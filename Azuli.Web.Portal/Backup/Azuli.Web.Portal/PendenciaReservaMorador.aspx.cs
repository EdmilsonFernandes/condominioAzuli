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
    public partial class PendenciaReservaMorador : System.Web.UI.Page
    {

        ProprietarioBLL oProprietario = new ProprietarioBLL();
        ProprietarioModel oProprietarioModel = new ProprietarioModel();
        ApartamentoModel oAPmodel = new ApartamentoModel();
        AgendaModel oAgendaModel = new AgendaModel();
        AgendaBLL oAgendaBLL = new AgendaBLL();
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                     Session["aptoSession"] = Request.QueryString["apto"];
                     Session["dataReservaOnline"] = Request.QueryString["data"];
                    //string status = Request.QueryString["status"];
                     Session["blocoSession"] = Request.QueryString["bloco"];
                     lblBlocoApto.Text = "0" + Session["blocoSession"] + "-" + Session["aptoSession"];  
                    preencheGridAgendamentoFuturo();
                }
            }
        }

        public void preencheGridAgendamentoFuturo()
        {

            oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
            oAPmodel.bloco = Convert.ToInt32(Session["blocoSession"]);
            oAPmodel.apartamento = Convert.ToInt32(Session["aptoSession"]);

            oAgendaModel.ap = oAPmodel;



               foreach (var item in oAgendaBLL.pendentePagamento(oAgendaModel))
                {
                    if (oAgendaBLL.pendentePagamento(oAgendaModel).Count >= 2)
                    {


                        showAll();


                        if (item.salaoFesta == true)
                        {
                            var festa = from festaPendente in oAgendaBLL.pendentePagamento(oAgendaModel)
                                        where festaPendente.salaoFesta == true 
                                        && festaPendente.salaoChurrasco == false
                                        select festaPendente;

                            grdReservaProgramadaFesta.DataSource = festa; //oAgendaBLL.pendentePagamento(oAgendaModel);
                            grdReservaProgramadaFesta.DataBind();

                        }
                        if (item.salaoChurrasco == true)
                        {
                            var churras = from churrasPendente in oAgendaBLL.pendentePagamento(oAgendaModel)
                                        where churrasPendente.salaoChurrasco == true
                                        select churrasPendente;


                            grdReservaProgramadaChurras.DataSource = churras;  //oAgendaBLL.pendentePagamento(oAgendaModel);
                            grdReservaProgramadaChurras.DataBind();

                        }

                    }
                    else
                    {
                        if (item.salaoFesta == true)
                        {

                            var churras = from churrasPendente in oAgendaBLL.pendentePagamento(oAgendaModel)
                                          where churrasPendente.salaoChurrasco == true
                                          select churrasPendente;

                            grdReservaProgramadaChurras.DataSource = churras;
                            grdReservaProgramadaChurras.DataBind();
                            
                            grdReservaProgramadaFesta.DataSource = oAgendaBLL.pendentePagamento(oAgendaModel);
                            grdReservaProgramadaFesta.DataBind();

                        }
                        if (item.salaoChurrasco == true)
                        {

                            var festa = from festaPendente in oAgendaBLL.pendentePagamento(oAgendaModel)
                                        where festaPendente.salaoFesta == true
                                        && festaPendente.salaoChurrasco == false
                                        select festaPendente;

                            grdReservaProgramadaFesta.DataSource = festa;
                            grdReservaProgramadaFesta.DataBind();

                            grdReservaProgramadaChurras.DataSource = oAgendaBLL.pendentePagamento(oAgendaModel);
                            grdReservaProgramadaChurras.DataBind();

                        }

                    }


                
            
        

            }


            
           
        }

        public void showAll()
        {
            grdReservaProgramadaChurras.Visible = true;
            grdReservaProgramadaFesta.Visible = true;
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("telaAgendamento.aspx");
        }

    }
}