﻿using System;
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

namespace myWeb.App_Control.budget_open
{
    public partial class budget_money_item_select : PageBase
    {

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        private string BudgetType
        {
            get
            {
                if (ViewState["BudgetType"] == null)
                {
                    ViewState["BudgetType"] = Helper.CStr(Request.QueryString["budget_type"]);
                }
                return ViewState["BudgetType"].ToString();
            }
            set
            {
                ViewState["BudgetType"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgFind.Attributes.Add("onMouseOver", "src='../../images/button/Search2.png'");
                imgFind.Attributes.Add("onMouseOut", "src='../../images/button/Search.png'");

                if (Request.QueryString["budget_plan_code"] != null)
                {
                    ViewState["budget_plan_code"] = Request.QueryString["budget_plan_code"].ToString();
                }
                else
                {
                    ViewState["budget_plan_code"] = string.Empty;
                }

                if (Request.QueryString["budget_plan_year"] != null)
                {
                    ViewState["year"] = Request.QueryString["budget_plan_year"].ToString();
                }
                else
                {
                    ViewState["year"] = string.Empty;
                }

                if (Request.QueryString["budget_open_doc"] != null)
                {
                    ViewState["budget_open_doc"] = Request.QueryString["budget_open_doc"].ToString();
                }

                if (Request.QueryString["degree_code"] != null)
                {
                    ViewState["degree_code"] = Request.QueryString["degree_code"].ToString();
                }

                if (Request.QueryString["major_code"] != null)
                {
                    ViewState["major_code"] = Request.QueryString["major_code"].ToString();
                }

                InitcboItem_group();
                if (Request.QueryString["item_group_code"] != null)
                {
                    ViewState["item_group_code"] = Request.QueryString["item_group_code"].ToString();
                    if (cboItem_group.Items.FindByValue(ViewState["item_group_code"].ToString()) != null)
                    {
                        cboItem_group.SelectedIndex = -1;
                        cboItem_group.Items.FindByValue(ViewState["item_group_code"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ViewState["item_group_code"] = string.Empty;
                }

                InitcboItemGroupDetail();
                if (Request.QueryString["item_group_detail_id"] != null)
                {
                    ViewState["item_group_detail_id"] = Request.QueryString["item_group_detail_id"].ToString();
                    if (cboItem_group_detail.Items.FindByValue(ViewState["item_group_detail_id"].ToString()) != null)
                    {
                        cboItem_group_detail.SelectedIndex = -1;
                        cboItem_group_detail.Items.FindByValue(ViewState["item_group_detail_id"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ViewState["item_group_detail_id"] = string.Empty;
                }

                InitcboItem();
                if (Request.QueryString["item_code"] != null)
                {
                    ViewState["item_code"] = Request.QueryString["item_code"].ToString();
                    if (cboItem.Items.FindByValue(ViewState["item_code"].ToString()) != null)
                    {
                        cboItem.SelectedIndex = -1;
                        cboItem.Items.FindByValue(ViewState["item_code"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ViewState["item_code"] = string.Empty;
                }

                if (Request.QueryString["item_detail_code"] != null)
                {
                    ViewState["item_detail_code"] = Request.QueryString["item_detail_code"].ToString();
                    txtitem_detail_code.Text = ViewState["item_detail_code"].ToString();
                }
                else
                {
                    ViewState["item_detail_code"] = string.Empty;
                    txtitem_detail_code.Text = string.Empty;
                }

                if (Request.QueryString["item_detail_name"] != null)
                {
                    ViewState["item_detail_name"] = Request.QueryString["item_detail_name"].ToString();
                    txtitem_detail_name.Text = ViewState["item_detail_name"].ToString();
                }
                else
                {
                    ViewState["item_detail_name"] = string.Empty;
                    txtitem_detail_name.Text = string.Empty;
                }

                if (Request.QueryString["hdditem_detail_id"] != null)
                {
                    ViewState["hdditem_detail_id"] = Request.QueryString["hdditem_detail_id"].ToString();
                }
                else
                {
                    ViewState["hdditem_detail_id"] = string.Empty;
                }



                if (Request.QueryString["txtitem_detail_code"] != null)
                {
                    ViewState["txtitem_detail_code"] = Request.QueryString["txtitem_detail_code"].ToString();
                }

                if (Request.QueryString["txtitem_detail_name"] != null)
                {
                    ViewState["txtitem_detail_name"] = Request.QueryString["txtitem_detail_name"].ToString();
                }


                if (Request.QueryString["txtlot_name"] != null)
                {
                    ViewState["txtlot_name"] = Request.QueryString["txtlot_name"].ToString();
                }

                if (Request.QueryString["txtitem_group_detail_name"] != null)
                {
                    ViewState["txtitem_group_detail_name"] = Request.QueryString["txtitem_group_detail_name"].ToString();
                }

                if (Request.QueryString["hddbudget_money_major_id"] != null)
                {
                    ViewState["hddbudget_money_major_id"] = Request.QueryString["hddbudget_money_major_id"].ToString();
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

                ViewState["sort"] = "item_detail_code";
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
            HiddenField hddbudget_money_major_id;
            var oBudget_open = new cBudget_open();
            Budget_open_detail budget_open_detail = null;
            try
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    chkSelect = (CheckBox)gvRow.FindControl("chkSelect");
                    var select = Request.Form[chkSelect.UniqueID];
                    if (select != null && select == "on")
                    {
                        hddbudget_money_major_id = (HiddenField)gvRow.FindControl("hddbudget_money_major_id");
                        budget_open_detail = new Budget_open_detail()
                        {
                            budget_open_doc = ViewState["budget_open_doc"].ToString(),
                            budget_money_major_id = long.Parse(hddbudget_money_major_id.Value),
                            budget_open_detail_amount = 0,
                            budget_open_detail_remark = string.Empty,
                            c_created_by = strUpdatedBy
                        };
                        oBudget_open.SP_BUDGET_OPEN_DETAIL_INS(budget_open_detail);
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
                oBudget_open.Dispose();
            }
            return blnResult;
        }



        private void BindGridView()
        {
            cBudget_money oBudget_money = new cBudget_money();
            DataSet ds = new DataSet();
            string strMessage = string.Empty;
            string strCriteria = string.Empty;
            view_Budget_money_major item = new view_Budget_money_major();
            string strScript = string.Empty;

            item.item_year = ViewState["year"].ToString();

            item.item_group_code = cboItem_group.SelectedValue;
            item.item_group_detail_id = string.IsNullOrEmpty(cboItem_group_detail.SelectedValue) ? 0 : int.Parse(cboItem_group_detail.SelectedValue);
            item.item_code = cboItem.SelectedValue;
            item.item_detail_code = txtitem_detail_code.Text.Replace("'", "''").Trim();
            item.item_detail_name = txtitem_detail_name.Text.Replace("'", "''").Trim();
            item.budget_plan_code = ViewState["budget_plan_code"].ToString();
            item.degree_code = ViewState["degree_code"].ToString();
            item.major_code = ViewState["major_code"].ToString();

            if (!item.item_year.Equals(""))
            {
                strCriteria = strCriteria + "  And  (item_year = '" + item.item_year + "') ";
            }
            if (!item.item_group_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (item_group_code = '" + item.item_group_code + "') ";
            }
            if (item.item_group_detail_id.GetValueOrDefault() > 0)
            {
                strCriteria = strCriteria + "  And  (item_group_detail_id = '" + item.item_group_detail_id.GetValueOrDefault() + "') ";
            }
            if (!item.item_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (item_code = '" + item.item_code + "') ";
            }

            if (!item.item_detail_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (item_detail_code like '%" + item.item_detail_code + "%') ";
            }

            if (!item.item_detail_name.Equals(""))
            {
                strCriteria = strCriteria + "  And  (item_detail_name like '%" + item.item_detail_name + "%') ";
            }

            if (!item.budget_plan_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (budget_plan_code like '%" + item.budget_plan_code + "%') ";
            }

            if (!item.degree_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (degree_code like '%" + item.degree_code + "%') ";
            }

            if (!item.major_code.Equals(""))
            {
                strCriteria = strCriteria + "  And  (major_code like '%" + item.major_code + "%') ";
            }
            strCriteria = strCriteria + "  And  budget_money_major_id not in (select budget_money_major_id from Budget_open_detail where budget_open_doc = '" + ViewState["budget_open_doc"].ToString() + "' ) ";

            try
            {
                if (oBudget_money.SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
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
                oBudget_money.Dispose();
                ds.Dispose();
            }
        }



        private void InitcboItem_group()
        {
            cItem_group oItem_group = new cItem_group();
            string strMessage = string.Empty,
                        strCriteria = string.Empty,
                        strItem_group_code = string.Empty;
            var strYear = ViewState["year"].ToString();
            strItem_group_code = cboItem_group.SelectedValue;
            int i;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = "and item_group_code IN (Select item_group_code from view_Budget_money_detail where budget_plan_code = '" + ViewState["budget_plan_code"].ToString() + "') ";
            if (oItem_group.SP_ITEM_GROUP_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group.Items.Clear();
                cboItem_group.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group.Items.Add(new ListItem(dt.Rows[i]["Item_group_name"].ToString(), dt.Rows[i]["Item_group_code"].ToString()));
                }
                if (cboItem_group.Items.FindByValue(strItem_group_code) != null)
                {
                    cboItem_group.SelectedIndex = -1;
                    cboItem_group.Items.FindByValue(strItem_group_code).Selected = true;
                }
            }
        }

        private void InitcboItemGroupDetail()
        {
            cItem_group_detail oItem_group_detail = new cItem_group_detail();
            string strMessage = string.Empty, strCriteria = string.Empty;
            var strYear = ViewState["year"].ToString();

            string strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            string strItem_group_code = cboItem_group.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_group_year = '" + strYear + "'  and  c_active='Y' And Item_group_code ='" + strItem_group_code + "' ";
            if (oItem_group_detail.SP_ITEM_GROUP_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem_group_detail.Items.Clear();
                cboItem_group_detail.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem_group_detail.Items.Add(new ListItem(dt.Rows[i]["Item_group_detail_name"].ToString(), dt.Rows[i]["Item_group_detail_id"].ToString()));
                }
                if (cboItem_group_detail.Items.FindByValue(strItem_group_detail_id) != null)
                {
                    cboItem_group_detail.SelectedIndex = -1;
                    cboItem_group_detail.Items.FindByValue(strItem_group_detail_id).Selected = true;
                }
            }
        }

        private void InitcboItem()
        {
            cItem oItem = new cItem();
            string strMessage = string.Empty, strCriteria = string.Empty;
            string strItem_code = string.Empty;
            string strItem_group_detail_id = string.Empty;
            var strYear = ViewState["year"].ToString();

            strItem_code = cboItem.SelectedValue;
            strItem_group_detail_id = cboItem_group_detail.SelectedValue;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            strCriteria = " and Item_year = '" + strYear + "'  and  c_active='Y' ";
            //if (!string.IsNullOrEmpty(strItem_group_detail_id))
            {
                strCriteria += " and item_group_detail_id = '" + strItem_group_detail_id + "'  ";
            }
            if (oItem.SP_ITEM_SEL(strCriteria, ref ds, ref strMessage))
            {
                dt = ds.Tables[0];
                cboItem.Items.Clear();
                cboItem.Items.Add(new ListItem("---- เลือกข้อมูลทั้งหมด ----", ""));
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cboItem.Items.Add(new ListItem(dt.Rows[i]["Item_name"].ToString(), dt.Rows[i]["Item_code"].ToString()));
                }
                if (cboItem.Items.FindByValue(strItem_code) != null)
                {
                    cboItem.SelectedIndex = -1;
                    cboItem.Items.FindByValue(strItem_code).Selected = true;
                }
            }
        }


        #region GridView1 Event

        private void BindGridItem()
        {
            cMajor oMajor = new cMajor();
            string strMessage = string.Empty, strCriteria = string.Empty;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                strCriteria = " AND major_code not in (Select major_code From Budget_money_major where budget_money_detail_id = '" + ViewState["budget_money_detail_id"].ToString() + "') ";
                if (MajorLock == "Y")
                {
                    strCriteria += " and major_code = '" + PersonMajorCode + "' ";
                }

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

                Label lblNo = (Label)e.Row.FindControl("lblNo");
                int nNo = (GridView1.PageSize * GridView1.PageIndex) + e.Row.RowIndex + 1;
                lblNo.Text = nNo.ToString();

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
            if (saveData())
            {
                MsgBox("บันทึกข้อมูลสมบูรณ์");

                var script = "window.parent.__doPostBack('ctl00$ContentPlaceHolder1$LinkButton2','');" +
                              "ClosePopUp('" + ViewState["show"].ToString() + "');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenPage", script, true);
            }
        }

        protected void cboLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem_group();
        }

        protected void cboItem_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItemGroupDetail();
        }

        protected void cboItem_group_detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitcboItem();
        }

        protected void imgFind_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
        }


    }
}