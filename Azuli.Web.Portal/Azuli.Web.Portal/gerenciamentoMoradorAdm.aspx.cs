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
using System.Data;

namespace Azuli.Web.Portal
{

    public partial class gerenciamentoMoradorAdm : Util.Base
    {


        ProprietarioBLL oProprietario = new ProprietarioBLL();
        public static ProprietarioModel oProprietarioModel = new ProprietarioModel();
        public static ApartamentoModel oAPmodel = new ApartamentoModel();
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
                oProprietarioModel.telefone = txtTelefone.Text;

                
                oProprietarioModel.proprietarioImovel = lstRadioButton.SelectedItem.Value;

                try
                {
                    int count = oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

                    if (count > 0)
                    {

                        lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;

                    }

                    else
                    {

                        
                        string msgCredencial = "";
                        msgCredencial = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " <b> <br>" + " Bloco:  " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><hr> acesse: http://condominiospazioazuli.somee.com/";

                        SendMail enviaEmail = new SendMail();

                        bool isEmail = Regex.IsMatch(oProprietarioModel.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (isEmail)
                        {

//                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                        }
                        else
                        {
                           // enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1,"residencialcampoazuli@gmail.com", status);
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

        public void preencheModelDepedente()
        {
           
           
         
            if (txtboxDepedente1.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtboxDepedente1.Text == string.Empty ? null : txtboxDepedente1.Text;
                oDepedentes.parentesco = drpdownParentesco1.SelectedItem.Text == string.Empty ? null : drpdownParentesco1.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDatanascimento1.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
              
                
            }
             if (txtNomeDepedente2.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtNomeDepedente2.Text == string.Empty ? null : txtNomeDepedente2.Text;
                oDepedentes.parentesco = drpdownParentesco2.SelectedItem.Text == string.Empty ? null : drpdownParentesco2.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDatanascimento2.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
            }
             if (txtNomeDepedente3.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtNomeDepedente3.Text == string.Empty ? null : txtNomeDepedente3.Text;
                oDepedentes.parentesco = drpdownParentesco3.SelectedItem.Text == string.Empty ? null : drpdownParentesco3.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDataascimento3.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
            }
             if (txtNomeDepedente4.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtNomeDepedente4.Text == string.Empty ? null :txtNomeDepedente4.Text;
                oDepedentes.parentesco = drpdownParentesco4.SelectedItem.Text == string.Empty ? null : drpdownParentesco4.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDatanascimento4.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
            }
             if (txtNomeDepedente5.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtNomeDepedente5.Text == string.Empty ? null : txtNomeDepedente5.Text;
                oDepedentes.parentesco = drpdownParentesco5.SelectedItem.Text == string.Empty ? null : drpdownParentesco5.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDatanascimento5.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
            }
             if (txtNomeDepedente6.Text != string.Empty)
            {
                Depedentes oDepedentes = new Depedentes();
                oDepedentes.nomeDepedente = txtNomeDepedente6.Text == string.Empty ? null : txtNomeDepedente6.Text;
                oDepedentes.parentesco = drpdownParentesco6.SelectedItem.Text == string.Empty ? null : drpdownParentesco6.SelectedItem.Text;
                oDepedentes.nascimentoDepedente = txtDatanascimento6.Text;
                oProprietarioModel.dependentes.Add(oDepedentes);
            }
       
        }

        public void preencheModelEmpregados()
        {
            

            if (txtBoxNomeEmpregado.Text != string.Empty)
            {
                Empregados oEmpregados = new Empregados();
                oEmpregados.nomeEmpregado = txtBoxNomeEmpregado.Text;
                oEmpregados.rgEmpregado = txtBoxRG.Text;
                oProprietarioModel.empregados.Add(oEmpregados);
            }

            if (txtBoxNomeEmpregado1.Text != string.Empty)
            {
                Empregados oEmpregados = new Empregados();
                oEmpregados.nomeEmpregado = txtBoxNomeEmpregado1.Text;
                oEmpregados.rgEmpregado = TextBoxRG1.Text;
            }
        }

        public void preencheModelTransporte()
        {


            if (TextBoxMarcaModelo1.Text != string.Empty)
            {
                Transporte oTransporte = new Transporte();
                oTransporte.marcaModelo = TextBoxMarcaModelo1.Text;
                oTransporte.cor = TextBoxCor1.Text;
                oTransporte.placaCarro = TextBoxPlaca1.Text;
                oProprietarioModel.transporte.Add(oTransporte);
            }

            if (TextBoxMarcaModelo2.Text != string.Empty)
            {
                Transporte oTransporte = new Transporte();
                oTransporte.marcaModelo = TextBoxMarcaModelo2.Text;
                oTransporte.cor = TextBoxCor2.Text;
                oTransporte.placaCarro = TextBoxPlaca2.Text;
                oProprietarioModel.transporte.Add(oTransporte);
            }
            if (TextBoxMarcaModelo3.Text != string.Empty)
            {
                Transporte oTransporte = new Transporte();
                oTransporte.marcaModelo = TextBoxMarcaModelo3.Text;
                oTransporte.cor = TextBoxCor3.Text;
                oTransporte.placaCarro = TextBoxPlaca3.Text;
                oProprietarioModel.transporte.Add(oTransporte);
            }
                
        }

        public void preencheModelEmergencia()
        {

            if (TextBoxNomeEmergencia.Text != string.Empty)
            {
                Emergencia oEmergencia = new Emergencia();
                oEmergencia.nomeContatoEmergencia = TextBoxNomeEmergencia.Text;
                oEmergencia.nomeParentescoEmergencia = txtBoxParentescoEmergencia.Text;
                oEmergencia.contato = textboxContatoEmergencia.Text;
                oProprietarioModel.emergencia = oEmergencia;
            }
        }

        public void preencheModelAnimais()
        {

            if (DropDownListQuantdAnimal.SelectedItem.Value != "0")
            {
                Animais oAnimal = new Animais();
                oAnimal.quantidadeAnimais = Convert.ToInt32(DropDownListQuantdAnimal.SelectedItem.Value);
                oAnimal.especies = TextBoxEspecieAnimal.Text;
                oProprietarioModel.animais = oAnimal;
               
            }
        }

        public void preencheModelImobiliaria()
        {

            if (TextBoxEmpresaImobiliaria.Text != string.Empty)
            {
                Imobiliaria oImobiliaria = new Imobiliaria();
                oImobiliaria.nomeImobiliaria = TextBoxEmpresaImobiliaria.Text;
                oImobiliaria.telefoneImobiliaria = TextBoxTelefoneImobiliaria.Text;
                oImobiliaria.Contato = TextBoxContatoImobiliaria.Text;
                oProprietarioModel.imobiliaria = oImobiliaria;
            }
        }
        public void cadastrarMoradorCompleto()
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
                oProprietarioModel.telefone = txtTelefone.Text;


                oProprietarioModel.proprietarioImovel = lstRadioButton.SelectedItem.Value;

                preencheModelDepedente();
                preencheModelEmpregados();
                preencheModelTransporte();
                preencheModelEmergencia();
                preencheModelAnimais();
                preencheModelImobiliaria();
                try
                {
                    int count = oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

                    int count1 = oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

                    if (count > 0)
                    {

                        lblMsg.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;

                    }

                    else
                    {

                        string msgCredencial = "";
                        msgCredencial = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " <b> <br>" + " Bloco:  " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><hr> acesse: http://condominiospazioazuli.somee.com/";

                        SendMail enviaEmail = new SendMail();

                        bool isEmail = Regex.IsMatch(oProprietarioModel.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (isEmail)
                        {

                            //                            enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                        }
                        else
                        {
                            // enviaEmail.enviaSenha(msgCredencial, oProprietarioModel.proprietario1,"residencialcampoazuli@gmail.com", status);
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
            txtTelefone.Text = "";
            lstRadioButton.SelectedItem.Enabled = true;
            dvDesenv.Visible = false;


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