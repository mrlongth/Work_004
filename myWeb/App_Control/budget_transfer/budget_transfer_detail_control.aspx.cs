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

namespace myWeb.App_Control.budget_transfer
{
    public partial class budget_transfer_detail_control : PageBase
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

        private string BudgetYear
        {
            get
            {
                if (ViewState["BudgetYear"] == null)
                {
                    ViewState["BudgetYear"] = Helper.CStr(Request.QueryString["year"]);
                }
                return ViewState["BudgetYear"].ToString();
            }
            set
            {
                ViewState["BudgetYear"] = value;
            }
        }

        private string BudgetTransferDoc
        {
            get
            {
                if (ViewState["BudgetTransferDoc"] == null)
                {
                    ViewState["BudgetTransferDoc"] = Helper.CStr(Request.QueryString["budget_transfer_doc"]);
                }
                return ViewState["BudgetTransferDoc"].ToString();
            }
            set
            {
                ViewState["BudgetTransferDoc"] = value;
            }
        }

        private long BudgetTransferDetailId
        {
            get
            {
                if (ViewState["BudgetTransferDetailId"] == null)
                {
                    ViewState["BudgetTransferDetailId"] = "0";
                    if (ViewState["budget_transfer_detail_id"] != null)
                    {
                        ViewState["BudgetTransferDetailId"] = Helper.CStr(ViewState["budget_transfer_detail_id"]);
                    }
                }
                return long.Parse(ViewState["BudgetTransferDetailId"].ToString());
            }
            set
            {
                ViewState["BudgetTransferDetailId"] = value;
            }
        }

        private view_Budget_transfer_head MyBudgetTransferHead
        {
            get
            {
                if (ViewState["MyBudgetTransferHead"] == null)
                {
                    ViewState["MyBudgetTransferHead"] = new view_Budget_transfer_head();
                }
                return (view_Budget_transfer_head)ViewState["MyBudgetTransferHead"];
            }
            set
            {
                ViewState["MyBudgetTransferHead"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");
                #region set QueryString

                if (Request.QueryString["budget_transfer_detail_id"] != null)
                {
                    ViewState["budget_transfer_detail_id"] = Request.QueryString["budget_transfer_detail_id"].ToString();
                }

                if (Request.QueryString["mode"] != null)
                {
                    ViewState["mode"] = Request.QueryString["mode"].ToString();
                }

                SetBudgetTransferData();

                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    InitcboLot_from();
                    InitcboLot_to();
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    Utils.SetControls(pnlControl, myDLL.Common.Enumeration.Mode.VIEW);
                }

                #endregion
            }

            if (ViewState["mode"].ToString().ToLower().Equals("view"))
            {
                Utils.SetControls(pnlContent, myDLL.Common.Enumeration.Mode.VIEW);
            }

        }

        #region private function

        private void SetBudgetTransferData()
        {
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_transfer_doc = '" + this.BudgetTransferDoc + "' ";
                this.MyBudgetTransferHead = oBudget_transfer.GET(strCriteria);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }


        private void InitcboLot_from()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strLot = cboLot_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                          " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                          " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                          " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' ";
            var strSql = " select lot_code , lot_name from view_Budget_money_major " +
                         " where 1=1 " + strCriteria +
                         " group by lot_code , lot_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboLot_from.Items.Clear();
                cboLot_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboLot_from.Items.Add(new ListItem(dt.Rows[i]["lot_name"].ToString(), dt.Rows[i]["lot_code"].ToString()));
                }
                if (cboLot_from.Items.FindByValue(strLot) != null)
                {
                    cboLot_from.SelectedIndex = -1;
                    cboLot_from.Items.FindByValue(strLot).Selected = true;
                }
            }
            InitcboItem_group_from();
        }

        private void InitcboItem_group_from()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            strItem_group_code = cboItem_group_from.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                          " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                          " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                          " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' " +
                          " and lot_code = '" + cboLot_from.SelectedValue + "' ";
            var strSql = " select Item_group_code , Item_group_name  from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by Item_group_code , Item_group_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_from.Items.Clear();
                cboItem_group_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_from.Items.Add(new ListItem(dt.Rows[i]["Item_group_name"].ToString(), dt.Rows[i]["Item_group_code"].ToString()));
                }
                if (cboItem_group_from.Items.FindByValue(strItem_group_code) != null)
                {
                    cboItem_group_from.SelectedIndex = -1;
                    cboItem_group_from.Items.FindByValue(strItem_group_code).Selected = true;
                }
            }
            InitcboItemGroupDetail_from();
        }

        private void InitcboItemGroupDetail_from()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = BudgetYear;
            string strItem_group_detail_id = cboItem_group_detail_from.SelectedValue;
            string strItem_group_code = cboItem_group_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' " +
                            " and Item_group_code = '" + strItem_group_code + "' ";
            var strSql = " select Item_group_detail_id , Item_group_detail_name  from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by Item_group_detail_id , Item_group_detail_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_detail_from.Items.Clear();
                cboItem_group_detail_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_detail_from.Items.Add(new ListItem(dt.Rows[i]["Item_group_detail_name"].ToString(), dt.Rows[i]["Item_group_detail_id"].ToString()));
                }
                if (cboItem_group_detail_from.Items.FindByValue(strItem_group_detail_id) != null)
                {
                    cboItem_group_detail_from.SelectedIndex = -1;
                    cboItem_group_detail_from.Items.FindByValue(strItem_group_detail_id).Selected = true;
                }
            }
            InitcboItem_from();
        }

        private void InitcboItem_from()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strItem_group_detail_id = string.Empty;
            string strYear = BudgetYear;
            strItem_code = cboItem_from.SelectedValue;
            strItem_group_detail_id = cboItem_group_detail_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' " +
                            " and item_group_detail_id = '" + strItem_group_detail_id + "' ";
            var strSql = " select item_code ,item_name from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by item_code ,item_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_from.Items.Clear();
                cboItem_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_from.Items.Add(new ListItem(dt.Rows[i]["Item_name"].ToString(), dt.Rows[i]["Item_code"].ToString()));
                }
                if (cboItem_from.Items.FindByValue(strItem_code) != null)
                {
                    cboItem_from.SelectedIndex = -1;
                    cboItem_from.Items.FindByValue(strItem_code).Selected = true;
                }
            }
            InitcboItem_detail_from();
        }

        private void InitcboItem_detail_from()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strYear = BudgetYear;
            var strItem_detail = cboItem_detail_from.SelectedValue;
            strItem_code = cboItem_from.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' " +
                            " and item_code = '" + strItem_code + "' ";
            var strSql = " select item_detail_id, item_detail_name from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by item_detail_id, item_detail_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_detail_from.Items.Clear();
                cboItem_detail_from.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_detail_from.Items.Add(new ListItem(dt.Rows[i]["item_detail_name"].ToString(), dt.Rows[i]["item_detail_id"].ToString()));
                }
                if (cboItem_detail_from.Items.FindByValue(strItem_detail) != null)
                {
                    cboItem_detail_from.SelectedIndex = -1;
                    cboItem_detail_from.Items.FindByValue(strItem_detail).Selected = true;
                }
            }
            SetBudgetMoneyMajor_from();
        }

        private void SetBudgetMoneyMajor_from()
        {
            cBudget_money oBudget_money = new cBudget_money();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                              " and degree_code = '" + MyBudgetTransferHead.degree_code_from + "' " +
                              " and major_code = '" + MyBudgetTransferHead.major_code_from + "' " +
                              " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_from + "' " +
                              " and item_detail_id = '" + cboItem_detail_from.SelectedValue + "' ";
                var item = oBudget_money.GETMAJOR(strCriteria);
                hddbudget_money_major_id_from.Value = string.Empty;
                if (item != null)
                {
                    hddbudget_money_major_id_from.Value = item.budget_money_major_id.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

        private void InitcboLot_to()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strLot = cboLot_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                          " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                          " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                          " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' ";
            var strSql = " select lot_code , lot_name from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by lot_code , lot_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboLot_to.Items.Clear();
                cboLot_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboLot_to.Items.Add(new ListItem(dt.Rows[i]["lot_name"].ToString(), dt.Rows[i]["lot_code"].ToString()));
                }
                if (cboLot_to.Items.FindByValue(strLot) != null)
                {
                    cboLot_to.SelectedIndex = -1;
                    cboLot_to.Items.FindByValue(strLot).Selected = true;
                }
            }
            InitcboItem_group_to();
        }

        private void InitcboItem_group_to()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            strItem_group_code = cboItem_group_to.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                          " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                          " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                          " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' " +
                          " and lot_code = '" + cboLot_to.SelectedValue + "' ";
            var strSql = " select Item_group_code , Item_group_name  from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by Item_group_code , Item_group_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_to.Items.Clear();
                cboItem_group_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_to.Items.Add(new ListItem(dt.Rows[i]["Item_group_name"].ToString(), dt.Rows[i]["Item_group_code"].ToString()));
                }
                if (cboItem_group_to.Items.FindByValue(strItem_group_code) != null)
                {
                    cboItem_group_to.SelectedIndex = -1;
                    cboItem_group_to.Items.FindByValue(strItem_group_code).Selected = true;
                }
            }
            InitcboItemGroupDetail_to();
        }

        private void InitcboItemGroupDetail_to()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = BudgetYear;
            string strItem_group_detail_id = cboItem_group_detail_to.SelectedValue;
            string strItem_group_code = cboItem_group_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' " +
                            " and Item_group_code = '" + strItem_group_code + "' ";
            var strSql = " select Item_group_detail_id , Item_group_detail_name  from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by Item_group_detail_id , Item_group_detail_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_detail_to.Items.Clear();
                cboItem_group_detail_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_detail_to.Items.Add(new ListItem(dt.Rows[i]["Item_group_detail_name"].ToString(), dt.Rows[i]["Item_group_detail_id"].ToString()));
                }
                if (cboItem_group_detail_to.Items.FindByValue(strItem_group_detail_id) != null)
                {
                    cboItem_group_detail_to.SelectedIndex = -1;
                    cboItem_group_detail_to.Items.FindByValue(strItem_group_detail_id).Selected = true;
                }
            }
            InitcboItem_to();
        }

        private void InitcboItem_to()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strItem_group_detail_id = string.Empty;
            string strYear = BudgetYear;
            strItem_code = cboItem_to.SelectedValue;
            strItem_group_detail_id = cboItem_group_detail_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' " +
                            " and item_group_detail_id = '" + strItem_group_detail_id + "' ";
            var strSql = " select item_code ,item_name from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by item_code ,item_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_to.Items.Clear();
                cboItem_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_to.Items.Add(new ListItem(dt.Rows[i]["Item_name"].ToString(), dt.Rows[i]["Item_code"].ToString()));
                }
                if (cboItem_to.Items.FindByValue(strItem_code) != null)
                {
                    cboItem_to.SelectedIndex = -1;
                    cboItem_to.Items.FindByValue(strItem_code).Selected = true;
                }
            }
            InitcboItem_detail_to();
        }

        private void InitcboItem_detail_to()
        {
            cCommon oCommon = new cCommon();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strYear = BudgetYear;
            var strItem_detail = cboItem_detail_to.SelectedValue;
            strItem_code = cboItem_to.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                            " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                            " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                            " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' " +
                            " and item_code = '" + strItem_code + "' ";
            var strSql = " select item_detail_id, item_detail_name from view_Budget_money_major " +
                          " where 1=1 " + strCriteria +
                         " group by item_detail_id, item_detail_name ";
            if (oCommon.SEL_SQL(strSql, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_detail_to.Items.Clear();
                cboItem_detail_to.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_detail_to.Items.Add(new ListItem(dt.Rows[i]["item_detail_name"].ToString(), dt.Rows[i]["item_detail_id"].ToString()));
                }
                if (cboItem_detail_to.Items.FindByValue(strItem_detail) != null)
                {
                    cboItem_detail_to.SelectedIndex = -1;
                    cboItem_detail_to.Items.FindByValue(strItem_detail).Selected = true;
                }
            }
            SetBudgetMoneyMajor_to();
        }

        private void SetBudgetMoneyMajor_to()
        {
            cBudget_money oBudget_money = new cBudget_money();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_money_year = '" + BudgetYear + "' and budget_type='" + this.BudgetType + "' " +
                              " and degree_code = '" + MyBudgetTransferHead.degree_code_to + "' " +
                              " and major_code = '" + MyBudgetTransferHead.major_code_to + "' " +
                              " and budget_plan_code = '" + MyBudgetTransferHead.budget_plan_code_to + "' " +
                              " and item_detail_id = '" + cboItem_detail_to.SelectedValue + "' ";
                var item = oBudget_money.GETMAJOR(strCriteria);
                hddbudget_money_major_id_to.Value = string.Empty;
                if (item != null)
                {
                    hddbudget_money_major_id_to.Value = item.budget_money_major_id.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
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
                MsgBox("บันทึกข้อมูลสมบูรณ์");
                var script = "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');" +
                              "ClosePopUp('1');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", script, true);
            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            string strScript = string.Empty;
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                var budget_transfer_detail = new Budget_transfer_detail()
                {
                    budget_transfer_detail_id = BudgetTransferDetailId,
                    budget_transfer_doc = BudgetTransferDoc,
                    budget_money_major_id_from = long.Parse(hddbudget_money_major_id_from.Value),
                    budget_money_major_id_to = long.Parse(hddbudget_money_major_id_to.Value),
                    budget_transfer_detail_amount = decimal.Parse(txtbudget_transfer_detail_amount.Value.ToString()),
                    budget_transfer_detail_remark = txtbudget_transfer_detail_comment.Text.Trim(),
                    c_created_by = Session["username"].ToString(),
                    c_updated_by = Session["username"].ToString()
                };
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    oBudget_transfer.SP_BUDGET_TRANSFER_DETAIL_UPD(budget_transfer_detail);
                }
                else
                {
                    oBudget_transfer.SP_BUDGET_TRANSFER_DETAIL_INS(budget_transfer_detail);
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
            cBudget_transfer oBudget_transfer = new cBudget_transfer();
            string strMessage = string.Empty, strCriteria = string.Empty;
            try
            {
                strCriteria = " and budget_transfer_detail_id = '" + BudgetTransferDetailId + "' ";
                var item = oBudget_transfer.GETDETAIL(strCriteria);
                if (item != null)
                {
                    #region set Control

                    InitcboLot_from();
                    if (cboLot_from.Items.FindByValue(item.lot_code_from) != null)
                    {
                        cboLot_from.SelectedIndex = -1;
                        cboLot_from.Items.FindByValue(item.lot_code_from).Selected = true;
                    }
                    InitcboItem_group_from();
                    if (cboItem_group_from.Items.FindByValue(item.item_group_code_from) != null)
                    {
                        cboItem_group_from.SelectedIndex = -1;
                        cboItem_group_from.Items.FindByValue(item.item_group_code_from).Selected = true;
                    }

                    InitcboItemGroupDetail_from();
                    if (cboItem_group_detail_from.Items.FindByValue(item.item_group_detail_id_from.ToString()) != null)
                    {
                        cboItem_group_detail_from.SelectedIndex = -1;
                        cboItem_group_detail_from.Items.FindByValue(item.item_group_detail_id_from.ToString()).Selected = true;
                    }

                    InitcboItem_from();
                    if (cboItem_from.Items.FindByValue(item.item_code_from.ToString()) != null)
                    {
                        cboItem_from.SelectedIndex = -1;
                        cboItem_from.Items.FindByValue(item.item_code_from.ToString()).Selected = true;
                    }

                    InitcboItem_detail_from();
                    if (cboItem_detail_from.Items.FindByValue(item.item_detail_id_from.ToString()) != null)
                    {
                        cboItem_detail_from.SelectedIndex = -1;
                        cboItem_detail_from.Items.FindByValue(item.item_detail_id_from.ToString()).Selected = true;
                    }
                    hddbudget_money_major_id_from.Value = item.budget_money_major_id_from.ToString();

                    InitcboLot_to();
                    if (cboLot_to.Items.FindByValue(item.lot_code_to) != null)
                    {
                        cboLot_to.SelectedIndex = -1;
                        cboLot_to.Items.FindByValue(item.lot_code_to).Selected = true;
                    }
                    InitcboItem_group_to();
                    if (cboItem_group_to.Items.FindByValue(item.item_group_code_to) != null)
                    {
                        cboItem_group_to.SelectedIndex = -1;
                        cboItem_group_to.Items.FindByValue(item.item_group_code_to).Selected = true;
                    }

                    InitcboItemGroupDetail_to();
                    if (cboItem_group_detail_to.Items.FindByValue(item.item_group_detail_id_to.ToString()) != null)
                    {
                        cboItem_group_detail_to.SelectedIndex = -1;
                        cboItem_group_detail_to.Items.FindByValue(item.item_group_detail_id_to.ToString()).Selected = true;
                    }

                    InitcboItem_to();
                    if (cboItem_to.Items.FindByValue(item.item_code_to.ToString()) != null)
                    {
                        cboItem_to.SelectedIndex = -1;
                        cboItem_to.Items.FindByValue(item.item_code_to.ToString()).Selected = true;
                    }

                    InitcboItem_detail_to();
                    if (cboItem_detail_to.Items.FindByValue(item.item_detail_id_to.ToString()) != null)
                    {
                        cboItem_detail_to.SelectedIndex = -1;
                        cboItem_detail_to.Items.FindByValue(item.item_detail_id_to.ToString()).Selected = true;
                    }
                    hddbudget_money_major_id_to.Value = item.budget_money_major_id_to.ToString();

                    this.BudgetTransferDoc = item.budget_transfer_doc;
                    txtbudget_transfer_detail_comment.Text = item.budget_transfer_detail_remark;
                    txtbudget_transfer_detail_amount.Value = item.budget_transfer_detail_amount;
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

        protected void cboLot_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group_from();
        }

        protected void cboItem_group_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItemGroupDetail_from();
        }

        protected void cboItem_group_detail_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_from();
        }

        protected void cboItem_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_detail_from();
        }

        protected void cboItem_detail_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBudgetMoneyMajor_from();
        }

        protected void cboLot_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group_to();
        }

        protected void cboItem_group_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItemGroupDetail_to();
        }

        protected void cboItem_group_detail_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_to();
        }

        protected void cboItem_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_detail_to();
        }

        protected void cboItem_detail_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBudgetMoneyMajor_to();
        }

    }
}