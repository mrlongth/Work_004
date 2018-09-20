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

namespace myWeb.App_Control.deduct
{
    public partial class deduct_control : PageBase
    {

        #region private data

        private string BudgetType
        {
            get
            {
                if (ViewState["BudgetType"] == null)
                {
                    ViewState["BudgetType"] = "R";
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

        private DataTable dtDeductDetail
        {
            get
            {
                if (ViewState["dtDeductDetail"] == null)
                {
                    cDeduct oDeduct = new cDeduct();
                    _strMessage = string.Empty;
                    _strCriteria = " and deduct_doc_no = " + Helper.CInt(ViewState["deduct_doc"]) + " order by recv_item_code";
                    DataSet dsTemp = null;
                    oDeduct.SP_DEDUCT_DETAIL_SEL(_strCriteria, ref dsTemp, ref _strMessage);
                    if (dsTemp != null)
                    {
                        var dtTemp = dsTemp.Tables[0];
                        dtTemp.Columns.Add("row_status");
                        if (dtTemp.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                dr["row_status"] = "O";
                            }
                        }
                        ViewState["dtDeductDetail"] = dtTemp;
                    }

                }
                return (DataTable)ViewState["dtDeductDetail"];
            }
            set
            {
                ViewState["dtDeductDetail"] = value;
            }
        }

        private long DeductDetailID
        {
            get
            {
                if (ViewState["DeductDetailID"] == null)
                {
                    ViewState["DeductDetailID"] = 1000000;
                }
                return long.Parse(ViewState["DeductDetailID"].ToString());
            }
            set
            {
                ViewState["DeductDetailID"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ViewState["sort"] = "recv_item_code";
                ViewState["direction"] = "ASC";

                TabContainer1.ActiveTabIndex = 0;

                #region set QueryString
                if (Request.QueryString["deduct_doc"] != null)
                {
                    ViewState["deduct_doc"] = Request.QueryString["deduct_doc"].ToString();
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
                    BindGridDetail();
                    txtdeduct_date.Text = cCommon.CheckDate(DateTime.Now.ToShortDateString());
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    BindGridDetail();
                    txtdeduct_doc.ReadOnly = true;
                    txtdeduct_doc.CssClass = "textboxdis";
                    pnlDetail.Visible = true;
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
            Deduct_head deduct_head = new Deduct_head();
            cDeduct oDeduct = new cDeduct();
            try
            {
                #region set Data
                deduct_head.deduct_doc_no = txtdeduct_doc.Text;
                deduct_head.deduct_year = cboYear.SelectedValue;
                deduct_head.deduct_date = cCommon.GetDate(txtdeduct_date.Text);
                deduct_head.budget_money_doc = txtbudget_money_doc.Text;
                deduct_head.budget_receive_doc = txtbudget_receive_doc.Text;
                deduct_head.major_code = cboMajor.SelectedValue;
                deduct_head.degree_code = cboDegree.SelectedValue;

                deduct_head.recv_doc_no = txtrecv_doc_no.Text;
                deduct_head.recv_total_amount = decimal.Parse(txtrecv_total_amount.Value.ToString());
                deduct_head.deduct_total_reduce = decimal.Parse(txtdeduct_total_reduce.Value.ToString());
                deduct_head.deduct_total_reduce_director = decimal.Parse(txtdeduct_total_reduce_director.Value.ToString());
                deduct_head.deduct_total_remain = decimal.Parse(txtdeduct_total_remain.Value.ToString());

                deduct_head.budget_plan_code = txtbudget_plan_code.Text;
                deduct_head.deduct_remark = txtcomment.Text.Trim();
                deduct_head.item_group_detail_id = int.Parse(cboItem_group_detail.SelectedValue);
                deduct_head.c_created_by = Session["username"].ToString();
                deduct_head.c_updated_by = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    if (oDeduct.SP_DEDUCT_HEAD_UPD(deduct_head))
                    {
                        SaveDetail();
                        saveBudgetReceive();
                    }
                }
                else
                {
                    oDeduct.SP_DEDUCT_HEAD_INS(deduct_head);
                    ViewState["deduct_doc"] = deduct_head.deduct_doc_no;
                    saveBudgetReceive();
                    deduct_head.budget_receive_doc = txtbudget_receive_doc.Text;
                    oDeduct.SP_DEDUCT_HEAD_UPD(deduct_head);
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
                    //lblError.Text = ex.Message.ToString();
                }
            }
            finally
            {
                oDeduct.Dispose();
            }
            return blnResult;
        }


        private bool saveBudgetReceive()
        {
            bool blnResult = false;
            Budget_receive_head budget_receive_head = new Budget_receive_head();
            cBudget_receive oBudget_receive = new cBudget_receive();
            try
            {
                #region set Data
                budget_receive_head.budget_receive_doc = txtbudget_receive_doc.Text;
                budget_receive_head.budget_receive_date = cCommon.GetDate(txtdeduct_date.Text);
                budget_receive_head.budget_receive_year = cboYear.SelectedValue;
                budget_receive_head.budget_type = this.BudgetType;
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
                        saveRecvDetail();
                        oBudget_receive.SP_BUDGET_RECEIVE_TOTAL_UPD(txtbudget_receive_doc.Text);                       
                    }
                }
                else
                {
                    oBudget_receive.SP_BUDGET_RECEIVE_HEAD_INS(budget_receive_head);
                    txtbudget_receive_doc.Text = budget_receive_head.budget_receive_doc;
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

        private bool saveRecvDetail()
        {
            bool blnResult = false;
            cBudget_receive oBudget_receive = new cBudget_receive();
            cBudget_money oBudget_money = new cBudget_money();
            cCommon oCommon = new cCommon();
            var ds = new DataSet();
            DataTable dt = null;
            var major_director_code = string.Empty;
            oCommon.SEL_SQL("select g_code from General where g_type = 'main_director_code'", ref ds, ref _strMessage);
            dt = ds.Tables[0];
            if(dt.Rows.Count > 0)
            {
                major_director_code =  "M" + cboYear.SelectedValue.Substring(2,2) + dt.Rows[0]["g_code"].ToString();
            }
            _strCriteria = " and budget_money_doc = '" + txtbudget_money_doc.Text + "' ";
            _strCriteria += " and major_code in (select '"+ major_director_code + "' union all select '"+ cboMajor.SelectedValue +"') ";

            var listBudget_major = oBudget_money.GETMONEYDETAILS(_strCriteria);
            if (listBudget_major != null)
            {
                List<Budget_receive_detail> listBudget_receive_detail = new List<Budget_receive_detail>();
                try
                {
                    decimal detail_contribute = 0;
                    foreach (var row in listBudget_major)
                    {
                        if (row.major_code == major_director_code)
                        {
                            detail_contribute = decimal.Parse(txtdeduct_total_reduce_director.Value.ToString());
                        }
                        else
                        {
                            detail_contribute = decimal.Parse(txtdeduct_total_remain.Value.ToString());
                        }
                        listBudget_receive_detail.Add(new Budget_receive_detail
                        {
                            budget_receive_doc = txtbudget_receive_doc.Text,
                            budget_money_major_id = row.budget_money_major_id,
                            budget_receive_detail_contribute = detail_contribute,
                            c_created_by = Session["username"].ToString(),
                            c_updated_by = Session["username"].ToString()
                        });                       
                    }
                    DeleteRecvDetail(txtbudget_receive_doc.Text);
                    if (listBudget_receive_detail.Any())
                    {

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
            }         
            return blnResult;
        }

        private bool DeleteRecvDetail(string pbudget_receive_doc)
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

        private void setData()
        {
            view_Deduct_head deduct_head = null;
            cDeduct oDeduct = new cDeduct();
            try
            {
                _strCriteria = " and deduct_doc_no = '" + ViewState["deduct_doc"].ToString() + "' ";
                deduct_head = oDeduct.GET(_strCriteria);
                if (deduct_head != null)
                {
                    #region set Control
                    TabContainer1.Tabs[1].Visible = true;
                    //Tab 1 
                    txtUpdatedBy.Text = deduct_head.c_updated_by;
                    txtUpdatedDate.Text = deduct_head.d_updated_date.ToString();
                    txtdeduct_doc.Text = deduct_head.deduct_doc_no;
                    txtdeduct_date.Text = deduct_head.deduct_date.Value.ToString("dd/MM/yyyy");
                    txtbudget_money_doc.Text = deduct_head.budget_money_doc;

                    InitcboYear();
                    if (cboYear.Items.FindByValue(deduct_head.deduct_year) != null)
                    {
                        cboYear.SelectedIndex = -1;
                        cboYear.Items.FindByValue(deduct_head.deduct_year).Selected = true;
                    }

                    InitcboDegree();
                    if (cboDegree.Items.FindByValue(deduct_head.degree_code) != null)
                    {
                        cboDegree.SelectedIndex = -1;
                        cboDegree.Items.FindByValue(deduct_head.degree_code).Selected = true;
                    }

                    InitcboMajor();
                    if (cboMajor.Items.FindByValue(deduct_head.major_code) != null)
                    {
                        cboMajor.SelectedIndex = -1;
                        cboMajor.Items.FindByValue(deduct_head.major_code).Selected = true;
                    }


                    txtbudget_plan_code.Text = deduct_head.budget_plan_code;
                    txtbudget_name.Text = deduct_head.budget_name;
                    txtproduce_name.Text = deduct_head.produce_name;
                    txtactivity_name.Text = deduct_head.activity_name;
                    txtplan_name.Text = deduct_head.plan_name;
                    txtwork_name.Text = deduct_head.work_name;
                    txtfund_name.Text = deduct_head.fund_name;
                    txtdirector_name.Text = deduct_head.director_name;
                    txtunit_name.Text = deduct_head.unit_name;
                    txtcomment.Text = deduct_head.deduct_remark;

                    txtrecv_total_amount.Value = deduct_head.recv_total_amount;
                    txtdeduct_total_reduce.Value = deduct_head.deduct_total_reduce;
                    txtdeduct_total_reduce_director.Value = deduct_head.deduct_total_reduce_director;
                    txtdeduct_total_remain.Value = deduct_head.deduct_total_remain;

                    txtrecv_doc_no.Text = deduct_head.recv_doc_no;
                 
                    InitcboItem_group_detail();
                    if (cboItem_group_detail.Items.FindByValue(deduct_head.item_group_detail_id.ToString()) != null)
                    {
                        cboItem_group_detail.SelectedIndex = -1;
                        cboItem_group_detail.Items.FindByValue(deduct_head.item_group_detail_id.ToString()).Selected = true;
                    }

                    BindGridDetail();

                    TabContainer1.Tabs[2].Visible = true;
                    txtbudget_receive_doc.Text = deduct_head.budget_receive_doc;
                    BindGridDetailReceive();

                    #endregion
                }


            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message.ToString();
            }
        }

        private void InitcboYear()
        {
            string strYear = string.Empty;
            strYear = cboYear.SelectedValue;
            if (strYear.Equals(""))
            {
                if (this.BudgetType == "B")
                {
                    strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
                }
                else
                {
                    strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow2"].ToString();
                }
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

        private void InitcboMajor()
        {
            cBudget_money oMajor = new cBudget_money();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strmajor_code = cboMajor.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  budget_money_doc = '" + txtbudget_money_doc.Text + "' " ;
            if (MajorLock == "Y")
            {
                strCriteria += " and major_code = '" + PersonMajorCode + "' ";
            }

            if (oMajor.SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
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

        private void InitcboItem_group_detail()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' and item_group_type = 'D' ";
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "RegisterScript();createDate('" + txtdeduct_date.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    var url = @"~/App_Control/deduct/deduct_control.aspx?mode=edit&deduct_doc=" + ViewState["deduct_doc"].ToString() + "&budget_type=" + this.BudgetType;
                    Response.Redirect(url);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtdeduct_doc.ReadOnly = true;
                    txtdeduct_doc.CssClass = "textboxdis";
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
            InitcboMajor();
            InitcboItem_group_detail();
            txtdeduct_doc.ReadOnly = true;
            txtdeduct_doc.CssClass = "textboxdis";
            txtdeduct_doc.CssClass = "textboxdis";
            TabContainer1.Tabs[0].Visible = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App_Control/deduct/deduct_list.aspx");
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
                grdView.DataSource != null)
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

        #region GridView1 Event

        private void StoreDetail()
        {
            try
            {
                HiddenField hdddeduct_detail_id;
                TextBox txtrecv_item_code;
                TextBox txtrecv_item_name;
                AwNumeric txtrecv_item_rate;
                AwNumeric txtdeduct_item_amount;
                TextBox txtdeduct_item_remark;
                CheckBox chkDeduct_item_is_director;
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    hdddeduct_detail_id = (HiddenField)gvRow.FindControl("hdddeduct_detail_id");
                    txtrecv_item_code = (TextBox)gvRow.FindControl("txtrecv_item_code");
                    txtrecv_item_name = (TextBox)gvRow.FindControl("txtrecv_item_name");
                    txtrecv_item_rate = (AwNumeric)gvRow.FindControl("txtrecv_item_rate");
                    txtdeduct_item_amount = (AwNumeric)gvRow.FindControl("txtdeduct_item_amount");
                    txtdeduct_item_remark = (TextBox)gvRow.FindControl("txtdeduct_item_remark");
                    chkDeduct_item_is_director = (CheckBox)gvRow.FindControl("chkDeduct_item_is_director");
                    foreach (DataRow dr in this.dtDeductDetail.Rows)
                    {
                        if (Helper.CLong(dr["deduct_detail_id"]) == Helper.CLong(hdddeduct_detail_id.Value))
                        {
                            dr["deduct_detail_id"] = hdddeduct_detail_id.Value;
                            dr["recv_item_code"] = txtrecv_item_code.Text;
                            dr["recv_item_name"] = txtrecv_item_name.Text;
                            dr["recv_item_rate"] = Helper.CDbl(txtrecv_item_rate.Value);
                            dr["deduct_item_amount"] = Helper.CDbl(txtdeduct_item_amount.Value);
                            dr["deduct_item_remark"] = txtdeduct_item_remark.Text;
                            dr["deduct_item_is_director"] = chkDeduct_item_is_director.Checked;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
            }
        }

        private void BindGridDetail()
        {
            DataView dv = null;
            try
            {
                if (ViewState["mode"].ToString() == "copy")
                {
                    foreach (DataRow dr in this.dtDeductDetail.Rows)
                    {
                        dr["deduct_detail_id"] = ++this.DeductDetailID;
                        dr["row_status"] = "N";
                    }
                }
                dv = new DataView(this.dtDeductDetail, "row_status<>'D'", (ViewState["sort"] + " " + ViewState["direction"]), DataViewRowState.CurrentRows);
                GridView1.DataSource = dv.ToTable();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                this.bIsGridDetailEmpty = false;
                if (dv.ToTable().Rows.Count == 0)
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

        private void BindGridDetailReceive()
        {
             try
            {
                cBudget_receive oBudget_receive = new cBudget_receive();
                _strMessage = string.Empty;
                _strCriteria = " and budget_receive_doc = " + txtbudget_receive_doc.Text ;
                var res = oBudget_receive.GETDETAILS(_strCriteria);               
                GridView2.DataSource = res;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }           
        }


        private bool SaveDetail()
        {
            bool blnResult = false;
            cDeduct oDeduct = new cDeduct();
            try
            {
                string strUserName = Session["username"].ToString();
                StoreDetail();
                foreach (DataRow dr in this.dtDeductDetail.Rows)
                {
                    if (Helper.CStr(dr["recv_item_code"]).Trim().Length > 0)
                    {
                        var detail = new Deduct_detail
                        {
                            deduct_doc_no = txtdeduct_doc.Text,
                            deduct_detail_id = Helper.CLong(dr["deduct_detail_id"]),
                            recv_item_code = Helper.CStr(dr["recv_item_code"]),
                            recv_item_rate = Helper.CDec(dr["recv_item_rate"]),
                            deduct_item_amount = Helper.CDec(dr["deduct_item_amount"]),
                            deduct_item_is_director = Helper.CBool(dr["deduct_item_is_director"]),
                            deduct_item_remark = Helper.CStr(dr["deduct_item_remark"]),
                            c_created_by = strUserName,
                            c_updated_by = strUserName
                        };
                        if (Helper.CStr(dr["row_status"]) == "N")
                        {
                            oDeduct.SP_DEDUCT_DETAIL_INS(detail);
                        }
                        else if (Helper.CStr(dr["row_status"]) == "O")
                        {
                            oDeduct.SP_DEDUCT_DETAIL_UPD(detail);
                        }
                        else if (Helper.CStr(dr["row_status"]) == "D")
                        {
                            oDeduct.SP_DEDUCT_DETAIL_DEL(detail.deduct_detail_id);
                        }
                    }
                }
                this.dtDeductDetail = null;
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDeduct.Dispose();
            }
            return blnResult;
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

                txtdeduct_total_reduce.Value = 0;
                txtdeduct_total_reduce_director.Value = 0;
                txtdeduct_total_remain.Value = 0;

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
                    DataRowView dv = (DataRowView)e.Row.DataItem;
                    Label lblNo = (Label)e.Row.FindControl("lblNo");
                    int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                    lblNo.Text = nNo.ToString();

                    #region set Image Delete

                    ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                    imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                    imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                    imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบข้อมูลนี้หรือไม่ ?\");");
                    imgDelete.Visible = IsUserDelete;
                    #endregion
                    CheckBox chkDeduct_item_is_director = (CheckBox)e.Row.FindControl("chkDeduct_item_is_director");
                    chkDeduct_item_is_director.Checked = Helper.CBool(dv["deduct_item_is_director"]);

                    var txtdeduct_item_amount = (AwNumeric)e.Row.FindControl("txtdeduct_item_amount");

                    txtdeduct_total_reduce.Value = Helper.CDec(txtdeduct_total_reduce.Value) + Helper.CDec(txtdeduct_item_amount.Value);
                    if(chkDeduct_item_is_director.Checked)
                    {
                        txtdeduct_total_reduce_director.Value = Helper.CDec(txtdeduct_total_reduce_director.Value) + Helper.CDec(txtdeduct_item_amount.Value);
                    }
                    txtdeduct_total_remain.Value = Helper.CDec(txtrecv_total_amount.Value) - Helper.CDec(txtdeduct_total_reduce.Value);
                }

            }
            else if (e.Row.RowType.Equals(DataControlRowType.Footer))
            {
                //AwNumeric txtopen_amount = (AwNumeric)e.Row.FindControl("txtopen_amount");
                //txtopen_amount.Value = Helper.CDbl(ViewState["TotalAmount"]);
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
                            if (ViewState["direction2"].Equals("ASC"))
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
            HiddenField hdddeduct_detail_id = (HiddenField)GridView1.Rows[e.RowIndex].FindControl("hdddeduct_detail_id");
            try
            {
                StoreDetail();
                int i = 0;
                foreach (DataRow dr in this.dtDeductDetail.Rows)
                {
                    if (Helper.CLong(dr["deduct_detail_id"]) == Helper.CLong(hdddeduct_detail_id.Value))
                    {
                        dr["row_status"] = "D";
                        break;
                    }
                    ++i;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
            }
            BindGridDetail();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName.ToUpper())
            {
                case "ADD":
                    StoreDetail();
                    DataRow dr = this.dtDeductDetail.NewRow();
                    dr["deduct_detail_id"] = ++this.DeductDetailID;
                    dr["recv_item_id"] = "0";
                    dr["recv_item_name"] = string.Empty;
                    dr["recv_item_detail"] = string.Empty;
                    dr["recv_item_rate"] = 0;
                    dr["deduct_item_remark"] = string.Empty;
                    dr["row_status"] = "N";
                    this.dtDeductDetail.Rows.Add(dr);
                    BindGridDetail();
                    break;
                default:
                    break;
            }
        }
        #endregion

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    int nNo = (GridView2.PageSize * GridView2.PageIndex) + e.Row.RowIndex + 1;
                    lblNo.Text = nNo.ToString();

            }
            else if (e.Row.RowType.Equals(DataControlRowType.Footer))
            {
                //AwNumeric txtopen_amount = (AwNumeric)e.Row.FindControl("txtopen_amount");
                //txtopen_amount.Value = Helper.CDbl(ViewState["TotalAmount"]);
            }
        }

        protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                #region Create Item Header
                bool bSort = false;
                int i = 0;
                for (i = 0; i < GridView2.Columns.Count; i++)
                {
                    if (ViewState["sort"].Equals(GridView2.Columns[i].SortExpression))
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
                            if (ViewState["direction2"].Equals("ASC"))
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

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
        }         

        protected void lkbRefresh_Click(object sender, EventArgs e)
        {
            BindGridDetail();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.dtDeductDetail = null;
            BindGridDetail();
        }

        protected void cboItem_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group_detail();
        }

        protected void lbkRefresh_Click(object sender, EventArgs e)
        {
            cBudget_money oBudget_money = new cBudget_money();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_money_doc = '" + txtbudget_money_doc.Text + "' ";
                var item = oBudget_money.GET(strCriteria);
                if (item != null)
                {
                    txtbudget_money_doc.Text = item.budget_money_doc;
                    txtbudget_plan_code.Text = item.budget_plan_code;
                    txtdirector_name.Text = item.director_name;
                    txtunit_name.Text = item.unit_name;
                    txtbudget_name.Text = item.budget_name;
                    txtproduce_name.Text = item.produce_name;
                    txtactivity_name.Text = item.activity_name;
                    txtplan_name.Text = item.plan_name;
                    txtwork_name.Text = item.work_name;
                    txtfund_name.Text = item.fund_name;
                    InitcboMajor();
                    InitcboItem_group_detail();
                }

            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message.ToString();
            }
        }

        protected void imgClear_budget_plan_Click(object sender, ImageClickEventArgs e)
        {
            ClearBudgetPlan();
        }

        private void ClearBudgetPlan()
        {
            txtbudget_money_doc.Text = string.Empty;
            txtbudget_plan_code.Text = string.Empty;
            txtdirector_name.Text = string.Empty;
            txtunit_name.Text = string.Empty;
            txtbudget_name.Text = string.Empty;
            txtproduce_name.Text = string.Empty;
            txtactivity_name.Text = string.Empty;
            txtplan_name.Text = string.Empty;
            txtwork_name.Text = string.Empty;
            txtfund_name.Text = string.Empty;
            InitcboMajor();
            InitcboItem_group_detail();
        }

        protected void cboDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }

        protected void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }

        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearBudgetPlan();
        }
    }
}
