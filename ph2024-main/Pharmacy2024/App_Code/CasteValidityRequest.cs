using SynthesysDAL;
using System.Data;
using System.Data.SqlClient;



public class CasteValidityRequest
{

    DBConnection db = new DBConnection();
    public CasteValidityRequest()
    {

    }

    public DataSet CheckCandidateCasteValidityRequestStatus(long PersonalID)
    {
        DataSet ds = db.ExecuteDataSet("sp_CheckCandidateCasteValidityRequestStatus", new SqlParameter[] { new SqlParameter("@PersonalID", PersonalID) });
        db.Dispose();
        return ds;
    }

    public void CandidateCasteValidityRequestStatus(long PersonalID, string CasteValidityStatus, string CVCApplicationNo, string CVCApplicationDate, string CVCAuthority, string CVCName, string CCNumber, string CreatedBy, string ModifiedBy, string fileurl, int docid, string CVCDistrict)
    {
        string IPAddress = UserInfo.GetIPAddress();
        db.ExecuteNonQuery("sp_ChangeCandidateCasteValidityRequest", new SqlParameter[]
        {
            new SqlParameter("@PersonalID", PersonalID),
            new SqlParameter("@CasteValidityStatus", CasteValidityStatus),
            new SqlParameter("@CVCApplicationNo", CVCApplicationNo),
            new SqlParameter("@CVCApplicationDate", CVCApplicationDate),
            new SqlParameter("@CVCAuthority", CVCAuthority),
            new SqlParameter("@CVCName", CVCName),
            new SqlParameter("@CCNumber", CCNumber),
            new SqlParameter("@CVCDistrict", CVCDistrict),
            new SqlParameter("@ModifiedBy", ModifiedBy),
            new SqlParameter("@ModifiedByIPAddress", IPAddress),
             new SqlParameter("@CreatedBy", CreatedBy),
            new SqlParameter("@CreatedByIPAddress", IPAddress),
            new SqlParameter("@fileurl", fileurl),
            new SqlParameter("@docid", docid)
        });
        db.Dispose();
    }

}
