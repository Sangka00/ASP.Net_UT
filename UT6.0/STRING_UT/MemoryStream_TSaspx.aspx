<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemoryStream_TSaspx.aspx.cs" Inherits="Sting_UT_MemoryStream_TSaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Btn_MemoryStream" runat="server" Text="Memory Stream" OnClick="Btn_MemoryStream_Click" />
        <asp:Label ID="Lbl_mStream" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="BTN_SteamReader" runat="server" Text="Stream Reader" OnClick="BTN_SteamReader_Click" />
        <asp:Label ID="Lbl_StreamReader" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Btn_BinaryWriter" runat="server" Text="BinaryWriter" OnClick="Btn_BinaryWriter_Click" />
         <asp:Label ID="Lbl_BinaryWriter" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
