using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;
using ERPWebApplication.AppClass.DataAccess;
using System.Data;
using System.Net.Mail;
using System.IO;

namespace ERPWebApplication.AppClass.DataAccess
{
    public class MailServiceController : DataAccessBase
    {
        public void eMailSendService(CompanySetup objCompanySetup, MailServiceSetup objMailServiceSetup)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select MailFrom,Passkey,SmtpServer,MailSubject,MailBody,IspAsswordWillSend,IsUserNameWillSend"
                            + " from uEmailConfigurationSetup a"
                            + " inner join uEmailTypeSetup b on a.MailtypeID=b.MailtypeID"
                            + " where CompanyID= " + objCompanySetup.CompanyID + " and a.MailtypeID='" + objMailServiceSetup.MailtypeID + "'";

                dt = clsDataManipulation.GetData(this.ConnectionString, sql);

                foreach (DataRow dr in dt.Rows)
                {
                    objMailServiceSetup.SmtpServer = dr["SmtpServer"].ToString();

                    if (objMailServiceSetup.EmailFrom == null)
                    {
                        objMailServiceSetup.EmailFrom = dr["MailFrom"].ToString();
                    }
                    if (objMailServiceSetup.MailSubject == null)
                    {
                        objMailServiceSetup.MailSubject = dr["MailSubject"].ToString();
                    }
                    if (objMailServiceSetup.MailBody == null)
                    {
                        objMailServiceSetup.MailBody = dr["MailBody"].ToString();
                    }
                    //if (drOrganigationElement["IsUserNameWillSend"].ToString().Equals("Y") == true)
                    //{
                    //    eMailBody = eMailBody + "\nuser name:" + drOrganigationElement["IsUserNameWillSend"].ToString();
                    //}
                    //if (drOrganigationElement["IspAsswordWillSend"].ToString().Equals("Y") == true)
                    //{
                    //    eMailBody = eMailBody + "\nPassword:" + drOrganigationElement["IspAsswordWillSend"].ToString();
                    //}
                }



                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(objMailServiceSetup.EmailFrom.ToString());
                mailMessage.To.Add(objMailServiceSetup.EmailTo.ToString());
                if (objMailServiceSetup.EmailCC != null)
                    mailMessage.CC.Add(objMailServiceSetup.EmailCC.ToString());
                if (objMailServiceSetup.EmailBCC != null)
                    mailMessage.Bcc.Add(objMailServiceSetup.EmailBCC.ToString());

                mailMessage.Subject = objMailServiceSetup.MailSubject.ToString();
                mailMessage.Body = objMailServiceSetup.MailBody.ToString();
                

                foreach (System.Web.HttpPostedFile fu1 in objMailServiceSetup.AttachItem)
                {
                    string filename = Path.GetFileName(fu1.FileName);
                    if (fu1.ContentLength > 0)
                    {
                        Attachment fileAttach = new Attachment(fu1.InputStream, filename);
                        mailMessage.Attachments.Add(fileAttach);
                    }
                }

                SmtpClient smtp = new SmtpClient(objMailServiceSetup.SmtpServer);

                smtp.Send(mailMessage);
            }
            catch (Exception msgException)
            {
                throw msgException;
            }
        }

    }
}