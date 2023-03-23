<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LodingBar_TS.aspx.cs" Inherits="LodingBar_LodingBar_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>로딩테스트</title>
      <script src="../Js/jquery-3.2.1.min.js"   type="text/javascript"></script>
      <script type="text/javascript">
         function create_blindloading() {

             if ($('#container_loading').length > 0) {
                 $('#container_loading').remove();
             }
             var blind_window = '<table id="container_loading" style="width:100%; height:100%; opacity:0.8; filter:alpha(opacity = 80); position:fixed; left:0px; top:0px; z-index:1001; background-color:#ffffff;">'
                 + '<tr>'
                 + '<td style="vertical-align:middle; text-align:center;">'
                 + '<img src="../img/Progress.gif" alt="loading..." />'
                 + '</td>'
                 + '</tr>'
                 + '</table>';

             $('body').append(blind_window);
         }
     </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="로딩테스트" OnClientClick="create_blindloading();" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
