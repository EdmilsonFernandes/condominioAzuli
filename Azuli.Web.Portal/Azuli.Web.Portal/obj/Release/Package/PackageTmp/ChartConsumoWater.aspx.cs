using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Collections;
using Highchart.Core;
using Highchart.Core.Data.Chart;
using Highchart.Core.PlotOptions;


namespace Azuli.Web.Portal
{
    public partial class ChartConsumoWater : System.Web.UI.Page
    {

        int anoBaseDefault = DateTime.Now.Year;
        Util.Util oUtil = new Util.Util();
        ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
        listaSegundaViaAgua oListReciboModel = new listaSegundaViaAgua();
        DateTime data = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                oUtil.validateSessionAdmin();
                anoBaseDefault = Convert.ToInt32(Session["yearBase"]);
                consumoApCondominioAnual(anoBaseDefault);
             

            }
        }


       
        public void consumoApCondominioAnual(int yearbase)
        {


                //----------Consumo Geral Condominio X Apartamentos X Área de comum -------------------///
                //--------------------------------------------------------------------////



                ArrayList arrayCondominio = new ArrayList();
                ArrayList arrayApartamento = new ArrayList();
                ArrayList arrayAreaComum = new ArrayList();
                ArrayList meses = new ArrayList();

                foreach (var item in oReciboBLL.graficosConsumoAgua(yearbase))
                {

                    arrayCondominio.Add(item.consumoM3pagoCondominio);
                    meses.Add(item.fechamentoAtual);
                    arrayApartamento.Add(item.mes);
                    if ( item.consumoM3pagoCondominio < item.mes )
                    {
                        item.mes = item.consumoM3pagoCondominio;
                    }
                    arrayAreaComum.Add(item.consumoM3pagoCondominio - item.mes);

                }

                //Title configuration
                hcConsumoGeral.Title = new Title("Condominio X Apartamentos - Ano Base: " + yearbase);
                hcConsumoGeral.SubTitle = new SubTitle("Consumo em M³ - Minimo 2400 M³");
                //Defining Axis
                hcConsumoGeral.YAxis.Add(new YAxisItem { title = new Title(" Consumo em M³ - Minimo 2400 M³") });

                hcConsumoGeral.XAxis.Add(new XAxisItem { categories = meses.ToArray() });
                hcConsumoGeral.Width = 620;
                //data    
                var series = new Collection<Serie>();
                hcConsumoGeral.ToolTip = "M³";

                series.Add(new Serie { name = "Condominio", data = arrayCondominio.ToArray(), });
                series.Add(new Serie { name = "Apartamentos", data = arrayApartamento.ToArray() });
                series.Add(new Serie { name = "Área Comum", data = arrayAreaComum.ToArray() });

                //configuring Visual     
                hcConsumoGeral.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#dedede", borderRadius = 4 };

                //bind    
                hcConsumoGeral.DataSource = series;
                hcConsumoGeral.DataBind();

                //-------------------------------------------------------------------------------------------------------------------------//

                //-----------Total dos Excedentes dos Apartamentos a 10 m³ por mes e ano----------------------//
                //--------------------------------------------------------------------------------------------//


                ArrayList arrayExcedente = new ArrayList();
                ArrayList mesesExcedente = new ArrayList();

                foreach (var item in oReciboBLL.graficoExcedentePorApartamento(yearbase))
                {

                    arrayExcedente.Add(item.excedenteM3Rateio);
                    mesesExcedente.Add(item.fechamentoAtual);


                }

                //Title configuration
                hcExcedentes.Title = new Title("Soma dos Excedentes Apartamentos - Ano Base: " + yearbase);
                hcExcedentes.SubTitle = new SubTitle("Consumo > 10 M³");
                //Defining Axis
                hcExcedentes.YAxis.Add(new YAxisItem { title = new Title("Consumo em M³ - Minimo 2400 M³ ") });

                hcExcedentes.XAxis.Add(new XAxisItem { categories = mesesExcedente.ToArray() });
                hcExcedentes.Width = 620;

                //data    
                var seriesExcedente = new Collection<Serie>();
                hcExcedentes.ToolTip = "Valor em M³";


                seriesExcedente.Add(new Serie { name = "Soma do consumo do Excedente (M³) - Apartamentos", data = arrayExcedente.ToArray(), });

                //configuring Visual     
                hcExcedentes.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#3299CC", borderRadius = 4 };

                //bind    
                hcExcedentes.DataSource = seriesExcedente;
                hcExcedentes.DataBind();

                //*-----------------------------------------------------------------------------------------------------------------*/



                //---------------------------------------------------------------------------------------------//

                //-----------Consumo de Água por Blocos ------------------------------------------------------//
                //--------------------------------------------------------------------------------------------//



                ArrayList arrayConsumoBloco1 = new ArrayList();
                ArrayList arrayConsumoBloco2 = new ArrayList();
                ArrayList arrayConsumoBloco3 = new ArrayList();
                ArrayList arrayConsumoBloco4 = new ArrayList();
                ArrayList arrayConsumoBloco5 = new ArrayList();
                ArrayList arrayConsumoBloco6 = new ArrayList();

                ArrayList arrayBlocos = new ArrayList();
                ArrayList mesesBloco = new ArrayList();

                var bloco1 =
                    from listBl01 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl01.bloco == "1"
                    select listBl01.somaConsumoByBloco;

                var bloco2 =
                    from listBl02 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl02.bloco == "2"
                    select listBl02.somaConsumoByBloco;

                var bloco3 =
                    from listBl03 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl03.bloco == "3"
                    select listBl03.somaConsumoByBloco;

                var bloco4 =
                    from listBl04 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl04.bloco == "4"
                    select listBl04.somaConsumoByBloco;

                var bloco5 =
                    from listBl05 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl05.bloco == "5"
                    select listBl05.somaConsumoByBloco;

                var bloco6 =
                    from listBl06 in oReciboBLL.graficoConsumoPorBloco(yearbase)
                    where listBl06.bloco == "6"
                    select listBl06.somaConsumoByBloco;



                foreach (var item in bloco1)
                {
                    arrayConsumoBloco1.Add(item);
                }

                foreach (var item in bloco2)
                {
                    arrayConsumoBloco2.Add(item);
                }

                foreach (var item in bloco3)
                {
                    arrayConsumoBloco3.Add(item);
                }

                foreach (var item in bloco4)
                {
                    arrayConsumoBloco4.Add(item);
                }

                foreach (var item in bloco5)
                {
                    arrayConsumoBloco5.Add(item);
                }

                foreach (var item in bloco6)
                {
                    arrayConsumoBloco6.Add(item);
                }


                var mesDistinct = (from c in oReciboBLL.graficoConsumoPorBloco(yearbase)
                                   orderby c.mes descending
                                   select new {  c.fechamentoAtual }).Distinct();

                foreach (var item in mesDistinct)
                {

                         mesesBloco.Add(item.fechamentoAtual);

                }
                //mesesBloco.Add(item.fechamentoAtual);
                //arrayApartamento.Add(item.mes);

                //Title configuration
                hcConsumoPorBloco.Title = new Title("Consumo Por Blocos - Ano Base: " + yearbase);
                hcConsumoPorBloco.SubTitle = new SubTitle("Consumo (M³)");
                //Defining Axis
                hcConsumoPorBloco.YAxis.Add(new YAxisItem { title = new Title("Consumo em M³ - Minimo 2400 M³") });

                hcConsumoPorBloco.XAxis.Add(new XAxisItem { categories = mesesBloco.ToArray() });
                hcConsumoPorBloco.Width = 620;
                //data    
                var seriesBloco = new Collection<Serie>();
                hcConsumoPorBloco.ToolTip = "M³";


                seriesBloco.Add(new Serie { name = "Bloco 01", data = arrayConsumoBloco1.ToArray(), });
                seriesBloco.Add(new Serie { name = "Bloco 02", data = arrayConsumoBloco2.ToArray(), });
                seriesBloco.Add(new Serie { name = "Bloco 03", data = arrayConsumoBloco3.ToArray(), });
                seriesBloco.Add(new Serie { name = "Bloco 04", data = arrayConsumoBloco4.ToArray(), });
                seriesBloco.Add(new Serie { name = "Bloco 05", data = arrayConsumoBloco5.ToArray(), });
                seriesBloco.Add(new Serie { name = "Bloco 06", data = arrayConsumoBloco6.ToArray(), });


                //configuring Visual     
                hcConsumoPorBloco.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#dedede", borderRadius = 2 };

                //bind    
                hcConsumoPorBloco.DataSource = seriesBloco;
                hcConsumoPorBloco.DataBind();




                //-------------------------------------------------------------------------------------------------------------------------//

                //-----------Total de Apartamentos com o consumo fora da normalidade----------------------//
                //--------------------------------------------------------------------------------------------//


                ArrayList arrayAnormalidade = new ArrayList();
                ArrayList mesesAnormalidade = new ArrayList();

                foreach (var item in oReciboBLL.graficoQuantidadeApAnormal(yearbase))
                {

                    arrayAnormalidade.Add(item.qtdAnormalidade);
                    mesesAnormalidade.Add(item.fechamentoAtual);


                }

                //Title configuration
                hcAnormalidade.Title = new Title("Quantidades de Apartamentos fora da normalidade -  Ano Base: " + yearbase);
                hcAnormalidade.SubTitle = new SubTitle("Consumo (M³) Anormal ↑ ");
                //Defining Axis
                hcAnormalidade.YAxis.Add(new YAxisItem { title = new Title("Consumo em M³ - Minimo 2400 M³ ") });

                hcAnormalidade.XAxis.Add(new XAxisItem { categories = mesesAnormalidade.ToArray() });
                hcAnormalidade.Width = 620;

                //data    
                var seriesAnormalidade = new Collection<Serie>();
                hcAnormalidade.ToolTip = "Valor em M³";


                seriesAnormalidade.Add(new Serie { name = "Quantidade de Apartamentos com consumo fora da sua normalidade ↑", data = arrayAnormalidade.ToArray(), });

                //configuring Visual     
                hcAnormalidade.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#3299CC", borderRadius = 4 };

                //bind    
                hcAnormalidade.DataSource = seriesAnormalidade;
                hcAnormalidade.DataBind();

                //*-----------------------------------------------------------------------------------------------------------------*/

          
          



        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuxliaryChart1.aspx");
        }

        

       
    }
}