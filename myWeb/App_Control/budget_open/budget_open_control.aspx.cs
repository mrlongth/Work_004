using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using myModel;
using System.Linq;
using System.Collections.Generic;
using myDLL.Common;
using Aware.WebControls;
using System.Collections;

namespace myWeb.App_Control.budget_open
{
    public partial class budget_open_control : PageBase
    {

        #region private data

        private string BudgetType
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
            }
        }

        private bool bIsGridDetailEmpty
        {
            get
            {
                if (ViewState["bIsGridDetailEmpty"] == null)
                {
                    ViewState["bIsGridDetailEmpty"] = false;
                }
                return (bool)ViewState["bIsGridDetailEmpty"];
            }
            set
            {
                ViewState["bIsGridDetailEmpty"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!ScriptManager.GetCurrent(this).IsInAsyncPostBack)
            {
                ScriptManager.RegisterOnSubmitStatement(this, this.GetType(), "BeforePostback", "BeforePostback()");
            }

            if (!IsPostBack)
            {

                ViewState["sort"] = "open_detail_id";
                ViewState["direction"] = "ASC";

                TabContainer1.ActiveTabIndex = 0;

                #region set QueryString
                if (Request.QueryString["budget_open_doc"] != null)
                {
                    ViewState["budget_open_doc"] = Request.QueryString["budget_open_doc"].ToString();
                }
                if (Request.QueryString["page"] != null)
                {
                    ViewState["page"] = Request.QueryString["page"].ToString();
                }
                if (Request.QueryString["mode"] != null)
                {
                    ViewState["mode"] = Request.QueryString["mode"].ToString();
                }
                else
                {
                    ViewState["mode"] = string.Empty;
                }


                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    ClearData();
                    txtbudget_open_date.Text = cCommon.CheckDate(DateTime.Now.ToShortDateString());
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_open_doc.ReadOnly = true;
                    txtbudget_open_doc.CssClass = "textboxdis";
                    //pnlDetail.Visible = true;
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    Utils.SetControls(pnlMain, myDLL.Common.Enumeration.Mode.VIEW);
                    btnSave.Visible = false;
                    GridView1.AllowSorting = false;
                }


                #endregion



            }
            else
            {
                if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    Utils.SetControls(pnlMain, myDLL.Common.Enumeration.Mode.VIEW);
                    btnSave.Visible = false;
                }
            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            Budget_open_head budget_open_head = new Budget_open_head();
            cBudget_open obudget_open = new cBudget_open();
            try
            {
                #region set Data
                budget_open_head.budget_open_doc = txtbudget_open_doc.Text;
                budget_open_head.degree_code = cboDegree.SelectedValue;
                budget_open_head.budget_open_date = cCommon.GetDate(txtbudget_open_date.Text);
                budget_open_head.budget_type = cboBudget_type.SelectedValue;
                budget_open_head.budget_open_year = cboYear.SelectedValue;
                budget_open_head.major_code = cboMajor.SelectedValue;
                budget_open_head.budget_plan_code = txtbudget_plan_code.Text;

                budget_open_head.ef_open_doc = txtef_open_doc.Text;
                if (!string.IsNullOrEmpty(txtopen_code.Text))
                {
                    budget_open_head.open_code = int.Parse(txtopen_code.Text);
                }
                budget_open_head.open_title = txtopen_title.Text.Trim();
                budget_open_head.open_command_desc = txtopen_command_desc.Text.Trim();
                budget_open_head.open_desc = txtopen_desc.Text.Trim();

                budget_open_head.open_remark = txtopen_remark.Text.Trim();
                budget_open_head.approve_head_status = cboApproveStatus.SelectedValue;

                budget_open_head.c_created_by = Session["username"].ToString();
                budget_open_head.c_updated_by = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    if (obudget_open.SP_BUDGET_OPEN_HEAD_UPD(budget_open_head))
                    {
                        saveDataDetail();
                        obudget_open.SP_BUDGET_OPEN_TOTAL_UPD(txtbudget_open_doc.Text);
                    }
                }
                else
                {
                    obudget_open.SP_BUDGET_OPEN_HEAD_INS(budget_open_head);
                    ViewState["budget_open_doc"] = budget_open_head.budget_open_doc;
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
                obudget_open.Dispose();
            }
            return blnResult;
        }

        private bool saveDataDetail()
        {
            bool blnResult = false;
            string strScript = string.Empty;
            cBudget_open oBudget_open = new cBudget_open();
            HiddenField hddbudget_open_detail_id = null;
            TextBox txtmaterial_detail = null;
            AwNumeric txtopen_detail_amount = null;
            Budget_open_detail budget_open_detail = null;
            try
            {
                for (var index = 0; index < GridView1.Rows.Count; index++)
                {
                    hddbudget_open_detail_id = (HiddenField)GridView1.Rows[index].FindControl("hddbudget_open_detail_id");
                    txtmaterial_detail = (TextBox)GridView1.Rows[index].FindControl("txtmaterial_detail");
                    txtopen_detail_amount = (AwNumeric)GridView1.Rows[index].FindControl("txtopen_detail_amount");
                    if (!string.IsNullOrEmpty(hddbudget_open_detail_id.Value))
                    {
                        budget_open_detail = new Budget_open_detail
                        {
                            budget_open_doc = ViewState["budget_open_doc"].ToString(),
                            budget_open_detail_id = long.Parse(hddbudget_open_detail_id.Value),
                            budget_open_detail_amount = decimal.Parse(txtopen_detail_amount.Value.ToString()),
                            material_detail = txtmaterial_detail.Text,
                            c_updated_by = Session["username"].ToString()
                        };
                        oBudget_open.SP_BUDGET_OPEN_DETAIL_UPD(budget_open_detail);
                    }
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
                oBudget_open.Dispose();
            }
            return blnResult;
        }

        private void setData()
        {
            view_Budget_open_head budget_open_head = null;
            cBudget_open obudget_open = new cBudget_open();
            try
            {
                _strCriteria = " and budget_open_doc = '" + ViewState["budget_open_doc"].ToString() + "' ";
                budget_open_head = obudget_open.GET(_strCriteria);
                if (budget_open_head != null)
                {
                    #region set Control
                    TabContainer1.Tabs[1].Visible = true;
                    //Tab 1 
                    txtUpdatedBy.Text = budget_open_head.c_updated_by;
                    txtUpdatedDate.Text = budget_open_head.d_updated_date.ToString();
                    txtbudget_open_doc.Text = budget_open_head.budget_open_doc;
                    txtbudget_open_date.Text = budget_open_head.budget_open_date.Value.ToString("dd/MM/yyyy");

                    InitcboYear();
                    if (cboYear.Items.FindByValue(budget_open_head.budget_open_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(budget_open_head.budget_open_year).Selected = true;
                    }

                    InitcboDegree();
                    if (cboDegree.Items.FindByValue(budget_open_head.degree_code) != null)
                    {
                        cboDegree.SelectedIndex = -1;
                        cboDegree.Items.FindByValue(budget_open_head.degree_code).Selected = true;
                    }

                    InitcboBudgetType();
                    if (cboBudget_type.Items.FindByValue(budget_open_head.budget_type) != null)
                    {
                        cboBudget_type.SelectedIndex = -1;
                        cboBudget_type.Items.FindByValue(budget_open_head.budget_type).Selected = true;
                    }


                    txtbudget_plan_code.Text = budget_open_head.budget_plan_code;
                    txtbudget_name.Text = budget_open_head.budget_name;
                    txtproduce_name.Text = budget_open_head.produce_name;
                    txtactivity_name.Text = budget_open_head.activity_name;
                    txtplan_name.Text = budget_open_head.plan_name;
                    txtwork_name.Text = budget_open_head.work_name;
                    txtfund_name.Text = budget_open_head.fund_name;
                    txtdirector_name.Text = budget_open_head.director_name;
                    txtunit_name.Text = budget_open_head.unit_name;
                    txtopen_remark.Text = budget_open_head.open_remark;

                    txtef_open_doc.Text = budget_open_head.ef_open_doc;
                    if (budget_open_head.open_code != null)
                    {
                        txtopen_code.Text = budget_open_head.open_code.ToString();
                    }
                    txtopen_title.Text = budget_open_head.open_title;
                    txtopen_desc.Text = budget_open_head.open_desc;
                    txtopen_command_desc.Text = budget_open_head.open_command_desc;


                    InitcboMajor();
                    if (cboMajor.Items.FindByValue(budget_open_head.major_code) != null)
                    {
                        cboMajor.SelectedIndex = -1;
                        cboMajor.Items.FindByValue(budget_open_head.major_code).Selected = true;
                    }

                    if (cboApproveStatus.Items.FindByValue(budget_open_head.approve_head_status) != null)
                    {
                        cboApproveStatus.SelectedIndex = -1;
                        cboApproveStatus.Items.FindByValue(budget_open_head.approve_head_status).Selected = true;
                    }


                    BindGridDetail();

                    #endregion
                }


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

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

        private void InitcboDegree()
        {
            cDegree oDegree = new cDegree();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strDegree_code = string.Empty;
            string strdegree_year = cboYear.SelectedValue;
            strDegree_code = cboDegree.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree.Items.Clear();
                //cboDegree.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree.Items.Add(new ListItem(dt.Rows[i]["Degree_name"].ToString(), dt.Rows[i]["Degree_code"].ToString()));
                }
                if (cboDegree.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree.SelectedIndex = -1;
                    cboDegree.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }

        private void InitcboBudgetType()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strCode = cboBudget_type.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " Select * from  general where g_type = 'budget_type' and g_code = '" + BudgetType + "'  Order by g_sort ";
            if (oCommon.SEL_SQL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboBudget_type.Items.Clear();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboBudget_type.Items.Add(new ListItem(dt.Rows[i]["g_name"].ToString(), dt.Rows[i]["g_code"].ToString()));
                }
                if (cboBudget_type.Items.FindByValue(strCode) != null)
                {
                    cboBudget_type.SelectedIndex = -1;
                    cboBudget_type.Items.FindByValue(strCode).Selected = true;
                }
            }
        }

        private void InitcboMajor()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strmajor_code = cboMajor.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  c_active='Y' ";
            if (MajorLock == "Y")
            {
                strCriteria += " and major_code = '" + PersonMajorCode + "' ";
            }

            if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMajor.Items.Clear();
                cboMajor.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboMajor.Items.Add(new ListItem(dt.Rows[i]["major_name"].ToString(), dt.Rows[i]["major_code"].ToString()));
                }
                if (cboMajor.Items.FindByValue(strmajor_code) != null)
                {
                    cboMajor.SelectedIndex = -1;
                    cboMajor.Items.FindByValue(strmajor_code).Selected = true;
                }
            }
        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "RegisterScript();createDate('" + txtbudget_open_date.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    var url = @"~/App_Control/budget_open/budget_open_control.aspx?mode=edit&budget_open_doc=" + ViewState["budget_open_doc"].ToString() + "&budget_type=" + this.BudgetType;
                    Response.Redirect(url);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_open_doc.ReadOnly = true;
                    txtbudget_open_doc.CssClass = "textboxdis";
                }
                MsgBox("บันทึกข้อมูลสมบูรณ์");
            }
        }

        protected void cboBudget_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbudget_plan_code.Text = string.Empty;
            txtbudget_name.Text = string.Empty;
            txtproduce_name.Text = string.Empty;
            txtactivity_name.Text = string.Empty;
            txtplan_name.Text = string.Empty;
            txtwork_name.Text = string.Empty;
            txtfund_name.Text = string.Empty;
            txtdirector_name.Text = string.Empty;
            txtunit_name.Text = string.Empty;
        }

        private void ClearData()
        {
            ClearDataControls(pnlMain);
            InitcboYear();
            InitcboDegree();
            InitcboBudgetType();
            InitcboMajor();
            txtbudget_open_doc.ReadOnly = true;
            txtbudget_open_doc.CssClass = "textboxdis";
            txtbudget_open_doc.CssClass = "textboxdis";
            TabContainer1.Tabs[0].Visible = true;
            TabContainer1.Tabs[1].Visible = false;
            TabContainer1.Tabs[2].Visible = false;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/App_Control/budget_open/budget_open_list.aspx?budget_type={0}", this.BudgetType));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ViewState["mode"].ToString() == "add")
            {
                ClearData();
            }
            else if (ViewState["mode"].ToString() == "edit")
            {
                setData();
            }
        }

        protected void lkbRefresh_Click(object sender, EventArgs e)
        {
            //BindGridViewDetail();
        }


        #region GridView1 Event

        private void BindGridDetail()
        {
            var lstBudgetDetail = new List<view_Budget_open_detail>();
            try
            {
                cBudget_open oBudget_open = new cBudget_open();
                _strMessage = string.Empty;
                _strCriteria = " and budget_open_doc = '" + txtbudget_open_doc.Text + "' order by item_detail_code";
                lstBudgetDetail = oBudget_open.GETDETAILS(_strCriteria);
                GridView1.DataSource = lstBudgetDetail;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                this.bIsGridDetailEmpty = false;
                if (!lstBudgetDetail.Any())
                {
                    this.bIsGridDetailEmpty = true;
                    EmptyGridFix(GridView1);
                }
                else
                {
                    GridView1.DataBind();
                }
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

                ImageButton imgAdd = (ImageButton)e.Row.FindControl("imgAdd");
                imgAdd.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["img"].ToString();
                imgAdd.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["title"].ToString());
                ViewState["TotalAmount"] = 0;

            }
            else if (e.Row.RowType.Equals(DataControlRowType.DataRow) || e.Row.RowState.Equals(DataControlRowState.Alternate))
            {
                if (!this.bIsGridDetailEmpty)
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
                    view_Budget_open_detail dv = (view_Budget_open_detail)e.Row.DataItem;
                    Label lblNo = (Label)e.Row.FindControl("lblNo");
                    int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                    lblNo.Text = nNo.ToString();

                    #region set Image Delete

                    ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                    imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                    imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                    imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบข้อมูลนี้หรือไม่ ?\");");
                    //imgDelete.Visible = IsUserDelete;
                    #endregion

                    ViewState["TotalAmount"] = Helper.CDbl(ViewState["TotalAmount"]) +
                                               Helper.CDbl(dv.budget_open_detail_amount);
                }

            }
            else if (e.Row.RowType.Equals(DataControlRowType.Footer))
            {
                AwNumeric txtopen_amount = (AwNumeric)e.Row.FindControl("txtopen_amount");
                txtopen_amount.Value = Helper.CDbl(ViewState["TotalAmount"]);
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

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strMessage = string.Empty;
            string strScript = string.Empty;
            HiddenField hddbudget_open_detail_id = (HiddenField)GridView1.Rows[e.RowIndex].FindControl("hddbudget_open_detail_id");
            cBudget_open oBudget_open = new cBudget_open();
            try
            {
                oBudget_open.SP_BUDGET_OPEN_DETAIL_DEL(hddbudget_open_detail_id.Value);
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
                oBudget_open.Dispose();
            }
            BindGridDetail();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName.ToUpper())
            //{
            //    case "ADD":
            //        StoreDetail();
            //        this.lstBudgetDetail.Add(new view_Budget_open_detail
            //        {
            //            budget_open_detail_id = ++this.OpenDetailID,
            //            budget_open_detail_amount = 0,
            //            row_status = "N"
            //        });
            //        BindGridDetail();
            //        break;
            //    default:
            //        break;
            //}
        }


        #endregion


        #region EmptyGridFix
        protected void EmptyGridFix(GridView grdView)
        {
            // normally executes after a grid load method
            if (grdView.Rows.Count == 0 &&
                grdView.DataSource != null)
            {
                var dt = new List<view_Budget_open_detail>();

                // need to clone sources otherwise it will be indirectly adding to 
                // the original source

                //if (grdView.DataSource is IList)
                //{
                //    var source = (List<view_Budget_open_detail>)grdView.DataSource;
                //    Helper.CopyTo(source, dt);
                //}
                //if (dt == null)
                //{
                //    return;
                //}

                dt.Add(new view_Budget_open_detail());
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


        protected void lbkRefresh_Click(object sender, EventArgs e)
        {
            cBudget_plan oBudget_plan = new cBudget_plan();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_plan_code = '" + txtbudget_plan_code.Text + "' ";
                var item = oBudget_plan.GET(strCriteria);
                if (item != null)
                {
                    txtbudget_plan_code.Text = item.budget_plan_code;
                    txtdirector_name.Text = item.director_name;
                    txtunit_name.Text = item.unit_name;
                    txtbudget_name.Text = item.budget_name;
                    txtproduce_name.Text = item.produce_name;
                    txtactivity_name.Text = item.activity_name;
                    txtplan_name.Text = item.plan_name;
                    txtwork_name.Text = item.work_name;
                    txtfund_name.Text = item.fund_name;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void imgClear_budget_plan_Click(object sender, ImageClickEventArgs e)
        {
            ClearBudgetPlan();
        }

        private void ClearBudgetPlan()
        {
            txtbudget_plan_code.Text = string.Empty;
            txtdirector_name.Text = string.Empty;
            txtunit_name.Text = string.Empty;
            txtbudget_name.Text = string.Empty;
            txtproduce_name.Text = string.Empty;
            txtactivity_name.Text = string.Empty;
            txtplan_name.Text = string.Empty;
            txtwork_name.Text = string.Empty;
            txtfund_name.Text = string.Empty;

            if (ViewState["mode"].ToString() == "edit")
            {
                cBudget_open obudget_open = new cBudget_open();
                try
                {
                    obudget_open.SP_BUDGET_OPEN_DETAIL_DEL_BY_DOC(txtbudget_open_doc.Text);
                    BindGridDetail();
                }
                catch(Exception ex)
                {
                    lblError.Text = ex.Message;
                    throw ex;
                }
                finally
                {
                    obudget_open.Dispose();
                }
            }
        }

        protected void cboDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }

        protected void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            setEFormData();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            BindGridDetail();
        }

        private void setEFormData()
        {
            cefOpen opjEfloan = new cefOpen();
            DataTable dt = new DataTable();
            string strMessage = string.Empty,
                strCriteria = string.Empty;
            try
            {
                strCriteria = " and open_doc = '" + txtef_open_doc.Text + "' ";
                dt = opjEfloan.SP_OPEN_HEAD_SEL(strCriteria);
                if (dt.Rows.Count > 0)
                {
                    ViewState["open_head_id"] = dt.Rows[0]["open_head_id"].ToString();
                    txtef_open_doc.Text = dt.Rows[0]["open_doc"].ToString();
                    txtopen_code.Text = Helper.CInt(dt.Rows[0]["open_code"]) > 0 ? dt.Rows[0]["open_code"].ToString() : "";
                    txtopen_title.Text = dt.Rows[0]["open_title"].ToString();
                    txtopen_desc.Text = dt.Rows[0]["open_desc"].ToString();
                    txtopen_command_desc.Text = dt.Rows[0]["open_command_desc"].ToString();
                    txtopen_remark.Text = dt.Rows[0]["open_remark"].ToString();
                    //txtopen_person.Text = dt.Rows[0]["person_open"].ToString();
                    //txtopen_person_name.Text = Helper.CStr(dt.Rows[0]["person_thai_name"]) + " " + Helper.CStr(dt.Rows[0]["person_thai_surname"]);

                    BindGridDetail();

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void imgClear_open_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["open_head_id"] = 0;
            txtopen_code.Text = string.Empty;
            txtopen_title.Text = string.Empty;
            txtopen_desc.Text = string.Empty;
            txtopen_command_desc.Text = string.Empty;
            txtopen_remark.Text = string.Empty;
        }

        protected void imgClear_ef_open_doc_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["open_head_id"] = 0;
            txtef_open_doc.Text = string.Empty;
            txtopen_code.Text = string.Empty;
            txtopen_title.Text = string.Empty;
            txtopen_desc.Text = string.Empty;
            txtopen_command_desc.Text = string.Empty;
            txtopen_remark.Text = string.Empty;
        }
    }
}
