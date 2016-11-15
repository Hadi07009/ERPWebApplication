using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace ProudMonkey.Common.Controls
{
    public class ConfirmBox : CompositeControl
    {
        #region Control Properties
        [Description("Set the ImageUrl of the ConfirmBox header.")]
        public string HeaderImageUrl { private get; set; }
        [Description("Set the background color of the ConfirmBox header.")]
        public string HeaderTextColor { private get; set; }
        [Description("Set the text font of the ConfirmBox header.")]
        public string HeaderTextFont { private get; set; }
        [Description("Set the background color of the ConfirmBox header.")]
        public string HeaderBackgroundColor { private get; set; }
        [Description("Set the background color of the ConfirmBox body.")]
        public string BodyBackgroundColor { private get; set; }
        [Description("Set the text color of the ConfirmBox body.")]
        public string BodyTextColor { private get; set; }
        [Description("Set the text font color of the ConfirmBox body.")]
        public string BodyTextFont { private get; set; }
        [Description("Set image of the ConfirmBox Yes button.")]
        public string YesButtonImageUrl { private get; set; }
        [Description("Set image of the ConfirmBox No button.")]
        public string NoButtonImageUrl { private get; set; }
        [Description("Set image of the ConfirmBox close button.")]
        public string CloseButtonImageUrl { private get; set; }
        #endregion

        #region Private Method
        private void SetControlProperties() {
            #region PROPERTY ASSIGNMENT

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

            if (!string.IsNullOrEmpty(YesButtonImageUrl)) {
                btnOk.ImageUrl = YesButtonImageUrl;
            }
            else {
                //USE DEFAULT
                string imgBtnYesUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.btnSmYes.png");
                btnOk.ImageUrl = imgBtnYesUrl;
            }

            if (!string.IsNullOrEmpty(NoButtonImageUrl)) {
                btnCancel.ImageUrl = NoButtonImageUrl;
            }
            else {
                //USE DEFAULT
                string imgBtnNoUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.btnSmNo.png");
                btnCancel.ImageUrl = imgBtnNoUrl;
            }

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
        private Image imgCloseButton = new Image();
        private ImageButton btnOk = new ImageButton();
        private ImageButton btnCancel = new ImageButton();
        private Label lblMessageText = new Label();
        private Image imgMessageType = new Image();
        private CheckBox cbDontAskAgain = new CheckBox();

        private HiddenField hfDontAsk = new HiddenField();
        #endregion

        #region Overriden Methods
        protected override void OnLoad(EventArgs e) {
            EnsureChildControls();
            base.OnLoad(e);

            string imgPath = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.imgWarning.png");

            #region Initialize Client ConfirmBox
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ConfirmBoxClientWrapper", @"
     
                var _source;
                var _popup;
                
                function ShowConfirmBox(source,message,height,width){
                    this._source = source;

                    //Uncheck CheckBox on every load
                    var cb = $get('" + cbDontAskAgain.ClientID + @"');
                    cb.checked = false;
            
                    //Handle the Don't Ask Again option
                    var flag = $get('" + hfDontAsk.ClientID + @"');
                    var splitItem = flag.value.split(',');
                    var caller;
                    for(var i =0; i < splitItem.length; i++){
                        if(splitItem[i] == _source.name + '_hide'){
                        caller = splitItem[i];
                        break;}
                    }
                        if(caller == _source.name + '_hide'){
                            //do normal postback without confirm
                             __doPostBack(this._source.name, '');
                        }
                        else{
                            if(width == undefined)
                                width = '360';
                            if(height == undefined)
                                height = '60';
                                var ajaxModal = $get('" + ajaxModal.ClientID + @"');
                                $get('" + lblPopupHeaderText.ClientID + @"').innerHTML = 'Confirmation';
                                $get('" + lblMessageText.ClientID + @"').innerHTML = message;
                                $get('" + panelMessageBox.ClientID + @"').style.width = width+'px';        
                                $get('" + panelBody.ClientID + @"').style.height = height+'px';
                                $get('" + panelBodyRight.ClientID + @"').style.width = (parseInt(width) - 70) +'px';  
                                $get('" + lblMessageText.ClientID + @"').style.width = (parseInt(width) - 80) +'px';          
                                $get('" + imgMessageType.ClientID + @"').src = '" + imgPath + @"';
                                $find('" + ajaxModal.BehaviorID + @"').show();
                                this._popup = $find('" + ajaxModal.BehaviorID + @"');
                                this._popup.show();
                                $get('" + btnCancel.ClientID + @"').focus();
                        }
                }
                
                function okClick(){
                    var cb = $get('" + cbDontAskAgain.ClientID + @"');
                    var flag = $get('" + hfDontAsk.ClientID + @"');
                    if(cb.checked){
                    //if opt to show the comfirm box
                    flag.value += _source.name + '_hide' + ',';   
                    //  use the cached button as the postback source
                    __doPostBack(this._source.name, '');
                    }
                    else{
                    __doPostBack(this._source.name, '');
                    }
                    this._popup.hide();
                }
                
                function cancelClick(){
                    //  find the confirm ModalPopup and hide it 
                    this._popup.hide();
                    //  clear the event source
                    this._source = null;
                    this._popup = null;
                }
                
                function dontShowMe(){
                
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
            lblMessageText.CssClass = "label_text";

            imgCloseButton.ID = "imgCloseButton";
            imgCloseButton.CssClass = "close";

            string imgMsgTypeUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ProudMonkey.Common.Controls.css.images.imgWarning.png");
            imgMessageType.ID = "imgMessageType";
            imgMessageType.ImageUrl = imgMsgTypeUrl;

            cbDontAskAgain.ID = "cbDontAskAgain";
            cbDontAskAgain.Text = "Don't ask me again!";

            btnOk.ID = "btnOk";
            btnOk.Width = Unit.Pixel(70);
            btnOk.Height = Unit.Pixel(22);
            btnOk.CssClass = "button_small_active";

            btnCancel.ID = "btnCancel";
            btnCancel.Width = Unit.Pixel(70);
            btnCancel.Height = Unit.Pixel(22);
            btnCancel.CssClass = "button_small_active";

            hfDontAsk.ID = "hfDontAsk";

            LiteralControl space = new LiteralControl();
            space.Text = "&nbsp;";
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
            panelFooterLeft.Controls.Add(cbDontAskAgain);
            panelFooterLeft.CssClass = "left";
            panelFooterRight.Controls.Add(btnOk);
            panelFooterRight.Controls.Add(space);
            panelFooterRight.Controls.Add(btnCancel);
            panelFooterRight.CssClass = "right";
            panelFooter.Controls.Add(panelFooterLeft);
            panelFooter.Controls.Add(panelFooterRight);

            //Set up Modal Popup
            ajaxModal.ID = "ajaxModal";
            ajaxModal.TargetControlID = lbTarget.ClientID;
            ajaxModal.PopupControlID = panelMessageBox.ClientID;
            ajaxModal.OkControlID = btnOk.ClientID;
            ajaxModal.OnOkScript = "okClick();";
            ajaxModal.CancelControlID = btnCancel.ClientID;
            ajaxModal.OnCancelScript = "cancelClick();";
            ajaxModal.BackgroundCssClass = "msgbox_messagemodalbackground";

            this.Controls.Add(lbTarget);
            this.Controls.Add(ajaxModal);
            this.Controls.Add(panelMessageBox);
            this.Controls.Add(hfDontAsk);

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
            hfDontAsk.RenderControl(output);
        }
        #endregion

    }
}
