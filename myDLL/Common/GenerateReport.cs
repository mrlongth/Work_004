using Aware.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using myModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myDLL.Common
{
    public class GenerateReport<T> : IDisposable
    {

        string strCompanyName = ConfigurationSettings.AppSettings["CompanyName"];

        string _ReportDirectoryTemp;
        private string ReportDirectoryTemp
        {
            get
            {
                if (string.IsNullOrEmpty(_ReportDirectoryTemp))
                {
                    try
                    {
                        _ReportDirectoryTemp = ConfigurationSettings.AppSettings["ReportDirectoryTemp"];

                    }
                    catch
                    {
                        _ReportDirectoryTemp = string.Empty;
                    }
                }
                return _ReportDirectoryTemp;
            }
            set { _ReportDirectoryTemp = value; }
        }

        short _ReportAliveTime;
        private short ReportAliveTime
        {
            get
            {
                if (_ReportAliveTime == 0)
                {
                    try
                    {
                        _ReportAliveTime = short.Parse(ConfigurationSettings.AppSettings["ReportAliveTime"]);
                    }
                    catch
                    {
                        _ReportAliveTime = 0;
                    }
                }
                return _ReportAliveTime;
            }
            set { _ReportAliveTime = value; }
        }

        public GenerateReport()
        {

        }

        public string Retive_Rep_Data(Report_param<T> condition, string strReportPath, DataSet ds)
        {
            var result = string.Empty;
            var oReport = new cReport();
            var rptSource = new ReportDocument();
            try
            {
                string strReportDirectoryTempPhysicalPath = HttpContext.Current.Server.MapPath(this.ReportDirectoryTemp);
                Helper.DeleteUnusedFile(strReportDirectoryTempPhysicalPath, ReportAliveTime);
                string strFilename;
                strFilename = "report_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string strPath = strReportPath;
                rptSource.Load(HttpContext.Current.Server.MapPath(strPath));
                rptSource.SetDataSource(ds.Tables[0]);
                rptSource.SetParameterValue("UserName", condition.Report_user_print);
                rptSource.SetParameterValue("CompanyName", strCompanyName);
                rptSource.SetParameterValue("CriteriaDesc", condition.Report_criteria_desc);
                if (condition.Report_is_pdf)
                {
                    rptSource.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/temp/") + strFilename + ".pdf");
                }
                if (condition.Report_is_excel)
                {
                    rptSource.ExportToDisk(ExportFormatType.Excel, HttpContext.Current.Server.MapPath("~/temp/") + strFilename + ".xls");
                }
                result = strFilename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
                rptSource.Dispose();
            }
            return result;
        }

        public string Retive_Rep_001(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_001(condition.Report_criteria);
                string strPath = "~/reports/Rep_001.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_002(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_002(condition.Report_criteria);
                string strPath = "~/reports/Rep_002.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_003(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_003(condition.Report_criteria);
                string strPath = "~/reports/Rep_003.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_004(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_004(condition.Report_criteria);
                string strPath = "~/reports/Rep_004.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_005(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_005(condition.Report_criteria);
                string strPath = "~/reports/Rep_005.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_006(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_006(condition.Report_criteria);
                string strPath = "~/reports/Rep_006.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_007(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_007(condition.Report_criteria);
                string strPath = "~/reports/Rep_007.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_009(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_009(condition.Report_criteria);
                string strPath = "~/reports/Rep_009.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }

        public string Retive_Rep_010(Report_param<T> condition)
        {
            var result = string.Empty;
            var oReport = new cReport();
            try
            {
                var ds = oReport.SP_REP_010(condition.Report_criteria);
                string strPath = "~/reports/Rep_010.rpt";
                result = Retive_Rep_Data(condition, strPath, ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oReport.Dispose();
            }
            return result;
        }


        #region IDisposable Members

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
