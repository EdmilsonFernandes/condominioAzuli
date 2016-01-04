using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using Azuli.Web.Portal.Util;
using System.Text;

namespace Azuli.Web.Portal
{

    public partial class gerenciamentoMoradorAdm :Util.Base
    {


        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {


                }
                else
                {


                }
            }

        }

        protected void ibtAddSave_Click(object sender, ImageClickEventArgs e)
        {

            oProprietarioModel.ap = new ApartamentoModel();

            oAPmodel.apartamento = Convert.ToInt32(txtAP.Text);
            oAPmodel.bloco = Convert.ToInt32(txtBloco.Text);
            oProprietarioModel.ap = oAPmodel;


            if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count == 0)
            {

                oProprietarioModel.proprietario1 = txtCond01.Text;
                //oProprietarioModel.proprietario2 = txtCond02.Text;
                oProprietarioModel.email = txtEmail.Text;
                oProprietarioModel.senha = oUtil.GeraSenha();

                try
                {
                    int count = oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

                    if (count > 0)
                    {

                        lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;
                       
                    }

                    else
                    {
                        
                        int status = 0;
                        string msgCredencial = "";
                        msgCredencial = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " <b> <br>" + " Bloco:  " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><hr> acesse: http://www.condominioazuli.somee.com/";

                        SendMail enviaEmail = new SendMail();
                        if (oProprietarioModel.email != "Não tem no momento")
                        {
                           
                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                        }
                        if (oProprietarioModel.email == "")
                        {
                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                        }

                        lblMsg.Text = "Cadastro efetuado com sucesso!! <br> <b> "  ;
                        grdGerenciamentoMoradores.DataBind();
                        hideControl();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;
            }
          
           }

        public void hideControl()
        {
            txtBloco.Text = "";
            txtCond01.Text = "";
           // txtCond02.Text = "";
            txtAP.Text = "";
            txtEmail.Text = "";

        }


        protected void ibtCancel_Click(object sender, ImageClickEventArgs e)
        {
            hideControl();

        }

        protected void ibtSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}