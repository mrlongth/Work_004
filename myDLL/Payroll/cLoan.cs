using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    public class cLoan : IDisposable
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

        public cLoan()
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



        #region SP_LOAN_SEL
        public bool SP_SEL_LOAN(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_LOAN_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_LOAN_SEL");
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

        #region SP_INS_LOAN
        public bool SP_INS_LOAN(string ploan_code, string ploan_name, string ploan_desc, string pC_created_by, ref string strMessage)
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
                oCommand.CommandText = "sp_LOAN_INS";
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_code = new SqlParameter("loan_code", SqlDbType.NVarChar);
                oParam_loan_code.Direction = ParameterDirection.Input;
                oParam_loan_code.Value = ploan_code;
                oCommand.Parameters.Add(oParam_loan_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_name = new SqlParameter("loan_name", SqlDbType.NVarChar);
                oParam_loan_name.Direction = ParameterDirection.Input;
                oParam_loan_name.Value = ploan_name;
                oCommand.Parameters.Add(oParam_loan_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_desc = new SqlParameter("loan_desc", SqlDbType.NVarChar);
                oParam_loan_desc.Direction = ParameterDirection.Input;
                oParam_loan_desc.Value = ploan_desc;
                oCommand.Parameters.Add(oParam_loan_desc);

                // - - - - - - - - - - - -             
                SqlParameter oParam_c_created_by = new SqlParameter("c_created_by", SqlDbType.NVarChar);
                oParam_c_created_by.Direction = ParameterDirection.Input;
                oParam_c_created_by.Value = pC_created_by;
                oCommand.Parameters.Add(oParam_c_created_by);
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

        #region SP_UPD_LOAN
        public bool SP_UPD_LOAN(string ploan_code, string ploan_name, string ploan_desc, string pc_updated_by, ref string strMessage)
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
                oCommand.CommandText = "sp_LOAN_UPD";
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_code = new SqlParameter("loan_code", SqlDbType.NVarChar);
                oParam_loan_code.Direction = ParameterDirection.Input;
                oParam_loan_code.Value = ploan_code;
                oCommand.Parameters.Add(oParam_loan_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_name = new SqlParameter("loan_name", SqlDbType.NVarChar);
                oParam_loan_name.Direction = ParameterDirection.Input;
                oParam_loan_name.Value = ploan_name;
                oCommand.Parameters.Add(oParam_loan_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_desc = new SqlParameter("loan_desc", SqlDbType.NVarChar);
                oParam_loan_desc.Direction = ParameterDirection.Input;
                oParam_loan_desc.Value = ploan_desc;
                oCommand.Parameters.Add(oParam_loan_desc);

              
                // - - - - - - - - - - - -             
                SqlParameter oParam_c_updated_by = new SqlParameter("c_updated_by", SqlDbType.NVarChar);
                oParam_c_updated_by.Direction = ParameterDirection.Input;
                oParam_c_updated_by.Value = pc_updated_by;
                oCommand.Parameters.Add(oParam_c_updated_by);
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

        #region SP_DEL_LOAN
        public bool SP_DEL_LOAN(string ploan_code, string pactive, string pc_updated_by, ref string strMessage)
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
                oCommand.CommandText = "sp_LOAN_DEL";
                // - - - - - - - - - - - -             
                SqlParameter oParam_loan_code = new SqlParameter("loan_code", SqlDbType.NVarChar);
                oParam_loan_code.Direction = ParameterDirection.Input;
                oParam_loan_code.Value = ploan_code;
                oCommand.Parameters.Add(oParam_loan_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Active = new SqlParameter("c_active", SqlDbType.NVarChar);
                oParam_Active.Direction = ParameterDirection.Input;
                oParam_Active.Value = pactive;
                oCommand.Parameters.Add(oParam_Active);
                // - - - - - - - - - - - -             
                SqlParameter oParam_c_updated_by = new SqlParameter("c_updated_by", SqlDbType.NVarChar);
                oParam_c_updated_by.Direction = ParameterDirection.Input;
                oParam_c_updated_by.Value = pc_updated_by;
                oCommand.Parameters.Add(oParam_c_updated_by);
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
