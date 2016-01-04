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


namespace Azuli.Web.Portal
{
    public partial class AuxliaryChart1 : System.Web.UI.Page
    {

        int anoBaseDefault = DateTime.Now.Year;
        Util.Util oUtil = new Util.Util();
        ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
        listaSegundaViaAgua oListReciboModel = new listaSegundaViaAgua();
        DateTime data = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["yearBase"] = "";
            
            if (!IsPostBack)
            {
                oUtil.validateSessionAdmin();
                preencheAno();

            }
        }

        public void preencheAno()
        {
            int anoAuxiliar = 2012; // irá receber o ano do banco.
            // Pegar o ano anterior de acordo com o ano do ultimo circular publicado, por enquanto está estático.
            for (int ano = data.Year; ano >= anoAuxiliar; ano--)
            {
                drpAno.Items.Add(ano.ToString());
            }

        }

        protected void BtnChart_Click(object sender, EventArgs e)
        {
            anoBaseDefault = Convert.ToInt32(drpAno.SelectedItem.Value);

            if (oReciboBLL.graficosConsumoAgua(anoBaseDefault).Count == 0)
            {

                string cleanMessage = "Não existem dados para este ano base " + anoBaseDefault;
                lblMsg.Text = cleanMessage;
               
            }

            else
            {
                Session["yearBase"] = anoBaseDefault;
                Response.Redirect("chartConsumoWater.aspx");

            }
        }
    }
}