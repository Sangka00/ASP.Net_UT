<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sam_TS01.aspx.cs" Inherits="Encryption_Sam_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Width="616px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="암호화" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="lbl_encoding" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="615px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="복호화" OnClick="Button2_Click" />

            <br />
            <asp:Label ID="lbl_decoding" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
