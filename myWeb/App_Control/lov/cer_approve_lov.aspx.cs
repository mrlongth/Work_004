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
    public partial class cer_approve_lov : PageBase
    {

        #region private data
        private string strConn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        private bool[] blnAccessRight = new bool[5] { false, false, false, false, false };
        private string strPrefixCtr = "ctl00$ASPxRoundPanel1$ASPxRoundPanel2$ContentPlaceHolder1$";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // Thread.Sleep(2000);
            if (!IsPostBack)
            {
                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                #region set QueryString
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

                if (Request.QueryString["ctrl3"] != null)
                {
                    ViewState["ctrl3"] = Request.QueryString["ctrl3"].ToString();
                }
                else
                {
                    ViewState["ctrl3"] = string.Empty;
                }

                #endregion

                if (Request.QueryString["show"] != null)
                {
                    ViewState["show"] = Request.QueryString["show"].ToString();
                }
                else
                {
                    ViewState["show"] = "1";
                }

                ViewState["sort"] = "req_approve";
                ViewState["direction"] = "ASC";
                BindGridView();
            }
            else
            {
                BindGridView();
            }
        }

        #region private function

        private void BindGridView()
        {
            cReq_approve oReq_approve = new cReq_approve();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string strScript = string.Empty;

            string strreq_approve = string.Empty;
            string strreq_approve_position1 = string.Empty;
            string strreq_approve_position2 = string.Empty;

            strreq_approve = txtreq_approve.Text.Replace("'", "''").Trim();
            if (!strreq_approve.Equals(""))
            {
                strCriteria = strCriteria + "  And  (req_approve like '%" + strreq_approve + "%') ";
            }
            try
            {
                if (oReq_approve.SP_REQ_APPROVE_SEL(strCriteria, ref ds, ref strMessage))
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {

                        strreq_approve = ds.Tables[0].Rows[0]["req_approve"].ToString();
                        strreq_approve_position1 = ds.Tables[0].Rows[0]["req_approve_position1"].ToString();
                        strreq_approve_position2 = ds.Tables[0].Rows[0]["req_approve_position2"].ToString();
                        
                        if (!ViewState["show"].ToString().Equals("1"))
                        {
                            if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                                strScript = "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strreq_approve + "';\n ";
                            if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                                strScript += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strreq_approve_position1 + "';\n";
                            if (!string.IsNullOrEmpty(ViewState["ctrl3"].ToString()))
                                strScript += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl3"].ToString() + "').value='" + strreq_approve_position2 + "';\n";                           
                            
                            strScript += "ClosePopUp('" + ViewState["show"].ToString() + "');";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                                strScript = "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strreq_approve + "';\n ";
                            if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                                strScript += "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strreq_approve_position1 + "';\n";

                            if (!string.IsNullOrEmpty(ViewState["ctrl3"].ToString()))
                                strScript += "window.parent.document.getElementById('" + ViewState["ctrl3"].ToString() + "').value='" + strreq_approve_position2 + "';\n";

                            
                            strScript += "ClosePopUp('" + ViewState["show"].ToString() + "');";
                       
                        
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
                else
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
                oReq_approve.Dispose();
                ds.Dispose();
            }
        }
        #endregion

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
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
                Label lblreq_approve = (Label)e.Row.FindControl("lblreq_approve");
                Label lblreq_approve_position1 = (Label)e.Row.FindControl("lblreq_approve_position1");
                Label lblreq_approve_position2 = (Label)e.Row.FindControl("lblreq_approve_position2");


                var strreq_approve = string.Empty;
                if (!ViewState["show"].ToString().Equals("1"))
                {
                    strreq_approve = "<a href=\"\" onclick=\"";
                    if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                        strreq_approve += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblreq_approve.Text + "';\n ";
                    if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                        strreq_approve += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblreq_approve_position1.Text + "';\n";
                    if (!string.IsNullOrEmpty(ViewState["ctrl3"].ToString()))
                        strreq_approve += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl3"].ToString() + "').value='" + lblreq_approve_position2.Text + "';\n";
                    strreq_approve += "ClosePopUp('" + ViewState["show"].ToString() + "');" + "return false;\" >" + lblreq_approve.Text + "</a>";
                }
                else
                {
                    strreq_approve = "<a href=\"\" onclick=\"";
                    if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                        strreq_approve += "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblreq_approve.Text + "';\n ";
                    if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                        strreq_approve += "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblreq_approve_position1.Text + "';\n";
                    if (!string.IsNullOrEmpty(ViewState["ctrl3"].ToString()))
                        strreq_approve += "window.parent.document.getElementById('" + ViewState["ctrl3"].ToString() + "').value='" + lblreq_approve_position2.Text + "';\n";

                    strreq_approve += "ClosePopUp('" + ViewState["show"].ToString() + "');" + "return false;\" >" + lblreq_approve.Text + "</a>";
                }
                lblreq_approve.Text = strreq_approve;
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
