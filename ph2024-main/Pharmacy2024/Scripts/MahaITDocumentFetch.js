


function DisplayFetchDocu(dsResponse, documentID, IsBarcodeFetch) {
    //var personalID = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
    //var documentID = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
    //var IsBarcodeFetch = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;
     
    if (IsBarcodeFetch == "Y") {
       // var dsResponse = classname.GetDocumentFetchData(personalID, documentID);
        var obj = JSON.parse(dsResponse.json);
        if (obj.value.ApplicantName != null) {
            if (documentID == 21) {
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = CastTable(obj);
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
            else if (documentID == 32 || documentID == 34) {
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = IncomeTable(obj);
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
            else if (documentID == 22) {
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = CastValidityTable(obj);
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
            else if (documentID == 1 || documentID == 2 || documentID == 11) {
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = AgeDomicileNationalityTable(obj);
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
            else if (documentID == 25) {
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = DisabilityCertificateTable(obj);
                 document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
            else if (documentID == 24) {
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'block';
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
                var table = NCLTable(obj);
                document.getElementById('rightContainer_contentViewDocument_trFetchDocView').appendChild(table);
            }
        }
    }
    else {
         document.getElementById('rightContainer_contentViewDocument_trFetchDocView').style.display = 'none';
         document.getElementById('rightContainer_contentViewDocument_trFetchDocView').innerHTML = "";
    }
}


function DisplayFetchDocuVerification(dsResponse, documentID, IsBarcodeFetch) {
    //var personalID = corrRow.cells[corrRow.cells.length - 2].getElementsByTagName("input")[0].value;
    //var documentID = corrRow.cells[corrRow.cells.length - 3].getElementsByTagName("input")[0].value;
    //var IsBarcodeFetch = corrRow.cells[corrRow.cells.length - 4].getElementsByTagName("input")[0].value;

    if (IsBarcodeFetch == "Y") {
        // var dsResponse = classname.GetDocumentFetchData(personalID, documentID);
        var obj = JSON.parse(dsResponse.json);
        if (obj.value.ApplicantName != null) {
            if (documentID == 21) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = CastTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
            else if (documentID == 32 || documentID == 34) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = IncomeTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
            else if (documentID == 22) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = CastValidityTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
            else if (documentID == 1 || documentID == 2 || documentID == 11) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = AgeDomicileNationalityTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
            else if (documentID == 25) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = DisabilityCertificateTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
            else if (documentID == 24) {
                document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'block';
                document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
                var table = NCLTable(obj);
                document.getElementById('rightContainer_ContentTable2_divcondoc').appendChild(table);
            }
        }
    }
    else {
        document.getElementById('rightContainer_ContentTable2_divcondoc').style.display = 'none';
        document.getElementById('rightContainer_ContentTable2_divcondoc').innerHTML = "";
    }
}


function CastTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 5;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);



    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Caste';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Caste;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'BenfiName';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.BenfiName;
    tr1.appendChild(td);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'ClosedOn ';
    tr.appendChild(th);
    var td = document.createElement("td");
    //td.innerHTML = obj.value.ClosedOn.Day + '/' + obj.value.ClosedOn.Month + '/' + obj.value.ClosedOn.Year;
    td.innerHTML = obj.value.ClosedOn;
    tr1.appendChild(td);

    return table;

}
function IncomeTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 7;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Years';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Years;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'First Year Income';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.FirstYearIncome;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Second Year Income';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.SecondYearIncome;
    tr1.appendChild(td);
    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Third Year Income';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.ThirdYearIncome;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'BenfiName ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.BenfiName;
    tr1.appendChild(td);

    return table;
}
function CastValidityTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 7;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);



    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'DistrictName';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.DistrictName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'CertificateDate';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.CertificateDate;
    tr1.appendChild(td);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'TribeName ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.TribeName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'CommitteeName ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.CommitteeName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'ApplicationType ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicationType;
    tr1.appendChild(td);

    return table;
}
function AgeDomicileNationalityTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 5;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);



    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'District Name';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.DistrictName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Years Of Residency';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.YearsOfResidency;
    tr1.appendChild(td);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Benfi Name ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.BenfiName;
    tr1.appendChild(td);



    //var th = document.createElement("th");      // TABLE HEADER.
    //th.innerHTML = 'Date ';
    //tr.appendChild(th);
    //var td = document.createElement("td");
    //td.innerHTML = obj.value.PaymentDate.Day + '/' + obj.value.PaymentDate.Month + '/' + obj.value.PaymentDate.Year;
    //tr1.appendChild(td);

    return table;
}

function DisabilityCertificateTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 6;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);



    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'DistrictName';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.DistrictName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'PercentageOfDisability';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.PercentageOfDisability;
    tr1.appendChild(td);


    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'DisabilityType ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.DisabilityType;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Date ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.AllottedDate;
    tr1.appendChild(td);


    return table;
}
function NCLTable(obj) {

    var table = document.createElement("table")
    table.setAttribute('class', 'AppFormTable');
    var tr0 = table.insertRow(0);
    var tr = table.insertRow(1);
    var tr1 = table.insertRow(-1);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Fetch from Aaple Sarkar Portal ';
    th.colSpan = 7;
    th.style.backgroundColor = "white";
    th.style.textAlign = "center";
    tr0.appendChild(th);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Applicant Name ';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.ApplicantName;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Barcode ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.Barcode;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Years';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.Years;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'First Year Income';
    tr.appendChild(th);

    var td = document.createElement("td");
    td.innerHTML = obj.value.FirstYearIncome;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Second Year Income';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.SecondYearIncome;
    tr1.appendChild(td);
    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'Third Year Income';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.ThirdYearIncome;
    tr1.appendChild(td);

    var th = document.createElement("th");      // TABLE HEADER.
    th.innerHTML = 'BenfiName ';
    tr.appendChild(th);
    var td = document.createElement("td");
    td.innerHTML = obj.value.BenfiName;
    tr1.appendChild(td);

    return table;
}