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
    public partial class CadastrarEncomendas : System.Web.UI.Page
    {
        Util.Util oUtil = new Util.Util();
        Encomendas oEncomendas = new Encomendas();
        EncomendaBLL oEncomendasBLL = new EncomendaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblDescBloco.Text = Session["Bloco"].ToString();
                    lblDescApartamento.Text = Session["AP"].ToString();
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            //oEncomendas.Bloco = (int)Session["Bloco"];
            //oEncomendas.Apartamento = (int)Session["AP"]; 
            oEncomendas.Bloco = Convert.ToInt32(txtBloco.Text);
            oEncomendas.Apartamento = Convert.ToInt32(txtApto.Text);
            oEncomendas.EncDtaRec = DateTime.Now;
            oEncomendas.EncDesc = txtDescricao.Text;
            oEncomendasBLL.cadastraEncomendas(oEncomendas);

        }

    }
}