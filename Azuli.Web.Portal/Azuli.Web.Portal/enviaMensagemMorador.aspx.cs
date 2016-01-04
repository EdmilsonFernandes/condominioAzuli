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
    public partial class enviaMensagemMorador : System.Web.UI.Page
    {

        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        MensagemMoradorBLL oMensagemBLL = new MensagemMoradorBLL();
        MensagemMoradorModel oMsgModel = new MensagemMoradorModel();
        Util.Util oUtil = new Util.Util();
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {
                    buscaMorador();
                   
                }
                else
                {
                    
                   
                }
            }
        }

        protected void drpMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscaMorador();
        }

        protected void drpBloco_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscaMorador();
        }

        public string buscaMorador()
        {

            string nomeMorador = "";

            if (drpBloco.SelectedItem.Value == "T")
            {
                drpMsg.SelectedIndex = -1;
                drpMsg.Visible = false;
                lblAp.Visible = false;
            }
            else
            {
             
                drpMsg.Visible = true;
                lblAp.Visible = true;
            }

            if (drpMsg.SelectedItem.Value != "T" && drpBloco.SelectedItem.Value != "T")
            {

                oAPmodel.apartamento = Convert.ToInt32(drpMsg.SelectedItem.Text);
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);

                if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count > 0)
                {

                    foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
                    {

                        lblMorador.Text = item.proprietario1.ToString();
                        nomeMorador = item.proprietario1.ToString();


                    }
                }
                else
                {
                    nomeMorador = "Não existe morador cadastrado!";
                    lblMorador.Text = "Não existe morador cadastrado!";
                }
            }
            else if (drpMsg.SelectedItem.Value == "T" && drpBloco.SelectedItem.Value != "T")
                {
                    lblMorador.Text = "";
                }
            else
            {
                nomeMorador = "Enviar para todos os moradores!!";
                lblMorador.Text = "Enviar para todos os moradores!!";
            }

            return nomeMorador; 
        }

        protected void btnMensagem_Click(object sender, EventArgs e)
        {
            if (drpBloco.SelectedItem.Value != "T" && drpMsg.SelectedItem.Value != "T")
            {

                oAPmodel.apartamento = Convert.ToInt32(drpMsg.SelectedItem.Text);
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);
                if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count > 0)
                {
                    ApartamentoModel oAp = new ApartamentoModel();
                    oMsgModel.ativo = "S";
                    oMsgModel.status = "NL";
                    oMsgModel.mensagem = txtDescription.Text;
                    oMsgModel.assunto = txtAssunto.Text;
                    oAp.apartamento = Convert.ToInt32(drpMsg.SelectedItem.Value);
                    oAp.bloco = Convert.ToInt32(drpBloco.SelectedItem.Value);
                    oMsgModel.deMsg = "Administrador do Condominio";
                    oMsgModel.todosMoradores = "";
                    oMsgModel.oAp = oAp;


                    try
                    {
                        oMensagemBLL.enviaMensagemMorador(oMsgModel);
                        lblMsg.Text = "Mensagem enviada com sucesso!!";
                        txtAssunto.Text = "";
                        txtDescription.Text = "";
                        lblMorador.Text = "";
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    lblMsg.Text = "Não existem morador cadastrado para o Bloco/Apartamento!";

                }

            }
           

            else if (drpBloco.SelectedItem.Value == "T" && drpMsg.SelectedItem.Value == "T")
            {
              
                    ApartamentoModel oAp = new ApartamentoModel();
                    oMsgModel.ativo = "S";
                    oMsgModel.status = "NL";
                    oMsgModel.mensagem = txtDescription.Text;
                    oMsgModel.assunto = txtAssunto.Text;
                    oAp.apartamento = 0;
                    oAp.bloco = 0;
                    oMsgModel.todosMoradores = "T";
                    oMsgModel.deMsg = "Administrador do Condominio";
                    oMsgModel.oAp = oAp;


                    try
                    {
                        oMensagemBLL.enviaMensagemMorador(oMsgModel);
                        lblMsg.Text = "Mensagem enviada com sucesso!!";
                        txtAssunto.Text = "";
                        txtDescription.Text = "";
                        lblMorador.Text = "";
                    }
                    catch (Exception)
                    {

                        throw;
                    }
              

            }

        }

       
    }
}