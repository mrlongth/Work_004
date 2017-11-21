using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using myDLL;
using DevExpress.Web.ASPxRoundPanel;

namespace myWeb
{
    public class PageBase : Page
    {

        #region Public Fields

        public bool _boolResult;
        public string _strMessage = string.Empty;
        public enum Mode { SEARCH, NEW, EDIT, VIEW };
        public string _strCriteria;


        #endregion

        #region Property General


        public string IsLogin
        {
            get
            {
                if (Session["IsLogin"] == null)
                {
                    Session["IsLogin"] = "N";
                }
                return Session["IsLogin"].ToString();
            }
            set
            {
                Session["IsLogin"] = value;
            }
        }

        public string PageTitle
        {
            get
            {
                if (ViewState["PageTitle"] == null)
                {
                    ViewState["PageTitle"] = string.Format(Resources.Resource.PageTitle, string.Empty, ProgramVersion);
                }
                return ViewState["PageTitle"].ToString();
            }
            set
            {
                ViewState["PageTitle"] = value;
            }
        }

        public string PageDes
        {
            get
            {
                if (ViewState["PageDes"] == null)
                {
                    ViewState["PageDes"] = string.Format(Resources.Resource.PageTitle, string.Empty, ProgramVersion);
                }
                return ViewState["PageDes"].ToString();
            }
            set
            {
                ViewState["PageDes"] = value;
            }
        }



        private string ProgramVersion
        {
            get
            {
                try
                {
                    ViewState["ProgramVersion"] = ConfigurationManager.AppSettings["ProgramVersion"].ToString();
                }
                catch
                {
                    ViewState["ProgramVersion"] = "ระบบบริหารจัดการงบประมาณ คณะผลิตกรรมการเกษตร มหาวิทยาลัยแม่โจ้ เชียงใหม่";
                }
                return ViewState["ProgramVersion"].ToString();
            }
            set
            {
                ViewState["ProgramVersion"] = value;
            }
        }

        //public int UserID
        //{
        //    get
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            Session["UserID"] = "0";
        //        }
        //        return int.Parse(Session["UserID"].ToString());
        //    }
        //    set
        //    {
        //        Session["UserID"] = value;
        //    }
        //}

        public string UserLoginName
        {
            get
            {
                if (Session["LoginName"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["LoginName"].ToString();
                }
            }
            set
            {
                Session["LoginName"] = value;
            }
        }

        public string PersonGroupList
        {
            get
            {
                //if (Session["LoginName"] == null)
                //{
                //    GetUserProfile();
                //}
                //return Session["LoginName"].ToString();
                if (Session["PersonGroupList"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["PersonGroupList"].ToString();
                }
            }
            set
            {
                Session["PersonGroupList"] = value;
            }
        }

        public string DirectorLock
        {
            get
            {
                if (Session["DirectorLock"] == null)
                {
                    Session["DirectorLock"] = "N";
                }
                return Session["DirectorLock"].ToString();
            }
            set
            {
                Session["DirectorLock"] = value;
            }
        }


        public string MajorLock
        {
            get
            {
                if (Session["MajorLock"] == null)
                {
                    Session["MajorLock"] = "N";
                }
                return Session["MajorLock"].ToString();
            }
            set
            {
                Session["MajorLock"] = value;
            }
        }

        public string PersonMajorCode
        {
            get
            {
                if (Session["PersonMajorCode"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["PersonMajorCode"].ToString();
                }
            }
            set
            {
                Session["PersonMajorCode"] = value;
            }
        }

        public string PersonMajorName
        {
            get
            {
                if (Session["PersonMajorName"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["PersonMajorName"].ToString();
                }
            }
            set
            {
                Session["PersonMajorName"] = value;
            }
        }

        public string PersonMajorAbbrev
        {
            get
            {
                if (Session["PersonMajoAbbrev"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["PersonMajoAbbrev"].ToString();
                }
            }
            set
            {
                Session["PersonMajoAbbrev"] = value;
            }
        }


        


        public string UserGroupList
        {
            get
            {
                if (Session["UserGroupList"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["UserGroupList"].ToString();
                }
            }
            set
            {
                Session["UserGroupList"] = value;
            }
        }

        public string UserGroupCode
        {
            get
            {
                if (Session["UserGroupCode"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["UserGroupCode"].ToString();
                }
            }
            set
            {
                Session["UserGroupCode"] = value;
            }
        }


        public string PersonId
        {
            get
            {
                if (Session["PersonId"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["PersonId"].ToString();
                }
            }
            set
            {
                Session["PersonId"] = value;
            }
        }



        public string DirectorCode
        {
            get
            {
                if (Session["DirectorCode"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["DirectorCode"].ToString();
                }
            }
            set
            {
                Session["DirectorCode"] = value;
            }
        }

        public string DirectorName
        {
            get
            {
                if (Session["DirectorName"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["DirectorName"].ToString();
                }
            }
            set
            {
                Session["DirectorName"] = value;
            }
        }

        public string LotCodeList
        {
            get
            {
                if (Session["LotCodeList"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["LotCodeList"].ToString();
                }
            }
            set
            {
                Session["LotCodeList"] = value;
            }
        }

        public string UserNameEN
        {
            get
            {
                if (Session["NameEN"] == null)
                {
                    Session["NameEN"] = string.Empty;
                }
                return Session["NameEN"].ToString();
            }
            set
            {
                Session["NameEN"] = value;
            }
        }

        public bool IsUserNew
        {
            get { return (bool)ViewState["IsUserNew"]; }
            set { ViewState["IsUserNew"] = value; }
        }

        public bool IsUserView
        {
            get { return (bool)ViewState["IsUserView"]; }
            set { ViewState["IsUserView"] = value; }
        }

        public bool IsUserEdit
        {
            get { return (bool)ViewState["IsUserEdit"]; }
            set { ViewState["IsUserEdit"] = value; }
        }

        public bool IsUserDelete
        {
            get { return (bool)ViewState["IsUserDelete"]; }
            set { ViewState["IsUserDelete"] = value; }
        }

        public bool IsUserApprove
        {
            get { return (bool)ViewState["IsUserApprove"]; }
            set { ViewState["IsUserApprove"] = value; }
        }

        public bool IsUserExtra
        {
            get { return (bool)ViewState["IsUserExtra"]; }
            set { ViewState["IsUserExtra"] = value; }
        }

        public string myBudgetType
        {
            get
            {
                if (Request.QueryString["budget_type"] != null)
                {
                    Session["myBudgetType"] = Request.QueryString["budget_type"].ToString();
                }
                else
                {
                    Session["myBudgetType"] = "B";
                }
                return Helper.CStr(Session["myBudgetType"]);
            }
            //set
            //{
            //    Session["myBudgetType"] = value;
            //}
        }



        #endregion
        
        public void InitUserAccessRight()
        {
            string currentUrl = this.GetCurrentUrl();
            string strMessage = string.Empty;

            cUser_group_menu objUserBLL = new cUser_group_menu();
            DataSet ds = new DataSet();
            DataTable table;
            string strCriteria;
            if (currentUrl.Contains("budget_money_control.aspx"))
            {
                if (currentUrl.Contains("budget_type=B"))
                    currentUrl = @"~/App_Control/budget_money/budget_money_list.aspx?budget_type=B";
                else
                    currentUrl = @"~/App_Control/budget_money/budget_money_list.aspx?budget_type=R";
            }
            else if (currentUrl.Contains("budget_receive_control.aspx"))
            {
                if (currentUrl.Contains("budget_type=B"))
                    currentUrl = @"~/App_Control/budget_receive/budget_receive_list.aspx?budget_type=B";
                else
                    currentUrl = @"~/App_Control/budget_receive/budget_receive_list.aspx?budget_type=R";
            }
            else if (currentUrl.Contains("budget_open_control.aspx"))
            {
                if (currentUrl.Contains("budget_type=B"))
                    currentUrl = @"~/App_Control/budget_open/budget_open_list.aspx?budget_type=B";
                else
                    currentUrl = @"~/App_Control/budget_open/budget_open_list.aspx?budget_type=R";
            }
            else if (currentUrl.Contains("budget_transfer_control.aspx"))
            {
                if (currentUrl.Contains("budget_type=B"))
                    currentUrl = @"~/App_Control/budget_transfer/budget_transfer_list.aspx?budget_type=B";
                else
                    currentUrl = @"~/App_Control/budget_transfer/budget_transfer_list.aspx?budget_type=R";
            }

            strCriteria = " And user_group_code='" + this.UserGroupCode + "'  And  MenuNavigationUrl='" + currentUrl + "' ";
            objUserBLL.SP_USER_GROUP_MENU_SEL(strCriteria, ref ds, ref strMessage);
            if (ds.Tables.Count > 0)
            {
                table = ds.Tables[0];
                if (table.Rows.Count > 0)
                {
                    IsUserView = false;
                    IsUserNew = false;
                    IsUserEdit = false;
                    IsUserDelete = false;
                    IsUserApprove = false;
                    IsUserExtra = false;
                    DataRow rowArray = table.Rows[0];
                    string str6 = rowArray["CanView"].ToString();
                    string str5 = rowArray["CanInsert"].ToString();
                    string str3 = rowArray["CanEdit"].ToString();
                    string str2 = rowArray["CanDelete"].ToString();
                    string str = rowArray["CanApprove"].ToString();
                    string str4 = rowArray["CanExtra"].ToString();

                    if (str == "N" && str2 == "N" && str3 == "N" && str4 == "N" && str5 == "N" && str6 == "N")
                    {
                        Response.Redirect("~/Default.aspx?op=NotAccess");
                        return;
                    }
                    else
                    {

                        if (str6 == "Y")
                        {
                            IsUserView = true;
                        }
                        if (str5 == "Y")
                        {
                            IsUserNew = true;
                        }
                        if (str3 == "Y")
                        {
                            IsUserEdit = true;
                        }
                        if (str2 == "Y")
                        {
                            IsUserDelete = true;
                        }
                        if (str == "Y")
                        {
                            IsUserApprove = true;
                        }
                        if (str4 == "Y")
                        {
                            IsUserExtra = true;
                        }
                        PageTitle = string.Format(Resources.Resource.PageTitle, rowArray["MenuName"].ToString(), ProgramVersion);
                        PageDes = rowArray["MenuName"].ToString();
                    }
                }
                table.Dispose();
            }


        }

        private string GetCurrentUrl()
        {
            string str2 = this.Page.AppRelativeVirtualPath.ToString();
            if (this.Page.ClientQueryString.ToString() != string.Empty)
            {
                str2 = str2 + "?" + this.Page.ClientQueryString;
            }
            return str2;
        }

        public void MsgBox(string strMessage)
        {
            UpdatePanel oUpdatePanel;
            string strScript = string.Empty;
            strScript = "alert('" + strMessage + "');";
            oUpdatePanel = (UpdatePanel)this.Master.FindControl("updatePanel1");
            ScriptManager.RegisterClientScriptBlock(oUpdatePanel, oUpdatePanel.GetType(), "MessageBox", strScript, true);
        }

        protected override void OnPreLoad(System.EventArgs e)
        {
            base.OnPreLoad(e);
            if (!IsPostBack)
            {
                if (this.Master != null)
                {
                    this.InitUserAccessRight();
                    if (Master.FindControl("lblHeader") != null)
                    {
                        ((Label)Master.FindControl("lblHeader")).Text = PageDes;
                    
                    }
                    //GenerateMenu();
                }
            }
            else
            {
                InitUserAccessRight();
            }
            Title = PageTitle;
        }

        protected override void OnLoad(EventArgs e)
        {
            SetProfile();
            base.OnLoad(e);
        }

    
        protected void SetProfile()
        {
            if (Application["xmlconfig"] == null)
            {
                try
                {
                    #region read xml config file store to variable
                    cAware.Profile.Xml oXml = new cAware.Profile.Xml();
                    oXml.Name = Server.MapPath("xml\\") + System.Configuration.ConfigurationSettings.AppSettings["xmlconfig"];
                    DataSet ds = new DataSet();
                    DataTable dt;
                    DataRow rw;
                    int i = 0;

                    #region "Record Per Page"
                    dt = new DataTable("RecordPerPage");
                    dt.Columns.Add("Text");
                    dt.Columns.Add("Value");

                    string[] entries = oXml.GetEntryNames("RecordPerPage");
                    for (i = 0; i < entries.Length; i++)
                    {
                        rw = dt.NewRow();
                        rw[0] = entries[i].ToString();
                        rw[1] = oXml.GetValue("RecordPerPage", entries[i].ToString(), "");
                        dt.Rows.Add(rw);
                    }
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgFind"
                    dt = new DataTable("imgFind");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgFind", "img");
                    rw[1] = oXml.GetValue("imgFind", "title");
                    rw[2] = oXml.GetValue("imgFind", "imgdisable");
                    rw[3] = oXml.GetValue("imgFind", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgNew"
                    dt = new DataTable("imgNew");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgNew", "img");
                    rw[1] = oXml.GetValue("imgNew", "title");
                    rw[2] = oXml.GetValue("imgNew", "imgdisable");
                    rw[3] = oXml.GetValue("imgNew", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgView"
                    dt = new DataTable("imgView");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgView", "img");
                    rw[1] = oXml.GetValue("imgView", "title");
                    rw[2] = oXml.GetValue("imgView", "imgdisable");
                    rw[3] = oXml.GetValue("imgView", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgEdit"
                    dt = new DataTable("imgEdit");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgEdit", "img");
                    rw[1] = oXml.GetValue("imgEdit", "title");
                    rw[2] = oXml.GetValue("imgEdit", "imgdisable");
                    rw[3] = oXml.GetValue("imgEdit", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgEditMain"
                    //imgEditMain
                    dt = new DataTable("imgEditMain");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgEditMain", "img");
                    rw[1] = oXml.GetValue("imgEditMain", "title");
                    rw[2] = oXml.GetValue("imgEditMain", "imgdisable");
                    rw[3] = oXml.GetValue("imgEditMain", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgLock"
                    dt = new DataTable("imgLock");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgLock", "img");
                    rw[1] = oXml.GetValue("imgLock", "title");
                    rw[2] = oXml.GetValue("imgLock", "imgdisable");
                    rw[3] = oXml.GetValue("imgLock", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgDelete"
                    dt = new DataTable("imgDelete");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgDelete", "img");
                    rw[1] = oXml.GetValue("imgDelete", "title");
                    rw[2] = oXml.GetValue("imgDelete", "imgdisable");
                    rw[3] = oXml.GetValue("imgDelete", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "colorDataGridRow"
                    dt = new DataTable("colorDataGridRow");
                    dt.Columns.Add("Even");
                    dt.Columns.Add("Odd");
                    dt.Columns.Add("MouseOver");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("colorDataGridRow", "Even");
                    rw[1] = oXml.GetValue("colorDataGridRow", "Odd");
                    rw[2] = oXml.GetValue("colorDataGridRow", "MouseOver");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgSave"
                    dt = new DataTable("imgSave");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgSave", "img");
                    rw[1] = oXml.GetValue("imgSave", "title");
                    rw[2] = oXml.GetValue("imgSave", "imgdisable");
                    rw[3] = oXml.GetValue("imgSave", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgSaveOnly"
                    dt = new DataTable("imgSaveOnly");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgSaveOnly", "img");
                    rw[1] = oXml.GetValue("imgSaveOnly", "title");
                    rw[2] = oXml.GetValue("imgSaveOnly", "imgdisable");
                    rw[3] = oXml.GetValue("imgSaveOnly", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgSaveAdd"
                    dt = new DataTable("imgSaveAdd");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgSaveAdd", "img");
                    rw[1] = oXml.GetValue("imgSaveAdd", "title");
                    rw[2] = oXml.GetValue("imgSaveAdd", "imgdisable");
                    rw[3] = oXml.GetValue("imgSaveAdd", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgClose"
                    dt = new DataTable("imgClose");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgClose", "img");
                    rw[1] = oXml.GetValue("imgClose", "title");
                    rw[2] = oXml.GetValue("imgClose", "imgdisable");
                    rw[3] = oXml.GetValue("imgClose", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgAsc"
                    dt = new DataTable("imgAsc");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgAsc", "img");
                    rw[1] = oXml.GetValue("imgAsc", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgDesc"
                    dt = new DataTable("imgDesc");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgDesc", "img");
                    rw[1] = oXml.GetValue("imgDesc", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgClear"
                    dt = new DataTable("imgClear");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgClear", "img");
                    rw[1] = oXml.GetValue("imgClear", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgList"
                    dt = new DataTable("imgList");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgList", "img");
                    rw[1] = oXml.GetValue("imgList", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgViewDetail"
                    dt = new DataTable("imgViewDetail");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgViewDetail", "img");
                    rw[1] = oXml.GetValue("imgViewDetail", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgGo"
                    dt = new DataTable("imgGo");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgGo", "img");
                    rw[1] = oXml.GetValue("imgGo", "title");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgStatus"
                    dt = new DataTable("imgStatus");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgStatus", "img");
                    rw[1] = oXml.GetValue("imgStatus", "title");
                    rw[2] = oXml.GetValue("imgStatus", "imgdisable");
                    rw[3] = oXml.GetValue("imgStatus", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "HardCode"
                    dt = new DataTable("MemberType");
                    dt.Columns.Add("GBK");
                    dt.Columns.Add("GSJ");
                    dt.Columns.Add("SOS");
                    dt.Columns.Add("GBK2");
                    dt.Columns.Add("PVD");
                    dt.Columns.Add("GSJ2");
                
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("MemberType", "GBK");
                    rw[1] = oXml.GetValue("MemberType", "GSJ");
                    rw[2] = oXml.GetValue("MemberType", "SOS");
                    rw[3] = oXml.GetValue("MemberType", "GBK2");
                    rw[4] = oXml.GetValue("MemberType", "PVD");
                    rw[5] = oXml.GetValue("MemberType", "GSJ2");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "cboYear"
                    dt = new DataTable("cboYear");
                    dt.Columns.Add("Text");
                    dt.Columns.Add("Value");
                    entries = oXml.GetEntryNames("cboYear");
                    for (i = 0; i < entries.Length; i++)
                    {
                        rw = dt.NewRow();
                        rw[0] = entries[i].ToString();
                        rw[1] = oXml.GetValue("cboYear", entries[i].ToString(), "");
                        dt.Rows.Add(rw);
                    }
                    ds.Tables.Add(dt);
                    #endregion

                    #region "cboMonth"
                    dt = new DataTable("cboMonth");
                    dt.Columns.Add("Value");
                    dt.Columns.Add("Text");
                    entries = oXml.GetEntryNames("cboMonth");
                    for (i = 0; i < entries.Length; i++)
                    {
                        rw = dt.NewRow();
                        rw[0] = entries[i].ToString();
                        rw[1] = oXml.GetValue("cboMonth", entries[i].ToString(), "");
                        dt.Rows.Add(rw);
                    }
                    ds.Tables.Add(dt);
                    #endregion

                    #region "imgGridAdd"
                    dt = new DataTable("imgGridAdd");
                    dt.Columns.Add("img");
                    dt.Columns.Add("title");
                    dt.Columns.Add("imgdisable");
                    dt.Columns.Add("titledisable");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("imgGridAdd", "img");
                    rw[1] = oXml.GetValue("imgGridAdd", "title");
                    rw[2] = oXml.GetValue("imgGridAdd", "imgdisable");
                    rw[3] = oXml.GetValue("imgGridAdd", "titledisable");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    #region "Document Default"
                    dt = new DataTable("default");
                    dt.Columns.Add("pagetitle");
                    dt.Columns.Add("yearnow");
                    dt.Columns.Add("companyname");
                    dt.Columns.Add("work_status");
                    dt.Columns.Add("SOS_MAX");
                    dt.Columns.Add("SOS_MIN");
                    rw = dt.NewRow();
                    rw[0] = oXml.GetValue("default", "pagetitle");
                    rw[1] = oXml.GetValue("default", "yearnow");
                    rw[2] = oXml.GetValue("default", "companyname");
                    rw[3] = oXml.GetValue("default", "work_status");
                    rw[4] = oXml.GetValue("default", "SOS_MAX");
                    rw[5] = oXml.GetValue("default", "SOS_MIN");
                    dt.Rows.Add(rw);
                    ds.Tables.Add(dt);
                    #endregion

                    Application["xmlconfig"] = ds;

                    #endregion
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }

        public string GetConfigItem(string strCode)
        {
            string strMessage = string.Empty;

            var objCommon = new cCommon();
            var ds = new DataSet();
            DataTable table;
            var strCriteria = "Select [dbo].[getConfigCode]('" + strCode + "') as Code";
            objCommon.SEL_SQL(strCriteria, ref ds, ref strMessage);
            if (ds.Tables.Count <= 0)
            {
                return string.Empty;
            }
            table = ds.Tables[0];
            if (table.Rows.Count > 0)
            {
                var rowArray = table.Rows[0];
                return rowArray["Code"].ToString();
            }
            return string.Empty;
        }

        public void SetControlView(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is ImageButton)
                {
                    if (!ctrl.ID.Contains("imgPrint") && !ctrl.ID.Contains("imgView"))
                        ctrl.Visible = false;
                }
                else if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).ReadOnly = true;
                    ((TextBox)ctrl).CssClass = "textboxdis";
                }
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).Enabled = false;
                    ((DropDownList)ctrl).CssClass = "textboxdis";
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        SetControlView(ctrl);
                    }
                }
            }
        }


        public string GetMonth(string month)
        {
            string strMonth = string.Empty;
            if (month.Equals("01"))
            {
                strMonth = "มกราคม";
            }
            else if (month.Equals("02"))
            {
                strMonth = "กุมภาพันธ์";
            }
            else if (month.Equals("03"))
            {
                strMonth = "มีนาคม";
            }
            else if (month.Equals("04"))
            {
                strMonth = "เมษายน";
            }
            else if (month.Equals("05"))
            {
                strMonth = "พฤษภาคม";
            }
            else if (month.Equals("06"))
            {
                strMonth = "มิถุนายน";
            }
            else if (month.Equals("07"))
            {
                strMonth = "กรกฎาคม";
            }
            else if (month.Equals("08"))
            {
                strMonth = "สิงหาคม";
            }
            else if (month.Equals("09"))
            {
                strMonth = "กันยายน";
            }
            else if (month.Equals("10"))
            {
                strMonth = "ตุลาคม";
            }
            else if (month.Equals("11"))
            {
                strMonth = "พฤศจิกายน";
            }
            else if (month.Equals("12"))
            {
                strMonth = "ธันวาคม";
            }
            return strMonth;
        }


         public static void ClearDataControls(Control control)
        {

            foreach (Control ctrl in control.Controls)
            {
                if ((ctrl is TextBox))
                {
                    ((TextBox)(ctrl)).Text = string.Empty;
                }
                else if ((ctrl is DropDownList))
                {
                    ((DropDownList)(ctrl)).SelectedIndex = 0;
                }
                else if ((ctrl is CheckBox))
                {
                    ((CheckBox)(ctrl)).Checked = false;
                }
                else if ((ctrl.Controls.Count > 0))
                {
                    ClearDataControls(ctrl);
                }
            }
        }

        //public void SetLabel(Control control, String old_str, String new_str)
        //{
        //    foreach (Control ctrl in control.Controls)
        //    {
        //        if (ctrl is Label)
        //        {
        //            if (((Label)ctrl).Text.Contains(old_str))
        //            {
        //                ((Label)ctrl).Text = ((Label)ctrl).Text.Replace(old_str, new_str);
        //            }
        //        }
        //        else if (ctrl is Literal)
        //        {
        //            if (((Literal)ctrl).Text.Contains(old_str))
        //            {
        //                ((Literal)ctrl).Text = ((Literal)ctrl).Text.Replace(old_str, new_str);
        //            }
        //        }
        //        else if (ctrl is LinkButton)
        //        {
        //            if (((LinkButton)ctrl).Text.Contains(old_str))
        //            {
        //                ((LinkButton)ctrl).Text = ((LinkButton)ctrl).Text.Replace(old_str, new_str);
        //            }
        //        }
        //        else if (ctrl is HyperLink)
        //        {
        //            if (((HyperLink)ctrl).Text.Contains(old_str))
        //            {
        //                ((HyperLink)ctrl).Text = ((HyperLink)ctrl).Text.Replace(old_str, new_str);
        //            }
        //        }
        //        else if (ctrl is RadioButtonList)
        //        {
        //            foreach (ListItem ctr_sub in ((RadioButtonList)ctrl).Items)
        //            {
        //                if (((ListItem)ctr_sub).Text.Contains(old_str))
        //                {
        //                    ((ListItem)ctr_sub).Text = ((ListItem)ctr_sub).Text.Replace(old_str, new_str);
        //                }                    
        //            }
        //        }
        //        else
        //        {
        //            if (ctrl.Controls.Count > 0)
        //            {
        //                SetLabel(ctrl, old_str, new_str);
        //            }
        //        }
        //    }
        //}


    }
}
