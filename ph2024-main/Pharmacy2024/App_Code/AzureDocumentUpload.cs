using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public class AzureDocumentUpload
{
    public string UploadDocument(string ContainerName, string filename, System.IO.Stream uploadfilestream, string contentType, string foldername = "")
    {
        string DocumentURL = "";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);
        container.CreateIfNotExists();
        //container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        string uploadfilelocation = filename;
        if (foldername != "")
            uploadfilelocation = foldername + "/" + filename;

        CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfilelocation.ToLower());
        blockBlob.Properties.ContentType = contentType;
        blockBlob.UploadFromStream(uploadfilestream);

        DocumentURL = ConfigurationManager.AppSettings["StorageBaseURL"] + ContainerName + "/" + uploadfilelocation;

        return DocumentURL;
    }

    public string UploadDocumentFromByteArray(string ContainerName, string filename, byte[] photobytes, string foldername = "")
    {
        string DocumentURL = "";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(ContainerName.ToLower());
        container.CreateIfNotExists();
        //container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        string uploadfilelocation = filename;
        if (foldername != "")
            uploadfilelocation = foldername + "/" + filename.ToLower();

        CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfilelocation.ToLower());

        blockBlob.UploadFromByteArray(photobytes, 0, photobytes.Length);

        DocumentURL = ConfigurationManager.AppSettings["StorageBaseURL"] + ContainerName + "/" + uploadfilelocation;

        return DocumentURL.ToLower();
    }
    public string UploadDocumentFromByteArrayWithContentType(string ContainerName, string filename, byte[] photobytes, string contentType, string foldername = "")
    {
        string DocumentURL = "";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(ContainerName.ToLower());
        container.CreateIfNotExists();
        //container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        string uploadfilelocation = filename;
        if (foldername != "")
            uploadfilelocation = foldername + "/" + filename.ToLower();

        CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfilelocation.ToLower());
        blockBlob.Properties.ContentType = contentType;
        blockBlob.UploadFromByteArray(photobytes, 0, photobytes.Length);

        DocumentURL = ConfigurationManager.AppSettings["StorageBaseURL"] + ContainerName + "/" + uploadfilelocation;

        return DocumentURL.ToLower();
    }

    public bool Exists(String filepath)
    {
        var blob = GetBlobReference(filepath, false);
        return blob.Exists();

    }
    private CloudBlockBlob GetBlobReference(string filePath, bool createContainerIfMissing = true)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient client = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = client.GetContainerReference(ConfigurationManager.AppSettings["BlobContainerName"].ToLower());

        if (createContainerIfMissing && container.CreateIfNotExists())
        {
            //Public blobs allow for public access to the image via the URI
            //But first, make sure the blob exists
            //container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        CloudBlockBlob blob = container.GetBlockBlobReference(filePath);

        return blob;
    }
    private byte[] GetImage(string url)
    {
        Stream stream = null;
        byte[] buf;

        try
        {
            WebProxy myProxy = new WebProxy();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            stream = response.GetResponseStream();

            using (BinaryReader br = new BinaryReader(stream))
            {
                int len = (int)(response.ContentLength);
                buf = br.ReadBytes(len);
                br.Close();
            }

            stream.Close();
            response.Close();
        }
        catch (Exception exp)
        {
            buf = null;
        }

        return (buf);
    }
    public String ConvertImageURLToBase64(String url)
    {
        string processURL = url;
        if (!Exists(processURL))
            processURL = processURL.ToLower();
        StringBuilder _sb = new StringBuilder();

        Byte[] _byte = this.GetImage(url);
        if (_byte == null)
            _byte = this.GetImage(url.ToLower());

        //if (Exists(processURL))
        //{
        //    Byte[] _byte = this.GetImage(processURL);

        //    _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
        //}
        //else
        //{
        //    Byte[] _byte = this.GetImage(url);

        //    _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
        //}

        _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
        return _sb.ToString();
    }
    public String ConvertImageURLToDataURL(String url)
    {
        string processURL = url;
        if (!Exists(processURL))
            processURL = processURL.ToLower();
        StringBuilder _sb = new StringBuilder();

        Byte[] _byte = this.GetImage(url);
        if (_byte == null)
            _byte = this.GetImage(url.ToLower());

        //if (Exists(processURL))
        //{
        //    Byte[] _byte = this.GetImage(processURL);

        //    sb.Append(Convert.ToBase64String(_byte, 0, byte.Length));
        //}
        //else
        //{
        //    Byte[] _byte = this.GetImage(url);

        //    sb.Append(Convert.ToBase64String(_byte, 0, byte.Length));
        //}

        _sb.Append("data:image/jpg;base64,");
        _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));
        return _sb.ToString();
    }
    public string GetBlobContentAsBase64(string folderName, string filePath)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["BlobContainerName"].ToLower());

        string fileName = Path.GetFileName(filePath).ToLower();
        string uploadfilelocation = fileName;
        if (folderName != "")
            uploadfilelocation = folderName.ToLower() + "/" + fileName;

        CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfilelocation.ToLower());

        using (MemoryStream ms = new MemoryStream())
        {
            blockBlob.DownloadToStream(ms);
            byte[] fileBytes = ms.ToArray();

            string fileExtension = Path.GetExtension(filePath).ToLower();
            string preFix = "";
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    if (folderName.ToLower() == "studentdocumentsthumbnail")
                        preFix = "data:image/png;base64,";
                    else
                        preFix = "data:image/jpg;base64,";
                    break;
                case ".pdf":
                    preFix = "data:application/pdf;base64,";
                    break;
                default:
                    break;
            }
            return preFix + Convert.ToBase64String(fileBytes);
        }
    }

    public string GetBlobContentOnly(string folderName, string filePath)
    {
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["BlobContainerName"].ToLower());

        string fileName = Path.GetFileName(filePath).ToLower();
        string uploadfilelocation = fileName;
        if (folderName != "")
            uploadfilelocation = folderName.ToLower() + "/" + fileName;

        CloudBlockBlob blockBlob = container.GetBlockBlobReference(uploadfilelocation.ToLower());

        using (MemoryStream ms = new MemoryStream())
        {
            blockBlob.DownloadToStream(ms);
            byte[] fileBytes = ms.ToArray();

            return Convert.ToBase64String(fileBytes);
        }
    }
}
