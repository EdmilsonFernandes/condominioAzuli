using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using Azuli.Web.Portal.Util;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.IO;

namespace Azuli.Web.Portal
{
    public partial class CadastroCompletoMorador : System.Web.UI.Page
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
                    preencheApartamentos();
                    disableComponent();
                }
            }
        }

        public void preencheEnderecoPorCep()
        {

            using (br.com.correios.apps.AtendeClienteService ws = new br.com.correios.apps.AtendeClienteService())
            {
                try
                {
                    var enderecoCep = ws.consultaCEP(txtCep.Text.Replace("-", "").Trim());
                    txtEndereco.Text = enderecoCep.end;
                    txtCidade.Text = enderecoCep.cidade;
                    txtBairro.Text = enderecoCep.bairro;
                    lblCepNaoEcontrado.Visible = false;
                }
                catch 
                {
                    lblCepNaoEcontrado.Visible = true;
                    lblCepNaoEcontrado.Text = "CEP não encontrado";
                }
            }

            
          
        }

        public void disableComponent()
        {

            dvImobiliaria.Visible = false;
            tdAlugaGaragem.Visible = false;
        }
        public void preencheApartamentos()
        {
            int count = 0;
            for (int i = 101; i <= 508; i++)
            {
                if (count == 8)
                {
                    i += 92;
                    count = 0;
                }

                ddLApartamentos.Items.Add(i.ToString());
                if (tdAlugaGaragem.Visible == true)
                {
                    ddLApartamentosAluga.Items.Add(i.ToString());
                }
                count++;

            }
        }

        public void preencheApartamentosAluga()
        {
            int count = 0;
            for (int i = 101; i <= 508; i++)
            {
                if (count == 8)
                {
                    i += 92;
                    count = 0;
                }


                ddLApartamentosAluga.Items.Add(i.ToString());

                count++;

            }



        }


        public void geraNumeroGaragem()
        {
            if (!(ddLApartamentosAluga.SelectedValue == "-1" || drpBlocoAluga.SelectedValue == "-1"))
            {
                txtNumeroGaragem.Text = drpBlocoAluga.SelectedItem.Text + "" + ddLApartamentosAluga.SelectedItem.Text.Replace("0", "");
            }
        }



        #region Validar Dados do Morador Responsável

        public void cadastrarMoradorCompleto()
        {
            oProprietarioModel.ap = new ApartamentoModel();

            oAPmodel.apartamento = Convert.ToInt32(ddLApartamentos.SelectedValue);
            oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedItem.Text);
            oAPmodel.qtdGaragem = Convert.ToInt32(ddlQuantidadeGarage.SelectedValue);
            oProprietarioModel.ap = oAPmodel;


                oProprietarioModel.proprietario1 = txtCond01.Text;
                //oProprietarioModel.proprietario2 = txtCond02.Text;
                oProprietarioModel.email = txtEmail.Text;
                oProprietarioModel.senha = oUtil.GeraSenha();
                oProprietarioModel.telefone = txtTelefone.Text;
                oProprietarioModel.cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
                oProprietarioModel.rg = txtRg.Text;
                oProprietarioModel.endereco = txtEndereco.Text;
                oProprietarioModel.cepEndereco = txtCep.Text;
                oProprietarioModel.cidade = txtCidade.Text;
                oProprietarioModel.estadoCivil = lsrEstadoCivil.SelectedValue;
                oProprietarioModel.proprietarioImovel = lstRadioButtonTipo.SelectedItem.Value;
                oProprietarioModel.celular = txtCelular.Text;
                oProprietarioModel.bairro = txtBairro.Text;
                string garagemAluga = "Aluga garagem: ";

                if(chkAluga.Checked)
                {
                    oProprietarioModel.alugaGaragem = garagemAluga + "Sim" + " | Número da Garagem: " + txtNumeroGaragem.Text;   
                }
                else if (ChkNaoAluga.Checked)
                {
                    oProprietarioModel.alugaGaragem = garagemAluga + "Não";
                }
                oProprietarioModel.qtdBicicleta = Convert.ToInt32(drlQtdBicicleta.SelectedItem.Text);

                if (oProprietarioModel.qtdBicicleta > 0)
                {
                    oProprietarioModel.descricaoBike = chkBikePequena.Checked ? chkBikePequena.Text + ";" : "";
                    oProprietarioModel.descricaoBike += chkGrande.Checked ? chkGrande.Text + ";" : "";
                    oProprietarioModel.descricaoBike += CheckBikeMedia.Checked ? CheckBikeMedia.Text : "";
                }
                else
                {
                    oProprietarioModel.descricaoBike = "";
                }
                preencheModelDepedente();
                preencheModelEmpregados();
                preencheModelTransporte();
                preencheModelEmergencia();
                preencheModelAnimais();
                preencheModelImobiliaria();
                try
                {
                    int count = oProprietario.cadastrarApartamentoMoradorCompleto(oProprietarioModel);

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

                    }

                }
                catch (Exception)
                {

                    throw;
                }
            
           

        }

        public void carregaAtualizaMoradorCondominio(ApartamentoModel pProprietarioModel)
        {

             oListProprietario = oProprietario.populaProprietarioSemSenha(pProprietarioModel);

            foreach (ProprietarioModel proprietarioItem in oListProprietario)
            {

                txtCond01.Text = proprietarioItem.proprietario1;
                txtEmail.Text = proprietarioItem.email;
                txtTelefone.Text = proprietarioItem.telefone;
                txtCPF.Text = proprietarioItem.cpf;
                txtRg.Text = proprietarioItem.rg;
                txtEndereco.Text = proprietarioItem.endereco;
                txtCep.Text = proprietarioItem.cepEndereco;
                txtCidade.Text = proprietarioItem.cidade;

                if (proprietarioItem.ap.qtdGaragem > 0)
                {
                    ddlQuantidadeGarage.SelectedItem.Text = proprietarioItem.ap.qtdGaragem.ToString();
                }

                if (proprietarioItem.estadoCivil !=  string.Empty && proprietarioItem.estadoCivil != null)
                {
                    lsrEstadoCivil.SelectedValue = proprietarioItem.estadoCivil;
                }

                if (proprietarioItem.proprietarioImovel != string.Empty && proprietarioItem.proprietarioImovel != null)
                {
                    lstRadioButtonTipo.SelectedValue = proprietarioItem.proprietarioImovel;   
                }
                
                txtCelular.Text = proprietarioItem.celular;
                txtBairro.Text = proprietarioItem.bairro;

                if (proprietarioItem.alugaGaragem != string.Empty && proprietarioItem.alugaGaragem != null && proprietarioItem.alugaGaragem.Contains("Não"))
                {
                    ChkNaoAluga.Checked = true;
                }
                if (proprietarioItem.alugaGaragem != string.Empty && proprietarioItem.alugaGaragem != null && proprietarioItem.alugaGaragem.Contains("Sim"))
                {
                    chkAluga.Checked = true;   
                }
                   
                txtNumeroGaragem.Text = proprietarioItem.alugaGaragem;

                if (proprietarioItem.qtdBicicleta != null)
                {
                    drlQtdBicicleta.SelectedValue = proprietarioItem.qtdBicicleta.ToString();
                }

               
                if (proprietarioItem.descricaoBike != string.Empty && proprietarioItem.descricaoBike != null && proprietarioItem.descricaoBike.ToUpper().Contains("PEQUENAS"))
                {
                    chkBikePequena.Checked = true;
                }
                if (proprietarioItem.descricaoBike != string.Empty && proprietarioItem.descricaoBike != null && proprietarioItem.descricaoBike.ToUpper().Contains("GRANDES"))
                {
                    chkGrande.Checked = true;
                }

                if (proprietarioItem.descricaoBike != string.Empty && proprietarioItem.descricaoBike != null && proprietarioItem.descricaoBike.ToUpper().Contains("MÉDIA"))
                {
                    chkGrande.Checked = true;
                }

                int qtdDepedente = 0;

                foreach (Depedentes depedenteItem in proprietarioItem.dependentes)
                {
                    if (qtdDepedente == 0)
                    {
                        txtboxDepedente1.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco1.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento1.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                    if (qtdDepedente == 1)
                    {
                        txtNomeDepedente2.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco2.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento2.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                    if (qtdDepedente == 2)
                    {
                        txtNomeDepedente3.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco3.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento3.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                    if (qtdDepedente == 3)
                    {
                        txtNomeDepedente4.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco4.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento4.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                    if (qtdDepedente == 4)
                    {
                        txtNomeDepedente5.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco5.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento5.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                    if (qtdDepedente == 5)
                    {
                        txtNomeDepedente6.Text = depedenteItem.nomeDepedente;
                        drpdownParentesco6.SelectedItem.Text = depedenteItem.parentesco;
                        txtDatanascimento6.Text = depedenteItem.nascimentoDepedente;
                        qtdDepedente++;
                        continue;
                    }

                }

                int qtdEmpregados = 0;
                foreach (Empregados empregadoItem in proprietarioItem.empregados)
                {
                    
                    if (qtdEmpregados == 0)
                    {
                    
                        txtBoxNomeEmpregado.Text = empregadoItem.nomeEmpregado ;
                        txtBoxRG.Text = empregadoItem.rgEmpregado ; 
                        qtdEmpregados ++;
                        continue;
                    }
                    if(qtdEmpregados == 1)
                    {
                        txtBoxNomeEmpregado.Text = empregadoItem.nomeEmpregado ;
                        txtBoxRG.Text = empregadoItem.rgEmpregado ; 
                    }
	             
                }

                int qtdAutomovel = 0;

                foreach (Transporte transporteItem in proprietarioItem.transporte)
                {

                    if (qtdAutomovel == 0)
                    {
                        TextBoxMarcaModelo1.Text = transporteItem.marcaModelo;
                        TextBoxCor1.Text = transporteItem.cor;
                        TextBoxPlaca1.Text = transporteItem.placaCarro;
                        qtdAutomovel++;
                        continue;
                    }
                    if (qtdAutomovel == 1)
                    {
                        TextBoxMarcaModelo2.Text = transporteItem.marcaModelo;
                        TextBoxCor2.Text = transporteItem.cor;
                        TextBoxPlaca2.Text = transporteItem.placaCarro;
                        qtdAutomovel++;
                        continue;
                    }

                    if (qtdAutomovel == 2)
                    {
                        TextBoxMarcaModelo3.Text = transporteItem.marcaModelo;
                        TextBoxCor3.Text = transporteItem.cor;
                        TextBoxPlaca3.Text = transporteItem.placaCarro;
                    }
                    
                }

                if (proprietarioItem.emergencia.nomeContatoEmergencia != null)
                {
                    TextBoxNomeEmergencia.Text = proprietarioItem.emergencia.nomeContatoEmergencia;
                    txtBoxParentescoEmergencia.Text = proprietarioItem.emergencia.nomeParentescoEmergencia;
                    textboxContatoEmergencia.Text =   proprietarioItem.emergencia.contato;
                }


                if (proprietarioItem.animais.quantidadeAnimais > 0)
                {
                    DropDownListQuantdAnimal.SelectedItem.Text = proprietarioItem.animais.quantidadeAnimais.ToString();
                    TextBoxEspecieAnimal.Text = proprietarioItem.animais.especies;
                }

                if (proprietarioItem.imobiliaria.Contato != null)
                {
                   TextBoxEmpresaImobiliaria.Text =  proprietarioItem.imobiliaria.nomeImobiliaria;
                   TextBoxTelefoneImobiliaria.Text =  proprietarioItem.imobiliaria.telefoneImobiliaria;
                   TextBoxContatoImobiliaria.Text = proprietarioItem.imobiliaria.Contato;
                }
        }
        }
        #endregion

        public void preencheModelDepedente()
        {
           
                oProprietarioModel.dependentes = new List<Depedentes>();
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
                    oDepedentes.nascimentoDepedente = txtDatanascimento3.Text;
                    oProprietarioModel.dependentes.Add(oDepedentes);
                }
                if (txtNomeDepedente4.Text != string.Empty)
                {
                    Depedentes oDepedentes = new Depedentes();
                    oDepedentes.nomeDepedente = txtNomeDepedente4.Text == string.Empty ? null : txtNomeDepedente4.Text;
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

            oProprietarioModel.empregados = new List<Empregados>();
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
                oProprietarioModel.empregados.Add(oEmpregados);
            }
        }

        public void preencheModelTransporte()
        {

            oProprietarioModel.transporte = new List<Transporte>();
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

        protected void ibtAddSave_Click(object sender, ImageClickEventArgs e)
        {
            cadastrarMoradorCompleto();
        }

        protected void chkAluga_CheckedChanged(object sender, EventArgs e)
        {

            if (chkAluga.Checked == false)
            {
                tdAlugaGaragem.Visible = false;
            }
            else
            {
                ChkNaoAluga.Checked = false;
                tdAlugaGaragem.Visible = true;
                geraNumeroGaragem();
                preencheApartamentosAluga();
            }
        }

        protected void ChkNaoAluga_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkNaoAluga.Checked == false)
            {
                tdAlugaGaragem.Visible = false;
            }

            tdAlugaGaragem.Visible = false;
            chkAluga.Checked = false;
        }

        protected void lstRadioButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRadioButtonTipo.SelectedItem.Text == "Proprietário")
            {
                dvImobiliaria.Visible = false;
            }
            else if (lstRadioButtonTipo.SelectedItem.Text == "Locatário")
            {
                dvImobiliaria.Visible = true;
            }
        }

        protected void drpBlocoAluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            geraNumeroGaragem();
        }

        protected void ddLApartamentosAluga_SelectedIndexChanged(object sender, EventArgs e)
        {
            geraNumeroGaragem();
        }

        public void maskTextBoxCPF()
        {

        }

        protected void txtCPF_TextChanged(object sender, EventArgs e)
        {
            bool isCpf = Util.Util.IsCpf(txtCPF.Text);

            if (!isCpf)
            {
                txtCPF.Text = "";
                string errorText = "CPF inválido";
                lblMessageCPF.Text = errorText;
                lblMessageCPF.ForeColor = System.Drawing.Color.Red;
                lblMessageCPF.BackColor = System.Drawing.Color.WhiteSmoke;

            }
            



        }

        protected void txtCep_TextChanged(object sender, EventArgs e)
        {
            preencheEnderecoPorCep();

        }

        protected void ibtSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnFinalizaCadastro_Click(object sender, EventArgs e)
        {
            cadastrarMoradorCompleto();
            Response.Redirect(Page.Request.Path);
        }

        protected void ibtCancel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

            bool validateEmail = Util.Util.validaEmail(txtEmail.Text);

            if (!validateEmail)
            {
                lblValidaEmail.Text = "E-mail inválido";
                txtEmail.Text = "";
            }
            else
            {
                lblValidaEmail.Visible = false;
            }
                
            

        }

        protected void drpBloco_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!drpBloco.SelectedValue.Equals("-1") && !ddLApartamentos.SelectedValue.Equals("-1"))
            {
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedValue);
                oAPmodel.apartamento  = Convert.ToInt32(ddLApartamentos.SelectedValue);
                carregaAtualizaMoradorCondominio(oAPmodel);
            }

        }

        protected void ddLApartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!drpBloco.SelectedValue.Equals("-1") && !ddLApartamentos.SelectedValue.Equals("-1"))
                {
                oAPmodel.bloco = Convert.ToInt32(drpBloco.SelectedValue);
                oAPmodel.apartamento = Convert.ToInt32(ddLApartamentos.SelectedValue);
                carregaAtualizaMoradorCondominio(oAPmodel);
                }
        }
    }
}