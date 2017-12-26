using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Text;

namespace Azuli.Web.Portal
{
    public partial class detalheMensagemMorador : Util.Base
    {
        Util.Util oUtil = new Util.Util();
        MensagemMoradorModel oMensagemModel = new MensagemMoradorModel();
        MensagemMoradorBLL oMensagemBLL = new MensagemMoradorBLL();
        ApartamentoModel oApModel = new ApartamentoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {

                    listaMensagemMoradorBLL();
                    divGeralMsg.Visible = false;
                    btnOk.Visible = false;
                    dvAvancada.Visible = false;
                    DvPesquisa.Visible = false;
                }
            }

        }



        public void listaMensagemMoradorBLL()
        {

            try
            {
                dvCaixa.Visible = true;
                dvNaoLida.Visible = true;
                oApModel.apartamento = Convert.ToInt32(Session["AP"]);
                oApModel.bloco = Convert.ToInt32(Session["Bloco"]);
                oMensagemModel.oAp = oApModel;
                oMensagemModel.status = drpStatusMsg.SelectedItem.Value;

                if (drpMsgStatus.SelectedItem.Value == "1")
                {
                    lblLidNL.Text = "Mensagens Não Lidas";
                }
                else if (drpMsgStatus.SelectedItem.Value == "0")
                {
                    lblLidNL.Text = "Mensagens já Lidas";
                }
                grdMsg.DataSource =  oMensagemBLL.listaMensagemMorador(oMensagemModel);
                grdMsg.DataBind();

                //GridView1.DataSource = oMensagemBLL.listaMensagemMorador(oMensagemModel);
                //GridView1.DataBind();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        protected void grdMsg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigoMensagem = 0;

            int index = int.Parse((string)e.CommandArgument);
            codigoMensagem = Convert.ToInt32(grdMsg.DataKeys[index]["codigoMsg"]);
            oMensagemModel.codigoMsg = codigoMensagem;

            try
            {
               
               
                


                foreach (var item in   oMensagemBLL.listaMensagemMoradorByID(oMensagemModel))
                {
                    lblDe.Text = item.deMsg;
                    lblAssunto.Text = item.assunto;
                    lblData.Text = item.data_inicio.ToString() ;
                    lblMsg.Text = item.mensagem;
                    
                }

                atualizaMensagemParaLida(oMensagemModel);
                dvNaoLida.Visible = false;
                grdMsg.Visible = false;
                divGeralMsg.Visible = true;
               
                btnOk.Visible = true;
              
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            listaMensagemMoradorBLL();
            divGeralMsg.Visible = false;
            dvCaixa.Visible = true;
            grdMsg.Visible = true;
            drpStatusMsg.Visible = true;
            lblConsultaAno.Visible = true;
            dvAvancada.Visible = false;
            btnOk.Visible = false;
            DvPesquisa.Visible = false;
        }

        protected void drpStatusMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaMensagemMoradorBLL();
        }


        public void atualizaMensagemParaLida(MensagemMoradorModel codigoMsg)
        {
            oMensagemBLL.atualizaMSG(codigoMsg);
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string dataTxt = txtData.Text;
            dvAvancada.Visible = true;
            StringBuilder montaMsg = new StringBuilder();

            oApModel.apartamento = Convert.ToInt32(Session["AP"]);
            oApModel.bloco = Convert.ToInt32(Session["Bloco"]);
            oMensagemModel.oAp = oApModel;
             
            if (txtAssunto.Text == string.Empty)
                txtAssunto.Text = "";
            
            oMensagemModel.assunto = txtAssunto.Text;
            oMensagemModel.status =  drpMsgStatus.SelectedValue;

            if (dataTxt == string.Empty)
                dataTxt = "01-01-1753";

            oMensagemModel.data_inicio = DateTime.Parse(dataTxt);

            if (txtMsg.Text == string.Empty)
                txtMsg.Text = "";
            oMensagemModel.mensagem = txtMsg.Text;

            try
            {
                dvCaixa.Visible = false ;
                dvNaoLida.Visible = false;
                DvPesquisa.Visible = true;

                if (txtAssunto.Text != "")
                    montaMsg.Append(txtAssunto.Text + " e ");
                if (txtData.Text != "")
                    montaMsg.Append(txtData.Text + " e ");
                if (txtMsg.Text != "")
                    montaMsg.Append(txtMsg.Text +  " e ");

                   
                montaMsg.Append(" Mensagens " + drpMsgStatus.SelectedItem.Text);

                lblCondintion.Text = montaMsg.ToString();
                grdPesquisa.Visible = true;
                grdPesquisa.DataSource = oMensagemBLL.pesquisaMensagemMorador(oMensagemModel);
                grdPesquisa.DataBind();
            }
            catch (Exception err)
            {

                throw err;
            }
                
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAssunto.Text = "";
            txtData.Text = "";
            txtMsg.Text = "";
            dvNaoLida.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        { 
            listaMensagemMoradorBLL();
            dvCaixa.Visible = true;
            dvNaoLida.Visible = true;
            dvAvancada.Visible = false;
            divGeralMsg.Visible = false;
            DvPesquisa.Visible = false;
           
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            dvNaoLida.Visible = false;
            dvCaixa.Visible = false;
            dvAvancada.Visible = true;
            
        }

        protected void grdPesquisa_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int codigoMensagem = 0;

            int index = int.Parse((string)e.CommandArgument);
            codigoMensagem = Convert.ToInt32(grdPesquisa.DataKeys[index]["codigoMsg"]);
            oMensagemModel.codigoMsg = codigoMensagem;

            try
            {





                foreach (var item in oMensagemBLL.listaMensagemMoradorByID(oMensagemModel))
                {
                    lblDe.Text = item.deMsg;
                    lblAssunto.Text = item.assunto;
                    lblData.Text = item.data_inicio.ToString();
                    lblMsg.Text = item.mensagem;

                }

                atualizaMensagemParaLida(oMensagemModel);
                DvPesquisa.Visible = false;
                dvNaoLida.Visible = false;
                grdPesquisa.Visible = false;
                divGeralMsg.Visible = true;

                btnOk.Visible = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}