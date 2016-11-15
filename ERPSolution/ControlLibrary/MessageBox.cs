using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

//Created by Vincent Maverick D. Durano
//2009 - 2011

namespace ERPSolution.Common.Controls
{
    public class MessageBox : CompositeControl {

        #region Control Properties
        [Description ("Set the ImageUrl of the MessageBox header.")]
        public string HeaderImageUrl { private get; set; }
        [Description("Set the text fore color of the MessageBox header.")]
        public string HeaderTextColor { private get; set; }
        [Description("Set the text font of the MessageBox header.")]
        public string HeaderTextFont { private get; set; }
        [Description("Set the background color of the MessageBox header.")]
        public string HeaderBackgroundColor {private get; set; }
        [Description("Set the background color of the MessageBox body.")]
        public string BodyBackgroundColor { private get; set; }
        [Description("Set the text color of the MessageBox body.")]
        public string BodyTextColor { private get; set; }
        [Description("Set the text font color of the MessageBox body.")]
        public string BodyTextFont { private get; set; }
        [Description("Set image of the MessageBox OK button.")]
        public string OKButtonImageUrl { private get; set; }
        [Description("Set image of the MessageBox close button.")]
        public string CloseButtonImageUrl { private get; set; }
        #endregion

        #region Control Initialization
        private ModalPopupExtender ajaxModal = new ModalPopupExtender();
        private Panel panelMessageBox = new Panel();
        private Panel panelHeader = new Panel();
        private Panel panelHeaderMsg = new Panel();
        private Panel panelBody = new Panel();
        private Panel panelBodyLeft = new Panel();
        private Panel panelBodyRight = new Panel();
        private Panel panelFooter = new Panel();
        private Panel panelFooterLeft = new Panel();
        private Panel panelFooterRight = new Panel();
        private LinkButton lbTarget = new LinkButton();
        private Label lblPopupHeaderText = new Label();
        private ImageButton imgCloseButton = new ImageButton();
        private ImageButton btnOk = new ImageButton();
        private Label lblMessageText = new Label();
        private Image imgMessageType = new Image();
        #endregion

        #region Private Variable
        private const string _cssPrefix = "msgbox_";
        private string _imageUrl = string.Empty;
        private const int _height = 60;
        private const int _width = 340;
        #endregion

        #region Private Methods
        private void SetControlProperties() {

            #region header
            if (!string.IsNullOrEmpty(HeaderImageUrl)) {
                panelHeader.Attributes.Add("style", "background: url(" + HeaderImageUrl + ");repeat-x 0px -200px;");
            }
            else if (!string.IsNullOrEmpty(HeaderBackgroundColor)) {
                panelHeader.Attributes.Add("style", string.Format("background-color:{0};", HeaderBackgroundColor));
            }
            else {
                //USE DEFAULT
                string path = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.sprite.png");
                panelHeader.Attributes.Add("style", "background: url(" + path + ");repeat-x 0px -200px;");
            }

            if (!string.IsNullOrEmpty(HeaderTextColor)) {
                if (!string.IsNullOrEmpty(HeaderTextFont))
                    lblPopupHeaderText.Attributes.Add("style", string.Format("color:{0};font-family:{1};", HeaderTextColor, HeaderTextFont));
                else
                    lblPopupHeaderText.Attributes.Add("style", string.Format("color:{0};", HeaderTextColor));
            }
            else if (!string.IsNullOrEmpty(HeaderTextFont)) {
                if (!string.IsNullOrEmpty(HeaderTextColor))
                    lblPopupHeaderText.Attributes.Add("style", string.Format("font-family:{0};color:{1};", HeaderTextFont, HeaderTextColor));
                else
                    lblPopupHeaderText.Attributes.Add("style", string.Format("font-family:{0};", HeaderTextFont));
            }
            #endregion

            #region body
            if (!string.IsNullOrEmpty(BodyBackgroundColor)) {
                panelBody.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
                panelBodyLeft.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
                panelBodyRight.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
                panelFooter.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
                panelFooterLeft.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
                panelFooterRight.Attributes.Add("style", string.Format("background-color:{0};", BodyBackgroundColor));
            }

            if (!string.IsNullOrEmpty(BodyTextColor)) {
                if (!string.IsNullOrEmpty(BodyTextFont)) {
                    lblMessageText.Attributes.Add("style", string.Format("color:{0};font-family:{1};", BodyTextColor, BodyTextFont));
                }
                else {
                    lblMessageText.Attributes.Add("style", string.Format("color:{0};", BodyTextColor));
                }
            }

            if (!string.IsNullOrEmpty(BodyTextFont)) {
                if (!string.IsNullOrEmpty(BodyTextColor)) {
                    lblMessageText.Attributes.Add("style", string.Format("font-family:{0};color:{1};", BodyTextFont, BodyTextColor));
                }
                else {
                    lblMessageText.Attributes.Add("style", string.Format("font-family:{0};", BodyTextFont));
                }
            }

            #endregion

            #region buttons
            if (!string.IsNullOrEmpty(OKButtonImageUrl)) {
                btnOk.ImageUrl = OKButtonImageUrl;
            }
            else {
                //USE DEFAULT
                string imgBtnOkUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.btnSmOK.png");
                btnOk.ImageUrl = imgBtnOkUrl;
            }

            if (!string.IsNullOrEmpty(CloseButtonImageUrl)) {
                imgCloseButton.ImageUrl = CloseButtonImageUrl;
            }
            else {
                //USE DEFAULT
                string imgCloseUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.close.png");
                imgCloseButton.ImageUrl = imgCloseUrl;
            }

            #endregion
        }
        #endregion

        #region Overriden Methods
        protected override void OnLoad(EventArgs e) {
            EnsureChildControls();
            base.OnLoad(e);

            string imgPathWarning = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.imgWarning.png");
            string imgPathError = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.imgError.png");
            string imgPathInfo = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.imgWarning.png");
            string imgPathSuccess = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.images.imgSuccess.png");

            #region Initialize Client MessageBox
            
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MessageBoxClientWrapper", @"
            function ShowMsgBox(type,message,height,width)
            {
                if(width == undefined)
                    width = '340';
                if(height == undefined)
                    height = '60';
                var ajaxModal = $get('" + ajaxModal.ClientID + @"');
                var headerText = $get('" + lblPopupHeaderText.ClientID + @"');
                $get('" + lblMessageText.ClientID + @"').innerHTML = message;
                $get('" + panelMessageBox.ClientID + @"').style.width = width+'px';        
                $get('" + panelBody.ClientID + @"').style.height = height+'px';
                $get('" + panelBodyRight.ClientID + @"').style.width = (parseInt(width) - 70) +'px';  
                $get('" + lblMessageText.ClientID + @"').style.width = (parseInt(width) - 80) +'px'; 
                var imgType = $get('" + imgMessageType.ClientID + @"');
                if(type.toLowerCase() == 'success'){
                    headerText.innerHTML = 'Successful';
                    imgType.src = '" + imgPathSuccess + @"';
                }
                else if(type.toLowerCase() == 'error'){
                     headerText.innerHTML = 'Error';
                     imgType.src = '" + imgPathError + @"';
                }
                else if(type.toLowerCase() == 'warning'){
                     headerText.innerHTML = 'Warning';
                     imgType.src = '" + imgPathWarning + @"';
                }
                else{
                     headerText.innerHTML = 'Information';
                     imgType.src = '" + imgPathInfo + @"';
                }
               
                $find('" + ajaxModal.BehaviorID + @"').show();
                $get('" + btnOk.ClientID + @"').focus();
            }
            ", true);
            #endregion
        }
        protected override void OnInit(EventArgs e) {

            base.OnInit(e);
            System.Web.UI.HtmlControls.HtmlLink cssLink = new System.Web.UI.HtmlControls.HtmlLink();
            string cssUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ERPSolution.Common.Controls.css.MessageBox.css");
            cssLink.Href = cssUrl;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            this.Page.Header.Controls.Add(cssLink);

            SetControlProperties();
           
        }
        protected override void CreateChildControls() {

            #region Define Internal Control Properties
            lbTarget.ID = "lbTarget";//Target Control for Modal Popup

            lblPopupHeaderText.ID = "lblPopupHeader";
            lblMessageText.ID = "lblMessageDisplay";

            imgCloseButton.ID = "imgCloseButton";
            imgCloseButton.CssClass = "close";

            btnOk.ID = "btnOk";
            btnOk.Width = Unit.Pixel(70);
            btnOk.Height = Unit.Pixel(22);
            btnOk.CssClass = "button_small_active";
            btnOk.CausesValidation = false;
            #endregion

            #region Modal PopUp Construction
            panelMessageBox.ID = "panelMessageBox";
            panelMessageBox.Attributes.Add("style", "display:none");
            panelMessageBox.CssClass = "confirmBox";

            //Construct Header with Styles
            panelHeader.ID = "panelHeader";
            panelHeader.CssClass = "header";
            panelHeaderMsg.Controls.Add(lblPopupHeaderText);
            panelHeaderMsg.CssClass = "msg";
            panelHeader.Controls.Add(panelHeaderMsg);
            panelHeader.Controls.Add(imgCloseButton);

            //Construct Body with Styles
            panelBody.ID = "panelBody";
            panelBody.CssClass = "body"; 
            panelBodyLeft.Controls.Add(imgMessageType);
            panelBodyLeft.CssClass = "body-left";
            panelBodyRight.Controls.Add(lblMessageText);
            panelBodyRight.CssClass = "body-right";
            panelBody.Controls.Add(panelBodyLeft);
            panelBody.Controls.Add(panelBodyRight);

            //Construct Footer with Styles
            panelFooter.ID = "panelFooter";
            panelFooter.CssClass = "footer";
            panelFooterRight.Controls.Add(btnOk);
            panelFooterRight.CssClass = "right";
            panelFooter.Controls.Add(panelFooterRight);

            //Set up Modal Popup
            ajaxModal.ID = "ajaxModal";
            ajaxModal.TargetControlID = lbTarget.ClientID;
            ajaxModal.PopupControlID = panelMessageBox.ClientID;
            ajaxModal.OkControlID = btnOk.ClientID;
            ajaxModal.CancelControlID = imgCloseButton.ClientID;
            ajaxModal.BackgroundCssClass = "msgbox_messagemodalbackground";

            this.Controls.Add(lbTarget);
            this.Controls.Add(ajaxModal);
            //this.Controls.Add(lblPopupHeaderText);
            //this.Controls.Add(panelHeader);
            this.Controls.Add(panelMessageBox);

            //Add Header, Body and Footer elements in the main Container
            panelMessageBox.Controls.Add(panelHeader);
            panelMessageBox.Controls.Add(panelBody);
            panelMessageBox.Controls.Add(panelFooter);

            #endregion

            base.CreateChildControls();
        }
        protected override void RenderContents(HtmlTextWriter output) {
            lbTarget.RenderControl(output);
            ajaxModal.RenderControl(output);
            panelMessageBox.RenderControl(output);
        }
        #endregion

        #region Wrapper
        public void ShowError(string message){
            ShowError(message, _height, _width);
        }
        public void ShowError(string message, int height, int width) {
            _imageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MessageBox), "ERPSolution.Common.Controls.css.images.imgError.png");
            Show(MessageType.Error, message, height, width, _imageUrl);
        }

        public void ShowInfo(string message){
            ShowInfo(message, _height, _width);
        }
        public void ShowInfo(string message, int height, int width) {
            _imageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MessageBox), "ERPSolution.Common.Controls.css.images.imgInformation.png");
            Show(MessageType.Info, message, height, width, _imageUrl);
        }

        public void ShowSuccess(string message){
            ShowSuccess(message, _height, _width);
        }
        public void ShowSuccess(string message, int height, int width) {
            _imageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MessageBox), "ERPSolution.Common.Controls.css.images.imgSuccess.png");
            Show(MessageType.Success, message, height, width, _imageUrl);
        }

        public void ShowWarning(string message){
            ShowWarning(message, _height, _width);
        }
        public void ShowWarning(string message, int height, int width) {
            _imageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MessageBox), "ERPSolution.Common.Controls.css.images.imgWarning.png");
            Show(MessageType.Warning, message, height, width, _imageUrl);
        }

        public void ShowWelcome(string message) {
            ShowWelcome(message, _height, _width);
        }
        public void ShowWelcome(string message, int height, int width) {
            _imageUrl = this.Page.ClientScript.GetWebResourceUrl(typeof(MessageBox), "ERPSolution.Common.Controls.css.images.imgInformation.png");
            Show(MessageType.Welcome, message, height, width, _imageUrl);
        }
        #endregion

        #region Show control
        private void Show(MessageType messageType, string message, int height, int width, string imageUrl) {
            
            lblPopupHeaderText.Text = SetHeaderText(messageType.ToString().ToLower());
            lblMessageText.Text = message;
            panelBody.Height = height;
            panelMessageBox.Width = width;
            panelBodyRight.Width = width - 70;
            lblMessageText.Width = width - 80;
            imgMessageType.ImageUrl = imageUrl;
            //panelMessageBox.CssClass = _cssPrefix + messageType.ToString().ToLower();
            //panelMessageBox.Attributes.Add("style", "background-image: url('" + imageUrl + "');display:none");
            ajaxModal.Show();
            
            //OLD WorkAround
            //ScriptManager.RegisterStartupScript(this,this.GetType(), "ModalPopup",
            //"var done=false; Sys.Application.add_load(function() {if (!done) {AjaxControlToolkit.ModalPopupBehavior.invokeViaServer('" + ajaxModal.ClientID + "', true);} done=true; });", true);

            //this.Visible = true;
        }
        #endregion

        #region Enum
        private enum MessageType
        {
            Error = 1,
            Info = 2,
            Success = 3,
            Warning = 4,
            Welcome
        }
        #endregion

        #region Set Header
        private string SetHeaderText(string msgType) {
            string headerText = string.Empty;
            switch (msgType) {
                case "info":
                    headerText = "Information";
                    break;
                case "error":
                    headerText = "Error";
                    break;
                case "warning":
                    headerText = "Warning";
                    break;
                case "success":
                    headerText = "Successful";
                    break;
                case "welcome":
                    headerText = "Welcome!";
                    break;
            }

            return headerText;
        }
        #endregion

    }
}
