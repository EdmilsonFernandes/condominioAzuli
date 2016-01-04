using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Azuli.Web.Model;
using Azuli.Web.Business;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;


namespace Azuli.Web.Portal
{
    public partial class reportRelatorioGeral : System.Web.UI.Page
    {

        ReciboAguaBLL oReciboBLL = new ReciboAguaBLL();
        Util.Util oUtil = new Util.Util();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToBoolean(Session["RelGerencial"]) == true)
            {
                if (oUtil.validateSessionAdmin())
                {
                    string mes = Session["mes"].ToString();
                    string ano = Session["ano"].ToString();
                    lblReferencia.Text = "Relatório Geral Referência " + addZero(mes) + "/" + ano;
                    detalheConsumo(Convert.ToInt32(ano), Convert.ToInt32(mes));
                   

                }
            }
            
        }

        public void detalheConsumo(int mes, int ano)
        {

            string leituraAt ="";
            string leituraAnt ="";
            var listExcel = from lisExcelBl1 in oReciboBLL.buscaTodosRecibosByYearAndMonth(mes,ano)
                            orderby lisExcelBl1.registro ascending
                            select lisExcelBl1;



            listaSegundaViaAgua listExcelTratada = new listaSegundaViaAgua();
            listaSegundaViaAgua listExcelTratada2 = new listaSegundaViaAgua();
            listaSegundaViaAgua listExcelTratada3 = new listaSegundaViaAgua();
            listaSegundaViaAgua listExcelTratada4 = new listaSegundaViaAgua();
            listaSegundaViaAgua listExcelTratada5 = new listaSegundaViaAgua();
            listaSegundaViaAgua listExcelTratada6 = new listaSegundaViaAgua();
            double totalExcedenteDinamico = 0;


            foreach (var item in listExcel)
            {
             
                
                if (leituraAnt == "" && leituraAt == "")
                {
                   
                    leituraAnt = item.dataLeituraAnterior;
                    leituraAt = item.dataLeituraAtual;
                    
                }
                
                
            }


            foreach (var item in listExcel)
            {

                if (Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) > 10)
                {

                    totalExcedenteDinamico += Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) - 10;
                }

            }
                    

            foreach (var item in listExcel)
            {
                ReciboAgua oReciboModel = new ReciboAgua();

                

                if (item.bloco == "1")
                {

                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;
                        
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;

                      
                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }

                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                   



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();


                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {
                            
                                oReciboModel.status = "↓ " + item.status;
                            

                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {
                            

                                oReciboModel.status = "↑ " + item.status;
                           

                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = item.status;


                        }
                    }
                    

                    listExcelTratada.Add(oReciboModel);
                }

                if (item.bloco == "2")
                {

                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }

                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                  //  oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {

                            oReciboModel.status = "↓ " + item.status;


                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = "↑ " + item.status;


                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = item.status;


                        }
                    }

                    listExcelTratada2.Add(oReciboModel);
                }

                if (item.bloco == "3")
                {

                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }

                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                    //oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {

                            oReciboModel.status = "↓ " + item.status;


                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = "↑ " + item.status;


                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = item.status;


                        }
                    }

                    listExcelTratada3.Add(oReciboModel);
                }

                if (item.bloco == "4")
                {

                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }

                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                    //oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {

                            oReciboModel.status = "↓ " + item.status;


                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = "↑ " + item.status;


                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = item.status;


                        }
                    }

                    listExcelTratada4.Add(oReciboModel);
                }


                if (item.bloco == "5")
                {
                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;


                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }
                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                    //oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                            if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                            {

                                oReciboModel.status = "↓ " + item.status;


                            }
                            if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                            {


                                oReciboModel.status = "↑ " + item.status;


                            }

                            if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                            {


                                oReciboModel.status = item.status;


                            }
                        
                    }

                    listExcelTratada5.Add(oReciboModel);
                }

                if (item.bloco == "6")
                {
                    //Se o valor do consumo do M3 for maior que o minimo M3 do condominio será feito o rateio...
                    if (item.consumoM3pagoCondominio > item.minimoM3PagoCondominio)
                    {
                        item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                        item.excedenteM3PagoCondominio = item.consumoM3pagoCondominio - item.minimoM3PagoCondominio;
                        item.excedenteValorRateio = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.excedenteValorPagoCondominio) / totalExcedenteDinamico + 0.0005, 3));
                        item.valorPagarValorDevido = item.excedenteValorDevido * item.excedenteValorRateio;

                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    }
                    //Se não mantêm o valor sem rateio..
                    else
                    {
                        oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;
                    }

                    oReciboModel.registro = "R" + item.registro;
                    oReciboModel.apartamento = "B" + item.bloco + "-AP" + item.apartamento;
                    oReciboModel.historicoMes1 = " " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")";
                    oReciboModel.leituraAnteriorM3 = item.leituraAnteriorM3;
                    oReciboModel.leituraAtualM3 = item.leituraAtualM3;
                    
                    oReciboModel.consumoMesM3 = Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero).ToString();
                    oReciboModel.excedenteValorDevido = item.excedenteValorDevido;
                    //oReciboModel.valorPagarValorDevido = item.valorPagarValorDevido;



                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "" || item.status == "-")
                    {
                        oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {
                            
                                oReciboModel.status = "↓ " + item.status;
                            

                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = "↑ " + item.status;
                           

                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {


                            oReciboModel.status = item.status;


                        }
                    }

                    listExcelTratada6.Add(oReciboModel);
                }



                

            }

            populaGridBloco(listExcelTratada, 1, leituraAnt, leituraAt);
            populaGridBloco(listExcelTratada2, 2, leituraAnt, leituraAt);
            populaGridBloco(listExcelTratada3, 3, leituraAnt, leituraAt);
            populaGridBloco(listExcelTratada4, 4, leituraAnt, leituraAt);
            populaGridBloco(listExcelTratada5, 5, leituraAnt, leituraAt);
            populaGridBloco(listExcelTratada6, 6, leituraAnt, leituraAt);

            
        }


        public void populaGridBloco(listaSegundaViaAgua olista, int bloco, string leituraAnt, string leituraAt)
        {

            switch (bloco)
            {
                case 1:
                    grdDetalheConsumo.DataSource = olista;
                    grdDetalheConsumo.DataBind();
                    grdDetalheConsumo.FooterRow.Cells[0].ColumnSpan = 9;
                    grdDetalheConsumo.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdDetalheConsumo.FooterRow.Cells[0].Font.Size = 28;
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(8);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(7);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(6);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(5);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(4);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(3);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(2);
                    grdDetalheConsumo.FooterRow.Cells.RemoveAt(1);
                    grdDetalheConsumo.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    grdDetalheConsumo.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    grdDetalheConsumo.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    grdDetalheConsumo.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    grdDetalheConsumo.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    grdDetalheConsumo.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (","").Replace("):","") + "<br>[m³]";
                    grdDetalheConsumo.FooterRow.Cells[0].Text = "BLOCO 1";
                    break;

                case 2:
                    GridBloco2.DataSource = olista;
                    GridBloco2.DataBind();
                    GridBloco2.FooterRow.Cells[0].ColumnSpan = 9;
                    GridBloco2.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridBloco2.FooterRow.Cells[0].Font.Size = 28;
                    GridBloco2.FooterRow.Cells.RemoveAt(8);
                    GridBloco2.FooterRow.Cells.RemoveAt(7);
                    GridBloco2.FooterRow.Cells.RemoveAt(6);
                    GridBloco2.FooterRow.Cells.RemoveAt(5);
                    GridBloco2.FooterRow.Cells.RemoveAt(4);
                    GridBloco2.FooterRow.Cells.RemoveAt(3);
                    GridBloco2.FooterRow.Cells.RemoveAt(2);
                    GridBloco2.FooterRow.Cells.RemoveAt(1);
                    GridBloco2.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    GridBloco2.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    GridBloco2.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    GridBloco2.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    GridBloco2.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    GridBloco2.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (", "").Replace("):", "") + "<br>[m³]";
                    GridBloco2.FooterRow.Cells[0].Text = "BLOCO 2";
                    break;
                case 3:
                    GridView1.DataSource = olista;
                    GridView1.DataBind();
                    GridView1.FooterRow.Cells[0].ColumnSpan = 9;
                    GridView1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridView1.FooterRow.Cells[0].Font.Size = 28;
                    GridView1.FooterRow.Cells.RemoveAt(8);
                    GridView1.FooterRow.Cells.RemoveAt(7);
                    GridView1.FooterRow.Cells.RemoveAt(6);
                    GridView1.FooterRow.Cells.RemoveAt(5);
                    GridView1.FooterRow.Cells.RemoveAt(4);
                    GridView1.FooterRow.Cells.RemoveAt(3);
                    GridView1.FooterRow.Cells.RemoveAt(2);
                    GridView1.FooterRow.Cells.RemoveAt(1);
                    GridView1.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    GridView1.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    GridView1.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    GridView1.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    GridView1.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    GridView1.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (", "").Replace("):", "") + "<br>[m³]";
                    GridView1.FooterRow.Cells[0].Text = "BLOCO 3";
                    break;
                case 4:
                    GridView2.DataSource = olista;
                    GridView2.DataBind();
                    GridView2.FooterRow.Cells[0].ColumnSpan = 9;
                    GridView2.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridView2.FooterRow.Cells[0].Font.Size = 28;
                    GridView2.FooterRow.Cells.RemoveAt(8);
                    GridView2.FooterRow.Cells.RemoveAt(7);
                    GridView2.FooterRow.Cells.RemoveAt(6);
                    GridView2.FooterRow.Cells.RemoveAt(5);
                    GridView2.FooterRow.Cells.RemoveAt(4);
                    GridView2.FooterRow.Cells.RemoveAt(3);
                    GridView2.FooterRow.Cells.RemoveAt(2);
                    GridView2.FooterRow.Cells.RemoveAt(1);
                    GridView2.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    GridView2.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    GridView2.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    GridView2.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    GridView2.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    GridView2.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (", "").Replace("):", "") + "<br>[m³]";
                    GridView2.FooterRow.Cells[0].Text = "BLOCO 4";
                    break;

                case 5:
                    GridView3.DataSource = olista;
                    GridView3.DataBind();
                    GridView3.FooterRow.Cells[0].ColumnSpan = 9;
                    GridView3.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridView3.FooterRow.Cells[0].Font.Size = 28;
                    GridView3.FooterRow.Cells.RemoveAt(8);
                    GridView3.FooterRow.Cells.RemoveAt(7);
                    GridView3.FooterRow.Cells.RemoveAt(6);
                    GridView3.FooterRow.Cells.RemoveAt(5);
                    GridView3.FooterRow.Cells.RemoveAt(4);
                    GridView3.FooterRow.Cells.RemoveAt(3);
                    GridView3.FooterRow.Cells.RemoveAt(2);
                    GridView3.FooterRow.Cells.RemoveAt(1);
                    GridView3.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    GridView3.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    GridView3.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    GridView3.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    GridView3.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    GridView3.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (", "").Replace("):", "") + "<br>[m³]";
                    GridView3.FooterRow.Cells[0].Text = "BLOCO 5";
                    break;

                case 6:
                    GridView4.DataSource = olista;
                    GridView4.DataBind();
                    GridView4.FooterRow.Cells[0].ColumnSpan = 9;
                    GridView4.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    GridView4.FooterRow.Cells[0].Font.Size = 28;
                    GridView4.FooterRow.Cells.RemoveAt(8);
                    GridView4.FooterRow.Cells.RemoveAt(7);
                    GridView4.FooterRow.Cells.RemoveAt(6);
                    GridView4.FooterRow.Cells.RemoveAt(5);
                    GridView4.FooterRow.Cells.RemoveAt(4);
                    GridView4.FooterRow.Cells.RemoveAt(3);
                    GridView4.FooterRow.Cells.RemoveAt(2);
                    GridView4.FooterRow.Cells.RemoveAt(1);
                    GridView4.FooterRow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    GridView4.HeaderRow.Cells[5].Text = "Consumo <br>30d [M³]";
                    GridView4.HeaderRow.Cells[6].Text = "Excedente <br> [m³]";
                    GridView4.HeaderRow.Cells[2].Text = "Histórico de consumo <br> 6 últimos meses (média) <br> [m³]";
                    GridView4.HeaderRow.Cells[3].Text = "Leitura <br> ant <br>" + leituraAnt.Replace("Leitura anterior (", "").Replace("):", "") + "<br>[m³]"; ;
                    GridView4.HeaderRow.Cells[4].Text = "Leitura <br> atual <br> " + leituraAt.Replace("Leitura Atual (", "").Replace("):", "") + "<br>[m³]";
                    GridView4.FooterRow.Cells[0].Text = "BLOCO 6";
                    break;


            }
        }

        public string returnNumber(string historico)
        {
            Regex re = new Regex("[0-9]");
            StringBuilder s = new StringBuilder();

            foreach (Match m in re.Matches(historico))
            {
                s.Append(m.Value);
            }

            return s.ToString();
        }


        public string addZero(string valor)
        {
            string auxiliar = "";

            if (valor == "")
            {
                valor = "0";
            }
            if (Convert.ToInt32(valor) >= 10)
            {


                return valor;


            }

            else
            {
                auxiliar = "0" + valor;

                return auxiliar;
            }

        }

        

        protected void grdDetalheConsumo1_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }





            }
        }



        protected void grdDetalheConsumo2_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }





            }
        }



        protected void grdDetalheConsumo3_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }





            }
        }


        protected void grdDetalheConsumo4_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }





            }
        }



        protected void grdDetalheConsumo5_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }

               



            }





        }


        protected void grdDetalheConsumo6_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            // quando montar as linhas do tipo DADOS
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 10)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#800000");

                }

                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "consumoMesM3")) > 20)
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;

                }
                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↓ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;

                }

                if (DataBinder.Eval(e.Row.DataItem, "status").ToString() == "↑ Anormal")
                {

                    e.Row.Cells[8].BackColor = System.Drawing.Color.Red;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Yellow;

                }





            }





        }

        public void preencheDadosExcel()
        {

            //int consumoAPs = 0;
            //int consumoSomaExcedentes = 0;
            double[] arrayConsumoTotalAPs = new double[5];
            double[] arrayExcedente = new double[5];
           
            int[] arraySabesp = new int[5];
            string[] mesesHistrorico = new string[5];


            string mes = Session["mes"].ToString();
            string ano = Session["ano"].ToString();
            int anoHistorico = Convert.ToInt32(mes);

            
            var listExcel = from lisExcelBl1 in oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano),Convert.ToInt32(mes))
                            orderby lisExcelBl1.registro ascending
                            select lisExcelBl1;

           // bool mesVerdadeiro = false;
            int anoExcel = Convert.ToInt32(ano);


            for (int i = 0; i < 5; i ++)
            {
                if (anoExcel == 2013)
                {

                    var listHistoricoAP = from listHistorico in oReciboBLL.buscaTodosRecibosByYearAndMonth(anoExcel, Convert.ToInt32(anoHistorico))
                                          select Convert.ToInt32(listHistorico.consumoMesM3);

                    arrayConsumoTotalAPs[i] = listHistoricoAP.Sum();
                }
                else
                {
                    var listHistoricoAP = from listHistorico in oReciboBLL.buscaTodosRecibosByYearAndMonth(anoExcel, Convert.ToInt32(anoHistorico))
                                          select Math.Round(listHistorico.excedenteM3diaria * 30, 0,MidpointRounding.AwayFromZero);

                    arrayConsumoTotalAPs[i] = listHistoricoAP.Sum();
                }

               // var listHistoricoExcedente = from listHistorico in oReciboBLL.buscaTodosRecibosByYearAndMonth(anoExcel, Convert.ToInt32(anoHistorico))
                                           //  select Convert.ToInt32(listHistorico.excedenteM3Rateio);

                var oListOrdenadoByRegistro = from listaOrdenada in oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(anoExcel), Convert.ToInt32(anoHistorico))
                                              orderby listaOrdenada.registro ascending
                                              select listaOrdenada;

                var listSabesp = from listHistorico in oReciboBLL.buscaTodosRecibosByYearAndMonth(anoExcel, Convert.ToInt32(anoHistorico))
                                 select listHistorico.consumoM3pagoCondominio;



                mesesHistrorico[i] = "01/" + anoHistorico + "/" + anoExcel;
                double totalExcedenteDinamico = 0;
                foreach (var item in oListOrdenadoByRegistro)
                {

                    if (Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) > 10)
                    {

                       totalExcedenteDinamico += Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero) - 10;
                    }
                   
                       
                    
                }

                arrayExcedente[i] = totalExcedenteDinamico;
                arraySabesp[i] = listSabesp.FirstOrDefault();

               


                 if (anoHistorico == 1)
                 {
                     anoHistorico = 12;
                     anoExcel--;
                 }
                 else
                 {
                    
                   anoHistorico--;
                     
                 }

                

                 
                                
                
            }

           
            
            
            var listChart = from lisExcelChartAux in oReciboBLL.buscaTodosRecibosByYearAndMonth(Convert.ToInt32(ano), Convert.ToInt32(mes))
                            orderby lisExcelChartAux.consumoMesM3 descending
                            select lisExcelChartAux;


            // Open Template
            //local
            //FileStream fs = new FileStream(@"C:\Users\Edmilson\Documents\RelatorioGeral.xls", FileMode.Open, FileAccess.Read);
            //web

            var dir = System.Configuration.ConfigurationManager.AppSettings["relatorioGeral"];
            FileStream fs = new FileStream(Server.MapPath(dir + "RelatorioGeral.xls"), FileMode.Open, FileAccess.Read);

            

            // Load the template into a NPOI workbook
            HSSFWorkbook templateWorkbook = new HSSFWorkbook(fs, true);

            ISheet sheet = templateWorkbook.GetSheet("RG");
            ISheet sheetMedia = templateWorkbook.GetSheet("Plan2");
            int auxiliarChart = 0;
            int posArrayConsumoAps = 23;
            int posArrayExcedente = 24;
            int posArrayConsumoSabesp = 22;
            int posArrayMesesHistorico = 21;
            int posArrayReferencia = 0;

            sheet.GetRow(posArrayReferencia).GetCell(8).SetCellValue(Convert.ToDateTime("01/"+mes+"/"+ano));
            sheet.GetRow(posArrayConsumoAps).GetCell(7).SetCellValue(arrayConsumoTotalAPs[0]);
            sheet.GetRow(posArrayConsumoAps).GetCell(6).SetCellValue(arrayConsumoTotalAPs[1]);
            sheet.GetRow(posArrayConsumoAps).GetCell(5).SetCellValue(arrayConsumoTotalAPs[2]);
            sheet.GetRow(posArrayConsumoAps).GetCell(4).SetCellValue(arrayConsumoTotalAPs[3]);
            sheet.GetRow(posArrayConsumoAps).GetCell(3).SetCellValue(arrayConsumoTotalAPs[4]);

            sheet.GetRow(posArrayExcedente).GetCell(7).SetCellValue(arrayExcedente[0]);
            sheet.GetRow(posArrayExcedente).GetCell(6).SetCellValue(arrayExcedente[1]);
            sheet.GetRow(posArrayExcedente).GetCell(5).SetCellValue(arrayExcedente[2]);
            sheet.GetRow(posArrayExcedente).GetCell(4).SetCellValue(arrayExcedente[3]);
            sheet.GetRow(posArrayExcedente).GetCell(3).SetCellValue(arrayExcedente[4]);


            sheet.GetRow(posArrayConsumoSabesp).GetCell(7).SetCellValue(arraySabesp[0]);
            sheet.GetRow(posArrayConsumoSabesp).GetCell(6).SetCellValue(arraySabesp[1]);
            sheet.GetRow(posArrayConsumoSabesp).GetCell(5).SetCellValue(arraySabesp[2]);
            sheet.GetRow(posArrayConsumoSabesp).GetCell(4).SetCellValue(arraySabesp[3]);
            sheet.GetRow(posArrayConsumoSabesp).GetCell(3).SetCellValue(arraySabesp[4]);

            sheet.GetRow(posArrayMesesHistorico).GetCell(7).SetCellValue(Convert.ToDateTime(mesesHistrorico[0]));
            sheet.GetRow(posArrayMesesHistorico).GetCell(6).SetCellValue(Convert.ToDateTime(mesesHistrorico[1]));
            sheet.GetRow(posArrayMesesHistorico).GetCell(5).SetCellValue(Convert.ToDateTime(mesesHistrorico[2]));
            sheet.GetRow(posArrayMesesHistorico).GetCell(4).SetCellValue(Convert.ToDateTime(mesesHistrorico[3]));
            sheet.GetRow(posArrayMesesHistorico).GetCell(3).SetCellValue(Convert.ToDateTime(mesesHistrorico[4]));






            foreach (var item in listChart)
            {
                
                if (auxiliarChart <= 240)
                {


                    sheetMedia.GetRow(auxiliarChart).GetCell(0).SetCellValue(Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero));
                    sheetMedia.GetRow(auxiliarChart).GetCell(2).SetCellValue(Math.Round(item.excedenteM3diaria * 30, 0, MidpointRounding.AwayFromZero)); // 
                    auxiliarChart++;
                }
                
            }

            sheetMedia.ForceFormulaRecalculation = true;

            int initial = 46;
            int dataAtual = 9;
            int dataAnterior = 9 ;
            int consumoSabesp = 5;
            int valorCobrado = 6;
            bool date = false;

            foreach (var item in listExcel)
            {
                ReciboAgua oReciboModel = new ReciboAgua();

                if (date == false)
                {


                    sheet.GetRow(dataAtual).GetCell(1).SetCellValue(item.dataLeituraAtual.Replace("Leitura Atual (", "").Replace("):", ""));
                    sheet.GetRow(dataAnterior).GetCell(5).SetCellValue(item.dataLeituraAnterior.Replace("Leitura anterior (", "").Replace("):", ""));
                    sheet.GetRow(consumoSabesp).GetCell(2).SetCellValue(item.consumoM3pagoCondominio);
                    sheet.GetRow(valorCobrado).GetCell(2).SetCellValue(String.Format("{0:C2}",item.ConsumoValorPagoCondominio)); 


                    date = true;
                }
                   
                    //R111

                    sheet.GetRow(initial).GetCell(0).SetCellValue("R" + item.registro);  // 
                    sheet.GetRow(initial).GetCell(1).SetCellValue("B" + item.bloco + "-AP" + item.apartamento);  //
                    sheet.GetRow(initial).GetCell(2).SetCellValue(" " + addZero(returnNumber(item.historicoMes6)) + "-" + addZero(returnNumber(item.historicoMes5)) + "-" + addZero(returnNumber(item.historicoMes4)) + "-" + addZero(returnNumber(item.historicoMes3)) + "-" + addZero(returnNumber(item.historicoMes2)) + "-" + addZero(returnNumber(item.historicoMes1)) + " - (" + addZero(item.media) + ")");
                    sheet.GetRow(initial).GetCell(3).SetCellValue(item.leituraAnteriorM3);
                    sheet.GetRow(initial).GetCell(4).SetCellValue(item.leituraAtualM3);

                    sheet.GetRow(initial).GetCell(5).SetCellValue(Math.Round(item.excedenteM3diaria * 30, 0 , MidpointRounding.AwayFromZero));
                    sheet.GetRow(initial).GetCell(6).SetCellValue(""+item.excedenteValorDevido);
                    item.excedenteValorPagoCondominio = Math.Abs(item.ConsumoValorPagoCondominio - item.minimoValorPagoCondominio);
                    item.excedenteValorRateio = (item.excedenteValorPagoCondominio / item.excedenteM3Rateio);
                    sheet.GetRow(initial).GetCell(7).SetCellValue(String.Format("{0:C2}", item.excedenteValorDevido * Math.Round(item.excedenteValorRateio, 2)));

                    item.historicoMes1 = returnNumber(item.historicoMes1).ToString();

                    if (item.status == "" || item.historicoMes1 == "")
                    {
                       // oReciboModel.status = "-";
                        item.historicoMes1 = "0";
                        sheet.GetRow(initial).GetCell(8).SetCellValue(" - ");
                    }
                    else
                    {

                        if (Math.Round(item.excedenteM3diaria * 30, 0) < Convert.ToInt32(item.historicoMes1))
                        {
                            sheet.GetRow(initial).GetCell(8).SetCellValue("↓ " + item.status);

                        }
                        if (Math.Round(item.excedenteM3diaria * 30, 0) > Convert.ToInt32(item.historicoMes1))
                        {
                            sheet.GetRow(initial).GetCell(8).SetCellValue("↑ " + item.status);

                        }

                        if (Math.Round(item.excedenteM3diaria * 30, 0) == Convert.ToInt32(item.historicoMes1))
                        {
                            sheet.GetRow(initial).GetCell(8).SetCellValue( item.status);
                        }


                    }

                    

                    initial++;

                    if (initial == 86) // bloco 2
                    {
                        initial = 92;
                    }
                    else if (initial == 132) // bloco 3
                    {
                        initial = 138;
                    }
                    else if (initial == 178) // bloco 4
                    {
                        initial = 184;
                    }

                    else if (initial == 224) // bloco 5
                    {
                        initial = 230;
                    }
                    else if (initial == 270) //bloco 6
                    {
                        initial = 276;
                    }

                    
                    

            }
    

           
            

            // Force formulas to update with new data we added
            sheet.ForceFormulaRecalculation = true;

            // Save the NPOI workbook into a memory stream to be sent to the browser, could have saved to disk.
            MemoryStream ms = new MemoryStream();
            templateWorkbook.Write(ms);

            
            //// Send the memory stream to the browser
            ExportDataTableToExcel(ms, "Relatório Geral Referência " + addZero(mes) + "/" + ano);


        }



        private void DownloadAsPDF(MemoryStream ms)
        {
            
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename=abc.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.End();
            ms.Close();
        }

        private static void ExportDataTableToExcel(MemoryStream memoryStream, string fileName)
        {
            
            HttpResponse response = HttpContext.Current.Response;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            response.Clear();
            response.BinaryWrite(memoryStream.GetBuffer());
            response.End();
        }



           

        








        //protected void imbBtnExcel_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition",
        //    "attachment;filename=GridViewExport.doc");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-word ";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            
        //    grdDetalheConsumo.AllowPaging = false;
        //    grdDetalheConsumo.DataBind();
        //    grdDetalheConsumo.RenderControl(hw);

        //    GridBloco2.AllowPaging = false;
        //    GridBloco2.DataBind();
        //    GridBloco2.RenderControl(hw);

        //    GridView1.AllowPaging = false;
        //    GridView1.DataBind();
        //    GridView1.RenderControl(hw);

        //    GridView2.AllowPaging = false;
        //    GridView2.DataBind();
        //    GridView2.RenderControl(hw);

        //    GridView3.AllowPaging = false;
        //    GridView3.DataBind();
        //    GridView3.RenderControl(hw);

        //    GridView4.AllowPaging = false;
        //    GridView4.DataBind();
        //    GridView4.RenderControl(hw);

        //    GridView5.AllowPaging = false;
        //    GridView5.DataBind();
        //    GridView5.RenderControl(hw);
            
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();
        //}

        //protected void imgPdf_Click(object sender, ImageClickEventArgs e)
        //{

        //    ExportGridToExcel();
        //    //Response.ContentType = "application/pdf";
        //    //Response.AddHeader("content-disposition",
        //    //"attachment;filename=GridViewExport.pdf");
        //    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    //StringWriter sw = new StringWriter();
        //    //HtmlTextWriter hw = new HtmlTextWriter(sw);
            
        //    //grdDetalheConsumo.AllowPaging = false;
        //    //grdDetalheConsumo.DataBind();
        //    //grdDetalheConsumo.RenderControl(hw);

        //    //GridBloco2.AllowPaging = false;
        //    //GridBloco2.DataBind();
        //    //GridBloco2.RenderControl(hw);

        //    //GridView1.AllowPaging = false;
        //    //GridView1.DataBind();
        //    //GridView1.RenderControl(hw);

        //    //GridView2.AllowPaging = false;
        //    //GridView2.DataBind();
        //    //GridView2.RenderControl(hw);

        //    //GridView3.AllowPaging = false;
        //    //GridView3.DataBind();
        //    //GridView3.RenderControl(hw);

        //    //GridView4.AllowPaging = false;
        //    //GridView4.DataBind();
        //    //GridView4.RenderControl(hw);

        //    //GridView5.AllowPaging = false;
        //    //GridView5.DataBind();
        //    //GridView5.RenderControl(hw);

        //    //StringReader sr = new StringReader(sw.ToString());
        //    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    //pdfDoc.Open();
        //    //htmlparser.Parse(sr);
        //    //pdfDoc.Close();
        //    //Response.Write(pdfDoc);
        //    //Response.End();
        //}

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Vithal" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }  
        public override void VerifyRenderingInServerForm(Control control)
        {

            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            preencheDadosExcel();
        }

        public bool ExportWorkbookToPdf(string workbookPath, string outputPath)
        {
            // If either required string is null or empty, stop and bail out
            if (string.IsNullOrEmpty(workbookPath) || string.IsNullOrEmpty(outputPath))
            {
                return false;
            }

            // Create COM Objects
            Microsoft.Office.Interop.Excel.Application excelApplication;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook;

            // Create new instance of Excel
            excelApplication = new Microsoft.Office.Interop.Excel.Application();

            // Make the process invisible to the user
            excelApplication.ScreenUpdating = false;

            // Make the process silent
            excelApplication.DisplayAlerts = false;

            // Open the workbook that you wish to export to PDF
            excelWorkbook = excelApplication.Workbooks.Open(workbookPath);

            // If the workbook failed to open, stop, clean up, and bail out
            if (excelWorkbook == null)
            {
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;

                return false;
            }

            var exportSuccessful = true;
            try
            {
                // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
                excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputPath);
            }
            catch (System.Exception ex)
            {
                // Mark the export as failed for the return value...
                exportSuccessful = false;

                // Do something with any exceptions here, if you wish...
                // MessageBox.Show...        
            }
            finally
            {
                // Close the workbook, quit the Excel, and clean up regardless of the results...
                excelWorkbook.Close();
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;
            }

            // You can use the following method to automatically open the PDF after export if you wish
            // Make sure that the file actually exists first...
            if (System.IO.File.Exists(outputPath))
            {
                System.Diagnostics.Process.Start(outputPath);
            }

            return exportSuccessful;
        }

    }
}