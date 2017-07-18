using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.AppClass.Model
{
    public class MailServiceSetup
    {
        private string _mailtypeID;

        public string MailtypeID
        {
            get { return _mailtypeID; }
            set { _mailtypeID = value; }
        }
        private string _mailTypeTitle;

        public string MailTypeTitle
        {
            get { return _mailTypeTitle; }
            set { _mailTypeTitle = value; }
        }
        private string _mailSubject;

        public string MailSubject
        {
            get { return _mailSubject; }
            set { _mailSubject = value; }
        }
        private string _mailBody;

        public string MailBody
        {
            get { return _mailBody; }
            set { _mailBody = value; }
        }
        private string _emailFrom;

        public string EmailFrom
        {
            get { return _emailFrom; }
            set { _emailFrom = value; }
        }
        private string _emailTo;

        public string EmailTo
        {
            get { return _emailTo; }
            set { _emailTo = value; }
        }
        private string _emailCC;

        public string EmailCC
        {
            get { return _emailCC; }
            set { _emailCC = value; }
        }
        private string _emailBCC;

        public string EmailBCC
        {
            get { return _emailBCC; }
            set { _emailBCC = value; }
        }
        private ArrayList _attachItem;

        public ArrayList AttachItem
        {
            get { return _attachItem; }
            set { _attachItem = value; }
        }
        private string _smtpServer;

        public string SmtpServer
        {
            get { return _smtpServer; }
            set { _smtpServer = value; }
        }
    }
}