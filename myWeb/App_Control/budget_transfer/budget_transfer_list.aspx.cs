using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using myModel;

namespace myWeb.App_Control.budget_transfer
{
    public partial class budget_transfer_list : PageBase
    {

        #region private data
        private string strRecordPerPage;
        private string strPageNo = "1";

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            if (!IsPostBack)
            {
                imgNew.Attributes.Add("onMouseOver", "src='../../images/button/save2.png'");
                imgNew.Attributes.Add("onMouseOut", "src='../../images/button/save.png'");
                imgNew.Visible = base.IsUserNew;

                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                ViewState["sort"] = "budget_transfer_doc";
                ViewState["direction"] = "ASC";
                InitcboYear();

                InitcboBudget_from();
                InitcboDegree_from();
                InitcboUnit_from();
                InitcboMajor_from();

                InitcboBudget_to();
                InitcboDegree_to();
                InitcboUnit_to();
                InitcboMajor_to();

                //txtdate_begin.Text = cCommon.CheckDate(DateTime.Now.ToShortDateString());

                BindGridView(0);

            }
            else
            {
                if (Request.Form["ctl00$ContentPlaceHolder2$GridView1$ctl01$cboPerPage"] != null)
                {
                    strRecordPerPage = Request.Form["ctl00$ContentPlaceHolder2$GridView1$ctl01$cboPerPage"].ToString();
                    strPageNo = Request.Form["ctl00$ContentPlaceHolder2$GridView1$ctl01$txtPage"].ToString();
                }
                if (txthpage.Value != string.Empty)
                {
                    BindGridView(int.Parse(txthpage.Value));
                    txthpage.Value = string.Empty;
                }
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
            if (MajorLock == "Y")
            {
                strCriteria += " and major_code = '" + PersonMajorCode + "' ";
            }

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
            if (MajorLock == "Y")
            {
                strCriteria += " and major_code = '" + PersonMajorCode + "' ";
            }

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


        #endregion

        private void cboPerPage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GridView1.PageSize = int.Parse(strRecordPerPage);
            BindGridView(0);
        }

        private void imgGo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            BindGridView(int.Parse(strPageNo) - 1);
        }

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView(0);
        }

        private void BindGridView(int nPageNo)
        {
            var oBudget_transfer = new cBudget_transfer();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            var budget_transfer_head = new view_Budget_transfer_head();
            string strScript = string.Empty;
            #region Criteria
            budget_transfer_head.budget_transfer_year = cboYear.SelectedValue;
            budget_transfer_head.budget_transfer_doc = txtbudget_plan_code_from.Text.Replace("'", "''").Trim();

            budget_transfer_head.degree_code_from = cboDegree_from.SelectedValue;
            budget_transfer_head.budget_plan_code_from = txtbudget_plan_code_from.Text;
            budget_transfer_head.unit_code_from = cboUnit_from.SelectedValue;
            budget_transfer_head.budget_code_from = cboBudget_from.SelectedValue;
            budget_transfer_head.produce_code_from = cboProduce_from.SelectedValue;
            budget_transfer_head.activity_code_from = cboActivity_from.SelectedValue;
            budget_transfer_head.major_code_from = cboMajor_from.SelectedValue;

            budget_transfer_head.degree_code_to = cboDegree_to.SelectedValue;
            budget_transfer_head.budget_plan_code_to = txtbudget_plan_code_to.Text;
            budget_transfer_head.unit_code_to = cboUnit_to.SelectedValue;
            budget_transfer_head.budget_code_to = cboBudget_to.SelectedValue;
            budget_transfer_head.produce_code_to = cboProduce_to.SelectedValue;
            budget_transfer_head.activity_code_to = cboActivity_to.SelectedValue;
            budget_transfer_head.major_code_to = cboMajor_to.SelectedValue;


            if (!string.IsNullOrEmpty(budget_transfer_head.budget_transfer_year))
            {
                strCriteria = strCriteria + "  And  (budget_transfer_year = '" + budget_transfer_head.budget_transfer_year + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.budget_transfer_doc))
            {
                strCriteria = strCriteria + "  And  (budget_transfer_doc ='" + budget_transfer_head.budget_transfer_doc + "') ";
            }

            if (!string.IsNullOrEmpty(txtdate_begin.Text))
            {
                strCriteria = strCriteria + "  And  (budget_transfer_date >= '" + cCommon.SeekDate(txtdate_begin.Text) + "') ";
            }

            if (!string.IsNullOrEmpty(txtdate_end.Text))
            {
                strCriteria = strCriteria + "  And  (budget_transfer_date <= '" + cCommon.SeekDate(txtdate_end.Text) + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.degree_code_from))
            {
                strCriteria = strCriteria + "  And  (degree_code_from ='" + budget_transfer_head.degree_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.budget_plan_code_from))
            {
                strCriteria = strCriteria + "  And  (budget_plan_code_from ='" + budget_transfer_head.budget_plan_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.unit_code_from))
            {
                strCriteria = strCriteria + "  And  (unit_code_from ='" + budget_transfer_head.unit_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.budget_code_from))
            {
                strCriteria = strCriteria + "  And  (budget_code_from ='" + budget_transfer_head.budget_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.produce_code_from))
            {
                strCriteria = strCriteria + "  And  (produce_code_from ='" + budget_transfer_head.produce_code_from + "') ";
            }          

            if (!string.IsNullOrEmpty(budget_transfer_head.activity_code_from))
            {
                strCriteria = strCriteria + "  And  (activity_code_from = '" + budget_transfer_head.activity_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.major_code_from))
            {
                strCriteria = strCriteria + "  And  (major_code_from = '" + budget_transfer_head.major_code_from + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.degree_code_to))
            {
                strCriteria = strCriteria + "  And  (degree_code_to ='" + budget_transfer_head.degree_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.budget_plan_code_to))
            {
                strCriteria = strCriteria + "  And  (budget_plan_code_to ='" + budget_transfer_head.budget_plan_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.unit_code_to))
            {
                strCriteria = strCriteria + "  And  (unit_code_to ='" + budget_transfer_head.unit_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.budget_code_to))
            {
                strCriteria = strCriteria + "  And  (budget_code_to ='" + budget_transfer_head.budget_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.produce_code_to))
            {
                strCriteria = strCriteria + "  And  (produce_code_to ='" + budget_transfer_head.produce_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.activity_code_to))
            {
                strCriteria = strCriteria + "  And  (activity_code_to = '" + budget_transfer_head.activity_code_to + "') ";
            }

            if (!string.IsNullOrEmpty(budget_transfer_head.major_code_to))
            {
                strCriteria = strCriteria + "  And  (major_code_to = '" + budget_transfer_head.major_code_to + "') ";
            }

            if (DirectorLock == "Y")
            {
                strCriteria += " and substring(director_code_from,4,2) = substring('" + DirectorCode + "',4,2) ";
                strCriteria += " and substring(director_code_to,4,2) = substring('" + DirectorCode + "',4,2) ";
            }

            #endregion

            strCriteria = strCriteria + " and budget_type ='" + this.BudgetType + "' ";

            try
            {
                if (!oBudget_transfer.SP_BUDGET_TRANSFER_HEAD_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    try
                    {
                        GridView1.PageIndex = nPageNo;
                        txthTotalRecord.Value = ds.Tables[0].Rows.Count.ToString();
                        ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                    catch
                    {
                        GridView1.PageIndex = 0;
                        txthTotalRecord.Value = ds.Tables[0].Rows.Count.ToString();
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
                oBudget_transfer.Dispose();
                ds.Dispose();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.TopPagerRow.Visible = true;
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
                Label lblbudget_transfer_doc = (Label)e.Row.FindControl("lblbudget_transfer_doc");
           


                #region set ImageView
                ImageButton imgView = (ImageButton)e.Row.FindControl("imgView");
                //imgView.Attributes.Add("onclick", "OpenPopUp('950px','350px','94%','แสดงข้อมูลผังงบประมาณ','budget_transfer_view.aspx?mode=view&budget_plan_code=" +
                //                                                lblbudget_transfer_doc.Text + "','1');return false;");
                imgView.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["img"].ToString();
                imgView.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["title"].ToString());
                #endregion

                #region set Image Edit & Delete
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                //Label lblCanEdit = (Label)e.Row.FindControl("lblCanEdit");
                //imgEdit.Attributes.Add("onclick", "OpenPopUp('900px','350px','90%','แก้ไข" + base.PageDes + "','budget_transfer_control.aspx?budget_type=" + this.BudgetType + "&mode=edit&budget_plan_code="
                //                                            + lblbudget_transfer_doc.Text + "&page=" + GridView1.PageIndex.ToString() + "&canEdit=Y','1');return false;");
                imgEdit.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["img"].ToString();
                imgEdit.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["title"].ToString());

                ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบข้อมูล  : " + lblbudget_transfer_doc.Text + " หรือไม่ ?\");");
                #endregion


                #region check user can edit/delete
                imgEdit.Visible = base.IsUserEdit;
                imgDelete.Visible = base.IsUserDelete;
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
            else if (e.Row.RowType.Equals(DataControlRowType.Pager))
            {
                TableCell tbc = e.Row.Cells[0];
                Label lblPrev = null;
                Label lblNext = null;
                ImageButton lbtnPrev = null;
                ImageButton lbtnNext = null;

                #region find and store Previous and Next Page
                TableRow tbr = (TableRow)tbc.Controls[0].Controls[0];
                foreach (System.Web.UI.Control c in tbr.Controls)
                {
                    if (c.GetType().ToString().Equals("System.Web.UI.WebControls.Label"))
                    {
                        Label lbl = (Label)c;
                        if (lbl.Text.IndexOf("P") != -1)
                        {
                            lblPrev = lbl;
                            lblPrev.Text = string.Empty;
                        }
                        if (lbl.Text.IndexOf("N") != -1)
                        {
                            lblNext = lbl;
                            lblNext.Text = string.Empty;
                        }
                    }
                    if (c.Controls[0].GetType().ToString().Equals("System.Web.UI.WebControls.DataControlImageButton"))
                    {
                        ImageButton lbtn = (ImageButton)c.Controls[0];
                        if (lbtn.AlternateText.IndexOf("P") != -1)
                        {
                            lbtnPrev = lbtn;
                            lbtnPrev.ImageUrl = "~/images/prev.gif";
                        }
                        if (lbtn.AlternateText.IndexOf("N") != -1)
                        {
                            lbtnNext = lbtn;
                            lbtnNext.ImageUrl = "~/images/next.gif";
                        }
                    }
                }
                #endregion

                #region render new pager
                tbc.Text = string.Empty;
                Literal lblPager = new Literal();
                lblPager.Text = "<TABLE border='0' width='100%' cellpadding='0' cellspacing='0'><TR><TD width='30%' valign='middle'>";
                tbc.Controls.Add(lblPager);

                Label lblTotalRecord = new Label();
                lblTotalRecord.Attributes.Add("class", "label_h");
                lblTotalRecord.Text = "พบข้อมูล " + txthTotalRecord.Value.ToString() + " รายการ.";
                tbc.Controls.Add(lblTotalRecord);

                lblPager = new Literal();
                lblPager.Text = "</TD><TD width='30%' align='center' valign='middle'>";
                tbc.Controls.Add(lblPager);

                DropDownList cboPerPage = new DropDownList();
                cboPerPage.ID = "cboPerPage";

                DataTable entries;
                if ((DataSet)Application["xmlconfig"] == null)
                    return;
                else
                    entries = ((DataSet)Application["xmlconfig"]).Tables["RecordPerPage"];

                for (int i = 0; i < entries.Rows.Count; i++)
                {
                    cboPerPage.Items.Add(new ListItem(entries.Rows[i][0].ToString(), entries.Rows[i][1].ToString()));
                }

                if (cboPerPage.Items.FindByValue(strRecordPerPage) != null)
                {
                    cboPerPage.Items.FindByValue(strRecordPerPage).Selected = true;
                }

                cboPerPage.AutoPostBack = true;
                cboPerPage.SelectedIndexChanged += new System.EventHandler(cboPerPage_SelectedIndexChanged);
                tbc.Controls.Add(cboPerPage);

                lblPager = new Literal();
                lblPager.Text = "&nbsp;&nbsp;&nbsp;<span class=\"label_h\">รายการ/หน้า</span></TD><TD width='40%' align='right' valign='middle'>";
                tbc.Controls.Add(lblPager);

                if (lblPrev != null)
                {
                    tbc.Controls.Add(lblPrev);
                }
                else if (lbtnPrev != null)
                {
                    tbc.Controls.Add(lbtnPrev);
                }

                lblPager = new Literal();
                lblPager.Text = "&nbsp;&nbsp;&nbsp;<span class=\"label_h\">หน้าที่: </span>";
                tbc.Controls.Add(lblPager);

                TextBox txtPage = new TextBox();
                txtPage.AutoPostBack = false;
                txtPage.ID = "txtPage";
                txtPage.Width = System.Web.UI.WebControls.Unit.Parse("30px");
                txtPage.Attributes.Add("class", "text1");
                txtPage.Style.Add("text-align", "right");
                int nCurrentPage = (GridView1.PageIndex + 1);
                txtPage.Text = nCurrentPage.ToString();//strPageNo;
                txtPage.Attributes.Add("onkeypress", "javascript: return checkKeyCode(event);");
                txtPage.Attributes.Add("onkeyup", "javasctipt: checkInt(this, " + GridView1.PageCount.ToString() + ");");
                tbc.Controls.Add(txtPage);

                lblPager = new Literal();
                lblPager.Text = "<span class=\"label_h\"> จากทั้งหมด " + GridView1.PageCount.ToString() + "&nbsp;&nbsp;</span>";
                tbc.Controls.Add(lblPager);

                lblPager = new Literal();
                lblPager.Text = "&nbsp;&nbsp;";
                tbc.Controls.Add(lblPager);

                ImageButton imgGo = new ImageButton();
                imgGo.ID = "imgGo";
                imgGo.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgGo"].Rows[0]["img"].ToString();
                imgGo.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgGo"].Rows[0]["title"].ToString());
                imgGo.Attributes.Add("onclick", "javascript: return checkPage(" + GridView1.PageCount.ToString() + ",'กรุณาระบุข้อมูลให้ถูกต้อง.|||ctl00$ContentPlaceHolder2$GridView1$ctl01$txtPage');");
                imgGo.Click += new System.Web.UI.ImageClickEventHandler(this.imgGo_Click);
                tbc.Controls.Add(imgGo);

                lblPager = new Literal();
                lblPager.Text = "&nbsp;&nbsp;&nbsp;";
                tbc.Controls.Add(lblPager);

                if (lblNext != null)
                {
                    tbc.Controls.Add(lblNext);
                }
                else if (lbtnNext != null)
                {
                    tbc.Controls.Add(lbtnNext);
                }

                lblPager = new Literal();
                lblPager.Text = "</TD></TR></TABLE>";
                tbc.Controls.Add(lblPager);

                #endregion
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGridView(e.NewPageIndex);
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
                GridViewRow item = (GridViewRow)GridView1.Controls[0].Controls[0];
                TextBox txtPage = (TextBox)item.FindControl("txtPage");
                BindGridView(int.Parse(txtPage.Text) - 1);
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
            Label lblbudget_transfer_doc = (Label)GridView1.Rows[e.RowIndex].FindControl("lblbudget_transfer_doc");
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            try
            {
                oBudget_transfer.SP_BUDGET_TRANSFER_HEAD_DEL(lblbudget_transfer_doc.Text);
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
            BindGridView(0);
        }


        protected void cboBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboProduce_from();
            BindGridView(1);
        }

        protected void cboProduce_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboActivity_from();
            BindGridView(1);

        }

        protected void cboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(1);
        }

        protected void cboPlan_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            // InitcboPlan();
            BindGridView(1);
        }

        protected void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(1);
            //  InitcboUnit();
        }

        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow;
            Label lblbudget_transfer_doc = null;
            if (!e.CommandName.ToUpper().Equals("SORT"))
            {
                gvRow = GridView1.Rows[Helper.CInt(e.CommandArgument) - 1];
                lblbudget_transfer_doc = (Label)gvRow.FindControl("lblbudget_transfer_doc");
            }
            switch (e.CommandName.ToUpper())
            {
                case "VIEW":
                    Response.Redirect(string.Format("~/App_Control/budget_transfer/budget_transfer_control.aspx?mode=view&budget_transfer_doc={0}&budget_type={1}", lblbudget_transfer_doc.Text, this.myBudgetType));
                    break;
                case "EDIT":
                    Response.Redirect(string.Format("~/App_Control/budget_transfer/budget_transfer_control.aspx?mode=edit&budget_transfer_doc={0}&budget_type={1}", lblbudget_transfer_doc.Text, this.myBudgetType));
                    break;
                case "SORT":

                    break;
                default:
                    break;
            }
        }

        protected void imgNew_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(string.Format("~/App_Control/budget_transfer/budget_transfer_control.aspx?mode=add&budget_type={0}", this.myBudgetType));
        }



        protected void cboUnit_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(1);
        }

        protected void cboBudget_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboProduce_to();
            BindGridView(1);
        }

        protected void cboProduce_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboActivity_to();
            BindGridView(1);
        }

        protected void cboActivity_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(1);
        }

        protected void cboMajor_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(1);
        }
    }
}
