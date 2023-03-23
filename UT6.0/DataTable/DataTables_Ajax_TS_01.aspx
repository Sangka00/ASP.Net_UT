<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTables_Ajax_TS_01.aspx.cs" Inherits="DataTable_DataTables_Ajax_TS_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DataTables Control</title>
     
    <script src="../Js/jquery-3.2.1.min.js"></script>
     <link rel="stylesheet" href="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.css"/> 
    <script src="https://cdn.datatables.net/t/bs-3.3.6/jqc-1.12.0,dt-1.10.11/datatables.min.js"></script>
      <script type="text/javascript">
          $(document).ready(function () {
              var t
              $.ajax({
                  type: "POST",
                  url: "DataTables_Ajax_TS_01.aspx/GetList",
                  data: {},
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",

                  success: function (data) {
                      if (data.d.length) {

                          t = $("#example").DataTable({
                              "responsive": true,

                              "data": JSON.parse(data.d),
                              'dataSrc': '',
                              "columns": [
                                  { "data": "id" },
                                  { "data": "Name" },
                                  { "data": "position" },
                                  { "data": "salary" },
                                  { "data": "start_date" },
                                  { "data": "office" },
                                  { "data": "extn" }
                              ],
                              "scrollY": "50vh",   //Y축의 50%
                              "scrollCollapse": true,
                              "paging": true,
                              "scrollX": true, //X축 스크롤
                          })




                      } else {
                          $("#example").DataTable({
                              "language": {
                                  "emptyTable": "No data"
                              }
                          });




                      }
                  },
                  error: function (request, status, error) {
                      alert("code:" + request.status + "\n" + "message:" + request.responseText + "\n" + "error:" + error);
                  }
              })





          });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button id="addRow">Add new Row</button>
            <table class="display" id="example" style="width: 100%;">

        <thead>
            <tr>
                 <th>id</th>
                <th>Name</th>
                <th>position</th>
                 <th>salary</th>
                 <th>start_date</th>
                 <th>office</th>
                <th>extn</th>
            </tr>

        </thead>

    </table>
        </div>
    </form>
</body>
</html>
