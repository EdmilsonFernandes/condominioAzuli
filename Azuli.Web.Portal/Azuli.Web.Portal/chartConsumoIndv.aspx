<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chartConsumoIndv.aspx.cs" Inherits="Azuli.Web.Portal.chartConsumoIndv" %>
<%@ Register TagPrefix="highchart"  Namespace="Highchart.UI" Assembly="Highchart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>

	
    <script src="Scripts/highcharts.js" type="text/javascript"></script>
    <script src="Scripts/exporting.js" type="text/javascript"></script>

    <title>Gráficos de Gestão de Água</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 539px;
        }
    </style>

    <script type="text/javascript">
    $(function () {
        $('#container').highcharts({
            chart: {
                type: 'column',
                margin: [ 50, 50, 100, 80]
            },
            title: {
                text: 'Consumo Mensal Individual - Azuli Ano Base - ' + <%= anobaseSerializado  %>
            },
            xAxis: {
                categories:<%=chartDataCategory %>,
                labels: {
                    rotation: -45,
                    align: 'right',
                    style: {
                        fontSize: '13px',
                        fontFamily: 'Verdana, sans-serif'
                    }
                }
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Consumo de Água - Minímo 10 M³'
                }
            },
            legend: {
                enabled: true
            },
            tooltip: {
                pointFormat: 'Consumo <b>{point.y:.0f} M³ </b>'
                
            },
            series: [{
                name: 'Consumo Mensal Individual - Bloco: ' + <%=blocoSerial %> + ' Apto: ' + <%=aptoSerial  %>,
                data: <%=chartDataSeries %>,
                dataLabels: {
                    enabled: true,
                    rotation: -90,
                    color: '#FFFAFA',
                    align: 'center',
                    x:5,
                    y:10
                   }
                },
                {
                type: 'line',
                name: 'Minímo 10 M³',
                data: [10, 10, 10, 10, 10,10,10,10,10,10,10,10],
                marker: {
                	lineWidth: -1,
                	lineColor: Highcharts.getOptions().colors[1],
                	fillColor: 'red'
                    }
            }],

        });
    });
    
  </script>
</head>
<body>
    <form id="form1" runat="server">
   <center><legend align="bottom" class="accordionContent">CONDOMÍNIO RESIDENCIAL SPAZIO CAMPO AZULI</legend></center>
  <center>  
  
   <asp:Button ID="btnVoltar" runat="server" CssClass="AlternatingRowStyle" 
           onclick="btnVoltar_Click" Text="Voltar" />
  
  <div id="container" align="center" runat="server"> 
    
      
           
      
      
      <asp:Literal id="ltrChart1" runat="server"></asp:Literal>

   
   <%--<highchart:columnchart id="hcConsumoGeral" width="500" height="400" runat="server"></highchart:columnchart>--%>

 
                    

 
              

  </div></center>
    </form>
</body>
</html>
