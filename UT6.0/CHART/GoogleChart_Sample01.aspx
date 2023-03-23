<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleChart_Sample01.aspx.cs" Inherits="CHART_GoogleChart_Sample01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <!--GoogleChart 라이브러리 불러오기-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        //불러올 차트 타입 정하기
        //차트를 그리는 function 주기
        google.charts.load('current', { 'packages': ['bar'] });
        //차트를 그리는 function 주기
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            //var data = google.visualization.arrayToDataTable([
            //    ['Year', 'Sales', 'Expenses', 'Profit','etc'],
            //    ['2014', 1000, 400, 200,150],
            //    ['2015', 1170, 460, 250,1000],
            //    ['2016', 660, 1120, 300,10],
            //    ['2017', 1030, 540, 350,450]
            //]);

            var data = google.visualization.arrayToDataTable([
                ['Year', 'Sales', 'Expenses', 'Profit', 'etc'],
                ['2014', 1000, 400, 200, 150],
                ['2015', 1170, 460, 250, 1000],
                ['2016', 660, 1120, 300, 10],
                ['2017', 1030, 540, 350, 450]
            ]);

            var options = {
                chart: {
                    title: 'Company Performance',  // 타이틀
                    subtitle: 'Sales, Expenses, and Profit: 2014-2017',  //서브타이틀
                    titlePosition: 'in' // 제목 위치 그래프 안 in 밖 out
                }, // bar, column 차트 등
                legend: {  //범례 보이기
                 //   position: 'none'
                }
                //,
                //// pie 차트 등
                //var options = {
                //    legend: `none`
                //}
                ,
                hAxis: { textPosition: 'none' }, // 가로축 제거
                bar: { groupWidth: "95%" },
              //  vAxis: { textPosition: 'none' } // 세로축 제거
            };

            var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

            chart.draw(data, google.charts.Bar.convertOptions(options));
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="columnchart_material" style="width: 800px; height: 500px;"></div>
    </form>
</body>
</html>
