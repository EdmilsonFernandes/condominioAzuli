using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azuli.Web.Portal
{
    public partial class PendenciaAgendamentos : System.Web.UI.Page
    {
       
        int actionStatus = 0;


        AgendaBLL oAgenda = new AgendaBLL();
        AgendaModel oAgendaModel = new AgendaModel();
        ApartamentoModel oApModel = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();
        ApartamentoModel oAP = new ApartamentoModel();
        ProprietarioBLL oProprietarioBusiness = new ProprietarioBLL();
        Util.SendMail oEnviaEmail = new Util.SendMail();
        


        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (oUtil.validateSessionAdmin())
            {
                if (!IsPostBack)
                {
                    // lblAdmin.Text = Session["Proprie1"].ToString();

                    hiddenAll();
                     Session["aptoSession"] = Request.QueryString["apto"];
                     Session["dataReservaOnline"] = Request.QueryString["data"];
                    //string status = Request.QueryString["status"];
                     Session["blocoSession"] = Request.QueryString["bloco"];
                    DvConfirma.Visible = false;
                    DvVoltar.Visible = false;

                    carregaPendencia((string)Session["dataReservaOnline"], (string)Session["aptoSession"], (string)Session["blocoSession"]);
                    lblDataReserva.Text =  dataByExtense();
                    lblDataReservaEtapa1.Text = dataByExtense();
                   

                }
            }


           
            

        }

        public string buscaEmail(int bloco, int apto)
        {
            oApModel.apartamento = apto;
            oApModel.bloco = bloco;
            string email = oProprietarioBusiness.BuscaEmailMorador(oApModel);

            return email;

        }

        public string dataByExtense()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            DateTime dataReserva = new DateTime();
            dataReserva = Convert.ToDateTime(Session["dataReservaOnline"]);

            int dia = dataReserva.Day;
            int ano = dataReserva.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dataReserva.Month));
            string diaSemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(dataReserva.DayOfWeek));

            string dataRetorno = diaSemana + ", " + dia + " de " + mes + " de " + ano;

            lblBlocoApto.Text = Session["blocoSession"] + " - " + Session["aptoSession"];

            return dataRetorno;

        }

        public void carregaPendencia(string dataPen, string apto, string bloco)
        {

       
            oApModel.apartamento = Convert.ToInt32(apto);
            oApModel.bloco = Convert.ToInt32(bloco);
            oAgendaModel.ap = oApModel;
            oAgendaModel.dataAgendamento = Convert.ToDateTime(dataPen);
            double valorChurras = 0.0;
            double valorFesta = 0.0;
            //double desconto = 0.0;

     


            try
            {

                foreach (var item in  oAgenda.pendentePagamento(oAgendaModel))
                {
                    if (oAgenda.pendentePagamento(oAgendaModel).Count >= 2)
                    {
                        showAll();

                        if (item.salaoFesta == true)
                        {
                          
                            lblBloco.Text = item.ap.bloco.ToString();
                            lblApto.Text = item.ap.apartamento.ToString();
                            //lblDiasAtrasoFesta.Text = item.qtdDiasPagamentoChurras.ToString();
                            //lblValorFesta.Text = "R$ " + item.valorReserva.ToString();
                            valorFesta = item.valorReserva;

                        }

                        if (item.salaoChurrasco == true)
                        {
                            lblBloco.Text = item.ap.bloco.ToString();
                            lblApto.Text = item.ap.apartamento.ToString();
                            //lblDiasAtrasoChurras.Text = item.qtdDiasPagamentoChurras.ToString();
                            //lblValorChurras.Text = "R$ " + item.valorReserva.ToString();
                            valorChurras = item.valorReserva;
                        }

                        //desconto = 20.00;
                        //lblDesconto.Text = "R$ 20,00";


                        //lblTotal.Text = "R$ " + Convert.ToString((valorFesta + valorChurras) - desconto);

                    }


                    else
                    {
                        if (item.salaoFesta == true)
                        {
                            hiddenControllerChurras();
                            showControllerFesta();
                            lblBloco.Text = item.ap.bloco.ToString();
                            lblApto.Text = item.ap.apartamento.ToString();
                            //lblDiasAtrasoFesta.Text = item.qtdDiasPagamentoChurras.ToString();
                            //lblValorFesta.Text = "R$ " + item.valorReserva.ToString();

                            //lblTotal.Text = "R$ " + item.valorReserva.ToString();
                            //lblDesconto.Text = "R$ 00,00";

                        }

                        if (item.salaoChurrasco == true)
                        {
                            hiddenControllerFesta();
                            showControllerChurras();
                            lblBloco.Text = item.ap.bloco.ToString();
                            lblApto.Text = item.ap.apartamento.ToString();
                            //lblDiasAtrasoChurras.Text = item.qtdDiasPagamentoChurras.ToString();
                            //lblValorChurras.Text = "R$ " +  item.valorReserva.ToString();

                            //lblTotal.Text = "R$ " + item.valorReserva.ToString();
                            //lblDe7conto.Text = "R$ 00,00";
                        }
                    }
                    
                }
               

            }
            catch (Exception)
            {
                
                throw;
            }
          




        }


     

        public void hiddenControllerChurras()
        {
           
            lblChurras.Visible = false;
            //btnConfirmaChurras.Visible = false;
            //btnCancelarChurras.Visible = false;
            //lblDiasAtrasoChurras.Visible = false;
            //lblValorChurras.Visible = false;


        }

        public void showControllerChurras()
        {

            lblChurras.Visible = true;
            //btnConfirmaChurras.Visible = true;
             btnCancelarChurras.Visible = true;
            //lblDiasAtrasoChurras.Visible = true;
            //lblValorChurras.Visible = true;


        }


        public void hiddenControllerFesta()
        {

            lblSalaoFesta.Visible = false;
            //btnConfirmaSalao.Visible = false;
            //btnCancelaFesta.Visible = false;
            //lblDiasAtrasoFesta.Visible = false;
            //lblValorFesta.Visible = false;


        }

        public void showControllerFesta()
        {

            lblSalaoFesta.Visible = true;
            //btnConfirmaSalao.Visible = true;
            btnCancelaFesta.Visible = true;
            //lblDiasAtrasoFesta.Visible = true;
            //lblValorFesta.Visible = true;


        }


        public void showAll()
        {
            lblChurras.Visible = true;
            //btnConfirmaChurras.Visible = true;
            btnCancelarChurras.Visible = true;
            //lblDiasAtrasoChurras.Visible = true;
            //lblValorChurras.Visible = true;
            lblSalaoFesta.Visible = true;
            //btnConfirmaSalao.Visible = true;
            btnCancelaFesta.Visible = true;
            //lblDiasAtrasoFesta.Visible = true;
            //lblValorFesta.Visible = true;
            btnCancelAll.Visible = true;
            //btnConfirmALL.Visible = true;


        }

        public void hiddenAll()
        {
            lblChurras.Visible = false;
            //btnConfirmaChurras.Visible = false;
            btnCancelarChurras.Visible = false;
            //lblDiasAtrasoChurras.Visible = false;
            //lblValorChurras.Visible = false;
            lblSalaoFesta.Visible = false;
            //btnConfirmaSalao.Visible = false;
            btnCancelaFesta.Visible = false;
            //lblDiasAtrasoFesta.Visible = false;
            //lblValorFesta.Visible = false;
            btnCancelAll.Visible = false;
            //btnConfirmALL.Visible = false;


        }

        
        protected void btnConfirmaChurras_Click(object sender, EventArgs e)
        {

            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Confirmação será feita para área: Churrasqueira";
            lblStatus.ForeColor = System.Drawing.Color.Green;
            //lblMsg.Text = "Confirme os dados para reserva da Churrasqueira: ";
            actionStatus =  ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.confirmaChurrasqueira.ToString()));
            Session["status"] = actionStatus;
              
            
        }



        protected void btnCancelarChurras_Click(object sender, EventArgs e)
        {
            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Cancelamento será feito para área: Churrasqueira";
            lblStatus.ForeColor = System.Drawing.Color.Red;

           // lblMsg.Text = "Confirme os dados para cancelamento da Churrasqueira?";
            actionStatus = ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.cancelaChurrasco.ToString()));
            Session["status"] = actionStatus;
        }

        protected void btnCancelaFesta_Click(object sender, EventArgs e)
        {
            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Cancelamento será feito para área: Salão de Festa";
            lblStatus.ForeColor = System.Drawing.Color.Red;

           // lblMsg.Text = "Confirma os dados para cancelamento do Salão de Festa?";
            actionStatus = ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.cancelaSLFesta.ToString()));
            Session["status"] = actionStatus;

        }

        protected void btnConfirmALL_Click(object sender, EventArgs e)
        {
            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Confirmação será feita para área: Salão de Festa / Churrasqueira";
            lblStatus.ForeColor = System.Drawing.Color.Green;

           // lblMsg.Text = "Confirme os dados para reservas do Salão de Festa e Churrasqueira";
            actionStatus = ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.confimaTudo.ToString()));
            Session["status"] = actionStatus;

        }

        protected void btnCancelAll_Click(object sender, EventArgs e)
        {
            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Cancelamento será feito para áreas: Salão de Festa  e Churrasqueira";

            lblStatus.ForeColor = System.Drawing.Color.Red;

            //lblMsg.Text = "Confirme os dados para cancelamento das áreas: Salão de Festa e Churrasqueira?";
            actionStatus = ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.cancelaTudo.ToString()));
            Session["status"] = actionStatus;

        }

        protected void btnConfirmaSalao_Click(object sender, EventArgs e)
        {

            DvConfirma.Visible = true;
            dvPesquisaMorador.Visible = false;

            lblStatus.Text = "Confirmação será feita para área: Salão de Festa";
            lblStatus.ForeColor = System.Drawing.Color.Green;

            //lblMsg.Text = "Confirme os dados para reserva do Salão de Festa:";
            actionStatus = ((Int32)Enum.Parse(typeof(opcaoCancelamento), opcaoCancelamento.confirmaFesta.ToString()));
            Session["status"] = actionStatus;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

        public enum opcaoCancelamento
        {
            confirmaChurrasqueira = 1,
            confirmaFesta = 2 ,
            cancelaSLFesta = 3,
            cancelaChurrasco = 4,
            confimaTudo = 5,
            cancelaTudo = 6

        };

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            DvVoltar.Visible = true;
            DvConfirma.Visible = false;
            dvPesquisaMorador.Visible = false;
            int bloco = Convert.ToInt32(Session["blocoSession"]);
            int apto = Convert.ToInt32( Session["aptoSession"]);
            bool isEmailAll = false;

            string recebeEmail = buscaEmail(Convert.ToInt32(Session["blocoSession"]), Convert.ToInt32(Session["aptoSession"]));

            if (recebeEmail == null)
            {
                isEmailAll = false;
            }
            else
            {
                isEmailAll = Regex.IsMatch(recebeEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            }

            if (Session["status"] != null)
            {
                switch ((Int32)Session["status"])
                {
                    case 1:
                     
                        ConfirmChurraqueira();
                        openedPoupReport();
                       
                       
                     
                        break;
                    case 2:
                        
                        ConfirmFesta();

                       

                        openedPoupReport();
                       
                      
                        break;
                    case 3:
                        
                        cancelFesta();

                      

                        if (isEmailAll)
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Salão de festa", recebeEmail);

                        }
                        else
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Salão de festa - Morador sem e-mail", "residencialcampoazuli@gmail.com");
                        }

                        Response.Redirect("WelcomeAdmin.aspx");
                        //openedPoupReport();
                      
                      
                        break;

                    case 4:
                        cancelChurras();

                      
                        if (isEmailAll)
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Churrasqueira", recebeEmail);

                        }
                        else
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Churrasqueira - Morador sem e-mail", "residencialcampoazuli@gmail.com ");
                        }
                        Response.Redirect("WelcomeAdmin.aspx");
                        //openedPoupReport();
                     
                        break;

                    case 5:
                       
                        ConfirmFesta();
                        ConfirmChurraqueira();
                        openedPoupReport();
                      
                       
                       


                        //ConfirmTudo();
                        break;

                    case 6:
                       
                        cancelFesta();
                        cancelChurras();
                        if (isEmailAll)
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Churrasqueira e Salão de Festa", recebeEmail);

                        }
                        else
                        {
                            sendEmailCancelamento(apto.ToString(), bloco.ToString(), "Cancelamento de Salão de festa e Churrasqueira - Morador sem e-mail", "residencialcampoazuli@gmail.com ");
                        }
                        Response.Redirect("WelcomeAdmin.aspx");
                       
                       
                        //cancelTudo();
                        break;


                }
            }
        }


        public void openedPoupReport()
        {

            OpenPopUp(Page.ResolveUrl("ReportViewer.aspx"), 700, 920, true, true);
        }

        public void ConfirmChurraqueira()
        {

            oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
            oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
            oAgendaModel.ap = oApModel;
            oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
            oAgendaModel.salaoChurrasco = true;
            oAgendaModel.salaoFesta = false;
            oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
            oAgendaModel.statusPagamento = "S";
            oAgendaModel.observacao = txtObs.Text;

            try
            {
                //Atualiza a reserva
                oAgenda.cadastrarAgenda(oAgendaModel.dataAgendamento, oApModel, oAgendaModel);
               
                Session.Remove("status");
               

                // Gera Recibo

            }
            catch (Exception e)
            {
                
                throw e;
            }


            
        }

        //public void ConfirmTudo()
        //{

        //    oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
        //    oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
        //    oAgendaModel.ap = oApModel;
        //    oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
        //    oAgendaModel.salaoChurrasco = true;
        //    oAgendaModel.salaoFesta = true;
        //    oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
        //    oAgendaModel.statusPagamento = "S";
        //    oAgendaModel.observacao = txtObs.Text;

        //    try
        //    {
        //        //Atualiza a reserva
        //        oAgenda.cadastrarAgenda(oAgendaModel.dataAgendamento, oApModel, oAgendaModel);
        //        Session.Remove("status");




        //        // Gera Recibo

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }



        //}


        //public void cancelTudo()
        //{

        //    oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
        //    oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
        //    oAgendaModel.ap = oApModel;
        //    oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
        //    oAgendaModel.salaoChurrasco = true;
        //    oAgendaModel.salaoFesta = true;
        //    oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
        //    oAgendaModel.observacao = txtObs.Text;

        //    try
        //    {
        //        //Atualiza a reserva
        //        oAgenda.cancelaAgendamentoMoradorObservation(oAgendaModel.dataAgendamento, oApModel, oAgendaModel.salaoFesta, oAgendaModel.salaoChurrasco, oAgendaModel.observacao);
        //        Session.Remove("status");


        //        // Gera Recibo

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }



        //}

        public void cancelFesta()
        {
          
            oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
            oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
            oAgendaModel.ap = oApModel;
            oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
            oAgendaModel.salaoChurrasco = false;
            oAgendaModel.salaoFesta = true;
            oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
            oAgendaModel.observacao = txtObs.Text;



            try
            {
                //Atualiza a reserva
                //oAgenda.cancelaAgendamentoMorador(oAgendaModel.dataAgendamento, oApModel, oAgendaModel.salaoFesta, oAgendaModel.salaoChurrasco);
                if (oAgendaModel.observacao == string.Empty || oAgendaModel.observacao == null)
                {
                    oAgendaModel.observacao = "Sem observações!";
                }

                oAgenda.cancelaAgendamentoMoradorObservation(oAgendaModel.dataAgendamento, oApModel, oAgendaModel.salaoFesta, oAgendaModel.salaoChurrasco, oAgendaModel.observacao);
              
                Session.Remove("status");



                // Gera Recibo

            }
            catch (Exception e)
            {

                throw e;
            }



        }

        public void cancelChurras()
        {
           
            oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
            oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
            oAgendaModel.ap = oApModel;
            oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
            oAgendaModel.salaoChurrasco = true;
            oAgendaModel.salaoFesta = false;
            oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
            oAgendaModel.observacao = txtObs.Text;
            

            try
            {
                //Atualiza a reserva
                //oAgenda.cancelaAgendamentoMorador(oAgendaModel.dataAgendamento,oApModel,oAgendaModel.salaoFesta,oAgendaModel.salaoChurrasco);
                oAgenda.cancelaAgendamentoMoradorObservation(oAgendaModel.dataAgendamento, oApModel, oAgendaModel.salaoFesta, oAgendaModel.salaoChurrasco, oAgendaModel.observacao);
              
                Session.Remove("status");
               
                // Gera Recibo

            }
            catch (Exception e)
            {

                throw e;
            }



        }


        public void ConfirmFesta()
        {
        
            oApModel.apartamento = Convert.ToInt32(Session["aptoSession"]);
            oApModel.bloco = Convert.ToInt32(Session["blocoSession"]);
            oAgendaModel.ap = oApModel;
            oAgendaModel.dataConfirmacaoPagamento = DateTime.Now;
            oAgendaModel.salaoChurrasco = false;
            oAgendaModel.salaoFesta = true;
            oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
            oAgendaModel.statusPagamento = "S";
            oAgendaModel.observacao = "Nada Por enquanto";

            try
            {
                //Atualiza a reserva
                oAgenda.cadastrarAgenda(oAgendaModel.dataAgendamento, oApModel, oAgendaModel);
                Session.Remove("status");


                // Gera Recibo

            }
            catch (Exception e)
            {

                throw e;
            }



        }

        /// <summary>
        /// Abre uma janela no estilo Modal Dialog
        /// </summary>
        /// <param name="NamePage">Nome da pagina que sera aberta</param>
        /// <param name="Height">Altura</param>
        /// <param name="Width">Largura</param>
        public static void OpenPopUp(string NamePage, int Height, int Width, bool ScrollBars, bool Resizable)
        {


            StringBuilder url = new StringBuilder();

            url.Append("window.open('" + NamePage + "','janela1','");
            url.Append("width =");
            url.Append(Width);
            url.Append(", height=");
            url.Append(Height);
            url.Append(", scrollbars=");
            url.Append(ScrollBars ? "yes" : "no");
            url.Append(", resizable=");
            url.Append(Resizable ? "yes" : "no");
            url.Append("');");

            JsStartUpScript(url.ToString());
        }

        /// <summary>
        /// Executa um script
        /// </summary>
        /// <param name="Script">Script que sera executado</param>
        public static void JsStartUpScript(string Script)
        {
            Page paginaAtual;
            paginaAtual = GetCurrentPage();
            paginaAtual.ClientScript.RegisterClientScriptBlock(paginaAtual.GetType(), Guid.NewGuid().ToString(), Script, true);
        }

        /// <summary>
        /// Retorna Pagina Corrente
        /// </summary>
        /// <returns></returns>
        private static Page GetCurrentPage()
        {
            return (Page)System.Web.HttpContext.Current.Handler;
        }

        public void sendEmailCancelamento(string apto, string bloco, string area , string email)
        {

            StringBuilder msgMorador = new StringBuilder();

            string dataFormated = Session["dataReservaOnline"].ToString();
            dataFormated.Replace("00:00:00", "");

            msgMorador.Append("Olá,");
            msgMorador.Append("<br> Seu agendamento foi cancelado para o dia:" + string.Format("{0:dd/MM/yy}",  dataFormated.Replace("00:00:00", "") + "<br> Área:" + area + " <br>"));
            msgMorador.Append(" Referente ao Bloco: " + bloco + " e apartamento: " + apto);
            if (txtObs.Text == string.Empty || txtObs.Text=="")
            {
                msgMorador.Append("<br> Motivo: Não informado.");
            }
            else
            {
                msgMorador.Append("<br> Motivo: " + txtObs.Text);
            }
            msgMorador.Append("<br> Qualquer dúvida ligar para o ramal 93 ou pelo telefone: 3027-7997");
            msgMorador.Append("<br> Acesse o site azuli e veja mais detalhes: http://condominiospazioazuli.somee.com/");


            try
            {
                oEnviaEmail.enviaEmailCancelamento(msgMorador.ToString(),"Cara morador(ª)", email.ToString());
            }
            catch 
            {

                throw new Exception("Por algum motivo não possivel enviar e-mail sobre o cancelamento -> " + msgMorador.ToString());
            }
         

        }
      
      
    }

    


}