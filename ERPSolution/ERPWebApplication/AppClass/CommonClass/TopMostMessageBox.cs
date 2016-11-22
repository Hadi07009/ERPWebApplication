using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32; 

namespace ERPWebApplication.AppClass.CommonClass
{
    /// <summary>
    /// Displays MessageBox messages as a top most window
    /// </summary>
    static public class TopMostMessageBox
    {
        /// <summary>
        /// Displays a <see cref="MessageBox"/> but as a TopMost window.
        /// </summary>
        /// <param name="message">The text to appear in the message box.</param>
        /// <param name="title">The title of the message box.</param>
        /// <returns>The button pressed.</returns>
        /// <remarks>This will display with no title and only the OK button.</remarks>
        /// 


        public static void MsgConfirmBox(System.Web.UI.WebControls.Button btn, string strMessage)
        {
            strMessage = strMessage.Replace("'", "\\'");
            btn.Attributes.Add("onclick", "return confirm('" + strMessage + "');");

        }

        public static void MsgConfirmBox(string strMessage)
        {


            strMessage = strMessage.Replace("'", "\\'");
            string script = "<script type= \"text/javascript\">alert('" + strMessage + "'); </script> ";

            System.Web.UI.Page page =System.Web.HttpContext.Current.CurrentHandler as System.Web.UI.Page;
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {

                //page.ClientScript.RegisterClientScriptBlock(typeof (clsStatic), "alert", script);
                System.Web.UI.ScriptManager.RegisterStartupScript(page, typeof(System.Web.UI.Page), "temp", script, false);
            }
        }



        public static void Show(string message)
        {
            //return Show(message, string.Empty, MessageBoxButtons.OK);
            string script = "<script type= \"text/javascript\">alert('" + message + "'); </script> ";

            System.Web.UI.Page page = System.Web.HttpContext.Current.CurrentHandler as System.Web.UI.Page;
            System.Web.UI.ScriptManager.RegisterStartupScript(page, typeof(System.Web.UI.Page), "temp", script, false);
            
        }


        static public DialogResult Show(string message, string title)
        {
            return Show(message, title, MessageBoxButtons.OK);

        }


        static public bool Show1(string message, string title)
        {
        
            // Create a host form that is a TopMost window which will be the parent of the MessageBox.
            Form topmostForm = new Form();
            MessageBoxButtons buttons;
             buttons = MessageBoxButtons.OKCancel;
             
            // We do not want anyone to see this window so position it off the visible screen and make it as small as possible
            topmostForm.Size = new System.Drawing.Size(900, 800);
            topmostForm.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10, rect.Right + 10);
            
            topmostForm.Show(); 
            // Make this form the active form and make it TopMost
           
            topmostForm.Focus();
            topmostForm.Activate();
            //topmostForm.BringToFront();
            topmostForm.TopMost = true;
            
           
          
            // Finally show the MessageBox with the form just created as its owner
            DialogResult result = MessageBox.Show(topmostForm.Owner, message, title,buttons);
         

            topmostForm.Dispose(); // clean it up all the way

            if (result == DialogResult.OK)
            {
                
                return true;
            }
            else
            {
              
                return false;
            }
        }




        static public DialogResult Show(string message, string title, MessageBoxButtons buttons)
        {

            // Create a host form that is a TopMost window which will be the parent of the MessageBox.
            Form topmostForm = new Form();



            // We do not want anyone to see this window so position it off the visible screen and make it as small as possible
            topmostForm.Size = new System.Drawing.Size(1, 6);
            topmostForm.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10, rect.Right + 10);

            topmostForm.Show();
            // Make this form the active form and make it TopMost
            topmostForm.Focus();
            topmostForm.Activate();
            //topmostForm.BringToFront();
            topmostForm.TopMost = true;


           DialogResult result = MessageBox.Show(topmostForm.Owner, message, title, buttons);
           

            topmostForm.Dispose();

            return result;

        }
    }
}
