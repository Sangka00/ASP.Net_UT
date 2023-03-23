<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Google_gauge_Chart.aspx.cs" Inherits="CHART_Google_gauge_Chart" %>
<html>
  <head>
   <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
   <script type="text/javascript">
       google.charts.load('current', { 'packages': ['gauge'] });
       google.charts.setOnLoadCallback(drawChart);

       function drawChart() {
           var data = google.visualization.arrayToDataTable([
               ['Label', 'Value'],
               ['Memory', 85],              
           ]);
             //  ['CPU', 55],
             //  ['Network', 68]
           var options = {
               width: 500, height: 220,
               max: 100,
               redFrom: 90, redTo: 100,
               yellowFrom: 75, yellowTo: 90,
               greenFrom: 30, greenTo: 75,
              
               majorTicks: ['0GB', '10', '20', '30', '40', '50','60', '70','80', '90', '100GB'], //굵은 눈금을 설정, 값의 갯수는 굵운 눈금의 갯수
               minorTicks: 5    // 굵은 눈금사이에 들어가는 작은 눈금의 갯수
           };

           var chart = new google.visualization.Gauge(document.getElementById('chart_div'));

           chart.draw(data, options);

           setInterval(function () {
               data.setValue(0, 1, 40 + Math.round(60 * Math.random()));
               chart.draw(data, options);
           }, 1000); // 지정된 주기로 특정 코드 실행, setInterval, 1초가 1000

           //setInterval(function () {
           //    data.setValue(1, 1, 40 + Math.round(60 * Math.random()));
           //    chart.draw(data, options);
           //}, 5000);
           //setInterval(function () {
           //    data.setValue(2, 1, 60 + Math.round(20 * Math.random()));
           //    chart.draw(data, options);
           //}, 26000);  
       }
   </script>
  </head>
  <body>
    <div id="chart_div" style="width: 500px; height: 320px;"></div>
  </body>
</html>
