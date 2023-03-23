<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUP_TS01.aspx.cs" Inherits="POPUP_PopUP_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">

        //새창 여는 함수
        function uf_newWin(url, winName, sizeW, sizeH) {
            var nLeft = screen.width / 2 - sizeW / 2;
            var nTop = screen.height / 2 - sizeH / 2;

            opt = ",toolbar=no,menubar=no,location=no,scrollbars=yes,status=no";
            window.open(url, winName, "left=" + nLeft + ",top=" + nTop + ",width=" + sizeW + ",height=" + sizeH + opt);
        }

        //새창 사이즈 정함 
        function uf_reSize(sizeW, sizeH) {
            window.resizeTo(sizeW, sizeH);
        }
        /**
         *  문자열에서 좌우 공백제거
        */

        function trim(str) {
            return replace(str, " ", "");
        }
        function trim2(str) {
            //길이가 8자리?
            if (datestr.length != 6) {
                return null;
            }

        }
       

     </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
             <button type="button" onclick="uf_newWin('../INPUTBOX/INPUTBOX_TS002.aspx','test','1000','1000');">추가</button>
             <button type="button" onclick="uf_newWin('../GoogleChart/GoogleChart_TS006.aspx','test','1000','1000');">추가</button>
            
        </div>
    </form>
</body>
</html>
