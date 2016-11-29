using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DocumentUploadController
/// </summary>
public class DocumentUploadController
{
    public DocumentUploadController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void DocumentUpload(string connectionString, DocumentUpload objDocumentUpload)
    {
        string storedProcedureText = "exec [DocumentUploadInto_HRMS_Document] '" + objDocumentUpload.DocumentFor + "','" + objDocumentUpload.DocumentTypeCode + "','" + objDocumentUpload.Description + "','" + objDocumentUpload.DocumentContent + "','" + objDocumentUpload.EntryUser + "','" + objDocumentUpload.documentCode + "','" + objDocumentUpload.documentName + "'";
        DataManipulation.StoredProcedureExecuteNonQuery(connectionString, storedProcedureText);
    }

    public string GetReferenceNo(string connectionString)
    {
        string referenceNo = null;
        const string storedProcedureCommand = "exec [DocumentUploadGetReferenceNoFrom_HRMS_Document] ";
        var dtReference = DataManipulation.GetData(connectionString, storedProcedureCommand);
        if (dtReference.Rows.Count > 0)
        {
            referenceNo = dtReference.Rows[0][0].ToString();
        }
        return referenceNo;
    }

    public DataTable GetActiveDocument(string connectionString,int doctype)
    {
        string storedProcedureCommand = "exec [DocumentUploadGetActiveDocumentFrom_HRMS_Document] " + doctype.ToString();
        var dtActiveDocument = DataManipulation.GetData(connectionString,
            storedProcedureCommand);
        return dtActiveDocument;
    }

    public DataTable GetInactiveDocument(string connectionString,int doctype)
    {
        string storedProcedureCommand = "exec [DocumentUploadGetInActiveDocumentFrom_HRMS_Document] " + doctype.ToString();

        var dtInactiveDocument = DataManipulation.GetData(connectionString,
            storedProcedureCommand);
        return dtInactiveDocument;
    }
    public void UpdateDocumentSrtatus(string connectionString, DocumentUpload objDocumentUpload)
    {
        string storedProcedureCommand = "exec [spUpdateDocumentSrtatus] " + objDocumentUpload.referenceNo + "," + objDocumentUpload.dstatus + "";
        DataManipulation.StoredProcedureExecuteNonQuery(connectionString,storedProcedureCommand);
    }
   
}