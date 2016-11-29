using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DocumentUpload
/// </summary>
public class DocumentUpload
{
	public DocumentUpload()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string _documentTypeCode;
    private string _description;
    private string _documentContent;
    private string _entryUser;


    public string DocumentTypeCode
    {
        get { return _documentTypeCode; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Must select" + " document type ");
            }
            _documentTypeCode = value;
        }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string DocumentContent
    {
        get { return _documentContent; }
        set { _documentContent = value; }
    }

    public string EntryUser
    {
        get { return _entryUser; }
        set { _entryUser = value; }
    }

    public string documentCode { get; set; }

    public string documentName { get; set; }
    public int referenceNo { get; set; }
    public int dstatus { get; set; }
    public string DocumentFor { get; set; }
}