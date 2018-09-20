using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;
using System.Collections.Generic;

namespace myDLL
{
    public class cBudget_money : IDisposable
    {
        private string _strConn = string.Empty;
        public string ConnectionString
        {
            get
            {
                return _strConn;
            }
            set
            {
                if (value == string.Empty)
                {
                    _strConn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                }
                else
                {
                    _strConn = value;
                }
            }
        }

        public cBudget_money()
        {
            //
            // TODO: Add constructor logic here
            //
            _strConn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        #region BUDGET_MONEY_HEAD

        #region sp_BUDGET_MONEY_HEAD_SEL
        public bool SP_BUDGET_MONEY_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_MONEY_HEAD_SEL");
                blnResult = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region sp_BUDGET_MONEY_HEAD_INS
        public bool SP_BUDGET_MONEY_HEAD_INS(Budget_money_head budget_money_head)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_HEAD_INS";

                SqlParameter oParambudget_money_doc = new SqlParameter("budget_money_doc", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = budget_money_head.budget_money_doc
                };
                oCommand.Parameters.Add(oParambudget_money_doc);
                //oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = budget_money_head.budget_money_doc;

                oCommand.Parameters.Add("budget_money_year", SqlDbType.VarChar).Value = budget_money_head.budget_money_year;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_money_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_money_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_money_head.degree_code;
                oCommand.Parameters.Add("budget_money_plan", SqlDbType.Money).Value = budget_money_head.budget_money_plan;
                oCommand.Parameters.Add("budget_money_contribute", SqlDbType.VarChar).Value = budget_money_head.budget_money_contribute;
                oCommand.Parameters.Add("budget_money_use", SqlDbType.VarChar).Value = budget_money_head.budget_money_use;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = budget_money_head.c_active;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_money_head.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_money_head.budget_money_doc = oParambudget_money_doc.Value.ToString();

                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_HEAD_UPD
        public bool SP_BUDGET_MONEY_HEAD_UPD(Budget_money_head budget_money_head)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_HEAD_UPD";
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = budget_money_head.budget_money_doc;
                oCommand.Parameters.Add("budget_money_year", SqlDbType.VarChar).Value = budget_money_head.budget_money_year;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_money_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_money_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_money_head.degree_code;
                oCommand.Parameters.Add("budget_money_plan", SqlDbType.Money).Value = budget_money_head.budget_money_plan;
                oCommand.Parameters.Add("budget_money_contribute", SqlDbType.VarChar).Value = budget_money_head.budget_money_contribute;
                oCommand.Parameters.Add("budget_money_use", SqlDbType.VarChar).Value = budget_money_head.budget_money_use;
                oCommand.Parameters.Add("comments", SqlDbType.VarChar).Value = budget_money_head.comments;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = budget_money_head.c_active;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_money_head.c_updated_by;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_HEAD_DEL
        public bool SP_BUDGET_MONEY_HEAD_DEL(string pBudget_money_doc)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_HEAD_DEL";
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = pBudget_money_doc;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        public view_Budget_money_head GET(string strCriteria)
        {
            view_Budget_money_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_MONEY_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_money_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region BUDGET_MONEY_DETAIL

        #region sp_BUDGET_MONEY_DETAIL_SEL
        public bool SP_BUDGET_MONEY_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_MONEY_DETAIL_SEL");
                blnResult = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region sp_BUDGET_MONEY_DETAIL_INS
        public bool SP_BUDGET_MONEY_DETAIL_INS(Budget_money_detail budget_money_detail)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_DETAIL_INS";

                SqlParameter oParambudget_money_detail_id = new SqlParameter("budget_money_detail_id", SqlDbType.BigInt);
                oParambudget_money_detail_id.Direction = ParameterDirection.Output;
                oParambudget_money_detail_id.Value = budget_money_detail.budget_money_detail_id;
                oCommand.Parameters.Add(oParambudget_money_detail_id);
                //oCommand.Parameters.Add("budget_money_detail_id",  SqlDbType.BigInt, ).Value = budget_money_detail.budget_money_detail_id;
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = budget_money_detail.budget_money_doc;
                oCommand.Parameters.Add("item_detail_id", SqlDbType.BigInt).Value = budget_money_detail.item_detail_id;
                oCommand.Parameters.Add("budget_money_detail_plan", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan;
                oCommand.Parameters.Add("budget_money_detail_plan2", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan2;
                oCommand.Parameters.Add("budget_money_detail_plan3", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan3;
                oCommand.Parameters.Add("budget_money_detail_contribute", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_contribute;
                oCommand.Parameters.Add("budget_money_detail_use", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_use;
                oCommand.Parameters.Add("budget_money_detail_comment", SqlDbType.VarChar).Value = budget_money_detail.budget_money_detail_comment;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_money_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_money_detail.budget_money_detail_id = long.Parse(oParambudget_money_detail_id.Value.ToString());
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_DETAIL_UPD
        public bool SP_BUDGET_MONEY_DETAIL_UPD(Budget_money_detail budget_money_detail)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_DETAIL_UPD";
                oCommand.Parameters.Add("budget_money_detail_id", SqlDbType.BigInt).Value = budget_money_detail.budget_money_detail_id;
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = budget_money_detail.budget_money_doc;
                oCommand.Parameters.Add("item_detail_id", SqlDbType.BigInt).Value = budget_money_detail.item_detail_id;
                oCommand.Parameters.Add("budget_money_detail_plan", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan;
                oCommand.Parameters.Add("budget_money_detail_plan2", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan2;
                oCommand.Parameters.Add("budget_money_detail_plan3", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_plan3;
                oCommand.Parameters.Add("budget_money_detail_contribute", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_contribute;
                oCommand.Parameters.Add("budget_money_detail_use", SqlDbType.Money).Value = budget_money_detail.budget_money_detail_use;
                oCommand.Parameters.Add("budget_money_detail_comment", SqlDbType.VarChar).Value = budget_money_detail.budget_money_detail_comment;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_money_detail.c_updated_by;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_DETAIL_DEL
        public bool SP_BUDGET_MONEY_DETAIL_DEL(string pBudget_money_detail_id)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_DETAIL_DEL";
                oCommand.Parameters.Add("budget_money_detail_id", SqlDbType.BigInt).Value = pBudget_money_detail_id;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        public view_Budget_money_detail GETDETAIL(string strCriteria)
        {
            view_Budget_money_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_MONEY_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_money_detail>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion


        #region BUDGET_MONEY_MAJOR

        #region sp_BUDGET_MONEY_MAJOR_SEL
        public bool SP_BUDGET_MONEY_MAJOR_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_MAJOR_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_MONEY_MAJOR_SEL");
                blnResult = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion


        public List<view_Budget_money_major> GETMONEYDETAILS(string strCriteria)
        {
            List<view_Budget_money_major> results = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
            {
                results = Helper.ToClassInstanceCollection<view_Budget_money_major>(ds.Tables[0]).ToList();
            }
            return results;
        }

        #region SP_BUDGET_RECEIVE_DETAIL_TMP_SEL
        public bool SP_BUDGET_RECEIVE_DETAIL_TMP_SEL(string budget_receive_doc, string degree_code, string budget_plan_code, ref DataSet ds, ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_RECEIVE_DETAIL_TMP_SEL";
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = budget_receive_doc;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = degree_code;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_plan_code;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_BUDGET_RECEIVE_DETAIL_TMP_SEL");
                blnResult = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message.ToString();
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region sp_BUDGET_MONEY_MAJOR_INS
        public bool SP_BUDGET_MONEY_MAJOR_INS(Budget_money_major budget_money_major)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_MAJOR_INS";
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.BigInt).Value = budget_money_major.budget_money_major_id;
                oCommand.Parameters.Add("budget_money_detail_id", SqlDbType.BigInt).Value = budget_money_major.budget_money_detail_id;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = budget_money_major.major_code;
                oCommand.Parameters.Add("budget_money_major_plan", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan;
                oCommand.Parameters.Add("budget_money_major_plan2", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan2;
                oCommand.Parameters.Add("budget_money_major_plan3", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan3;
                oCommand.Parameters.Add("budget_money_major_contribute", SqlDbType.Money).Value = budget_money_major.budget_money_major_contribute;
                oCommand.Parameters.Add("budget_money_major_use", SqlDbType.Money).Value = budget_money_major.budget_money_major_use;
                oCommand.Parameters.Add("budget_money_major_comment", SqlDbType.VarChar).Value = budget_money_major.budget_money_major_comment;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_money_major.c_created_by;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_MAJOR_UPD
        public bool SP_BUDGET_MONEY_MAJOR_UPD(Budget_money_major budget_money_major)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_MAJOR_UPD";
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.BigInt).Value = budget_money_major.budget_money_major_id;
                oCommand.Parameters.Add("budget_money_detail_id", SqlDbType.BigInt).Value = budget_money_major.budget_money_detail_id;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = budget_money_major.major_code;
                oCommand.Parameters.Add("budget_money_major_plan", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan;
                oCommand.Parameters.Add("budget_money_major_plan2", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan2;
                oCommand.Parameters.Add("budget_money_major_plan3", SqlDbType.Money).Value = budget_money_major.budget_money_major_plan3;
                oCommand.Parameters.Add("budget_money_major_contribute", SqlDbType.Money).Value = budget_money_major.budget_money_major_contribute;
                oCommand.Parameters.Add("budget_money_major_use", SqlDbType.Money).Value = budget_money_major.budget_money_major_use;
                oCommand.Parameters.Add("budget_money_major_comment", SqlDbType.VarChar).Value = budget_money_major.budget_money_major_comment;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_money_major.c_updated_by;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        #region SP_BUDGET_MONEY_MAJOR_DEL
        public bool SP_BUDGET_MONEY_MAJOR_DEL(string pBudget_money_major_id)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_BUDGET_MONEY_MAJOR_DEL";
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.BigInt).Value = pBudget_money_major_id;
                oCommand.ExecuteNonQuery();
                blnResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConn.Close();
                oCommand.Dispose();
                oConn.Dispose();
            }
            return blnResult;
        }
        #endregion

        public view_Budget_money_major GETMAJOR(string strCriteria)
        {
            view_Budget_money_major result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_MONEY_MAJOR_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_money_major>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion




        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
