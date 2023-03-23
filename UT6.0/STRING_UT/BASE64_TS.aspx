<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BASE64_TS.aspx.cs" Inherits="STRING_UT_BASE64_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div> BASE64 Encoding
        <asp:TextBox ID="Txt_P" runat="server"></asp:TextBox>
        <asp:Button ID="Btn_Base64" runat="server" Text="Base64처리" OnClick="Btn_Base64_Click" />
        <asp:Label ID="lbl_Base64" runat="server" Text="Label"></asp:Label>
    </div>
    <div> Base64 Decoding
        <asp:TextBox ID="Txt_Base64" runat="server"></asp:TextBox>
        <asp:Button ID="Btn_P" runat="server" Text="Base64 평문전환" OnClick="Btn_P_Click" />   
        <asp:Label ID="lbl_p" runat="server" Text="Label"></asp:Label>
     </div>
        </div>
    </form>
</body>
</html>
