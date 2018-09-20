using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using myDLL;
using Aware.WebControls;
using myModel;

namespace myWeb.App_Control.budget_money
{
    public partial class budget_money_major_select : PageBase
    {

        private string BudgetType
        {
            get
            {
                if (ViewState["budget_type"] == null)
                {
                    ViewState["budget_type"] = Helper.CStr(Request.QueryString["budget_type"]);
                }
                return ViewState["budget_type"].ToString();
            }
            set
            {
                ViewState["budget_type"] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            if (!IsPostBack)
            {
                imgSaveOnly.Attributes.Add("onMouseOver", "src='../../images/button/save_add2.png'");
                imgSaveOnly.Attributes.Add("onMouseOut", "src='../../images/button/save_add.png'");

                if (Request.QueryString["show"] != null)
                {
                    ViewState["show"] = Request.QueryString["show"].ToString();
                }
                else
                {
                    ViewState["show"] = "1";
                }


                ViewState["sort"] = "major_name";
                ViewState["direction"] = "ASC";

                #region set QueryString


                if (Request.QueryString["budget_money_detail_id"] != null)
                {
                    ViewState["budget_money_detail_id"] = Request.QueryString["budget_money_detail_id"].ToString();
                    BindGridItem();
                }

                #endregion


            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            string strUpdatedBy = string.Empty;
            strUpdatedBy = Session["username"].ToString();
            CheckBox chkSelect;
            Label lblmajor_code;
            var oBudget_money = new cBudget_money();
            Budget_money_major budget_money_major = null;
            try
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    chkSelect = (CheckBox)gvRow.FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        lblmajor_code = (Label)gvRow.FindControl("lblmajor_code");
                        budget_money_major = new Budget_money_major()
                        {
                            budget_money_detail_id = long.Parse(ViewState["budget_money_detail_id"].ToString()),
                            major_code = lblmajor_code.Text,
                            c_created_by = strUpdatedBy
                        };
                        oBudget_money.SP_BUDGET_MONEY_MAJOR_INS(budget_money_major);
                    }
                }
                blnResult = true;
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }
            finally
            {
                oBudget_money.Dispose();
            }
            return blnResult;
        }



        #region GridView1 Event

        private void BindGridItem()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            var strYear = string.Empty;
            if (this.BudgetType == "B")
            {
                strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow"].ToString();
            }
            else
            {
                strYear = ((DataSet)Application["xmlconfig"]).Tables["default"].Rows[0]["yearnow2"].ToString();
            }
            try
            {
                strCriteria = " AND  c_active = 'Y' AND major_year = '" + strYear + "'  AND major_code not in (Select major_code From Budget_money_major where budget_money_detail_id = '" + ViewState["budget_money_detail_id"].ToString() + "')  order by major_order";
                if (oMajor.SP_SEL_Major(strCriteria, ref ds, ref strMessage))
                {
                    dt = ds.Tables[0];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                if (GridView1.Rows.Count == 0)
                {
                    EmptyGridFix(GridView1);
                }
                oMajor.Dispose();
                ds.Dispose();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType.Equals(DataControlRowType.Header))
            {
                ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
                        ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");


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

                var chkSelect = ((CheckBox)e.Row.FindControl("chkSelect"));
                chkSelect.Checked = true;
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

        #region EmptyGridFix
        protected void EmptyGridFix(GridView grdView)
        {
            // normally executes after a grid load method
            if (grdView.Rows.Count == 0 &&
                grdView.DataSource != null)
            {
                DataTable dt = null;

                // need to clone sources otherwise it will be indirectly adding to 
                // the original source

                if (grdView.DataSource is DataSet)
                {
                    dt = ((DataSet)grdView.DataSource).Tables[0].Clone();
                }
                else if (grdView.DataSource is DataTable)
                {
                    dt = ((DataTable)grdView.DataSource).Clone();
                }

                if (dt == null)
                {
                    return;
                }

                dt.Rows.Add(dt.NewRow()); // add empty row
                grdView.DataSource = dt;
                grdView.DataBind();

                // hide row
                grdView.Rows[0].Visible = false;
                grdView.Rows[0].Controls.Clear();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1 &&
                grdView.DataSource == null)
            {
                bool bIsGridEmpty = true;

                // check first row that all cells empty
                for (int i = 0; i < grdView.Rows[0].Cells.Count; i++)
                {
                    if (grdView.Rows[0].Cells[i].Text != string.Empty)
                    {
                        bIsGridEmpty = false;
                    }
                }
                // hide row
                if (bIsGridEmpty)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }
        #endregion

        #endregion


        protected void imgSaveOnly_Click(object sender, ImageClickEventArgs e)
        {
            if (saveData())
            {
                MsgBox("บันทึกข้อมูลสมบูรณ์");
                var script = "window.parent.frames['iframeShow" + (int.Parse(ViewState["show"].ToString()) - 1) + "'].__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');" +
                              "ClosePopUp('" + ViewState["show"].ToString() + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", script, true);
            }
        }

    }
}