﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cRecv_item : IDisposable
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

        public cRecv_item()
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

        #region SP_RECV_ITEM_SEL
        public bool SP_RECV_ITEM_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_RECV_ITEM_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_RECV_ITEM_SEL");
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


        public Recv_item GET(string strCriteria)
        {
            Recv_item result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_RECV_ITEM_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<Recv_item>(ds.Tables[0]).FirstOrDefault();
            }
            return result;
        }



        #region SP_RECV_ITEM_INS
        public bool SP_RECV_ITEM_INS(Recv_item Recv_item)
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
                oCommand.CommandText = "sp_RECV_ITEM_INS";
                oCommand.Parameters.Add("recv_item_code", SqlDbType.VarChar).Value = Recv_item.recv_item_code;
                oCommand.Parameters.Add("recv_item_year", SqlDbType.VarChar).Value = Recv_item.recv_item_year;
                oCommand.Parameters.Add("recv_item_name", SqlDbType.VarChar).Value = Recv_item.recv_item_name;
                oCommand.Parameters.Add("recv_item_type", SqlDbType.VarChar).Value = Recv_item.recv_item_type;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = Recv_item.recv_item_rate;
                oCommand.Parameters.Add("recv_item_remark", SqlDbType.VarChar).Value = Recv_item.recv_item_remark;
                oCommand.Parameters.Add("recv_item_is_director", SqlDbType.Bit).Value = Recv_item.recv_item_is_director;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = Recv_item.c_active;                
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = Recv_item.c_created_by;
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

        #region SP_RECV_ITEM_UPD
        public bool SP_RECV_ITEM_UPD(Recv_item Recv_item)
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
                oCommand.CommandText = "sp_RECV_ITEM_UPD";
                oCommand.Parameters.Add("recv_item_code", SqlDbType.VarChar).Value = Recv_item.recv_item_code;
                oCommand.Parameters.Add("recv_item_year", SqlDbType.VarChar).Value = Recv_item.recv_item_year;
                oCommand.Parameters.Add("recv_item_name", SqlDbType.VarChar).Value = Recv_item.recv_item_name;
                oCommand.Parameters.Add("recv_item_type", SqlDbType.VarChar).Value = Recv_item.recv_item_type;
                oCommand.Parameters.Add("recv_item_rate", SqlDbType.Money).Value = Recv_item.recv_item_rate;
                oCommand.Parameters.Add("recv_item_remark", SqlDbType.VarChar).Value = Recv_item.recv_item_remark;
                oCommand.Parameters.Add("recv_item_is_director", SqlDbType.Bit).Value = Recv_item.recv_item_is_director;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = Recv_item.c_active;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = Recv_item.c_updated_by;
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

        #region SP_RECV_ITEM_DEL
        public bool SP_RECV_ITEM_DEL(string pRecv_item_code)
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
                oCommand.CommandText = "sp_RECV_ITEM_DEL";
                oCommand.Parameters.Add("Recv_item_code", SqlDbType.VarChar).Value = pRecv_item_code;
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

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
