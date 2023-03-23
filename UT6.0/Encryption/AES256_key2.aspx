<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AES256_key2.aspx.cs" Inherits="Encryption_AES256_key2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <asp:TextBox ID="Txt_payload" runat="server" Height="25px" Width="746px"></asp:TextBox>
            <asp:Button ID="Btn_enc" runat="server" Text="암호화" OnClick="Btn_enc_Click" />
            <br />
            <asp:TextBox ID="txt_re1" runat="server" Width="876px" Height="47px"></asp:TextBox>
&nbsp;암호값<br />
            <br />
            <asp:TextBox ID="Txt_enc" runat="server" Width="944px"></asp:TextBox>
            <asp:Button ID="Btn_un" runat="server" Text="복호화" OnClick="Btn_un_Click" />
            <br />
            <br />
            <asp:TextBox ID="txt_re2" runat="server" Height="45px" Width="968px"></asp:TextBox>
            평문<br />

        </div>
    </form>
</body>
</html>
