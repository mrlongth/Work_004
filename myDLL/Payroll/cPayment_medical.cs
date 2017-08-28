using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    using System.Runtime.Remoting.Messaging;

    public class cPayment_medical : IDisposable
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

        public cPayment_medical()
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

        #region SP_ALL_MEDICAL_PERSON_SEL
        public bool SP_ALL_MEDICAL_PERSON_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_ALL_MEDICAL_PERSON_SEL";
                var oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_ALL_MEDICAL_PERSON_SEL");
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

        
        #region SP_PAYMENT_MEDICAL_HEAD_SEL
        public bool SP_PAYMENT_MEDICAL_HEAD_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_HEAD_SEL";
                var oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_PAYMENT_MEDICAL_HEAD_SEL");
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

        #region SP_PAYMENT_MEDICAL_HEAD_DEL
        public bool SP_PAYMENT_MEDICAL_HEAD_DEL(string pmc_payment_doc, ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_HEAD_DEL";
                // - - - - - - - - - - - -             
                var oParam_sp_payment_doc = new SqlParameter("pmc_payment_doc", SqlDbType.VarChar);
                oParam_sp_payment_doc.Direction = ParameterDirection.Input;
                oParam_sp_payment_doc.Value = pmc_payment_doc;
                oCommand.Parameters.Add(oParam_sp_payment_doc);
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

        #region SP_PAYMENT_MEDICAL_HEAD_INS
        public bool SP_PAYMENT_MEDICAL_HEAD_INS(
                string pmc_payment_doc ,
                string ppayment_date ,
                string ppayment_year ,
	            string ppay_month ,
	            string ppay_year ,
                string pmc_person_code ,            
                string pmc_person_group_code,
	            string pmc_budget_plan_code,
                string pmc_payment_recv ,
                string pmc_payment_pay ,
                string pmc_payment_net ,
                string pcomments ,
                string pc_status ,
                string pc_active,
                string pc_created_by,
                ref string strMessage)
        {
                        
            bool blnResult = false;
            var oConn = new SqlConnection();
            var oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_HEAD_INS";
                oCommand.Parameters.Add("pmc_payment_doc", SqlDbType.VarChar).Value = pmc_payment_doc;
                oCommand.Parameters.Add("ppayment_date", SqlDbType.DateTime).Value = cCommon.CheckDate(ppayment_date);                
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;                              
                oCommand.Parameters.Add("pmc_person_code", SqlDbType.VarChar).Value = pmc_person_code;
                oCommand.Parameters.Add("pmc_person_group_code", SqlDbType.VarChar).Value = pmc_person_group_code;
                oCommand.Parameters.Add("pmc_budget_plan_code", SqlDbType.VarChar).Value = pmc_budget_plan_code;
                oCommand.Parameters.Add("pmc_payment_recv", SqlDbType.Money).Value = Helper.CDbl(pmc_payment_recv);
                oCommand.Parameters.Add("pmc_payment_pay", SqlDbType.Money).Value = Helper.CDbl(pmc_payment_pay);
                oCommand.Parameters.Add("pmc_payment_net", SqlDbType.Money).Value = Helper.CDbl(pmc_payment_net);
                oCommand.Parameters.Add("pcomments", SqlDbType.VarChar).Value = pcomments;
                oCommand.Parameters.Add("pc_status", SqlDbType.VarChar).Value = pc_status;
                oCommand.Parameters.Add("pc_active", SqlDbType.VarChar).Value = pc_active;
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

        #region SP_PAYMENT_MEDICAL_HEAD_UPD
        public bool SP_PAYMENT_MEDICAL_HEAD_UPD(
                string pmc_payment_doc,
                string ppayment_date,
                string ppayment_year,
                string ppay_month,
                string ppay_year,
                string pmc_person_code,
                string pmc_person_group_code,
                string pmc_budget_plan_code,
                string pcomments,
                string pc_status,
                string pc_active,
                string pc_updated_by,
                ref string strMessage)
        {

            bool blnResult = false;
            var oConn = new SqlConnection();
            var oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_HEAD_UPD";
                oCommand.Parameters.Add("pmc_payment_doc", SqlDbType.VarChar).Value = pmc_payment_doc;
                oCommand.Parameters.Add("ppayment_date", SqlDbType.DateTime).Value = cCommon.CheckDate(ppayment_date);                               
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("pmc_person_code", SqlDbType.VarChar).Value = pmc_person_code;
                oCommand.Parameters.Add("pmc_person_group_code", SqlDbType.VarChar).Value = pmc_person_group_code;
                oCommand.Parameters.Add("pmc_budget_plan_code", SqlDbType.VarChar).Value = pmc_budget_plan_code;
                oCommand.Parameters.Add("pcomments", SqlDbType.VarChar).Value = pcomments;
                oCommand.Parameters.Add("pc_status", SqlDbType.VarChar).Value = pc_status;
                oCommand.Parameters.Add("pc_active", SqlDbType.VarChar).Value = pc_active;
                oCommand.Parameters.Add("pc_updated_by", SqlDbType.VarChar).Value = pc_updated_by;
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


        #region SP_PAYMENT_MEDICAL_DETAIL_SEL
        public bool SP_PAYMENT_MEDICAL_DETAIL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_DETAIL_SEL";
                var oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "SP_PAYMENT_MEDICAL_DETAIL_SEL");
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

        #region SP_PAYMENT_MEDICAL_DETAIL_DEL
        public bool SP_PAYMENT_MEDICAL_DETAIL_DEL(string pmc_payment_detail_id, string pc_updated_by,  ref string strMessage)
        {
            bool blnResult = false;
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_DETAIL_DEL";
                // - - - - - - - - - - - -             
                oCommand.Parameters.Add("pmc_payment_detail_id", SqlDbType.BigInt).Value = Helper.CLong(pmc_payment_detail_id);
                oCommand.Parameters.Add("pc_updated_by", SqlDbType.VarChar).Value = pc_updated_by;
                
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

        #region SP_PAYMENT_MEDICAL_DETAIL_INS
        public bool SP_PAYMENT_MEDICAL_DETAIL_INS(
                string pmc_payment_doc ,
                string pitem_code ,
                string pitem_qty ,
                string pmc_payment_item_money ,
                string pmc_comments_sub ,
                string pc_active,
                string pc_created_by,
                ref string strMessage)
        {

            bool blnResult = false;
            var oConn = new SqlConnection();
            var oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_DETAIL_INS";
                oCommand.Parameters.Add("pmc_payment_doc", SqlDbType.VarChar).Value = pmc_payment_doc;
                oCommand.Parameters.Add("pitem_code", SqlDbType.VarChar).Value = pitem_code;
                oCommand.Parameters.Add("pitem_qty", SqlDbType.Float).Value = Helper.CDbl(pitem_qty);
                oCommand.Parameters.Add("pmc_payment_item_money", SqlDbType.Money).Value = Helper.CDbl(pmc_payment_item_money);
                oCommand.Parameters.Add("pmc_comments_sub", SqlDbType.VarChar).Value = pmc_comments_sub;
                oCommand.Parameters.Add("pc_active", SqlDbType.VarChar).Value = pc_active;
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

        #region SP_PAYMENT_MEDICAL_DETAIL_UPD
        public bool SP_PAYMENT_MEDICAL_DETAIL_UPD(
                string sp_payment_detail_id,
                string pmc_payment_doc,
                string pitem_code,
                string pitem_qty,
                string pmc_payment_item_money,
                string pmc_comments_sub,
                string pc_active,
                string pc_updated_by,
                ref string strMessage)
        {

            bool blnResult = false;
            var oConn = new SqlConnection();
            var oCommand = new SqlCommand();
            try
            {
                oConn.ConnectionString = _strConn;
                oConn.Open();
                oCommand.Connection = oConn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_PAYMENT_MEDICAL_DETAIL_UPD";
                oCommand.Parameters.Add("mc_payment_detail_id", SqlDbType.BigInt).Value = Helper.CLong(sp_payment_detail_id);
                oCommand.Parameters.Add("pmc_payment_doc", SqlDbType.VarChar).Value = pmc_payment_doc;
                oCommand.Parameters.Add("pitem_code", SqlDbType.VarChar).Value = pitem_code;
                oCommand.Parameters.Add("pitem_qty", SqlDbType.Float).Value = Helper.CDbl(pitem_qty);
                oCommand.Parameters.Add("pmc_payment_item_money", SqlDbType.Money).Value = Helper.CDbl(pmc_payment_item_money);
                oCommand.Parameters.Add("pmc_comments_sub", SqlDbType.VarChar).Value = pmc_comments_sub;
                oCommand.Parameters.Add("pc_active", SqlDbType.VarChar).Value = pc_active;
                oCommand.Parameters.Add("pc_updated_by", SqlDbType.VarChar).Value = pc_updated_by;
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

        #region SP_IMPORT_PAYMENT_MEDICAL_INS
        public bool SP_IMPORT_PAYMENT_MEDICAL_INS
            (
                 string ppayment_year,
                 string ppay_year,
                 string ppay_month,
                string pmc_person_id,
                string pmc_person_code,
                string pmc_person_name,
                string pmc_person_surname,
                string pitem_code,
                string pitem_qty,
                string pitem_amt,
                string pc_created_by,
                ref string strMessage
            )
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
                oCommand.CommandText = "sp_IMPORT_PAYMENT_MEDICAL_INS";
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("pmc_person_id", SqlDbType.VarChar).Value = pmc_person_id;
                oCommand.Parameters.Add("pmc_person_code", SqlDbType.VarChar).Value = pmc_person_code;
                oCommand.Parameters.Add("pmc_person_name", SqlDbType.VarChar).Value = pmc_person_name;
                oCommand.Parameters.Add("pmc_person_surname", SqlDbType.VarChar).Value = pmc_person_surname;
                oCommand.Parameters.Add("pitem_code", SqlDbType.VarChar).Value = pitem_code;
                oCommand.Parameters.Add("pitem_qty", SqlDbType.Float).Value = double.Parse(pitem_qty);
                oCommand.Parameters.Add("pitem_amt", SqlDbType.Money).Value = double.Parse(pitem_amt);
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

        #region SP_IMPORT_PAYMENT_MEDICAL_DEL
        public bool SP_IMPORT_PAYMENT_MEDICAL_DEL
            (
                string pc_created_by,
                ref string strMessage
            )
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
                oCommand.CommandText = "sp_IMPORT_PAYMENT_MEDICAL_DEL";
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

        #region SP_IMPORT_PAYMENT_MEDICAL_SEL
        public bool SP_IMPORT_PAYMENT_MEDICAL_SEL(string strCriteria, ref DataSet ds, ref string strMessage)
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
                oCommand.CommandText = "sp_IMPORT_PAYMENT_MEDICAL_SEL";
                var oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
                oParamI_vc_criteria.Direction = ParameterDirection.Input;
                oParamI_vc_criteria.Value = strCriteria;
                oCommand.Parameters.Add(oParamI_vc_criteria);
                oAdapter = new SqlDataAdapter(oCommand);
                ds = new DataSet();
                oAdapter.Fill(ds, "sp_IMPORT_PAYMENT_MEDICAL_SEL");
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

        #region SP_IMPORT_PAYMENT_MEDICAL_SAVE
        public bool SP_IMPORT_PAYMENT_MEDICAL_SAVE
            (
                 string ppayment_year,
                 string ppay_year,
                 string ppay_month,
                 string pmc_person_id,
                 string pmc_person_group_code,
                 string pbudget_plan_code,
                 string pitem_code,
                 string pitem_qty,
                 string pitem_amt,
                 string pc_created_by,
                ref string strMessage
            )
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
                oCommand.CommandText = "sp_IMPORT_PAYMENT_MEDICAL_SAVE";
                oCommand.Parameters.Add("ppayment_year", SqlDbType.VarChar).Value = ppayment_year;
                oCommand.Parameters.Add("ppay_year", SqlDbType.VarChar).Value = ppay_year;
                oCommand.Parameters.Add("ppay_month", SqlDbType.VarChar).Value = ppay_month;
                oCommand.Parameters.Add("pmc_person_id", SqlDbType.VarChar).Value = pmc_person_id;
                oCommand.Parameters.Add("pmc_person_group_code", SqlDbType.VarChar).Value = pmc_person_group_code;
                oCommand.Parameters.Add("pbudget_plan_code", SqlDbType.VarChar).Value = pbudget_plan_code;
                oCommand.Parameters.Add("pitem_code", SqlDbType.VarChar).Value = pitem_code;
                oCommand.Parameters.Add("pitem_qty", SqlDbType.Float).Value = double.Parse(pitem_qty);
                oCommand.Parameters.Add("pitem_amt", SqlDbType.Money).Value = double.Parse(pitem_amt);
                oCommand.Parameters.Add("pc_created_by", SqlDbType.VarChar).Value = pc_created_by;
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
