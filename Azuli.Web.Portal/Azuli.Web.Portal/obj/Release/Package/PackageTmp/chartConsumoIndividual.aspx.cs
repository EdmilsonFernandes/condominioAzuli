using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Highchart.Core.Data.Chart;
using System.Collections.ObjectModel;
using Highchart.Core;
using System.Collections;
using Azuli.Web.Business;
using Azuli.Web.Model;

namespace Azuli.Web.Portal
{
    public partial class chartConsumoIndividual : System.Web.UI.Page
    {

        int anoBaseDefault = DateTime.Now.Year;
        Util.Util oUtil = new Util.Util();
        ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
        listaSegundaViaAgua oListReciboModel = new listaSegundaViaAgua();
        DateTime data = DateTime.Now;
        int bloco = 0;
        int apto = 0;
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

            //----------Consumo Geral Condominio X Apartamentos X Área de comum -------------------///
            //--------------------------------------------------------------------////

            ArrayList arrayApartamento = new ArrayList();
            ArrayList meses = new ArrayList();

            foreach (var item in oReciboBLL.graficosConsumoAguaIndividual(yearbase,bloco,apto))
            {
                meses.Add(item.fechamentoAtual);
                arrayApartamento.Add(item.consumoMesM3);
            }

            //Title configuration
            hcConsumoGeral.Title = new Title("Seu consumo Individual - Ano Base: " + yearbase);
            hcConsumoGeral.SubTitle = new SubTitle("Consumo em M³ - Minimo 10 M³");
            //Defining Axis
            hcConsumoGeral.YAxis.Add(new YAxisItem { title = new Title(" Consumo em M³ - Minimo 10 M³") });

            hcConsumoGeral.XAxis.Add(new XAxisItem { categories = meses.ToArray() });
            hcConsumoGeral.Width = 620;
            //data    
            var series = new Collection<Serie>();
            hcConsumoGeral.ToolTip = "M³";

            series.Add(new Serie { name = "Seu consumo Individual", data = arrayApartamento.ToArray(), });
          
            //configuring Visual     
            hcConsumoGeral.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsColumn { borderColor = "#dedede", borderRadius = 4 };

            //bind    
            hcConsumoGeral.DataSource = series;
            hcConsumoGeral.DataBind();

            //-------------------------------------------------------------------------------------------------------------------------//
        }
    }
}