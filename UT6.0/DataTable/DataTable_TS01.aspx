<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTable_TS01.aspx.cs" Inherits="DataTable_DataTable_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="Button1" runat="server" Text="DataTable 필드 단위입력" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Object 배열로 밀어 넣기" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="GetInputParamDataTable" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
