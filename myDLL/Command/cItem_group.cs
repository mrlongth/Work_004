using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cItem_group : IDisposable
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

        public cItem_group()
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

        #region SP_ITEM_GROUP_SEL
        public bool SP_ITEM_GROUP_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_GROUP_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_ITEM_GROUP_SEL");
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

        #region SP_ITEM_GROUP_INS
        public bool SP_ITEM_GROUP_INS(Item_group item_group, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_GROUP_INS";
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_year = new SqlParameter("item_group_year", SqlDbType.NVarChar);
                oParam_Item_group_year.Direction = ParameterDirection.Input;
                oParam_Item_group_year.Value = item_group.item_group_year;
                oCommand.Parameters.Add(oParam_Item_group_year);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_name = new SqlParameter("item_group_name", SqlDbType.NVarChar);
                oParam_Item_group_name.Direction = ParameterDirection.Input;
                oParam_Item_group_name.Value = item_group.item_group_name;
                oCommand.Parameters.Add(oParam_Item_group_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_lot_code = new SqlParameter("lot_code", SqlDbType.NVarChar);
                oParam_lot_code.Direction = ParameterDirection.Input;
                oParam_lot_code.Value = item_group.lot_code;
                oCommand.Parameters.Add(oParam_lot_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Active = new SqlParameter("c_active", SqlDbType.NVarChar);
                oParam_Active.Direction = ParameterDirection.Input;
                oParam_Active.Value = item_group.c_active;
                oCommand.Parameters.Add(oParam_Active);
                // - - - - - - - - - - - -             
                SqlParameter oParam_c_created_by = new SqlParameter("c_created_by", SqlDbType.NVarChar);
                oParam_c_created_by.Direction = ParameterDirection.Input;
                oParam_c_created_by.Value = item_group.c_created_by;
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

        #region SP_ITEM_GROUP_UPD
        public bool SP_ITEM_GROUP_UPD(Item_group item_group, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_GROUP_UPD";
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_code = new SqlParameter("item_group_code", SqlDbType.NVarChar);
                oParam_Item_group_code.Direction = ParameterDirection.Input;
                oParam_Item_group_code.Value = item_group.item_group_code;
                oCommand.Parameters.Add(oParam_Item_group_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_year = new SqlParameter("item_group_year", SqlDbType.NVarChar);
                oParam_Item_group_year.Direction = ParameterDirection.Input;
                oParam_Item_group_year.Value = item_group.item_group_year;
                oCommand.Parameters.Add(oParam_Item_group_year);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_name = new SqlParameter("item_group_name", SqlDbType.NVarChar);
                oParam_Item_group_name.Direction = ParameterDirection.Input;
                oParam_Item_group_name.Value = item_group.item_group_name;
                oCommand.Parameters.Add(oParam_Item_group_name);
                // - - - - - - - - - - - -             
                SqlParameter oParam_lot_code = new SqlParameter("lot_code", SqlDbType.NVarChar);
                oParam_lot_code.Direction = ParameterDirection.Input;
                oParam_lot_code.Value = item_group.lot_code;
                oCommand.Parameters.Add(oParam_lot_code);
                // - - - - - - - - - - - -             
                SqlParameter oParam_Active = new SqlParameter("C_active", SqlDbType.NVarChar);
                oParam_Active.Direction = ParameterDirection.Input;
                oParam_Active.Value = item_group.c_active;
                oCommand.Parameters.Add(oParam_Active);
                // - - - - - - - - - - - -             
                SqlParameter oParam_c_updated_by = new SqlParameter("c_updated_by", SqlDbType.NVarChar);
                oParam_c_updated_by.Direction = ParameterDirection.Input;
                oParam_c_updated_by.Value = item_group.c_updated_by;
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

        #region SP_ITEM_GROUP_DEL
        public bool SP_ITEM_GROUP_DEL(string pitem_group_code, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_GROUP_DEL";
                // - - - - - - - - - - - -             
                SqlParameter oParam_Item_group_code = new SqlParameter("item_group_code", SqlDbType.NVarChar);
                oParam_Item_group_code.Direction = ParameterDirection.Input;
                oParam_Item_group_code.Value = pitem_group_code;
                oCommand.Parameters.Add(oParam_Item_group_code);
               
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

        public view_Item_group GET(string strCriteria)
        {
            view_Item_group result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_ITEM_GROUP_SEL(strCriteria, ref ds, ref strMessage)) 
            {
                result = Helper.ToClassInstanceCollection<view_Item_group>(ds.Tables[0]).FirstOrDefault();
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
