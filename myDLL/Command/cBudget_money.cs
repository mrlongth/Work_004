using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

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
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = budget_money_head.budget_money_doc;
                oCommand.Parameters.Add("budget_money_year", SqlDbType.VarChar).Value = budget_money_head.budget_money_year;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_money_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_money_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_money_head.degree_code;
                oCommand.Parameters.Add("budget_money_plan", SqlDbType.Money).Value = budget_money_head.budget_money_plan;
                oCommand.Parameters.Add("budget_money_contribute", SqlDbType.VarChar).Value = budget_money_head.budget_money_contribute;
                oCommand.Parameters.Add("budget_money_use", SqlDbType.VarChar).Value = budget_money_head.budget_money_use;
                oCommand.Parameters.Add("budget_money_remain", SqlDbType.VarChar).Value = budget_money_head.budget_money_remain;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = budget_money_head.c_active;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_money_head.c_created_by;
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
                oCommand.Parameters.Add("budget_money_remain", SqlDbType.VarChar).Value = budget_money_head.budget_money_remain;
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
        public bool SP_BUDGET_MONEY_HEAD_DEL(string pBudget_money_doc, ref string strMessage)
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

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
