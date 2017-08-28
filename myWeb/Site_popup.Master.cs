﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using myDLL;

namespace myWeb
{
    public partial class Site_popup : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddJavaScriptInclude();
            if (Session["username"] == null)
            {
                string strScript = "ClosePopUp('1');ClosePopUp('2');ClosePopUp('3');window.parent.document.location.href='../../Default.aspx';";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ClosePage", strScript, true);
                return;
            }            
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("th-TH");
        }

        protected void AddJavaScriptInclude()
        {
            HtmlGenericControl script;


            script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = (cCommon.AbsoluteWebRoot + "js/jquery-1.7.2.min.js");
            Page.Header.Controls.Add(script);

            script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = (cCommon.AbsoluteWebRoot + "js/jquery-ui-1.8.22.custom.js");
            Page.Header.Controls.Add(script);


            script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = (cCommon.AbsoluteWebRoot + "scripts/form.js");
            Page.Header.Controls.Add(script);

            script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = (cCommon.AbsoluteWebRoot + "javascript/AwNumeric.js");
            Page.Header.Controls.Add(script);

            script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = (cCommon.AbsoluteWebRoot + "javascript/AwTextBox.js");
            Page.Header.Controls.Add(script);

        }
    
    
    }

    
      
    
    //<script src="js/jquery.min.js" type="text/javascript"></script>
    
    //<script type="text/javascript" src="../js/jquery.easing.1.3.js"></script>

    //<script type="text/javascript" src="../js/alertbox.js"></script>

    //<script src="../../scripts/form.js" type="text/javascript"></script>



}
