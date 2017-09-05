using System;
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
using myDLL;
using myModel;

namespace myWeb.App_Control.item_group
{
    public partial class item_group_control : PageBase
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {

            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");

                InitcboYear();
                InitcboLot();

                #region set QueryString
                if (Request.QueryString["item_group_code"] != null)
                {
                    ViewState["item_group_code"] = Request.QueryString["item_group_code"].ToString();
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
                    ViewState["page"] = Request.QueryString["page"];
                    Session["menupopup_name"] = "เพิ่มข้อมูลหมวดรายได้/ค่าใช้จ่าย ";
                    txtitem_group_code.ReadOnly = true;
                    txtitem_group_code.CssClass = "textboxdis";
                    chkStatus.Checked = true;
                }

                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtitem_group_code.ReadOnly = true;
                    txtitem_group_code.CssClass = "textboxdis";
                    Session["menupopup_name"] = "แก้ไขข้อมูลหมวดรายได้/ค่าใช้จ่าย ";
                    if (ViewState["PageStatus"] != null)
                    {
                        if (ViewState["PageStatus"].ToString().ToLower().Equals("save"))
                        {
                            string strScript1 =
                                "self.opener.document.forms[0].ctl00$ASPxRoundPanel1$ContentPlaceHolder2$txthpage.value=" + ViewState["page"].ToString() + ";\n" +
                                "self.opener.document.forms[0].submit();\n" +
                                "self.focus();\n";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "frMainPage", strScript1, true);
                        }
                    }
                }

                #endregion
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

        private void InitcboLot()
        {
            cLot oLot = new cLot();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strLot_code = cboLot_code.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and lot_year = '" + strYear + "'  and  c_active='Y' ";
            if (oLot.SP_SEL_LOT(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboLot_code.Items.Clear();
                cboLot_code.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboLot_code.Items.Add(new ListItem(dt.Rows[i]["lot_name"].ToString(), dt.Rows[i]["lot_code"].ToString()));
                }
                if (cboLot_code.Items.FindByValue(strLot_code) != null)
                {
                    cboLot_code.SelectedIndex = -1;
                    cboLot_code.Items.FindByValue(strLot_code).Selected = true;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgSaveOnly.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveOnly_Click);
        }
        #endregion

        private bool saveData()
        {
            bool blnResult = false;
            bool blnDup = false;
            
            string strScript = string.Empty;
            cItem_group oItem_group = new cItem_group();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                var item_group = new Item_group()
                {
                    item_group_code = txtitem_group_code.Text.Trim(),
                    item_group_name = txtitem_group_name.Text,
                    item_group_year = cboYear.SelectedItem.Value,
                    lot_code = cboLot_code.SelectedItem.Value,
                    c_active = chkStatus.Checked ? "Y" : "N",
                    c_created_by = Session["username"].ToString(),
                    c_updated_by = Session["username"].ToString()
                };
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    #region edit
                    if (!blnDup)
                    {
                        if (oItem_group.SP_ITEM_GROUP_UPD(item_group, ref _strMessage))
                        {
                            blnResult = true;
                        }
                        else
                        {
                            lblError.Text = _strMessage.ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "frMainPage", strScript, true);
                    }
                    #endregion
                }
                else
                {
                    #region check dup
                    string strCheckDup = string.Empty;
                    strCheckDup = " and item_group_name = '" + item_group.item_group_name + "' and item_group_year = '" + item_group.item_group_year + "' ";
                    if (!oItem_group.SP_ITEM_GROUP_SEL(strCheckDup, ref ds, ref _strMessage))
                    {
                        lblError.Text = _strMessage.ToString();
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strScript =
                                "alert(\"ไม่สามารถเพิ่มข้อมูล เนื่องจากข้อมูล " + item_group.item_group_name + " ปี " + item_group.item_group_year + "  ซ้ำ\");\n";
                            blnDup = true;
                        }
                    }


                    #endregion
                    #region insert
                    if (!blnDup)
                    {
                        if (oItem_group.SP_ITEM_GROUP_INS(item_group, ref _strMessage))
                        {
                            string strGetcode = " and item_group_name = '" + item_group.item_group_name.Trim() + "' and item_group_year = '" + item_group.item_group_year + "' ";
                            if (!oItem_group.SP_ITEM_GROUP_SEL(strGetcode, ref ds, ref _strMessage))
                            {
                                lblError.Text = _strMessage;
                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                item_group.item_group_code = ds.Tables[0].Rows[0]["item_group_code"].ToString();
                            }
                            ViewState["item_group_code"] = item_group.item_group_code;
                            blnResult = true;
                        }
                        else
                        {
                            lblError.Text = _strMessage.ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "frMainPage", strScript, true);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oItem_group.Dispose();
            }
            return blnResult;
        }

        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    txtitem_group_code.Text = string.Empty;
                    txtitem_group_name.Text = string.Empty;
                    txtitem_group_name.Focus();
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

        private void setData()
        {
            cItem_group oItem_group = new cItem_group();

            try
            {
                _strCriteria = " and item_group_code = '" + ViewState["item_group_code"].ToString() + "' ";
                var item_group = oItem_group.GET(_strCriteria);
                if (item_group != null)
                {

                    #region set Control
                    txtitem_group_code.Text = item_group.item_group_code;
                    txtitem_group_name.Text = item_group.item_group_name;
                    InitcboYear();
                    if (cboYear.Items.FindByValue(item_group.item_group_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(item_group.item_group_year).Selected = true;
                    }
                    InitcboLot();
                    if (cboLot_code.Items.FindByValue(item_group.lot_code) != null)
                    {
                        cboLot_code.SelectedIndex = -1;
                        cboLot_code.Items.FindByValue(item_group.lot_code).Selected = true;
                    }

                    if (item_group.c_active.Equals("Y"))
                    {
                        txtitem_group_name.ReadOnly = false;
                        txtitem_group_name.CssClass = "textbox";
                        chkStatus.Checked = true;
                    }
                    else
                    {
                        txtitem_group_name.ReadOnly = true;
                        txtitem_group_name.CssClass = "textboxdis";
                        chkStatus.Checked = false;
                    }
                    cboYear.Enabled = false;
                    cboYear.CssClass = "textboxdis";
                    txtUpdatedBy.Text = item_group.c_updated_by;
                    txtUpdatedDate.Text = item_group.d_updated_date.ToString();
                    #endregion

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboLot();
        }




    }
}