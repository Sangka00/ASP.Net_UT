<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GooglePieChart_TS.aspx.cs" Inherits="CHART_GooglePieChart_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {

        var data = google.visualization.arrayToDataTable([
          ['Task', 'Hours per Day'],
          ['Work',     1],
          ['Eat',      2],
          ['Commute',  2],
          ['Watch TV', 2],
          ['Sleep',    7]
        ]);

        var options = {
          title: 'My Daily '
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
      }
    </script>
     <script type="text/javascript">
         google.charts.load("current", { packages: ["corechart"] });
         google.charts.setOnLoadCallback(drawChart);
         function drawChart() {
             var data = google.visualization.arrayToDataTable([
                 ['Task', 'Hours per Day'],
                 ['Work', 11],
                 ['Eat', 2],
                 ['Commute', 2],
                 ['Watch TV', 2],
                 ['Sleep', 7]
             ]);

             var options = {
                 title: 'My Daily Activities',
                 is3D: true,
             };

             var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
             chart.draw(data, options);
         }
     </script>
     <script type="text/javascript">
         google.charts.load("current", { packages: ["corechart"] });
         google.charts.setOnLoadCallback(drawChart);
         function drawChart() {
             var data = google.visualization.arrayToDataTable([
                 ['Task', 'Hours per Day'],
                 ['Work', 11],
                 ['Eat', 2],
                 ['Commute', 2],
                 ['Watch TV', 2],
                 ['Sleep', 7]
             ]);

             var options = {
                 title: 'My Daily Activities',
                 pieHole: 0.4,
             };

             var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
             chart.draw(data, options);
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="piechart" style="width: 900px; height: 500px;"></div>
         <div id="piechart_3d" style="width: 900px; height: 500px;"></div>
         <div id="donutchart" style="width: 900px; height: 500px;"></div>
    </form>
</body>
</html>
