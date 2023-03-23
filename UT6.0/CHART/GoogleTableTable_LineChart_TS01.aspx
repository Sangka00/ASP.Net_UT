<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleTableTable_LineChart_TS01.aspx.cs" Inherits="CHART_GoogleTableTable_LineChart_TS01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TableLineChart</title>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['Month', 'Sales', 'Expenses'],
            ['1월', 1000, 400],
            ['2월', 1170, 460]
        ]);

        var options = {
          title: 'Company Performance',
          curveType: 'function',
          legend: { position: 'bottom' },
            page: "enable",
            pageSize: 2,
            pagingSymbols: { prev: 'prev', next: 'next' }
        };

        var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

        chart.draw(data, options);
      }
    </script>

     <script type="text/javascript">
         google.charts.load('current', { 'packages': ['table'] });
         google.charts.setOnLoadCallback(drawTable);

         function drawTable() {
             var data = new google.visualization.DataTable();
             data.addColumn('string', 'Name');
             data.addColumn('number', 'Salary');
             data.addColumn('boolean', 'Check');
             data.addColumn('string', '1월');
             data.addColumn('string', '2월');
             data.addColumn('string', '3월');
             data.addColumn('string', '4월');
             data.addColumn('string', '5월');
             data.addColumn('string', '6월');
             data.addColumn('string', '7월');
             data.addColumn('string', '8월');
             data.addColumn('string', '9월');
             data.addColumn('string', '10월');
             data.addColumn('string', '11월');
             data.addColumn('string', '12월');

             data.addRows([
                 ['Mike', { v: 10000, f: '$10,000' }, true, '1월', '2월', '3월', '4월', '5월', '6월', '7월', '8월', '9월', '10월', '11월', '12월'],
                 ['Jim', { v: 8000, f: '$8,000' }, false, '1월', '2월', '3월', '4월', '5월', '6월', '7월', '8월', '9월', '10월', '11월', '12월'],
                 ['Alice', { v: 12500, f: '$12,500' }, true, '1월', '2월', '3월', '4월', '5월', '6월', '7월', '8월', '9월', '10월', '11월', '12월'],
                 ['Bob', { v: 7000, f: '$7,000' }, true, '1월', '2월', '3월', '4월', '5월', '6월', '7월', '8월', '9월', '10월', '11월', '12월']
             ]);

             var table = new google.visualization.Table(document.getElementById('table_div'));
             var options = {
                 title: 'Company Performance',
                 curveType: 'function',
                 legend: { position: 'bottom' },
                 page: "enable",
                 pageSize: 2,
                 pagingSymbols: { prev: 'prev', next: 'next' },
                 showRowNumber: true,
                 width: '100%',
                 height: '100%'
             };
          //   table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
             table.draw(data, options);
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
         <div id="curve_chart" style="width: 900px; height: 500px"></div>
        <p></p>
        <div id="table_div" style="width: 900px; height: 500px"></div>
        <p></p>
    </form>
</body>
</html>
