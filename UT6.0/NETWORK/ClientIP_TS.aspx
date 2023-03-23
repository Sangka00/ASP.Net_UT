<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientIP_TS.aspx.cs" Inherits="NETWORK_ClientIP_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Button ID="btn_IP" runat="server" Text="Client IP" OnClick="btn_IP_Click" />
        <asp:Label ID="lbl_IP" runat="server" Text="" Width="150px"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="ServerINformation" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
