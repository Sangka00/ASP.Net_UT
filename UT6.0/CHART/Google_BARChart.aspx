<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Google_BARChart.aspx.cs" Inherits="CHART_Google_BARChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
     <script type="text/javascript"> 
         var data = google.visualization.arrayToDataTable([
             ['Element', 'Density', { role: 'style' }],
             ['Copper', 8.94, '#b87333'],            // RGB value
             ['Silver', 10.49, 'silver'],            // English color name
             ['Gold', 19.30, 'gold'],
             ['Platinum', 21.45, 'color: #e5e4e2'], // CSS-style declaration
         ]);
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
