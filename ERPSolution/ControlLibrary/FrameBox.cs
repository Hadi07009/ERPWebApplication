using System;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace ProudMonkey.Common.Controls
{
    public class FrameBox:    CompositeControl
    {
        #region Control Properties
        [Description("Set the ImageUrl of the FrameBox header.")]
        public string HeaderImageUrl { private get; set; }
        [Description("Set the text fore color of the FrameBox header.")]
        public string HeaderTextColor { private get; set; }
        [Description("Set the text font of the FrameBox header.")]
        public string HeaderTextFont { private get; set; }
        [Description("Set the background color of the FrameBox header.")]
        public string HeaderBackgroundColor { private get; set; }
        [Description("Set image of the FrameBox close button.")]
        public string CloseButtonImageUrl { private get; set; }
        #endregion

        #region Private Method
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
                string path = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.sprite.png");
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

            #region buttons
           
            if (!string.IsNullOrEmpty(CloseButtonImageUrl)) {
                imgCloseButton.ImageUrl = CloseButtonImageUrl;
            }
            else {
                //USE DEFAULT
                string imgCloseUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.close.png");
                imgCloseButton.ImageUrl = imgCloseUrl;
            }

            #endregion
        }
        #endregion

        #region Control Initialization
        private ModalPopupExtender ajaxModal = new ModalPopupExtender();
        private Panel panelFrameBox = new Panel();
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
        private Button btnOk = new Button();
        private Button btnCancel = new Button();
        private Label lblMessageText = new Label();
        private Image imgMessageType = new Image();
        HtmlGenericControl htmlFrame = new HtmlGenericControl("iframe");
        #endregion

        #region Overriden Methods
        protected override void OnLoad(EventArgs e) {
            EnsureChildControls();
            base.OnLoad(e);
            #region Initialize Client FrameBox

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MessageBoxClientWrapper", @"
            function ShowFrameBox(headerText,url,height,width)
            {
                if(width == undefined)
                    width = '400';
                if(height == undefined)
                    height = '300';
                var ajaxModal = $get('" + ajaxModal.ClientID + @"');
                $get('" + panelFrameBox.ClientID + @"').style.width = width+'px'; 
                $get('" + panelBody.ClientID + @"').style.height = height+'px';  
                $get('" + htmlFrame.ClientID + @"').src = url;
                $get('" + htmlFrame.ClientID + @"').target = '_parent';
                $get('" + htmlFrame.ClientID + @"').style.width = width+'px';        
                $get('" + htmlFrame.ClientID + @"').style.height = height+'px'; 
                $get('" + lblPopupHeaderText.ClientID + @"').innerHTML = headerText;    
                $find('" + ajaxModal.BehaviorID + @"').show();
            }

            function HideFrameBox(){
                $find('" + ajaxModal.BehaviorID + @"').hide();
            }
            ", true);
            #endregion
        }
        protected override void OnInit(EventArgs e) {

            base.OnInit(e);
            System.Web.UI.HtmlControls.HtmlLink cssLink = new System.Web.UI.HtmlControls.HtmlLink();
            string cssUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.MessageBox.css");
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
            //lblMessageText.CssClass = "label_text";

            imgCloseButton.ID = "imgCloseButton";
            imgCloseButton.Attributes.Add("style", "position:absolute;right:4px; top:1px; cursor:hand;");

            btnOk.ID = "btnOk";
            btnOk.Width = Unit.Pixel(40);
            btnOk.Text = "OK";

            btnCancel.ID = "btnCancel";
            btnCancel.Width = Unit.Pixel(40);
            btnCancel.Text = "Cancel";

            htmlFrame.ID = "htmlFrame";
            htmlFrame.Attributes.Add("style", "border:none");
            #endregion

            #region Modal PopUp Construction
            panelFrameBox.ID = "panelFrameBox";
            panelFrameBox.Attributes.Add("style", "display:none");
            panelFrameBox.CssClass = "confirmBox";

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
            
            panelBody.Controls.Add(htmlFrame);

            //Set up Modal Popup
            ajaxModal.ID = "ajaxModal";
            ajaxModal.TargetControlID = lbTarget.ClientID;
            ajaxModal.PopupControlID = panelFrameBox.ClientID;
            //ajaxModal.OkControlID = btnOk.ClientID;
            ajaxModal.CancelControlID = imgCloseButton.ClientID;
            ajaxModal.BackgroundCssClass = "msgbox_messagemodalbackground";

            this.Controls.Add(lbTarget);
            this.Controls.Add(ajaxModal);
            this.Controls.Add(panelFrameBox);

            //Add Header, Body and Footer elements in the main Container
            panelFrameBox.Controls.Add(panelHeader);
            panelFrameBox.Controls.Add(panelBody);
            //panelMessageBox.Controls.Add(panelFooter);

            #endregion

            base.CreateChildControls();
        }
        protected override void RenderContents(HtmlTextWriter output) {
            lbTarget.RenderControl(output);
            ajaxModal.RenderControl(output);
            panelFrameBox.RenderControl(output);
        }
        #endregion
    }
}
