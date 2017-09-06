using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using myModel;

namespace myWeb.App_Control.item_group
{
    public partial class item_group_detail_control : PageBase
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");

                imgClear.Attributes.Add("onMouseOver", "src='../../images/controls/clear2.jpg'");
                imgClear.Attributes.Add("onMouseOut", "src='../../images/controls/clear.jpg'");

                ViewState["sort"] = "item_group_detail_code";
                ViewState["direction"] = "ASC";
                #region set QueryString
                if (Request.QueryString["item_group_detail_id"] != null)
                {
                    ViewState["item_group_detail_id"] = Request.QueryString["item_group_detail_id"].ToString();
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
                    InitcboItemGroup();
                    ViewState["page"] = Request.QueryString["page"];
                    chkStatus.Checked = true;
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    //txtitem_group_detail_code.ReadOnly = true;
                    //txtitem_group_detail_code.CssClass = "textboxdis";
                    if (ViewState["PageStatus"] != null)
                    {
                        if (ViewState["PageStatus"].ToString().ToLower().Equals("save"))
                        {
                            hdditem_group_detail_id.Value = string.Empty;
                            txtitem_group_detail_code.Text = "";
                            txtitem_group_detail_name.Text = "";
                            txtitem_group_detail_name.ReadOnly = false;
                            txtitem_group_detail_name.CssClass = "textbox";
                            chkStatus.Checked = true;
                            string strScript1 =
                                "self.opener.document.forms[0].ctl00$ASPxRoundPanel1$ContentPlaceHolder2$txthpage.value=" + ViewState["page"].ToString() + ";\n" +
                                "self.opener.document.forms[0].submit();\n" +
                                "self.focus();\n";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
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
            InitcboItemGroup();
        }

        private void InitcboItemGroup()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_group_code = cboItemGroup.SelectedValue;
            string strYear = cboYear.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and item_group_year = '" + strYear + "'  and  c_active='Y' ";
            if (oItem_group.SP_ITEM_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItemGroup.Items.Clear();
                cboItemGroup.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItemGroup.Items.Add(new ListItem(dt.Rows[i]["item_group_name"].ToString(), dt.Rows[i]["item_group_code"].ToString()));
                }
                if (cboItemGroup.Items.FindByValue(strItem_group_code) != null)
                {
                    cboItemGroup.SelectedIndex = -1;
                    cboItemGroup.Items.FindByValue(strItem_group_code).Selected = true;
                }
            }
        }

        #endregion

        #region Web Form Designer generated code

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.imgSaveOnly.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveOnly_Click);
        }

        #endregion

        private bool saveData()
        {
            bool blnResult = false;
            string strMessage = string.Empty;
            string strScript = string.Empty;
            Item_group_detail item_group_detail = new Item_group_detail();
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                item_group_detail.item_group_detail_id =  string.IsNullOrEmpty(hdditem_group_detail_id.Value) ? 0 : int.Parse(hdditem_group_detail_id.Value);
                item_group_detail.item_group_detail_code = txtitem_group_detail_code.Text.Trim();
                item_group_detail.item_group_detail_name = txtitem_group_detail_name.Text.Trim();
                item_group_detail.item_group_code = cboItemGroup.SelectedValue;
                item_group_detail.c_active = chkStatus.Checked == true ? "Y" : "N";
                item_group_detail.c_created_by = Session["username"].ToString();
                item_group_detail.c_updated_by = Session["username"].ToString();
                #endregion

                string strCheckAdd = " and item_group_detail_id = '" + item_group_detail.item_group_detail_id + "' ";
                var item = oItem_group_detail.GET(strCheckAdd);
                if (item != null)
                {
                    blnResult = oItem_group_detail.SP_ITEM_GROUP_DETAIL_UPD(item_group_detail);
                }
                else
                {
                    blnResult = oItem_group_detail.SP_ITEM_GROUP_DETAIL_INS(item_group_detail);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    strScript = @"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก";
                    if (ex.Message.Contains("IX_item_group_detail_code"))
                    {
                        strScript += "ข้อมูลรหัสรายละเอียดหมวดค่าใช้จ่าย : " + txtitem_group_detail_code.Text + " ซ้ำ";
                    }
                    else if (ex.Message.Contains("IX_item_group_detail_name"))
                    {
                        strScript += "ข้อมูลรายละเอียดหมวดค่าใช้จ่าย : " + txtitem_group_detail_name.Text + " ซ้ำ";
                    }
                    MsgBox(strScript);
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oItem_group_detail.Dispose();
            }
            return blnResult;
        }

        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (saveData())
            {
                hdditem_group_detail_id.Value = string.Empty;
                txtitem_group_detail_code.Text = string.Empty;
                txtitem_group_detail_name.Text = string.Empty;
                txtitem_group_detail_name.ReadOnly = false;
                txtitem_group_detail_name.CssClass = "textbox";
                chkStatus.Checked = true;
                txtitem_group_detail_name.Focus();
                BindGridView();
                string strScript1 = "RefreshMain('" + ViewState["page"].ToString() + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
                MsgBox("บันทึกข้อมูลสมบูรณ์");
            }
        }

        private void setData()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and item_group_detail_id = '" + ViewState["item_group_detail_id"].ToString() + "' ";
                var item = oItem_group_detail.GET(strCriteria);
                if (item != null)
                {
                    hdditem_group_detail_id.Value = item.item_group_detail_id.ToString();
                    txtitem_group_detail_code.Text = item.item_group_detail_code;
                    txtitem_group_detail_name.Text = item.item_group_detail_name;
                    InitcboYear();
                    if (cboYear.Items.FindByValue(item.item_group_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(item.item_group_year).Selected = true;
                    }
                    InitcboItemGroup();
                    if (cboItemGroup.Items.FindByValue(item.item_group_code) != null)
                    {
                        cboItemGroup.SelectedIndex = -1;
                        cboItemGroup.Items.FindByValue(item.item_group_code).Selected = true;
                    }
                    chkStatus.Checked = item.c_active == "Y";

                    //if (strC_active.Equals("Y"))
                    //{
                    //    txtitem_group_detail_name.ReadOnly = false;
                    //    txtitem_group_detail_name.CssClass = "textbox";
                    //    chkStatus.Checked = true;
                    //}
                    //else
                    //{
                    //    txtitem_group_detail_name.ReadOnly = true;
                    //    txtitem_group_detail_name.CssClass = "textboxdis";
                    //    chkStatus.Checked = false;
                    //}
                    ////cboItemGroup.Enabled = false;
                    ////cboItemGroup.CssClass = "textboxdis";
                    //cboYear.Enabled = false;
                    //cboYear.CssClass = "textboxdis";

                    txtUpdatedBy.Text = item.c_updated_by;
                    txtUpdatedDate.Text = item.d_created_date.ToString();
                    BindGridView();

                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        private void BindGridView()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string stritem_group_code = string.Empty;
            stritem_group_code = cboItemGroup.SelectedValue;
            strCriteria = strCriteria + "  And  (item_group_code = '" + stritem_group_code + "') ";
            try
            {
                if (!oItem_group_detail.SP_ITEM_GROUP_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    try
                    {
                        ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch
                    {
                        GridView1.PageIndex = 0;
                        ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oItem_group_detail.Dispose();
                ds.Dispose();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                for (int iCol = 0; iCol < e.Row.Cells.Count; iCol++)
                {
                    e.Row.Cells[iCol].Attributes.Add("class", "table_h");
                    e.Row.Cells[iCol].Wrap = false;
                }
            }
            else if (e.Row.RowType.Equals(DataControlRowType.DataRow) || e.Row.RowState.Equals(DataControlRowState.Alternate))
            {
                #region Set datagrid row color
                string strEvenColor, strOddColor, strMouseOverColor;
                strEvenColor = ((DataSet)Application["xmlconfig"]).Tables["colorDataGridRow"].Rows[0]["Even"].ToString();
                strOddColor = ((DataSet)Application["xmlconfig"]).Tables["colorDataGridRow"].Rows[0]["Odd"].ToString();
                strMouseOverColor = ((DataSet)Application["xmlconfig"]).Tables["colorDataGridRow"].Rows[0]["MouseOver"].ToString();

                e.Row.Style.Add("valign", "top");
                e.Row.Style.Add("cursor", "hand");
                e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='" + strMouseOverColor + "'");

                if (e.Row.RowState.Equals(DataControlRowState.Alternate))
                {
                    e.Row.Attributes.Add("bgcolor", strOddColor);
                    e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='" + strOddColor + "'");
                }
                else
                {
                    e.Row.Attributes.Add("bgcolor", strEvenColor);
                    e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='" + strEvenColor + "'");
                }
                #endregion
                Label lblNo = (Label)e.Row.FindControl("lblNo");
                int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                lblNo.Text = nNo.ToString();
                Label lblitem_group_detail_code = (Label)e.Row.FindControl("lblitem_group_detail_code");
                Label lblitem_group_detail_name = (Label)e.Row.FindControl("lblitem_group_detail_name");
                Label lblc_active = (Label)e.Row.FindControl("lblc_active");
                string strStatus = lblc_active.Text;

                #region set ImageStatus
                ImageButton imgStatus = (ImageButton)e.Row.FindControl("imgStatus");
                if (strStatus.Equals("Y"))
                {
                    imgStatus.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["img"].ToString();
                    imgStatus.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["title"].ToString());
                    imgStatus.Attributes.Add("onclick", "return false;");
                }
                else
                {
                    imgStatus.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["imgdisable"].ToString();
                    imgStatus.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["titledisable"].ToString());
                    imgStatus.Attributes.Add("onclick", "return false;");
                }
                #endregion

                #region set Image Edit & Delete

                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                Label lblCanEdit = (Label)e.Row.FindControl("lblCanEdit");
                imgEdit.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["img"].ToString();
                imgEdit.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["title"].ToString());

                ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบรายละเอียดหมวดค่าใช้จ่าย   " + lblitem_group_detail_code.Text + " : " + lblitem_group_detail_name.Text + " ?\");");
                #endregion

            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                #region Create Item Header
                bool bSort = false;
                int i = 0;
                for (i = 0; i < GridView1.Columns.Count; i++)
                {
                    if (ViewState["sort"].Equals(GridView1.Columns[i].SortExpression))
                    {
                        bSort = true;
                        break;
                    }
                }
                if (bSort)
                {
                    foreach (System.Web.UI.Control c in e.Row.Controls[i].Controls)
                    {
                        if (c.GetType().ToString().Equals("System.Web.UI.WebControls.DataControlLinkButton"))
                        {
                            if (ViewState["direction"].Equals("ASC"))
                            {
                                ((LinkButton)c).Text += "<img border=0 src='" + ((DataSet)Application["xmlconfig"]).Tables["imgAsc"].Rows[0]["img"].ToString() + "'>";
                            }
                            else
                            {
                                ((LinkButton)c).Text += "<img border=0 src='" + ((DataSet)Application["xmlconfig"]).Tables["imgDesc"].Rows[0]["img"].ToString() + "'>";
                            }
                        }
                    }
                }
                #endregion
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGridView();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (ViewState["sort"].ToString().Equals(e.SortExpression.ToString()))
                {
                    if (ViewState["direction"].Equals("DESC"))
                        ViewState["direction"] = "ASC";
                    else
                        ViewState["direction"] = "DESC";
                }
                else
                {
                    ViewState["sort"] = e.SortExpression;
                    ViewState["direction"] = "ASC";
                }
                BindGridView();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strMessage = string.Empty;
            string strCheck = string.Empty;
            string strScript = string.Empty;
            string strUpdatedBy = Session["username"].ToString();
            HiddenField hdditem_group_detail_id = (HiddenField)GridView1.Rows[e.RowIndex].FindControl("hdditem_group_detail_id");
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            try
            {
                if (!oItem_group_detail.SP_ITEM_GROUP_DETAIL_DEL(hdditem_group_detail_id.Value, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    string strScript1 = "RefreshMain('" + ViewState["page"].ToString() + "');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oItem_group_detail.Dispose();
            }
            BindGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            HiddenField hddgrid_item_group_detail_id = (HiddenField)GridView1.Rows[e.NewEditIndex].FindControl("hdditem_group_detail_id");
            Label lblitem_group_detail_code = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblitem_group_detail_code");
            Label lblitem_group_detail_name = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblitem_group_detail_name");
            Label lblc_active = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblc_active");

            hdditem_group_detail_id.Value = hddgrid_item_group_detail_id.Value;
            txtitem_group_detail_code.Text = lblitem_group_detail_code.Text;
            txtitem_group_detail_name.Text = lblitem_group_detail_name.Text;
            string strC_active = lblc_active.Text;
            chkStatus.Checked = strC_active == "Y";
            txtitem_group_detail_name.Focus();
        }

        protected void imgClear_Click(object sender, ImageClickEventArgs e)
        {
            hdditem_group_detail_id.Value = string.Empty;
            txtitem_group_detail_code.Text = "";
            txtitem_group_detail_name.Text = "";
            txtitem_group_detail_name.ReadOnly = false;
            txtitem_group_detail_name.CssClass = "textbox";
            chkStatus.Checked = true;
            txtitem_group_detail_code.Focus();
        }

        protected void cboItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}