﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace myDLL
{
    public class cBank : IDisposable
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

    public cBank()
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

    #region SP_BANK_SEL
    public bool SP_SEL_BANK(string strCriteria, ref DataSet ds,ref string strMessage)
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
            oCommand.CommandText = "sp_BANK_SEL";
            SqlParameter oParamI_vc_criteria = new SqlParameter("vc_criteria", SqlDbType.NVarChar);
            oParamI_vc_criteria.Direction = ParameterDirection.Input;
            oParamI_vc_criteria.Value = strCriteria;
            oCommand.Parameters.Add(oParamI_vc_criteria);
            oAdapter = new SqlDataAdapter(oCommand) ;
            ds = new DataSet();
            oAdapter.Fill(ds, "sp_BANK_SEL");
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

    #region SP_INS_BANK
    public bool SP_INS_BANK(string pbank_code, string pbank_name, string pbank_fee_rate ,  string pfee_charge_normal,
            string pfee_charge_special, string pfee_charge_medical, string pfee_charge_bonus, string  pcheque_code, string pitem_code , string pActive, string pC_created_by, ref string strMessage)
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
            oCommand.CommandText = "sp_BANK_INS";
            // - - - - - - - - - - - -             
            SqlParameter oParam_Bank_code = new SqlParameter("bank_code", SqlDbType.NVarChar);
            oParam_Bank_code.Direction = ParameterDirection.Input;
            oParam_Bank_code.Value = pbank_code;
            oCommand.Parameters.Add(oParam_Bank_code);
            // - - - - - - - - - - - -             
            SqlParameter oParam_Bank_name = new SqlParameter("bank_name", SqlDbType.NVarChar);
            oParam_Bank_name.Direction = ParameterDirection.Input;
            oParam_Bank_name.Value = pbank_name;
            oCommand.Parameters.Add(oParam_Bank_name);


            oCommand.Parameters.Add("bank_fee_rate", SqlDbType.Money).Value = Helper.CDbl(pbank_fee_rate);
            oCommand.Parameters.Add("fee_charge_normal", SqlDbType.Bit).Value = pfee_charge_normal == "1";
            oCommand.Parameters.Add("fee_charge_special", SqlDbType.Bit).Value = pfee_charge_special == "1";
            oCommand.Parameters.Add("fee_charge_medical", SqlDbType.Bit).Value = pfee_charge_medical == "1";
            oCommand.Parameters.Add("fee_charge_bonus", SqlDbType.Bit).Value = pfee_charge_bonus == "1";
            oCommand.Parameters.Add("cheque_code", SqlDbType.VarChar).Value = pcheque_code;
            oCommand.Parameters.Add("item_code", SqlDbType.VarChar).Value = pitem_code;            

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

    #region SP_UPD_BANK
    public bool SP_UPD_BANK(string pbank_code, string pbank_name, string pbank_fee_rate, string pfee_charge_normal,
            string pfee_charge_special, string pfee_charge_medical, string pfee_charge_bonus, string pcheque_code, string pitem_code, string pActive, string pC_updated_by, ref string strMessage)
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
            oCommand.CommandText = "sp_BANK_UPD";
            // - - - - - - - - - - - -             
            SqlParameter oParam_Bank_code = new SqlParameter("bank_code", SqlDbType.NVarChar);
            oParam_Bank_code.Direction = ParameterDirection.Input;
            oParam_Bank_code.Value = pbank_code;
            oCommand.Parameters.Add(oParam_Bank_code);
            // - - - - - - - - - - - -             
            SqlParameter oParam_Bank_name = new SqlParameter("bank_name", SqlDbType.NVarChar);
            oParam_Bank_name.Direction = ParameterDirection.Input;
            oParam_Bank_name.Value = pbank_name;
            oCommand.Parameters.Add(oParam_Bank_name);

            oCommand.Parameters.Add("bank_fee_rate", SqlDbType.Money).Value = Helper.CDbl(pbank_fee_rate);
            oCommand.Parameters.Add("fee_charge_normal", SqlDbType.Bit).Value = pfee_charge_normal == "1";
            oCommand.Parameters.Add("fee_charge_special", SqlDbType.Bit).Value = pfee_charge_special == "1";
            oCommand.Parameters.Add("fee_charge_medical", SqlDbType.Bit).Value = pfee_charge_medical == "1";
            oCommand.Parameters.Add("fee_charge_bonus", SqlDbType.Bit).Value = pfee_charge_bonus == "1";
            oCommand.Parameters.Add("cheque_code", SqlDbType.VarChar).Value = pcheque_code;
            oCommand.Parameters.Add("item_code", SqlDbType.VarChar).Value = pitem_code;            

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

    #region SP_DEL_BANK
    public bool SP_DEL_BANK(string pbank_code, string pActive, string pC_updated_by, ref string strMessage)
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
            oCommand.CommandText = "sp_BANK_DEL";
            // - - - - - - - - - - - -             
            SqlParameter oParam_Bank_code = new SqlParameter("bank_code", SqlDbType.NVarChar);
            oParam_Bank_code.Direction = ParameterDirection.Input;
            oParam_Bank_code.Value = pbank_code;
            oCommand.Parameters.Add(oParam_Bank_code);
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

    #region IDisposable Members

    void IDisposable.Dispose()
    {
        throw new NotImplementedException();
    }

    #endregion

    }
}
