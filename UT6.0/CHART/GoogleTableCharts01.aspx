<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleTableCharts01.aspx.cs" Inherits="CHART_GoogleTableCharts01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../js/jquery-3.2.1.min.js"></script>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        //'current'를 통해 가장 최근 버전의 Google chart를 불러올 수 있다. 새로 나올 다음 버전을 불러오고 싶다면 'upcoming'을 입력
        //'corechart': 원형 그래프를 이용
        google.charts.load('current', { 'packages': ['corechart'] });

        //차트를 그리는 function 주기
        google.charts.setOnLoadCallback(drawChart);

        //차트 그리기, 데이터를 data 변수에 입력하기
        function drawChart() {

            $.ajax({
                type: "POST",
                url: "GoogleTableCharts01.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.Table($("#table_div")[0]);

                    chart.draw(data, options);

                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });


            var data = google.visualization.arrayToDataTable([
                ['Month', 'Sales', 'Expenses'],
                ['1월', 1000, 400],
                ['2월', 1170, 460],
                ['3월', 660, 1120],
                ['4월', 660, 1120],
                ['5월', 1030, 540],
                ['6월', 1030, 900],
                ['7월', 1030, 540],
                ['8월', 1030, 540],
                ['9월', 1030, 540],
                ['10월', 660, 1120],
                ['11월', 660, 1120],
                ['12월', 660, 1120]
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
      google.charts.load('current', {'packages':['table']});
      google.charts.setOnLoadCallback(drawTable);

      function drawTable() {
      
          var options = {
              chart: {
                  title: "M",        //제목
                  showRowNumber: true
              }
          };
          $.ajax({
              type: "POST",
              url: "GoogleTableCharts01.aspx/GetChartData",
              data: '{}',
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (r) {
                  var data = google.visualization.arrayToDataTable(r.d);
                  var chart = new google.visualization.Table($("#table_div")[0]);

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
         <div id="curve_chart" style="width: 900px; height: 500px"></div>
        <p></p>
         <div id="table_div" style="width: 900px; height: 500px;"></div>
    </form>
</body>
</html>
