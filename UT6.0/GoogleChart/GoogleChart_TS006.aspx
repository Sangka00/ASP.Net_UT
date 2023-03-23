<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleChart_TS006.aspx.cs" Inherits="GoogleChart_GoogleChart_TS006" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
     <script src="../JS/Plugin/jquery-1.5.1.min.js"></script>
     <script type="text/javascript" src="../../Js/Plugin/jquery.datepick.js"></script>
     <script type="text/javascript" src="../../Js/Plugin/jquery.datepick-ko.js"></script>
     <link type="text/css" rel="stylesheet" href="../Css/humanity.datepick.css" />
      

     <link href="../Css/Style.css" rel="stylesheet" />
     <script type="text/javascript">
         $(document).ready(function () {
             OnPageInit();
             fnListData("CHI", "#tbody_China");     
             google.charts.load('current', { 'packages': ['bar', 'corechart'] });
             day_init();
             
         });
         function day_init() {// 
             var date1 = new Date();
             var year1 = date1.getFullYear();
             var month1 = new String(date1.getMonth());
             var day1 = new String(date1.getDate());

             var date2 = new Date();
             var year2 = date2.getFullYear();
             var month2 = new String(date2.getMonth() + 1);
             var day2 = new String(date2.getDate());

             // 한자리수일 경우 0을 채워준다. 
             if (month1.length == 1) {
                 month1 = "0" + month1;
             }
             if (day1.length == 1) {
                 day1 = "0" + day1;
             }
             if (month2.length == 1) {
                 month2 = "0" + month2;
             }
             if (day2.length == 1) {
                 day2 = "0" + day2;
             }
             $("#txtSearchReleaseDTStart").val(year1 + "-" + month1 + "-" + day1);
             $("#txtSearchReleaseDTEnd").val(year2 + "-" + month2 + "-" + day2); 
         }
         function fnListData(agc, str) {
             $.ajax({
                 type: "POST",
                 url: "GoogleChart_TS006.aspx/GetList_ALL",
                 data: "{agc:\"" + agc + "\"}",
                 contentType: "application/json; charset=utf-8",

                 success: function (data) {      // .d 결과값을 가지고 있는 멤버
                     $(str).html(data.d);
                 },
                 error: function (request, status, error) {
                     alert("code:" + request.status + "\n" + "message:" + request.responseText + "\n" + "error:" + error);
                 }
             });
         }
      
         function OnPageInit() {
             // 이벤트 바인딩
             $('#txtSearchReleaseDTStart').datepick({ showOn: 'button', buttonImageOnly: true, buttonImage: '../Img/icon/calendar.gif' }); //방문일 달력
             $('#txtSearchReleaseDTEnd').datepick({ showOn: 'button', buttonImageOnly: true, buttonImage: '../Img/icon/calendar.gif' }); //방문일 달력
           //  $('#btnSearch').click(function () { onSearchPages(1); });
           //  $('#btnExportExcel').click(function () { onSearchPages(1, 'out=xls'); });
         }
         function search() {
             var releaseDTStart = $('#txtSearchReleaseDTStart').val();
             var releaseDTEnd = $('#txtSearchReleaseDTEnd').val();
             // 사용개요 보기
             fnGetList(releaseDTStart, releaseDTEnd, document.getElementById('<%=ddl_Product.ClientID%>').value);
             // 구글차트
             google.charts.setOnLoadCallback(drawBasic(releaseDTStart, releaseDTEnd, document.getElementById('<%=ddl_Product.ClientID%>').value));
         }
         function fnGetList(s_date, e_date, product) {
           
                $.ajax({
                    type: "POST",
                    url: "GoogleChart_TS006.aspx/GetNewID",
                    data: "{sDate:\"" + s_date + "\" , eDate:\"" + e_date + "\" , Product:\"" + product + "\"}",
                 contentType: "application/json; charset=utf-8",
                 success: function (data) {

                     $("#new_custom").html(data.d.NewUUID_CnT);
                     $("#Login_user").html(data.d.Session_CnT);
                     $("#Connect_Cnt").html(data.d.Connect_Cnt);
                 },
                 error: function (request, status, error) {
                     alert("code:" + request.status + "\n" + "message:" + request.responseText + "\n" + "error:" + error);
                 }
             });

            }
         function drawBasic(s_date, e_date, product) {

             $.ajax({
                 type: "POST",
                 url: "GoogleChart_TS006.aspx/GetData",
                 data: "{sDate:\"" + s_date + "\" , eDate:\"" + e_date + "\" , Product:\"" + product + "\"}",
                
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 beforeSend: function () {
                     create_blindloading("a");
                 },
                 success: function (data) {
                     var data = google.visualization.arrayToDataTable(JSON.parse(data.d));
                     if (data.d == "") {
                         return;
                     }
                     
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
                     setTimeout(function () {
                         create_blindloading("b");
                     }, 3000);

                     
                 },
                 complete: function () {
                    
                 },
                 error: function (request, status, error) {
                 }
             });
         }
         function create_blindloading(str) {

             //  if ($('#container_loading').length > 0) {
             //      $('#container_loading').remove();
             //  }

             if (str == "b") {
                 $('#container_loading').remove();
                 return;
             }
             var blind_window = '<table id="container_loading" style="width:100%; height:100%; opacity:0.8; filter:alpha(opacity = 80); position:fixed; left:0px; top:0px; z-index:1001; background-color:#ffffff;">'
                 + '<tr>'
                 + '<td style="vertical-align:middle; text-align:center;">'
                 + '<img src="../img/Progress.gif" alt="loading..." />'
                 + '</td>'
                 + '</tr>'
                 + '</table>';

             $('body').append(blind_window);
         }
     </script>
     <style type="text/css">
        .auto-style1 {
            width: 1000px;
        }
        .auto-style2 {
            cursor: pointer;
            width: 92px;
            font-size: 12px;
            font-weight: bold;
            color: #ffffff;
            text-align: center;
            vertical-align: middle;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-image: url('../../img/button/btn_orange_3.gif');
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     
        <table style="width: 100%;" border="1">
            <tr>
                <td colspan="8">
                    <div id="tbody_China"> </div>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <input id="txtSearchReleaseDTStart" type="text" value="<%=GetQuery("ds") %>" style="width: 120px;" maxlength="10" readonly="readonly" />
                     ~ 
                   <input id="txtSearchReleaseDTEnd" type="text" value="<%=GetQuery("de") %>" style="width: 120px;"   maxlength="10" readonly="readonly" />
                  <asp:DropDownList ID="ddl_Product" runat="server" Width="150" > </asp:DropDownList>        
                   <input id="btnSearch"  class="button1" title="검색" value="검색" onclick="search();"    />

                </td>
                
            </tr>
            <tr>
                <td>신규 가입</td>
                <td><div id ="new_custom"> </div></td>
                <td>로그인 사용자수 </td>
                <td><div id="Login_user"></div></td>
                <td>접속횟수</td>
                <td><div id ="Connect_Cnt"></div></td>
                <td>평균 사용 시간</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">
                    <div id="chart_div"></div>

                </td>
               
            </tr>
        </table>
          
    </form>
</body>
</html>
