using System;
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

namespace myWeb.App_Control.lov
{
    public partial class person_retire_lov : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

             
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

                if (Request.QueryString["ctrl1"] != null)
                {
                    ViewState["ctrl1"] = Request.QueryString["ctrl1"].ToString();
                }
                else
                {
                    ViewState["ctrl1"] = string.Empty;
                }

                if (Request.QueryString["ctrl2"] != null)
                {
                    ViewState["ctrl2"] = Request.QueryString["ctrl2"].ToString();
                }
                else
                {
                    ViewState["ctrl2"] = string.Empty;
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



                ViewState["sort"] = "pr_person_code";
                ViewState["direction"] = "ASC";
            }
            else
            {
                BindGridView();
            }
        }

        #region private function

      
        #endregion

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {


            var oPerson_retire = new cPerson_retire();
            var ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string strperson_code = string.Empty;
            string strperson_name = string.Empty;
            strperson_code = txtperson_code.Text.Replace("'", "''").Trim();
            strperson_name = txtperson_name.Text.Replace("'", "''").Trim();
          
        
            if (!strperson_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (pr_person_code= '" + strperson_code + "') ";
            }

            if (!strperson_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (person_thai_name like '%" + strperson_name + "%'  " +
                                               "  OR person_thai_surname like '%" + strperson_name + "%'" +
                                               "  OR (person_thai_name + ' ' +person_thai_surname) like '%" + strperson_name + "%' )";
            }

            if (RadioActive.Checked)
            {
                strCriteria = strCriteria + "  And  (c_active ='Y') ";
            }
            else if (RadioCancel.Checked)
            {
                strCriteria = strCriteria + "  And  (c_active ='N') ";
            }

           
            if (DirectorLock == "Y")
            {
                strCriteria += " and substring(director_code,4,2) = substring('" + DirectorCode + "',4,2) ";
            }


            try
            {
                if (!oPerson_retire.SP_PERSON_RETIRE_SEL(strCriteria, ref ds, ref strMessage))
                {
                    lblError.Text = strMessage;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        string strScript = string.Empty;
                        strperson_code = ds.Tables[0].Rows[0]["pr_person_code"].ToString();
                        strperson_name = ds.Tables[0].Rows[0]["person_thai_name"].ToString() + " " + ds.Tables[0].Rows[0]["person_thai_surname"].ToString();

                        if (!ViewState["show"].ToString().Equals("1"))
                        {
                            strScript = "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strperson_code + "';\n " +
                                                 "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strperson_name + "';\n" +
                                                 "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');" +
                                                 "ClosePopUp('" + ViewState["show"].ToString() + "');";
                        }
                        else
                        {
                            strScript = "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strperson_code + "';\n " +
                                        "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strperson_name + "';\n" +
                                        "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');" +
                                        "ClosePopUp('" + ViewState["show"].ToString() + "');";
                        }
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "close", strScript, true);
                    }
                    else
                    {
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
                oPerson_retire.Dispose();
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
                if (ViewState["from"].ToString().Equals("user"))
                {
                    lblperson_code.Text = "<a href=\"\" onclick=\"" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblperson_code.Text + "';\n " +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblperson_name.Text + " " + dv["person_thai_surname"].ToString() + "';\n" +
                                                             "ClosePopUp('" + ViewState["show"].ToString() + "');" +
                                                             "return false;\" >" + lblperson_code.Text + "</a>";
                }
                else if (!ViewState["show"].ToString().Equals("1"))
                {
                    lblperson_code.Text = "<a href=\"\" onclick=\"" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblperson_code.Text + "';\n " +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblperson_name.Text + " " + dv["person_thai_surname"].ToString() + "';\n" +
                                                             "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');"+
                                                             "ClosePopUp('" + ViewState["show"].ToString() + "');" +
                                                             "return false;\" >" + lblperson_code.Text + "</a>";
               
                
                }
                else
                {
                    string strPersonCode = lblperson_code.Text;
                    string strPersonName = lblperson_name.Text + " " + dv["person_thai_surname"].ToString();
                   
                    lblperson_code.Text = "<a href=\"\" onclick=\"";
                    lblperson_code.Text += "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strPersonCode + "';\n ";
                    lblperson_code.Text += "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strPersonName + "';\n";
                    if (ViewState["from"].ToString() == "payment_control")
                        lblperson_code.Text += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');";
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
