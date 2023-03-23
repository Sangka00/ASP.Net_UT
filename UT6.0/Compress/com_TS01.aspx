<%@ Page Language="C#" AutoEventWireup="true" CodeFile="com_TS01.aspx.cs" Inherits="Compress_com_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;--&gt;<asp:TextBox ID="TextBox2" runat="server" Width="825px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="암호화" OnClick="Button1_Click" />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Width="841px"></asp:TextBox>
            --&gt;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="복호화" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
