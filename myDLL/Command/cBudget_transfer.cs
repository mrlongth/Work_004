using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;
using System.Collections.Generic;

namespace myDLL
{
    public class cBudget_transfer : IDisposable
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

        public cBudget_transfer()
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



        #region BUDGET_TRANSFER_HEAD

        #region sp_BUDGET_TRANSFER_HEAD_SEL
        public bool SP_BUDGET_TRANSFER_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_TRANSFER_HEAD_SEL");
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

        #region sp_BUDGET_TRANSFER_HEAD_INS
        public bool SP_BUDGET_TRANSFER_HEAD_INS(Budget_transfer_head budget_transfer_head)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_HEAD_INS";
                SqlParameter oParambudget_transfer_doc = new SqlParameter("budget_transfer_doc", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = budget_transfer_head.budget_transfer_doc
                };
                oCommand.Parameters.Add(oParambudget_transfer_doc);
                oCommand.Parameters.Add("budget_doc_no", SqlDbType.VarChar).Value = budget_transfer_head.budget_doc_no;                
                oCommand.Parameters.Add("budget_transfer_year", SqlDbType.VarChar).Value = budget_transfer_head.budget_transfer_year;
                oCommand.Parameters.Add("budget_transfer_date", SqlDbType.DateTime).Value = budget_transfer_head.budget_transfer_date;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_transfer_head.budget_type;
                oCommand.Parameters.Add("degree_code_from", SqlDbType.VarChar).Value = budget_transfer_head.degree_code_from;
                oCommand.Parameters.Add("major_code_from", SqlDbType.VarChar).Value = budget_transfer_head.major_code_from;
                oCommand.Parameters.Add("budget_plan_code_from", SqlDbType.VarChar).Value = budget_transfer_head.budget_plan_code_from;
                oCommand.Parameters.Add("degree_code_to", SqlDbType.VarChar).Value = budget_transfer_head.degree_code_to;
                oCommand.Parameters.Add("major_code_to", SqlDbType.VarChar).Value = budget_transfer_head.major_code_to;
                oCommand.Parameters.Add("budget_plan_code_to", SqlDbType.VarChar).Value = budget_transfer_head.budget_plan_code_to;
                oCommand.Parameters.Add("budget_transfer_remark", SqlDbType.VarChar).Value = budget_transfer_head.budget_transfer_remark;
                oCommand.Parameters.Add("budget_transfer_amount", SqlDbType.Money).Value = budget_transfer_head.budget_transfer_amount;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_transfer_head.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_transfer_head.budget_transfer_doc = oParambudget_transfer_doc.Value.ToString();
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

        #region SP_BUDGET_TRANSFER_HEAD_UPD
        public bool SP_BUDGET_TRANSFER_HEAD_UPD(Budget_transfer_head budget_transfer_head)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_HEAD_UPD";
                oCommand.Parameters.Add("budget_transfer_doc", SqlDbType.VarChar).Value = budget_transfer_head.budget_transfer_doc;
                oCommand.Parameters.Add("budget_doc_no", SqlDbType.VarChar).Value = budget_transfer_head.budget_doc_no;
                oCommand.Parameters.Add("budget_transfer_year", SqlDbType.VarChar).Value = budget_transfer_head.budget_transfer_year;
                oCommand.Parameters.Add("budget_transfer_date", SqlDbType.DateTime).Value = budget_transfer_head.budget_transfer_date;
                oCommand.Parameters.Add("budget_type", SqlDbType.VarChar).Value = budget_transfer_head.budget_type;
                oCommand.Parameters.Add("degree_code_from", SqlDbType.VarChar).Value = budget_transfer_head.degree_code_from;
                oCommand.Parameters.Add("major_code_from", SqlDbType.VarChar).Value = budget_transfer_head.major_code_from;
                oCommand.Parameters.Add("budget_plan_code_from", SqlDbType.VarChar).Value = budget_transfer_head.budget_plan_code_from;
                oCommand.Parameters.Add("degree_code_to", SqlDbType.VarChar).Value = budget_transfer_head.degree_code_to;
                oCommand.Parameters.Add("major_code_to", SqlDbType.VarChar).Value = budget_transfer_head.major_code_to;
                oCommand.Parameters.Add("budget_plan_code_to", SqlDbType.VarChar).Value = budget_transfer_head.budget_plan_code_to;
                oCommand.Parameters.Add("budget_transfer_remark", SqlDbType.VarChar).Value = budget_transfer_head.budget_transfer_remark;
                oCommand.Parameters.Add("budget_transfer_amount", SqlDbType.Money).Value = budget_transfer_head.budget_transfer_amount;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_transfer_head.c_updated_by;
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

        #region SP_BUDGET_TRANSFER_HEAD_DEL
        public bool SP_BUDGET_TRANSFER_HEAD_DEL(string pcBudget_transfer_doc)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_HEAD_DEL";
                oCommand.Parameters.Add("budget_transfer_doc", SqlDbType.VarChar).Value = pcBudget_transfer_doc;
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

        public view_Budget_transfer_head GET(string strCriteria)
        {
            view_Budget_transfer_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_TRANSFER_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_transfer_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region BUDGET_TRANSFER_DETAIL

        #region sp_BUDGET_TRANSFER_DETAIL_SEL
        public bool SP_BUDGET_TRANSFER_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_BUDGET_TRANSFER_DETAIL_SEL");
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

        #region sp_BUDGET_TRANSFER_DETAIL_INS
        public bool SP_BUDGET_TRANSFER_DETAIL_INS(Budget_transfer_detail budget_transfer_detail)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_DETAIL_INS";

                SqlParameter oParambudget_transfer_detail_id = new SqlParameter("budget_transfer_detail_id", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output,
                    Value = budget_transfer_detail.budget_transfer_detail_id
                };
                oCommand.Parameters.Add(oParambudget_transfer_detail_id);
                oCommand.Parameters.Add("budget_transfer_doc", SqlDbType.VarChar).Value = budget_transfer_detail.budget_transfer_doc;
                oCommand.Parameters.Add("budget_money_major_id_from", SqlDbType.BigInt).Value = budget_transfer_detail.budget_money_major_id_from;
                oCommand.Parameters.Add("budget_money_major_id_to", SqlDbType.BigInt).Value = budget_transfer_detail.budget_money_major_id_to;
                oCommand.Parameters.Add("budget_transfer_detail_amount", SqlDbType.Money).Value = budget_transfer_detail.budget_transfer_detail_amount;
                oCommand.Parameters.Add("budget_transfer_detail_remark", SqlDbType.VarChar).Value = budget_transfer_detail.budget_transfer_detail_remark;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = budget_transfer_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                budget_transfer_detail.budget_transfer_detail_id = long.Parse(oParambudget_transfer_detail_id.Value.ToString());
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

        #region SP_BUDGET_TRANSFER_DETAIL_UPD
        public bool SP_BUDGET_TRANSFER_DETAIL_UPD(Budget_transfer_detail budget_transfer_detail)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_DETAIL_UPD";
                oCommand.Parameters.Add("budget_transfer_detail_id", SqlDbType.BigInt).Value = budget_transfer_detail.budget_transfer_detail_id;
                oCommand.Parameters.Add("budget_transfer_doc", SqlDbType.VarChar).Value = budget_transfer_detail.budget_transfer_doc;
                oCommand.Parameters.Add("budget_money_major_id_from", SqlDbType.BigInt).Value = budget_transfer_detail.budget_money_major_id_from;
                oCommand.Parameters.Add("budget_money_major_id_to", SqlDbType.BigInt).Value = budget_transfer_detail.budget_money_major_id_to;
                oCommand.Parameters.Add("budget_transfer_detail_amount", SqlDbType.Money).Value = budget_transfer_detail.budget_transfer_detail_amount;
                oCommand.Parameters.Add("budget_transfer_detail_remark", SqlDbType.VarChar).Value = budget_transfer_detail.budget_transfer_detail_remark;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = budget_transfer_detail.c_updated_by;
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

        #region SP_BUDGET_TRANSFER_DETAIL_DEL
        public bool SP_BUDGET_TRANSFER_DETAIL_DEL(string pBudget_transfer_detail_id)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_DETAIL_DEL";
                oCommand.Parameters.Add("budget_transfer_detail_id", SqlDbType.BigInt).Value = pBudget_transfer_detail_id;
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


        #region sp_BUDGET_TRANSFER_TOTAL_UPD
        public bool SP_BUDGET_TRANSFER_TOTAL_UPD(string budget_transfer_doc)
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
                oCommand.CommandText = "sp_BUDGET_TRANSFER_TOTAL_UPD";
                oCommand.Parameters.Add("budget_transfer_doc", SqlDbType.VarChar).Value = budget_transfer_doc;
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


        public List<view_Budget_transfer_detail> GETDETAILS(string strCriteria)
        {
            List<view_Budget_transfer_detail> results = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_TRANSFER_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                results = Helper.ToClassInstanceCollection<view_Budget_transfer_detail>(ds.Tables[0]).ToList();
            }
            return results;
        }

        public view_Budget_transfer_detail GETDETAIL(string strCriteria)
        {
            view_Budget_transfer_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_BUDGET_TRANSFER_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Budget_transfer_detail>(ds.Tables[0]).FirstOrDefault();
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
