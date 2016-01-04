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
    namespace Azuli.Web.Portal
    {
        public partial class telaAgendamento : Util.Base
        {
            AgendaBLL oAgenda = new AgendaBLL();
            AgendaModel oAgendaModel = new AgendaModel();
            ApartamentoModel oApModel = new ApartamentoModel();
            Util.Util oUtil = new Util.Util();
            ApartamentoModel oAP = new ApartamentoModel();
            PendenciaAdminBLL oPendenciaBLL = new PendenciaAdminBLL();
            string status = "";

            protected void Page_Load(object sender, EventArgs e)
            {

                if (!IsPostBack)
                {



                    oUtil.validateSession();
               

                }

            }



            protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
            {

                Literal litAlugado = new Literal();
                List<AgendaModel> listaAgenda = oAgenda.listaEventos();





                if (e.Day.Date < (System.DateTime.Now.AddDays(-1)))
                {

                    e.Cell.Font.Strikeout = true;
                    e.Cell.Font.Bold = true;
             
                    e.Cell.BackColor = System.Drawing.Color.FromName("#BAE4F1");

                }

                if (e.Day.Date > (System.DateTime.Now.AddDays(90)))
                {

                        Label t1 = new Label();
                        t1.Font.Bold = true;
                        t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                        t1.Width = 135;
                        t1.Height = 20;

                        t1.Font.Name = "Calibri";
                        t1.Font.Size = 10;
                        t1.ForeColor = Color.Black;
                        t1.Text = "Não Liberado!";
                        t1.ForeColor = System.Drawing.Color.White;
                        t1.BackColor = System.Drawing.Color.FromName("#8B0000");

                        e.Cell.Controls.Add(t1);

                   
                }

                e.Day.IsSelectable = false;
                //e.Cell.Font.Strikeout = false;
                e.Cell.Font.Bold = true;



                if (e.Day.IsToday)
                {
                    e.Cell.Font.Bold = true;
                    e.Cell.ForeColor = System.Drawing.Color.Black;

                }

                foreach (var item in listaAgenda)
                {


                    if (e.Day.Date == item.dataAgendamento)
                    {

                        listAgenda OeventCalendar = new listAgenda();
                        if (item.salaoChurrasco == true & item.salaoFesta == false)
                        {

                            // e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF01");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Name = "Calibri";
                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;


                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;
                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;






                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;





                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                        

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceCHP.ForeColor = Color.FromName("FFA0CC");
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");


                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento +  status ;
                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;

                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");


                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        // t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                    }
                                else
                                {

                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t1.ForeColor = Color.FromName("#8B0000");

                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;

                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");

                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");

                                    }

                                    //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;

                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");

                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }

                            e.Cell.Controls.Add(p1);
                            e.Cell.Height = 50;
                            // e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            //e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");



                        }
                        else if (item.salaoChurrasco == false & item.salaoFesta == true)
                        {

                            // e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#BADEF4");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;


                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;




                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;
                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";

                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");

                                        }

                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");
                                        }
                                        // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            //

                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                    }
                                else
                                {
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t1.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");

                                    }
                                    // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;

                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");

                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }


                            e.Cell.Controls.Add(p1);
                            e.Cell.Height = 50;
                            //e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            //e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");


                        }
                        else if (item.salaoChurrasco == true & item.salaoFesta == true)
                        {

                            //  e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#AA0708");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;


                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;


                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;




                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");

                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;


                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        // t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                    }
                                else
                                {
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t1.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");
                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");
                                    }
                                    // t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                    // t1.Text = "As duas P/";
                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");

                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }


                            e.Cell.Controls.Add(p1);

                            e.Cell.Height = 50;
                            e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");

                            e.Day.IsSelectable = false;
                        }

                        /// Status Pendente
                        /// 
                        else if (item.salaoChurrasco == true & item.salaoFesta == false)
                        {

                            //  e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;


                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;






                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;
                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");
                                        }
                                        // t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");

                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;


                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        // t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                    }
                                else
                                {
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t1.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");

                                    }
                                    //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;

                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");


                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }
                            e.Cell.Controls.Add(p1);
                            e.Cell.Height = 50;
                            e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");



                        }
                        else if (item.salaoChurrasco == false & item.salaoFesta == true)
                        {

                            // e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1B6C81");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;


                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;





                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;
                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            // t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;


                                            // t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            // t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }

                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");
                                        }
                                        t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                    }
                                else
                                {
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        // t1.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");

                                    }


                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");


                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }
                            e.Cell.Controls.Add(p1);
                            e.Cell.Height = 60;
                            e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");


                        }
                        else if (item.salaoChurrasco == true & item.salaoFesta == true)
                        {

                            // e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FB9FB7");
                            Label t1 = new Label();
                            t1.Font.Bold = true;
                            t1.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t1.Width = 135;
                            t1.Height = 20;

                            t1.Font.Size = 8;
                            t1.ForeColor = Color.Black;



                            HyperLink linkPendenceSLFP = new HyperLink();
                            linkPendenceSLFP.Font.Size = 8;

                            linkPendenceSLFP.Width = 135;
                            linkPendenceSLFP.Height = 20;


                            HyperLink linkPendenceCHP = new HyperLink();
                            linkPendenceCHP.Font.Size = 8;
                            linkPendenceCHP.ForeColor = Color.FromName("#FF7979");
                            linkPendenceCHP.Height = 20;
                            linkPendenceCHP.Width = 135;



                            Label t2 = new Label();
                            t2.Font.Bold = true;
                            t2.ID = "t" + e.Day.DayNumberText + e.Day.Date.Month.ToString();
                            t2.Width = 135;
                            t2.Height = 20;

                            t2.Font.Size = 8;
                            t2.ForeColor = Color.Black;
                            int count = 0;

                            OeventCalendar = oAgenda.listaEventos_ByCalendar(item.dataAgendamento);
                            foreach (var quemAlugou in OeventCalendar)
                            {
                                if (OeventCalendar.Count >= 2)
                                    if (count == 0)
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t1.ForeColor = Color.FromName("#8B0000");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;


                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }

                                        count = 1;
                                    }
                                    else
                                    {
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(*) - ";
                                            //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            // t1.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                            linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");

                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "SF(R) - ";
                                            t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t1.ForeColor = Color.FromName("#215E21");

                                        }
                                        if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(*) - ";
                                            //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                            //t2.ForeColor = Color.FromName("#8B0000");
                                            linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;



                                        }
                                        if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                        {
                                            status = "CH(R) - ";
                                            t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                            t2.ForeColor = Color.FromName("#8B0000");

                                        }

                                    }
                                else
                                {
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(*) - ";
                                        //t1.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t1.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceSLFP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceSLFP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;
                                        linkPendenceSLFP.ForeColor = Color.FromName("#8FBC8F");
                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoFesta == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "SF(R) - ";
                                        t1.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t1.ForeColor = Color.FromName("#215E21");

                                    }
                                    if (quemAlugou.statusPagamento == "N" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(*) - ";
                                        //t2.Text = "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento ;
                                        //t2.ForeColor = Color.FromName("#8B0000");
                                        linkPendenceCHP.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        linkPendenceCHP.NavigateUrl = "~/PendenciaReservaMorador.aspx?Bloco=" + quemAlugou.ap.bloco + "&apto=" + quemAlugou.ap.apartamento + "&data=" + quemAlugou.dataAgendamento + "&status" + quemAlugou.statusPagamento;




                                    }
                                    if (quemAlugou.statusPagamento == "S" && quemAlugou.salaoChurrasco == true && quemAlugou.statusPagamento != "C")
                                    {
                                        status = "CH(R) - ";
                                        t2.Text = status + "BL-" + quemAlugou.ap.bloco.ToString() + " AP-" + quemAlugou.ap.apartamento;
                                        t2.ForeColor = Color.FromName("#8B0000");


                                    }

                                    //t1.Text = "As duas P/";
                                }

                            }

                            Panel p1 = new Panel();
                            p1.ID = "p" + e.Day.DayNumberText + e.Day.Date.Month.ToString(); ;
                            p1.Attributes.Add("style", "display:block;");
                            p1.Attributes.Add("style", "display:block;");


                            if (linkPendenceSLFP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceSLFP);
                            }
                            if (linkPendenceCHP.Text != "")
                            {
                                p1.Controls.Add(linkPendenceCHP);
                            }
                            if (t1.Text != "")
                            {
                                p1.Controls.Add(t1);
                            }

                            if (t2.Text != "")
                            {
                                p1.Controls.Add(t2);
                            }
                            e.Cell.Controls.Add(p1);
                            e.Cell.Height = 50;
                            e.Cell.Attributes.Add("onmouseover", "ShowInfo('" + p1.ClientID + "')");
                            e.Cell.Attributes.Add("onmouseout", "HideInfo('" + p1.ClientID + "')");

                            e.Day.IsSelectable = false;
                        }

                        /* FIM */

                    }
                }






            }




            public void preechePendencia()
            {
                try
                {
                    foreach (var item in oPendenciaBLL.listaPendenciaAdmin())
                    {
                        lblLiberarMorador.Text = item.qtdMoradorPendente.ToString();
                        lblLiberaOcorrencia.Text = item.qtdOcorrenciaPendente.ToString();
                        lblMsgRecebida.Text = item.qtdMensagemPendente.ToString();
                        lblLiberarReserva.Text = item.qtdAgendaNoPrazo.ToString();

                    }


                }
                catch (Exception)
                {

                    throw;
                }

            }

            protected void imgLiberarMorador_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("liberaAcessoAdmin.aspx");
            }

            protected void imgReclamacai_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("ListaReclamacaoAbertaAdmin.aspx");
            }

            protected void Calendar2_SelectionChanged(object sender, EventArgs e)
            {
                Session["dataReservaAdministrador"] = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
                Response.Redirect("AreaAdministrativa.aspx");


            }
        }
    }