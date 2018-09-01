using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using myDLL;
using myModel;

namespace myWeb.App_Control.recv_item
{
    public partial class recv_item_control : PageBase
    {

        #region private data
        private string strPrefixCtr_main = "ctl00$ContentPlaceHolder1$";
        // private string strPrefixCtr = "ctl00$ASPxRoundPanel1$ASPxRoundPanel2$ContentPlaceHolder1$";
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");
                Session["menupopup_name"] = "";
                ViewState["sort"] = "recv_item_code";
                ViewState["direction"] = "ASC";
                #region set QueryString
                if (Request.QueryString["recv_item_code"] != null)
                {
                    ViewState["recv_item_code"] = Request.QueryString["recv_item_code"].ToString();
                }
                if (Request.QueryString["page"] != null)
                {
                    ViewState["page"] = Request.QueryString["page"].ToString();
                }
                if (Request.QueryString["mode"] != null)
                {
                    ViewState["mode"] = Request.QueryString["mode"].ToString();
                }
                if (Request.QueryString["PageStatus"] != null)
                {
                    ViewState["PageStatus"] = Request.QueryString["PageStatus"].ToString();
                }


                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    InitcboYear();
                    ViewState["page"] = Request.QueryString["page"];
                    txtrecv_item_code.ReadOnly = true;
                    txtrecv_item_code.CssClass = "textboxdis";
                    chkStatus.Checked = true;
                    txtrecv_item_code.CssClass = "textboxdis";
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtrecv_item_code.ReadOnly = true;
                    txtrecv_item_code.CssClass = "textboxdis";
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    txtrecv_item_code.ReadOnly = true;
                    txtrecv_item_code.CssClass = "textboxdis";
                }

                #endregion
            }

            if (ViewState["mode"].ToString().ToLower().Equals("view"))
            {
                Utils.SetControls(pnlContent, myDLL.Common.Enumeration.Mode.VIEW);
            }

        }

        #region private function

        private void InitcboYear()
        {
            string strYear = string.Empty;
            strYear = cboYear.SelectedValue;
            if (strYear.Equals(""))
            {
                strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
            }
            DataTable odt;
            int i;
            cboYear.Items.Clear();
            odt = ((DataSet)Application["xmlconfig"]).Tables["cboYear"];
            for (i = 0; i <= odt.Rows.Count - 1; i++)
            {
                cboYear.Items.Add(new ListItem(odt.Rows[i]["Text"].ToString(), odt.Rows[i]["Value"].ToString()));
            }
            if (cboYear.Items.FindByValue(strYear) != null)
            {
                cboYear.SelectedIndex = -1;
                cboYear.Items.FindByValue(strYear).Selected = true;
            }
        }

        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.imgSaveOnly.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveOnly_Click);
        }
        #endregion

        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    txtrecv_item_code.Text = string.Empty;
                    txtrecv_item_name.Text = string.Empty;
                    cboRecv_item_type.SelectedIndex = 0;
                    txtrecv_item_name.Focus();
                    string strScript1 = "RefreshMain('" + ViewState["page"].ToString() + "');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    string strScript1 = "ClosePopUpListPost('" + ViewState["page"].ToString() + "','1');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
                }
                MsgBox("บันทึกข้อมูลสมบูรณ์");
            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            string strScript = string.Empty;
            cRecv_item oRecv_Item = new cRecv_item();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                var recv_item = new Recv_item()
                {
                    recv_item_code = txtrecv_item_code.Text.Trim(),
                    recv_item_name = txtrecv_item_name.Text,
                    recv_item_remark = txtrecv_item_remark.Text.Trim(),
                    recv_item_year = cboYear.SelectedItem.Value,
                    recv_item_rate= decimal.Parse(txtrecv_item_rate.Value.ToString()) ,
                    recv_item_is_director = chkRecv_item_is_director.Checked,
                    recv_item_type = cboRecv_item_type.SelectedValue,
                    c_active = chkStatus.Checked ? "Y" : "N",
                    c_created_by = Session["username"].ToString(),
                    c_updated_by = Session["username"].ToString()
                };
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    oRecv_Item.SP_RECV_ITEM_UPD(recv_item);
                }
                else
                {
                    oRecv_Item.SP_RECV_ITEM_INS(recv_item);
                }
                blnResult = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    strScript = @"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก";
                    //if (ex.Message.Contains("IX_recv_item_group_detail_code"))
                    //{
                    //    strScript += "ข้อมูลรหัสรายละเอียดหมวดค่าใช้จ่าย : " + txtrecv_item_group_detail_code.Text + " ซ้ำ";
                    //}
                    //else if (ex.Message.Contains("IX_recv_item_group_detail_name"))
                    //{
                    //    strScript += "ข้อมูลรายละเอียดหมวดค่าใช้จ่าย : " + txtrecv_item_group_detail_name.Text + " ซ้ำ";
                    //}
                    MsgBox(strScript);
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oRecv_Item.Dispose();
            }
            return blnResult;
        }


        private void setData()
        {
            cRecv_item oRecv_item = new cRecv_item();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and recv_item_code = '" + ViewState["recv_item_code"].ToString() + "' ";
                var item = oRecv_item.GET(strCriteria);
                if (item != null)
                {
                    #region set Control
                    InitcboYear();
                    if (cboYear.Items.FindByValue(item.recv_item_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(item.recv_item_year).Selected = true;
                    }
                    cboYear.Enabled = false;
                    txtrecv_item_code.Text = item.recv_item_code;
                    txtrecv_item_name.Text = item.recv_item_name;
                    txtrecv_item_remark.Text = item.recv_item_remark;
                    if (cboRecv_item_type.Items.FindByValue(item.recv_item_type) != null)
                    {
                        cboRecv_item_type.SelectedIndex = -1;
                        cboRecv_item_type.Items.FindByValue(item.recv_item_type).Selected = true;
                    }

                    chkRecv_item_is_director.Checked = item.recv_item_is_director.Value;
                    chkStatus.Checked = item.c_active == "Y";
                    cboYear.CssClass = "textboxdis";

                    txtrecv_item_code.ReadOnly = true;
                    txtrecv_item_code.CssClass = "textboxdis";

                    DisableControl(item.recv_item_type);

                    txtUpdatedBy.Text = item.c_updated_by;
                    txtUpdatedDate.Text = item.d_updated_date.ToString();
                    #endregion

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void cboRecv_item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableControl(cboRecv_item_type.SelectedValue);           
        }

        protected void DisableControl(string recv_item_type)
        {
            if (recv_item_type == "D")
            {
                txtrecv_item_rate.Value = 0;
                txtrecv_item_rate.Enabled = false;
                txtrecv_item_rate.CssClassDefault = "numberdis";
                chkRecv_item_is_director.Checked = false;
                chkRecv_item_is_director.Enabled = false;

            }
            else
            {
                txtrecv_item_rate.CssClassDefault = "numberbox";
                txtrecv_item_rate.Enabled = true;
                chkRecv_item_is_director.Enabled = true;
            }
        }



    }
}