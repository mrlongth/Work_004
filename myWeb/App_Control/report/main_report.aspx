<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="main_report.aspx.cs" Inherits="myWeb.App_Control.report.main_report"
    Title="แสดงรายงาน" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="pnlYear" runat="server" CssClass="row">
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage4">ปีงบประมาณ :</asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:DropDownList runat="server" CssClass="textbox" ID="cboYear"
                AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlDegree" runat="server" CssClass="row ">

        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="Label2">ประเภทงบประมาณ :
            </asp:Label>
        </div>
        <div class="col-lg-2 nopadding">
            <asp:DropDownList runat="server" CssClass="textbox" ID="cboBudgetType" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage18">ระดับการศึกษา :</asp:Label>
        </div>
        <div class="col-lg-2 nopadding">
            <asp:DropDownList runat="server" CssClass="textbox" ID="cboDegree"
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlDate" runat="server" CssClass="row ">
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage22">ตั้งแต่วันที่ : </asp:Label>
        </div>
        <div class="col-lg-2 nopadding">
            <asp:TextBox ID="txtdate_begin" runat="server" CssClass="textbox"
                Width="100px" />
        </div>
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage24">ถึงวันที่ :</asp:Label>
        </div>
        <div class="col-lg-2 nopadding">
            <asp:TextBox ID="txtdate_end" runat="server" CssClass="textbox"
                Width="100px" />
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlSearchDoc" runat="server" CssClass="row ">
        <asp:Panel ID="pnlDocno" runat="server" >
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage19">เลขที่เอกสาร : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_doc"></asp:TextBox>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlBudgetplan" runat="server" >
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">รหัสผังงบประมาณ : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_plan_code"></asp:TextBox>
            </div>
        </asp:Panel>
    </asp:Panel>


    <asp:Panel ID="pnlBudget" runat="server" CssClass="row ">
        <div class="row">
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage8">หน่วยงาน :
                </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit" AutoPostBack="True" OnSelectedIndexChanged="cboUnit_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="col-lg-2 text-right">
                <asp:Label ID="lblPage5" runat="server" CssClass="label_h">แผนงบประมาณ  :</asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboBudget" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboBudget_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-2 text-right">
                <asp:Label ID="lblPage15" runat="server" CssClass="label_h">ผลผลิต :</asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboProduce" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboProduce_SelectedIndexChanged">
                </asp:DropDownList>

            </div>
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage16">กิจกรรม :</asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboActivity" runat="server" CssClass="textbox" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlMajor" runat="server" CssClass="row ">
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage23">หลักสูตร :</asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:DropDownList ID="cboMajor" runat="server" CssClass="textbox" AutoPostBack="True">
            </asp:DropDownList>
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlItem" runat="server" CssClass="row ">

        <div class="row">
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="Label3">งบ : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboLot" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboLot_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="Label4">หมวดค่าจ่าย : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboItem_group" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="Label5">รายละเอียดหมวดค่าจ่าย : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboItem_group_detail" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_detail_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="Label6">รายการค่าใช้จ่าย : </asp:Label>
            </div>
            <div class="col-lg-2 nopadding">
                <asp:DropDownList ID="cboItem" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-lg-2 text-right">
                <asp:Label runat="server" CssClass="label_h" ID="Label7">รายละเอียดค่าใช้จ่าย :</asp:Label>
            </div>
            <div class="col-lg-4">
                <asp:DropDownList ID="cboItem_detail" runat="server" CssClass="textbox" AutoPostBack="True">
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>


    

    <asp:Panel ID="pnlApproveStatus" runat="server" CssClass="row ">
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="lblPage26">สถานะการอนุมัติ :</asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:DropDownList runat="server" CssClass="textbox" ID="cboApproveStatus">
                <asp:ListItem Value="">---- เลือกข้อมูลทั้งหมด ----</asp:ListItem>
                <asp:ListItem Value="P">รออนุมัติ</asp:ListItem>
                <asp:ListItem Value="A">อนุมัติ</asp:ListItem>
                <asp:ListItem Value="C">ยกเลิกรายการ</asp:ListItem>
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlExportOption" runat="server" CssClass="row ">
        <div class="col-lg-2 text-right">
            <asp:Label runat="server" CssClass="label_h" ID="Label1">รูปแบบรายงาน :</asp:Label>
        </div>
        <div class="col-lg-4">
            <asp:CheckBox ID="chkPdf" runat="server" Checked="true" Text="Pdf" />
            <asp:CheckBox ID="chkExcel" runat="server" Checked="false" Text="Excel" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlControl" runat="server" CssClass="row ">
        <div class="col-lg-2 text-right">
        </div>
        <div class="col-lg-4">
            <asp:HyperLink ID="lnkPdfFile" runat="server" CssClass="pdf" Target="_blank">
                <img id="imgPdf" runat="server" alt="ดาวน์โหลดไฟล์" src="~/images/icon_pdfdisable.gif" border="0" />
            </asp:HyperLink>
            <asp:HyperLink ID="lnkExcelFile" runat="server" CssClass="pdf" Target="_blank">
                <img id="imgExcel" runat="server" alt="ดาวน์โหลดไฟล์" src="~/images/icon_exceldisable.gif" border="0" />
            </asp:HyperLink>
            <asp:ImageButton runat="server" AlternateText="พิมพ์ข้อมูล" ImageUrl="~/images/button/print.png"
                ID="imgPrint" OnClick="imgPrint_Click"></asp:ImageButton>
            <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
        </div>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
