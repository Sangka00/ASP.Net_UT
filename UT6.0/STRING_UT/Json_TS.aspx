<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Json_TS.aspx.cs" Inherits="Sting_UT_Json_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Bnt_Serialize" runat="server" Text="Serialize(객체->Json 문자열)" OnClick="Bnt_Serialize_Click" />
    <asp:Label ID="lbl_Re" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Bnt_Deserialize" runat="server" Text="Deserialize(JSON 문자열 -> 객체)" OnClick="Bnt_Deserialize_Click" />
     <asp:Label ID="lbl_Re1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Bnt_LinQtoJSON" runat="server" Text="Collection Data -> Json 문자열" OnClick="Bnt_LinQtoJSON_Click" />
     <asp:Label ID="lbl_Re2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Bnt_JObject" runat="server" Text="JObject" OnClick="Bnt_JObject_Click" />
    <asp:Label ID="lbl_Re3" runat="server" Text="Label"></asp:Label>
        <br />
     <asp:Button ID="Bnt_JObjectParse" runat="server" Text="JObject.Parse" OnClick="Bnt_JObjectParse_Click" />
    <asp:Label ID="lbl_Re4" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Bnt_JOBjectFromOject" runat="server" Text="JObject.FromObject" OnClick="Bnt_JOBjectFromOject_Click" />
    <asp:Label ID="lbl_Re5" runat="server" Text="Label"></asp:Label>
    <br />
     <asp:Button ID="Bnt_JObjectElement" runat="server" Text="Jobject.Add :  다른 JObject를 Element 추가" OnClick="Bnt_JObjectElement_Click" />
     <asp:Label ID="lbl_Re6" runat="server" Text="Label"></asp:Label>
        <br />
     <asp:Button ID="Bnt_JObjectElement_Read_Del" runat="server" Text="JObject Element Read /Del" OnClick="Bnt_JObjectElement_Read_Del_Click" />
     <asp:Label ID="lbl_Re7" runat="server" Text="Label"></asp:Label>
        <br />
     <asp:Button ID="Bnt_JArray" runat="server" Text="JArray  :Element 입력시 Key를 가지지 않는 다는 것 빼고 Oject와 비슷함 " OnClick="Bnt_JArray_Click" />
     <asp:Label ID="lbl_Re8" runat="server" Text="Label"></asp:Label>
        <br />
    <asp:Button ID="Bnt_parse_count" runat="server" Text="JObject parser count" OnClick="Bnt_parse_count_Click" />
        <asp:Label ID="lbl_Re9" runat="server" Text="Label"></asp:Label>
        <br />
    <asp:Button ID="Bnt_GetJsonValue" runat="server" Text="Get Json Value : json object name to Search Value" OnClick="Bnt_GetJsonValue_Click" />
         <asp:Label ID="lbl_Re10" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="bnt_JsonStringDataSet" runat="server" Text="JsonStringDataSet" OnClick="bnt_JsonStringDataSet_Click" />
         <asp:Label ID="lbl_Re11" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="bnt_JsonStringDataTable" runat="server" Text="JsonStringDataTable" OnClick="bnt_JsonStringDataTable_Click" />
         <asp:Label ID="lbl_Re12" runat="server" Text="Label"></asp:Label>
        <br />
         <asp:Button ID="Bnt_XmlDataSet" runat="server" Text="XmlDataSet" OnClick="Bnt_XmlDataSet_Click" />
          <asp:Label ID="lbl_Re13" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Array" />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="JsonArray2" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
    </form>
</body>
</html>
