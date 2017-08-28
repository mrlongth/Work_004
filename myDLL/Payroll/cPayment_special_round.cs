using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    using System.Runtime.Remoting.Messaging;

    public class cPayment_special_round : IDisposable
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

        public cPayment_special_round()
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

        #region SP_PAYMENT_SPECIAL_ROUND_SEL
        public bool SP_PAYMENT_SPECIAL_ROUND_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
        {
            bool blnResult = false;
            var oConn = new SqlConnection();
            var oCommand = new SqlCommand();
            var oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_PAYMENT_SPECIAL_ROUND_SEL";
                var oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_PAYMENT_SPECIAL_ROUND_SEL");
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

        #region SP_PAYMENT_SPECIAL_ROUND_DEL
        public bool SP_PAYMENT_SPECIAL_ROUND_DEL(string pRound_id, string pActive, string pC_updated_by, ref string strMessage)
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
                oCommand.CommandText = "sp_PAYMENT_SPECIAL_ROUND_DEL";
                // - - - - - - - - - - - -             
                var oParam_sp_round_id = new SqlParameter("sp_round_id", SqlDbType.Int);
                oParam_sp_round_id.Direction = ParameterDirection.Input;
                oParam_sp_round_id.Value = pRound_id;
                oCommand.Parameters.Add(oParam_sp_round_id);
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

        #region SP_PAYMENT_SPECIAL_ROUND_INS
        public bool SP_PAYMENT_SPECIAL_ROUND_INS(
                string ppayment_year,
                string ppay_year ,
                string ppay_semeter ,
                string ppay_item ,
                string ppay_begin_date ,
                string ppay_end_date ,
                string ppay_day ,
                string pround_status ,
                string pcomments ,
                string pc_active,
                string pc_created_by,
                ref string strMessage)
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
                oCommand.CommandText = "sp_PAYMENT_SPECIAL_ROUND_INS";
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("ppay_semeter", SqlDbType.VarChar).Value = ppay_semeter;
                oCommand.Parameters.Add("ppay_item", SqlDbType.VarChar).Value = ppay_item;
                oCommand.Parameters.Add("ppay_begin_date", SqlDbType.DateTime).Value = cCommon.CheckDate(ppay_begin_date);
                oCommand.Parameters.Add("ppay_end_date", SqlDbType.DateTime).Value = cCommon.CheckDate(ppay_end_date);
                oCommand.Parameters.Add("ppay_day", SqlDbType.Int).Value = Helper.CInt(ppay_day);
                oCommand.Parameters.Add("pround_status", SqlDbType.VarChar).Value = pround_status;
                oCommand.Parameters.Add("pcomments", SqlDbType.VarChar).Value = pcomments;                
                oCommand.Parameters.Add("pc_active", SqlDbType.VarChar).Value =  pc_active;
                oCommand.Parameters.Add("pc_created_by", SqlDbType.VarChar).Value = pc_created_by;
                // - - - - - - - - - - - -             
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

        #region SP_PAYMENT_SPECIAL_ROUND_UPD
        public bool SP_PAYMENT_SPECIAL_ROUND_UPD(
                string psp_round_id,
                string pround_status,
                string pc_updated_by,
                ref string strMessage)
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
                oCommand.CommandText = "sp_PAYMENT_SPECIAL_ROUND_UPD";
                oCommand.Parameters.Add("psp_round_id", SqlDbType.Int).Value = psp_round_id;
                oCommand.Parameters.Add("pround_status", SqlDbType.VarChar).Value = pround_status;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = pc_updated_by;
                // - - - - - - - - - - - -             
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


        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
