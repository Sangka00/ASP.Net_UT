<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTables_TS3.aspx.cs" Inherits="DataTables_DataTables_TS3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.css"/> 
		<script src="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.js"></script>
		<script>
			jQuery(function($){
				$("#foo-table").DataTable({
                   // 옵션 항목 위치를 변경하거나 추가하고 싶은 항목이 있는 경우에는 lfrtip를 변경해 주면 됩니다
                    stateSave: true,  
						
					
                    columnDefs: [
                        { targets: 0, render: $.fn.dataTable.render.number(',') }
                        , { targets: 1, render: $.fn.dataTable.render.number(',', '.', 0, '', '원') }
                        , { targets: 2, render: $.fn.dataTable.render.number(',', '.', 0, '', '\\') }]


                

                  

				});
			});
		</script>
		<style>
	           /* 필터링 (검색) */
				div.dataTables_filter {
					text-align : left !important;
				}

				/* 표시 건수수 설정 */
				div.dataTables_length {
					text-align : right !important;
				}

		</style>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<table id="foo-table" class="table table-bordered">
			<thead>
				<tr>
					<th>1</th>
					<th>2</th>
					<th>3</th>
				</tr>
			</thead>
			<tbody>
				<tr><td>35000</td><td>35000</td><td>35000</td></tr>
				<tr><td>1500</td><td>1500</td><td>1500</td></tr>
				<tr><td>28390</td><td>28390</td><td>28390</td></tr>
				<tr><td>1300</td><td>1300</td><td>1300</td></tr>
			</tbody>
		</table>

        </div>
    </form>
</body>
</html>
