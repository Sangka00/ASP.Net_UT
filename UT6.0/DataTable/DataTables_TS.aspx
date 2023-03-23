<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTables_TS.aspx.cs" Inherits="DataTables_DataTables_TS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="stylesheet" href="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.css"/> 
    <script src="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.js"></script>
      <script>
        jQuery(function($){
            $("#foo-table").DataTable({
                //1번째 항목을 오름 차순 
                // order : [ [ 열 번호, 정렬 순서 ], ... ]
                order: [[0, "desc"]],
               
                lengthChange: true,    // 표시 건수기능 숨기기
                
                searching: true,    // 검색 기능 숨기기
                
                ordering: true,   // 정렬 기능 숨기기
               
                info: true,           // 정보 표시 숨기기
              
                paging: true,      // 페이징 기능 숨기기
                // 가로 스크롤바를 표시
                // 설정 값은 true 또는 false
                // 표시 건수를 10건 단위로 설정
                lengthMenu: [10, 20, 30, 40, 50],

                // 기본 표시 건수를 50건으로 설정
                displayLength: 50,
             
                columnDefs: [
                    { targets: 0, visible: true, width: 30},
                    { targets: 1, width: 50 }
                ]



                

            });
        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table id="foo-table" class="table table-bordered">
		<thead>
			<tr><th>No</th><th>지역선택</th></tr>
		</thead>
		<tbody>
			<tr><td>1</td><td>서울</td></tr>
			<tr><td>2</td><td>경기도</td></tr>
			<tr><td>3</td><td>충청남도</td></tr>
			<tr><td>4</td><td>충청북도</td></tr>
			<tr><td>5</td><td>전라남도</td></tr>
			<tr><td>6</td><td>전라북도</td></tr>
			<tr><td>7</td><td>경상남도</td></tr>
			<tr><td>8</td><td>경상북도</td></tr>
			<tr><td>9</td><td>강원도</td></tr>
			<tr><td>10</td><td>제주도</td></tr>
			<tr><td>99</td><td>해외</td></tr>
		</tbody>
    </table>

        </div>
    </form>
</body>
</html>
