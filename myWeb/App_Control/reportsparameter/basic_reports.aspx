<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic_reports.aspx.cs"
    Inherits="myWeb.App_Control.reportsparameter.basic_reports" Debug="true" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />--%>
    <script src="~/scripts/form.js" type="text/javascript"></script>
    <script language="vbscript" src="~/scripts/mju_vbscripts.vbs"></script>
    <title>Report Preview</title>
</head>
<body style="margin: 1px 10px 1px 1px;">
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
            HasCrystalLogo="False" Height="50px" PrintMode="ActiveX"
            Width="350px"  />
        <asp:Label runat="server"  ID="lblError"></asp:Label>
    </div> 
    </form>
</body>
</html>
