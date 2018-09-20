using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;

namespace myWeb.App_Control.lov
{
    public partial class person_lov : PageBase
    {

        private string Year
        {
            get
            {
                if (ViewState["year"] == null)
                {
                    ViewState["year"] = Helper.CStr(Request.QueryString["year"]);
                }
                return ViewState["year"].ToString();
            }
            set
            {
                ViewState["year"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                InitcboWork_status();
                InitcboPerson_group();
                InitcboMajor();


                if (Request.QueryString["person_code"] != null)
                {
                    ViewState["person_code"] = Request.QueryString["person_code"].ToString();
                    txtperson_code.Text = ViewState["person_code"].ToString();
                }
                else
                {
                    ViewState["person_code"] = string.Empty;
                    txtperson_code.Text = string.Empty;
                }

                if (Request.QueryString["person_name"] != null)
                {
                    ViewState["person_name"] = Request.QueryString["person_name"].ToString();
                    txtperson_name.Text = ViewState["person_name"].ToString();
                }
                else
                {
                    ViewState["person_name"] = string.Empty;
                    txtperson_name.Text = string.Empty;
                }

                if (Request.QueryString["txtperson_code"] != null)
                {
                    ViewState["txtperson_code"] = Request.QueryString["txtperson_code"].ToString();
                }
                else
                {
                    ViewState["txtperson_code"] = string.Empty;
                }

                if (Request.QueryString["txtperson_name"] != null)
                {
                    ViewState["txtperson_name"] = Request.QueryString["txtperson_name"].ToString();
                }
                else
                {
                    ViewState["txtperson_name"] = string.Empty;
                }



                if (Request.QueryString["show"] != null)
                {
                    ViewState["show"] = Request.QueryString["show"].ToString();
                }
                else
                {
                    ViewState["show"] = "1";
                }

                if (Request.QueryString["from"] != null)
                {
                    ViewState["from"] = Request.QueryString["from"].ToString();
                }
                else
                {
                    ViewState["from"] = string.Empty;
                }



                ViewState["sort"] = "person_code";
                ViewState["direction"] = "ASC";
            }
            else
            {
                BindGridView();
            }
        }

        #region private function

        private void InitcboWork_status()
        {
            cPerson_work_status oPerson_work_status = new cPerson_work_status();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strperson_work_status_code = cboPerson_work_status.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "  and  c_active='Y' ";
            if (oPerson_work_status.SP_PERSON_WORK_STATUS_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_work_status.Items.Clear();
                cboPerson_work_status.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboPerson_work_status.Items.Add(new ListItem(dt.Rows[i]["person_work_status_name"].ToString(), dt.Rows[i]["person_work_status_code"].ToString()));
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
            cPerson_group oPerson_group = new cPerson_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strperson_group_code = string.Empty;
            strperson_group_code = cboPerson_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and c_active='Y' ";
            strCriteria += " and person_group_code IN (" + PersonGroupList + ") ";
            if (oPerson_group.SP_PERSON_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboPerson_group.Items.Clear();
                cboPerson_group.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
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


        private void InitcboMajor()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strYear = Year;
            string strmajor_code = cboMajor.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and major_year = '" + strYear + "' and  c_active='Y' ";
            if (MajorLock == "Y")
            {
                strCriteria += " and major_code = '" + PersonMajorCode + "' ";
            }

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


        #endregion

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {

            InitcboWork_status();
            InitcboPerson_group();

            cPerson oPerson = new cPerson();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string strYear = string.Empty;
            string strActive = string.Empty;
            string strperson_group_code = string.Empty;
            string strperson_group_name = string.Empty;
            string strmajor_code = string.Empty;
            string strperson_code = string.Empty;
            string strperson_name = string.Empty;
            string strperson_work_status_code = string.Empty;
            strperson_group_code = cboPerson_group.Text;
            strmajor_code = cboMajor.SelectedValue;
            strperson_code = txtperson_code.Text.Replace("'", "''").Trim();
            strperson_name = txtperson_name.Text.Replace("'", "''").Trim();
            strperson_work_status_code = cboPerson_work_status.SelectedValue;

            if (!strYear.Equals(""))
            {
                strCriteria = strCriteria + "  And  (budget_plan_year = '" + strYear + "') ";
            }

            if (!strperson_group_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (person_group_code like '%" + strperson_group_code + "%') ";
            }


            if (!strmajor_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (major_code= '" + strmajor_code + "') ";
            }

            if (!strperson_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (person_code= '" + strperson_code + "') ";
            }

            if (!strperson_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (person_thai_name like '%" + strperson_name + "%'  " +
                                                              "  OR person_thai_surname like '%" + strperson_name + "%'  " +
                                                              "  OR (person_thai_surname + ' ' +person_eng_surname) like '%" + strperson_name + "%')";
            }

            if (!strperson_work_status_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (person_work_status_code= '" + strperson_work_status_code + "') ";
            }

            if (RadioActive.Checked)
            {
                strCriteria = strCriteria + "  And  (c_active ='Y') ";
            }
            else if (RadioCancel.Checked)
            {
                strCriteria = strCriteria + "  And  (c_active ='N') ";
            }

            strCriteria += " and person_group_code IN (" + PersonGroupList + ") ";


            if (DirectorLock == "Y")
            {
                strCriteria += " and substring(director_code,4,2) = substring('" + DirectorCode + "',4,2) ";
            }



            try
            {
                if (!oPerson.SP_PERSON_LIST_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
            finally
            {
                oPerson.Dispose();
                ds.Dispose();
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
                Label lblperson_code = (Label)e.Row.FindControl("lblperson_code");
                Label lblperson_name = (Label)e.Row.FindControl("lblperson_name");
                DataRowView dv = (DataRowView)e.Row.DataItem;

                string strPersonCode = lblperson_code.Text;
                string strPersonSurName = dv["person_thai_surname"].ToString();
                string strPersonName = lblperson_name.Text + " " + strPersonSurName;
                string strPersonId = dv["person_id"].ToString();

                if (ViewState["from"].ToString().Equals("user"))
                {
                    lblperson_code.Text = "<a href=\"\" onclick=\"" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblperson_code.Text + "';\n " +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblperson_name.Text + " " + dv["person_thai_surname"].ToString() + "';\n" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl3"].ToString() + "').value='" + dv["person_group_name"].ToString() + "';\n" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl4"].ToString() + "').value='" + dv["director_name"].ToString() + "';\n" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl5"].ToString() + "').value='" + dv["unit_name"].ToString() + "';\n" +
                                                             "ClosePopUp('" + ViewState["show"].ToString() + "');" +
                                                             "return false;\" >" + lblperson_code.Text + "</a>";
                }
                else if (!ViewState["show"].ToString().Equals("1"))
                {

                    lblperson_code.Text = "<a href=\"\" onclick=\"";

                    if (!string.IsNullOrEmpty(ViewState["txtperson_code"].ToString()))
                        lblperson_code.Text += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["txtperson_code"].ToString() + "').value='" + strPersonCode + "';\n ";

                    if (!string.IsNullOrEmpty(ViewState["txtperson_name"].ToString()))
                        lblperson_code.Text += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["txtperson_name"].ToString() + "').value='" + strPersonName + "';\n";

                    lblperson_code.Text += "ClosePopUp('" + ViewState["show"].ToString() + "');";
                    lblperson_code.Text += "return false;\" >" + strPersonCode + "</a>";

                }
                else
                {

                    lblperson_code.Text = "<a href=\"\" onclick=\"";

                    if (!string.IsNullOrEmpty(ViewState["txtperson_code"].ToString()))
                        lblperson_code.Text += "window.parent.document.getElementById('" + ViewState["txtperson_code"].ToString() + "').value='" + strPersonCode + "';\n ";

                    if (!string.IsNullOrEmpty(ViewState["txtperson_name"].ToString()))
                        lblperson_code.Text += "window.parent.document.getElementById('" + ViewState["txtperson_name"].ToString() + "').value='" + strPersonName + "';\n";

                    lblperson_code.Text += "ClosePopUp('" + ViewState["show"].ToString() + "');";
                    lblperson_code.Text += "return false;\" >" + strPersonCode + "</a>";
                }


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
                BindGridView();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }

    

    }
}
