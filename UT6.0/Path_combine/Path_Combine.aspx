<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Path_Combine.aspx.cs" Inherits="Path_combine_Path_Combine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lbl_Domain" runat="server" Text="Domain"></asp:Label>
            <asp:TextBox ID="Txt_Domain" runat="server"></asp:TextBox>
            <asp:Label ID="Lbl_URL" runat="server" Text="URL"></asp:Label>
            <asp:TextBox ID="Txt_URL" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Combine" OnClick="Button1_Click" />
            <br />

            <asp:Label ID="Lbl_Rs" runat="server" Text="Label"></asp:Label>
            </div>
    </form>
</body>
</html>
