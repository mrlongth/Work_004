using Aware.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using myModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myDLL.Common
{
    public class GenerateReport : IDisposable
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

        public string Retive_Rep_007(string criteria,  string strCriteriaDesc , string userPrint , bool isPdf , bool isExcel)
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
                string strPath = "~/reports/Rep_007.rpt";
                rptSource.Load(HttpContext.Current.Server.MapPath(strPath));
                var ds = oReport.SP_REP_007(criteria);
                rptSource.SetDataSource(ds.Tables[0]);
                rptSource.SetParameterValue("UserName", userPrint);
                rptSource.SetParameterValue("CompanyName", strCompanyName);
                rptSource.SetParameterValue("CriteriaDesc", strCriteriaDesc);
                if (isPdf)
                {
                    rptSource.ExportToDisk(ExportFormatType.PortableDocFormat, HttpContext.Current.Server.MapPath("~/temp/") + strFilename + ".pdf");
                }
                if (isExcel)
                {
                    rptSource.ExportToDisk(ExportFormatType.ExcelWorkbook, HttpContext.Current.Server.MapPath("~/temp/") + strFilename + ".xlsx");
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
