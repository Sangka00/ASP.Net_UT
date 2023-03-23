<%@ Page Language="C#" AutoEventWireup="true" CodeFile="postMessage_Parent.aspx.cs" Inherits="Javascript_postMessage_Parent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript">
         var popup;
         function fnListData() {
            //  popup = window.open("postMessage_TS01.aspx");
             popup = window.open("http://gsup.gitauto.com/GDSN/gdsmobile_web/Certify/Category/GDSN/License4th_check.aspx");
             
         }
         // This does nothing, assuming the window hasn't changed its location.
     
         window.addEventListener("message", receiveMessage, false);
       
         function receiveMessage(event) {
             event.source.postMessage("hi there yourself!  the secret response " +
                 "is: rheeeeet!",
                 event.origin);

             alert(event.data);
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <input type="button" value="여러행인 경우1" onclick="fnListData();" />
        </div>
    </form>
</body>
</html>
