<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleChart_TS003.aspx.cs" Inherits="GoogleChart_GoogleChart_TS003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://www.google.com/jsapi"></script>
<script type="text/javascript">
   // google.load("visualization", "1", { packages: ["bar", "corechart"] });
    google.charts.load('current', { 'packages': ['bar', 'corechart'] });

   
   
    function drawChart() {
        var options = {
            bars: 'vertical',
            title: '메뉴얼 사용빈도',
            width: 600,
            height: 400,
            bar: { groupWidth: "55%" },
            legend: { position: "right" },
            isStacked: false,
            tooltip: { textStyle: { fontSize: 12 }, showColorCode: true },
            
            
            animation: { //차트가 뿌려질때 실행될 애니메이션 효과
                startup: true,
                duration: 1000,
                easing: 'linear'
            },
            annotations: {
                textStyle: {
                    fontSize: 15,
                    bold: true,
                    italic: true,
                    color: '#871b47',
                    auraColor: '#d799ae',
                    opacity: 1.8
                }
            }
           
        };
        $.ajax({
            type: "POST",
            url: "GoogleChart_TS003.aspx/GetChartData",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert(r.d);
          //    var data = google.visualization.arrayToDataTable(r.d);
                
             var data = google.visualization.arrayToDataTable([
                  ["Element", "Density", {"role": "annotation" }],
                    ["Copper", 8.94,  "8.94"],
                  ["Silver", 10.49,  "10.49"],
                  ["Gold", 19.30, "19.30"],
                  ["Platinum", 21.45,  "21.45"]
                ]);

            //    var data = google.visualization.arrayToDataTable([
            //        ['City', 'Population', 'Area', { role: 'annotation' }],
          //          ['Rome', 2761477, 128775.31, 'Cu']])

                document.write(r.d);

                var chart = new google.visualization.BarChart($("#chart")[0]);
                chart.draw(data, options);
            },
            failure: function (r) {
                alert(r.d);
            },
            error: function (r) {
                alert(r.d);
            }
        });
    }

    google.setOnLoadCallback(drawChart);
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="chart" style="width: 900px; height: 500px;">
        </div>
    </form>
</body>
</html>
