using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;
using System.Collections.Generic;

namespace myDLL
{
    public class cRecv : IDisposable
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

        public cRecv()
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



        #region RECV_HEAD

        #region sp_RECV_HEAD_SEL
        public bool SP_RECV_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_RECV_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_RECV_HEAD_SEL");
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

        #region sp_RECV_HEAD_INS
        public bool SP_RECV_HEAD_INS(Recv_head recv_head)
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
                oCommand.CommandText = "sp_RECV_HEAD_INS";
                SqlParameter oParamrecv_doc = new SqlParameter("recv_doc_no", SqlDbType.VarChar, 10)
                {
                    Direction = ParameterDirection.Output,
                    Value = recv_head.recv_doc_no
                };
                oCommand.Parameters.Add(oParamrecv_doc);
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = recv_head.recv_doc_no;
                oCommand.Parameters.Add("recv_year", SqlDbType.VarChar).Value = recv_head.recv_year;
                oCommand.Parameters.Add("recv_doc_ref", SqlDbType.VarChar).Value = recv_head.recv_doc_ref;
                oCommand.Parameters.Add("recv_date", SqlDbType.DateTime).Value = recv_head.recv_date;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = recv_head.major_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = recv_head.degree_code;
                oCommand.Parameters.Add("recv_remark", SqlDbType.VarChar).Value = recv_head.recv_remark;
                oCommand.Parameters.Add("recv_total", SqlDbType.Money).Value = recv_head.recv_total;
                oCommand.Parameters.Add("recv_reduce", SqlDbType.Money).Value = recv_head.recv_reduce;
                oCommand.Parameters.Add("recv_remain", SqlDbType.Money).Value = recv_head.recv_remain;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = recv_head.item_group_detail_id;            
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = recv_head.c_created_by;
                oCommand.ExecuteNonQuery();
                recv_head.recv_doc_no = oParamrecv_doc.Value.ToString();
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

        #region SP_RECV_HEAD_UPD
        public bool SP_RECV_HEAD_UPD(Recv_head recv_head)
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
                oCommand.CommandText = "sp_RECV_HEAD_UPD";
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = recv_head.recv_doc_no;
                oCommand.Parameters.Add("recv_year", SqlDbType.VarChar).Value = recv_head.recv_year;
                oCommand.Parameters.Add("recv_doc_ref", SqlDbType.VarChar).Value = recv_head.recv_doc_ref;
                oCommand.Parameters.Add("recv_date", SqlDbType.DateTime).Value = recv_head.recv_date;
                oCommand.Parameters.Add("major_code", SqlDbType.VarChar).Value = recv_head.major_code;
                oCommand.Parameters.Add("degree_code", SqlDbType.VarChar).Value = recv_head.degree_code;
                oCommand.Parameters.Add("recv_remark", SqlDbType.VarChar).Value = recv_head.recv_remark;
                oCommand.Parameters.Add("recv_total", SqlDbType.Money).Value = recv_head.recv_total;
                oCommand.Parameters.Add("recv_reduce", SqlDbType.Money).Value = recv_head.recv_reduce;
                oCommand.Parameters.Add("recv_remain", SqlDbType.Money).Value = recv_head.recv_remain;
                oCommand.Parameters.Add("item_group_detail_id", SqlDbType.Int).Value = recv_head.item_group_detail_id;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = recv_head.c_updated_by;
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

        #region SP_RECV_HEAD_DEL
        public bool SP_RECV_HEAD_DEL(string pcRecv_doc)
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
                oCommand.CommandText = "sp_RECV_HEAD_DEL";
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = pcRecv_doc;
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

        public view_Recv_head GET(string strCriteria)
        {
            view_Recv_head result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_RECV_HEAD_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Recv_head>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }

        #endregion

        #region RECV_DETAIL

        #region sp_RECV_DETAIL_SEL
        public bool SP_RECV_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_RECV_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_RECV_DETAIL_SEL");
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

        #region sp_RECV_DETAIL_INS
        public bool SP_RECV_DETAIL_INS(Recv_detail recv_detail)
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
                oCommand.CommandText = "sp_RECV_DETAIL_INS";

                SqlParameter oParamrecv_detail_id = new SqlParameter("recv_detail_id", SqlDbType.BigInt);
                oParamrecv_detail_id.Direction = ParameterDirection.Output;
                oParamrecv_detail_id.Value = recv_detail.recv_detail_id;
                oCommand.Parameters.Add(oParamrecv_detail_id);
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = recv_detail.recv_doc_no;
                oCommand.Parameters.Add("recv_item_code", SqlDbType.Int).Value = recv_detail.recv_item_code;
                oCommand.Parameters.Add("recv_item_is_reduce", SqlDbType.Bit).Value = recv_detail.recv_item_is_reduce;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = recv_detail.recv_item_rate;
                oCommand.Parameters.Add("recv_item_debit", SqlDbType.Money).Value = recv_detail.recv_item_debit;
                oCommand.Parameters.Add("recv_item_credit", SqlDbType.Money).Value = recv_detail.recv_item_credit;              
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = recv_detail.c_created_by;
                oCommand.ExecuteNonQuery();
                recv_detail.recv_detail_id = long.Parse(oParamrecv_detail_id.Value.ToString());
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

        #region SP_RECV_DETAIL_UPD
        public bool SP_RECV_DETAIL_UPD(Recv_detail recv_detail)
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
                oCommand.CommandText = "sp_RECV_DETAIL_UPD";
                oCommand.Parameters.Add("recv_detail_id", SqlDbType.BigInt).Value = recv_detail.recv_detail_id;
                oCommand.Parameters.Add("recv_doc_no", SqlDbType.VarChar).Value = recv_detail.recv_doc_no;
                oCommand.Parameters.Add("recv_item_code", SqlDbType.Int).Value = recv_detail.recv_item_code;
                oCommand.Parameters.Add("recv_item_is_reduce", SqlDbType.Bit).Value = recv_detail.recv_item_is_reduce;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = recv_detail.recv_item_rate;
                oCommand.Parameters.Add("recv_item_debit", SqlDbType.Money).Value = recv_detail.recv_item_debit;
                oCommand.Parameters.Add("recv_item_credit", SqlDbType.Money).Value = recv_detail.recv_item_credit;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = recv_detail.c_updated_by;
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

        #region SP_RECV_DETAIL_DEL
        public bool SP_RECV_DETAIL_DEL(string pRecv_detail_id)
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
                oCommand.CommandText = "sp_RECV_DETAIL_DEL";
                oCommand.Parameters.Add("recv_detail_id", SqlDbType.BigInt).Value = pRecv_detail_id;
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


        public List<view_Recv_detail> GETDETAILS(string strCriteria)
        {
            List<view_Recv_detail> results = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_RECV_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                results = Helper.ToClassInstanceCollection<view_Recv_detail>(ds.Tables[0]).ToList();
            }
            return results;
        }


        public view_Recv_detail GETDETAIL(string strCriteria)
        {
            view_Recv_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_RECV_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Recv_detail>(ds.Tables[0]).FirstOrDefault();
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
