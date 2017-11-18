using System;
using System.Data;
using System.Data.SqlClient;
using myModel;
using System.Linq;

namespace myDLL
{
    public class cReport : IDisposable
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

        public cReport()
        {
            //
            // TODO: Add constructor logic here
            //
            _strConn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        #region SP_REP_001
        public DataSet SP_REP_001(string strCriteria)
        {
            DataSet ds = null;
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
                oCommand.Parameters.Add("vc_criteria", SqlDbType.NVarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_BUDGET_TRANSFER_DETAIL_SEL");
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
            return ds;
        }
        #endregion

        #region SP_REP_002
        public DataSet SP_REP_002(string strCriteria)
        {
            DataSet ds = null;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_REP_002";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.NVarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REP_002");
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
            return ds;
        }
        #endregion

        #region SP_REP_004
        public DataSet SP_REP_004(string strCriteria)
        {
            DataSet ds = null;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_RPT_004";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.NVarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REP_004");
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
            return ds;
        }
        #endregion

        #region SP_REP_005
        public DataSet SP_REP_005(string strCriteria)
        {
            DataSet ds = null;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_RPT_005";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.NVarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REP_005");
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
            return ds;
        }
        #endregion


        #region SP_REP_007
        public DataSet SP_REP_007(string strCriteria)
        {
            DataSet ds = null;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "sp_REP_007";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.NVarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REP_007");
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
            return ds;
        }
        #endregion



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
