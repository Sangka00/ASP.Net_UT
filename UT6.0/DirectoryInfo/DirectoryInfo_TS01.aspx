<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DirectoryInfo_TS01.aspx.cs" Inherits="DirectoryInfo_DirectoryInfo_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <asp:Button ID="Btn1" runat="server" Text="DirectoryExists" OnClick="Btn1_Click" />
        <asp:Button ID="Btn2" runat="server" Text="DirectoryCreate" OnClick="Btn2_Click" />
        <asp:Button ID="Btn3" runat="server" Text="DirectorySize" OnClick="Btn3_Click" />
        <asp:Button ID="Btn4" runat="server" Text="DirectoryCopy" OnClick="Btn4_Click" />
        <asp:Button ID="Btn5" runat="server" Text="DirectorySort" OnClick="Btn5_Click" />
      <br />
        <asp:Button ID="btn10" runat="server" Text="FileInfoExists" OnClick="btn10_Click" />
        <asp:Button ID="Btn6" runat="server" Text="Root Pass" OnClick="Btn6_Click" />
        </div>
    </form>
</body>
</html>
