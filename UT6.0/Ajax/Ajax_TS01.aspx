<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ajax_TS01.aspx.cs" Inherits="Ajax_Ajax_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ajax TS</title>
    <script src="../Js/jquery-3.2.1.min.js"></script>
      <script type="text/javascript">
        $(document).ready(function () {
            //alert("aaa");
        });

        // 멀티행인 경우 (데이터를 가져와서 여기서 html를 만들는 경우)
        function fnListData() {
            $.ajax({
                type: "POST",
                url: "Ajax_TS01.aspx/GetList",
                data: "{aaa:'11',bbb:5}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "") {
                        return;
                    }
                    else {
                        var rows = JSON.parse(data.d);

                        var list = "";
                        jQuery.each(rows, function (i) {
                            list += "<tr><td>" + rows[i].NAME + "</td><td>" + rows[i].AGE + "</td></tr>"
                        });

                        $("#tbody").html(list);
                    }
                },
                error: function (request, status, error) {
                    alert("code:" + request.status + "\n" + "message:" + request.responseText + "\n" + "error:" + error);
                }
            });
        }

        // 멀티행인 경우 (cs 단에서 html 만들어서 오는 경우)
        function fnListData2() {
            $.ajax({
                type: "POST",
                url: "Ajax_TS01.aspx/GetList2",
                data: "{aaa:'11',bbb:5}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    // .d 라고 하는거는 asp.net에서 문법입니다. 즉 결과값을 가지고 있는 멤버입니다.
                    $("#tbody").html(data.d);
                },
                error: function (request, status, error) {
                    alert("code:" + request.status + "\n" + "message:" + request.responseText + "\n" + "error:" + error);
                }
            });
        }

        // 단일행인 경우
        function fnViewData() {
            $.ajax({
                type: "POST",
                url: "Ajax_TS01.aspx/GetView",
                data: "{aaa:'홍길동',bbb:80}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    // 데이터가 없는 경우
                    if (data.d == "") {
                        return;
                    }
                    else {
                        // 데이터가 있는 경우에만 JSON으로 파싱한다.
                        var rows = JSON.parse(data.d);

                        alert(rows[0].NAME);
                        alert(rows[0].AGE);
                    }
                },
                error: function (request, status, error) {
                    alert("code:"+request.status+"\n"+"message:"+request.responseText+"\n"+"error:"+error);
                }
            });
        }
    </script>

</head>
<body>
     <form id="form1" runat="server">
    <div>
        <input type="button" value="여러행인 경우1" onclick="fnListData();" />
        <input type="button" value="여러행인 경우2" onclick="fnListData2();" />
        <input type="button" value="한개행인 경우" onclick="fnViewData();" />
    </div>
    <br /><br /><br />
    <h2>결과값</h2>
    <table border="1">
        <thead>
        <tr>
            <td>이름</td>
            <td>나이</td>
        </tr>
        </thead>
        <tbody id="tbody"></tbody>
    </table>
    </form>
</body>
</html>
