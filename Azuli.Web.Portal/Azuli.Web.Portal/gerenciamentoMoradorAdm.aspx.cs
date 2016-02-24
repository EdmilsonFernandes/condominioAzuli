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
using System.Text.RegularExpressions;

namespace Azuli.Web.Portal
{

    public partial class gerenciamentoMoradorAdm : Util.Base
    {


        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        listProprietario oListProprietario = new listProprietario();
        Util.Util oUtil = new Util.Util();
       
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {

                    hideControl();

                    dvGridAll.Visible = true;
                    grdGerenciamentoMoradores.DataSourceID = "SqlDataSourceGerenciamentoUser";
                    grdGerenciamentoMoradores.DataBind();

                    dvPesquisa.Visible = false;
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
            oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);
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

                        bool isEmail = Regex.IsMatch(oProprietarioModel.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (isEmail)
                        {

                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                        }
                        else
                        {
                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1,"residencialcampoazuli@gmail.com", status);
                        }

                        lblMsg.Text = "Cadastro efetuado com sucesso!! <br> <b> ";
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
            drpBloco.SelectedIndex = -1;
            txtCond01.Text = "";
            // txtCond02.Text = "";
            txtAP.Text = "";
            txtEmail.Text = "";
            lblPesquisa.Text = "";
            dvPesquisa.Visible = false;


        }


        protected void ibtCancel_Click(object sender, ImageClickEventArgs e)
        {
            hideControl();
            dvGridAll.Visible = true;
            grdGerenciamentoMoradores.DataSourceID = "SqlDataSourceGerenciamentoUser";
            grdGerenciamentoMoradores.DataBind();

            dvPesquisa.Visible = false;

        }

        protected void ibtSearch_Click(object sender, ImageClickEventArgs e)
        {

            dvPesquisa.Visible = true;
            lblPesquisa.Text = "";
            dvGridAll.Visible = false;

            if (txtCond01.Text != string.Empty)
            {

                lblPesquisa.Text = txtCond01.Text;
                oListProprietario = oProprietario.PesquisaMorador(Util.Util.statusPesquisa.N.ToString(), txtCond01.Text.Trim(), oAPmodel);
                preencheGridViewByPesquisa(oListProprietario);

            }
            else if (drpBloco.SelectedItem.Text != "0" && txtAP.Text == string.Empty)
            {

                lblPesquisa.Text = drpBloco.SelectedItem.Text;
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);

                oListProprietario = oProprietario.PesquisaMorador(Util.Util.statusPesquisa.B.ToString(), drpBloco.SelectedItem.Text, oAPmodel);
                preencheGridViewByPesquisa(oListProprietario);

            }
            else if (drpBloco.SelectedItem.Text == string.Empty && txtAP.Text != string.Empty)
            {

                lblPesquisa.Text = txtAP.Text;
                oAPmodel.apartamento = Convert.ToInt32(txtAP.Text);
                oListProprietario = oProprietario.PesquisaMorador(Util.Util.statusPesquisa.A.ToString(),"", oAPmodel);
                preencheGridViewByPesquisa(oListProprietario);

            }
            else if (drpBloco.SelectedItem.Text != string.Empty && txtAP.Text != string.Empty)
            {
                lblPesquisa.Text = drpBloco.SelectedItem.Text + " + " + txtAP.Text;

                oAPmodel.apartamento = Convert.ToInt32(txtAP.Text);
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text); 
                oListProprietario = oProprietario.PesquisaMorador(Util.Util.statusPesquisa.BA.ToString(), "", oAPmodel);

                preencheGridViewByPesquisa(oListProprietario);

            }




        }

        public void preencheGridViewByPesquisa(listProprietario oList)
        {
            
            grdPesquisa.DataSource = oList;
            grdPesquisa.DataBind();
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            dvGridAll.Visible = true;
            grdGerenciamentoMoradores.DataSourceID = "SqlDataSourceGerenciamentoUser";
            grdGerenciamentoMoradores.DataBind();

            dvPesquisa.Visible = false;
        }
    }
}