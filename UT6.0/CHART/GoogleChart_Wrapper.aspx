<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleChart_Wrapper.aspx.cs" Inherits="CHART_GoogleChart_Wrapper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GoogleChart_Wrapper</title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current');   // Don't need to specify chart libraries!
      google.charts.setOnLoadCallback(drawVisualization);

      function drawVisualization() {
        var wrapper = new google.visualization.ChartWrapper({
          chartType: 'ColumnChart',
          dataTable: [['', 'Germany', 'USA', 'Brazil', 'Canada', 'France', 'RU'],
                      ['', 700, 300, 400, 500, 600, 800]],
          options: {'title': 'Countries'},
          containerId: 'vis_div'
        });
        wrapper.draw();
      }
    </script>
</head>
<body>
    <!-- GoogleChart_Wrapper
        Chart_Wrapper
        적절한 차트 라이브러리를 모두 로드하는 것을 처리하고 차트 도구 데이터 원본에 대한 쿼리 전송을 단순화하는 편리한 클래스
        [장점]
           1. 훨씬 적은 코드
           2. 필요한 모든 차트 라이브러리를로드합니다.
           3. 개체를 만들고 콜백을 처리하여 데이터 원본을 훨씬 쉽게 쿼리할 수 있습니다.Query
           4. 컨테이너 요소 ID를 전달하면 getElementByID를 호출합니다.
           5. 데이터는 값 배열, JSON 리터럴 문자열 또는 핸들과 같은 다양한 형식으로 제출할 수 있습니다.DataTable
        [단점]
             ChartWrapper 현재는 선택, 준비 및 오류 이벤트만 전파합니다. 
             다른 이벤트를 가져오려면 래핑된 차트에 대한 핸들을 가져오고 해당 차트에서 이벤트를 구독해야 합니다

        다음은 로컬로 구성된 데이터가 배열로 지정된 세로 막대형 차트의 예입니다. 
        배열 구문을 사용하여 차트 레이블 또는 datetime 값을 지정할 수는 없지만 해당 값을 사용하여 
        수동으로 개체를 만들어 속성에 전달할 수 있습니다.DataTabledataTable
     -->
    <form id="form1" runat="server" style="font-family: Arial;border: 0 none;">
         <div id="vis_div" style="width: 600px; height: 400px;"></div>
    </form>
</body>
</html>
