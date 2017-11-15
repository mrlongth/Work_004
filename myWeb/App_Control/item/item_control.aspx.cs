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

namespace myWeb.App_Control.item
{
    public partial class item_control : PageBase
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
                ViewState["sort"] = "item_code";
                ViewState["direction"] = "ASC";
                #region set QueryString
                if (Request.QueryString["item_code"] != null)
                {
                    ViewState["item_code"] = Request.QueryString["item_code"].ToString();
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
                    InitcboItem_group();
                    InitcboItemGroupDetail();
                    ViewState["page"] = Request.QueryString["page"];
                    txtitem_code.ReadOnly = true;
                    txtitem_code.CssClass = "textboxdis";
                    chkStatus.Checked = true;
                    txtitem_code.CssClass = "textboxdis";
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtitem_code.ReadOnly = true;
                    txtitem_code.CssClass = "textboxdis";
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    txtitem_code.ReadOnly = true;
                    txtitem_code.CssClass = "textboxdis";
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

        private void InitcboItem_group()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            string stritem_group_year = cboYear.SelectedValue;
            string stritem_group_type = cboItem_type.SelectedValue;
            strItem_group_code = cboItem_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and item_group_year='" + stritem_group_year + "' ";
            if (!string.IsNullOrEmpty(cboItem_type.SelectedValue))
            {
                strCriteria = "and item_group_type='" + stritem_group_type + "' ";
            }

            if (oItem_group.SP_ITEM_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group.Items.Clear();
                cboItem_group.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group.Items.Add(new ListItem(dt.Rows[i]["Item_group_name"].ToString(), dt.Rows[i]["Item_group_code"].ToString()));
                }
                if (cboItem_group.Items.FindByValue(strItem_group_code) != null)
                {
                    cboItem_group.SelectedIndex = -1;
                    cboItem_group.Items.FindByValue(strItem_group_code).Selected = true;
                }
            }
        }

        private void InitcboItemGroupDetail()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            string strItem_group_code = cboItem_group.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' And Item_group_code ='" + strItem_group_code + "' ";
            if (oItem_group_detail.SP_ITEM_GROUP_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_detail.Items.Clear();
                cboItem_group_detail.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_detail.Items.Add(new ListItem(dt.Rows[i]["Item_group_detail_name"].ToString(), dt.Rows[i]["Item_group_detail_id"].ToString()));
                }
                if (cboItem_group_detail.Items.FindByValue(strItem_group_detail_id) != null)
                {
                    cboItem_group_detail.SelectedIndex = -1;
                    cboItem_group_detail.Items.FindByValue(strItem_group_detail_id).Selected = true;
                }
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
                    txtitem_code.Text = string.Empty;
                    txtitem_name.Text = string.Empty;
                    cboItem_type.SelectedIndex = 0;
                    txtitem_name.Focus();
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
            cItem oItem = new cItem();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                var item = new Item()
                {
                    item_code = txtitem_code.Text.Trim(),
                    item_name = txtitem_name.Text,
                    item_year = cboYear.SelectedItem.Value,
                    item_group_detail_id = int.Parse(cboItem_group_detail.SelectedItem.Value),
                    c_active = chkStatus.Checked ? "Y" : "N",
                    c_created_by = Session["username"].ToString(),
                    c_updated_by = Session["username"].ToString()
                };
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    oItem.SP_ITEM_UPD(item);
                }
                else
                {
                    oItem.SP_ITEM_INS(item);
                }
                blnResult = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    strScript = @"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก";
                    //if (ex.Message.Contains("IX_item_group_detail_code"))
                    //{
                    //    strScript += "ข้อมูลรหัสรายละเอียดหมวดค่าใช้จ่าย : " + txtitem_group_detail_code.Text + " ซ้ำ";
                    //}
                    //else if (ex.Message.Contains("IX_item_group_detail_name"))
                    //{
                    //    strScript += "ข้อมูลรายละเอียดหมวดค่าใช้จ่าย : " + txtitem_group_detail_name.Text + " ซ้ำ";
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
                oItem.Dispose();
            }
            return blnResult;
        }


        private void setData()
        {
            cItem oItem = new cItem();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and item_code = '" + ViewState["item_code"].ToString() + "' ";
                var item = oItem.GET(strCriteria);
                if (item != null)
                {
                    #region set Control
                    InitcboYear();
                    if (cboYear.Items.FindByValue(item.item_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(item.item_year).Selected = true;
                    }
                    cboYear.Enabled = false;
                    txtitem_code.Text = item.item_code;
                    txtitem_name.Text = item.item_name;
                    
                    if (cboItem_type.Items.FindByValue(item.item_group_type) != null)
                    {
                        cboItem_type.SelectedIndex = -1;
                        cboItem_type.Items.FindByValue(item.item_group_type).Selected = true;
                    }

                    InitcboItem_group();
                    if (cboItem_group.Items.FindByValue(item.item_group_code) != null)
                    {
                        cboItem_group.SelectedIndex = -1;
                        cboItem_group.Items.FindByValue(item.item_group_code).Selected = true;
                    }
                    InitcboItemGroupDetail();
                    if (cboItem_group_detail.Items.FindByValue(item.item_group_detail_id.ToString()) != null)
                    {
                        cboItem_group_detail.SelectedIndex = -1;
                        cboItem_group_detail.Items.FindByValue(item.item_group_detail_id.ToString()).Selected = true;
                    }
                    chkStatus.Checked = item.c_active == "Y";
                    cboYear.CssClass = "textboxdis";

                    txtitem_code.ReadOnly = true;
                    txtitem_code.CssClass = "textboxdis";

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

        protected void cboItem_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItemGroupDetail();
        }

        protected void cboItem_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group();
        }
    }
}