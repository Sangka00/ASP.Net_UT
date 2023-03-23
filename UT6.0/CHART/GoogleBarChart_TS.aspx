<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleBarChart_TS.aspx.cs" Inherits="Chart_GoogleBarChart_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bar Chart </title>
    <script type="text/javascript" src="../js/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript"> 
        google.load("visualization", "1", { packages: ["corechart"] }); // chart 사용준비
        google.setOnLoadCallback(drawChart); //로딩 완료시 함수 실행하여 차트 생성

        function drawChart() {
            var options = {
                chart: {
                    title: "GDS-M Model",        //제목
                    subtitle: " sale, Expenses, and profit : 2014-2017",
                    width: 300,                  //가로 px
                    height: 500,                //세로 px
                    bar: { groupWidth: "5%" },   //그래프 너비 설정 %
                    // legend: { position: "none" }, //항목 표시 여부(현재 설정 안함)
                    legend: { position: "right" },
                    
                    tooltip: { textStyle: { fontSize: 32 }, showColorCode: false }
                },
                //  bars: 'horizontal',  bars: 'vertical', // Required for Material Bar Charts.
                bars: 'horizontal',
                animation: { //차트가 뿌려질때 실행될 애니메이션 효과
                    startup: true,
                    duration: 1000,
                    easing: 'linear'
                },
                annotations: {
                    textStyle: {
                        fontSize: 35,
                        bold: false,
                        italic: true,
                        color: '#871b47',
                        auraColor: '#d799ae',
                        opacity: 1.8
                    }
                },
                isStacked: true
            };
            $.ajax({
                type: "POST",
                url: "Googlebarchart_TS.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
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

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="chart" style="width: 900px; height: 500px;"></div>
       
    </form>
</body>
</html>
