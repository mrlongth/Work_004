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

namespace myWeb.App_Control.deduct
{
    public partial class deduct_item_select : PageBase
    {

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                if (Request.QueryString["recv_item_type"] != null)
                {
                    ViewState["recv_item_type"] = Request.QueryString["recv_item_type"].ToString();
                    cboRecv_item_type.SelectedValue = ViewState["recv_item_type"].ToString();
                    cboRecv_item_type.Enabled = false;
                }
                else
                {
                    ViewState["recv_item_type"] = string.Empty;
                }

                if (Request.QueryString["deduct_doc"] != null)
                {
                    ViewState["deduct_doc"] = Request.QueryString["deduct_doc"].ToString();
                }

                if (Request.QueryString["recv_item_year"] != null)
                {
                    ViewState["recv_item_year"] = Request.QueryString["recv_item_year"].ToString();
                }

                if (Request.QueryString["recv_total_amount"] != null)
                {
                    ViewState["recv_total_amount"] = Request.QueryString["recv_total_amount"].ToString();
                }                

                if (Request.QueryString["lbkRefresh"] != null)
                {
                    ViewState["lbkRefresh"] = Request.QueryString["lbkRefresh"].ToString();
                }
                else
                {
                    ViewState["lbkRefresh"] = string.Empty;
                }

                if (Request.QueryString["show"] != null)
                {
                    ViewState["show"] = Request.QueryString["show"].ToString();
                }
                else
                {
                    ViewState["show"] = "1";
                }

                if (Request.QueryString["from_page"] != null)
                {
                    ViewState["from_page"] = Request.QueryString["from_page"].ToString();
                }
                else
                {
                    ViewState["from_page"] = string.Empty;
                }

                ViewState["sort"] = "recv_item_code";
                ViewState["direction"] = "ASC";
                BindGridView();
            }
            else
            {
                BindGridView();
            }
        }

        private bool saveData()
        {
            bool blnResult = false;
            string strUpdatedBy = string.Empty;
            strUpdatedBy = Session["username"].ToString();
            CheckBox chkSelect;
            Label lblrecv_item_code = null;
            Label lblrecv_item_name = null;
            AwNumeric txtrecv_item_rate = null;
            CheckBox chkRecv_item_is_director = null;
            var oDeduct = new cDeduct();
            Deduct_detail deduct_detail = null;
            try
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    chkSelect = (CheckBox)gvRow.FindControl("chkSelect");
                    var select = Request.Form[chkSelect.UniqueID];
                    if (select != null && select == "on")
                    {
                        lblrecv_item_code = (Label)gvRow.FindControl("lblrecv_item_code");
                        lblrecv_item_name = (Label)gvRow.FindControl("lblrecv_item_name");
                        txtrecv_item_rate = (AwNumeric)gvRow.FindControl("txtrecv_item_rate");
                        chkRecv_item_is_director = (CheckBox)gvRow.FindControl("chkRecv_item_is_director");
                        var recv_item_rate = decimal.Parse(txtrecv_item_rate.Value.ToString());
                        deduct_detail = new Deduct_detail
                        {
                            deduct_doc_no = ViewState["deduct_doc"].ToString(),
                            recv_item_code = lblrecv_item_code.Text,
                            recv_item_rate = recv_item_rate,
                            deduct_item_amount = decimal.Parse(ViewState["recv_total_amount"].ToString()) * recv_item_rate / 100,
                            deduct_item_is_director = chkRecv_item_is_director.Checked,
                            c_created_by= strUpdatedBy
                        };
                        oDeduct.SP_DEDUCT_DETAIL_INS(deduct_detail);

                    }
                    blnResult = true;
                }
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }
            finally
            {
                oDeduct.Dispose();
            }
            return blnResult;
        }

        private bool validateCheckBox()
        {
            bool blnResult = false;
            CheckBox chkSelect;
            int count = 0;
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                chkSelect = (CheckBox)gvRow.FindControl("chkSelect");
                var select = Request.Form[chkSelect.UniqueID];
                if (select != null && select == "on")
                {
                    count++;
                }
            }
            blnResult = count > 0;
            if (!blnResult)
            {
                MsgBox("กรุณาเลือกข้อมูล");
            }
            return blnResult;
        }

        private void BindGridView()
        {
            cRecv_item oRecv_item = new cRecv_item();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            var recv_item = new Recv_item();
            string strScript = string.Empty;

            recv_item.recv_item_year = ViewState["recv_item_year"].ToString();
            recv_item.recv_item_code = txtrecv_item_code.Text.Replace("'", "''").Trim();
            recv_item.recv_item_name = txtrecv_item_name.Text.Replace("'", "''").Trim();
            recv_item.recv_item_type = cboRecv_item_type.SelectedValue; ;

            if (!recv_item.recv_item_year.Equals(""))
            {
                strCriteria = strCriteria + "  And  (recv_item_year = '" + recv_item.recv_item_year + "') ";
            }
            if (!recv_item.recv_item_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (recv_item_code = '" + recv_item.recv_item_code + "') ";
            }

            if (!recv_item.recv_item_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (recv_item_name = '" + recv_item.recv_item_name + "') ";
            }

            if (!recv_item.recv_item_type.Equals(""))
            {
                strCriteria = strCriteria + "  And  (recv_item_type = '" + recv_item.recv_item_type + "') ";
            }

            if (ViewState["deduct_doc"] != null)
            {
                strCriteria = strCriteria + "  And  recv_item_code NOT IN (SELECT recv_item_code from Deduct_detail WHERE deduct_doc_no = '" + ViewState["deduct_doc"].ToString() + "') ";
            }

            try
            {
                if (oRecv_item.SP_RECV_ITEM_SEL(strCriteria, ref ds, ref strMessage))
                {
                    ds.Tables[0].DefaultView.Sort = ViewState["sort"] + " " + ViewState["direction"];
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
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
                oRecv_item.Dispose();
                ds.Dispose();
            }
        }


        #region GridView1 Event

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

                DataRowView dv = (DataRowView)e.Row.DataItem;
                //Label lblNo = (Label)e.Row.FindControl("lblNo");
                //int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                //lblNo.Text = nNo.ToString();

                CheckBox chkRecv_item_is_director = (CheckBox)e.Row.FindControl("chkRecv_item_is_director");
                chkRecv_item_is_director.Checked = Helper.CBool(dv["recv_item_is_director"]);

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
            if (validateCheckBox() && saveData())
            {
                MsgBox("บันทึกข้อมูลสมบูรณ์");

                var script = "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton1','');" +
                              "ClosePopUp('" + ViewState["show"].ToString() + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", script, true);
            }
        }

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
        }

        public static string getItemtype(object mData)
        {
            if (mData.Equals("D"))
            {
                return "รายการรับ";
            }
            else
            {
                return "รายการหัก";
            }
        }

        protected void cboRecv_item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }
    }

}