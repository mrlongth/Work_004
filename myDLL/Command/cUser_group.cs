using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    public class cUser_group : IDisposable
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

        public cUser_group()
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

        #region SP_USER_GROUP_SEL
        public bool SP_USER_GROUP_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_USER_GROUP_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_USER_GROUP_SEL");
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

        #region SP_USER_GROUP_INS
        public bool SP_USER_GROUP_INS(string puser_group_code, string puser_group_name, string pActive, string pC_created_by, ref string strMessage)
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
                oCommand.CommandText = "sp_USER_GROUP_INS";
                // - - - - - - - - - - - -             
                SqlParameter oParam_user_group_code = new SqlParameter("user_group_code", SqlDbType.NVarChar);
                oParam_user_group_code.Direction = ParameterDirection.Input;
                oParam_user_group_code.Value = puser_group_code;
                oCommand.Parameters.Add(oParam_user_group_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_user_group_name = new SqlParameter("user_group_name", SqlDbType.NVarChar);
                oParam_user_group_name.Direction = ParameterDirection.Input;
                oParam_user_group_name.Value = puser_group_name;
                oCommand.Parameters.Add(oParam_user_group_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Active = new SqlParameter("c_active", SqlDbType.NVarChar);
                oParam_Active.Direction = ParameterDirection.Input;
                oParam_Active.Value = pActive;
                oCommand.Parameters.Add(oParam_Active);
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

        #region SP_USER_GROUP_UPD
        public bool SP_USER_GROUP_UPD(string puser_group_code, string puser_group_name, string pActive, string pC_updated_by, ref string strMessage)
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
                oCommand.CommandText = "sp_USER_GROUP_UPD";
                // - - - - - - - - - - - -             
                SqlParameter oParam_user_group_code = new SqlParameter("user_group_code", SqlDbType.NVarChar);
                oParam_user_group_code.Direction = ParameterDirection.Input;
                oParam_user_group_code.Value = puser_group_code;
                oCommand.Parameters.Add(oParam_user_group_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_user_group_name = new SqlParameter("user_group_name", SqlDbType.NVarChar);
                oParam_user_group_name.Direction = ParameterDirection.Input;
                oParam_user_group_name.Value = puser_group_name;
                oCommand.Parameters.Add(oParam_user_group_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Active = new SqlParameter("C_active", SqlDbType.NVarChar);
                oParam_Active.Direction = ParameterDirection.Input;
                oParam_Active.Value = pActive;
                oCommand.Parameters.Add(oParam_Active);
                // - - - - - - - - - - - -             
                SqlParameter oParam_c_updated_by = new SqlParameter("c_updated_by", SqlDbType.NVarChar);
                oParam_c_updated_by.Direction = ParameterDirection.Input;
                oParam_c_updated_by.Value = pC_updated_by;
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

        #region SP_USER_GROUP_DEL
        public bool SP_USER_GROUP_DEL(string puser_group_code, string pActive, string pC_updated_by, ref string strMessage)
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
                oCommand.CommandText = "sp_USER_GROUP_DEL";
                // - - - - - - - - - - - -             
                SqlParameter oParam_user_group_code = new SqlParameter("user_group_code", SqlDbType.NVarChar);
                oParam_user_group_code.Direction = ParameterDirection.Input;
                oParam_user_group_code.Value = puser_group_code;
                oCommand.Parameters.Add(oParam_user_group_code);
                //// - - - - - - - - - - - -             
                //SqlParameter oParam_Active = new SqlParameter("C_active", SqlDbType.NVarChar);
                //oParam_Active.Direction = ParameterDirection.Input;
                //oParam_Active.Value = pActive;
                //oCommand.Parameters.Add(oParam_Active);
                //// - - - - - - - - - - - -             
                //SqlParameter oParam_c_updated_by = new SqlParameter("c_updated_by", SqlDbType.NVarChar);
                //oParam_c_updated_by.Direction = ParameterDirection.Input;
                //oParam_c_updated_by.Value = pC_updated_by;
                //oCommand.Parameters.Add(oParam_c_updated_by);
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

        #region SP_USER_GROUP_PERSON_GROUP_UPD
        public bool SP_USER_GROUP_PERSON_GROUP_UPD(
                string user_group_code,
                string person_group_list,
                string pdirector_lock,
                string punit_lock,
            //string punit_code_list,
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
                oCommand.CommandText = "SP_USER_GROUP_PERSON_GROUP_UPD";
                oCommand.Parameters.Add("puser_group_code", SqlDbType.VarChar).Value = user_group_code;
                oCommand.Parameters.Add("pperson_group_list", SqlDbType.VarChar).Value = person_group_list;
                oCommand.Parameters.Add("pdirector_lock", SqlDbType.VarChar).Value = pdirector_lock;
                oCommand.Parameters.Add("punit_lock", SqlDbType.VarChar).Value = punit_lock;
                oCommand.Parameters.Add("pUpdatedBy", SqlDbType.VarChar).Value = pc_updated_by;
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
