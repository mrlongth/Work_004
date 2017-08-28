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

namespace myWeb.App_Control.lov
{
    public partial class position_lov : PageBase
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

                Session["menulov_name"] = "ค้นหาข้อมูลตำแหน่ง";
                #region set QueryString
                if (Request.QueryString["position_code"] != null)
                {
                    ViewState["position_code"] = Request.QueryString["position_code"].ToString();
                    txtposition_code.Text = ViewState["position_code"].ToString();
                }
                else
                {
                    ViewState["position_code"] = string.Empty;
                    txtposition_code.Text = string.Empty;
                }
                if (Request.QueryString["position_name"] != null)
                {
                    ViewState["position_name"] = Request.QueryString["position_name"].ToString();
                    txtposition_name.Text = ViewState["position_name"].ToString();
                }
                else
                {
                    ViewState["position_name"] = string.Empty;
                    txtposition_name.Text = string.Empty;
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
                #endregion

                if (Request.QueryString["show"] != null)
                {
                    ViewState["show"] = Request.QueryString["show"].ToString();
                }
                else
                {
                    ViewState["show"] = "1";
                }

                ViewState["sort"] = "position_code";
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
            cPosition oPosition = new cPosition();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            string strposition_code = string.Empty;
            string strposition_name = string.Empty;
            string strScript = string.Empty;
            strposition_code = txtposition_code.Text.Replace("'", "''").Trim();
            strposition_name = txtposition_name.Text.Replace("'", "''").Trim();
            if (!strposition_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (position_code like '%" + strposition_code + "%') ";
            }
            if (!strposition_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (position_name like '%" + strposition_name + "%')";
            }
            strCriteria = strCriteria + "  And  (c_active ='Y') ";
            try
            {
                if (oPosition.SP_POSITION_SEL(strCriteria, ref ds, ref strMessage))
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        strposition_code = ds.Tables[0].Rows[0]["position_code"].ToString();
                        strposition_name = ds.Tables[0].Rows[0]["position_name"].ToString();
                        if (!ViewState["show"].ToString().Equals("1"))
                        {
                            if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                                strScript = "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strposition_code + "';\n ";
                            if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                                strScript += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strposition_name + "';\n";
                            strScript += "ClosePopUp('" + ViewState["show"].ToString() + "');";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                                strScript = "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + strposition_code + "';\n ";
                            if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                                strScript += "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + strposition_name + "';\n";
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
                oPosition.Dispose();
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
                Label lblposition_code = (Label)e.Row.FindControl("lblposition_code");
                Label lblposition_name = (Label)e.Row.FindControl("lblposition_name");
                var strposition_code = string.Empty;
                if (!ViewState["show"].ToString().Equals("1"))
                {
                    strposition_code = "<a href=\"\" onclick=\"";
                    if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                        strposition_code += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblposition_code.Text + "';\n ";
                    if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                        strposition_code += "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblposition_name.Text + "';\n";
                    strposition_code += "ClosePopUp('" + ViewState["show"].ToString() + "');" + "return false;\" >" + lblposition_code.Text + "</a>";
                }
                else
                {
                    strposition_code = "<a href=\"\" onclick=\"";
                    if (!string.IsNullOrEmpty(ViewState["ctrl1"].ToString()))
                        strposition_code += "window.parent.document.getElementById('" + ViewState["ctrl1"].ToString() + "').value='" + lblposition_code.Text + "';\n ";
                    if (!string.IsNullOrEmpty(ViewState["ctrl2"].ToString()))
                        strposition_code += "window.parent.document.getElementById('" + ViewState["ctrl2"].ToString() + "').value='" + lblposition_name.Text + "';\n";
                    strposition_code += "ClosePopUp('" + ViewState["show"].ToString() + "');" + "return false;\" >" + lblposition_code.Text + "</a>";
                }
                lblposition_code.Text = strposition_code;
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
