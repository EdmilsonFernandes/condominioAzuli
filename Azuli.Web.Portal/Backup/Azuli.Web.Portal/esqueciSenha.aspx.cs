using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace Azuli.Web.Portal
{
    public partial class esqueciSenha : Util.Base
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblBloco.Text = Session["Bloco"].ToString();
                lblAp.Text = Session["AP"].ToString();
            }

        }

      
        protected void btnEsqueci_Click(object sender, EventArgs e)
        {
            string vMail = string.Empty;


            
            
            Regex rg= new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            
            if (rg.IsMatch(txtEm.Text))
            {



                try
                {
                    Util.SendMail oEnviaEmail = new Util.SendMail();

                    ProprietarioBLL oProprietario = new ProprietarioBLL();
                    ProprietarioModel oProprietarioModel = new ProprietarioModel();
                    StringBuilder sbMsg = new StringBuilder();

                    oProprietarioModel.ap = new ApartamentoModel();

                    oProprietarioModel.ap.apartamento = (int)Session["AP"];
                    oProprietarioModel.ap.bloco = (int)Session["Bloco"];
                    oProprietarioModel.email = txtEm.Text;

                    foreach (var item in oProprietario.recuperaSenhaMorador(oProprietarioModel))
                    {
                        vMail = item.senha;
                    }

                    if (vMail != string.Empty)
                    {
                        oEnviaEmail.enviaSenha("A senha para o apartamento" + oProprietarioModel.ap.apartamento + " do bloco " + oProprietarioModel.ap.bloco + " é " + vMail + Environment.NewLine + " www.condominioazuli.somee.com ", oProprietarioModel.ap.apartamento.ToString(), oProprietarioModel.email, 1);
                        
                        sbMsg.Append("<b>A sua senha foi enviada para o e-mail informado!</b>");

                    }
                    else
                    {
                       
                        sbMsg.Append("<b>E-mail não cadastrado em nossa base de dados / Ou e-mail não corresponde com o Bloco e apartamento cadastrado</b>");
                    }

                    lblMsg.Visible = true;
                    lblMsg.Text = sbMsg.ToString();

                }

                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "E-mail inválido ou não cadastrado";
            }

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginAzulli.aspx");
        }

      
    }
}