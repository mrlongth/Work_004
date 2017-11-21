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

namespace myWeb.App_Control.budget_transfer
{
    public partial class budget_transfer_control : PageBase
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
            if (!IsPostBack)
            {

                ViewState["sort"] = "open_detail_id";
                ViewState["direction"] = "ASC";

                TabContainer1.ActiveTabIndex = 0;

                #region set QueryString
                if (Request.QueryString["budget_transfer_doc"] != null)
                {
                    ViewState["budget_transfer_doc"] = Request.QueryString["budget_transfer_doc"].ToString();
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
                    txtbudget_transfer_date.Text = cCommon.CheckDate(DateTime.Now.ToShortDateString());
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_transfer_doc.ReadOnly = true;
                    txtbudget_transfer_doc.CssClass = "textboxdis";
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
            Budget_transfer_head budget_transfer_head = new Budget_transfer_head();
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            try
            {
                #region set Data
                budget_transfer_head.budget_transfer_doc = txtbudget_transfer_doc.Text;
                budget_transfer_head.budget_doc_no = txtbudget_doc_no.Text;
                budget_transfer_head.budget_transfer_year = cboYear.SelectedValue;
                budget_transfer_head.budget_transfer_date = cCommon.GetDate(txtbudget_transfer_date.Text);
                budget_transfer_head.budget_type = cboBudget_type.SelectedValue;
                budget_transfer_head.degree_code_from = cboDegree_from.SelectedValue;
                budget_transfer_head.major_code_from = cboMajor_from.SelectedValue;
                budget_transfer_head.budget_plan_code_from = txtbudget_plan_code_from.Text;
                budget_transfer_head.degree_code_to = cboDegree_to.SelectedValue;
                budget_transfer_head.major_code_to = cboMajor_to.SelectedValue;
                budget_transfer_head.budget_plan_code_to = txtbudget_plan_code_to.Text;
                budget_transfer_head.budget_transfer_remark = txtbudget_transfer_remark.Text;
                budget_transfer_head.c_created_by = Session["username"].ToString();
                budget_transfer_head.c_updated_by = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    oBudget_transfer.SP_BUDGET_TRANSFER_HEAD_UPD(budget_transfer_head);
                }
                else
                {
                    oBudget_transfer.SP_BUDGET_TRANSFER_HEAD_INS(budget_transfer_head);
                    ViewState["budget_transfer_doc"] = budget_transfer_head.budget_transfer_doc;
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
                oBudget_transfer.Dispose();
            }
            return blnResult;
        }

        private void setData()
        {
            view_Budget_transfer_head budget_transfer_head = null;
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            try
            {
                _strCriteria = " and budget_transfer_doc = '" + ViewState["budget_transfer_doc"].ToString() + "' ";
                budget_transfer_head = oBudget_transfer.GET(_strCriteria);
                if (budget_transfer_head != null)
                {
                    #region set Control
                    TabContainer1.Tabs[1].Visible = true;
                    //Tab 1 
                    txtUpdatedBy.Text = budget_transfer_head.c_updated_by;
                    txtUpdatedDate.Text = budget_transfer_head.d_updated_date.ToString();
                    txtbudget_transfer_doc.Text = budget_transfer_head.budget_transfer_doc;
                    txtbudget_transfer_date.Text = budget_transfer_head.budget_transfer_date.Value.ToString("dd/MM/yyyy");
                    txtbudget_doc_no.Text = budget_transfer_head.budget_doc_no;

                    InitcboBudgetType();
                    if (cboBudget_type.Items.FindByValue(budget_transfer_head.budget_type) != null)
                    {
                        cboBudget_type.SelectedIndex = -1;
                        cboBudget_type.Items.FindByValue(budget_transfer_head.budget_type).Selected = true;
                    }

                    InitcboYear();
                    if (cboYear.Items.FindByValue(budget_transfer_head.budget_transfer_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(budget_transfer_head.budget_transfer_year).Selected = true;
                    }

                    InitcboDegree_from();
                    if (cboDegree_from.Items.FindByValue(budget_transfer_head.degree_code_from) != null)
                    {
                        cboDegree_from.SelectedIndex = -1;
                        cboDegree_from.Items.FindByValue(budget_transfer_head.degree_code_from).Selected = true;
                    }

                    InitcboMajor_from();
                    if (cboMajor_from.Items.FindByValue(budget_transfer_head.major_code_from) != null)
                    {
                        cboMajor_from.SelectedIndex = -1;
                        cboMajor_from.Items.FindByValue(budget_transfer_head.major_code_from).Selected = true;
                    }

                    txtbudget_plan_code_from.Text = budget_transfer_head.budget_plan_code_from;
                    txtbudget_name_from.Text = budget_transfer_head.budget_name_from;
                    txtproduce_name_from.Text = budget_transfer_head.produce_name_from;
                    txtactivity_name_from.Text = budget_transfer_head.activity_name_from;
                    txtplan_name_from.Text = budget_transfer_head.plan_name_from;
                    txtwork_name_from.Text = budget_transfer_head.work_name_from;
                    txtfund_name_from.Text = budget_transfer_head.fund_name_from;
                    txtunit_name_from.Text = budget_transfer_head.unit_name_from;

                    InitcboDegree_to();
                    if (cboDegree_to.Items.FindByValue(budget_transfer_head.degree_code_to) != null)
                    {
                        cboDegree_to.SelectedIndex = -1;
                        cboDegree_to.Items.FindByValue(budget_transfer_head.degree_code_to).Selected = true;
                    }

                    InitcboMajor_to();
                    if (cboMajor_to.Items.FindByValue(budget_transfer_head.major_code_to) != null)
                    {
                        cboMajor_to.SelectedIndex = -1;
                        cboMajor_to.Items.FindByValue(budget_transfer_head.major_code_to).Selected = true;
                    }

                    txtbudget_plan_code_to.Text = budget_transfer_head.budget_plan_code_to;
                    txtbudget_name_to.Text = budget_transfer_head.budget_name_to;
                    txtproduce_name_to.Text = budget_transfer_head.produce_name_to;
                    txtactivity_name_to.Text = budget_transfer_head.activity_name_to;
                    txtplan_name_to.Text = budget_transfer_head.plan_name_to;
                    txtwork_name_to.Text = budget_transfer_head.work_name_to;
                    txtfund_name_to.Text = budget_transfer_head.fund_name_to;
                    txtunit_name_to.Text = budget_transfer_head.unit_name_to;

                    txtbudget_transfer_remark.Text = budget_transfer_head.budget_transfer_remark;
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

        private void InitcboDegree_from()
        {
            cDegree oDegree = new cDegree();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strDegree_code = string.Empty;
            string strdegree_year = cboYear.SelectedValue;
            strDegree_code = cboDegree_from.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree_from.Items.Clear();
                //cboDegree.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree_from.Items.Add(new ListItem(dt.Rows[i]["Degree_name"].ToString(), dt.Rows[i]["Degree_code"].ToString()));
                }
                if (cboDegree_from.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree_from.SelectedIndex = -1;
                    cboDegree_from.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }


        private void InitcboMajor_from()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strmajor_code = cboMajor_from.SelectedValue;
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
                cboMajor_from.Items.Clear();
                cboMajor_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboMajor_from.Items.Add(new ListItem(dt.Rows[i]["major_name"].ToString(), dt.Rows[i]["major_code"].ToString()));
                }
                if (cboMajor_from.Items.FindByValue(strmajor_code) != null)
                {
                    cboMajor_from.SelectedIndex = -1;
                    cboMajor_from.Items.FindByValue(strmajor_code).Selected = true;
                }
            }
        }

        private void InitcboDegree_to()
        {
            cDegree oDegree = new cDegree();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strDegree_code = string.Empty;
            string strdegree_year = cboYear.SelectedValue;
            strDegree_code = cboDegree_to.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree_to.Items.Clear();
                //cboDegree.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree_to.Items.Add(new ListItem(dt.Rows[i]["Degree_name"].ToString(), dt.Rows[i]["Degree_code"].ToString()));
                }
                if (cboDegree_to.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree_to.SelectedIndex = -1;
                    cboDegree_to.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }


        private void InitcboMajor_to()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strmajor_code = cboMajor_to.SelectedValue;
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
                cboMajor_to.Items.Clear();
                cboMajor_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboMajor_to.Items.Add(new ListItem(dt.Rows[i]["major_name"].ToString(), dt.Rows[i]["major_code"].ToString()));
                }
                if (cboMajor_to.Items.FindByValue(strmajor_code) != null)
                {
                    cboMajor_to.SelectedIndex = -1;
                    cboMajor_to.Items.FindByValue(strmajor_code).Selected = true;
                }
            }
        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "RegisterScript();createDate('" + txtbudget_transfer_date.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    var url = @"~/App_Control/budget_transfer/budget_transfer_control.aspx?mode=edit&budget_transfer_doc=" + ViewState["budget_transfer_doc"].ToString() + "&budget_type=" + this.BudgetType;
                    Response.Redirect(url);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_transfer_doc.ReadOnly = true;
                    txtbudget_transfer_doc.CssClass = "textboxdis";
                }
                MsgBox("บันทึกข้อมูลสมบูรณ์");
            }
        }

        protected void cboBudget_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbudget_plan_code_from.Text = string.Empty;
            txtbudget_name_from.Text = string.Empty;
            txtproduce_name_from.Text = string.Empty;
            txtactivity_name_from.Text = string.Empty;
            txtplan_name_from.Text = string.Empty;
            txtwork_name_from.Text = string.Empty;
            txtfund_name_from.Text = string.Empty;
            txtunit_name_from.Text = string.Empty;
        }

        private void ClearData()
        {
            ClearDataControls(pnlMain);
            InitcboYear();
            InitcboDegree_from();
            InitcboBudgetType();
            InitcboMajor_from();

            InitcboDegree_to();
            InitcboMajor_to();

            txtbudget_transfer_doc.ReadOnly = true;
            txtbudget_transfer_doc.CssClass = "textboxdis";
            txtbudget_transfer_doc.CssClass = "textboxdis";
            TabContainer1.Tabs[0].Visible = true;
            TabContainer1.Tabs[1].Visible = false;

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/App_Control/budget_transfer/budget_transfer_list.aspx?budget_type={0}", this.BudgetType));
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
            var lstBudgetDetail = new List<view_Budget_transfer_detail>();
            try
            {
                cBudget_transfer oBudget_transfer = new cBudget_transfer();
                _strMessage = string.Empty;
                _strCriteria = " and budget_transfer_doc = '" + txtbudget_transfer_doc.Text + "' order by lot_code_from";
                lstBudgetDetail = oBudget_transfer.GETDETAILS(_strCriteria);
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
                    view_Budget_transfer_detail dv = (view_Budget_transfer_detail)e.Row.DataItem;
                    Label lblNo = (Label)e.Row.FindControl("lblNo");
                    int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                    lblNo.Text = nNo.ToString();


                    #region set ImageView
                    ImageButton imgView = (ImageButton)e.Row.FindControl("imgView");
                    imgView.Attributes.Add("onclick", "OpenPopUp('1000px','400px','96%','แสดงข้อมูลรายการโอนเงิน','budget_transfer_detail_control.aspx?mode=view&budget_transfer_doc=" + dv.budget_transfer_doc + 
                        "&budget_transfer_detail_id=" + dv.budget_transfer_detail_id.ToString() + 
                        "&year=" + dv.budget_transfer_year + 
                        "&budget_type=" + this.BudgetType + "','1');return false;");
                    imgView.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["img"].ToString();
                    imgView.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["title"].ToString());
                    #endregion

                    #region set Image Edit & Delete

                    ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                    imgEdit.Attributes.Add("onclick", "OpenPopUp('1000px','400px','96%','แก้ไขข้อมูลรายการโอนเงิน','budget_transfer_detail_control.aspx?mode=edit&budget_transfer_doc=" + dv.budget_transfer_doc + 
                        "&budget_transfer_detail_id=" + dv.budget_transfer_detail_id.ToString() + 
                        "&year=" + dv.budget_transfer_year + 
                        "&budget_type=" + this.BudgetType + "','1');return false;");
                    imgEdit.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["img"].ToString();
                    imgEdit.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["title"].ToString());

                    ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                    imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                    imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                    imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบข้อมูลนี้หรือไม่ ?\");");
                    //imgDelete.Visible = IsUserDelete;
                    #endregion

                    ViewState["TotalAmount"] = Helper.CDbl(ViewState["TotalAmount"]) +
                                               Helper.CDbl(dv.budget_transfer_detail_amount);
                }

            }
            else if (e.Row.RowType.Equals(DataControlRowType.Footer))
            {
                AwNumeric txttransfer_amount = (AwNumeric)e.Row.FindControl("txttransfer_amount");
                txttransfer_amount.Value = Helper.CDbl(ViewState["TotalAmount"]);
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
            HiddenField hddbudget_transfer_detail_id = (HiddenField)GridView1.Rows[e.RowIndex].FindControl("hddbudget_transfer_detail_id");
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            try
            {
                oBudget_transfer.SP_BUDGET_TRANSFER_DETAIL_DEL(hddbudget_transfer_detail_id.Value);
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
                oBudget_transfer.Dispose();
            }
            BindGridDetail();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName.ToUpper())
            //{
            //    case "ADD":
            //        StoreDetail();
            //        this.lstBudgetDetail.Add(new view_Budget_transfer_detail
            //        {
            //            budget_transfer_detail_id = ++this.OpenDetailID,
            //            budget_transfer_detail_amount = 0,
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
                var dt = new List<view_Budget_transfer_detail>();

                // need to clone sources otherwise it will be indirectly adding to 
                // the original source

                //if (grdView.DataSource is IList)
                //{
                //    var source = (List<view_Budget_transfer_detail>)grdView.DataSource;
                //    Helper.CopyTo(source, dt);
                //}
                //if (dt == null)
                //{
                //    return;
                //}

                dt.Add(new view_Budget_transfer_detail());
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


        protected void lbkRefresh_from_Click(object sender, EventArgs e)
        {
            cBudget_plan oBudget_plan = new cBudget_plan();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_plan_code = '" + txtbudget_plan_code_from.Text + "' ";
                var item = oBudget_plan.GET(strCriteria);
                if (item != null)
                {
                    txtbudget_plan_code_from.Text = item.budget_plan_code;
                    txtunit_name_from.Text = item.unit_name;
                    txtbudget_name_from.Text = item.budget_name;
                    txtproduce_name_from.Text = item.produce_name;
                    txtactivity_name_from.Text = item.activity_name;
                    txtplan_name_from.Text = item.plan_name;
                    txtwork_name_from.Text = item.work_name;
                    txtfund_name_from.Text = item.fund_name;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void lbkRefresh_to_Click(object sender, EventArgs e)
        {
            cBudget_plan oBudget_plan = new cBudget_plan();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_plan_code = '" + txtbudget_plan_code_to.Text + "' ";
                var item = oBudget_plan.GET(strCriteria);
                if (item != null)
                {
                    txtbudget_plan_code_to.Text = item.budget_plan_code;
                    txtunit_name_to.Text = item.unit_name;
                    txtbudget_name_to.Text = item.budget_name;
                    txtproduce_name_to.Text = item.produce_name;
                    txtactivity_name_to.Text = item.activity_name;
                    txtplan_name_to.Text = item.plan_name;
                    txtwork_name_to.Text = item.work_name;
                    txtfund_name_to.Text = item.fund_name;
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

        protected void imgClear_budget_plan_to_Click(object sender, ImageClickEventArgs e)
        {
            ClearBudgetPlanTo();
        }

        private void ClearBudgetPlan()
        {
            txtbudget_plan_code_from.Text = string.Empty;
            txtunit_name_from.Text = string.Empty;
            txtbudget_name_from.Text = string.Empty;
            txtproduce_name_from.Text = string.Empty;
            txtactivity_name_from.Text = string.Empty;
            txtplan_name_from.Text = string.Empty;
            txtwork_name_from.Text = string.Empty;
            txtfund_name_from.Text = string.Empty;

            //if (ViewState["mode"].ToString() == "edit")
            //{
            //    cBudget_transfer oBudget_transfer = new cBudget_transfer();
            //    try
            //    {
            //        oBudget_transfer.SP_BUDGET_TRANSFER_DETAIL_DEL_BY_DOC(txtbudget_transfer_doc.Text);
            //        BindGridDetail();
            //    }
            //    catch(Exception ex)
            //    {
            //        lblError.Text = ex.Message;
            //        throw ex;
            //    }
            //    finally
            //    {
            //        oBudget_transfer.Dispose();
            //    }
            //}
        }

        private void ClearBudgetPlanTo()
        {
            txtbudget_plan_code_to.Text = string.Empty;
            txtunit_name_to.Text = string.Empty;
            txtbudget_name_to.Text = string.Empty;
            txtproduce_name_to.Text = string.Empty;
            txtactivity_name_to.Text = string.Empty;
            txtplan_name_to.Text = string.Empty;
            txtwork_name_to.Text = string.Empty;
            txtfund_name_to.Text = string.Empty;

            //if (ViewState["mode"].ToString() == "edit")
            //{
            //    cBudget_transfer oBudget_transfer = new cBudget_transfer();
            //    try
            //    {
            //        oBudget_transfer.SP_BUDGET_TRANSFER_DETAIL_DEL_BY_DOC(txtbudget_transfer_doc.Text);
            //        BindGridDetail();
            //    }
            //    catch(Exception ex)
            //    {
            //        lblError.Text = ex.Message;
            //        throw ex;
            //    }
            //    finally
            //    {
            //        oBudget_transfer.Dispose();
            //    }
            //}
        }

        protected void cboDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }

        protected void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindGridDetail();
        }

        protected void cboMajor_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlanTo();
        }

        protected void cboDegree_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlanTo();
        }
    }
}
