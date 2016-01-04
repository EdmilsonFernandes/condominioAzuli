using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;

namespace Azuli.Web.Portal
{
    public partial class CadastraEncomendas : System.Web.UI.Page
    {
        Encomendas oEncomendas = new Encomendas();
        EncomendaBLL oEncomendasBLL = new EncomendaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            oEncomendas.Bloco = int.Parse(txtBloco.Text);
            oEncomendas.Apartamento = int.Parse(txtApartamento.Text);
            //oEncomendas.EncDtaRec = DateTime.Parse(txtDataRecebimento);
            oEncomendas.EncDesc = txtDescricao.Text;
            oEncomendas.EncEntr = txtEntregue.Text;
            oEncomendas.EncQuemPegou = txtQuemPegou.Text;

            oEncomendasBLL.cadastraEncomendas(oEncomendas);

        }
    }
}