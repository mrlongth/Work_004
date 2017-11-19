using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using myModel;
using myDLL.Common;

namespace myWeb.App_Control.report
{
    public partial class main_transfer_report : PageBase
    {
        private string BudgetType
        {
            get
            {
                return cboBudgetType.SelectedValue;
            }
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            if (!IsPostBack)
            {

                InitcboYear();
                InitcboBudgetType();
                InitcboBudget_from();
                InitcboDegree_from();
                InitcboUnit_from();
                InitcboMajor_from();

                InitcboBudget_to();
                InitcboDegree_to();
                InitcboUnit_to();
                InitcboMajor_to();


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

        private void InitcboDegree_from()
        {
            cDegree oDegree = new cDegree();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strDegree_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            strDegree_code = cboDegree_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree_from.Items.Clear();
                cboDegree_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree_from.Items.Add(new ListItem(dt.Rows[i]["degree_name"].ToString(), dt.Rows[i]["degree_code"].ToString()));
                }
                if (cboDegree_from.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree_from.SelectedIndex = -1;
                    cboDegree_from.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }

        private void InitcboUnit_from()
        {
            cUnit oUnit = new cUnit();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strUnit_code = cboUnit_from.SelectedValue;
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
                cboUnit_from.Items.Clear();
                cboUnit_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboUnit_from.Items.Add(new ListItem(dt.Rows[i]["unit_name"].ToString(), dt.Rows[i]["unit_code"].ToString()));
                }
                if (cboUnit_from.Items.FindByValue(strUnit_code) != null)
                {
                    cboUnit_from.SelectedIndex = -1;
                    cboUnit_from.Items.FindByValue(strUnit_code).Selected = true;
                }
            }
        }

        private void InitcboBudget_from()
        {
            cBudget oBudget = new cBudget();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strbudget_code = cboBudget_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_year = '" + strYear + "'  and  c_active='Y' ";
            strCriteria = strCriteria + "  And budget_type ='" + this.BudgetType + "' ";
            if (oBudget.SP_SEL_BUDGET(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboBudget_from.Items.Clear();
                cboBudget_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboBudget_from.Items.Add(new ListItem(dt.Rows[i]["budget_name"].ToString(), dt.Rows[i]["budget_code"].ToString()));
                }
                if (cboBudget_from.Items.FindByValue(strbudget_code) != null)
                {
                    cboBudget_from.SelectedIndex = -1;
                    cboBudget_from.Items.FindByValue(strbudget_code).Selected = true;
                }
            }
            InitcboProduce_from();
        }

        private void InitcboProduce_from()
        {
            cProduce oProduce = new cProduce();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty,
                        strproduce_name = string.Empty;
            string strYear = cboYear.SelectedValue;
            strbudget_code = cboBudget_from.SelectedValue;
            strproduce_code = cboProduce_from.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and  produce.c_active='Y' ";
            strCriteria = strCriteria + "  And produce.budget_type ='" + this.BudgetType + "' ";

            //if (!strbudget_code.Equals(""))
            //{
            strCriteria = strCriteria + " and produce.budget_code= '" + strbudget_code + "' ";
            //}

            if (oProduce.SP_SEL_PRODUCE(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboProduce_from.Items.Clear();
                cboProduce_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboProduce_from.Items.Add(new ListItem(dt.Rows[i]["produce_name"].ToString(), dt.Rows[i]["produce_code"].ToString()));
                }
                if (cboProduce_from.Items.FindByValue(strproduce_code) != null)
                {
                    cboProduce_from.SelectedIndex = -1;
                    cboProduce_from.Items.FindByValue(strproduce_code).Selected = true;
                }
            }
            InitcboActivity_from();
        }

        private void InitcboActivity_from()
        {
            cActivity oActivity = new cActivity();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        stractivity_code = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty;
            stractivity_code = cboActivity_from.SelectedValue;
            strbudget_code = cboBudget_from.SelectedValue;
            strproduce_code = cboProduce_from.SelectedValue;
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
                cboActivity_from.Items.Clear();
                cboActivity_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboActivity_from.Items.Add(new ListItem(dt.Rows[i]["activity_name"].ToString(), dt.Rows[i]["activity_code"].ToString()));
                }
                if (cboActivity_from.Items.FindByValue(stractivity_code) != null)
                {
                    cboActivity_from.SelectedIndex = -1;
                    cboActivity_from.Items.FindByValue(stractivity_code).Selected = true;
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
            if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMajor_from.Items.Clear();
                cboMajor_from.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strDegree_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            strDegree_code = cboDegree_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  c_active='Y' ";
            if (oDegree.SP_DEGREE_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDegree_to.Items.Clear();
                cboDegree_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDegree_to.Items.Add(new ListItem(dt.Rows[i]["degree_name"].ToString(), dt.Rows[i]["degree_code"].ToString()));
                }
                if (cboDegree_to.Items.FindByValue(strDegree_code) != null)
                {
                    cboDegree_to.SelectedIndex = -1;
                    cboDegree_to.Items.FindByValue(strDegree_code).Selected = true;
                }
            }
        }

        private void InitcboUnit_to()
        {
            cUnit oUnit = new cUnit();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strUnit_code = cboUnit_to.SelectedValue;
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
                cboUnit_to.Items.Clear();
                cboUnit_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboUnit_to.Items.Add(new ListItem(dt.Rows[i]["unit_name"].ToString(), dt.Rows[i]["unit_code"].ToString()));
                }
                if (cboUnit_to.Items.FindByValue(strUnit_code) != null)
                {
                    cboUnit_to.SelectedIndex = -1;
                    cboUnit_to.Items.FindByValue(strUnit_code).Selected = true;
                }
            }
        }

        private void InitcboBudget_to()
        {
            cBudget oBudget = new cBudget();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = cboYear.SelectedValue;
            string strbudget_code = cboBudget_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_year = '" + strYear + "'  and  c_active='Y' ";
            strCriteria = strCriteria + "  And budget_type ='" + this.BudgetType + "' ";
            if (oBudget.SP_SEL_BUDGET(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboBudget_to.Items.Clear();
                cboBudget_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboBudget_to.Items.Add(new ListItem(dt.Rows[i]["budget_name"].ToString(), dt.Rows[i]["budget_code"].ToString()));
                }
                if (cboBudget_to.Items.FindByValue(strbudget_code) != null)
                {
                    cboBudget_to.SelectedIndex = -1;
                    cboBudget_to.Items.FindByValue(strbudget_code).Selected = true;
                }
            }
            InitcboProduce_to();
        }

        private void InitcboProduce_to()
        {
            cProduce oProduce = new cProduce();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty,
                        strproduce_name = string.Empty;
            string strYear = cboYear.SelectedValue;
            strbudget_code = cboBudget_to.SelectedValue;
            strproduce_code = cboProduce_to.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and  produce.c_active='Y' ";
            strCriteria = strCriteria + "  And produce.budget_type ='" + this.BudgetType + "' ";

            //if (!strbudget_code.Equals(""))
            //{
            strCriteria = strCriteria + " and produce.budget_code= '" + strbudget_code + "' ";
            //}

            if (oProduce.SP_SEL_PRODUCE(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboProduce_to.Items.Clear();
                cboProduce_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboProduce_to.Items.Add(new ListItem(dt.Rows[i]["produce_name"].ToString(), dt.Rows[i]["produce_code"].ToString()));
                }
                if (cboProduce_to.Items.FindByValue(strproduce_code) != null)
                {
                    cboProduce_to.SelectedIndex = -1;
                    cboProduce_to.Items.FindByValue(strproduce_code).Selected = true;
                }
            }
            InitcboActivity_to();
        }

        private void InitcboActivity_to()
        {
            cActivity oActivity = new cActivity();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        stractivity_code = string.Empty,
                        strbudget_code = string.Empty,
                        strproduce_code = string.Empty;
            stractivity_code = cboActivity_to.SelectedValue;
            strbudget_code = cboBudget_to.SelectedValue;
            strproduce_code = cboProduce_to.SelectedValue;
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
                cboActivity_to.Items.Clear();
                cboActivity_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboActivity_to.Items.Add(new ListItem(dt.Rows[i]["activity_name"].ToString(), dt.Rows[i]["activity_code"].ToString()));
                }
                if (cboActivity_to.Items.FindByValue(stractivity_code) != null)
                {
                    cboActivity_to.SelectedIndex = -1;
                    cboActivity_to.Items.FindByValue(stractivity_code).Selected = true;
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
            if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMajor_to.Items.Clear();
                cboMajor_to.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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


        #endregion

        private Report_param<view_Budget_transfer_report> GetCondition()
        {
            var result = new Report_param<view_Budget_transfer_report>
            {
                Report_condition = new view_Budget_transfer_report(),
                Report_criteria = string.Empty,
                Report_criteria_desc = string.Empty,
                Report_is_excel = chkExcel.Checked ,
                Report_is_pdf = chkPdf.Checked ,
                Report_user_print = base.UserLoginName
            };

            result.Report_condition.budget_transfer_year = cboYear.SelectedValue;
            result.Report_condition.budget_transfer_doc = txtbudget_plan_code_from.Text.Replace("'", "''").Trim();

            result.Report_condition.degree_code_from = cboDegree_from.SelectedValue;
            result.Report_condition.budget_plan_code_from = txtbudget_plan_code_from.Text;
            result.Report_condition.unit_code_from = cboUnit_from.SelectedValue;
            result.Report_condition.budget_code_from = cboBudget_from.SelectedValue;
            result.Report_condition.produce_code_from = cboProduce_from.SelectedValue;
            result.Report_condition.activity_code_from = cboActivity_from.SelectedValue;
            result.Report_condition.major_code_from = cboMajor_from.SelectedValue;

            result.Report_condition.degree_code_to = cboDegree_to.SelectedValue;
            result.Report_condition.budget_plan_code_to = txtbudget_plan_code_to.Text;
            result.Report_condition.unit_code_to = cboUnit_to.SelectedValue;
            result.Report_condition.budget_code_to = cboBudget_to.SelectedValue;
            result.Report_condition.produce_code_to = cboProduce_to.SelectedValue;
            result.Report_condition.activity_code_to = cboActivity_to.SelectedValue;
            result.Report_condition.major_code_to = cboMajor_to.SelectedValue;           
            result.Report_condition.budget_transfer_detail_is_impact = rdoImpact.SelectedValue;

            if (!string.IsNullOrEmpty(result.Report_condition.budget_transfer_year))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_transfer_year = '" + result.Report_condition.budget_transfer_year + "') ";
                result.Report_criteria_desc += "ปีงบประมาณ : " + result.Report_condition.budget_transfer_year + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.budget_transfer_doc))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_transfer_doc ='" + result.Report_condition.budget_transfer_doc + "') ";
                result.Report_criteria_desc += "เลขที่เอกสาร : " + result.Report_condition.budget_transfer_doc + "    ";
            }

            if (!string.IsNullOrEmpty(txtdate_begin.Text))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_transfer_date >= '" + cCommon.SeekDate(txtdate_begin.Text) + "') ";
                result.Report_criteria_desc += "ตั้งแต่วันที่ : " + txtdate_begin.Text + "    ";
            }

            if (!string.IsNullOrEmpty(txtdate_end.Text))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_transfer_date <= '" + cCommon.SeekDate(txtdate_end.Text) + "') ";
                result.Report_criteria_desc += "ถึงวันที่ : " + txtdate_end.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.degree_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (degree_code_from ='" + result.Report_condition.degree_code_from + "') ";
                result.Report_criteria_desc += "ระดับการศึกษาต้นทาง : " + cboDegree_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.budget_plan_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_plan_code_from ='" + result.Report_condition.budget_plan_code_from + "') ";
                result.Report_criteria_desc += "รหัสผังงบประมาณต้นทาง : " + txtbudget_plan_code_from.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.unit_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (unit_code_from ='" + result.Report_condition.unit_code_from + "') ";
                result.Report_criteria_desc += "หน่วยงานต้นทาง : " + cboUnit_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.budget_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_code_from ='" + result.Report_condition.budget_code_from + "') ";
                result.Report_criteria_desc += "แผนงบประมาณต้นทาง  : " + cboBudget_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.produce_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (produce_code_from ='" + result.Report_condition.produce_code_from + "') ";
                result.Report_criteria_desc += "ผลผลิตต้นทาง  : " + cboProduce_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.activity_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (activity_code_from = '" + result.Report_condition.activity_code_from + "') ";
                result.Report_criteria_desc += "กิจกรรมต้นทาง  : " + cboProduce_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.major_code_from))
            {
                result.Report_criteria = result.Report_criteria + "  And  (major_code_from = '" + result.Report_condition.major_code_from + "') ";
                result.Report_criteria_desc += "หลักสูตรต้นทาง  : " + cboProduce_from.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.degree_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (degree_code_to ='" + result.Report_condition.degree_code_to + "') ";
                result.Report_criteria_desc += "ระดับการศึกษาปลายทาง : " + cboDegree_to.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.budget_plan_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_plan_code_to ='" + result.Report_condition.budget_plan_code_to + "') ";
                result.Report_criteria_desc += "รหัสผังงบประมาณปลายทาง : " + txtbudget_plan_code_to.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.unit_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (unit_code_to ='" + result.Report_condition.unit_code_to + "') ";
                result.Report_criteria_desc += "หน่วยงานปลายทาง : " + cboUnit_to.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.budget_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_code_to ='" + result.Report_condition.budget_code_to + "') ";
                result.Report_criteria_desc += "แผนงบประมาณปลายทาง  : " + cboBudget_to.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.produce_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (produce_code_to ='" + result.Report_condition.produce_code_to + "') ";
                result.Report_criteria_desc += "ผลผลิตปลายทาง  : " + cboProduce_to.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.activity_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (activity_code_to = '" + result.Report_condition.activity_code_to + "') ";
                result.Report_criteria_desc += "กิจกรรมปลายทาง  : " + cboProduce_to.SelectedItem.Text + "    ";
            }

            if (!string.IsNullOrEmpty(result.Report_condition.major_code_to))
            {
                result.Report_criteria = result.Report_criteria + "  And  (major_code_to = '" + result.Report_condition.major_code_to + "') ";
                result.Report_criteria_desc += "หลักสูตรปลายทาง  : " + cboProduce_to.SelectedItem.Text + "    ";
            }

            if (result.Report_condition.budget_transfer_detail_is_impact != "A")
            {
                result.Report_criteria = result.Report_criteria + "  And  (budget_transfer_detail_is_impact = '" + result.Report_condition.budget_transfer_detail_is_impact + "') ";
                result.Report_criteria_desc += "ผลการโอน  : " + rdoImpact.SelectedItem.Text + "    ";
            }

            if (DirectorLock == "Y")
            {
                result.Report_criteria += " and substring(director_code_from,4,2) = substring('" + DirectorCode + "',4,2) ";
                result.Report_criteria += " and substring(director_code_to,4,2) = substring('" + DirectorCode + "',4,2) ";
            }

            result.Report_criteria = result.Report_criteria + " and budget_type ='" + this.BudgetType + "' ";

            return result;
        }

        private string PrintData001()
        {
            var result = string.Empty;
            try
            {
                var report_condition = GetCondition();
                var oGenerateReport = new GenerateReport<view_Budget_transfer_report>();
                var strFilename = oGenerateReport.Retive_Rep_001(report_condition);
                result = strFilename;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return result;

        }

        private string PrintData002()
        {
            var result = string.Empty;
            try
            {
                var report_condition = GetCondition();
                var oGenerateReport = new GenerateReport<view_Budget_transfer_report>();
                var strFilename = oGenerateReport.Retive_Rep_002(report_condition);
                result = strFilename;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return result;
        }

        private string PrintData003()
        {
            var result = string.Empty;
            try
            {
                var report_condition = GetCondition();
                var oGenerateReport = new GenerateReport<view_Budget_transfer_report>();
                var strFilename = oGenerateReport.Retive_Rep_003(report_condition);
                result = strFilename;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            return result;
        }


        protected void cboBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboProduce_from();
        }

        protected void cboProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboActivity_from();
        }

        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void cboBudget_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboProduce_to();
        }

        protected void cboProduce_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboActivity_to();
        }

        protected void imgPrint_Click(object sender, ImageClickEventArgs e)
        {
            lnkExcelFile.Enabled = false;
            lnkPdfFile.Enabled = false;
            lnkExcelFile.ImageUrl = "~/images/icon_exceldisable.gif";
            lnkPdfFile.ImageUrl = "~/images/icon_pdfdisable.gif";
            var report_result_path = string.Empty;
            if (this.ReportCode == "001")
            {
                report_result_path = PrintData001();
            }
            else if (this.ReportCode == "002")
            {
                report_result_path = PrintData002();
            }
            else if (this.ReportCode == "003")
            {
                report_result_path = PrintData003();
            }
            if (!string.IsNullOrEmpty(report_result_path))
            {
                if (chkPdf.Checked)
                {
                    lnkPdfFile.Enabled = true;
                    lnkPdfFile.NavigateUrl = "~/temp/" + report_result_path + ".pdf";
                    lnkPdfFile.ImageUrl = "~/images/icon_pdf.gif";
                }
                if (chkExcel.Checked)
                {
                    lnkExcelFile.Enabled = true;
                    lnkExcelFile.NavigateUrl = "~/temp/" + report_result_path + ".xls";
                    lnkExcelFile.ImageUrl = "~/images/icon_excel.gif";
                }
            }
        }
    }
}
