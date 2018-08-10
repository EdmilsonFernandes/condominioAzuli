

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.Data;
using Azuli.Crystal;
using Azuli.Web.Business;
using Azuli.Web.Model;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Text;

namespace Azuli.Web.Portal
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        ApartamentoModel oAp = new ApartamentoModel();
        ProprietarioBLL oProprietario = new ProprietarioBLL();
        AgendaBLL oAgendaBLL = new AgendaBLL();
        AgendaModel oAgendaModel = new AgendaModel();
        Util.Util oUtil = new Util.Util();
        ConfiguracaoReservaBLL oConfigValor = new ConfiguracaoReservaBLL();

        // TODO: implementar o envio da água por e-mail, criar uma página aspx, que faz a gestão e envia o e-mail...
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToBoolean(Session["ReciboAgua"]) == true)
                {
                    if (oUtil.validateSession())
                    {
                        crystalReport();

                    }
                }

               //TODO: Esse metodo e sessão é responsável por mandar e-mail, quando for implementado deverá ser usado. 
                else if (Convert.ToBoolean(Session["EnviaEmailAgua"]) == true)
                {
                    if (oUtil.validateSession())
                    {

                        enviaReciboMoradorPorEmail();

                    }
                }

                else
                {

                    if (oUtil.validateSessionAdmin())
                    {
                        Recibo();

                    }
                }

            }


        }

        public void verificaExcenteCondominio()
        {

        }

        public class BancoExcel
        {
            public string parameters { get; set; }


        }



        public void Export(string fileName, listaSegundaViaAgua listAguaExcel)
        {






            ////The Clear method erases any buffered HTML output.
            //HttpContext.Current.Response.Clear();
            ////The AddHeader method adds a new HTML header and value to the response sent to the client.
            //HttpContext.Current.Response.AddHeader(
            //    "content-disposition", string.Format("attachment; filename={0}", fileName + ".xls"));
            ////The ContentType property specifies the HTTP content type for the response.
            //HttpContext.Current.Response.ContentType = "application/ms-excel";
            ////Implements a TextWriter for writing information to a string. The information is stored in an underlying StringBuilder.
            //using (StringWriter sw = new StringWriter())
            //{
            //    //Writes markup characters and text to an ASP.NET server control output stream. This class provides formatting capabilities that ASP.NET server controls use when rendering markup to clients.
            //    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            //    {
            //        //  Create a form to contain the List
            //        System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
            //        TableRow row = new TableRow();


            //         List<BancoExcel> listExcel = new List<BancoExcel>()
            //         {
            //             new BancoExcel{parameters="Registro"},
            //             new BancoExcel{parameters = "Apto"},
            //             new BancoExcel{parameters = "Histórico"},
            //             new BancoExcel{parameters = "Leitura Anterior"},
            //             new BancoExcel{parameters = "Leitura Atual"},
            //             new BancoExcel{parameters = "Consumo"},
            //             new BancoExcel{parameters = "Excedente M³"},
            //             new BancoExcel{parameters = "À pagar"},
            //             new BancoExcel{parameters = "Obs:"},

            //         };

            //        foreach(var item in  listExcel)
            //        {

            //            TableHeaderCell hcell = new TableHeaderCell();
            //            hcell.BorderColor = System.Drawing.Color.Black;
            //            hcell.Text = item.parameters;
            //            row.Cells.Add(hcell);
            //        }


            //        table.Rows.Add(row);


            //        var listAprove = from listaOrd in listAguaExcel
            //                         orderby listaOrd.registro ascending
            //                         select listaOrd;

            //        //  add each of the data item to the table
            //        foreach (ReciboAgua emp in listAprove)
            //        {
            //            TableRow row1 = new TableRow();
            //            TableCell cellAge = new TableCell();
            //            cellAge.Text = "" + emp.registro;
            //            TableCell cellName = new TableCell();
            //            cellName.Text = "" + Math.Round(emp.excedenteM3diaria * 30, 0);
            //            row1.Cells.Add(cellAge);
            //            row1.Cells.Add(cellName);
            //            table.Rows.Add(row1);
            //        }
            //        //  render the table into the htmlwriter
            //        table.RenderControl(htw);
            //        //  render the htmlwriter into the response
            //        HttpContext.Current.Response.Write(sw.ToString());
            //        HttpContext.Current.Response.End();

            //        Response.Redirect("~/GerarReciboAzuliAdm.aspx");


            //}
        }

        public void ReciboOld()
        {

            if (Convert.ToBoolean(Convert.ToBoolean(Session["chooseReport"]) == true))
            {
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 0;
                pg.Margins.Bottom = 0;
                pg.Margins.Left = 0;
                pg.Margins.Right = 0;
                System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
                size.RawKind = (int)PaperKind.Letter;
                pg.PaperSize = size;
                pg.Landscape = true;

                decimal somatudo = 0;
                ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
                ReciboAgua oReciboModel = new ReciboAgua();
                double totalExcedenteDinamico = 0;

                DSrecibo dsSegundaVia = new DSrecibo();


                string mes = Session["mes"].ToString();
                string ano = Session["ano"].ToString();



                var oListOrdenadoByRegistro = from listaOrdenada in oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano), Convert.ToInt32(mes))
                                              orderby listaOrdenada.registro ascending
                                              select listaOrdenada;


                listaSegundaViaAgua listExcel = oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano), Convert.ToInt32(mes));



                if (Convert.ToBoolean(Session["Excel"]) == true)
                {
                    Export(mes + "/" + ano, listExcel);
                }

                else
                {
                    try
                    {
                        foreach (var item in oListOrdenadoByRegistro)
                        {

                            if (Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) > 10)
                            {

                                totalExcedenteDinamico += Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) - 10;
                            }

                        }



                        foreach (var item in oListOrdenadoByRegistro)
                        {



                            DataRow drSegundaVia = dsSegundaVia.Tables[1].NewRow();

                            drSegundaVia["ID-Condomínio"] = item.idCondominio;
                            drSegundaVia["Nome do Condomínio"] = item.nomeCondominio;
                            drSegundaVia["Endereço do Condomínio"] = item.enderecoCondominio;
                            drSegundaVia["Bloco"] = item.bloco;
                            drSegundaVia["Apartamento"] = item.apartamento;
                            drSegundaVia["Registro"] = item.registro;
                            drSegundaVia["Fechamento Atual"] = item.fechamentoAtual;
                            drSegundaVia["Data leitura Anterior"] = item.dataLeituraAnterior;
                            drSegundaVia["Leitura Anterior M³"] = item.leituraAnteriorM3;
                            drSegundaVia["Data leitura Atual"] = item.dataLeituraAtual;
                            drSegundaVia["Leitura Atual M³"] = item.leituraAtualM3;

                            drSegundaVia["Consumo do Mês M³"] = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero);//item.consumoMesM3;// item.consumoMesM3;



                            //drSegundaVia["Consumo do Mês M³"] = Math.Round(item.excedenteM3diaria * 30, 0);//item.consumoMesM3;// item.consumoMesM3;
                            drSegundaVia["Data da próxima leitura"] = item.dataProximaLeitura;
                            drSegundaVia["status"] = item.status;
                            drSegundaVia["Média"] = item.media;
                            drSegundaVia["Histórico descricação mês1"] = item.historicoDescricaoMes1;
                            drSegundaVia["Histórico mês1"] = item.historicoMes1;
                            drSegundaVia["Histórico descricação mês2"] = item.historicoDescricaoMes2;
                            drSegundaVia["Histórico mês2"] = item.historicoMes2;
                            drSegundaVia["Histórico descricação mês3"] = item.historicoDescricaoMes3;
                            drSegundaVia["Histórico mês3"] = item.historicoMes3;
                            drSegundaVia["Histórico descricação mês4"] = item.historicoDescricaoMes4;
                            drSegundaVia["Histórico mês4"] = item.historicoMes4;
                            drSegundaVia["Histórico descricação mês5"] = item.historicoDescricaoMes5;
                            drSegundaVia["Histórico mês5"] = item.historicoMes5;
                            drSegundaVia["Histórico descricação mês6"] = item.historicoDescricaoMes6;
                            drSegundaVia["Histórico mês6"] = item.historicoMes6;

                            // Virá do banco quando o consumo - se maior que 2400 fara o valor do rateio
                            //item.consumoM3pagoCondominio = 2600;
                            // o Valor pago do condominio virá do banco também...
                            //item.ConsumoValorPagoCondominio = 7900;

                            //Isto ficará fixo - Será a diferença paga entre o valor pago do consumo minimo, e o consumo e excedente
                            item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);

                            drSegundaVia["Consumo Valor"] = item.ConsumoValorPagoCondominio;
                            drSegundaVia["Consumo M³"] = item.consumoM3pagoCondominio;

                            drSegundaVia["Mínimo M³"] = item.minimoM3PagoCondominio;
                            drSegundaVia["Mínimo Valor"] = item.minimoValorPagoCondominio;

                            drSegundaVia["Excedente Valor"] = item.excedenteValorPagoCondominio;
                            drSegundaVia["Tarifa Mínima M³"] = item.tarifaMinimaM3ValorDevido;
                            drSegundaVia["Tarifa Mínima Valor"] = item.tarifaMinimaValorValorDevido;



                            //var dir = System.Configuration.ConfigurationManager.AppSettings["relatorioGeral"];

                            //StreamWriter details = new StreamWriter("D:\\DZHosts\\LocalUser\\edmls34\\www.azulicondominio.com\\relatorio"+mes+ano+".txt",true,Encoding.ASCII);
                            //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...

                            if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                            {
                                item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;


                                item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                                item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                                somatudo += item.valorPagarValorDevido;

                                drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                                drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                                drSegundaVia["a pagar"] = item.valorPagarValorDevido;





                                //details.WriteLine(item.bloco + " " + item.apartamento + " " + item.valorPagarValorDevido);


                            }
                            //Se não mantêm o valor sem rateio..
                            else
                            {
                                drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                                drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                                drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                            }

                            //details.Close();

                            drSegundaVia["ExcedenteM3Rateio"] = totalExcedenteDinamico;
                            drSegundaVia["Geral"] = item.avisoGeralAviso;
                            drSegundaVia["Anormal"] = item.AnormalAviso;
                            drSegundaVia["Invididual"] = item.individualAviso;
                            drSegundaVia["ANORMALIDADE"] = item.anormalidadeAviso;
                            drSegundaVia["Imagem"] = item.imagem;
                            drSegundaVia["ExcedenteValorDevido"] = item.excedenteValorDevido;
                            drSegundaVia["excedenteM3Diario"] = item.excedenteM3diaria;

                            dsSegundaVia.Tables[1].Rows.Add(drSegundaVia);


                        }



                        Crystal.Relatorios.ReciboMoradorByApBloco rbSegundaVia = new Crystal.Relatorios.ReciboMoradorByApBloco();

                        rbSegundaVia.SetDataSource(dsSegundaVia);

                        rbSegundaVia.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo");
                    }

                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }


            else
            {
                if (Session["reciboConfirmadoNoAto"] != null && (int)Session["reciboConfirmadoNoAto"] == 1)
                {

                    oAp.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);
                    oAp.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
                    oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaAdministrador"]);
                    oAgendaModel.ap = oAp;

                }
                else
                {

                    oAp.apartamento = Convert.ToInt32(Session["aptoSession"]);
                    oAp.bloco = Convert.ToInt32(Session["blocoSession"]);
                    oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
                    oAgendaModel.ap = oAp;
                }

                try
                {
                    DSrecibo dsRecibo = new DSrecibo();
                    DataRow drRecibo = dsRecibo.Tables[0].NewRow();

                    foreach (var item in oAgendaBLL.geraReciboPago(oAgendaModel))
                    {
                        drRecibo["DIA"] = DateTime.Now.Day;
                        drRecibo["MES"] = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
                        drRecibo["ANO"] = DateTime.Now.Year;
                        if (item.salaoChurrasco == true && item.salaoFesta == true)
                        {
                            foreach (var Desconto in oConfigValor.oListaValorReserva())
                            {
                                if (Desconto.id_valor == 3)
                                {
                                    drRecibo["VALOR_POR_EXTENSO"] = new Util.NumeroPorExtenso(Convert.ToDecimal(item.valorReserva - Desconto.valor));
                                    drRecibo["VALOR"] = item.valorReserva - Desconto.valor + ",00";

                                }

                            }

                        }
                        else
                        {
                            drRecibo["VALOR_POR_EXTENSO"] = new Util.NumeroPorExtenso(Convert.ToDecimal(item.valorReserva));
                            drRecibo["VALOR"] = item.valorReserva + ",00";
                        }

                        drRecibo["PROPRIETARIO"] = "0" + item.ap.bloco + " - " + item.ap.apartamento + " - " + item.ap.oProprietario.proprietario1;
                        drRecibo["Descricao"] = item.observacao;



                    }






                    //string caminhoRelatorio = ConfigurationManager.AppSettings["ReportsPath"] + ConfigurationManager.AppSettings["reciboReserva"];

                    //rpt.Load(caminhoRelatorio);

                    // rpt.SetDataSource(drRecibo);

                    dsRecibo.Tables[0].Rows.Add(drRecibo);

                    Crystal.Relatorios.ReciboReserva rbReserva = new Crystal.Relatorios.ReciboReserva();

                    rbReserva.SetDataSource(dsRecibo);

                    CrystalReportViewer1.ReportSource = rbReserva;

                    rbReserva.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo");




                }

                catch (Exception ex)
                {

                    throw ex;
                }


            }
        }





        public void Recibo()
        {

            string mes = Session["mes"].ToString();
            string ano = Session["ano"].ToString();

           
            if (Convert.ToInt32(ano) <= 2015) 
            {
                ReciboOld();

            }
            else  if (Convert.ToInt32(mes) == 1 &&  Convert.ToInt32(ano) == 2016) 
            {
                ReciboOld();
            }

            else if (Convert.ToInt32(mes) == 2 && Convert.ToInt32(ano) == 2016) 
            {
                ReciboOld();
            }
          
            else
            {

                if (Convert.ToBoolean(Convert.ToBoolean(Session["chooseReport"]) == true))
                {


                    System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                    pg.Margins.Top = 0;
                    pg.Margins.Bottom = 0;
                    pg.Margins.Left = 0;
                    pg.Margins.Right = 0;
                    System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
                    size.RawKind = (int)PaperKind.Letter;
                    pg.PaperSize = size;
                    pg.Landscape = true;

                    //TODO:FicarConfigurável
                    bool IsConsumoCondominio = false;

                    //**********************/

                    int validaPersistCalculoCorreto = 0;
                    ListaSabesp oListLeituraSabesp = new ListaSabesp();
                    LeituraSabespBLL oLeituraBussiness = new LeituraSabespBLL();
                    decimal somatudo = 0;
                    ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
                    Util.RelatorioConfigRecibo oCarregaVariaveisRecibo = new Util.RelatorioConfigRecibo();
                    double totalExcedenteDinamico = 0;
                    double totalConsumoExcedenteMorador = 0;
                    double consumoMorador = 0;
                    double totalconsumoVariavelDiasAzuli30d = 0;
                    double totalExcedenteConsumoAzuli30d = 0;
                    double valorExcedentePagoCondominio = 0;
                    double totalExdenteAreaComumMorador = 0; // 1014 tt area comum + excedente morador
                    double diasAzuli = 0;
                    double consumoDoCondominio = 0;
                    double valorM3Excedente = 0;
                    DSrecibo dsSegundaVia = new DSrecibo();
                    int diasLeituraSabesp = 0;

                    validaPersistCalculoCorreto =  oReciboBLL.validaPersistenciaAgua(Convert.ToInt32(mes),Convert.ToInt32(ano));

                    // Entra neste if, quando for executado apenas a primeira vez
                    // Neste momento ele faz o cálculo, e cadastra no banco para consultas diretas.
                    if (validaPersistCalculoCorreto <= 0)
                    {


                        int mesReferenciaSabesp = Convert.ToInt32(mes);

                        oListLeituraSabesp = oLeituraBussiness.buscaLeitura(mesReferenciaSabesp.ToString(), ano);


                        foreach (var item in oListLeituraSabesp)
                        {
                            diasLeituraSabesp = item.dias;
                        }


                        var oListOrdenadoByRegistro = from listaOrdenada in oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano), Convert.ToInt32(mes))
                                                      orderby listaOrdenada.registro ascending
                                                      select listaOrdenada;


                        if (Convert.ToBoolean(Session["Excel"]) == true)
                        {
                            listaSegundaViaAgua listExcel = oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano), Convert.ToInt32(mes));
                            Export(mes + "/" + ano, listExcel);
                        }

                        else
                        {
                            try
                            {
                                foreach (var item in oListOrdenadoByRegistro)
                                {
                                    if (!IsConsumoCondominio)
                                    {
                                        TimeSpan date = Convert.ToDateTime(item.dataLeituraAtual.Replace("Leitura Atual (", "").Replace("):", "")) - Convert.ToDateTime(item.dataLeituraAnterior.Replace("Leitura anterior (", "").Replace("):", ""));
                                        diasAzuli = date.Days;

                                        valorExcedentePagoCondominio = Convert.ToDouble(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                                        consumoDoCondominio = item.consumoM3pagoCondominio;
                                        IsConsumoCondominio = true;
                                    }

                                    consumoMorador = Math.Round((Convert.ToDouble(item.leituraAtualM3) - Convert.ToDouble(item.leituraAnteriorM3)) / diasAzuli * diasLeituraSabesp, MidpointRounding.AwayFromZero);

                                    if (consumoMorador > 10)
                                    {

                                        totalExcedenteDinamico += consumoMorador - 10;

                                    }
                                    totalConsumoExcedenteMorador += consumoMorador;
                                }


                                /* -------- Calcula Leitura Azuli - Dias de leituras Azuli   */

                                totalconsumoVariavelDiasAzuli30d = Math.Round(((totalConsumoExcedenteMorador / diasLeituraSabesp) * diasAzuli) / diasAzuli * diasLeituraSabesp, MidpointRounding.AwayFromZero);
                                totalExcedenteConsumoAzuli30d = Math.Round(totalExcedenteDinamico / diasLeituraSabesp * diasAzuli / diasAzuli * diasLeituraSabesp, MidpointRounding.AwayFromZero);

                                double areaComumConsumo = consumoDoCondominio - totalconsumoVariavelDiasAzuli30d;

                                if (areaComumConsumo < 0 || consumoDoCondominio <= 2400)
                                {
                                    areaComumConsumo = 0;
                                }


                                totalExdenteAreaComumMorador = Math.Round(totalExcedenteConsumoAzuli30d + areaComumConsumo, MidpointRounding.AwayFromZero);


                                valorM3Excedente = Math.Round(valorExcedentePagoCondominio / totalExdenteAreaComumMorador + 0.001, 4);
                                /* ------------------------------------------------------------------------------------- */

                                foreach (var item in oListOrdenadoByRegistro)
                                {
                                    ReciboAgua oReciboModel = new ReciboAgua();
                                    DataRow drSegundaVia = dsSegundaVia.Tables[1].NewRow();
                                    int consumoIndividualMensal = Convert.ToInt32(Math.Round((Convert.ToDouble(item.leituraAtualM3) - Convert.ToDouble(item.leituraAnteriorM3)) / diasAzuli * diasLeituraSabesp, MidpointRounding.AwayFromZero));

                                    oReciboModel.mes = Convert.ToInt32(mes);
                                    oReciboModel.ano = Convert.ToInt32(ano);
                                    
                                    int mesConvertido = Convert.ToInt32(mes) - 1;
                                    int anoConvertido = Convert.ToInt32(ano);

                                    drSegundaVia["ID-Condomínio"] = item.idCondominio;
                                    oReciboModel.idCondominio = item.idCondominio;

                                    drSegundaVia["Nome do Condomínio"] = item.nomeCondominio;
                                    oReciboModel.nomeCondominio = item.nomeCondominio;

                                    drSegundaVia["Endereço do Condomínio"] = item.enderecoCondominio;
                                    oReciboModel.enderecoCondominio = item.enderecoCondominio;

                                    drSegundaVia["Bloco"] = item.bloco;
                                    oReciboModel.bloco = item.bloco;

                                    drSegundaVia["Apartamento"] = item.apartamento;
                                    oReciboModel.apartamento = item.apartamento;

                                    drSegundaVia["Registro"] = item.registro;
                                    oReciboModel.registro = item.registro;

                                    drSegundaVia["Fechamento Atual"] = item.fechamentoAtual;
                                    oReciboModel.fechamentoAtual = item.fechamentoAtual;

                                    drSegundaVia["Data leitura Anterior"] = item.dataLeituraAnterior;
                                    oReciboModel.dataLeituraAnterior = item.dataLeituraAnterior;

                                    drSegundaVia["Leitura Anterior M³"] = item.leituraAnteriorM3;
                                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;

                                    drSegundaVia["Data leitura Atual"] = item.dataLeituraAtual;
                                    oReciboModel.dataLeituraAtual = item.dataLeituraAtual;

                                    drSegundaVia["Leitura Atual M³"] = item.leituraAtualM3;
                                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;

                                    drSegundaVia["Consumo do Mês M³"] = consumoIndividualMensal;
                                    oReciboModel.consumoMesM3 = consumoIndividualMensal.ToString();

                                    //drSegundaVia["Consumo do Mês M³"] = Math.Round(item.excedenteM3diaria * 30, 0);//item.consumoMesM3;// item.consumoMesM3;
                                    drSegundaVia["Data da próxima leitura"] = item.dataProximaLeitura;
                                    oReciboModel.dataProximaLeitura = item.dataProximaLeitura;

                                    drSegundaVia["status"] = item.status;
                                    oReciboModel.status = item.status;

                                    drSegundaVia["Média"] = item.media;
                                    oReciboModel.media = item.media;

                                    int media = 0;

                                    int consumoHistory = 0;
                                    for (int i = 1; i <= 6; i++)
                                    {

                                        if (mesConvertido == 0)
                                        {
                                            anoConvertido = anoConvertido - 1;
                                            mesConvertido = 12;
                                        }

                                        if (i == 1)
                                        {
                                            drSegundaVia["Histórico descricação mês1"] = item.historicoDescricaoMes1;
                                            oReciboModel.historicoDescricaoMes1 = item.historicoDescricaoMes1;

                                            consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                            drSegundaVia["Histórico mês1"] = consumoHistory;
                                            oReciboModel.historicoMes1 = consumoHistory.ToString() + " m³";
                                            media += consumoHistory;
                                            consumoHistory = 0;

                                            //oReciboModel.historicoMes1 = item.historicoMes1;
                                        }
                                        else if (i == 2)
                                        {
                                            drSegundaVia["Histórico descricação mês2"] = item.historicoDescricaoMes2;
                                            oReciboModel.historicoDescricaoMes2 = item.historicoDescricaoMes2;

                                            consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                            drSegundaVia["Histórico mês2"] = consumoHistory;//item.historicoMes2;
                                            oReciboModel.historicoMes2 = consumoHistory.ToString() + " m³";//item.historicoMes2;
                                            media += consumoHistory;
                                            consumoHistory = 0;
                                        }
                                        else if (i == 3)
                                        {


                                            drSegundaVia["Histórico descricação mês3"] = item.historicoDescricaoMes3;
                                            oReciboModel.historicoDescricaoMes3 = item.historicoDescricaoMes3;

                                
                                            consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                            drSegundaVia["Histórico mês3"] = consumoHistory;// item.historicoMes3;
                                            oReciboModel.historicoMes3 = consumoHistory.ToString() + " m³";// item.historicoMes3;
                                            media += consumoHistory;
                                            consumoHistory = 0;
                                        }
                                        else if (i == 4)
                                        {

                                            drSegundaVia["Histórico descricação mês4"] = item.historicoDescricaoMes4;
                                            oReciboModel.historicoDescricaoMes4 = item.historicoDescricaoMes4;

                                   
                                             consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                             drSegundaVia["Histórico mês4"] = consumoHistory;//item.historicoMes4;
                                             oReciboModel.historicoMes4 = consumoHistory.ToString() + " m³"; //item.historicoMes4;
                                             media += consumoHistory;
                                            consumoHistory = 0;
                                        }

                                        else if (i == 5)
                                        {

                                            drSegundaVia["Histórico descricação mês5"] = item.historicoDescricaoMes5;
                                            oReciboModel.historicoDescricaoMes5 = item.historicoDescricaoMes5;
                                            consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                            drSegundaVia["Histórico mês5"] = consumoHistory;//item.historicoMes5;
                                            media += consumoHistory;
                                            oReciboModel.historicoMes5 = consumoHistory.ToString() + " m³";//item.historicoMes5;
                                        }
                                        else if (i == 6)
                                        {

                                            drSegundaVia["Histórico descricação mês6"] = item.historicoDescricaoMes6;
                                            oReciboModel.historicoDescricaoMes6 = item.historicoDescricaoMes6;
                                            consumoHistory = oReciboBLL.retornaConsumoHistorico(mesConvertido, anoConvertido, Convert.ToInt32(item.bloco), Convert.ToInt32(item.apartamento));//item.historicoMes1; 
                                            drSegundaVia["Histórico mês6"] = consumoHistory;//item.historicoMes6;
                                            oReciboModel.historicoMes6 =consumoHistory.ToString() + " m³";// item.historicoMes6;
                                            media += consumoHistory;
                                            consumoHistory = 0;

                                        }

                                           mesConvertido--;
                                    }


                                    drSegundaVia["Média"] = media / 6;
                                    oReciboModel.media = (media / 6).ToString();
                                    

                                    // Virá do banco quando o consumo - se maior que 2400 fara o valor do rateio
                                    //item.consumoM3pagoCondominio = 2600;
                                    // o Valor pago do condominio virá do banco também...
                                    //item.ConsumoValorPagoCondominio = 7900;

                                    //Isto ficará fixo - Será a diferença paga entre o valor pago do consumo minimo, e o consumo e excedente
                                    item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);

                                    drSegundaVia["Consumo Valor"] = item.ConsumoValorPagoCondominio;
                                    oReciboModel.ConsumoValorPagoCondominio = item.ConsumoValorPagoCondominio;

                                    drSegundaVia["Consumo M³"] = item.consumoM3pagoCondominio;
                                    oReciboModel.consumoM3pagoCondominio = item.consumoM3pagoCondominio;

                                    drSegundaVia["Mínimo M³"] = item.minimoM3PagoCondominio;
                                    oReciboModel.minimoM3PagoCondominio = item.minimoM3PagoCondominio;

                                    drSegundaVia["Mínimo Valor"] = item.minimoValorPagoCondominio;
                                    oReciboModel.minimoValorPagoCondominio = item.minimoValorPagoCondominio;

                                    drSegundaVia["Excedente Valor"] = item.excedenteValorPagoCondominio;
                                    oReciboModel.excedenteValorPagoCondominio = item.excedenteValorPagoCondominio;

                                    drSegundaVia["Tarifa Mínima M³"] = item.tarifaMinimaM3ValorDevido;
                                    oReciboModel.tarifaMinimaM3ValorDevido = item.tarifaMinimaM3ValorDevido;

                                    drSegundaVia["Tarifa Mínima Valor"] = item.tarifaMinimaValorValorDevido;
                                    oReciboModel.tarifaMinimaValorValorDevido = item.tarifaMinimaValorValorDevido;


                                    //var dir = System.Configuration.ConfigurationManager.AppSettings["relatorioGeral"];

                                    //StreamWriter details = new StreamWriter("D:\\DZHosts\\LocalUser\\edmls34\\www.azulicondominio.com\\relatorio"+mes+ano+".txt",true,Encoding.ASCII);
                                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...

                                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                                    {

                                        /* Calcula consumo estimativa leitura de dias da Sabesp, pegando o valor do m3 por excedente, e também calcula a area comum */

                                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                                        //totalExcenteAreaComumMorador = (item.consumoM3pagoCondominio - totalConsumoExcedenteMorador) + totalExcedenteDinamico;
                                        //item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                                        //M³ incluindo area comum..
                                        //item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExdenteAreaComumMorador + 0.0005,MidpointRounding.AwayFromZero));

                                        item.excedenteValorRateio = Convert.ToDecimal(valorM3Excedente);
                                        if (consumoIndividualMensal > 10)
                                        {
                                            drSegundaVia["ExcedenteValorDevido"] = consumoIndividualMensal - 10;
                                            oReciboModel.excedenteValorDevido = Convert.ToDecimal(drSegundaVia["ExcedenteValorDevido"]);

                                            item.valorPagarValorDevido = Math.Round(Convert.ToDecimal(consumoIndividualMensal - 10) * item.excedenteValorRateio - Convert.ToDecimal(0.0005), 3);
                                            somatudo += item.valorPagarValorDevido;
                                        }
                                        else
                                        {
                                            drSegundaVia["ExcedenteValorDevido"] = 0L;
                                            oReciboModel.excedenteValorDevido = 0L;
                                            item.valorPagarValorDevido = 0L;
                                        }


                                        drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                                        oReciboModel.excedenteM3PagoCondominio = item.excedenteM3PagoCondominio;

                                        drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                                        oReciboModel.excedenteValorRateio = item.excedenteValorRateio;




                                        drSegundaVia["a pagar"] = Math.Truncate(item.valorPagarValorDevido * 100) / 100;  //Math.Round(item.valorPagarValorDevido, 2);
                                        oReciboModel.valorPagarValorDevido = Math.Truncate(item.valorPagarValorDevido * 100) / 100;






                                        //details.WriteLine(item.bloco + " " + item.apartamento + " " + item.valorPagarValorDevido);


                                    }
                                    //Se não mantêm o valor sem rateio..
                                    else
                                    {
                                        if (consumoIndividualMensal > 10)
                                        {
                                            drSegundaVia["ExcedenteValorDevido"] = consumoIndividualMensal - 10;
                                            oReciboModel.excedenteValorDevido = Convert.ToDecimal(drSegundaVia["ExcedenteValorDevido"]);
                                        }
                                        else
                                        {
                                            drSegundaVia["ExcedenteValorDevido"] = 0L;
                                            oReciboModel.excedenteValorDevido = 0L;
                                        }

                                        drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                                        oReciboModel.excedenteM3PagoCondominio = item.excedenteM3PagoCondominio;


                                        drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                                        oReciboModel.excedenteValorRateio = item.excedenteValorRateio;

                                        drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                                    }

                                    //details.Close();

                                    drSegundaVia["ExcedenteM3Rateio"] = totalExdenteAreaComumMorador;
                                    oReciboModel.excedenteM3Rateio = Convert.ToInt32(totalExdenteAreaComumMorador);

                                    drSegundaVia["Geral"] = item.avisoGeralAviso;
                                    oReciboModel.avisoGeralAviso = item.avisoGeralAviso;

                                    drSegundaVia["Anormal"] = item.AnormalAviso;
                                    oReciboModel.AnormalAviso = item.AnormalAviso;

                                    drSegundaVia["Invididual"] = item.individualAviso;//"-> O ajuste no sistema foi realizado, haverá desconto na conta de junho/2016, para aqueles que excederam à 10 M³ na conta de maio/2016."; //item.individualAviso;
                                    oReciboModel.individualAviso = item.individualAviso;

                                    drSegundaVia["ANORMALIDADE"] = item.anormalidadeAviso;
                                    oReciboModel.anormalidadeAviso = item.anormalidadeAviso;

                                    drSegundaVia["Imagem"] = item.imagem;
                                    oReciboModel.imagem = item.imagem;

                                    drSegundaVia["excedenteM3Diario"] = Convert.ToDouble(consumoIndividualMensal) / Convert.ToDouble(diasLeituraSabesp);//item.excedenteM3diaria;
                                    oReciboModel.excedenteM3diaria = Convert.ToSingle(Convert.ToDouble(consumoIndividualMensal) / Convert.ToDouble(diasLeituraSabesp));

                                    dsSegundaVia.Tables[1].Rows.Add(drSegundaVia);

                                    oReciboBLL.persisteCalculoFinalBanco(oReciboModel);
                                    oReciboModel = null;
                                }



                                Crystal.Relatorios.ReciboMoradorByApBloco rbSegundaVia = new Crystal.Relatorios.ReciboMoradorByApBloco();

                                rbSegundaVia.SetDataSource(dsSegundaVia);

                                rbSegundaVia.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo");
                            }

                            catch (Exception ex)
                            {

                                throw ex;
                            }


                        }

                    }
                    else
                    {

                        var oListOrdenadoByRegistroJaCalculado = from listaOrdenada in oReciboBLL.buscaRecibosCalculadosByMesAno(Convert.ToInt32(ano), Convert.ToInt32(mes))
                                                      orderby listaOrdenada.registro ascending
                                                      select listaOrdenada;


                        foreach (var item in oListOrdenadoByRegistroJaCalculado)
                        {
                        
                            DataRow drSegundaVia = dsSegundaVia.Tables[1].NewRow();
                            drSegundaVia["ID-Condomínio"] = item.idCondominio;
                            drSegundaVia["Nome do Condomínio"] = item.nomeCondominio;
                            drSegundaVia["Endereço do Condomínio"] = item.enderecoCondominio;
                            drSegundaVia["Bloco"] = item.bloco;
                            drSegundaVia["Apartamento"] = item.apartamento;
                            drSegundaVia["Registro"] = item.registro;
                            drSegundaVia["Fechamento Atual"] = item.fechamentoAtual;
                            drSegundaVia["Data leitura Anterior"] = item.dataLeituraAnterior;
                            drSegundaVia["Leitura Anterior M³"] = item.leituraAnteriorM3;
                            drSegundaVia["Data leitura Atual"] = item.dataLeituraAtual;
                            drSegundaVia["Leitura Atual M³"] = item.leituraAtualM3;
                            drSegundaVia["Consumo do Mês M³"] = item.consumoMesM3;
                            drSegundaVia["Data da próxima leitura"] = item.dataProximaLeitura;
                            drSegundaVia["Média"] = item.media;
                            drSegundaVia["Histórico descricação mês1"] = item.historicoDescricaoMes1;
                            drSegundaVia["Histórico mês1"] = item.historicoMes1;
                            drSegundaVia["Histórico descricação mês2"] = item.historicoDescricaoMes2;
                            drSegundaVia["Histórico mês2"] = item.historicoMes2;
                            drSegundaVia["Histórico descricação mês3"] = item.historicoDescricaoMes3;
                            drSegundaVia["Histórico mês3"] = item.historicoMes3;
                            drSegundaVia["Histórico descricação mês4"] = item.historicoDescricaoMes4;
                            drSegundaVia["Histórico mês4"] = item.historicoMes4;
                            drSegundaVia["Histórico descricação mês5"] = item.historicoDescricaoMes5;
                            drSegundaVia["Histórico mês5"] = item.historicoMes5;
                            drSegundaVia["Histórico descricação mês6"] = item.historicoDescricaoMes6;
                            drSegundaVia["Histórico mês6"] = item.historicoMes6;
                            drSegundaVia["Consumo Valor"] = item.ConsumoValorPagoCondominio;
                            drSegundaVia["Consumo M³"] = item.consumoM3pagoCondominio;
                            drSegundaVia["Mínimo M³"] = item.minimoM3PagoCondominio;
                            drSegundaVia["Mínimo Valor"] = item.minimoValorPagoCondominio;
                            drSegundaVia["Excedente Valor"] = item.excedenteValorPagoCondominio;
                            drSegundaVia["Tarifa Mínima M³"] = item.tarifaMinimaM3ValorDevido;
                            drSegundaVia["Tarifa Mínima Valor"] = item.tarifaMinimaValorValorDevido;
                            drSegundaVia["ExcedenteValorDevido"] =  item.excedenteValorDevido;
                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                            drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteM3Rateio"] = item.excedenteM3Rateio;
                            drSegundaVia["Geral"] = item.avisoGeralAviso;
                            drSegundaVia["Anormal"] = item.AnormalAviso;
                            drSegundaVia["Invididual"] = item.individualAviso;
                            drSegundaVia["ANORMALIDADE"] = item.anormalidadeAviso;
                            drSegundaVia["Imagem"] = item.imagem;
                            drSegundaVia["excedenteM3Diario"] = item.excedenteM3diaria;
                            drSegundaVia["status"] = item.status;
                           

                            dsSegundaVia.Tables[1].Rows.Add(drSegundaVia);

                        }

                        Crystal.Relatorios.ReciboMoradorByApBloco rbSegundaVia = new Crystal.Relatorios.ReciboMoradorByApBloco();

                        rbSegundaVia.SetDataSource(dsSegundaVia);

                        rbSegundaVia.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo-"+ano+mes);


                    }
                        
                        
                }


                else
                {
                    if (Session["reciboConfirmadoNoAto"] != null && (int)Session["reciboConfirmadoNoAto"] == 1)
                    {

                        oAp.apartamento = Convert.ToInt32(Session["MoradorSemInternetAP"]);
                        oAp.bloco = Convert.ToInt32(Session["MoradorSemInternetBloco"]);
                        oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaAdministrador"]);
                        oAgendaModel.ap = oAp;

                    }
                    else
                    {

                        oAp.apartamento = Convert.ToInt32(Session["aptoSession"]);
                        oAp.bloco = Convert.ToInt32(Session["blocoSession"]);
                        oAgendaModel.dataAgendamento = Convert.ToDateTime(Session["dataReservaOnline"]);
                        oAgendaModel.ap = oAp;
                    }

                    try
                    {
                        DSrecibo dsRecibo = new DSrecibo();
                        DataRow drRecibo = dsRecibo.Tables[0].NewRow();

                        foreach (var item in oAgendaBLL.geraReciboPago(oAgendaModel))
                        {
                            drRecibo["DIA"] = DateTime.Now.Day;
                            drRecibo["MES"] = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
                            drRecibo["ANO"] = DateTime.Now.Year;
                            if (item.salaoChurrasco == true && item.salaoFesta == true)
                            {
                                foreach (var Desconto in oConfigValor.oListaValorReserva())
                                {
                                    if (Desconto.id_valor == 3)
                                    {
                                        drRecibo["VALOR_POR_EXTENSO"] = new Util.NumeroPorExtenso(Convert.ToDecimal(item.valorReserva - Desconto.valor));
                                        drRecibo["VALOR"] = item.valorReserva - Desconto.valor + ",00";

                                    }

                                }

                            }
                            else
                            {
                                drRecibo["VALOR_POR_EXTENSO"] = new Util.NumeroPorExtenso(Convert.ToDecimal(item.valorReserva));
                                drRecibo["VALOR"] = item.valorReserva + ",00";
                            }

                            drRecibo["PROPRIETARIO"] = "0" + item.ap.bloco + " - " + item.ap.apartamento + " - " + item.ap.oProprietario.proprietario1;
                            drRecibo["Descricao"] = item.observacao;



                        }


                        //string caminhoRelatorio = ConfigurationManager.AppSettings["ReportsPath"] + ConfigurationManager.AppSettings["reciboReserva"];

                        //rpt.Load(caminhoRelatorio);

                        // rpt.SetDataSource(drRecibo);

                        dsRecibo.Tables[0].Rows.Add(drRecibo);

                        Crystal.Relatorios.ReciboReserva rbReserva = new Crystal.Relatorios.ReciboReserva();

                        rbReserva.SetDataSource(dsRecibo);

                        CrystalReportViewer1.ReportSource = rbReserva;

                        rbReserva.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo");




                    }

                    catch (Exception ex)
                    {

                        throw ex;
                    }


                }
            }
        }

        private void enviaReciboMoradorPorEmail()
        {

            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
            size.RawKind = (int)PaperKind.Letter;
            pg.PaperSize = size;
            pg.Landscape = true;


            ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
            ReciboAgua oReciboModel = new ReciboAgua();
           
            DSrecibo dsSegundaVia = new DSrecibo();
          
            
            try
            {
                string fileNameRecibo = "";
                listProprietario oListaFromProprietario = new listProprietario();

                oListaFromProprietario = oProprietario.listaProprietarioSendEmail();

                foreach (var enviaEmail in oListaFromProprietario)
                {

                    oReciboModel.bloco = enviaEmail.ap.bloco.ToString(); ;
                    oReciboModel.apartamento = enviaEmail.ap.apartamento.ToString();
                    oReciboModel.ano = Convert.ToInt32(Session["ano"].ToString());
                    oReciboModel.mes = Convert.ToInt32(Session["mes"].ToString());

                    fileNameRecibo = @"C:\Desenvolvimento\reciboAguaBloco_"+oReciboModel.bloco+"AP_"+oReciboModel.apartamento+"Mes_"+oReciboModel.mes+"Ano_"+oReciboModel.ano+".pdf";

                    foreach (var item in oReciboBLL.buscaTodosRecibosByBlocoAndApto(oReciboModel))
                    {
                        DataRow drSegundaVia = dsSegundaVia.Tables[1].NewRow();
                        drSegundaVia["ID-Condomínio"] = item.idCondominio;
                        drSegundaVia["Nome do Condomínio"] = item.nomeCondominio;
                        drSegundaVia["Endereço do Condomínio"] = item.enderecoCondominio;
                        drSegundaVia["Bloco"] = item.bloco;
                        drSegundaVia["Apartamento"] = item.apartamento;
                        drSegundaVia["Registro"] = item.registro;
                        drSegundaVia["Fechamento Atual"] = item.fechamentoAtual;
                        drSegundaVia["Data leitura Anterior"] = item.dataLeituraAnterior;
                        drSegundaVia["Leitura Anterior M³"] = item.leituraAnteriorM3;
                        drSegundaVia["Data leitura Atual"] = item.dataLeituraAtual;
                        drSegundaVia["Leitura Atual M³"] = item.leituraAtualM3;
                        drSegundaVia["Consumo do Mês M³"] = item.consumoMesM3;
                        drSegundaVia["Data da próxima leitura"] = item.dataProximaLeitura;
                        drSegundaVia["status"] = item.status;
                        drSegundaVia["Média"] = item.media;
                        drSegundaVia["Histórico descricação mês1"] = item.historicoDescricaoMes1;
                        drSegundaVia["Histórico mês1"] = item.historicoMes1;
                        drSegundaVia["Histórico descricação mês2"] = item.historicoDescricaoMes2;
                        drSegundaVia["Histórico mês2"] = item.historicoMes2;
                        drSegundaVia["Histórico descricação mês3"] = item.historicoDescricaoMes3;
                        drSegundaVia["Histórico mês3"] = item.historicoMes3;
                        drSegundaVia["Histórico descricação mês4"] = item.historicoDescricaoMes4;
                        drSegundaVia["Histórico mês4"] = item.historicoMes4;
                        drSegundaVia["Histórico descricação mês5"] = item.historicoDescricaoMes5;
                        drSegundaVia["Histórico mês5"] = item.historicoMes5;
                        drSegundaVia["Histórico descricação mês6"] = item.historicoDescricaoMes6;
                        drSegundaVia["Histórico mês6"] = item.historicoMes6;

                        //item.consumoM3pagoCondominio = 2600;
                        // o Valor pago do condominio virá do banco também...
                        //item.ConsumoValorPagoCondominio = 7900;

                        //Isto ficará fixo - Será a diferença paga entre o valor pago do consumo minimo, e o consumo e excedente
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);

                        drSegundaVia["Consumo M³"] = item.consumoM3pagoCondominio;
                        drSegundaVia["Consumo Valor"] = item.ConsumoValorPagoCondominio;
                        drSegundaVia["Mínimo M³"] = item.minimoM3PagoCondominio;
                        drSegundaVia["Mínimo Valor"] = item.minimoValorPagoCondominio;
                        drSegundaVia["Excedente Valor"] = item.excedenteValorPagoCondominio;
                        drSegundaVia["Tarifa Mínima M³"] = item.tarifaMinimaM3ValorDevido;


                        //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                        if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                        {
                            item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                            item.excedenteValorRateio = (item.excedenteValorPagoCondominio / item.excedenteM3Rateio);
                            item.valorPagarValorDevido = item.excedenteValorDevido * Math.Round(item.excedenteValorRateio, 2);

                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                            drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                        }
                        //Se não mantêm o valor sem rateio..
                        else
                        {
                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                            drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                        }
                        drSegundaVia["Tarifa Mínima Valor"] = item.tarifaMinimaValorValorDevido;
                        drSegundaVia["ExcedenteM3Rateio"] = item.excedenteM3Rateio;
                        drSegundaVia["Geral"] = item.avisoGeralAviso;
                        drSegundaVia["Anormal"] = item.AnormalAviso;
                        drSegundaVia["Invididual"] = item.individualAviso;
                        drSegundaVia["ANORMALIDADE"] = item.anormalidadeAviso;
                        drSegundaVia["Imagem"] = item.imagem;
                        drSegundaVia["ExcedenteValorDevido"] = item.excedenteValorDevido;
                        drSegundaVia["excedenteM3Diario"] = item.excedenteM3diaria;





                        dsSegundaVia.Tables[1].Rows.Add(drSegundaVia);

                    }



                    Crystal.Relatorios.ReciboMoradorByApBloco rbSegundaVia = new Crystal.Relatorios.ReciboMoradorByApBloco();

                    rbSegundaVia.SetDataSource(dsSegundaVia);

                    

                    rbSegundaVia.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,fileNameRecibo);

                    rbSegundaVia.Close();
                   

                    StringBuilder msgEmail = montaEmailHtml(enviaEmail.proprietario1, oReciboModel.mes.ToString(), oReciboModel.ano.ToString());

                    sendReciboAguaAzuliByEmail(msgEmail.ToString(), enviaEmail.email, enviaEmail.proprietario1, fileNameRecibo);

                }


            }

            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void crystalReport()
        {

            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 0;
            pg.Margins.Bottom = 0;
            pg.Margins.Left = 0;
            pg.Margins.Right = 0;
            System.Drawing.Printing.PaperSize size = new System.Drawing.Printing.PaperSize();
            size.RawKind = (int)PaperKind.Letter;
            pg.PaperSize = size;
            pg.Landscape = true;

            DSrecibo dsSegundaVia = new DSrecibo();
            ListaSabesp oListLeituraSabesp = new ListaSabesp();
            LeituraSabespBLL oLeituraBussiness = new LeituraSabespBLL();
            ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
            ReciboAgua oReciboModel = new ReciboAgua();
            Util.RelatorioConfigRecibo oCarregaVariaveisRecibo = new Util.RelatorioConfigRecibo();
         
            string apartamento = Session["AP"].ToString();
            string bloco = Session["Bloco"].ToString();
            string mes = Session["mes"].ToString();
            string ano = Session["ano"].ToString();

            oReciboModel.bloco = bloco;
            oReciboModel.apartamento = apartamento;
            oReciboModel.ano = Convert.ToInt32(ano);
            oReciboModel.mes = Convert.ToInt32(mes);


            int mesReferenciaSabesp = Convert.ToInt32(mes);

             if (Convert.ToInt32(ano) <= 2015) 
            {
                ReciboOld();

            }
            else  if (Convert.ToInt32(mes) == 1 &&  Convert.ToInt32(ano) == 2016) 
            {
                ReciboOld();
            }

             else if (Convert.ToInt32(mes) == 2 && Convert.ToInt32(ano) == 2016)
             {
                 ReciboOld();
             }

             else
             {

                 var oListOrdenadoByRegistroJaCalculado = from listaOrdenada in oReciboBLL.buscaTodosRecibosByBlocoAndApto(oReciboModel)
                                                      orderby listaOrdenada.registro ascending
                                                      select listaOrdenada;


                        foreach (var item in oListOrdenadoByRegistroJaCalculado)
                        {
                        
                            DataRow drSegundaVia = dsSegundaVia.Tables[1].NewRow();
                            drSegundaVia["ID-Condomínio"] = item.idCondominio;
                            drSegundaVia["Nome do Condomínio"] = item.nomeCondominio;
                            drSegundaVia["Endereço do Condomínio"] = item.enderecoCondominio;
                            drSegundaVia["Bloco"] = item.bloco;
                            drSegundaVia["Apartamento"] = item.apartamento;
                            drSegundaVia["Registro"] = item.registro;
                            drSegundaVia["Fechamento Atual"] = item.fechamentoAtual;
                            drSegundaVia["Data leitura Anterior"] = item.dataLeituraAnterior;
                            drSegundaVia["Leitura Anterior M³"] = item.leituraAnteriorM3;
                            drSegundaVia["Data leitura Atual"] = item.dataLeituraAtual;
                            drSegundaVia["Leitura Atual M³"] = item.leituraAtualM3;
                            drSegundaVia["Consumo do Mês M³"] = item.consumoMesM3;
                            drSegundaVia["Data da próxima leitura"] = item.dataProximaLeitura;
                            drSegundaVia["Média"] = item.media;
                            drSegundaVia["Histórico descricação mês1"] = item.historicoDescricaoMes1;
                            drSegundaVia["Histórico mês1"] = item.historicoMes1;
                            drSegundaVia["Histórico descricação mês2"] = item.historicoDescricaoMes2;
                            drSegundaVia["Histórico mês2"] = item.historicoMes2;
                            drSegundaVia["Histórico descricação mês3"] = item.historicoDescricaoMes3;
                            drSegundaVia["Histórico mês3"] = item.historicoMes3;
                            drSegundaVia["Histórico descricação mês4"] = item.historicoDescricaoMes4;
                            drSegundaVia["Histórico mês4"] = item.historicoMes4;
                            drSegundaVia["Histórico descricação mês5"] = item.historicoDescricaoMes5;
                            drSegundaVia["Histórico mês5"] = item.historicoMes5;
                            drSegundaVia["Histórico descricação mês6"] = item.historicoDescricaoMes6;
                            drSegundaVia["Histórico mês6"] = item.historicoMes6;
                            drSegundaVia["Consumo Valor"] = item.ConsumoValorPagoCondominio;
                            drSegundaVia["Consumo M³"] = item.consumoM3pagoCondominio;
                            drSegundaVia["Mínimo M³"] = item.minimoM3PagoCondominio;
                            drSegundaVia["Mínimo Valor"] = item.minimoValorPagoCondominio;
                            drSegundaVia["Excedente Valor"] = item.excedenteValorPagoCondominio;
                            drSegundaVia["Tarifa Mínima M³"] = item.tarifaMinimaM3ValorDevido;
                            drSegundaVia["Tarifa Mínima Valor"] = item.tarifaMinimaValorValorDevido;
                            drSegundaVia["ExcedenteValorDevido"] =  item.excedenteValorDevido;
                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteValorRateio "] = item.excedenteValorRateio;
                            drSegundaVia["a pagar"] = item.valorPagarValorDevido;
                            drSegundaVia["ExcedentePagoPeloCondominio"] = item.excedenteM3PagoCondominio;
                            drSegundaVia["ExcedenteM3Rateio"] = item.excedenteM3Rateio;
                            drSegundaVia["Geral"] = item.avisoGeralAviso;
                            drSegundaVia["Anormal"] = item.AnormalAviso;
                            drSegundaVia["Invididual"] = item.individualAviso;
                            drSegundaVia["ANORMALIDADE"] = item.anormalidadeAviso;
                            drSegundaVia["Imagem"] = item.imagem;
                            drSegundaVia["excedenteM3Diario"] = item.excedenteM3diaria;
                            drSegundaVia["status"] = item.status;
                            dsSegundaVia.Tables[1].Rows.Add(drSegundaVia);

                        }

                        Crystal.Relatorios.ReciboMoradorByApBloco rbSegundaVia = new Crystal.Relatorios.ReciboMoradorByApBloco();

                        rbSegundaVia.SetDataSource(dsSegundaVia);

              
                 rbSegundaVia.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Recibo-"+ano+mes);
             }
        
        }
           
        private void SetDBLogonForReport(ConnectionInfo myConnectionInfo, ReportDocument myReportDocument)
        {
            Tables myTables = myReportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
            {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = myConnectionInfo;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }


        private void sendReciboAguaAzuliByEmail(string msg, string email, string proprietario, string fileNameAttached)
        {


            Util.SendMail.enviaSenhaComAnexo(msg, proprietario, email, fileNameAttached);

        }

        private StringBuilder montaEmailHtml(string proprietario, string mes, string ano)
        {
            //Cria objeto string builder
            StringBuilder sbBody = new StringBuilder();

            //Adiciona estrutura HTML do E-Mail
            sbBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
            sbBody.Append("<head><title>Untitled Document</title>");
            sbBody.Append("<style type='text/css'>body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #E1E0F2;}");
            sbBody.Append("body,td,th {font-family: Verdana, Geneva, sans-serif;font-size: 12px;}</style></head><body>");
            sbBody.Append("<strong><h3>.::Recibo da Água - Azuli - Referência:" + mes + "/" + ano + " </h3></strong><br />");
            sbBody.Append("<b>Caro(ª) </b><br />");
            //Adiciona texto digitado no TextBox txtNome
            sbBody.Append(proprietario);
            sbBody.Append("<br /><br />");
            sbBody.Append("<b>Segue em anexo o seu recibo da água do condominio Azuli.</b><br />");
            sbBody.Append("<b>Você pode acessá-lo também de forma on-line caso tenha interesse, acesse o link abaixo</b><br />");
            sbBody.Append("<b>http://http://condominiospazioazuli.somee.com/LoginAzulli.aspx</b><br />");
            sbBody.Append("<br /></body></html>");

            return sbBody;

        }


    }
}