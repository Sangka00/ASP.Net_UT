<%@ Page Language="C#" AutoEventWireup="true" CodeFile="postMessage_TS01.aspx.cs" Inherits="Javascript_postMessage_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript">
         //        Window.opener.postMessage("message",*);
         function fnListData2() {
           //  Window.open.postMessage("message", "*");
             //  window.open.postMessage("message");
             window.opener.postMessage("aaaa", "*");
           //  targetWindow.postMessage("message","*");
         }
     </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
              <input type="button" value="여러행인 경우1" onclick="fnListData2();" />
        </div>
    </form>
</body>
</html>
