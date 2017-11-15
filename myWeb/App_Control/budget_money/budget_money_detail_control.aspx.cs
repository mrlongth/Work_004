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
using Aware.WebControls;

namespace myWeb.App_Control.item
{
    public partial class budget_money_detail_control : PageBase
    {

        #region private data
        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");
                ViewState["sort"] = "lot_code";
                ViewState["direction"] = "ASC";
                #region set QueryString
                if (Request.QueryString["budget_money_detail_id"] != null)
                {
                    ViewState["budget_money_detail_id"] = Request.QueryString["budget_money_detail_id"].ToString();
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
                if (Request.QueryString["budget_money_doc"] != null)
                {
                    ViewState["budget_money_doc"] = Request.QueryString["budget_money_doc"].ToString();
                }


                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    InitcboLot();
                    InitcboItem_group();
                    InitcboItemGroupDetail();
                    GridViewMajor.Visible = false;
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    BindGridView();
                    Utils.SetControls(pnlControl, myDLL.Common.Enumeration.Mode.VIEW);
                    imgSaveOnly.Visible = true;
                    txtbudget_money_detail_comment.ReadOnly = false;
                    txtbudget_money_detail_comment.CssClass = "textbox";

                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    BindGridView();
                }

                #endregion
            }

            if (ViewState["mode"].ToString().ToLower().Equals("view"))
            {
                Utils.SetControls(pnlContent, myDLL.Common.Enumeration.Mode.VIEW);
            }

        }

        #region private function

        public string BudgetType
        {
            get
            {
                if (ViewState["BudgetType"] == null)
                {
                    ViewState["BudgetType"] = Helper.CStr(Request.QueryString["budget_type"]);
                }
                return ViewState["BudgetType"].ToString();
            }
            set
            {
                ViewState["BudgetType"] = value;
                hddbudget_type.Value = value;
            }
        }

        private void InitcboItem_group()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            var strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
            strItem_group_code = cboItem_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and item_group_year='" + strYear + "' and lot_code = '" + cboLot.SelectedValue + "' ";
            if (!string.IsNullOrEmpty(cboLot.SelectedValue))
            {
                strCriteria += " and lot_code = '" + cboLot.SelectedValue + "' ";
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
            var strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
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


        private void InitcboLot()
        {
            cLot oLot = new cLot();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
            string strLot = cboLot.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and lot_year = '" + strYear + "'  and  c_active='Y' and budget_type='" + this.BudgetType + "' ";
            if (oLot.SP_SEL_LOT(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboLot.Items.Clear();
                cboLot.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboLot.Items.Add(new ListItem(dt.Rows[i]["lot_name"].ToString(), dt.Rows[i]["lot_code"].ToString()));
                }
                if (cboLot.Items.FindByValue(strLot) != null)
                {
                    cboLot.SelectedIndex = -1;
                    cboLot.Items.FindByValue(strLot).Selected = true;
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

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "RegisterScript();", true);
            }
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

        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string strScript = string.Empty;
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    txtitem_detail_code.Text = string.Empty;
                    txtitem_detail_name.Text = string.Empty;
                    txtitem_detail_name.Focus();
                    strScript += "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$lkbRefresh','');";
                    strScript += "ResizePopUp('1000px','700px','98%','แก้ไขข้อมูลรายละเอียดงบประมาณประจำปี','budget_money_detail_control.aspx?mode=edit&budget_money_detail_id=" + ViewState["budget_money_detail_id"].ToString() + "&budget_type=" + this.BudgetType + "','1');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript, true);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    strScript += "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript, true);
                }
                MsgBox("บันทึกข้อมูลสมบูรณ์");
                setData();
            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            string strScript = string.Empty;
            cBudget_money oBudget_money = new cBudget_money();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                var budget_money_detail = new Budget_money_detail()
                {
                    budget_money_doc = ViewState["budget_money_doc"].ToString(),
                    item_detail_id = int.Parse(hdditem_detail_id.Value),
                    budget_money_detail_plan = decimal.Parse(txtbudget_money_detail_plan.Value.ToString()),
                    budget_money_detail_contribute = decimal.Parse(txtbudget_money_detail_contribute.Value.ToString()),
                    budget_money_detail_use = decimal.Parse(txtbudget_money_detail_contribute.Value.ToString()),
                    budget_money_detail_comment = txtbudget_money_detail_comment.Text.Trim(),
                    c_created_by = Session["username"].ToString(),
                    c_updated_by = Session["username"].ToString()
                };
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    if (oBudget_money.SP_BUDGET_MONEY_DETAIL_UPD(budget_money_detail))
                    {
                        saveDataDetail();
                    };
                }
                else
                {
                    oBudget_money.SP_BUDGET_MONEY_DETAIL_INS(budget_money_detail);
                    ViewState["budget_money_detail_id"] = budget_money_detail.budget_money_detail_id;
                }
                blnResult = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    MsgBox("ข้อมูลซ้ำโปรดตรวจสอบ");
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oBudget_money.Dispose();
            }
            return blnResult;
        }

        private bool saveDataDetail()
        {
            bool blnResult = false;
            string strScript = string.Empty;
            cBudget_money oBudget_money = new cBudget_money();
            HiddenField hddbudget_money_major_id = null;
            AwNumeric txtbudget_money_major_plan = null;
            Budget_money_major budget_money_major = null;

            try
            {
                #region set Data
                //GridViewRow item = (GridViewRow)GridView1.Controls[0].Controls[0];
                for (var index = 0; index < GridViewMajor.Rows.Count; index++)
                {
                    hddbudget_money_major_id = (HiddenField)GridViewMajor.Rows[index].FindControl("hddbudget_money_major_id");
                    txtbudget_money_major_plan = (AwNumeric)GridViewMajor.Rows[index].FindControl("txtbudget_money_major_plan");
                    budget_money_major = new Budget_money_major
                    {
                        budget_money_major_id = long.Parse(hddbudget_money_major_id.Value),
                        budget_money_major_plan = decimal.Parse(txtbudget_money_major_plan.Value.ToString()),
                        c_updated_by = Session["username"].ToString()
                    };
                    oBudget_money.SP_BUDGET_MONEY_MAJOR_UPD(budget_money_major);
                }
                blnResult = true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    MsgBox("ข้อมูลซ้ำโปรดตรวจสอบ");
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oBudget_money.Dispose();
            }
            return blnResult;
        }

        private void setData()
        {
            cBudget_money oBudget_money = new cBudget_money();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_money_detail_id = '" + ViewState["budget_money_detail_id"].ToString() + "' ";
                var item = oBudget_money.GETDETAIL(strCriteria);
                if (item != null)
                {
                    #region set Control

                    InitcboLot();
                    if (cboLot.Items.FindByValue(item.lot_code) != null)
                    {
                        cboLot.SelectedIndex = -1;
                        cboLot.Items.FindByValue(item.lot_code).Selected = true;
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
                    ViewState["budget_money_doc"] = item.budget_money_doc;
                    hdditem_detail_id.Value = item.item_detail_id.ToString();
                    txtitem_detail_code.Text = item.item_detail_code;
                    txtitem_detail_name.Text = item.item_detail_name;
                    txtitem_name.Text = item.item_name;
                    txtbudget_money_detail_comment.Text = item.budget_money_detail_comment;
                    txtbudget_money_detail_plan.Value = item.budget_money_detail_plan;
                    txtbudget_money_detail_contribute.Value = item.budget_money_detail_contribute;
                    txtbudget_money_detail_use.Value = item.budget_money_detail_use;
                    txtbudget_money_detail_remain.Value = item.budget_money_detail_remain;
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
        #endregion


        #region EmptyGridFix
        protected void EmptyGridFix(GridView grdView)
        {
            // normally executes after a grid load method
            if (grdView.Rows.Count == 0 &&
                grdView.DataSource != null)
            {
                DataTable dt = null;

                // need to clone sources otherwise it will be indirectly adding to 
                // the original source

                if (grdView.DataSource is DataSet)
                {
                    dt = ((DataSet)grdView.DataSource).Tables[0].Clone();
                }
                else if (grdView.DataSource is DataTable)
                {
                    dt = ((DataTable)grdView.DataSource).Clone();
                }

                if (dt == null)
                {
                    return;
                }

                dt.Rows.Add(dt.NewRow()); // add empty row
                grdView.DataSource = dt;
                grdView.DataBind();

                // hide row
                grdView.Rows[0].Visible = false;
                grdView.Rows[0].Controls.Clear();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1 &&
                grdView.DataSource == null)
            {
                bool bIsGridEmpty = true;

                // check first row that all cells empty
                for (int i = 0; i < grdView.Rows[0].Cells.Count; i++)
                {
                    if (grdView.Rows[0].Cells[i].Text != string.Empty)
                    {
                        bIsGridEmpty = false;
                    }
                }
                // hide row
                if (bIsGridEmpty)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }
        #endregion



        protected void GridViewMajor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {

                for (int iCol = 0; iCol < e.Row.Cells.Count; iCol++)
                {
                    e.Row.Cells[iCol].Attributes.Add("class", "table_h");
                    e.Row.Cells[iCol].Wrap = false;
                }

                ImageButton imgAdd = (ImageButton)e.Row.FindControl("imgAdd");
                imgAdd.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["img"].ToString();
                imgAdd.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["title"].ToString());
                imgAdd.Attributes.Add("onclick", "OpenPopUp('600px','400px','95%','เลือกหลักสูตร','budget_money_major_select.aspx?budget_money_detail_id=" + ViewState["budget_money_detail_id"].ToString() + "&budget_type=" + this.BudgetType + "&show=2','2');return false;");
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
                int nNo = (GridViewMajor.PageSize * GridViewMajor.PageIndex) + e.Row.RowIndex + 1;
                lblNo.Text = nNo.ToString();

                #region set Image Edit & Delete

                ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบข้อมูลนี้หรือไม่?\");");
                #endregion

                #region check user can edit/delete
                //imgDelete.Visible = base.IsUserDelete;
                #endregion

            }
        }

        protected void GridViewMajor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                #region Create Item Header
                bool bSort = false;
                int i = 0;
                for (i = 0; i < GridViewMajor.Columns.Count; i++)
                {
                    if (ViewState["sort"].Equals(GridViewMajor.Columns[i].SortExpression))
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

        protected void GridViewMajor_Sorting(object sender, GridViewSortEventArgs e)
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

        protected void GridViewMajor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strScript = string.Empty;
             HiddenField hddbudget_money_major_id = (HiddenField)GridViewMajor.Rows[e.RowIndex].FindControl("hddbudget_money_major_id");
            cBudget_money oBudget_money = new cBudget_money();
            try
            {
                oBudget_money.SP_BUDGET_MONEY_MAJOR_DEL(hddbudget_money_major_id.Value);
                setData();
                strScript = "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript, true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE constraint"))
                {
                    MsgBox("ไม่สามารถลบข้อมูลได้เนื่องจากมีการนำไปใช้ในระบบแล้ว");
                }
                else
                {
                    lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oBudget_money.Dispose();
            }
            BindGridView();
        }


        private void BindGridView()
        {
            cBudget_money oBudget_money = new cBudget_money();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            strCriteria = " And  (budget_money_detail_id = '" + ViewState["budget_money_detail_id"].ToString() + "') ";
            try
            {
                if (!oBudget_money.SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    try
                    {
                        GridViewMajor.PageIndex = 0;
                        ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                        GridViewMajor.DataSource = ds.Tables[0];
                        GridViewMajor.DataBind();
                    }
                    catch
                    {
                        GridViewMajor.PageIndex = 0;
                        ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                        GridViewMajor.DataSource = ds.Tables[0];
                        GridViewMajor.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                if (GridViewMajor.Rows.Count == 0)
                {
                    EmptyGridFix(GridViewMajor);
                }
                oBudget_money.Dispose();
                ds.Dispose();
            }
        }

        protected void cboLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group();
        }

        protected void cboItem_group_SelectedIndexChanged1(object sender, EventArgs e)
        {
            InitcboItemGroupDetail();
        }

        protected void cboItem_group_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdditem_detail_id.Value = string.Empty;
            txtitem_detail_code.Text = string.Empty;
            txtitem_detail_name.Text = string.Empty;
            txtitem_name.Text = string.Empty;
        }

        protected void lbkRefresh_Click(object sender, EventArgs e)
        {
            cItem_detail oItem_detail = new cItem_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and item_detail_id = '" + hdditem_detail_id.Value.ToString() + "' ";
                var item = oItem_detail.GET(strCriteria);
                if (item != null)
                {
                    hdditem_detail_id.Value = item.item_detail_id.ToString();
                    txtitem_detail_code.Text = item.item_detail_code;
                    txtitem_detail_name.Text = item.item_detail_name;

                    InitcboLot();
                    if (cboLot.Items.FindByValue(item.lot_code) != null)
                    {
                        cboLot.SelectedIndex = -1;
                        cboLot.Items.FindByValue(item.lot_code).Selected = true;
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
                    txtitem_detail_code.Text = item.item_detail_code;
                    txtitem_detail_name.Text = item.item_detail_name;
                    txtitem_name.Text = item.item_name;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

    }
}