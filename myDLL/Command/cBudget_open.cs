using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cBudget_open : IDisposable
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

        public cBudget_open()
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



        #region BUDGET_OPEN_HEAD

        #region sp_BUDGET_OPEN_HEAD_SEL
        public bool SP_BUDGET_OPEN_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_OPEN_HEAD_SEL");
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

        #region sp_BUDGET_OPEN_HEAD_INS
        public bool SP_BUDGET_OPEN_HEAD_INS(Budget_open_head budget_open_head)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_HEAD_INS";
                SqlParameter oParambudget_open_doc = new SqlParameter("budget_open_doc", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = budget_open_head.budget_open_doc
                };
                oCommand.Parameters.Add(oParambudget_open_doc);
                oCommand.Parameters.Add("ef_open_doc", SqlDbType.DateTime).Value = budget_open_head.ef_open_doc;                
                oCommand.Parameters.Add("budget_open_date", SqlDbType.DateTime).Value = budget_open_head.budget_open_date;
                oCommand.Parameters.Add("budget_open_year", SqlDbType.VarChar).Value = budget_open_head.budget_open_year;
                oCommand.Parameters.Add("open_code", SqlDbType.VarChar).Value = budget_open_head.open_code;
                oCommand.Parameters.Add("open_title", SqlDbType.VarChar).Value = budget_open_head.open_title;
                oCommand.Parameters.Add("open_command_desc", SqlDbType.VarChar).Value = budget_open_head.open_command_desc;
                oCommand.Parameters.Add("open_desc", SqlDbType.VarChar).Value = budget_open_head.open_desc;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_open_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_open_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_open_head.degree_code;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = budget_open_head.major_code;
                oCommand.Parameters.Add("open_remark", SqlDbType.VarChar).Value = budget_open_head.open_remark;
                oCommand.Parameters.Add("open_amount", SqlDbType.Money).Value = budget_open_head.open_amount;
                oCommand.Parameters.Add("person_open", SqlDbType.VarChar).Value = budget_open_head.person_open;
                oCommand.Parameters.Add("approve_head_status", SqlDbType.VarChar).Value = budget_open_head.approve_head_status;                
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_open_head.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_open_head.budget_open_doc = oParambudget_open_doc.Value.ToString();
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

        #region SP_BUDGET_OPEN_HEAD_UPD
        public bool SP_BUDGET_OPEN_HEAD_UPD(Budget_open_head budget_open_head)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_HEAD_UPD";
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = budget_open_head.budget_open_doc;
                oCommand.Parameters.Add("ef_open_doc", SqlDbType.DateTime).Value = budget_open_head.ef_open_doc;
                oCommand.Parameters.Add("budget_open_date", SqlDbType.DateTime).Value = budget_open_head.budget_open_date;
                oCommand.Parameters.Add("budget_open_year", SqlDbType.VarChar).Value = budget_open_head.budget_open_year;
                oCommand.Parameters.Add("open_code", SqlDbType.VarChar).Value = budget_open_head.open_code;
                oCommand.Parameters.Add("open_title", SqlDbType.VarChar).Value = budget_open_head.open_title;
                oCommand.Parameters.Add("open_command_desc", SqlDbType.VarChar).Value = budget_open_head.open_command_desc;
                oCommand.Parameters.Add("open_desc", SqlDbType.VarChar).Value = budget_open_head.open_desc;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_open_head.budget_type;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = budget_open_head.budget_plan_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = budget_open_head.degree_code;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = budget_open_head.major_code;
                oCommand.Parameters.Add("open_remark", SqlDbType.VarChar).Value = budget_open_head.open_remark;
                oCommand.Parameters.Add("open_amount", SqlDbType.Money).Value = budget_open_head.open_amount;
                oCommand.Parameters.Add("person_open", SqlDbType.VarChar).Value = budget_open_head.person_open;
                oCommand.Parameters.Add("approve_head_status", SqlDbType.VarChar).Value = budget_open_head.approve_head_status;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_open_head.c_updated_by;
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

        #region SP_BUDGET_OPEN_HEAD_DEL
        public bool SP_BUDGET_OPEN_HEAD_DEL(string pcBudget_open_doc)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_HEAD_DEL";
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = pcBudget_open_doc;
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

        public view_Budget_open_head GET(string strCriteria)
        {
            view_Budget_open_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_OPEN_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_open_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region BUDGET_OPEN_DETAIL

        #region sp_BUDGET_OPEN_DETAIL_SEL
        public bool SP_BUDGET_OPEN_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_OPEN_DETAIL_SEL");
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

        #region sp_BUDGET_OPEN_DETAIL_INS
        public bool SP_BUDGET_OPEN_DETAIL_INS(Budget_open_detail budget_open_detail)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_DETAIL_INS";

                SqlParameter oParambudget_open_detail_id = new SqlParameter("budget_open_detail_id", SqlDbType.BigInt);
                oParambudget_open_detail_id.Direction = ParameterDirection.Output;
                oParambudget_open_detail_id.Value = budget_open_detail.budget_open_detail_id;
                oCommand.Parameters.Add(oParambudget_open_detail_id);
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = budget_open_detail.budget_open_doc;
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.Int).Value = budget_open_detail.budget_money_major_id;
                oCommand.Parameters.Add("budget_open_detail_remark", SqlDbType.VarChar).Value = budget_open_detail.budget_open_detail_remark;                
                oCommand.Parameters.Add("budget_open_detail_amount", SqlDbType.Money).Value = budget_open_detail.budget_open_detail_amount;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_open_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_open_detail.budget_open_detail_id = long.Parse(oParambudget_open_detail_id.Value.ToString());
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

        #region SP_BUDGET_OPEN_DETAIL_UPD
        public bool SP_BUDGET_OPEN_DETAIL_UPD(Budget_open_detail budget_open_detail)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_DETAIL_UPD";
                oCommand.Parameters.Add("budget_open_detail_id", SqlDbType.BigInt).Value = budget_open_detail.budget_open_detail_id;
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = budget_open_detail.budget_open_doc;
                oCommand.Parameters.Add("budget_money_major_id", SqlDbType.Int).Value = budget_open_detail.budget_money_major_id;
                oCommand.Parameters.Add("budget_open_detail_remark", SqlDbType.VarChar).Value = budget_open_detail.budget_open_detail_remark;
                oCommand.Parameters.Add("budget_open_detail_amount", SqlDbType.Money).Value = budget_open_detail.budget_open_detail_amount;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_open_detail.c_updated_by;
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

        #region SP_BUDGET_OPEN_DETAIL_DEL
        public bool SP_BUDGET_OPEN_DETAIL_DEL(string budget_open_doc)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_DETAIL_DEL";
                //oCommand.Parameters.Add("budget_open_detail_id", SqlDbType.BigInt).Value = pBudget_open_detail_id;
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = budget_open_doc;
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


        #region SP_BUDGET_OPEN_TOTAL_UPD
        public bool SP_BUDGET_OPEN_TOTAL_UPD(string budget_open_doc)
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
                oCommand.CommandText = "sp_BUDGET_OPEN_TOTAL_UPD";
                //oCommand.Parameters.Add("budget_open_detail_id", SqlDbType.BigInt).Value = pBudget_open_detail_id;
                oCommand.Parameters.Add("budget_open_doc", SqlDbType.VarChar).Value = budget_open_doc;
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

        

        public view_Budget_open_detail GETDETAIL(string strCriteria)
        {
            view_Budget_open_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_OPEN_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_open_detail>(ds.Tables[0]).FirstOrDefault();
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
