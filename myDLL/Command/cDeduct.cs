using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;
using System.Collections.Generic;

namespace myDLL
{
    public class cDeduct : IDisposable
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

        public cDeduct()
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



        #region DEDUCT_HEAD

        #region sp_DEDUCT_HEAD_SEL
        public bool SP_DEDUCT_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_DEDUCT_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_DEDUCT_HEAD_SEL");
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

        #region sp_DEDUCT_HEAD_INS
        public bool SP_DEDUCT_HEAD_INS(Deduct_head deduct_head)
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
                oCommand.CommandText = "sp_DEDUCT_HEAD_INS";
                SqlParameter oParamdeduct_doc = new SqlParameter("deduct_doc_no", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = deduct_head.deduct_doc_no
                };
                oCommand.Parameters.Add(oParamdeduct_doc);
                oCommand.Parameters.Add("deduct_year", SqlDbType.VarChar).Value = deduct_head.deduct_year;
                oCommand.Parameters.Add("deduct_date", SqlDbType.DateTime).Value = deduct_head.deduct_date;
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = deduct_head.budget_money_doc;
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = deduct_head.budget_receive_doc;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = deduct_head.major_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = deduct_head.degree_code;
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = deduct_head.recv_doc_no;
                oCommand.Parameters.Add("recv_total_amount", SqlDbType.Money).Value = deduct_head.recv_total_amount;
                oCommand.Parameters.Add("deduct_total_reduce", SqlDbType.Money).Value = deduct_head.deduct_total_reduce;
                oCommand.Parameters.Add("deduct_total_reduce_director", SqlDbType.Money).Value = deduct_head.deduct_total_reduce_director;
                oCommand.Parameters.Add("deduct_total_remain", SqlDbType.Money).Value = deduct_head.deduct_total_remain;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = deduct_head.budget_plan_code;
                oCommand.Parameters.Add("deduct_remark", SqlDbType.VarChar).Value = deduct_head.deduct_remark;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = deduct_head.item_group_detail_id;
                oCommand.Parameters.Add("approve_head_status", SqlDbType.Int).Value = deduct_head.@approve_head_status;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = deduct_head.c_created_by;
                oCommand.ExecuteNonQuery();
                deduct_head.deduct_doc_no = oParamdeduct_doc.Value.ToString();
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

        #region SP_DEDUCT_HEAD_UPD
        public bool SP_DEDUCT_HEAD_UPD(Deduct_head deduct_head)
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
                oCommand.CommandText = "sp_DEDUCT_HEAD_UPD";
                oCommand.Parameters.Add("deduct_doc_no", SqlDbType.VarChar).Value = deduct_head.deduct_doc_no;
                oCommand.Parameters.Add("deduct_year", SqlDbType.VarChar).Value = deduct_head.deduct_year;
                oCommand.Parameters.Add("deduct_date", SqlDbType.DateTime).Value = deduct_head.deduct_date;
                oCommand.Parameters.Add("budget_money_doc", SqlDbType.VarChar).Value = deduct_head.budget_money_doc;
                oCommand.Parameters.Add("budget_receive_doc", SqlDbType.VarChar).Value = deduct_head.budget_receive_doc;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = deduct_head.major_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = deduct_head.degree_code;
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = deduct_head.recv_doc_no;
                oCommand.Parameters.Add("recv_total_amount", SqlDbType.Money).Value = deduct_head.recv_total_amount;
                oCommand.Parameters.Add("deduct_total_reduce", SqlDbType.Money).Value = deduct_head.deduct_total_reduce;
                oCommand.Parameters.Add("deduct_total_reduce_director", SqlDbType.Money).Value = deduct_head.deduct_total_reduce_director;
                oCommand.Parameters.Add("deduct_total_remain", SqlDbType.Money).Value = deduct_head.deduct_total_remain;
                oCommand.Parameters.Add("budget_plan_code", SqlDbType.VarChar).Value = deduct_head.budget_plan_code;
                oCommand.Parameters.Add("deduct_remark", SqlDbType.VarChar).Value = deduct_head.deduct_remark;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = deduct_head.item_group_detail_id;
                oCommand.Parameters.Add("approve_head_status", SqlDbType.Int).Value = deduct_head.@approve_head_status;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = deduct_head.c_updated_by;
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

        #region SP_DEDUCT_HEAD_DEL
        public bool SP_DEDUCT_HEAD_DEL(string pcDeduct_doc)
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
                oCommand.CommandText = "sp_DEDUCT_HEAD_DEL";
                oCommand.Parameters.Add("deduct_doc_no", SqlDbType.VarChar).Value = pcDeduct_doc;
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

        public view_Deduct_head GET(string strCriteria)
        {
            view_Deduct_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_DEDUCT_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Deduct_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region DEDUCT_DETAIL

        #region sp_DEDUCT_DETAIL_SEL
        public bool SP_DEDUCT_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_DEDUCT_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_DEDUCT_DETAIL_SEL");
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

        #region sp_DEDUCT_DETAIL_INS
        public bool SP_DEDUCT_DETAIL_INS(Deduct_detail deduct_detail)
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
                oCommand.CommandText = "sp_DEDUCT_DETAIL_INS";

                SqlParameter oParamdeduct_detail_id = new SqlParameter("deduct_detail_id", SqlDbType.BigInt);
                oParamdeduct_detail_id.Direction = ParameterDirection.Output;
                oParamdeduct_detail_id.Value = deduct_detail.deduct_detail_id;
                oCommand.Parameters.Add(oParamdeduct_detail_id);
                oCommand.Parameters.Add("deduct_doc_no", SqlDbType.VarChar).Value = deduct_detail.deduct_doc_no;
                oCommand.Parameters.Add("recv_item_code", SqlDbType.VarChar).Value = deduct_detail.recv_item_code;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = deduct_detail.recv_item_rate;
                oCommand.Parameters.Add("deduct_item_amount", SqlDbType.Money).Value = deduct_detail.deduct_item_amount;
                oCommand.Parameters.Add("deduct_item_is_director", SqlDbType.Bit).Value = deduct_detail.deduct_item_is_director;
                oCommand.Parameters.Add("deduct_item_remark", SqlDbType.VarChar).Value = deduct_detail.deduct_item_remark;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = deduct_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                deduct_detail.deduct_detail_id = long.Parse(oParamdeduct_detail_id.Value.ToString());
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

        #region SP_DEDUCT_DETAIL_UPD
        public bool SP_DEDUCT_DETAIL_UPD(Deduct_detail deduct_detail)
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
                oCommand.CommandText = "sp_DEDUCT_DETAIL_UPD";
                oCommand.Parameters.Add("deduct_detail_id", SqlDbType.VarChar).Value = deduct_detail.deduct_detail_id;
                oCommand.Parameters.Add("deduct_doc_no", SqlDbType.VarChar).Value = deduct_detail.deduct_doc_no;
                oCommand.Parameters.Add("recv_item_code", SqlDbType.VarChar).Value = deduct_detail.recv_item_code;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = deduct_detail.recv_item_rate;
                oCommand.Parameters.Add("deduct_item_amount", SqlDbType.Money).Value = deduct_detail.deduct_item_amount;
                oCommand.Parameters.Add("deduct_item_is_director", SqlDbType.Bit).Value = deduct_detail.deduct_item_is_director;
                oCommand.Parameters.Add("deduct_item_remark", SqlDbType.VarChar).Value = deduct_detail.deduct_item_remark;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = deduct_detail.c_updated_by;
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

        #region SP_DEDUCT_DETAIL_DEL
        public bool SP_DEDUCT_DETAIL_DEL(long pDeduct_detail_id)
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
                oCommand.CommandText = "sp_DEDUCT_DETAIL_DEL";
                oCommand.Parameters.Add("deduct_detail_id", SqlDbType.BigInt).Value = pDeduct_detail_id;
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

        #region SP_DEDUCT_DETAIL_DEL_BY_DOC
        public bool SP_DEDUCT_DETAIL_DEL_BY_DOC(string pDeduct_doc_no)
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
                oCommand.CommandText = "sp_DEDUCT_DETAIL_DEL_BY_DOC";
                oCommand.Parameters.Add("deduct_doc_no", SqlDbType.BigInt).Value = pDeduct_doc_no;
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

        public List<view_Deduct_detail> GETDETAILS(string strCriteria)
        {
            List<view_Deduct_detail> results = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_DEDUCT_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                results = Helper.ToClassInstanceCollection<view_Deduct_detail>(ds.Tables[0]).ToList();
            }
            return results;
        }

        public view_Deduct_detail GETDETAIL(string strCriteria)
        {
            view_Deduct_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_DEDUCT_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Deduct_detail>(ds.Tables[0]).FirstOrDefault();
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
