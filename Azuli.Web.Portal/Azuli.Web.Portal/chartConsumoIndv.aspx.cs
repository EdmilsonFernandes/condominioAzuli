using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Collections;
using System.Collections.ObjectModel;
using Highchart.Core;
using Highchart.Core.Data.Chart;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Web.Script.Serialization;




namespace Azuli.Web.Portal
{
    public partial class chartConsumoIndv : System.Web.UI.Page
    {
        int anoBaseDefault = DateTime.Now.Year;
        Util.Util oUtil = new Util.Util();
        ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
        listaSegundaViaAgua oListReciboModel = new listaSegundaViaAgua();
        DateTime data = DateTime.Now;
        int bloco = 0;
        int apto = 0;
        public string chartDataCategory { get; set; }
        public string chartDataSeries { get; set; }
        public string anobaseSerializado { get; set; }
        public string blocoSerial { get; set; }
        public string aptoSerial { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            oUtil.validateSession();
            anoBaseDefault = Convert.ToInt32(Session["yearBase"]);
            bloco = Convert.ToInt32(Session["Bloco"]);
            apto = Convert.ToInt32(Session["AP"]);
            consumoApCondominioAnual(anoBaseDefault);



        }

       

        public void consumoApCondominioAnual(int yearbase)
        {

          
            List<int> arrayApartamento = new List<int>();
            ArrayList meses = new ArrayList();
            foreach (var item in oReciboBLL.graficosConsumoAguaIndividual(yearbase, bloco, apto))
            {
                meses.Add(item.fechamentoAtual);
                arrayApartamento.Add(Convert.ToInt32(item.consumoMesM3));
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            chartDataSeries = jss.Serialize(arrayApartamento);
            chartDataCategory = jss.Serialize(meses);
            anobaseSerializado = jss.Serialize(yearbase.ToString());
            blocoSerial = jss.Serialize(bloco);
            aptoSerial = jss.Serialize(apto);

           

         
        //    // Declare the HighCharts object   
        //    DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
        //   .InitChart(new DotNet.Highcharts.Options.Chart { DefaultSeriesType = ChartTypes.Column })
        //         .SetTitle(new DotNet.Highcharts.Options.Title
        //{
        //    Text = "Consumo Mensal de água - Ano Base " + yearbase,
        //    X = -20
        //})
        //.SetSubtitle(new DotNet.Highcharts.Options.Subtitle
        //{
        //    Text = "Consumo minímo 10 M³ por apartamento",
        //    X = -20
        //})
        //.SetXAxis(new DotNet.Highcharts.Options.XAxis
        //{

        //    Categories =  chartData
         

        //})
        //.SetSeries(new DotNet.Highcharts.Options.Series
        //    {
        //        Name = "Consumo Mensal de Água - Bloco: " + bloco + " Apartamento: " + apto,
        //        Data = new Data(arrayApartamento.ToArray())
        //    });
        
      
    //ltrChart1.Text = chart.ToHtmlString(); // Let's visualize the chart into the webform.
        
            }
            
               // Let's visualize the chart into the webform.
 





            ////----------Consumo Geral Condominio X Apartamentos X Área de comum -------------------///
            ////--------------------------------------------------------------------////

            //ArrayList arrayApartamento = new ArrayList();
            //ArrayList meses = new ArrayList();

            //foreach (var item in oReciboBLL.graficosConsumoAguaIndividual(yearbase, bloco, apto))
            //{
            //    meses.Add(item.fechamentoAtual);
            //    arrayApartamento.Add(item.consumoMesM3);
            //}


          


            ////Title configuration
            //hcConsumoGeral.Title = new Title("Soma dos Excedentes Apartamentos - Ano Base: " + yearbase);
            //hcConsumoGeral.SubTitle = new SubTitle("Consumo > 10 M³");
            ////Defining Axis
            //hcConsumoGeral.YAxis.Add(new YAxisItem { title = new Title("Consumo em M³ - Minimo 2400 M³ ") });

            //hcConsumoGeral.XAxis.Add(new XAxisItem { categories = meses.ToArray() });
            //hcConsumoGeral.Width = 620;

            ////data    
            //var seriesExcedente = new Collection<Serie>();
            //hcConsumoGeral.ToolTip = "Valor em M³";


            //seriesExcedente.Add(new Serie { name = "Soma do consumo do Excedente (M³) - Apartamentos", data = arrayApartamento.ToArray(), });

            ////configuring Visual  
            //hcConsumoGeral.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#3299CC", borderRadius = 4 };

            ////bind    
            //hcConsumoGeral.DataSource = seriesExcedente;
            //hcConsumoGeral.DataBind();


        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsumoIndividual.aspx");
        }

    }
}