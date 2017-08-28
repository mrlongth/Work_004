﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using myDLL;

namespace myWeb.App_Control.person
{
    public partial class person_center_list : PageBase
    {

        #region private data
        private string strRecordPerPage;
        private string strPageNo = "1";
        private bool[] blnAccessRight = new bool[5] { false, false, false, false, false };
        private string strPrefixCtr = "ctl00$ASPxRoundPanel1$ASPxRoundPanel2$ContentPlaceHolder1$";
        private string strPrefixCtr_2 = "ctl00$ASPxRoundPanel1$ContentPlaceHolder2$";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgNew.Attributes.Add("onMouseOver", "src='../../images/button/save2.png'");
                imgNew.Attributes.Add("onMouseOut", "src='../../images/button/save.png'");

                //imgPrint.Attributes.Add("onMouseOver", "src='../../images/button/print2.png'");
                //imgPrint.Attributes.Add("onMouseOut", "src='../../images/button/print.png'");

                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                imgNew.Attributes.Add("onclick", "OpenPopUp('990px','550px','95%','เพิ่มข้อมูลบุคลากร','person_control.aspx?mode=add&page=0','1');return false;");

                ViewState["sort"] = "DATE_INWORK";
                ViewState["direction"] = "DESC";
                InitcboYear();
                InitcboWork_status();
                InitcboPerson_group();
                BindGridView(0);
                InitcboUnit();
                InitcboDirector();

            }
            else
            {
                if (Request.Form[strPrefixCtr_2 + "GridView1$ctl01$cboPerPage"] != null)
                {
                    strRecordPerPage = Request.Form[strPrefixCtr_2 + "GridView1$ctl01$cboPerPage"].ToString();
                    strPageNo = Request.Form[strPrefixCtr_2 + "GridView1$ctl01$txtPage"].ToString();
                }
                if (txthpage.Value != string.Empty)
                {
                    BindGridView(int.Parse(txthpage.Value));
                    txthpage.Value = string.Empty;
                }
            }

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

        private void InitcboWork_status()
        {
            cPerson_center oPerson_center = new cPerson_center();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strperson_work_status_code = string.Empty;
            strperson_work_status_code = "";
            if (Request.Form[strPrefixCtr + "cboPerson_work_status"] != null)
            {
                strperson_work_status_code = Request.Form[strPrefixCtr + "cboPerson_work_status"].ToString();
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  1=1 ";
            if (oPerson_center.SP_PERSON_WORK_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_work_status.Items.Clear();
                cboPerson_work_status.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboPerson_work_status.Items.Add(new ListItem(dt.Rows[i]["STATUS_NAME"].ToString(), dt.Rows[i]["STATUS_WORK"].ToString()));
                }
                if (cboPerson_work_status.Items.FindByValue(strperson_work_status_code) != null)
                {
                    cboPerson_work_status.SelectedIndex = -1;
                    cboPerson_work_status.Items.FindByValue(strperson_work_status_code).Selected = true;
                }
            }
        }

        private void InitcboPerson_group()
        {
            cPerson_center oPerson_center = new cPerson_center();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strperson_group_code = string.Empty;
            strperson_group_code = cboPerson_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and 1=1 ";
            if (oPerson_center.SP_PERSON_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_group.Items.Clear();
                cboPerson_group.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboPerson_group.Items.Add(new ListItem(dt.Rows[i]["GROUP_TYPE_NAME"].ToString(), dt.Rows[i]["GROUP_TYPE"].ToString()));
                }
                if (cboPerson_group.Items.FindByValue(strperson_group_code) != null)
                {
                    cboPerson_group.SelectedIndex = -1;
                    cboPerson_group.Items.FindByValue(strperson_group_code).Selected = true;
                }
            }
        }

        private void InitcboDirector()
        {
            cPerson_center oPerson_center = new cPerson_center();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strDirector_code = string.Empty;
            string strYear = cboYear.SelectedValue;
            strDirector_code = cboDirector.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and 1=1 ";
            if (oPerson_center.SP_PERSON_DIRECTION_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboDirector.Items.Clear();
                cboDirector.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboDirector.Items.Add(new ListItem(dt.Rows[i]["FACT_NAME"].ToString(), dt.Rows[i]["FACT_NAME"].ToString()));
                }
                if (cboDirector.Items.FindByValue(strDirector_code) != null)
                {
                    cboDirector.SelectedIndex = -1;
                    cboDirector.Items.FindByValue(strDirector_code).Selected = true;
                }
            }
        }

        private void InitcboUnit()
        {
            cPerson_center oPerson_center = new cPerson_center();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strUnit_code = cboUnit.SelectedValue;
            string strDirector_code = cboDirector.SelectedValue;
            string strYear = cboYear.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and 1=1 ";
            if (oPerson_center.SP_PERSON_UNIT_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboUnit.Items.Clear();
                cboUnit.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboUnit.Items.Add(new ListItem(dt.Rows[i]["DIVISION_NAME"].ToString(), dt.Rows[i]["DIVISION_NAME"].ToString()));
                }
                if (cboUnit.Items.FindByValue(strUnit_code) != null)
                {
                    cboUnit.SelectedIndex = -1;
                    cboUnit.Items.FindByValue(strUnit_code).Selected = true;
                }
            }
        }

        #endregion

        private void cboPerPage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            GridView1.PageSize = int.Parse(strRecordPerPage);
            if (int.Parse(strPageNo) != 0)
            {
                BindGridView(int.Parse(strPageNo) - 1);
            }
            else
            {
                BindGridView(0);
            }
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
            InitcboYear();
            InitcboWork_status();
            InitcboPerson_group();
            //InitcboDirector();
            // InitcboUnit();
            cPerson_center oPerson_center = new cPerson_center();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string strYear = string.Empty;
            string strActive = string.Empty;
            string strperson_group_code = string.Empty;
            string strperson_group_name = string.Empty;
            string strdirector_code = string.Empty;
            string strunit_code = string.Empty;
            string strperson_code = string.Empty;
            string strperson_name = string.Empty;
            string strperson_work_status_code = string.Empty;
            strperson_group_code = cboPerson_group.SelectedValue;
            strdirector_code = cboDirector.SelectedValue;
            strunit_code = cboUnit.SelectedValue;
            strperson_work_status_code = cboPerson_work_status.SelectedValue;
            strYear = cboYear.SelectedValue;
            strperson_code = txtperson_code.Text.Replace("'", "''").Trim();
            strperson_name = txtperson_name.Text.Replace("'", "''").Trim();
            if (Request.Form[strPrefixCtr + "cboPerson_work_status"] != null)
            {
                strperson_work_status_code = Request.Form[strPrefixCtr + "cboPerson_work_status"].ToString();
            }

            //if (!strYear.Equals(""))
            //{
            //    strCriteria = strCriteria + "  And  (budget_plan_year = '" + strYear + "') ";
            //}

            if (!strperson_group_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (GROUP_TYPE = '" + strperson_group_code + "') ";
            }

            if (!strdirector_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (FACT_NAME = '" + strdirector_code + "') ";
            }

            if (!strunit_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (DIVISION_NAME= '" + strunit_code + "') ";
            }

            if (!strperson_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (CITIZEN_ID= '" + strperson_code + "') ";
            }

            if (!strperson_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (STF_FNAME like '%" + strperson_name + "%'  " +
                                                              "  OR STF_LNAME like '%" + strperson_name + "%'  " +
                                                              "  OR NAME_ENG like '%" + strperson_name + "%'  " +
                                                              "  OR SURNAME_ENG like '%" + strperson_name + "%')";
            }

            if (!strperson_work_status_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (STATUS_WORK = '" + strperson_work_status_code + "') ";
            }


            try
            {
                if (!oPerson_center.SP_PERSON_CENTER_SEL(strCriteria, ref ds, ref strMessage))
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
                oPerson_center.Dispose();
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
                Label lblSTF_FNAME = (Label)e.Row.FindControl("lblSTF_FNAME");
                Label lblSTF_LNAME = (Label)e.Row.FindControl("lblSTF_LNAME");
                Label lblCITIZEN_ID = (Label)e.Row.FindControl("lblCITIZEN_ID");
                Label lblCITIZEN_ID2 = (Label)e.Row.FindControl("lblCITIZEN_ID2");

                Label lblTITLE_NAME = (Label)e.Row.FindControl("lblTITLE_NAME");
                Label lblGROUP_TYPE_NAME = (Label)e.Row.FindControl("lblGROUP_TYPE_NAME");
                Label lblPOSITION_WORK = (Label)e.Row.FindControl("lblPOSITION_WORK");
                Aware.WebControls.AwNumeric lblSALARY = (Aware.WebControls.AwNumeric)e.Row.FindControl("lblSALARY");
                Aware.WebControls.AwLabelDateTime lblDATE_INWORK = (Aware.WebControls.AwLabelDateTime)e.Row.FindControl("lblDATE_INWORK");
                Label lblADMIN_NAME = (Label)e.Row.FindControl("lblADMIN_NAME");
                cCommon oCommon = new cCommon();
                DataSet ds = new DataSet();

                string strSQL = "Select * from person_his where person_id = '" + lblCITIZEN_ID2.Text+"' ";
                oCommon.SEL_SQL(strSQL, ref ds, ref _strMessage);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string strScript = "<a href=\"\" onclick=\"" +
                                          "OpenPopUp('990px','550px','95%','เพิ่มข้อมูลพนักงาน (จากกองกลางเจ้าหน้าที่)','person_control.aspx?mode=add&person_code=" +
                                          lblCITIZEN_ID.Text + "&FromPage=person_center&page=" + GridView1.PageIndex.ToString() +
                                           "&IsUserEdit=" + (IsUserEdit ? "Y" : "N") + "&IsUserDelete=" + (IsUserDelete ? "Y" : "N") +
                                           "','1');return false;\" >" + lblCITIZEN_ID2.Text + "</a>";
                    if (IsUserEdit)
                    {
                        lblCITIZEN_ID.Text = strScript;

                        lblSTF_FNAME.ForeColor = System.Drawing.Color.Red;
                        lblSTF_LNAME.ForeColor = System.Drawing.Color.Red;
                        lblCITIZEN_ID.ForeColor = System.Drawing.Color.Red;
                        lblTITLE_NAME.ForeColor = System.Drawing.Color.Red;
                        lblGROUP_TYPE_NAME.ForeColor = System.Drawing.Color.Red;
                        lblPOSITION_WORK.ForeColor = System.Drawing.Color.Red;
                        lblSALARY.ForeColor = System.Drawing.Color.Red;
                        lblDATE_INWORK.ForeColor = System.Drawing.Color.Red;
                        lblADMIN_NAME.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else 
                {

                    string strScript = "<a href=\"\" onclick=\"" +
                                        "OpenPopUp('990px','550px','95%','แก้ไขข้อมูลพนังาน','person_control.aspx?mode=edit&person_code=" +
                                        ds.Tables[0].Rows[0]["person_code"].ToString() + "&FromPage=person_center&page=" + GridView1.PageIndex.ToString() +
                                         "&IsUserEdit=" + (IsUserEdit ? "Y" : "N") + "&IsUserDelete=" + (IsUserDelete ? "Y" : "N") +
                                         "','1');return false;\" >" + lblCITIZEN_ID2.Text + "</a>";
                    lblCITIZEN_ID.Text = strScript;

                }
                ds.Dispose();

                //Label lblperson_code = (Label)e.Row.FindControl("lblperson_code");
                //Label lblperson_name = (Label)e.Row.FindControl("lblperson_name");
                //Label lblc_active = (Label)e.Row.FindControl("lblc_active");
                //string strStatus = lblc_active.Text;

                //#region set ImageStatus
                //ImageButton imgStatus = (ImageButton)e.Row.FindControl("imgStatus");
                //if (strStatus.Equals("Y"))
                //{
                //    imgStatus.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["img"].ToString();
                //    imgStatus.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["title"].ToString());
                //    imgStatus.Attributes.Add("onclick", "return false;");
                //}
                //else
                //{
                //    imgStatus.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["imgdisable"].ToString();
                //    imgStatus.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgStatus"].Rows[0]["titledisable"].ToString());
                //    imgStatus.Attributes.Add("onclick", "return false;");
                //}
                //#endregion


                //#region set ImageView
                //ImageButton imgView = (ImageButton)e.Row.FindControl("imgView");
                //imgView.Attributes.Add("onclick", "OpenPopUp('900px','500px','94%','แสดงข้อมูลบุคลากร','person_center_control.aspx?mode=view&person_code=" +
                //                                                             lblCITIZEN_ID.Text + "','1');return false;");
                //imgView.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["img"].ToString();
                //imgView.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgView"].Rows[0]["title"].ToString());
                //#endregion

                //#region set Image Edit & Delete

                //ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                //Label lblperson_names = (Label)e.Row.FindControl("lblperson_names");
                //if (IsUserEdit)
                //{
                //    lblperson_names.Text = "<a href=\"\" onclick=\"" +
                //                             "OpenPopUp('990px','550px','95%','แก้ไขข้อมูลบุคลากร','person_control.aspx?mode=edit&person_code=" +
                //                                                                                                lblperson_code.Text + "&page=" + GridView1.PageIndex.ToString() + "','1');return false;\" >" + lblperson_names.Text + "</a>";
                //}

                //imgEdit.Attributes.Add("onclick", "OpenPopUp('990px','550px','95%','แก้ไขข้อมูลบุคลากร','person_control.aspx?mode=edit&person_code=" + 
                //                                                                                            lblperson_code.Text +"&page=" + GridView1.PageIndex.ToString() + "','1');return false;");                

                //imgEdit.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["img"].ToString();
                //imgEdit.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgEdit"].Rows[0]["title"].ToString());

                //ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                //imgDelete.ImageUrl = ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["img"].ToString();
                //imgDelete.Attributes.Add("title", ((DataSet)Application["xmlconfig"]).Tables["imgDelete"].Rows[0]["title"].ToString());
                //imgDelete.Attributes.Add("onclick", "return confirm(\"คุณต้องการลบ " + lblperson_code.Text + " : " + lblperson_name.Text + " ?\");");
                //#endregion

                //imgDelete.Visible = IsUserDelete ;
                //imgEdit.Visible = IsUserEdit;

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
                imgGo.Attributes.Add("onclick", "javascript: return checkPage(" + GridView1.PageCount.ToString() + ",'กรุณาระบุข้อมูลให้ถูกต้อง.|||ctl00$ASPxRoundPanel1$ContentPlaceHolder2$GridView1$ctl01$txtPage');");
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
            Label lblperson_code = (Label)GridView1.Rows[e.RowIndex].FindControl("lblperson_code");
            cPerson oPerson = new cPerson();
            try
            {
                if (!oPerson.SP_PERSON_DEL(lblperson_code.Text, "N", strUpdatedBy, ref strMessage))
                {
                    lblError.Text = strMessage;
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
            BindGridView(0);
        }


        protected void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboDirector();
            BindGridView(0);
        }

        protected void cboPerson_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(0);
        }

        protected void cboPerson_work_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(0);
        }

        protected void cboDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboUnit();
            BindGridView(0);
        }

        protected void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboUnit();
            BindGridView(0);
        }

    }
}
