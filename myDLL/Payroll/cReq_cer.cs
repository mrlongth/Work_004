using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    using System.Net.Configuration;

    public class cReq_cer : IDisposable
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

        public cReq_cer()
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

        #region SP_REQ_CER_HEAD_SEL
        public bool SP_REQ_CER_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_REQ_CER_HEAD_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REQ_CER_HEAD_SEL");
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

        #region SP_REQ_CER_HEAD_INS
        public bool SP_REQ_CER_HEAD_INS(
                string preq_code,
                string preq_date,
                string preq_date_print,
                string ppayment_year,
                string ppay_month,
                string ppay_year,
                string pperson_code,
                string ptitle_code ,
                string pperson_thai_name ,
                string pperson_thai_surname ,
                string preq_money,
                string preq_person_group_name,
                string preq_position_name,
                string preq_work_name,
                string preq_level_position_name,
                string preq_director_name,
                string preq_unit_name,
                string preq_start_work,
                string preq_age_work,
                string preq_approve,
                string preq_approve_position1,
                string preq_approve_position2,
                string ptotal_payment_recv,
                string ptotal_payment_pay,
                string ptotal_payment_net,
                string pcreated_by,
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
                oCommand.CommandText = "sp_REQ_CER_HEAD_INS";
                oCommand.Parameters.Add("preq_code", SqlDbType.VarChar).Value = preq_code;
                oCommand.Parameters.Add("preq_date", SqlDbType.Date).Value = cCommon.CheckDate(preq_date);
                oCommand.Parameters.Add("preq_date_print", SqlDbType.Date).Value = cCommon.CheckDate(preq_date_print);
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("pperson_code", SqlDbType.VarChar).Value = pperson_code;
                oCommand.Parameters.Add("ptitle_code", SqlDbType.VarChar).Value = ptitle_code;
                oCommand.Parameters.Add("pperson_thai_name", SqlDbType.VarChar).Value = pperson_thai_name;
                oCommand.Parameters.Add("pperson_thai_surname", SqlDbType.VarChar).Value = pperson_thai_surname;                
                oCommand.Parameters.Add("preq_money", SqlDbType.VarChar).Value = decimal.Parse(preq_money);
                oCommand.Parameters.Add("preq_person_group_name", SqlDbType.VarChar).Value = preq_person_group_name;
                oCommand.Parameters.Add("preq_position_name", SqlDbType.VarChar).Value = preq_position_name;
                oCommand.Parameters.Add("preq_work_name", SqlDbType.VarChar).Value = preq_work_name;
                oCommand.Parameters.Add("preq_level_position_name", SqlDbType.VarChar).Value = preq_level_position_name;
                oCommand.Parameters.Add("preq_director_name", SqlDbType.VarChar).Value = preq_director_name;
                oCommand.Parameters.Add("preq_unit_name", SqlDbType.VarChar).Value = preq_unit_name;
                oCommand.Parameters.Add("preq_start_work", SqlDbType.Date).Value = cCommon.CheckDate(preq_start_work); ;
                oCommand.Parameters.Add("preq_age_work", SqlDbType.VarChar).Value = preq_age_work;
                oCommand.Parameters.Add("preq_approve", SqlDbType.VarChar).Value = preq_approve;
                oCommand.Parameters.Add("preq_approve_position1", SqlDbType.VarChar).Value = preq_approve_position1;
                oCommand.Parameters.Add("preq_approve_position2", SqlDbType.VarChar).Value = preq_approve_position2;
                oCommand.Parameters.Add("ptotal_payment_recv", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_recv);
                oCommand.Parameters.Add("ptotal_payment_pay", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_pay);
                oCommand.Parameters.Add("ptotal_payment_net", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_net);
                oCommand.Parameters.Add("pcreated_by", SqlDbType.VarChar).Value = pcreated_by;
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

        #region SP_REQ_CER_HEAD_UPD
        public bool SP_REQ_CER_HEAD_UPD(
                string preq_cer_id,
                string preq_code,
                string preq_date,
                string preq_date_print,
                string ppayment_year,
                string ppay_month,
                string ppay_year,
                string pperson_code,
                string ptitle_code,
                string pperson_thai_name,
                string pperson_thai_surname,
                string preq_money,
                string preq_person_group_name,
                string preq_position_name,
                string preq_work_name,
                string preq_level_position_name,
                string preq_director_name,
                string preq_unit_name,
                string preq_start_work,
                string preq_age_work,
                string preq_approve,
                string preq_approve_position1,
                string preq_approve_position2,
                string ptotal_payment_recv,
                string ptotal_payment_pay,
                string ptotal_payment_net,
                string pupdated_by,
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
                oCommand.CommandText = "sp_REQ_CER_HEAD_UPD";
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = preq_cer_id;
                oCommand.Parameters.Add("preq_code", SqlDbType.VarChar).Value = preq_code;
                oCommand.Parameters.Add("preq_date", SqlDbType.Date).Value = cCommon.CheckDate(preq_date);
                oCommand.Parameters.Add("preq_date_print", SqlDbType.Date).Value = cCommon.CheckDate(preq_date_print);
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("pperson_code", SqlDbType.VarChar).Value = pperson_code;
                oCommand.Parameters.Add("ptitle_code", SqlDbType.VarChar).Value = ptitle_code;
                oCommand.Parameters.Add("pperson_thai_name", SqlDbType.VarChar).Value = pperson_thai_name;
                oCommand.Parameters.Add("pperson_thai_surname", SqlDbType.VarChar).Value = pperson_thai_surname;                                
                oCommand.Parameters.Add("preq_money", SqlDbType.VarChar).Value = decimal.Parse(preq_money);
                oCommand.Parameters.Add("preq_person_group_name", SqlDbType.VarChar).Value = preq_person_group_name;
                oCommand.Parameters.Add("preq_position_name", SqlDbType.VarChar).Value = preq_position_name;
                oCommand.Parameters.Add("preq_work_name", SqlDbType.VarChar).Value = preq_work_name;
                oCommand.Parameters.Add("preq_level_position_name", SqlDbType.VarChar).Value = preq_level_position_name;
                oCommand.Parameters.Add("preq_director_name", SqlDbType.VarChar).Value = preq_director_name;
                oCommand.Parameters.Add("preq_unit_name", SqlDbType.VarChar).Value = preq_unit_name;
                oCommand.Parameters.Add("preq_start_work", SqlDbType.Date).Value = cCommon.CheckDate(preq_start_work); ;
                oCommand.Parameters.Add("preq_age_work", SqlDbType.VarChar).Value = preq_age_work;
                oCommand.Parameters.Add("preq_approve", SqlDbType.VarChar).Value = preq_approve;
                oCommand.Parameters.Add("preq_approve_position1", SqlDbType.VarChar).Value = preq_approve_position1;
                oCommand.Parameters.Add("preq_approve_position2", SqlDbType.VarChar).Value = preq_approve_position2;
                oCommand.Parameters.Add("ptotal_payment_recv", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_recv);
                oCommand.Parameters.Add("ptotal_payment_pay", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_pay);
                oCommand.Parameters.Add("ptotal_payment_net", SqlDbType.VarChar).Value = decimal.Parse(ptotal_payment_net);
                oCommand.Parameters.Add("pupdated_by", SqlDbType.VarChar).Value = pupdated_by;
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

        #region SP_REQ_CER_HEAD_DEL
        public bool SP_REQ_CER_HEAD_DEL
            (
                string preq_cer_id,
                ref string strMessage
            )
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
                oCommand.CommandText = "sp_REQ_CER_HEAD_DEL";
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = long.Parse(preq_cer_id);
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


        #region SP_REQ_CER_HEAD_SEL
        public bool SP_REQ_CER_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_REQ_CER_DETAIL_SEL";
                oCommand.Parameters.Add("vc_criteria", SqlDbType.VarChar).Value = strCriteria;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REQ_CER_DETAIL_SEL");
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

        #region SP_REQ_CER_DETAIL_INS
        public bool SP_REQ_CER_DETAIL_INS(
                string preq_cer_id,
                string pitem_code,
                string ppayment_item_pay,
                string ppayment_item_recv,
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
                oCommand.CommandText = "sp_REQ_CER_DETAIL_INS";
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = preq_cer_id;
                oCommand.Parameters.Add("pitem_code", SqlDbType.VarChar).Value = pitem_code;
                oCommand.Parameters.Add("ppayment_item_pay", SqlDbType.VarChar).Value = decimal.Parse(ppayment_item_pay);
                oCommand.Parameters.Add("ppayment_item_recv", SqlDbType.VarChar).Value = decimal.Parse(ppayment_item_recv);
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

        #region SP_REQ_CER_DETAIL_UPD
        public bool SP_REQ_CER_DETAIL_UPD(
                string preq_cer_detail_id,
                string preq_cer_id,
                string pitem_code,
                string ppayment_item_pay,
                string ppayment_item_recv,
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
                oCommand.CommandText = "sp_REQ_CER_DETAIL_INS";
                oCommand.Parameters.Add("preq_cer_detail_id", SqlDbType.BigInt).Value = long.Parse(preq_cer_detail_id);
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = long.Parse(preq_cer_id);
                oCommand.Parameters.Add("ppayment_item_pay", SqlDbType.VarChar).Value = decimal.Parse(ppayment_item_pay);
                oCommand.Parameters.Add("ppayment_item_recv", SqlDbType.VarChar).Value = decimal.Parse(ppayment_item_recv);
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

        #region SP_REQ_CER_DETAIL_DEL
        public bool SP_REQ_CER_DETAIL_DEL
            (
                string preq_cer_id,
                ref string strMessage
            )
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
                oCommand.CommandText = "sp_REQ_CER_DETAIL_DEL";
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = long.Parse(preq_cer_id);
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

        #region SP_REQ_CER_DETAIL_TMP_SEL
        public bool SP_REQ_CER_DETAIL_TMP_SEL(string preq_cer_id,string ppay_year, string ppay_month , ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_REQ_CER_DETAIL_TMP_SEL";
                oCommand.Parameters.Add("preq_cer_id", SqlDbType.BigInt).Value = long.Parse(preq_cer_id);
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_REQ_CER_DETAIL_TMP_SEL");
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
