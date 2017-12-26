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
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azuli.Web.Portal
{
    public partial class AreaAdministrativa : Util.Base
    {
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        AgendaModel oAgendaModel = new AgendaModel();
        AgendaBLL oAgendaBLL = new AgendaBLL();
        Util.Util oUtil = new Util.Util();
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (oUtil.validateSessionAdmin())
                {
                   
                    hiddenControlDiv();
                    lblDataReserva.Text = dataByExtense();
                    lblDataReserva2.Text = dataByExtense();
               
                }
                else
                {
                    
                   
                }
            }
        }



        public void ativaLinkAgendamentoFuturo()
        {
            oAPmodel.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
            oAPmodel.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);
            int contaChurras = 0;
            int contaFesta = 0;
            oAgendaModel.ap = oAPmodel;

            if (oAgendaBLL.agendamentoFuturoChurras(oAgendaModel).Count > 0)
            {
                foreach (var item in oAgendaBLL.agendamentoFuturoChurras(oAgendaModel))
                {
                    contaChurras = item.contadorChurrasco;
                    
                }

                if (contaChurras < 0)
                {
                    lnkHistoricoReservas.Visible = true;
                }
            }

            if (oAgendaBLL.agendamentoFuturoFesta(oAgendaModel).Count > 0)
            {

                foreach (var item in oAgendaBLL.agendamentoFuturoFesta(oAgendaModel))
                {
                    contaFesta = item.contadorFesta;

                }

                if (contaFesta < 0)
                {
                    lnkHistoricoReservas.Visible = true;
                }
               
            }


        }

        public void preencheGridAgendamentoFuturo()
        {
            bool validaChuras = false;
            bool validaFesta = false;
            oAPmodel.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
            oAPmodel.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);

            oAgendaModel.ap = oAPmodel;

            if (oAgendaBLL.agendamentoFuturoFesta(oAgendaModel).Count > 0)
            {
                foreach (var item in oAgendaBLL.agendamentoFuturoFesta(oAgendaModel))
                {
                    if (item.contadorFesta < 0)
                    {
                        validaFesta = true;
                        grdReservaProgramadaFesta.DataSource = oAgendaBLL.agendamentoFuturoFesta(oAgendaModel);
                        grdReservaProgramadaFesta.DataBind();

                       
                    }
                }
            }

          
            if (oAgendaBLL.agendamentoFuturoChurras(oAgendaModel).Count > 0)
            {
                foreach (var item in oAgendaBLL.agendamentoFuturoChurras(oAgendaModel))
                {
                    if (item.contadorChurrasco < 0)
                    {
                        validaChuras = true;
                        grdReservaProgramadaChurras.DataSource = oAgendaBLL.agendamentoFuturoChurras(oAgendaModel);
                        grdReservaProgramadaChurras.DataBind();
                       
                    }

                }

           }

            if(validaChuras)
            {
                dvAgendamentosFuturos.Visible = true;
                grdReservaProgramadaFesta.Visible = false;
                lgFesta.Visible = false;
                grdReservaProgramadaChurras.Visible = true;
                lgChurras.Visible = true;

            }
            else if (validaFesta)
            {
                dvAgendamentosFuturos.Visible = true;
                grdReservaProgramadaFesta.Visible = true;
                lgFesta.Visible = true;
                grdReservaProgramadaChurras.Visible = false;
                lgChurras.Visible = false;

            }

            if (validaFesta == true && validaChuras == true)
            {
                dvAgendamentosFuturos.Visible = true;
                grdReservaProgramadaFesta.Visible = true;
                lgFesta.Visible = true;
                grdReservaProgramadaChurras.Visible = true;
                lgChurras.Visible = true;
            }
          
       


        }

        public void statusDiasChurrasSalao()
        {
            
            

            oAPmodel.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
            oAPmodel.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);
            Dictionary<int,DateTime> dataReservaDiasChurras = new Dictionary<int,DateTime>();
            Dictionary<int,DateTime> dataReservaDiasFesta = new Dictionary<int,DateTime>();
           
            foreach (var item in oAgendaBLL.quantidadeDiasReservaChurras(oAPmodel))
            {
                lblChurras.Text = item.Key.ToString();
                lblDataUltimaReservachurras.Text = item.Value.ToString("dd/MM/yyyy");
                
            }

            foreach (var item in oAgendaBLL.quantidadeDiasReservaFesta(oAPmodel))
            {
              lblSalao.Text = item.Key.ToString();
              lblDataUltimaReservaSalao.Text = item.Value.ToString("dd/MM/yyyy");
            }

             lblReservaChurraFoi.Text = "";
             lblDataReservaUltimaChurras.Text = "";
             lblReservaFestaFoi.Text = "";
             lblDataReservaUltimaDescription.Text = "";

            
                 if (Convert.ToInt32(lblChurras.Text) > 0)
                 {
                     lblChurras.Text = "" + Math.Abs(Convert.ToInt32(lblChurras.Text));
                     lblReservaChurraFoi.Text = "Ultima reserva foi a: ";
                     lblDataReservaUltimaChurras.Text = "E foi agendada dia: ";
                 }
                 else if (Convert.ToInt32(lblChurras.Text) == 0)
                 {
                         lblChurras.Text = "" + Math.Abs(Convert.ToInt32(lblChurras.Text));
                         lblDataUltimaReservachurras.Text = "Morador Ainda não fez reservas:";
                         lblReservaChurraFoi.Text = "Status :";
                         //lblReservaChurraFoi.Text = "Você tem reserva aqui";
                         //lblDataReservaUltimaChurras.Text = "Você já tem reserva agenda p/";
                       
                  }


                 if (Convert.ToInt32(lblSalao.Text) > 0)
                 {
                     lblSalao.Text = "" + Math.Abs(Convert.ToInt32(lblSalao.Text));
                     lblReservaFestaFoi.Text = "Ultima reserva foi a: ";
                     lblDataReservaUltimaDescription.Text = "E foi agendada dia: ";
                 }
                 else if (Convert.ToInt32(lblSalao.Text) == 0)
                 {
                         lblSalao.Text = "" + Math.Abs(Convert.ToInt32(lblSalao.Text));
                         lblDataUltimaReservaSalao.Text = "Morador Ainda não fez reservas!";
                         lblReservaFestaFoi.Text = "Status :";
                         //lblReservaFestaFoi.Text = "Você tem reserva aqui";
                         //lblDataReservaUltimaDescription.Text = ": ";
                         
                 }

        }

        public string dataByExtense()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            DateTime dataReserva = new DateTime();
            dataReserva = Convert.ToDateTime(Session["dataReservaAdministrador"]);

            int dia = dataReserva.Day;
            int ano = dataReserva.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dataReserva.Month));
            string diaSemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(dataReserva.DayOfWeek));

            string dataRetorno = diaSemana + ", " + dia + " de " + mes + " de " + ano;

            return dataRetorno;
          
        }

        /// <summary>
        /// Esconde Controles Botãos/Divs
        /// </summary>
        public void hiddenControlDiv()
        {
            dvDadosMorador.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            btnCancelar.Visible = false;
            dvCadastro.Visible = false;
            dvNewUser.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvChurras.Visible = false;
            lnkHistoricoReservas.Visible = false;
            dvAgendamentosFuturos.Visible = false;
            imgCalendar.Visible = false;
            hplnkWelcomeAdmin.Visible = false;
        }


        /// <summary>
        /// Ativa controles
        /// </summary>
        public void activeControlDiv()
        {
            dvDadosMorador.Visible = true;
            statusDiasChurrasSalao();
            dvChurras.Visible = true;
            dvSalaoEstatistica1.Visible = true;
           
        }


        /// <summary>
        /// Evento do botão 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {

           
            oAPmodel.apartamento = Convert.ToInt32(txtAp.Text);
            oAPmodel.bloco = Convert.ToInt32(drpBloco.Text);

            if (oProprietario.BuscaMoradorAdmin(oAPmodel).Count > 0)
            {
                dvCadastro.Visible = false;
                dvDadosMorador.Visible = false;
                dvChurras.Visible = false;
                dvSalaoEstatistica1.Visible = false;
                dvNewUser.Visible = false;
                dvPesquisaMorador.Visible = false;
                foreach (var item in oProprietario.BuscaMoradorAdmin(oAPmodel))
                {
                    lblApartDesc.Text = item.ap.apartamento.ToString();
                    lblBlocoDesc.Text = item.ap.bloco.ToString();
                    lblProprietarioDesc.Text = item.proprietario1.ToString();

                    Session["MoradorSemInternetAP"] = item.ap.apartamento;
                    Session["MoradorSemInternetBloco"] = item.ap.bloco;
                    Session["MoradorSemInternetNome1"] = item.proprietario1.ToString();
                    Session["MoradorSemInternetNome2"] = item.proprietario2.ToString();


                    //Session["AP"] = item.ap.apartamento;
                    //Session["Bloco"] = item.ap.bloco;
                   // Session["MoradorSemInternetNome1"] = item.proprietario1.ToString();
                    //Session["MoradorSemInternetNome2"] = item.proprietario2.ToString();
                    ativaLinkAgendamentoFuturo();
                }

                activeControlDiv();
            }
            else
            {
                dvNewUser.Visible = true;
                dvPesquisaMorador.Visible = false;
                dvDadosMorador.Visible = false;
                dvChurras.Visible = false;
                dvSalaoEstatistica1.Visible = false;
                lblMsg.Visible = true;
                btnCadastrar.Visible = true;
                btnCancelar.Visible = true;
                lblMsg.Text = "Não existem cadastro para este Apartamento e Bloco, Deseja Cadastrar agora?";
            }
           
        }

     
        protected void btnOkPesquisa_Click(object sender, EventArgs e)
        {
           
         
            Response.Redirect("telaAgendamentoAdmin.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            dvNewUser.Visible = false;
            dvPesquisaMorador.Visible = true;
        }

        protected void btnCancel0_Click(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            dvCadastro.Visible = true;
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            btnCancelar.Visible = false;
            lblMsg.Visible = false;
            btnCadastrar.Visible = false;
            dvPesquisaMorador.Visible = false;

            txtBlocos.Text = drpBloco.SelectedItem.Text;
            txtApartamento.Text = txtAp.Text;
            dvNewUser.Visible = false;
            
        }

        protected void btnCadastroMorador_Click(object sender, EventArgs e)
        {

            SendMail enviaEmail = new SendMail();
            
            oProprietarioModel.ap = new ApartamentoModel();

            oProprietarioModel.ap.bloco = Convert.ToInt32(txtBlocos.Text);
            oProprietarioModel.ap.apartamento = Convert.ToInt32(txtApartamento.Text);
            oProprietarioModel.proprietario1 = txtMorador1.Text;
            oProprietarioModel.proprietario2 = ""; //txtMorador2.Text - Para facilitar para o sindico;

            bool isEmail = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);


            if (!isEmail)
            {
                oProprietarioModel.email = "";
            }
            else
            {
                oProprietarioModel.email = txtEmail.Text;
               
            }

           
            oProprietarioModel.senha = oUtil.GeraSenha();
            
            
            try
            {
               int count =  oProprietario.CadastrarApartamentoMorador(oProprietarioModel);

               if (count > 0)
               {
                   lblMsgCadastro.Visible = true;
                   imgCalendar.Visible = true;
                   hplnkWelcomeAdmin.Visible = true;
                   lblMsgCadastro.Text = "Já existe cadastro para o Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento;
                
               }

               else
               {
                  
                   lblMsgCadastro.Visible = true;
                   imgCalendar.Visible = true;
                   hplnkWelcomeAdmin.Visible = true;
                   lblMsgCadastro.Text = "Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " <b> <br>" + "Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> Sua Senha é: " + oProprietarioModel.senha + "<br><b>Acesse: www.condominioazuli.somee.com<b><br><hr>";
                
                   dvCadastro.Visible = false;
                   dvPesquisaMorador.Visible = false;
                   
                  

                   try
                   {
                       if (isEmail)
                       {
                           int status = 0;

                           enviaEmail.enviaSenha(lblMsgCadastro.Text, oProprietarioModel.proprietario1, oProprietarioModel.email, status);
                       }

                       clearControl();
                     

                   }
                   catch (Exception)
                   {
                       
                       lblMsgCadastro.Visible = true;
                       imgCalendar.Visible = true;
                       hplnkWelcomeAdmin.Visible = true;
                       lblMsgCadastro.Text = "<br><br>Cadastro efetuado com sucesso para Morador: <br> <b> " + oProprietarioModel.proprietario1 + " <b> <br>" + "Bloco: " + oProprietarioModel.ap.bloco + " / Apartamento:  " + oProprietarioModel.ap.apartamento + "<br> a Senha é: " + oProprietarioModel.senha + "<br><hr>";

                       dvCadastro.Visible = false;
                       dvPesquisaMorador.Visible = false;
                   }

                  
                  
                  
                   
              
               }

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        protected void btnCancel0_Click1(object sender, EventArgs e)
        {
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvNewUser.Visible = false;
            dvPesquisaMorador.Visible = true;
            dvAgendamentosFuturos.Visible = false;
            Session.Remove("MoradorSemInternetAP");
            Session.Remove("MoradorSemInternetBloco");
            Session.Remove("MoradorSemInternetNome1");
            Session.Remove("MoradorSemInternetNome2");
        }

        protected void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            clearControl();
            dvDadosMorador.Visible = false;
            dvChurras.Visible = false;
            dvSalaoEstatistica1.Visible = false;
            dvCadastro.Visible = false;
            dvPesquisaMorador.Visible = true;
            lblMsgCadastro.Visible = false;
            imgCalendar.Visible = false;
            hplnkWelcomeAdmin.Visible = false;
            
        }

        public void clearControl()
        {
            txtApartamento.Text = "";
            txtBlocos.Text = "";
            txtMorador1.Text = "";
            //txtMorador2.Text = "";
            txtAp.Text = "";
        }

        

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

        protected void lnkHistoricoReservas_Click(object sender, EventArgs e)
        {
            preencheGridAgendamentoFuturo();
        }

        protected void btnOk0_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

        protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

       
    }
}