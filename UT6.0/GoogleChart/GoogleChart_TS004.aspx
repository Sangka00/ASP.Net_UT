<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleChart_TS004.aspx.cs" Inherits="GoogleChart_GoogleChart_TS004" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            google.charts.load('current', { 'packages': ['bar', 'corechart'] });
   google.charts.setOnLoadCallback(drawBasic);
        });

  function drawBasic() {

   $.ajax({
    type: "POST",
    url: "GoogleChart_TS004.aspx/GetData",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
     var data = google.visualization.arrayToDataTable(JSON.parse(data.d));

        var options = {
              bars: 'vertical',
            title: '메뉴얼 사용빈도',
            width: 600,
            height: 400,
            chartArea: { width: '50%' },
            legend: { position: "right" },
            isStacked: false,
              tooltip: { textStyle: { fontSize: 12 }, showColorCode: true },
              hAxis: {
               title: 'Total ',
               minValue: 0
            },
            animation: { //차트가 뿌려질때 실행될 애니메이션 효과
                startup: true,
                duration: 1000,
                easing: 'linear'
            },

              annotations: {
               textStyle: {
                fontName: 'Times-Roman',
                fontSize: 18,
                bold: true,
                italic: true,
                // The color of the text.
                color: '#871b47',
                // The color of the text outline.
                auraColor: '#d799ae',
                // The transparency of the text.
                opacity: 0.8
               }
      }
     };

        var chart = new google.visualization.BarChart(document.getElementById('chart_div'));

     chart.draw(data, options);
    },
    complete: function () {
    },
    error: function (request, status, error) {
    }
   });
  }
 </script>

</head>
<body>
    <form id="form1" runat="server">
        <div> <div id="chart_div"></div>
        </div>
    </form>
</body>
</html>
