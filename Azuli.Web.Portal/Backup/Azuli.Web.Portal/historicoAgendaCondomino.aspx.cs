using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Azuli.Web.Portal
{
    public partial class historicoAgendaCondomino : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        DateTime data = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                    preencheMeses();

                    preencheAno();
                }
            }



        }
        public void preencheMeses()
        {
            for (int ano = 1; ano <= 12; ano++)
            {
                drpMeses.Items.Add(ano.ToString());

            }
            drpMeses.SelectedValue = data.Month.ToString();
        }

        public void preencheAno()
        {

            for (int ano = data.Year - 4; ano <= data.Year + 1; ano++)
            {
                drpAno.Items.Add(ano.ToString());

            }
            drpAno.SelectedValue = data.Year.ToString();
        }

    }
}