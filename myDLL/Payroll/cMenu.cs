using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    public class cMenu : IDisposable
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

        public cMenu()
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

        #region SP_MENU_SEL
        public bool SP_MENU_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_MENU_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_MENU_SEL");
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

        #region SP_MENU_INS
        public bool SP_MENU_INS(
                string pMenuName ,
                string pMenuNavigationUrl ,
                string pMenuImageUrl ,
                string pMenuTarget ,
                string pMenuParent ,
                string pMenuOrder ,
                string pCanView ,
                string pCanInsert ,
                string pCanEdit ,
                string pCanDelete ,
                string pCanApprove ,
                string pCanExtra ,
                string pStatus ,
                string pRemark ,
                string pCreatedBy , 
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
                oCommand.CommandText = "sp_MENU_INS";
                oCommand.Parameters.Add("MenuName", SqlDbType.VarChar).Value = pMenuName;
                oCommand.Parameters.Add("MenuNavigationUrl", SqlDbType.VarChar).Value = pMenuNavigationUrl;
                oCommand.Parameters.Add("MenuImageUrl", SqlDbType.VarChar).Value = pMenuImageUrl;
                oCommand.Parameters.Add("MenuTarget", SqlDbType.VarChar).Value = pMenuTarget;
                oCommand.Parameters.Add("MenuParent", SqlDbType.SmallInt).Value = Int16.Parse(pMenuParent);
                oCommand.Parameters.Add("MenuOrder", SqlDbType.SmallInt).Value = Int16.Parse(pMenuOrder);
                oCommand.Parameters.Add("CanView", SqlDbType.Char).Value = pCanView;
                oCommand.Parameters.Add("CanInsert", SqlDbType.Char).Value = pCanInsert;
                oCommand.Parameters.Add("CanEdit", SqlDbType.Char).Value = pCanEdit;
                oCommand.Parameters.Add("CanDelete", SqlDbType.Char).Value = pCanDelete;
                oCommand.Parameters.Add("CanApprove", SqlDbType.Char).Value = pCanApprove;
                oCommand.Parameters.Add("CanExtra", SqlDbType.Char).Value = pCanExtra;
                oCommand.Parameters.Add("Status", SqlDbType.Char).Value = pStatus;
                oCommand.Parameters.Add("Remark", SqlDbType.VarChar).Value = pRemark;
                oCommand.Parameters.Add("CreatedBy", SqlDbType.VarChar).Value = pCreatedBy;
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

        #region SP_MENU_UPD
        public bool SP_MENU_UPD(
                string pMenuID,
                string pMenuName,
                string pMenuNavigationUrl,
                string pMenuImageUrl,
                string pMenuTarget,
                string pMenuParent,
                string pMenuOrder,
                string pCanView,
                string pCanInsert,
                string pCanEdit,
                string pCanDelete,
                string pCanApprove,
                string pCanExtra,
                string pStatus,
                string pRemark,
                string pUpdatedBy,
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
                oCommand.CommandText = "sp_MENU_UPD";
                oCommand.Parameters.Add("MenuID", SqlDbType.SmallInt).Value = Int16.Parse(pMenuID);
                oCommand.Parameters.Add("MenuName", SqlDbType.VarChar).Value = pMenuName;
                oCommand.Parameters.Add("MenuNavigationUrl", SqlDbType.VarChar).Value = pMenuNavigationUrl;
                oCommand.Parameters.Add("MenuImageUrl", SqlDbType.VarChar).Value = pMenuImageUrl;
                oCommand.Parameters.Add("MenuTarget", SqlDbType.VarChar).Value = pMenuTarget;
                oCommand.Parameters.Add("MenuParent", SqlDbType.SmallInt).Value = Int16.Parse(pMenuParent);
                oCommand.Parameters.Add("MenuOrder", SqlDbType.SmallInt).Value = Int16.Parse(pMenuOrder);
                oCommand.Parameters.Add("CanView", SqlDbType.Char).Value = pCanView;
                oCommand.Parameters.Add("CanInsert", SqlDbType.Char).Value = pCanInsert;
                oCommand.Parameters.Add("CanEdit", SqlDbType.Char).Value = pCanEdit;
                oCommand.Parameters.Add("CanDelete", SqlDbType.Char).Value = pCanDelete;
                oCommand.Parameters.Add("CanApprove", SqlDbType.Char).Value = pCanApprove;
                oCommand.Parameters.Add("CanExtra", SqlDbType.Char).Value = pCanExtra;
                oCommand.Parameters.Add("Status", SqlDbType.Char).Value = pStatus;
                oCommand.Parameters.Add("Remark", SqlDbType.VarChar).Value = pRemark;
                oCommand.Parameters.Add("UpdatedBy", SqlDbType.VarChar).Value = pUpdatedBy;
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

        #region SP_MENU_DEL
        public bool SP_MENU_DEL(
                string pMenuID,
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
                oCommand.CommandText = "sp_MENU_DEL";
                oCommand.Parameters.Add("MenuID", SqlDbType.SmallInt).Value = Int16.Parse(pMenuID);
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
