<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jsonp_TS01.aspx.cs" Inherits="jsonp_Jsonp_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.3.js"></script>
<script type="text/javascript">
    function getName() {
        $.ajax({
            url: "http://other-api.domain.com/Board/GetName",
            type: "GET",
            dataType: "JSONP",
            jsonpCallback: "callback",
            data: {
                "id": "hong"
            }
        }).success(function (data) {
            alert(data["Name"]);
        }).fail(function () {
            alert("error");
        });
    }
</script>
        </div>
    </form>
</body>
</html>
