using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;


namespace Azuli.Web.Portal
{
    public partial class ConfigurarValorReserva : System.Web.UI.Page
    {

        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {

            oUtil.validateSessionAdmin();
           
        }

        protected void btnAlteraSenha_Click(object sender, EventArgs e)
        {

            ConfiguraReserva oConfiguration = new ConfiguraReserva();
            ConfiguracaoReservaBLL oConfigBLL = new ConfiguracaoReservaBLL();

            oConfiguration.area = txtArea.Text;
            oConfiguration.valor = Convert.ToDouble(txtValor.Text);

            try
            {
                oConfigBLL.cadastraValorArea(oConfiguration);

                grdConfigArea.DataBind();

            }
            catch (Exception)
            {
                
                throw;
            }

        }


        }

}