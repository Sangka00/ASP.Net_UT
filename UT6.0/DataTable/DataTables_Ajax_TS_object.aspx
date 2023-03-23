<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTables_Ajax_TS_object.aspx.cs" Inherits="DataTables_DataTables_Ajax_TS_object" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
     <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css"/> 
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <script  type="text/javascript">
         $(document).ready(function () {

             $('#example').DataTable({

                 "ajax": "DATA2.json",

                 "columns": [

                     { "data": "name" },

                     { "data": "position" },

                     { "data": "office" },

                     { "data": "extn" },

                     { "data": "start_date" },

                     { "data": "salary" }

                 ]

             });

         });
     </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="display" id="example" style="width: 100%;">

        <thead>
            <tr>
                <th>Name</th>
                <th>Position</th>
                <th>Office</th>
                <th>Extn.</th>
                <th>Start date</th>
                <th>Salary</th>
            </tr>
        </thead>
       
    </table>

        </div>
    </form>
</body>
</html>
