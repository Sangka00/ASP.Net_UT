<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleLineChart_WithDB.aspx.cs" Inherits="CHART_GoogleLineChart_WithDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
   <!--<script type="text/javascript" src='https://www.google.com/jsapi'></script> -->

<script type="text/javascript">
    google.load("visualization", "1", { packages: ["corechart"] });
   // google.load("visualization", "1", { packages: ["bar"] });
    google.setOnLoadCallback(drawChart);
    function drawChart() {
        var options = {
            title: 'USA City Distribution',
            width: 1200,
            height: 600,
            bar: { groupWidth: "95%" },
           // legend: { position: "none" },
            isStacked: true
        };
        $.ajax({
            type: "POST",
            url: "GoogleLineChart_WithDB.aspx/GetChartData",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                var data = google.visualization.arrayToDataTable(r.d);
                var LineChart = new google.visualization.LineChart($("#LineChart")[0]);
                     LineChart.draw(data, options);
                var PieChart = new google.visualization.PieChart($("#PieChart")[0]);
                PieChart.draw(data, options);


                var csv = google.visualization.dataTableToCsv(data);
                //console.log(csv);
               // document.write(csv);
                saveToFile_Chrome("c:\aa.csv", csv);
            },
            failure: function (r) {
                alert(r.d);
            },
            error: function (r) {
                alert(r.d);
            }
        });
    }

    function saveToFile_Chrome(fileName, content) {
        var blob = new Blob([content], { type: 'text/plain' });
        objURL = window.URL.createObjectURL(blob);

        // 이전에 생성된 메모리 해제
        if (window.__Xr_objURL_forCreatingFile__) {
            window.URL.revokeObjectURL(window.__Xr_objURL_forCreatingFile__);
        }
        window.__Xr_objURL_forCreatingFile__ = objURL;
        var a = document.createElement('a');
        a.download = fileName;
        a.href = objURL;
        a.click();
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PieChart" style="width: 900px; height: 500px;"></div>
            <p></p>
        <div id="LineChart" style="width: 900px; height: 500px;"></div>
    </form>
</body>
</html>
