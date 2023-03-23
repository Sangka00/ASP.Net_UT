<%@ Page Language="C#" AutoEventWireup="true" CodeFile="string_TS.aspx.cs" Inherits="Sting_UT_string_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txt_str" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="문자열 자르기" />
        <asp:Label ID="lbl_str" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
