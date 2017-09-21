using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cBudget_receive : IDisposable
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

        public cBudget_receive()
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



        #region BUDGET_RECEIVE_HEAD

        #region sp_BUDGET_RECEIVE_HEAD_SEL
        public bool SP_BUDGET_RECEIVE_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_RECEIVE_HEAD_SEL");
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

        #region sp_BUDGET_RECEIVE_HEAD_INS
        public bool SP_BUDGET_RECEIVE_HEAD_INS(Budget_receive_head budget_receive_head)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_HEAD_INS";

                SqlParameter oParambudget_receive_doc = new SqlParameter("budget_receive_doc", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = budget_receive_head.budget_receive_doc
                };
                oCommand.Parameters.Add(oParambudget_receive_doc);

                oCommand.Parameters.Add("budget_receive_date", SqlDbType.DateTime).Value = budget_receive_head.budget_receive_date;
                oCommand.Parameters.Add("budget_receive_year", SqlDbType.VarChar).Value = budget_receive_head.budget_receive_year;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_receive_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_receive_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_receive_head.degree_code;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = budget_receive_head.item_group_detail_id;
                oCommand.Parameters.Add("budget_receive_total", SqlDbType.Money).Value = budget_receive_head.budget_receive_total;
                oCommand.Parameters.Add("budget_receive_comment", SqlDbType.VarChar).Value = budget_receive_head.@budget_receive_comment;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_receive_head.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_receive_head.budget_receive_doc = oParambudget_receive_doc.Value.ToString();

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

        #region SP_BUDGET_RECEIVE_HEAD_UPD
        public bool SP_BUDGET_RECEIVE_HEAD_UPD(Budget_receive_head budget_receive_head)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_HEAD_UPD";
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = budget_receive_head.budget_receive_doc;
                oCommand.Parameters.Add("budget_receive_date", SqlDbType.DateTime).Value = budget_receive_head.budget_receive_date;
                oCommand.Parameters.Add("budget_receive_year", SqlDbType.VarChar).Value = budget_receive_head.budget_receive_year;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_receive_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_receive_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_receive_head.degree_code;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = budget_receive_head.item_group_detail_id;
                oCommand.Parameters.Add("budget_receive_total", SqlDbType.Money).Value = budget_receive_head.budget_receive_total;
                oCommand.Parameters.Add("budget_receive_comment", SqlDbType.VarChar).Value = budget_receive_head.@budget_receive_comment;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_receive_head.c_updated_by;
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

        #region SP_BUDGET_RECEIVE_HEAD_DEL
        public bool SP_BUDGET_RECEIVE_HEAD_DEL(string pcBudget_receive_doc)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_HEAD_DEL";
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = pcBudget_receive_doc;
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

        public view_Budget_receive_head GET(string strCriteria)
        {
            view_Budget_receive_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_RECEIVE_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_receive_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region BUDGET_RECEIVE_DETAIL

        #region sp_BUDGET_RECEIVE_DETAIL_SEL
        public bool SP_BUDGET_RECEIVE_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_RECEIVE_DETAIL_SEL");
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

        #region sp_BUDGET_RECEIVE_DETAIL_INS
        public bool SP_BUDGET_RECEIVE_DETAIL_INS(Budget_receive_detail budget_revieve_detail)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_DETAIL_INS";

                SqlParameter oParambudget_revieve_detail_id = new SqlParameter("budget_revieve_detail_id", SqlDbType.BigInt);
                oParambudget_revieve_detail_id.Direction = ParameterDirection.Output;
                oParambudget_revieve_detail_id.Value = budget_revieve_detail.budget_receive_detail_id;
                oCommand.Parameters.Add(oParambudget_revieve_detail_id);
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = budget_revieve_detail.budget_receive_doc;
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.Int).Value = budget_revieve_detail.budget_money_major_id;
                oCommand.Parameters.Add("budget_receive_detail_contribute", SqlDbType.Money).Value = budget_revieve_detail.budget_receive_detail_contribute;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_revieve_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_revieve_detail.budget_receive_detail_id = long.Parse(oParambudget_revieve_detail_id.Value.ToString());
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

        #region SP_BUDGET_RECEIVE_DETAIL_UPD
        public bool SP_BUDGET_RECEIVE_DETAIL_UPD(Budget_receive_detail budget_revieve_detail)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_DETAIL_UPD";
                oCommand.Parameters.Add("budget_revieve_detail_id", SqlDbType.BigInt).Value = budget_revieve_detail.budget_receive_detail_id;
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = budget_revieve_detail.budget_receive_doc;
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.Int).Value = budget_revieve_detail.budget_money_major_id;
                oCommand.Parameters.Add("budget_receive_detail_contribute", SqlDbType.Money).Value = budget_revieve_detail.budget_receive_detail_contribute;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_revieve_detail.c_updated_by;
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

        #region SP_BUDGET_RECEIVE_DETAIL_DEL
        public bool SP_BUDGET_RECEIVE_DETAIL_DEL(string pBudget_receive_detail_id)
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
                oCommand.CommandText = "sp_BUDGET_RECEIVE_DETAIL_DEL";
                oCommand.Parameters.Add("budget_revieve_detail_id", SqlDbType.BigInt).Value = pBudget_receive_detail_id;
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

        public view_Budget_receive_detail GETDETAIL(string strCriteria)
        {
            view_Budget_receive_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_RECEIVE_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_receive_detail>(ds.Tables[0]).FirstOrDefault();
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
