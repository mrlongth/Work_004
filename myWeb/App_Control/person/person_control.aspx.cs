using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using myDLL;

namespace myWeb.App_Control.person
{
    public partial class person_control : PageBase
    {
        #region private data
        private string strConn = ConfigurationSettings.AppSettings["ConnectionString"];
        private bool[] blnAccessRight = new bool[5] { false, false, false, false, false };
        private string strPrefixCtr_main = "ctl00$ContentPlaceHolder1$TabContainer1$";
        private string _strYear = string.Empty;
        #endregion


        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            _strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
            if (!IsPostBack)
            {

                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");

                imgSaveOnly.Attributes.Add("onclick", "RunValidationsAndSetActiveTab();");
                txtperson_id.Attributes.Add("onblur", "checkInt(this,9999999999999)");

                TabContainer1.ActiveTabIndex = 0;

                #region set QueryString
                if (Request.QueryString["person_code"] != null)
                {
                    ViewState["person_code"] = Request.QueryString["person_code"].ToString();
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
                if (Request.QueryString["PageStatus"] != null)
                {
                    ViewState["PageStatus"] = Request.QueryString["PageStatus"].ToString();
                }
                if (Request.QueryString["FromPage"] != null)
                {
                    ViewState["FromPage"] = Request.QueryString["FromPage"].ToString();
                }

                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    InitcboTitle();
                    InitcboPerson_group();
                    InitcboPerson_work_status();
                    InitcboMajor();
                    Session["menupopup_name"] = "เพิ่มข้อมูลบุคลากร";
                    ViewState["page"] = Request.QueryString["page"];
                    txtperson_code.ReadOnly = true;
                    txtperson_code.CssClass = "textboxdis";
                    txtperson_code.CssClass = "textboxdis";
                    TabContainer1.Tabs[0].Visible = true;
                    TabContainer1.Tabs[1].Visible = false;

                    txtperson_start.Text = cCommon.CheckDate(DateTime.Now.Date.ToString("dd/MM/yyyy"));
                    txtperson_end.Text = cCommon.CheckDate(DateTime.Now.Date.ToString("dd/MM/yyyy"));
                    if (ViewState["FromPage"] != null && ViewState["FromPage"].ToString() == "person_center")
                    {
                        setDataCenter();
                    }
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    Session["menupopup_name"] = "แก้ไขข้อมูลบุคลากร";
                    setData();
                    txtperson_code.ReadOnly = true;
                    txtperson_code.CssClass = "textboxdis";
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("view"))
                {
                    setData();
                    Utils.SetControls(pnlMain, myDLL.Common.Enumeration.Mode.VIEW);
                }
                

                #endregion


                #region Set Image

                imgperson_pic.Attributes.Add("onclick", "OpenPopUp('500px','200px','80%','อัพโหลดรูปบุคลากร' ,'../person/person_upload.aspx?" +
                                                                    "ctrl1=" + txtperson_pic.ClientID + "&ctrl2=" + imgPerson.ClientID + "&show=2', '2');return false;");
                imgClear_person_pic.Attributes.Add("onclick", "document.getElementById('" + txtperson_pic.ClientID + "').value='';" +
                                                                                                             "document.getElementById('" + imgPerson.ClientID + "').src='../../person_pic/image_n_a.jpg';return false;");

                imgList_position.Attributes.Add("onclick", "OpenPopUp('800px','400px','93%','ค้นหาข้อมูลตำแหน่งปัจจุบัน' ,'../lov/position_lov.aspx?position_code='+document.forms[0]." +
                                                                strPrefixCtr_main + "TabPanel2$txtposition_code.value+" + "'&position_name='+document.forms[0]." + strPrefixCtr_main +
                                                                "TabPanel2$txtposition_name.value+" + "'&ctrl1=" + txtposition_code.ClientID + "&" +
                                                                "ctrl2=" + txtposition_name.ClientID + "&show=2', '2');return false;");
                imgClear_position.Attributes.Add("onclick", "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtposition_code.value='';document.forms[0]." +
                                                        strPrefixCtr_main + "TabPanel2$txtposition_name.value=''; return false;");

                imgList_level.Attributes.Add("onclick", "OpenPopUp('800px','400px','93%','ค้นหาข้อมูลระดับตำแหน่ง' ,'../lov/level_position_lov.aspx?level_position_code='+document.forms[0]." +
                                                strPrefixCtr_main + "TabPanel2$txtperson_level.value+" + "'&position_name='+document.forms[0]." + strPrefixCtr_main +
                                                "TabPanel2$txtlevel_position_name.value+" + "'&ctrl1=" + txtperson_level.ClientID + "&" +
                                                "ctrl2=" + txtlevel_position_name.ClientID + "&show=2', '2');return false;");
                imgClear_level.Attributes.Add("onclick", "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtperson_level.value='';document.forms[0]." +
                                                        strPrefixCtr_main + "TabPanel2$txtlevel_position_name.value=''; return false;");


                imgList_type.Attributes.Add("onclick", "OpenPopUp('800px','400px','93%','ค้นหาข้อมูลประเภทตำแหน่ง' ,'../lov/type_position_lov.aspx?type_position_code='+document.forms[0]." +
                                                              strPrefixCtr_main + "TabPanel2$txttype_position_code.value+" + "'&type_position_name='+document.forms[0]." + strPrefixCtr_main +
                                                              "TabPanel2$txttype_position_name.value+" + "'&ctrl1=" + txttype_position_code.ClientID + "&" +
                                                              "ctrl2=" + txttype_position_name.ClientID + "&show=2', '2');return false;");
                imgClear_type.Attributes.Add("onclick", "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txttype_position_code.value='';document.forms[0]." +
                                                        strPrefixCtr_main + "TabPanel2$txttype_position_name.value=''; return false;");


                imgList_person_manage.Attributes.Add("onclick", "OpenPopUp('800px','400px','93%','ค้นหาข้อมูลตำแหน่งทางการบริหาร' ,'../lov/person_manage_lov.aspx?" +
                                                            "person_manage_code='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtperson_manage_code.value+" +
                                                            "'&person_manage_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtperson_manage_name.value+" +
                                                            "'&ctrl1=" + txtperson_manage_code.ClientID + "&ctrl2=" + txtperson_manage_name.ClientID + "&show=2', '2');return false;");
                imgClear_person_manage.Attributes.Add("onclick", "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtperson_manage_code.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtperson_manage_name.value=''; return false;");
                InitcboBudgetType();

                string strBusget_type = cboBudget_type.SelectedValue;
                imgList_budget_plan.Attributes.Add("onclick", "OpenPopUp('950px','500px','94%','ค้นหาข้อมูลผังงบประมาณประจำปี' ,'../lov/budget_plan_lov.aspx?budget_type=" + strBusget_type +
                                                                "&budget_plan_code='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_code.value+'" +
                                                                "&budget_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_name.value+'" +
                                                                "&produce_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtproduce_name.value+'" +
                                                                "&activity_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtactivity_name.value+'" +
                                                                "&plan_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtplan_name.value+'" +
                                                                "&work_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtwork_name.value+'" +
                                                                "&fund_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtfund_name.value+'" +
                                                                "&director_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtdirector_name.value+'" +
                                                                "&unit_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtunit_name.value+'" +
                                                                "&budget_plan_year='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_year.value+'" +
                                                                "&ctrl1=" + txtbudget_plan_code.ClientID +
                                                                "&ctrl2=" + txtbudget_name.ClientID +
                                                                "&ctrl3=" + txtproduce_name.ClientID +
                                                                "&ctrl4=" + txtactivity_name.ClientID +
                                                                "&ctrl5=" + txtplan_name.ClientID +
                                                                "&ctrl6=" + txtwork_name.ClientID +
                                                                "&ctrl7=" + txtfund_name.ClientID +
                                                                "&ctrl9=" + txtdirector_name.ClientID +
                                                                "&ctrl10=" + txtunit_name.ClientID +
                                                                "&ctrl11=" + txtbudget_plan_year.ClientID + "&show=2', '2');return false;");

                imgClear_budget_plan.Attributes.Add("onclick",
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_code.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtproduce_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtactivity_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtplan_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtwork_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtfund_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtdirector_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtunit_name.value='';" +
                                                                "document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_year.value=''; return false;");

                #endregion


            }
            else
            {
                StoreDataFromJS();
            }
            //if (FileUploaderAJAX1.IsPosting)
            //{
            //    this.managePost();
            //}
        }

        #region private function

        private void InitcboTitle()
        {
            cTitle oTitle = new cTitle();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strtitle_code = string.Empty;
            strtitle_code = cboTitle.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and c_active='Y' ";
            if (oTitle.SP_SEL_TITLE(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboTitle.Items.Clear();
                cboTitle.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboTitle.Items.Add(new ListItem(dt.Rows[i]["title_name"].ToString(), dt.Rows[i]["title_code"].ToString()));
                }
                if (cboTitle.Items.FindByValue(strtitle_code) != null)
                {
                    cboTitle.SelectedIndex = -1;
                    cboTitle.Items.FindByValue(strtitle_code).Selected = true;
                }
            }
        }

        private void InitcboPerson_group()
        {
            cPerson_group oPerson_group = new cPerson_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strperson_group_code = string.Empty;
            strperson_group_code = cboPerson_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and c_active='Y' ";
            if (oPerson_group.SP_PERSON_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_group.Items.Clear();
                cboPerson_group.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboPerson_group.Items.Add(new ListItem(dt.Rows[i]["person_group_name"].ToString(), dt.Rows[i]["person_group_code"].ToString()));
                }
                if (cboPerson_group.Items.FindByValue(strperson_group_code) != null)
                {
                    cboPerson_group.SelectedIndex = -1;
                    cboPerson_group.Items.FindByValue(strperson_group_code).Selected = true;
                }
            }
        }

        private void InitcboPerson_work_status()
        {
            cPerson_work_status oPerson_work_status = new cPerson_work_status();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strperson_work_status = string.Empty;
            strperson_work_status = cboPerson_work_status.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and c_active='Y' ";
            if (oPerson_work_status.SP_PERSON_WORK_STATUS_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_work_status.Items.Clear();
                //cboPerson_work_status.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboPerson_work_status.Items.Add(new ListItem(dt.Rows[i]["person_work_status_name"].ToString(), dt.Rows[i]["person_work_status_code"].ToString()));
                }
                if (cboPerson_work_status.Items.FindByValue(strperson_work_status) != null)
                {
                    cboPerson_work_status.SelectedIndex = -1;
                    cboPerson_work_status.Items.FindByValue(strperson_work_status).Selected = true;
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
            strCriteria = " Select * from  general where g_type = 'budget_type' and g_code not in ('M','S') Order by g_sort ";
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
            string strMajor_code = cboMajor.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Major_year = '" + _strYear + "'  and  c_active='Y' ";
            if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMajor.Items.Clear();
                cboMajor.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboMajor.Items.Add(new ListItem(dt.Rows[i]["Major_name"].ToString(), dt.Rows[i]["Major_code"].ToString()));
                }
                if (cboMajor.Items.FindByValue(strMajor_code) != null)
                {
                    cboMajor.SelectedIndex = -1;
                    cboMajor.Items.FindByValue(strMajor_code).Selected = true;
                }
            }
        }


        protected void cboBudget_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLabelBudget();
        }

        private void ChangeLabelBudget()
        {

            string strBusget_type = cboBudget_type.SelectedValue;
            string strLovTitle = "ค้นหาข้อมูลผังงบประมาณประจำปี (เงินงบประมาณ)";
            if (strBusget_type == "R") strLovTitle = "ค้นหาข้อมูลผังงบประมาณประจำปี (เงินรายได้)";
            imgList_budget_plan.Attributes.Add("onclick", "OpenPopUp('950px','500px','94%','" + strLovTitle + "' ,'../lov/budget_plan_lov.aspx?budget_type=" + strBusget_type +
                                                                "&budget_plan_code='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_code.value+'" +
                                                                "&budget_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_name.value+'" +
                                                                "&produce_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtproduce_name.value+'" +
                                                                "&activity_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtactivity_name.value+'" +
                                                                "&plan_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtplan_name.value+'" +
                                                                "&work_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtwork_name.value+'" +
                                                                "&fund_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtfund_name.value+'" +
                                                                "&director_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtdirector_name.value+'" +
                                                                "&unit_name='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtunit_name.value+'" +
                                                                "&budget_plan_year='+document.forms[0]." + strPrefixCtr_main + "TabPanel2$txtbudget_plan_year.value+'" +
                                                                "&ctrl1=" + txtbudget_plan_code.ClientID +
                                                                "&ctrl2=" + txtbudget_name.ClientID +
                                                                "&ctrl3=" + txtproduce_name.ClientID +
                                                                "&ctrl4=" + txtactivity_name.ClientID +
                                                                "&ctrl5=" + txtplan_name.ClientID +
                                                                "&ctrl6=" + txtwork_name.ClientID +
                                                                "&ctrl7=" + txtfund_name.ClientID +
                                                                "&ctrl9=" + txtdirector_name.ClientID +
                                                                "&ctrl10=" + txtunit_name.ClientID +
                                                                "&ctrl11=" + txtbudget_plan_year.ClientID + "&show=2', '2');return false;");



            //if (strBusget_type == "B")
            //{
            //    Label54.Text = "แผนงบประมาณ  :";
            //    Label55.Text = "ผลผลิต :";
            //    Label53.Text = "กิจกรรม :";
            //    Label56.Text = "แผนงาน :";
            //}
            //else
            //{
            //    Label54.Text = "แผนงาน :";
            //    Label55.Text = "งานหลัก :";
            //    Label53.Text = "งานรอง :";
            //    Label56.Text = "งานย่อย :";
            //}
        }


        private void StoreDataFromJS()
        {
            if (Request.Form[strPrefixCtr_main + "TabPanel2$txtperson_start"] != null)
            {
                txtperson_start.Text = Request.Form[strPrefixCtr_main + "TabPanel2$txtperson_start"].ToString();
            }
            else
            {
                txtperson_start.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

            if (Request.Form[strPrefixCtr_main + "TabPanel2$txtperson_end"] != null)
            {
                txtperson_end.Text = Request.Form[strPrefixCtr_main + "TabPanel2$txtperson_end"].ToString();
            }
            else
            {
                txtperson_end.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        private void InitializeComponent()
        {
            this.imgSaveOnly.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveOnly_Click);
            //this.imgSave.Click += new System.Web.UI.ImageClickEventHandler(this.imgSave_Click);

        }
        #endregion

        private bool saveData1()
        {
            bool blnResult = false;
            bool blnDup = false;
            string strMessage = string.Empty;
            //Tab 1 
            string strperson_code = string.Empty,
                strtitle_code = string.Empty,
                strperson_thai_name = string.Empty,
                strperson_thai_surname = string.Empty,
                strperson_eng_name = string.Empty,
                strperson_eng_surname = string.Empty,
                strperson_nickname = string.Empty,
                strperson_id = string.Empty,
                strperson_pic = string.Empty,
                strC_active = string.Empty,
                strCreatedBy = string.Empty,
                strUpdatedBy = string.Empty,
                strCreatedDate = string.Empty,
                strUpdatedDate = string.Empty;
            string strScript = string.Empty;
            cPerson oPerson = new cPerson();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                strperson_code = txtperson_code.Text;
                strtitle_code = cboTitle.SelectedValue;
                if (Request.Form[strPrefixCtr_main + "TabPanel1$cboTitle"] != null)
                {
                    strtitle_code = Request.Form[strPrefixCtr_main + "TabPanel1$cboTitle"].ToString();
                }
                strperson_thai_name = txtperson_thai_name.Text;
                strperson_thai_surname = txtperson_thai_surname.Text;
                strperson_eng_name = txtperson_eng_name.Text;
                strperson_eng_surname = txtperson_eng_surname.Text;
                strperson_nickname = txtperson_nickname.Text;
                strperson_id = txtperson_id.Text;
                strperson_pic = Request.Form[strPrefixCtr_main + "TabPanel1$txtperson_pic"];

                if (chkStatus.Checked == true)
                {
                    strC_active = "Y";
                }
                else
                {
                    strC_active = "N";
                }
                strCreatedBy = Session["username"].ToString();
                strUpdatedBy = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    #region check dup
                    string strCheckDup = string.Empty;
                    strCheckDup = " and person_thai_name = '" + strperson_thai_name.Trim() + "' and person_thai_surname= '" +
                                                  strperson_thai_surname.Trim() + "' and person_code<>'" + strperson_code.Trim() + "' ";
                    if (!oPerson.SP_PERSON_LIST_SEL(strCheckDup, ref ds, ref strMessage))
                    {
                        lblError.Text = strMessage;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strScript =
                                "alert(\"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก" +
                                "\\nข้อมูลบุคลากร : " + strperson_thai_name.Trim() + "  " + strperson_thai_surname.Trim() +
                                "\\nซ้ำ\");\n";
                            blnDup = true;
                        }
                    }
                    #endregion
                    #region edit
                    if (!blnDup)
                    {
                        if (oPerson.SP_PERSON_HIS_UPD(strperson_code, strtitle_code, strperson_thai_name, strperson_thai_surname, strperson_eng_name,
                                                                                                 strperson_eng_surname, strperson_nickname, strperson_id, strperson_pic, strC_active, strUpdatedBy, ref strMessage))
                        {
                            saveData2();
                            blnResult = true;
                        }
                        else
                        {
                            lblError.Text = strMessage.ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "chkdup", strScript, true);
                    }
                    #endregion
                }
                else
                {
                    #region check dup
                    string strCheckDup = string.Empty;
                    strCheckDup = " and person_thai_name = '" + strperson_thai_name.Trim() + "' and person_thai_surname= '" + strperson_thai_surname.Trim() + "' ";
                    if (!oPerson.SP_PERSON_LIST_SEL(strCheckDup, ref ds, ref strMessage))
                    {
                        lblError.Text = strMessage;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strScript =
                                "alert(\"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก" +
                                "\\nข้อมูลบุคลากร : " + strperson_thai_name.Trim() + "  " + strperson_thai_surname.Trim() +
                                "\\nซ้ำ\");\n";
                            blnDup = true;
                        }
                    }
                    #endregion
                    #region insert
                    if (!blnDup)
                    {
                        if (oPerson.SP_PERSON_HIS_INS(strtitle_code, strperson_thai_name, strperson_thai_surname, strperson_eng_name,
                                                                                                 strperson_eng_surname, strperson_nickname, strperson_id, strperson_pic, strC_active, strCreatedBy, ref strMessage))
                        {
                            string strGetcode = " and person_thai_name = '" + strperson_thai_name.Trim() + "' and person_thai_surname = '" + strperson_thai_surname + "' ";
                            if (!oPerson.SP_PERSON_LIST_SEL(strGetcode, ref ds, ref strMessage))
                            {
                                lblError.Text = strMessage;
                            }
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strperson_code = ds.Tables[0].Rows[0]["person_code"].ToString();
                            }
                            ViewState["person_code"] = strperson_code;
                            txtperson_code.Text = ViewState["person_code"].ToString();
                            saveData2();
                            blnResult = true;
                        }
                        else
                        {
                            lblError.Text = strMessage.ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "close", strScript, true);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oPerson.Dispose();
            }
            return blnResult;
        }

        private bool saveData2()
        {
            bool blnResult = false;
            string strMessage = string.Empty;
            //Tab 2
            string strperson_code = string.Empty,
                strposition_code = string.Empty,
                strperson_level = string.Empty,
                strperson_level_name = string.Empty,
                strtype_position_code = string.Empty,
                strtype_position_name = string.Empty,

                strperson_postionno = string.Empty,
                strperson_group = string.Empty,
                strperson_start = string.Empty,
                strperson_end = string.Empty,
                strperson_manage_code = string.Empty,
                strbudget_plan_code = string.Empty,
                strperson_work_status = string.Empty,
                strmajor_code = string.Empty,

                strUpdatedBy = string.Empty;
            string strScript = string.Empty;
            cPerson oPerson = new cPerson();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                strperson_code = txtperson_code.Text;
                strposition_code = txtposition_code.Text;
                strperson_level = txtperson_level.Text;
                strperson_level_name = txtlevel_position_name.Text;
                strtype_position_code = txttype_position_code.Text;
                strtype_position_name = txttype_position_name.Text;

                strperson_postionno = txtperson_postionno.Text;
                strmajor_code = cboMajor.SelectedValue;

                strperson_group = cboPerson_group.SelectedValue;
                if (Request.Form[strPrefixCtr_main + "TabPanel2$cboPerson_group"] != null)
                {
                    strperson_group = Request.Form[strPrefixCtr_main + "TabPanel2$cboPerson_group"].ToString();
                }
                strperson_start = txtperson_start.Text;
                strperson_end = txtperson_end.Text;
                strperson_manage_code = txtperson_manage_code.Text;
                strbudget_plan_code = txtbudget_plan_code.Text;
                strperson_work_status = cboPerson_work_status.SelectedValue;
                if (Request.Form[strPrefixCtr_main + "TabPanel2$cboPerson_work_status"] != null)
                {
                    strperson_work_status = Request.Form[strPrefixCtr_main + "TabPanel2$cboPerson_work_status"].ToString();
                }
                strUpdatedBy = Session["username"].ToString();
                #endregion
                #region edit
                if (oPerson.SP_PERSON_WORK_UPD(strperson_code, strposition_code, strperson_level, strperson_postionno, strperson_start, 
                                                strperson_end, strperson_group, strperson_manage_code, strbudget_plan_code,
                                               strperson_work_status, strUpdatedBy, txttype_position_code.Text, strmajor_code, ref strMessage))
                {
                    blnResult = true;
                }
                else
                {
                    lblError.Text = strMessage.ToString();
                }
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oPerson.Dispose();
            }
            return blnResult;
        }



        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (saveData1())
            {
                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                    Response.Redirect("person_control.aspx?mode=edit&person_code=" + ViewState["person_code"].ToString() + "&page=" + ViewState["page"].ToString() + "&PageStatus=save", true);
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    txtperson_code.ReadOnly = true;
                    txtperson_code.CssClass = "textboxdis";
                    // string strScript1 = "RefreshMain('" + ViewState["page"].ToString() + "');";
                    string strScript1 = "ClosePopUpListPost('" + ViewState["page"].ToString() + "','1');";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
                }
                setData();
                txtperson_code.ReadOnly = true;
                txtperson_code.CssClass = "textboxdis";
                MsgBox("บันทึกข้อมูลสมบูรณ์");
            }
        }

        private void setData()
        {
            cPerson oPerson = new cPerson();
            DataSet ds = new DataSet();
            string strMessage = string.Empty, strCriteria = string.Empty;
            #region clear Data
            //Tab 1 
            string strperson_code = string.Empty,
                strtitle_code = string.Empty,
                strperson_thai_name = string.Empty,
                strperson_thai_surname = string.Empty,
                strperson_eng_name = string.Empty,
                strperson_eng_surname = string.Empty,
                strperson_nickname = string.Empty,
                strperson_id = string.Empty,
                strperson_pic = string.Empty,
                strC_active = string.Empty,
                strCreatedBy = string.Empty,
                strUpdatedBy = string.Empty,
                strCreatedDate = string.Empty,
                strUpdatedDate = string.Empty,
                strBudget_type = string.Empty;
            //Tab 2 
            string strposition_code = string.Empty,
                strposition_name = string.Empty,

                strperson_level = string.Empty,
                strperson_level_name = string.Empty,
                strtype_position_code = string.Empty,
                strtype_position_name = string.Empty,

                strperson_postionno = string.Empty,

                strperson_group = string.Empty,
                strperson_start = string.Empty,
                strperson_end = string.Empty,
                strperson_manage_code = string.Empty,
                strperson_manage_name = string.Empty,
                strbudget_plan_code = string.Empty,
                strbudget_name = string.Empty,
                strproduce_name = string.Empty,
                stractivity_name = string.Empty,
                strplan_name = string.Empty,
                strwork_name = string.Empty,
                strfund_name = string.Empty,
                strdirector_name = string.Empty,
                strunit_name = string.Empty,
                strbudget_plan_year = string.Empty,
                strperson_work_status = string.Empty,
                strmajor_code = string.Empty;

            #endregion
            try
            {
                strCriteria = " and person_code = '" + ViewState["person_code"].ToString() + "' ";
                if (!oPerson.SP_PERSON_ALL_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        #region get Data
                        //Tab 1 
                        strperson_code = ds.Tables[0].Rows[0]["person_code"].ToString();
                        strtitle_code = ds.Tables[0].Rows[0]["title_code"].ToString();
                        strperson_thai_name = ds.Tables[0].Rows[0]["person_thai_name"].ToString();
                        strperson_thai_surname = ds.Tables[0].Rows[0]["person_thai_surname"].ToString();
                        strperson_eng_name = ds.Tables[0].Rows[0]["person_eng_name"].ToString();
                        strperson_eng_surname = ds.Tables[0].Rows[0]["person_eng_surname"].ToString();
                        strperson_nickname = ds.Tables[0].Rows[0]["person_nickname"].ToString();
                        strperson_id = ds.Tables[0].Rows[0]["person_id"].ToString();
                        strperson_pic = ds.Tables[0].Rows[0]["person_pic"].ToString();
                        strC_active = ds.Tables[0].Rows[0]["c_active"].ToString();
                        strCreatedBy = ds.Tables[0].Rows[0]["c_created_by"].ToString();
                        strUpdatedBy = ds.Tables[0].Rows[0]["c_updated_by"].ToString();
                        strCreatedDate = ds.Tables[0].Rows[0]["d_created_date"].ToString();
                        strUpdatedDate = ds.Tables[0].Rows[0]["d_updated_date"].ToString();
                        //Tab 2 
                        strposition_code = ds.Tables[0].Rows[0]["position_code"].ToString();
                        strposition_name = ds.Tables[0].Rows[0]["position_name"].ToString();

                        strperson_level = ds.Tables[0].Rows[0]["person_level"].ToString();
                        strperson_level_name = ds.Tables[0].Rows[0]["level_position_name"].ToString();
                        strtype_position_code = ds.Tables[0].Rows[0]["type_position_code"].ToString();
                        strtype_position_name = ds.Tables[0].Rows[0]["type_position_name"].ToString();

                        strperson_postionno = ds.Tables[0].Rows[0]["person_postionno"].ToString();

                        strperson_group = ds.Tables[0].Rows[0]["person_group_code"].ToString();
                        strperson_start = ds.Tables[0].Rows[0]["person_start"].ToString();
                        strperson_end = ds.Tables[0].Rows[0]["person_end"].ToString();
                        strperson_manage_code = ds.Tables[0].Rows[0]["person_manage_code"].ToString();
                        strperson_manage_name = ds.Tables[0].Rows[0]["person_manage_name"].ToString();
                        strBudget_type = ds.Tables[0].Rows[0]["person_budget_type"].ToString();

                        if (cboBudget_type.Items.FindByValue(strBudget_type) != null)
                        {
                            cboBudget_type.SelectedIndex = -1;
                            cboBudget_type.Items.FindByValue(strBudget_type).Selected = true;
                        }

                        strbudget_plan_code = ds.Tables[0].Rows[0]["budget_plan_code"].ToString();
                        strbudget_name = ds.Tables[0].Rows[0]["budget_name"].ToString();
                        strproduce_name = ds.Tables[0].Rows[0]["produce_name"].ToString();
                        stractivity_name = ds.Tables[0].Rows[0]["activity_name"].ToString();
                        strplan_name = ds.Tables[0].Rows[0]["plan_name"].ToString();
                        strwork_name = ds.Tables[0].Rows[0]["work_name"].ToString();
                        strfund_name = ds.Tables[0].Rows[0]["fund_name"].ToString();
                        strdirector_name = ds.Tables[0].Rows[0]["director_name"].ToString();
                        strunit_name = ds.Tables[0].Rows[0]["unit_name"].ToString();
                        strbudget_plan_year = ds.Tables[0].Rows[0]["budget_plan_year"].ToString();
                        strperson_work_status = ds.Tables[0].Rows[0]["person_work_status_code"].ToString();
                        strBudget_type = ds.Tables[0].Rows[0]["person_budget_type"].ToString();
                        strmajor_code = ds.Tables[0].Rows[0]["major_code"].ToString();

                        #endregion

                        #region set Control
                        TabContainer1.Tabs[1].Visible = true;
                        //Tab 1 
                        txtperson_code.Text = strperson_code;
                        Session["person_code"] = strperson_code;
                        InitcboTitle();
                        if (cboTitle.Items.FindByValue(strtitle_code) != null)
                        {
                            cboTitle.SelectedIndex = -1;
                            cboTitle.Items.FindByValue(strtitle_code).Selected = true;
                        }
                        txtperson_thai_name.Text = strperson_thai_name;
                        txtperson_thai_surname.Text = strperson_thai_surname;
                        txtperson_eng_name.Text = strperson_eng_name;
                        txtperson_eng_surname.Text = strperson_eng_surname;
                        txtperson_nickname.Text = strperson_nickname;
                        txtperson_id.Text = strperson_id;
                        txtperson_pic.Text = strperson_pic;
                        if (strperson_pic.Length != 0)
                        {
                            imgPerson.ImageUrl = "../../person_pic/" + strperson_pic;
                        }
                        else
                        {
                            imgPerson.ImageUrl = "../../person_pic/image_n_a.jpg";
                        }
                        txtUpdatedBy.Text = strUpdatedBy;
                        txtUpdatedDate.Text = strUpdatedDate;

                        if (strC_active.Equals("Y"))
                        {
                            chkStatus.Checked = true;
                        }
                        else
                        {
                            chkStatus.Checked = false;
                        }


                        //Tab 2 
                        InitcboBudgetType();
                        if (cboBudget_type.Items.FindByValue(strBudget_type) != null)
                        {
                            cboBudget_type.SelectedIndex = -1;
                            cboBudget_type.Items.FindByValue(strBudget_type).Selected = true;
                        }
                        ChangeLabelBudget();

                        txtposition_code.Text = strposition_code;
                        txtposition_name.Text = strposition_name;

                        txtperson_level.Text = strperson_level;
                        txtlevel_position_name.Text = strperson_level_name;
                        txttype_position_code.Text = strtype_position_code;
                        txttype_position_name.Text = strtype_position_name;

                        txtperson_postionno.Text = strperson_postionno;
                        InitcboPerson_group();
                        if (cboPerson_group.Items.FindByValue(strperson_group) != null)
                        {
                            cboPerson_group.SelectedIndex = -1;
                            cboPerson_group.Items.FindByValue(strperson_group).Selected = true;
                        }
                        txtperson_start.Text = cCommon.CheckDate(strperson_start);
                        txtperson_end.Text = cCommon.CheckDate(strperson_end);

                        txtperson_manage_code.Text = strperson_manage_code;
                        txtperson_manage_name.Text = strperson_manage_name;
                        txtbudget_plan_code.Text = strbudget_plan_code;
                        txtbudget_name.Text = strbudget_name;
                        txtproduce_name.Text = strproduce_name;
                        txtactivity_name.Text = stractivity_name;
                        txtplan_name.Text = strplan_name;
                        txtwork_name.Text = strwork_name;
                        txtfund_name.Text = strfund_name;
                        txtdirector_name.Text = strdirector_name;
                        txtunit_name.Text = strunit_name;
                        txtbudget_plan_year.Text = strbudget_plan_year;
                        InitcboPerson_work_status();
                        if (cboPerson_work_status.Items.FindByValue(strperson_work_status) != null)
                        {
                            cboPerson_work_status.SelectedIndex = -1;
                            cboPerson_work_status.Items.FindByValue(strperson_work_status).Selected = true;
                        }


                        InitcboMajor();
                        if (cboMajor.Items.FindByValue(strmajor_code) != null)
                        {
                            cboMajor.SelectedIndex = -1;
                            cboMajor.Items.FindByValue(strmajor_code).Selected = true;
                        }

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }



        private void setDataCenter()
        {
            //cPerson_center oPerson = new cPerson_center();
            //cCommon oCommon = new cCommon();

            //DataSet ds = new DataSet();
            //DataSet dsPersonCode = new DataSet();
            //string strMessage = string.Empty, strCriteria = string.Empty;
            //#region clear Data
            ////Tab 1 
            //string strperson_code = string.Empty,
            //    strtitle_code = string.Empty,
            //    strperson_thai_name = string.Empty,
            //    strperson_thai_surname = string.Empty,
            //    strperson_eng_name = string.Empty,
            //    strperson_eng_surname = string.Empty,
            //    strperson_nickname = string.Empty,
            //    strperson_id = string.Empty,
            //    strperson_pic = string.Empty,
            //    strC_active = string.Empty,
            //    strCreatedBy = string.Empty,
            //    strUpdatedBy = string.Empty,
            //    strCreatedDate = string.Empty,
            //    strUpdatedDate = string.Empty,
            //    strBudget_type = string.Empty;
            ////Tab 2 
            //string strposition_code = string.Empty,
            //    strposition_name = string.Empty,

            //    strperson_level = string.Empty,
            //    strperson_level_name = string.Empty,
            //    strtype_position_code = string.Empty,
            //    strtype_position_name = string.Empty,

            //    strperson_postionno = string.Empty,
            //    strbranch_code = string.Empty,
            //    strbranch_name = string.Empty,
            //    strbank_name = string.Empty,
            //    strbank_no = string.Empty,
            //    strperson_salaly = string.Empty,
            //    strperson_group = string.Empty,
            //    strperson_start = string.Empty,
            //    strperson_end = string.Empty,
            //    strmember_type = string.Empty,
            //    strmember_type_add = "0",
            //    strperson_manage_code = string.Empty,
            //    strperson_manage_name = string.Empty,
            //    strbudget_plan_code = string.Empty,
            //    strbudget_name = string.Empty,
            //    strproduce_name = string.Empty,
            //    stractivity_name = string.Empty,
            //    strplan_name = string.Empty,
            //    strwork_name = string.Empty,
            //    strfund_name = string.Empty,
            //    strdirector_name = string.Empty,
            //    strunit_name = string.Empty,
            //    strbudget_plan_year = string.Empty,
            //    strperson_work_status = string.Empty;
            ////Tab 3
            //string strperson_sex = string.Empty,
            //    strperson_width = string.Empty,
            //    strperson_high = string.Empty,
            //    strperson_origin = string.Empty,
            //    strperson_nation = string.Empty,
            //    strperson_religion = string.Empty,
            //    strperson_birth = string.Empty,
            //    strperson_marry = string.Empty;
            ////Tab 4
            //string strperson_room = string.Empty,
            //    strperson_floor = string.Empty,
            //    strperson_village = string.Empty,
            //    strperson_homeno = string.Empty,
            //    strperson_soi = string.Empty,
            //    strperson_moo = string.Empty,
            //    strperson_road = string.Empty,
            //    strperson_tambol = string.Empty,
            //    strperson_aumphur = string.Empty,
            //    strperson_province = string.Empty,
            //    strperson_postno = string.Empty,
            //    strperson_tel = string.Empty,
            //    strperson_contact = string.Empty,
            //    strperson_ralation = string.Empty,
            //    strperson_contact_tel = string.Empty;
            //#endregion
            //try
            //{
            //    strCriteria = " and CITIZEN_ID = '" + ViewState["person_code"].ToString() + "' ";
            //    if (!oPerson.SP_PERSON_CENTER_SEL(strCriteria, ref ds, ref strMessage))
            //    {
            //        lblError.Text = strMessage;
            //    }
            //    else
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            #region get Data
            //            //Tab 1 
            //            string strSQL = " SELECT dbo.FormatNumber(cast(MAX(person_code) as int)+1,5) as person_code FROM [person_his]";
            //            oCommon.SEL_SQL(strSQL, ref dsPersonCode, ref strMessage);
            //            if (dsPersonCode.Tables[0].Rows.Count > 0) strperson_code = dsPersonCode.Tables[0].Rows[0]["person_code"].ToString();
            //            strtitle_code = getTitle(ds.Tables[0].Rows[0]["TITLE_NAME"]);
            //            strperson_thai_name = ds.Tables[0].Rows[0]["STF_FNAME"].ToString();
            //            strperson_thai_surname = ds.Tables[0].Rows[0]["STF_LNAME"].ToString();
            //            strperson_eng_name = ds.Tables[0].Rows[0]["NAME_ENG"].ToString();
            //            strperson_eng_surname = ds.Tables[0].Rows[0]["SURNAME_ENG"].ToString();
            //            strperson_nickname = "";
            //            strperson_id = ds.Tables[0].Rows[0]["CITIZEN_ID"].ToString();
            //            strperson_pic = "";
            //            strC_active = "Y";
            //            strCreatedBy = "";
            //            strUpdatedBy = "";
            //            strCreatedDate = "";
            //            strUpdatedDate = "";
            //            //Tab 2 
            //            strposition_code = getPosition(ds.Tables[0].Rows[0]["POSITION_WORK"]);
            //            strposition_name = ds.Tables[0].Rows[0]["POSITION_WORK"].ToString();

            //            //strperson_level = ds.Tables[0].Rows[0]["person_level"].ToString();
            //            //strperson_level_name = ds.Tables[0].Rows[0]["level_position_name"].ToString();
            //            //strtype_position_code = ds.Tables[0].Rows[0]["type_position_code"].ToString();
            //            strtype_position_name = ds.Tables[0].Rows[0]["positionBlockLevelName"].ToString();

            //            strperson_postionno = ds.Tables[0].Rows[0]["PCNO"].ToString();
            //            //strbranch_code = ds.Tables[0].Rows[0]["branch_code"].ToString();
            //            //strbranch_name = ds.Tables[0].Rows[0]["branch_name"].ToString();
            //            // strbank_name = ds.Tables[0].Rows[0]["bank_name"].ToString();
            //            // strbank_no = ds.Tables[0].Rows[0]["bank_no"].ToString();
            //            strperson_salaly = ds.Tables[0].Rows[0]["SALARY"].ToString();
            //            strperson_group = getPerson_group(ds.Tables[0].Rows[0]["GROUP_TYPE_NAME"]);
            //            strperson_start = ds.Tables[0].Rows[0]["DATE_INWORK"].ToString();
            //            strperson_end = ds.Tables[0].Rows[0]["DATE_RETIRE"].ToString();
            //            // strmember_type = ds.Tables[0].Rows[0]["member_type_code"].ToString();
            //            // strmember_type_add = ds.Tables[0].Rows[0]["member_type_add"].ToString();
            //            strperson_manage_code = getPerson_manage(ds.Tables[0].Rows[0]["ADMIN_NAME"]);
            //            strperson_manage_name = ds.Tables[0].Rows[0]["ADMIN_NAME"].ToString();
            //            // strBudget_type = ds.Tables[0].Rows[0]["person_budget_type"].ToString();

            //            //if (cboBudget_type.Items.FindByValue(strBudget_type) != null)
            //            //{
            //            //    cboBudget_type.SelectedIndex = -1;
            //            //    cboBudget_type.Items.FindByValue(strBudget_type).Selected = true;
            //            //}

            //            // strbudget_plan_code = ds.Tables[0].Rows[0]["budget_plan_code"].ToString();
            //            // strbudget_name = ds.Tables[0].Rows[0]["budget_name"].ToString();
            //            // strproduce_name = ds.Tables[0].Rows[0]["produce_name"].ToString();
            //            //  stractivity_name = ds.Tables[0].Rows[0]["activity_name"].ToString();
            //            //  strplan_name = ds.Tables[0].Rows[0]["plan_name"].ToString();
            //            //  strwork_name = ds.Tables[0].Rows[0]["work_name"].ToString();
            //            //  strfund_name = ds.Tables[0].Rows[0]["fund_name"].ToString();
            //            //  strdirector_name = ds.Tables[0].Rows[0]["director_name"].ToString();
            //            //   strunit_name = ds.Tables[0].Rows[0]["unit_name"].ToString();
            //            //   strbudget_plan_year = ds.Tables[0].Rows[0]["budget_plan_year"].ToString();
            //            strperson_work_status = "01";



            //            //Tab 3
            //            strperson_sex = getSex(ds.Tables[0].Rows[0]["GENDER_NAME"]);
            //            // strperson_width = ds.Tables[0].Rows[0]["person_width"].ToString();
            //            // strperson_high = ds.Tables[0].Rows[0]["person_high"].ToString();
            //            // strperson_origin = ds.Tables[0].Rows[0]["person_origin"].ToString();
            //            // strperson_nation = ds.Tables[0].Rows[0]["person_nation"].ToString();
            //            // strperson_religion = ds.Tables[0].Rows[0]["person_religion"].ToString();
            //            strperson_birth = ds.Tables[0].Rows[0]["BIRTHDAY"].ToString();
            //            strperson_marry = getMarry(ds.Tables[0].Rows[0]["MARRIED_NAME"]);
            //            //Tab 4
            //            // strperson_room = ds.Tables[0].Rows[0]["person_room"].ToString();
            //            //  strperson_floor = ds.Tables[0].Rows[0]["person_floor"].ToString();
            //            // strperson_village = ds.Tables[0].Rows[0]["person_village"].ToString();
            //            strperson_homeno = ds.Tables[0].Rows[0]["HOMEADD"].ToString();
            //            strperson_soi = ds.Tables[0].Rows[0]["SOI"].ToString();
            //            strperson_moo = ds.Tables[0].Rows[0]["MOO"].ToString();
            //            strperson_road = ds.Tables[0].Rows[0]["STREET"].ToString();
            //            strperson_tambol = ds.Tables[0].Rows[0]["DISTRICT"].ToString();
            //            strperson_aumphur = ds.Tables[0].Rows[0]["AMPHUR"].ToString();
            //            strperson_province = ds.Tables[0].Rows[0]["PROVINCE_NAME_TH"].ToString();
            //            strperson_postno = ds.Tables[0].Rows[0]["ZIPCODE"].ToString();
            //            //strperson_tel = ds.Tables[0].Rows[0]["person_tel"].ToString();
            //            // strperson_contact = ds.Tables[0].Rows[0]["person_contact"].ToString();
            //            //strperson_ralation = ds.Tables[0].Rows[0]["person_ralation"].ToString();
            //            // strperson_contact_tel = ds.Tables[0].Rows[0]["person_contact_tel"].ToString();

            //            strBudget_type = "B";


            //            #endregion

            //            #region set Control
            //            TabContainer1.Tabs[1].Visible = true;
            //            //Tab 1 
            //            txtperson_code.Text = strperson_code;
            //            Session["person_code"] = strperson_code;
            //            InitcboTitle();
            //            if (cboTitle.Items.FindByValue(strtitle_code) != null)
            //            {
            //                cboTitle.SelectedIndex = -1;
            //                cboTitle.Items.FindByValue(strtitle_code).Selected = true;
            //            }
            //            txtperson_thai_name.Text = strperson_thai_name;
            //            txtperson_thai_surname.Text = strperson_thai_surname;
            //            txtperson_eng_name.Text = strperson_eng_name;
            //            txtperson_eng_surname.Text = strperson_eng_surname;
            //            txtperson_nickname.Text = strperson_nickname;
            //            txtperson_id.Text = strperson_id;
            //            txtperson_pic.Text = strperson_pic;
            //            if (strperson_pic.Length != 0)
            //            {
            //                imgPerson.ImageUrl = "../../person_pic/" + strperson_pic;
            //            }
            //            else
            //            {
            //                imgPerson.ImageUrl = "../../person_pic/image_n_a.jpg";
            //            }
            //            txtUpdatedBy.Text = strUpdatedBy;
            //            txtUpdatedDate.Text = strUpdatedDate;

            //            if (strC_active.Equals("Y"))
            //            {
            //                chkStatus.Checked = true;
            //            }
            //            else
            //            {
            //                chkStatus.Checked = false;
            //            }


            //            //Tab 2 

            //            InitcboBudgetType();
            //            if (cboBudget_type.Items.FindByValue(strBudget_type) != null)
            //            {
            //                cboBudget_type.SelectedIndex = -1;
            //                cboBudget_type.Items.FindByValue(strBudget_type).Selected = true;
            //            }
            //            ChangeLabelBudget();

            //            txtposition_code.Text = strposition_code;
            //            txtposition_name.Text = strposition_name;

            //            txtperson_level.Text = strperson_level;
            //            txtlevel_position_name.Text = strperson_level_name;
            //            txttype_position_code.Text = strtype_position_code;
            //            txttype_position_name.Text = strtype_position_name;

            //            txtperson_postionno.Text = strperson_postionno;
            //            InitcboPerson_group();
            //            if (cboPerson_group.Items.FindByValue(strperson_group) != null)
            //            {
            //                cboPerson_group.SelectedIndex = -1;
            //                cboPerson_group.Items.FindByValue(strperson_group).Selected = true;
            //            }
            //            try
            //            {
            //                txtperson_start.Text = cCommon.CheckDate(strperson_start);
            //            }
            //            catch { }
            //            try
            //            {
            //                txtperson_end.Text = cCommon.CheckDate(strperson_end);
            //            }
            //            catch { }
            //            txtperson_manage_code.Text = strperson_manage_code;
            //            txtperson_manage_name.Text = strperson_manage_name;
            //            txtbudget_plan_code.Text = strbudget_plan_code;
            //            txtbudget_name.Text = strbudget_name;
            //            txtproduce_name.Text = strproduce_name;
            //            txtactivity_name.Text = stractivity_name;
            //            txtplan_name.Text = strplan_name;
            //            txtwork_name.Text = strwork_name;
            //            txtfund_name.Text = strfund_name;
            //            txtdirector_name.Text = strdirector_name;
            //            txtunit_name.Text = strunit_name;
            //            txtbudget_plan_year.Text = strbudget_plan_year;
            //            InitcboPerson_work_status();
            //            if (cboPerson_work_status.Items.FindByValue(strperson_work_status) != null)
            //            {
            //                cboPerson_work_status.SelectedIndex = -1;
            //                cboPerson_work_status.Items.FindByValue(strperson_work_status).Selected = true;
            //            }




            //            #endregion
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message.ToString();
            //}
        }

        public static string getNumber(object pNumber)
        {
            if (!pNumber.ToString().Equals(""))
            {
                string strNumber = String.Format("{0:#,##0.00}", double.Parse(pNumber.ToString()));
                return strNumber;
            }
            return "";
        }
    }
}