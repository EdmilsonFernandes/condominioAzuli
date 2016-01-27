using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.Text;


namespace Azuli.Web.Portal
{
    public partial class TelaAgendamentoAdmin : Util.Base
    {
           AgendaBLL oAgenda = new AgendaBLL();
           AgendaModel oAgendaModel = new AgendaModel();
           ApartamentoModel oApModel = new ApartamentoModel();
           Util.Util oUtil = new Util.Util();
           ProprietarioBLL oProprietario = new ProprietarioBLL();
           ApartamentoModel oAP = new ApartamentoModel();
           double churrasqueira =0;
           double festa = 0;
           double desconto = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSessionAdmin())
            {
             
                if (!IsPostBack)
                {


                    escondeControl();
                    lblApartDesc.Text = Session["MoradorSemInternetAP"].ToString();
                    lblBlocoDesc.Text = Session["MoradorSemInternetBloco"].ToString();
                    
                   lblProprietarioDesc.Text = Session["MoradorSemInternetNome1"].ToString() ;
                   lblData.Text = dataByExtense();
                   validaDate(Convert.ToDateTime(Session["dataReservaAdministrador"]));
                   lblDesconto.Text = "Valor total R$ 00,00";
                   precoArea();
                 
                    

                }

            }
            
        }

        public void precoArea()
        {
            ConfiguracaoReservaBLL oConfig = new ConfiguracaoReservaBLL();

            foreach (var item in oConfig.oListaValorReserva())
            {
                if(item.area =="FESTA")
                {
                    festa = item.valor;
                    lblVlFesta.Text = "Valor - R$ " + item.valor+",00";
                }
                if (item.area == "CHURRAS")
                {
                    churrasqueira = item.valor;
                    lblVlrChurras.Text = "Valor - R$ " + item.valor+",00";
                }

                if (item.area == "DESCONTO P/ Duas Áreas")
                {
                    desconto = item.valor;
                }
                
            }
        }




        #region Comentado para tirar complexibilidade de uso...
        //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        //{
        //      Literal litAlugado = new Literal();
        //    List<AgendaModel> listaAgenda = oAgenda.listaEventos();

         
         

           
        //    if (e.Day.Date < (System.DateTime.Now.AddDays(-1)))
        //    {
               
        //        e.Day.IsSelectable = false;
        //        e.Cell.Font.Strikeout = true;
        //        e.Cell.Font.Bold = true;
               
        //    }

        //    if (e.Day.IsToday)
        //    {
        //        e.Cell.Font.Bold = true;
        //        e.Cell.ForeColor = System.Drawing.Color.Black;

        //    }

        //    foreach (var item in listaAgenda)
        //    {


        //        if (e.Day.Date == item.dataAgendamento)
        //        {

        //            listAgenda OeventCalendar = new listAgenda();
        //            if (item.salaoChurrasco == true & item.salaoFesta == false)
        //            {

        //                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF01");
        //                TextBox t1 = new TextBox();
        //                t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t1.Width = 70;
        //                t1.Height = 20;
        //                t1.TextMode = TextBoxMode.SingleLine;
        //                t1.Font.Size = 7;
        //                t1.ForeColor = Color.Black;

        //                TextBox t2 = new TextBox();
        //                t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t2.Width = 70;
        //                t2.Height = 20;
        //                t2.TextMode = TextBoxMode.SingleLine;
        //                t2.Font.Size = 7;
        //                t2.ForeColor = Color.Black;
        //                int count = 0;

        //                OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
        //                foreach (var quemAlugou in OeventCalendar)
        //                {
        //                    if (OeventCalendar.Count >= 2)
        //                        if (count == 0)
        //                        {
        //                            t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                            count = 1;
        //                        }
        //                        else
        //                        {
        //                            t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                        }
        //                    else
        //                    {
        //                        t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;

        //                    }

        //                }

        //                Panel p1 = new Panel();
        //                p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Controls.Add(t1);

        //                if (t2.Text != "")
        //                {
        //                    p1.Controls.Add(t2);
        //                }
        //                e.Cell.Controls.Add(p1);
        //                e.Cell.Height = 50;
        //                e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
        //                e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");



        //            }
        //            else if (item.salaoChurrasco == false & item.salaoFesta == true)
        //            {

        //                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#BADEF4");
        //                TextBox t1 = new TextBox();
        //                t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t1.Width = 70;
        //                t1.Height = 20;
        //                t1.TextMode = TextBoxMode.SingleLine;
        //                t1.Font.Size = 7;
        //                t1.ForeColor = Color.Black;

        //                TextBox t2 = new TextBox();
        //                t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t2.Width = 70;
        //                t2.Height = 20;
        //                t2.TextMode = TextBoxMode.SingleLine;
        //                t2.Font.Size = 7;
        //                t2.ForeColor = Color.Black;
        //                int count = 0;

        //                OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
        //                foreach (var quemAlugou in OeventCalendar)
        //                {
        //                    if (OeventCalendar.Count >= 2)
        //                        if (count == 0)
        //                        {
        //                            t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                            count = 1;
        //                        }
        //                        else
        //                        {
        //                            t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                        }
        //                    else
        //                    {
        //                        t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;

        //                    }

        //                }

        //                Panel p1 = new Panel();
        //                p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Controls.Add(t1);

        //                if (t2.Text != "")
        //                {
        //                    p1.Controls.Add(t2);
        //                }
        //                e.Cell.Controls.Add(p1);
        //                e.Cell.Height = 50;
        //                e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
        //                e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");


        //            }
        //            else if (item.salaoChurrasco == true & item.salaoFesta == true)
        //            {

        //                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#AA0708");
        //                TextBox t1 = new TextBox();
        //                t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t1.Width = 70;
        //                t1.Height = 20;
        //                t1.TextMode = TextBoxMode.SingleLine;
        //                t1.Font.Size = 7;
        //                t1.ForeColor = Color.Black;

        //                TextBox t2 = new TextBox();
        //                t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
        //                t2.Width = 70;
        //                t2.Height = 20;
        //                t2.TextMode = TextBoxMode.SingleLine;
        //                t2.Font.Size = 7;
        //                t2.ForeColor = Color.Black;
        //                int count = 0;

        //                OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
        //                foreach (var quemAlugou in OeventCalendar)
        //                {
        //                    if (OeventCalendar.Count >= 2)
        //                        if (count == 0)
        //                        {
        //                            t1.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                            count = 1;
        //                        }
        //                        else
        //                        {
        //                            t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                        }
        //                    else
        //                    {
        //                        t2.Text = "B-" + quemAlugou.ap.bloco.ToString() + " A-" + quemAlugou.ap.apartamento;
        //                        t1.Text = "As duas P/";
        //                    }

        //                }

        //                Panel p1 = new Panel();
        //                p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Attributes.Add("style", "display:none;");
        //                p1.Controls.Add(t1);

        //                if (t2.Text != "")
        //                {
        //                    p1.Controls.Add(t2);
        //                }
        //                e.Cell.Controls.Add(p1);
        //                e.Cell.Height = 50;
        //                e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
        //                e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");

        //                e.Day.IsSelectable = false;
        //            }
        //        }
        //    }
        //}
#endregion

        public void escondeControl()
        {
            //dvAlugar.Visible = true;
            DivConfirma.Visible = false;
           
           
        
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

        #region Comentado para tirar a complexibilidade
        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{

        //    List<AgendaModel> oLista = validaData(Calendar1.SelectedDate);
        //    lblData.Text = // Calendar1.SelectedDate.ToString("dd/MM/yyyy");

        //    chkSalaoFesta.Visible = true;
        //    chkChurrascaria.Visible = true;
            
        //        foreach (var item in oLista)
        //        {

        //            if (item.salaoChurrasco == false && item.salaoFesta == false)
        //            {
        //                chkSalaoFesta.Visible = true;
        //                chkChurrascaria.Visible = true;
        //            }
        //            else
        //            {

        //                chkChurrascaria.Visible = item.salaoFesta;
        //                chkSalaoFesta.Visible = item.salaoChurrasco; 
        //            }



        //            //if (item.salaoChurrasco == true & item.salaoFesta  == false)
        //            //{
        //            //    chkChurrascaria.Visible = false;
        //            //    chkSalaoFesta.Visible = true;
        //            //    chkSalaoFesta.Checked = true;
        //            //}
        //            //else if (item.salaoChurrasco == false & item.salaoFesta == true)
        //            //{

        //            //    chkSalaoFesta.Visible = false;
        //            //    chkChurrascaria.Visible = true;
        //            //    chkChurrascaria.Checked = true;

        //            //}
        //            //else if (item.salaoChurrasco == false & item.salaoFesta == false)
        //            //{

        //            //    chkSalaoFesta.Visible = false;
        //            //    chkChurrascaria.Visible = false;
        //            //    chkChurrascaria.Checked = false;

        //            //}
        //            //else if (item.salaoChurrasco == true & item.salaoFesta == true)
        //            //{
        //            //    chkSalaoFesta.Visible = true;
        //            //    chkSalaoFesta.Visible = true;
        //            //}
        //        }


        //        //lblMsgData.Visible = false;
        //       // dvAlugar.Visible = true;
        //       // dvCalendar.Visible = false;

        //}
        #endregion

        public void validaDate(DateTime date)
        {
            List<AgendaModel> olistAgenda = new List<AgendaModel>();

         
                olistAgenda = oAgenda.listaEventosByData(date);

                chkSalaoFesta.Visible = true;
                chkChurrascaria.Visible = true;
                lblVlrChurras.Visible = true;
                lblVlFesta.Visible = true;

                foreach (var item in olistAgenda)
                {

                    if (item.salaoChurrasco == false && item.salaoFesta == false)
                    {
                        chkSalaoFesta.Visible = true;
                        chkChurrascaria.Visible = true;
                        lblVlFesta.Visible = true;
                        lblVlrChurras.Visible = true;
                    }
                    else
                    {

                        chkChurrascaria.Visible = item.salaoFesta;
                        lblVlrChurras.Visible = item.salaoFesta;

                        chkSalaoFesta.Visible = item.salaoChurrasco;
                        lblVlFesta.Visible = item.salaoChurrasco;
                    }
                   
                }  
        }
              

        public List<AgendaModel> validaData(DateTime date)
        {
            List<AgendaModel> olistAgenda = new List<AgendaModel>();

            olistAgenda = oAgenda.listaEventosByData(date);

            return olistAgenda;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            int contadorChurras = 0;
            int contadorFesta = 0;

            if (chkChurrascaria.Checked || chkSalaoFesta.Checked)
            {

                //bool salaoFesta = false;
                //bool churrasco = false;

                //if (chkSalaoFesta.Checked && chkChurrascaria.Checked)
                //{
                //    churrasco = true;
                //    salaoFesta = true;
                //}
                //else if (chkSalaoFesta.Checked && !chkChurrascaria.Checked)
                //{
                //    salaoFesta = true;
                //    churrasco = false; ;
                //}

                //else if (!chkSalaoFesta.Checked && chkChurrascaria.Checked)
                //{
                //    churrasco = true;
                //    salaoFesta = false;
                //}


                oAgendaModel.salaoChurrasco = chkChurrascaria.Checked;
                oAgendaModel.salaoFesta = chkSalaoFesta.Checked;
                oApModel.apartamento = int.Parse(lblApartDesc.Text);
                oApModel.bloco = int.Parse(lblBlocoDesc.Text);
                if (chkPG.Checked)
                {
                    oAgendaModel.statusPagamento = "S";

                }
                else
                {
                    oAgendaModel.statusPagamento = "N";
                }

                    oAgendaModel.dataConfirmacaoPagamento = DateTime.Today;

                    if (txtObservacao.Text == string.Empty)
                    {
                        txtObservacao.Text = "Sem observações";
                    }
                    oAgendaModel.observacao = txtObservacao.Text;
               

                try
                {

                     foreach (var item in  oAgenda.validaAgendamento(Convert.ToDateTime(lblData.Text), oApModel, oAgendaModel))
	                 {
                         contadorChurras = item.contadorChurrasco;
                         contadorFesta =  item.contadorFesta;
	                 }

                     if (chkChurrascaria.Checked && contadorChurras <= 0 || chkSalaoFesta.Checked && contadorFesta <= 0)
                     {
                         oAgenda.cadastrarAgenda(Convert.ToDateTime(Session["dataReservaAdministrador"]), oApModel, oAgendaModel);

                        

                         Util.SendMail oEnviaEmailCadastro = new Util.SendMail();
                        

                         string emailReserva = "";
	                       
                         foreach(var item in oProprietario.enviaCrendencialAcesso(oApModel))
                         {
                             emailReserva = item.email;
                         }
                         if (emailReserva == "Não tem no momento")
                         {
                             emailReserva = string.Empty;
                         }

                         if (emailReserva != string.Empty || emailReserva != "")
                         {
                             oEnviaEmailCadastro.enviaSenha("<b> Reserva realizada com sucesso para:<br> Apto:" +oApModel.apartamento+ " e Bloco: "+oApModel.bloco +"<br>, Para o dia: " + Session["dataReservaAdministrador"].ToString()+"<br> Para consultar seus agendamentos consulte o site abaixo: <br> http://www.condominioazuli.somee.com ","", emailReserva, 0);
                         }

                        

                         //dvAlugar.Visible = false;
                         if (chkPG.Checked)
                         {
                             btnRecibo.Visible = true;
                             imgCalendar.Visible = true;
                             hplnkWelcomeAdmin.Visible = true;
                             btnOKConfirma.Visible = false;
                         }
                         else
                         {
                             btnRecibo.Visible = false;
                             imgCalendar.Visible = false;
                             hplnkWelcomeAdmin.Visible = false;
                             btnOKConfirma.Visible = true;
                         }
                         DivConfirma.Visible = true;
                         dvProprietario.Visible = false;

                         lblConfirmaData.Text = lblData.Text;
                         lblBlocoConfirma.Text = lblBlocoDesc.Text;
                         lblApConfirma.Text = lblApartDesc.Text;
                     }
                     else
                     {
                         lblReserva.Text = "Já existem reservas para esta data!!";
                         lblDataPG.Text = "";
                     }
                }
                catch (Exception error)
                {

                    throw error;
                }


              

            }
            else
            {
                lblReserva.Text = "Favor escolher uma das opções !!";
            }
        }



        protected void btnOKConfirma_Click(object sender, EventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }


        
        protected void btnSair_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("telaAgendamentoAdmin.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Write("<script>window.print();</script>");
        }

        protected void btnOKConfirma_Click1(object sender, EventArgs e)
        {
            
            Response.Redirect("WelcomeAdmin.aspx");
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {

            HttpContext.Current.Response.Write("<script>window.print();</script>");

        }

        protected void btnCancelaReserva_Click(object sender, EventArgs e)
        {
            Session.Remove("MoradorSemInternetAP");
            Session.Remove("MoradorSemInternetBloco");
            Session.Remove("MoradorSemInternetNome1");
            Session.Remove("MoradorSemInternetNome2");

            Response.Redirect("AreaAdministrativa.aspx");
        }

        protected void chkPG_CheckedChanged(object sender, EventArgs e)
        {
            
            DateTime Data = DateTime.Now;
            string DataFormato = "";
            if (chkPG.Checked)
            {
                DataFormato = Data.ToString("D");
                lblDataPG.Text = "Pago hoje: " + DataFormato.ToUpper();
            }
            else
            {
                lblDataPG.Text = "";
            }
        }

        protected void btnRecibo_Click(object sender, EventArgs e)
        {
            Session["reciboConfirmadoNoAto"] = 1;
            openedPoupReport();

        }



        public void openedPoupReport()
        {

            OpenPopUp(Page.ResolveUrl("ReportViewer.aspx"), 700, 920, true, true);
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



        public void emitirRecibo()
        {

         
    
    
        }

        protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WelcomeAdmin.aspx");
        }

        protected void chkChurrascaria_CheckedChanged(object sender, EventArgs e)
        {

            precoArea();
            if (chkChurrascaria.Checked && chkSalaoFesta.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + ((festa + churrasqueira) - desconto)+",00 -> Desconto de: R$" + desconto + ",00";
            }

            if (!chkChurrascaria.Checked && !chkSalaoFesta.Checked)
            {

                lblDesconto.Text = "R$ 00,00";
            }

            if (!chkSalaoFesta.Checked && chkChurrascaria.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + churrasqueira + ",00"; ;

            }
            if (chkSalaoFesta.Checked && !chkChurrascaria.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + festa + ",00"; ;

            }
        }

        protected void chkSalaoFesta_CheckedChanged(object sender, EventArgs e)
        {
            precoArea();
            if (chkChurrascaria.Checked && chkSalaoFesta.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + ((festa + churrasqueira) - desconto) + ",00 -> Desconto de: R$" + desconto + ",00";
            }


         
            if (!chkChurrascaria.Checked && !chkSalaoFesta.Checked)
            {

                lblDesconto.Text = "R$ 00,00";
            }

            if (chkSalaoFesta.Checked && !chkChurrascaria.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + festa+ ",00"; ;

            }

            if (!chkSalaoFesta.Checked && chkChurrascaria.Checked)
            {
                lblDesconto.Text = "Valor Total: R$" + churrasqueira + ",00"; ;

            }

        }

      

        #region Comentado para tirar complexibilidade
        //protected void UpdateTimer_Tick(object sender, EventArgs e)
        //{
           
        //}

        //protected void UpdateTimer_Tick1(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        System.Web.UI.WebControls.TableCell tabela = new TableCell();
        //        System.Web.UI.WebControls.CalendarDay calendario = new CalendarDay(DateTime.Now, false, false, false, false, "1");


        //        Calendar1_DayRender(this, new DayRenderEventArgs(tabela, calendario));

        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }




        //}
        #endregion




    }
        
    
}
    
