using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using myDLL;

namespace myWeb
{
    public partial class MainPerson : GlobalPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbnChangePassAlert.Attributes.Add("onclick", "OpenPopUp('600px','200px','93%','เปลี่ยนรหัสผ่าน','Person_Manage/global_change_password.aspx','1');return false;");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (ChkChangePass())
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterAlertRunScript", "$(document).ready(function () { setTimeout(function() { $('#" + lbnChangePassAlert.ClientID + "').trigger('click'); }, 1000); });", true);
            }
        }

        private bool ChkChangePass()
        {
            string strCriteria = string.Empty;
            cCommon oCommon = new cCommon();
            var ds = new DataSet();
            var dt = new DataTable();
            #region Criteria

            strCriteria = "Select count(1) as item_count from person_his ";
            strCriteria += "  Where person_code = '" + base.PersonCode + "' and person_password is null ";

            #endregion
            try
            {
                if (oCommon.SEL_SQL(strCriteria, ref ds, ref _strMessage))
                {
                    dt = ds.Tables[0];
                }
                var result = Helper.CInt(dt.Rows[0]["item_count"])  > 0;
                return result;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            return false;
        }
        
        protected void imbSlip_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Person_Manage/global_payment_slip.aspx");
        }

        protected void imbHistory_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Person_Manage/global_person_his.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //Session["person_username"] = "0";
            Response.Redirect("~/Default.aspx");
        }

        protected string myLink()
        {
            string strIDBase64 = string.Empty;
            try
            {
                Byte[] bytesToEncode;

                // bytesToEncode = System.Text.Encoding.UTF8.GetBytes("3570100525491");
                bytesToEncode = System.Text.Encoding.UTF8.GetBytes(base.PersonID);
                strIDBase64 = Convert.ToBase64String(bytesToEncode);
            }
            catch { }
           
            string strSal1 = "0.00";
            string strSal2 = "0.00";

            cCommon oCommon = new cCommon();
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            string strMessage = string.Empty;
            string strSQL = string.Empty;
            strSQL = "Select Sum(item_debit) as item_debit_sum from [view_person_item] where person_code ='" + base.PersonCode + "' and [item_name] like '%ปจต%' ";
            oCommon.SEL_SQL(strSQL, ref ds, ref strMessage);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strSal1 = Helper.CStr(ds.Tables[0].Rows[0]["item_debit_sum"], "0.00");
            }
            strSQL = "Select Sum(item_debit) as item_debit_sum from [view_person_item] where person_code ='" + base.PersonCode + "' and [item_name] like '%ตอบแทน%' ";
            oCommon.SEL_SQL(strSQL, ref ds2, ref strMessage);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                strSal2 = Helper.CStr(ds2.Tables[0].Rows[0]["item_debit_sum"], "0.00");
            }
            string strURL = "http://personnel.mju.ac.th/form_salary/index.php?pid=" + strIDBase64 + "&sal1=" + strSal1 + "&sal2=" + strSal2 + "";
            return strURL;
        }

        protected void imbCertificate_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Person_Manage/global_payment_certificate.aspx");
        }

        protected void imbLoan_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Person_Manage/global_payment_loan.aspx");
        }

    }
}
