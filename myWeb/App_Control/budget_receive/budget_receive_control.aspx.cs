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

namespace myWeb.App_Control.budget_receive
{
    public partial class budget_receive_control : PageBase
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


        protected List<view_Budget_money_major> lstBudgetMajor
        {
            get
            {
                if (ViewState["lstBudgetMajor"] == null)
                {
                    ViewState["lstBudgetMajor"] = new List<view_Budget_money_major>();
                }
                return (List<view_Budget_money_major>)ViewState["lstBudgetMajor"];
            }
            set
            {
                ViewState["lstBudgetMajor"] = value;
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ViewState["sort"] = "lot_name";
                ViewState["direction"] = "ASC";

                TabContainer1.ActiveTabIndex = 0;

                #region set QueryString
                if (Request.QueryString["budget_receive_doc"] != null)
                {
                    ViewState["budget_receive_doc"] = Request.QueryString["budget_receive_doc"].ToString();
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
                    txtbudget_receive_date.Text = cCommon.CheckDate(DateTime.Now.ToShortDateString());
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_receive_doc.ReadOnly = true;
                    txtbudget_receive_doc.CssClass = "textboxdis";
                    pnlDetail.Visible = true;
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    Utils.SetControls(pnlMain, myDLL.Common.Enumeration.Mode.VIEW);
                }


                #endregion



            }
            else
            {

            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            Budget_receive_head budget_receive_head = new Budget_receive_head();
            cBudget_receive oBudget_receive = new cBudget_receive();
            try
            {
                #region set Data
                budget_receive_head.budget_receive_doc = txtbudget_receive_doc.Text;
                budget_receive_head.budget_receive_date = cCommon.GetDate(txtbudget_receive_date.Text);
                budget_receive_head.budget_receive_year = cboYear.SelectedValue;
                budget_receive_head.budget_type = cboBudget_type.SelectedValue;
                budget_receive_head.budget_plan_code = txtbudget_plan_code.Text;
                budget_receive_head.degree_code = cboDegree.SelectedValue;
                budget_receive_head.item_group_detail_id = int.Parse(cboItem_group_detail.SelectedValue);
                budget_receive_head.budget_receive_comment = txtcomment.Text.Trim();
                budget_receive_head.c_created_by = Session["username"].ToString();
                budget_receive_head.c_updated_by = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    if (oBudget_receive.SP_BUDGET_RECEIVE_HEAD_UPD(budget_receive_head))
                    {
                        saveDataDetail();
                    }
                }
                else
                {
                    oBudget_receive.SP_BUDGET_RECEIVE_HEAD_INS(budget_receive_head);
                    ViewState["budget_receive_doc"] = budget_receive_head.budget_receive_doc;
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
                oBudget_receive.Dispose();
            }
            return blnResult;
        }

        private bool saveDataDetail()
        {
            bool blnResult = false;
            cBudget_receive oBudget_receive = new cBudget_receive();
            List<Budget_receive_detail> listBudget_receive_detail = new List<Budget_receive_detail>();
            try
            {
                var lstMajor = lstBudgetMajor
                    .GroupBy(m => new { m.major_code, m.major_name, m.major_abbrev })
                    .Select(r => new Major { major_code = r.Key.major_code, major_name = r.Key.major_name, major_abbrev = r.Key.major_abbrev });
               
                foreach (GridViewRow row in GridViewDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        //rptItem_group
                        var rptItem_group = row.FindControl("rptItem_group") as Repeater;
                        foreach (RepeaterItem row_item_group in rptItem_group.Items)
                        {
                            //rptItem_group_detail
                            var rptItem_group_detail = row_item_group.FindControl("rptItem_group_detail") as Repeater;
                            foreach (RepeaterItem row_item_group_detail in rptItem_group_detail.Items)
                            {
                                //rptItem
                                var rptItem = row_item_group_detail.FindControl("rptItem") as Repeater;
                                foreach (RepeaterItem row_item in rptItem.Items)
                                {
                                    // GridViewMajor
                                    var GridViewMajor = row_item.FindControl("GridViewMajor") as GridView;
                                    foreach (GridViewRow row_Major in GridViewMajor.Rows)
                                    {
                                        //if (row_Major.RowType == DataControlRowType.DataRow)
                                        {
                                            var lblItem_detail_name = row_Major.FindControl("lblItem_detail_name");
                                            foreach (var major in lstMajor)
                                            {
                                                var txtMajor = row_Major.FindControl("txt" + major.major_code);
                                                  var hddMajor = row_Major.FindControl("hdd" + major.major_code);
                                                if (txtMajor != null && hddMajor != null)
                                                {
                                                    listBudget_receive_detail.Add(new Budget_receive_detail
                                                    {
                                                        budget_receive_doc = txtbudget_receive_doc.Text,
                                                        budget_money_major_id = long.Parse(((HiddenField)hddMajor).Value),
                                                        budget_receive_detail_contribute = decimal.Parse(((AwNumeric)txtMajor).Value.ToString()),
                                                        c_created_by = Session["username"].ToString(),
                                                        c_updated_by = Session["username"].ToString()
                                                    });
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                if (listBudget_receive_detail.Any())
                {

                    DeleteDetail(txtbudget_receive_doc.Text);
                    // TODO Delete recieve detail
                    foreach (var major in listBudget_receive_detail)
                    {
                        oBudget_receive.SP_BUDGET_RECEIVE_DETAIL_INS(major);
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
                oBudget_receive.Dispose();
            }
            return blnResult;
        }


        private void setData()
        {
            view_Budget_receive_head budget_receive_head = null;
            cBudget_receive oBudget_receive = new cBudget_receive();
            try
            {
                _strCriteria = " and budget_receive_doc = '" + ViewState["budget_receive_doc"].ToString() + "' ";
                budget_receive_head = oBudget_receive.GET(_strCriteria);
                if (budget_receive_head != null)
                {
                    #region set Control
                    TabContainer1.Tabs[1].Visible = true;
                    //Tab 1 
                    txtUpdatedBy.Text = budget_receive_head.c_updated_by;
                    txtUpdatedDate.Text = budget_receive_head.d_updated_date.ToString();
                    txtbudget_receive_doc.Text = budget_receive_head.budget_receive_doc;
                    txtbudget_receive_date.Text = budget_receive_head.budget_receive_date.Value.ToString("dd/MM/yyyy");

                    InitcboYear();
                    if (cboYear.Items.FindByValue(budget_receive_head.budget_receive_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(budget_receive_head.budget_receive_year).Selected = true;
                    }

                    InitcboDegree();
                    if (cboDegree.Items.FindByValue(budget_receive_head.degree_code) != null)
                    {
                        cboDegree.SelectedIndex = -1;
                        cboDegree.Items.FindByValue(budget_receive_head.degree_code).Selected = true;
                    }

                    InitcboBudgetType();
                    if (cboBudget_type.Items.FindByValue(budget_receive_head.budget_type) != null)
                    {
                        cboBudget_type.SelectedIndex = -1;
                        cboBudget_type.Items.FindByValue(budget_receive_head.budget_type).Selected = true;
                    }


                    txtbudget_plan_code.Text = budget_receive_head.budget_plan_code;
                    txtbudget_name.Text = budget_receive_head.budget_name;
                    txtproduce_name.Text = budget_receive_head.produce_name;
                    txtactivity_name.Text = budget_receive_head.activity_name;
                    txtplan_name.Text = budget_receive_head.plan_name;
                    txtwork_name.Text = budget_receive_head.work_name;
                    txtfund_name.Text = budget_receive_head.fund_name;
                    txtdirector_name.Text = budget_receive_head.director_name;
                    txtunit_name.Text = budget_receive_head.unit_name;
                    txtcomment.Text = budget_receive_head.budget_receive_comment;

                    InitcboItem_group();
                    if (cboItem_group.Items.FindByValue(budget_receive_head.item_group_code) != null)
                    {
                        cboItem_group.SelectedIndex = -1;
                        cboItem_group.Items.FindByValue(budget_receive_head.item_group_code).Selected = true;
                    }

                    InitcboItem_group_detail();
                    if (cboItem_group_detail.Items.FindByValue(budget_receive_head.item_group_detail_id.ToString()) != null)
                    {
                        cboItem_group_detail.SelectedIndex = -1;
                        cboItem_group_detail.Items.FindByValue(budget_receive_head.item_group_detail_id.ToString()).Selected = true;
                    }

                    BindGridViewDetail();

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

        private void InitcboItem_group()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_group_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            strItem_group_code = cboItem_group.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' ";
            if (oItem_group.SP_ITEM_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group.Items.Clear();
                cboItem_group.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
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

        private void InitcboItem_group_detail()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            string strItem_group_code = cboItem_group.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' ";
            if (!string.IsNullOrEmpty(strItem_group_code))
            {
                strCriteria += " and item_group_code = '" + strItem_group_code + "'  ";
            }
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

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "RegisterScript();createDate('" + txtbudget_receive_date.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    var url = @"~/App_Control/budget_receive/budget_receive_control.aspx?mode=edit&budget_receive_doc=" + ViewState["budget_receive_doc"].ToString() + "&budget_type=" + this.BudgetType;
                    Response.Redirect(url);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtbudget_receive_doc.ReadOnly = true;
                    txtbudget_receive_doc.CssClass = "textboxdis";
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
            InitcboItem_group();
            InitcboItem_group_detail();
            txtbudget_receive_doc.ReadOnly = true;
            txtbudget_receive_doc.CssClass = "textboxdis";
            txtbudget_receive_doc.CssClass = "textboxdis";
            TabContainer1.Tabs[0].Visible = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/App_Control/budget_receive/budget_receive_list.aspx?budget_type={0}", this.BudgetType));
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

        private void BindGridViewDetail()
        {
            cBudget_money oBudget_money = new cBudget_money();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            strCriteria = " And  (budget_plan_code = '" + txtbudget_plan_code.Text + "' AND degree_code = '" + cboDegree.SelectedValue + "') ";
            try
            {
                if (!oBudget_money.SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    var dtBudgetMajor = ds.Tables[0];
                    lstBudgetMajor = Helper.ToClassInstanceCollection<view_Budget_money_major>(dtBudgetMajor).ToList();
                    var lstLot = lstBudgetMajor.GroupBy(m => new { m.lot_code, m.lot_name }).Select(r => new Lot { lot_code = r.Key.lot_code, lot_name = r.Key.lot_name });
                    //var lstMajor = lstBudgetMajor.GroupBy(m => new { m.major_code, m.major_name, m.major_abbrev }).Select(r => new Major { major_code = r.Key.major_code, major_name = r.Key.major_name, major_abbrev = r.Key.major_abbrev });
                    //foreach (var major in lstMajor)
                    //{
                    //    TemplateField tfield = new TemplateField
                    //    {

                    //        HeaderText = major.major_abbrev,
                    //        ItemTemplate = new MyGridViewTemplate(DataControlRowType.DataRow, "txt" + major.major_code),
                    //    };
                    //    GridViewDetail.Columns.Add(tfield);
                    //}
                    GridViewDetail.PageIndex = 0;
                    ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                    GridViewDetail.DataSource = lstLot;
                    GridViewDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                //if (GridViewDetail.Rows.Count == 0)
                //{
                //    EmptyGridFix(GridViewDetail);
                //}
                oBudget_money.Dispose();
                ds.Dispose();
            }
        }

        protected void GridViewDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {

                for (int iCol = 0; iCol < e.Row.Cells.Count; iCol++)
                {
                    e.Row.Cells[iCol].Attributes.Add("class", "table_h");
                    e.Row.Cells[iCol].Wrap = false;
                }

                //ImageButton imgAdd = (ImageButton)e.Row.FindControl("imgAdd");
                //imgAdd.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["img"].ToString();
                //imgAdd.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgGridAdd"].Rows[0]["title"].ToString());
                //imgAdd.Attributes.Add("onclick", "OpenPopUp('1000px','380px','98%','เพิ่มข้อมูลรายละเอียดงบประมาณประจำปี','budget_receive_detail_control.aspx?mode=add&budget_receive_doc=" + ViewState["budget_receive_doc"].ToString() + "&budget_type=" + this.BudgetType + "','1');return false;");
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
                var lot = (Lot)e.Row.DataItem;
                Label lblNo = (Label)e.Row.FindControl("lblNo");

                //HiddenField hddbudget_receive_detail_id = (HiddenField)e.Row.FindControl("hddbudget_receive_detail_id");
                int nNo = (GridViewDetail.PageSize * GridViewDetail.PageIndex) + e.Row.RowIndex + 1;

                lblNo.Text = nNo.ToString();

                var rptItem_group = (Repeater)e.Row.FindControl("rptItem_group");
                var lstItem_group = this.lstBudgetMajor
                    .Where(b => b.lot_code == lot.lot_code)
                    .GroupBy(ig => new { ig.lot_code, ig.item_group_code, ig.item_group_name })
                    .Select(r => new Item_group { lot_code = r.Key.lot_code, item_group_code = r.Key.item_group_code, item_group_name = r.Key.item_group_name });
                rptItem_group.DataSource = lstItem_group;
                rptItem_group.DataBind();


            }
        }

        protected void GridViewDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                #region Create Item Header
                bool bSort = false;
                int i = 0;
                for (i = 0; i < GridViewDetail.Columns.Count; i++)
                {
                    if (ViewState["sort"].Equals(GridViewDetail.Columns[i].SortExpression))
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

        protected void GridViewDetail_Sorting(object sender, GridViewSortEventArgs e)
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
                BindGridViewDetail();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void GridViewDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow;
            HiddenField hddBudget_receive_detail_id = null;
            if (!e.CommandName.ToUpper().Equals("SORT") && !e.CommandName.ToUpper().Equals("ADD"))
            {
                gvRow = GridViewDetail.Rows[Helper.CInt(e.CommandArgument) - 1];
                hddBudget_receive_detail_id = (HiddenField)gvRow.FindControl("hddBudget_receive_detail_id");
            }
            switch (e.CommandName.ToUpper())
            {
                case "DELETEDETAIL":
                    if (DeleteDetail(hddBudget_receive_detail_id.Value))
                    {
                        BindGridViewDetail();
                    }
                    break;
                case "SORT":
                    break;
                default:
                    break;
            }
        }

        private bool DeleteDetail(string pbudget_receive_doc)
        {
            var oBudget_receive = new cBudget_receive();
            try
            {
                return oBudget_receive.SP_BUDGET_RECEIVE_DETAIL_DEL(pbudget_receive_doc);
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
                oBudget_receive.Dispose();
            }
            return false;
        }



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

        protected void lkbRefresh_Click(object sender, EventArgs e)
        {
            BindGridViewDetail();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            BindGridViewDetail();
        }

        protected void cboItem_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group_detail();
        }

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
        }

        protected void cboDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }


        protected void rptItem_group_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var item_group = (Item_group)e.Item.DataItem;
                var rptItem_group_detail = (Repeater)e.Item.FindControl("rptItem_group_detail");
                var lstItem_group_detail = this.lstBudgetMajor
                    .Where(b => b.lot_code == item_group.lot_code && b.item_group_code == item_group.item_group_code)
                    .GroupBy(ig => new { ig.lot_code, ig.item_group_code, ig.item_group_name, ig.item_group_detail_id, ig.item_group_detail_code, ig.item_group_detail_name })
                    .Select(r => new view_Item_group_detail
                    {
                        lot_code = r.Key.lot_code,
                        item_group_code = r.Key.item_group_code,
                        item_group_detail_id = r.Key.item_group_detail_id.GetValueOrDefault(),
                        item_group_detail_code = r.Key.item_group_detail_code,
                        item_group_detail_name = r.Key.item_group_detail_name
                    });
                rptItem_group_detail.DataSource = lstItem_group_detail;
                rptItem_group_detail.DataBind();
            }
        }

        protected void rptItem_group_detail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var item_group_detail = (view_Item_group_detail)e.Item.DataItem;
                var rptItem = (Repeater)e.Item.FindControl("rptItem");
                var lstItem = this.lstBudgetMajor
                    .Where(b => b.lot_code == item_group_detail.lot_code && b.item_group_code == item_group_detail.item_group_code && b.item_group_detail_id == item_group_detail.item_group_detail_id)
                    .GroupBy(ig => new { ig.lot_code, ig.item_group_code, ig.item_group_detail_id, ig.item_code, ig.item_name })
                    .Select(r => new view_Item
                    {
                        lot_code = r.Key.lot_code,
                        item_group_code = r.Key.item_group_code,
                        item_group_detail_id = r.Key.item_group_detail_id.GetValueOrDefault(),
                        item_code = r.Key.item_code,
                        item_name = r.Key.item_name
                    });
                rptItem.DataSource = lstItem;
                rptItem.DataBind();
            }
        }

        protected void rptItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (view_Item)e.Item.DataItem;
            var GridViewMajor = (GridView)e.Item.FindControl("GridViewMajor");
            var lstItem = this.lstBudgetMajor
                .Where(b => b.lot_code == item.lot_code && b.item_group_code == item.item_group_code && b.item_group_detail_id == item.item_group_detail_id && b.item_code == item.item_code)
                .GroupBy(ig => new { ig.lot_code, ig.item_group_code, ig.item_group_detail_id, ig.item_code, ig.item_detail_id, ig.item_detail_code, ig.item_detail_name })
                .Select(r => new view_Item_detail
                {
                    lot_code = r.Key.lot_code,
                    item_group_code = r.Key.item_group_code,
                    item_group_detail_id = r.Key.item_group_detail_id.GetValueOrDefault(),
                    item_code = r.Key.item_code,
                    item_detail_id = r.Key.item_detail_id.GetValueOrDefault(),
                    item_detail_code = r.Key.item_detail_code,
                    item_detail_name = r.Key.item_detail_name
                });
            BindGridViewMajorColumn(GridViewMajor, item.item_code);
            GridViewMajor.DataSource = lstItem;
            GridViewMajor.DataBind();
        }

        #region GridViewMajor

        protected void GridViewMajor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var GridViewMajor = (GridView)sender;
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

                //HiddenField hddbudget_receive_detail_id = (HiddenField)e.Row.FindControl("hddbudget_receive_detail_id");
                int nNo = (GridViewMajor.PageSize * GridViewMajor.PageIndex) + e.Row.RowIndex + 1;

                lblNo.Text = nNo.ToString();

                var item_detail = (view_Item_detail)e.Row.DataItem;
                var lstItemMajor = this.lstBudgetMajor
               .Where(b => b.lot_code == item_detail.lot_code && b.item_group_code == item_detail.item_group_code &&
                           b.item_group_detail_id == item_detail.item_group_detail_id && item_detail.item_code == item_detail.item_code &&
                           b.item_detail_id == item_detail.item_detail_id);
                //.GroupBy(ig => new
                // {
                //     ig.major_code,
                //     ig.major_name,
                //     ig.major_abbrev
                // })
                //.Select(r => new Major
                //{                   
                //    major_code = r.Key.major_code,
                //    major_name = r.Key.major_name,
                //    major_abbrev = r.Key.major_abbrev
                //});
                var major_name = string.Empty;
                var control_name = string.Empty;
                foreach (var major in lstItemMajor)
                {
                    var txtMajor = e.Row.FindControl("txt" + major.major_code);
                    if (txtMajor != null)
                    {
                        ((AwNumeric)txtMajor).Visible = true;
                    }
                    var hddMajor = e.Row.FindControl("hdd" + major.major_code);
                    if (hddMajor != null)
                    {
                        ((HiddenField)hddMajor).Value = major.budget_money_major_id.ToString();
                    }
                }

                //foreach (GridViewRow row in GridViewMajor.Rows)
                //{
                //    if (row.RowType == DataControlRowType.DataRow)
                //    {

                //    }
                //}
            }
        }


        protected void GridViewMajor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var GridViewMajor = (GridView)sender;
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
                var GridViewMajor = (GridView)sender;
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
                // BindGridViewMajorColumn(GridViewMajor);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        protected void GridViewMajor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //var GridViewMajor = (GridView)sender;
            //GridViewRow gvRow;
            //HiddenField hddBudget_receive_detail_id = null;
            //if (!e.CommandName.ToUpper().Equals("SORT") && !e.CommandName.ToUpper().Equals("ADD"))
            //{
            //    gvRow = GridViewMajor.Rows[Helper.CInt(e.CommandArgument) - 1];
            //    hddBudget_receive_detail_id = (HiddenField)gvRow.FindControl("hddBudget_receive_detail_id");
            //}
            //switch (e.CommandName.ToUpper())
            //{
            //    case "DELETEDETAIL":
            //        if (DeleteDetail(hddBudget_receive_detail_id.Value))
            //        {
            //            BindGridViewMajor();
            //        }
            //        break;
            //    case "SORT":
            //        break;
            //    default:
            //        break;
            //}
        }

        private void BindGridViewMajorColumn(GridView girdMajor, string item_code)
        {
            try
            {
                var lstMajor = lstBudgetMajor
                    .Where(m => m.item_code == item_code)
                    .GroupBy(m => new { m.major_code, m.major_name, m.major_abbrev })
                    .Select(r => new Major { major_code = r.Key.major_code, major_name = r.Key.major_name, major_abbrev = r.Key.major_abbrev });
                foreach (var major in lstMajor)
                {
                    TemplateField tfield = new TemplateField
                    {

                        HeaderText = major.major_abbrev,
                        ItemTemplate = new MyGridViewTemplate(DataControlRowType.DataRow, "txt" + major.major_code),
                    };
                    tfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    girdMajor.Columns.Add(tfield);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }


        #endregion



    }
}
