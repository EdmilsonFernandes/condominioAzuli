using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Portal.Util;

namespace Azuli.Web.Portal
{
    public partial class contato : System.Web.UI.Page
    {

        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblDescBloco.Text = "0"+Session["Bloco"].ToString();
                    lblDescApartamento.Text = Session["AP"].ToString();
                    lblMsg.Visible = false;
                }
                
            }

        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            MensagemMoradorBLL oMensagemMorador = new MensagemMoradorBLL();

            try
            {
                oMensagemMorador.cadastraContato(drpListSubject.SelectedItem.Text, txtDescription.Text, Convert.ToInt32(Session["Bloco"]), Convert.ToInt32(Session["AP"]));
                lblMsg.Visible = true;
                lblMsg.Text = "Obrigado por entrar em contato! <br> <br> <font size='1' color='#948c8c'>Em breve entraremos em contato com você via sistema para sanar sua dúvida e/ou agradecermos o seu comentário ou sugestões! </font> ";
                txtDescription.Text = "";
                drpListSubject.SelectedIndex = -1;

                Util.SendMail oEmail = new SendMail();
                oEmail.enviaSenha("Assunto:" + drpListSubject.SelectedItem.Text + "<br> Descrição: " + txtDescription.Text + "<br> Bloco:  " + Session["Bloco"].ToString() + " <br> Apto: " + Session["AP"].ToString() , "Fale Conosco Azuli", "edmls@ig.com.br", 0);
                
            }
            catch (Exception er)
            {
                
                throw er;
            }
            
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            drpListSubject.SelectedIndex = -1;
            txtDescription.Text = "";

            lblMsg.Visible = false;
        }
    }
}