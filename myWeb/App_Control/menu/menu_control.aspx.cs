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

namespace myWeb.App_Control.menu
{
    public partial class menu_control : PageBase
    {
        #region private data
        private string strConn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        private bool[] blnAccessRight = new bool[5] { false, false, false, false, false };
        private string strPrefixCtr_main = "ctl00$ContentPlaceHolder1$TabContainer1$";
        #endregion

        public static string getItemtype(object mData)
        {
            if (mData.Equals("D"))
            {
                return "Debit";
            }
            else
            {
                return "Credit";
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {

                InitcboMenuParent();

                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/controls/save2.jpg'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/controls/save.jpg'");

                #region set QueryString
                if (Request.QueryString["MenuId"] != null)
                {
                    ViewState["MenuID"] = Request.QueryString["MenuId"].ToString();
                }
                if (Request.QueryString["page"] != null)
                {
                    ViewState["page"] = Request.QueryString["page"].ToString();
                }
                else
                {
                    ViewState["page"] = Request.QueryString["1"].ToString();
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

                if (ViewState["mode"].ToString().ToLower().Equals("add"))
                {
                }
                else if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    setData();
                    //txtloginname.ReadOnly = true;
                    //txtloginname.CssClass = "textboxdis";
                }

                #endregion



            }
        }

        #region private function

        private void InitcboMenuParent()
        {
            cMenu oMenu = new cMenu();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strMenuParent = string.Empty;
            strMenuParent = cboMenuParent.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and [Status]='Y' Order by MenuName";
            if (oMenu.SP_MENU_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboMenuParent.Items.Clear();
                cboMenuParent.Items.Add(new ListItem("---- กรุณาเลือกข้อมูล ----", "0"));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboMenuParent.Items.Add(new ListItem(dt.Rows[i]["MenuName"].ToString(), dt.Rows[i]["MenuID"].ToString()));
                }
                if (cboMenuParent.Items.FindByValue(strMenuParent) != null)
                {
                    cboMenuParent.SelectedIndex = -1;
                    cboMenuParent.Items.FindByValue(strMenuParent).Selected = true;
                }
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.imgSaveOnly.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveOnly_Click);
            //this.imgSave.Click += new System.Web.UI.ImageClickEventHandler(this.imgSave_Click);

        }
        #endregion

        private bool saveData()
        {
            bool blnResult = false;
            bool blnDup = false;
            string strMessage = string.Empty;
            //Tab 1 
            string
            pMenuID = string.Empty,
            pMenuName = string.Empty,
            pMenuNavigationUrl = string.Empty,
            pMenuImageUrl = string.Empty,
            pMenuTarget = string.Empty,
            pMenuParent = string.Empty,
            pMenuOrder = string.Empty,
            pCanView = string.Empty,
            pCanInsert = string.Empty,
            pCanEdit = string.Empty,
            pCanDelete = string.Empty,
            pCanApprove = string.Empty,
            pCanExtra = string.Empty,
            pStatus = string.Empty,
            strRemark = string.Empty,
            strCreatedBy = string.Empty,
            strUpdatedBy = string.Empty;
            string strScript = string.Empty;
            cMenu oMenu = new cMenu();
            DataSet ds = new DataSet();
            try
            {
                #region set Data
                pMenuID = hddMenuID.Value.ToString();
                pMenuName = txtMenuName.Text;
                pMenuNavigationUrl = txtMenuNavigationUrl.Text;
                pMenuImageUrl = txtMenuImageUrl.Text;
                pMenuTarget = cboMenuTarget.SelectedValue;
                pMenuParent = cboMenuParent.SelectedValue;
                pMenuOrder = txtMenuOrder.Value.ToString();
                pCanView = chkCanView.Checked ? "Y" : "N";
                pCanInsert = chkCanInsert.Checked ? "Y" : "N";
                pCanEdit = chkCanEdit.Checked ? "Y" : "N";
                pCanDelete = chkCanDelete.Checked ? "Y" : "N";
                pCanApprove = chkCanApprove.Checked ? "Y" : "N";
                pCanExtra = chkCanExtra.Checked ? "Y" : "N";
                pStatus = chkStatus.Checked ? "Y" : "N";
                strRemark = txtRemark.Text;
                strCreatedBy = Session["username"].ToString();
                strUpdatedBy = Session["username"].ToString();
                #endregion
                if (ViewState["mode"].ToString().ToLower().Equals("edit"))
                {
                    #region edit

                    #region check dup
                    string strCheckDup = string.Empty;
                    strCheckDup = " and MenuName = '" + pMenuName + "'  and [MenuName] <> '" + hddMenuName.Value.ToString() + "' ";
                    if (!oMenu.SP_MENU_SEL(strCheckDup, ref ds, ref strMessage))
                    {
                        lblError.Text = strMessage;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strScript =
                                "alert(\"ไม่สามารถแก้ไขข้อมูลได้ เนื่องจาก" +
                                "\\nข้อมูล ชื่อเมนู : " + pMenuName.Trim() +
                                "\\nซ้ำ\");\n";
                            blnDup = true;
                        }
                    }
                    #endregion
                    if (!blnDup)
                    {
                        if (oMenu.SP_MENU_UPD(pMenuID, pMenuName, pMenuNavigationUrl, pMenuImageUrl, pMenuTarget, pMenuParent, pMenuOrder, pCanView,
                               pCanInsert, pCanEdit, pCanDelete, pCanApprove, pCanExtra, pStatus, strRemark, strUpdatedBy, ref strMessage))
                        {
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
                    strCheckDup = " and [MenuName] = '" + pMenuName + "' ";
                    if (!oMenu.SP_MENU_SEL(strCheckDup, ref ds, ref strMessage))
                    {
                        lblError.Text = strMessage;
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strScript =
                                "alert(\"ไม่สามารถเพิ่มข้อมูลได้ เนื่องจาก" +
                                "\\nข้อมูล เมนู : " + pMenuName.Trim() +
                                "\\nซ้ำ\");\n";
                            blnDup = true;
                        }
                    }
                    #endregion

                    #region insert
                    if (!blnDup)
                    {
                        if (oMenu.SP_MENU_INS(pMenuName, pMenuNavigationUrl, pMenuImageUrl, pMenuTarget, pMenuParent, pMenuOrder, pCanView,
                               pCanInsert, pCanEdit, pCanDelete, pCanApprove, pCanExtra, pStatus, strRemark, strUpdatedBy, ref strMessage))
                        {

                            string strCode = " and [MenuName] = '" + pMenuName + "' ";
                            if (!oMenu.SP_MENU_SEL(strCheckDup, ref ds, ref strMessage))
                            {
                                lblError.Text = strMessage;
                            }
                            else
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ViewState["MenuID"] = ds.Tables[0].Rows[0]["MenuID"].ToString();
                                }
                            }
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
                oMenu.Dispose();
            }
            return blnResult;
        }

        private void imgSaveOnly_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (saveData())
            {
                MsgBox("บันทึกข้อมูลสมบูรณ์");
                string strScript1 = "ClosePopUpListPost('" + ViewState["page"].ToString() + "','1');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", strScript1, true);
            }
        }

        private void setData()
        {
            cMenu oMenu = new cMenu();
            DataSet ds = new DataSet();
            string strMessage = string.Empty, strCriteria = string.Empty;

            try
            {
                strCriteria = " and MenuID = '" + ViewState["MenuID"].ToString() + "' ";
                if (!oMenu.SP_MENU_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        #region get Data
                        
                        hddMenuID.Value = ds.Tables[0].Rows[0]["MenuID"].ToString();
                        txtMenuName.Text = ds.Tables[0].Rows[0]["MenuName"].ToString();
                        hddMenuName.Value = ds.Tables[0].Rows[0]["MenuName"].ToString();
                        txtMenuNavigationUrl.Text = ds.Tables[0].Rows[0]["MenuNavigationUrl"].ToString();
                        txtMenuImageUrl.Text = ds.Tables[0].Rows[0]["MenuImageUrl"].ToString();
                        if (cboMenuTarget.Items.FindByValue(ds.Tables[0].Rows[0]["MenuTarget"].ToString()) != null)
                        {
                            cboMenuTarget.SelectedIndex = -1;
                            cboMenuTarget.Items.FindByValue(ds.Tables[0].Rows[0]["MenuTarget"].ToString()).Selected = true;
                        }
                        InitcboMenuParent();
                        if (cboMenuParent.Items.FindByValue(ds.Tables[0].Rows[0]["MenuParent"].ToString()) != null)
                        {
                            cboMenuParent.SelectedIndex = -1;
                            cboMenuParent.Items.FindByValue(ds.Tables[0].Rows[0]["MenuParent"].ToString()).Selected = true;
                        }
                        txtMenuOrder.Value = ds.Tables[0].Rows[0]["MenuOrder"].ToString();
                        chkCanView.Checked = ds.Tables[0].Rows[0]["CanView"].ToString() == "Y" ? true : false;
                        chkCanInsert.Checked = ds.Tables[0].Rows[0]["CanInsert"].ToString() == "Y" ? true : false;
                        chkCanEdit.Checked = ds.Tables[0].Rows[0]["CanEdit"].ToString() == "Y" ? true : false;
                        chkCanDelete.Checked = ds.Tables[0].Rows[0]["CanDelete"].ToString() == "Y" ? true : false;
                        chkCanApprove.Checked = ds.Tables[0].Rows[0]["CanApprove"].ToString() == "Y" ? true : false;
                        chkCanExtra.Checked = ds.Tables[0].Rows[0]["CanExtra"].ToString() == "Y" ? true : false;
                        chkStatus.Checked = ds.Tables[0].Rows[0]["Status"].ToString() == "Y" ? true : false;
                        txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                        txtUpdatedBy.Text = ds.Tables[0].Rows[0]["UpdatedBy"].ToString(); ;
                        txtUpdatedDate.Text = ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "" ? cCommon.CheckDate(ds.Tables[0].Rows[0]["UpdatedDate"].ToString()) : "";

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

    }
}