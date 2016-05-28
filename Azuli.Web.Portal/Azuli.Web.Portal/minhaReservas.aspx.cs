using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Drawing;

namespace Azuli.Web.Portal
{
    public partial class minhaReservas : Util.Base
    {

        decimal SomaChurraqueira = 0;
        decimal TotalChurrasqueira = 0;
        decimal TotalFesta = 0;
        decimal SomaFesta = 0; 
        bool exportando = false;
        DateTime data = DateTime.Now;
        AgendaBLL oAgenda = new AgendaBLL();
        AgendaModel oAgendaModel = new AgendaModel();
        ApartamentoModel oAP = new ApartamentoModel();
        Util.Util oUtil = new Util.Util();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.Request.ServerVariables["http_user_agent"].ToLower().Contains("safari"))
                {
                    Page.ClientTarget = "uplevel";

                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (oUtil.validateSession())
            {
                if (!IsPostBack)
                {
                   
                    hiddenControl();
                    preencheMeses();
                  
                    preencheAno();
                    consultaReserva();

                }
            }
        }



        public void preencheMeses()
        {
            string mesCorrente = "";
            drpMeses.DataSource = Enum.GetNames(typeof(Util.Util.meses));


            mesCorrente = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(data.Month);

            drpMeses.Items.Add(mesCorrente); //drpMeses.Items.IndexOf(drpMeses.Items.FindByValue(data.Month.ToString()));
            drpMeses.SelectedIndex = data.Month - 1;
            drpMeses.DataBind();
        }

        public void preencheAno()
        {

            for (int ano = data.Year -4  ; ano <= data.Year; ano ++)
            {
                drpAno.Items.Add(ano.ToString());
             
            }
            drpAno.SelectedValue = data.Year.ToString();
        }

        public void hiddenControl()
        {
            dvChurrasco.Visible = false;
            dvFesta.Visible = false;
        }

        private void consultaReserva()
        {
            SomaChurraqueira = 0;
            SomaFesta = 0;

            oAgendaModel.dataAgendamento = Convert.ToDateTime(drpAno.SelectedItem.Value + "-" + drpMeses.SelectedItem.Value + "01");
            oAP.bloco = Convert.ToInt32(Session["Bloco"]);
            oAP.apartamento = Convert.ToInt32(Session["AP"]);

            if (drpSalao.SelectedItem.Text == "Festa")
            {
                dvFesta.Visible = true;
                dvChurrasco.Visible = false;
                grdReservaProgramadaFesta.DataSource = oAgenda.listaReservaByMoradorFesta(oAP, oAgendaModel);
                grdReservaProgramadaFesta.DataBind();

                //lblMsg.Visible = false;
               // lblMesAnoFesta.Text = drpMeses.SelectedItem.Text + " / " + drpAno.SelectedItem.Text;
            }
            else if (drpSalao.SelectedItem.Text == "Churrasqueira")
            {

                grdReservaProgramadaChurras.DataSource = oAgenda.listaReservaByMorador(oAP, oAgendaModel);
                grdReservaProgramadaChurras.DataBind();
                dvChurrasco.Visible = true;
                dvFesta.Visible = false;
              //  lblMsg.Visible = false;
               // lbMesAnoChurras.Text = drpMeses.SelectedItem.Text + " / " + drpAno.SelectedItem.Text;
            }
            else if (drpSalao.SelectedItem.Value == "1")
            {
                grdReservaProgramadaChurras.DataSource = oAgenda.listaReservaByMorador(oAP, oAgendaModel);
                grdReservaProgramadaChurras.DataBind();

                grdReservaProgramadaFesta.DataSource = oAgenda.listaReservaByMoradorFesta(oAP, oAgendaModel);
                grdReservaProgramadaFesta.DataBind();
              
                dvFesta.Visible = true;
               // lblMsg.Visible = false;
               // lblMesAnoFesta.Text = drpMeses.SelectedItem.Text + " / " + drpAno.SelectedItem.Text;
               // lbMesAnoChurras.Text = drpMeses.SelectedItem.Text + " / " + drpAno.SelectedItem.Text;
                dvChurrasco.Visible = true;
              
              //  lblMsg.Visible = false;


            }
            lblTotalAreas.Text = "Valor total do mês: (Churrasqueira/Salão): R$ " + (SomaFesta + SomaChurraqueira).ToString("N2");
         

        }


        protected void drpSalao_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultaReserva();
            
        }

        protected void drpMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultaReserva();
        }

        protected void drpAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultaReserva();

        }

        protected void grdAgendaMorador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            const bool  salaoFesta = true;
            const bool churrasqueira = false;
            DateTime dataAgendamento = new DateTime();
            string bloco = "";
            string ap = "";

            

            if (e.CommandName == "Delete")
            {
                

                int index = int.Parse((string)e.CommandArgument);
                dataAgendamento = Convert.ToDateTime(grdReservaProgramadaChurras.DataKeys[index]["dataAgendamento"]);
                if (validaCancelamento(dataAgendamento))
                {
                    bloco = Session["Bloco"].ToString();
                    ap = Session["Ap"].ToString();
                    oAP.apartamento = Convert.ToInt32(ap);
                    oAP.bloco = Convert.ToInt32(bloco);


                    try
                    {
                        oAgenda.cancelaAgendamentoMorador(dataAgendamento, oAP, salaoFesta, churrasqueira);
                        grdReservaProgramadaChurras.DataBind();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }
        }

        protected void grdAgendaMorador_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdAgendaMorador_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void grdChurras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            


            }

        protected void grdChurras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            const bool salaoFesta = false;
            const bool churrasqueira = true;
            DateTime dataAgendamento = new DateTime();
            string bloco = "";
            string ap = "";


            if (e.CommandName == "Delete")
            {


                int index = int.Parse((string)e.CommandArgument);
                dataAgendamento = Convert.ToDateTime(grdReservaProgramadaChurras.DataKeys[index]["dataAgendamento"]);

                if (validaCancelamento(dataAgendamento))
                {
                    bloco = Session["Bloco"].ToString();
                    ap = Session["Ap"].ToString();
                    oAP.apartamento = Convert.ToInt32(ap);
                    oAP.bloco = Convert.ToInt32(bloco);


                    try
                    {
                        oAgenda.cancelaAgendamentoMorador(dataAgendamento, oAP, salaoFesta, churrasqueira);
                        grdReservaProgramadaChurras.DataBind();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
        }
        }

        /// <summary>
        /// Regras para validar cancelamento de reservas de Apartamento
        /// </summary>
        /// <remarks>Autor: Edmilson
        /// data: 01/03/2013
        /// </remarks>
        /// <param name="dataAgendamento">dataAgendamento</param>
        /// <returns>True or false</returns>
        public bool validaCancelamento(DateTime dataAgendamento)
        {

            int diasAgendado;
            diasAgendado = ((TimeSpan)(dataAgendamento - DateTime.Now)).Days;
            if (diasAgendado >= 15)
            {
                return true;
            }

            else
            {
                //lblMsg.Visible = true;
                //lblMsg.Text = "Só é permitido o cancelamento com 15 dias de antecedência e hoje faltam " + diasAgendado + " dias para reserva.";
                
                return false;
            }
        }

        protected void grdReservaProgramadaFesta_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.ForeColor = Color.White;
                HeaderCell2.Font.Bold = true;
                HeaderCell2.Font.Size = 12;
                HeaderCell2.CssClass = "grid";
                HeaderCell2.Text = "Salão de Festa - " + drpMeses.Text + "/" + drpAno.Text;
                HeaderCell2.ColumnSpan = 7;
                HeaderCell2.BackColor = Color.Blue;

                HeaderRow.Cells.Add(HeaderCell2);
                grdReservaProgramadaFesta.Controls[0].Controls.AddAt(0, HeaderRow);

            }
        }

        protected void grdReservaProgramadaFesta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalFesta = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "valorReserva")); //Convert.ToDecimal(grdReservaProgramadaFesta.DataKeys[row.RowIndex].Values["valorReserva"].ToString());
                SomaFesta += TotalFesta;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lbltotalFesta");
                lbl.Text = "R$ " + SomaFesta.ToString("N2");

            }
        }

        protected void grdReservaProgramadaChurras_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.ForeColor = Color.White;
                HeaderCell2.Font.Bold = true;
                HeaderCell2.Font.Size = 12;
                HeaderCell2.Text = "Churrasqueira - " + drpMeses.Text + "/" + drpAno.Text;
                HeaderCell2.ColumnSpan = 7;
                HeaderCell2.BackColor = Color.Blue;

                HeaderRow.Cells.Add(HeaderCell2);
                grdReservaProgramadaChurras.Controls[0].Controls.AddAt(0, HeaderRow);

            }


        }

        protected void grdReservaProgramadaChurras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalChurrasqueira = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "valorReserva")); //Convert.ToDecimal(grdReservaProgramadaFesta.DataKeys[row.RowIndex].Values["valorReserva"].ToString());
                SomaChurraqueira += TotalChurrasqueira;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lbltotalChurras");
                lbl.Text = "R$ " + SomaChurraqueira.ToString("N2");

            }

        }

        protected void imgBtExcelFesta_Click(object sender, ImageClickEventArgs e)
        {
            if (grdReservaProgramadaFesta.Rows.Count > 0)
            {
               // lblarea.Text = "Reserva do Salão de Festa - " + drpMeses.SelectedItem.Text + "/" + drpAno.Text;
                exportando = true;
                exportando = true;

                Response.ClearContent();

                Response.AddHeader("content-disposition", "attachment;filename=SalaoFesta" + drpMeses.SelectedItem.Text + "/" + drpAno.Text + ".xls");

                Response.Charset = "";

                // If you want the option to open the Excel file without saving than

                // comment out the line below

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
                Response.Charset = "ISO-8859-1";
                EnableViewState = false;


                System.IO.StringWriter stringWrite = new System.IO.StringWriter();

                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                //lblarea.RenderControl(htmlWrite);
                grdReservaProgramadaFesta.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }

        }

        protected void imgBtExcelChurras_Click(object sender, ImageClickEventArgs e)
        {


            if (grdReservaProgramadaChurras.Rows.Count > 0)
            {
               // lblarea.Text = "Reserva da Churrasqueira - " + drpMeses.SelectedItem.Text + "/" + drpAno.Text;
                exportando = true;

                Response.ClearContent();

                Response.AddHeader("content-disposition", "attachment;filename=AreaChurrasco" + drpMeses.SelectedItem.Text + "/" + drpAno.Text + ".xls");

                Response.Charset = "";

                // If you want the option to open the Excel file without saving than

                // comment out the line below
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
                Response.Charset = "ISO-8859-1";
                EnableViewState = false;

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                Response.ContentType = "application/ms-excel";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();

                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                //  lblarea.RenderControl(htmlWrite);
                grdReservaProgramadaChurras.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }


        }
        /// <summary>
        /// Para nao dar Erro na Hora de Exportar....
        /// </summary>
        /// <param name="control"></param>
        public override void VerifyRenderingInServerForm(Control control)
        {
            if (!exportando)
            {
                base.VerifyRenderingInServerForm(control);
            }
        }
        

      
    }
}