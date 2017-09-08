using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cItem_detail : IDisposable
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

        public cItem_detail()
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

        #region SP_ITEM_DETAIL_SEL
        public bool SP_ITEM_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_DETAIL_SEL";
                SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = strCriteria
                };
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_ITEM_DETAIL_SEL");
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

        #region SP_ITEM_DETAIL_INS
        public bool SP_ITEM_DETAIL_INS(Item_detail item_detail)
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
                oCommand.CommandText = "sp_ITEM_DETAIL_INS";
                oCommand.Parameters.Add("item_detail_code", SqlDbType.VarChar).Value = item_detail.item_detail_code;
                oCommand.Parameters.Add("item_detail_name", SqlDbType.VarChar).Value = item_detail.item_detail_name;
                oCommand.Parameters.Add("Item_code", SqlDbType.VarChar).Value = item_detail.item_code;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = item_detail.c_active;
                oCommand.Parameters.Add("c_created_by", SqlDbType.VarChar).Value = item_detail.c_created_by;
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

        #region SP_ITEM_DETAIL_UPD
        public bool SP_ITEM_DETAIL_UPD(Item_detail item_detail)
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
                oCommand.CommandText = "sp_ITEM_DETAIL_UPD";
                oCommand.Parameters.Add("item_detail_id", SqlDbType.Int).Value = item_detail.item_detail_id;
                oCommand.Parameters.Add("item_detail_code", SqlDbType.VarChar).Value = item_detail.item_detail_code;
                oCommand.Parameters.Add("item_detail_name", SqlDbType.VarChar).Value = item_detail.item_detail_name;
                oCommand.Parameters.Add("Item_code", SqlDbType.VarChar).Value = item_detail.item_code;
                oCommand.Parameters.Add("c_active", SqlDbType.VarChar).Value = item_detail.c_active;
                oCommand.Parameters.Add("c_updated_by", SqlDbType.VarChar).Value = item_detail.c_created_by;
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

        #region SP_ITEM_DETAIL_DEL
        public bool SP_ITEM_DETAIL_DEL(string pitem_detail_id, ref string strMessage)
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
                oCommand.CommandText = "sp_ITEM_DETAIL_DEL";
                oCommand.Parameters.Add("item_detail_id", SqlDbType.Int).Value = int.Parse(pitem_detail_id);
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

        public view_Item_detail GET(string strCriteria)
        {
            view_Item_detail result = null;
            var strMessage = string.Empty;
            DataSet ds = null;
            if (SP_ITEM_DETAIL_SEL(strCriteria, ref ds, ref strMessage))
            {
                result = Helper.ToClassInstanceCollection<view_Item_detail>(ds.Tables[0]).FirstOrDefault();
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
