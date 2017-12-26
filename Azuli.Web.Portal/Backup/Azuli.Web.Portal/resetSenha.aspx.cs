using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Text;

namespace Azuli.Web.Portal
{
    public partial class resetSenha : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSession())
                {
                    lblMensagem.Visible = false;
                }
            }
        }

        protected void btnAlteraSenha_Click(object sender, EventArgs e)
        {


            try
            {


                if (txtNovaSenha.Text.Length == 4)
                {
                    ProprietarioBLL oProprietario = new ProprietarioBLL();
                    ProprietarioModel oProprietarioModel = new ProprietarioModel();

                    oProprietarioModel.ap = new ApartamentoModel();



                    if (txtNovaSenha.Text == txtRepitaNovaSenha.Text)
                    {

                        oProprietarioModel.ap.apartamento = (int)Session["AP"];
                        oProprietarioModel.ap.bloco = (int)Session["Bloco"];
                        oProprietarioModel.senha = txtNovaSenha.Text;

                        oProprietario.alteraSenha(oProprietarioModel);


                        StringBuilder sb = new StringBuilder();
                        sb.Append("<b>A sua senha foi alterada com sucesso! No próximo logon será necessário  usá-la!</b>");

                        lblMensagem.Visible = true;
                        lblMensagem.ForeColor = System.Drawing.Color.Green;
                        lblMensagem.Text = sb.ToString();


                    }
                    else
                    {
                        lblMensagem.Visible = true;
                        lblMensagem.ForeColor = System.Drawing.Color.Red;
                        lblMensagem.Text = "Senhas digitadas estão diferentes, favor verificar.";
                    }
                }
                else
                {
                    lblMensagem.Visible = true;
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    lblMensagem.Text = "Senha precisa ser de até 4 caracteres, por motivo de segurança";
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}