using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using myModel;
using myDLL.Common;

namespace myWeb.App_Control.report
{
    public partial class main_report : PageBase
    {

        #region private data


        private string ReportCode
        {
            get
            {
                if (ViewState["report_code"] == null)
                {
                    ViewState["report_code"] = Helper.CStr(Request.QueryString["report_code"]);
                }
                return ViewState["report_code"].ToString();
            }
            set
            {
                ViewState["report_code"] = value;
            }
        }

        private string BudgetType
        {
            get
            {
                return cboBudgetType.SelectedValue;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetUpControl();
                InitcboYear();
                InitcboBudgetType();
                InitcboBudget();
                InitcboDegree();
                InitcboUnit();
                InitcboMajor();
                InitcboLot();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RegisterScript", "createDate('" + txtdate_begin.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');createDate('" + txtdate_end.ClientID + "','" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "');", true);
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

        private void InitcboDegree()
        {
            cDegree oDegree = new cDegree();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strDegree_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            strDegree_code = cboDegree.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree.Items.Clear();
                //cboDegree.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree.Items.Add(new ListItem(dt.Rows[i]["degree_name"].ToString(), dt.Rows[i]["degree_code"].ToString()));
                }
                if (cboDegree.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree.SelectedIndex = -1;
                    cboDegree.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }

        private void InitcboUnit()
        {
            cUnit oUnit = new cUnit();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strUnit_code = cboUnit.SelectedValue;
            string strDirector_code = base.DirectorCode;
            string strYear = cboYear.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and unit.unit_year = '" + strYear + "'  and  unit.c_active='Y' ";
            strCriteria = strCriteria + " and unit.director_code = '" + strDirector_code + "' ";
            if (this.BudgetType == "R")
            {
                strCriteria = strCriteria + " and unit.budget_type <> 'B' ";
            }
            else
            {
                strCriteria = strCriteria + " and unit.budget_type <> 'R' ";
            }
            if (oUnit.SP_SEL_UNIT(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboUnit.Items.Clear();
                cboUnit.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboUnit.Items.Add(new ListItem(dt.Rows[i]["unit_name"].ToString(), dt.Rows[i]["unit_code"].ToString()));
                }
                if (cboUnit.Items.FindByValue(strUnit_code) != null)
                {
                    cboUnit.SelectedIndex = -1;
                    cboUnit.Items.FindByValue(strUnit_code).Selected = true;
                }
            }
        }

        private void InitcboBudget()
        {
            cBudget oBudget = new cBudget();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strbudget_code = cboBudget.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_year = '" + strYear + "'  and  c_active='Y' ";
            strCriteria = strCriteria + "  And budget_type ='" + this.BudgetType + "' ";
            if (oBudget.SP_SEL_BUDGET(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboBudget.Items.Clear();
                cboBudget.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboBudget.Items.Add(new ListItem(dt.Rows[i]["budget_name"].ToString(), dt.Rows[i]["budget_code"].ToString()));
                }
                if (cboBudget.Items.FindByValue(strbudget_code) != null)
                {
                    cboBudget.SelectedIndex = -1;
                    cboBudget.Items.FindByValue(strbudget_code).Selected = true;
                }
            }
            InitcboProduce();
        }

        private void InitcboProduce()
        {
            cProduce oProduce = new cProduce();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty,
                        strproduce_name = string.Empty;
            string strYear = cboYear.SelectedValue;
            strbudget_code = cboBudget.SelectedValue;
            strproduce_code = cboProduce.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and  produce.c_active='Y' ";
            strCriteria = strCriteria + "  And produce.budget_type ='" + this.BudgetType + "' ";
            strCriteria = strCriteria + " and produce.budget_code= '" + strbudget_code + "' ";
            if (oProduce.SP_SEL_PRODUCE(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboProduce.Items.Clear();
                cboProduce.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboProduce.Items.Add(new ListItem(dt.Rows[i]["produce_name"].ToString(), dt.Rows[i]["produce_code"].ToString()));
                }
                if (cboProduce.Items.FindByValue(strproduce_code) != null)
                {
                    cboProduce.SelectedIndex = -1;
                    cboProduce.Items.FindByValue(strproduce_code).Selected = true;
                }
            }
            InitcboActivity();
        }

        private void InitcboActivity()
        {
            cActivity oActivity = new cActivity();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        stractivity_code = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty;
            stractivity_code = cboActivity.SelectedValue;
            strbudget_code = cboBudget.SelectedValue;
            strproduce_code = cboProduce.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  activity.c_active='Y' ";
            strCriteria = strCriteria + "  And activity.budget_type ='" + this.BudgetType + "' ";
            strCriteria = strCriteria + " and  produce.budget_code= '" + strbudget_code + "' ";
            strCriteria = strCriteria + " and activity.produce_code= '" + strproduce_code + "' ";


            if (oActivity.SP_SEL_ACTIVITY(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboActivity.Items.Clear();
                cboActivity.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboActivity.Items.Add(new ListItem(dt.Rows[i]["activity_name"].ToString(), dt.Rows[i]["activity_code"].ToString()));
                }
                if (cboActivity.Items.FindByValue(stractivity_code) != null)
                {
                    cboActivity.SelectedIndex = -1;
                    cboActivity.Items.FindByValue(stractivity_code).Selected = true;
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
            if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMajor.Items.Clear();
                cboMajor.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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

        private void InitcboBudgetType()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strCode = cboBudgetType.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " Select * from  general where g_type = 'budget_type'   Order by g_sort ";
            if (oCommon.SEL_SQL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboBudgetType.Items.Clear();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboBudgetType.Items.Add(new ListItem(dt.Rows[i]["g_name"].ToString(), dt.Rows[i]["g_code"].ToString()));
                }
                if (cboBudgetType.Items.FindByValue(strCode) != null)
                {
                    cboBudgetType.SelectedIndex = -1;
                    cboBudgetType.Items.FindByValue(strCode).Selected = true;
                }
            }
        }

        private void InitcboLot()
        {
            cLot oLot = new cLot();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = cboYear.SelectedValue;
            string strLot = cboLot.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and lot_year = '" + strYear + "'  and  c_active='Y' and budget_type='" + this.BudgetType + "' ";
            if (oLot.SP_SEL_LOT(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboLot.Items.Clear();
                cboLot.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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
            InitcboItem_group();
        }

        private void InitcboItem_group()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            var strYear = cboYear.SelectedValue; ;
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
                cboItem_group.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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
            InitcboItemGroupDetail();
        }

        private void InitcboItemGroupDetail()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = cboYear.SelectedValue;
            string strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            string strItem_group_code = cboItem_group.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' And Item_group_code ='" + strItem_group_code + "' ";
            if (oItem_group_detail.SP_ITEM_GROUP_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_detail.Items.Clear();
                cboItem_group_detail.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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
            InitcboItem();
        }

        private void InitcboItem()
        {
            cItem oItem = new cItem();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strItem_group_detail_id = string.Empty;
            string strYear = cboYear.SelectedValue;
            strItem_code = cboItem.SelectedValue;
            strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_year = '" + strYear + "'  and  c_active='Y' ";
            strCriteria += " and item_group_detail_id = '" + strItem_group_detail_id + "'  ";
            if (oItem.SP_ITEM_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem.Items.Clear();
                cboItem.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem.Items.Add(new ListItem(dt.Rows[i]["Item_name"].ToString(), dt.Rows[i]["Item_code"].ToString()));
                }
                if (cboItem.Items.FindByValue(strItem_code) != null)
                {
                    cboItem.SelectedIndex = -1;
                    cboItem.Items.FindByValue(strItem_code).Selected = true;
                }
            }
            InitcboItem_detail();
        }

        private void InitcboItem_detail()
        {
            cItem_detail oItem_detail = new cItem_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            var strItem_detail = cboItem_detail.SelectedValue;
            strItem_code = cboItem.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and item_year = '" + strYear + "'  and  c_active='Y' ";
            strCriteria += " and item_code = '" + strItem_code + "'  ";
            if (oItem_detail.SP_ITEM_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_detail.Items.Clear();
                cboItem_detail.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_detail.Items.Add(new ListItem(dt.Rows[i]["item_detail_name"].ToString(), dt.Rows[i]["item_detail_id"].ToString()));
                }
                if (cboItem_detail.Items.FindByValue(strItem_detail) != null)
                {
                    cboItem_detail.SelectedIndex = -1;
                    cboItem_detail.Items.FindByValue(strItem_detail).Selected = true;
                }
            }
        }

        #endregion

        protected void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboBudget();
        }

        protected void cboBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboProduce();
        }

        protected void cboProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboActivity();
        }

        protected void imgPrint_Click(object sender, ImageClickEventArgs e)
        {
            lnkExcelFile.Enabled = false;
            lnkPdfFile.Enabled = false;
            //lnkExcelFile.ImageUrl = "~/images/icon_exceldisable.gif";
            //lnkPdfFile.ImageUrl = "~/images/icon_pdfdisable.gif";
            var report_result_path = string.Empty;
            if (this.ReportCode == "007")
            {
                report_result_path = PrintData007();
            }
            if (!string.IsNullOrEmpty(report_result_path))
            {
                if (chkPdf.Checked)
                {
                    lnkPdfFile.NavigateUrl = "~/temp/" + report_result_path + ".pdf";
                    imgPdf.Src = "~/images/icon_pdf.gif";
                    lnkPdfFile.Enabled = true;
                }
                if (chkExcel.Checked)
                {
                    lnkExcelFile.NavigateUrl = "~/temp/" + report_result_path + ".xlsx";
                    imgExcel.Src = "~/images/icon_excel.gif";
                    lnkExcelFile.Enabled = true;
                }
            }
        }



        private string PrintData007()
        {
            var result = string.Empty;
            try
            {

                string strMessage = string.Empty;
                string strCriteria = string.Empty;
                string strCriteriaDesc = string.Empty;
                var view_budget_summary = new view_Budget_summary();
                string strScript = string.Empty;
                
                #region Criteria
                view_budget_summary.budget_money_year = cboYear.SelectedValue;
                view_budget_summary.budget_type = cboBudgetType.SelectedValue;
                view_budget_summary.degree_code = cboDegree.SelectedValue;
                view_budget_summary.budget_plan_code = txtbudget_plan_code.Text;
                view_budget_summary.unit_code = cboUnit.SelectedValue;
                view_budget_summary.budget_code = cboBudget.SelectedValue;
                view_budget_summary.produce_code = cboProduce.SelectedValue;
                view_budget_summary.activity_code = cboActivity.SelectedValue;
                view_budget_summary.major_code = cboMajor.SelectedValue;

                if (!string.IsNullOrEmpty(view_budget_summary.budget_money_year))
                {
                    strCriteria = strCriteria + "  And  (budget_money_year = '" + view_budget_summary.budget_money_year + "') ";
                    strCriteriaDesc += "ปีงบประมาณ : " + view_budget_summary.budget_money_year + "    ";
                }

                //if (!string.IsNullOrEmpty(txtdate_begin.Text))
                //{
                //    strCriteria = strCriteria + "  And  (budget_open_date >= '" + cCommon.SeekDate(txtdate_begin.Text) + "') ";
                //}

                //if (!string.IsNullOrEmpty(txtdate_end.Text))
                //{
                //    strCriteria = strCriteria + "  And  (budget_open_date <= '" + cCommon.SeekDate(txtdate_end.Text) + "') ";
                //}


                if (!string.IsNullOrEmpty(view_budget_summary.budget_type))
                {
                    strCriteria = strCriteria + "  And  (budget_type ='" + view_budget_summary.budget_type + "') ";
                    strCriteriaDesc += "ประเภทงบประมาณ : " + cboBudgetType.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.degree_code))
                {
                    strCriteria = strCriteria + "  And  (degree_code ='" + view_budget_summary.degree_code + "') ";
                    strCriteriaDesc += "ระดับการศึกษา : " + cboDegree.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.budget_plan_code))
                {
                    strCriteria = strCriteria + "  And  (budget_plan_code ='" + view_budget_summary.budget_plan_code + "') ";
                    strCriteriaDesc += "รหัสผังงบประมาณ : " + txtbudget_plan_code.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.unit_code))
                {
                    strCriteria = strCriteria + "  And  (unit_code ='" + view_budget_summary.unit_code + "') ";
                    strCriteriaDesc += "หน่วยงาน : " + cboUnit.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.budget_code))
                {
                    strCriteria = strCriteria + "  And  (budget_code ='" + view_budget_summary.budget_code + "') ";
                    strCriteriaDesc += "แผนงบประมาณ : " + cboBudget.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.produce_code))
                {
                    strCriteria = strCriteria + "  And  (produce_code ='" + view_budget_summary.produce_code + "') ";
                    strCriteriaDesc += "ผลผลิต : " + cboProduce.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.activity_code))
                {
                    strCriteria = strCriteria + "  And  (activity_code = '" + view_budget_summary.activity_code + "') ";
                    strCriteriaDesc += "กิจกรรม : " + cboActivity.SelectedItem.Text + "    ";
                }

                if (!string.IsNullOrEmpty(view_budget_summary.major_code))
                {
                    strCriteria = strCriteria + "  And  (major_code = '" + view_budget_summary.major_code + "') ";
                    strCriteriaDesc += "หลักสูตร : " + cboMajor.SelectedItem.Text + "    ";
                }

                if (DirectorLock == "Y")
                {
                    strCriteria += " and substring(director_code,4,2) = substring('" + DirectorCode + "',4,2) ";
                }

                #endregion

                var oGenerateReport = new GenerateReport();
                var strFilename = oGenerateReport.Retive_Rep_007(strCriteria, strCriteriaDesc, base.UserLoginName, chkPdf.Checked , chkExcel.Checked);
                result = strFilename;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return result;
        }

        private void SetUpControl()
        {
            if (ReportCode == "007")
            {
                pnlDate.Visible = false;
                pnlDocno.Visible = false;
                pnlItem.Visible = false;
                pnlApproveStatus.Visible = false;
            }
        }

        private void VisibleAllControl()
        {
            pnlYear.Visible = true;
            pnlDegree.Visible = true;
            pnlDate.Visible = true;
            pnlSearchDoc.Visible = true;
            pnlDocno.Visible = true;
            pnlBudgetplan.Visible = true;
            pnlBudget.Visible = true;
            pnlMajor.Visible = true;
            pnlItem.Visible = true;
            pnlExportOption.Visible = true;
            pnlApproveStatus.Visible = true;
        }

        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cboLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group();
        }

        protected void cboItem_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItemGroupDetail();
        }

        protected void cboItem_group_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem();
        }

        protected void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_detail();
        }

    }
}
