<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EmployeProj.UI.Index" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:TextBox ID="TextCity" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnLoadReport" runat="server" Text="Load report" OnClick="btnLoadReport_Click" />
        </div>
        <div>          
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="935px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
