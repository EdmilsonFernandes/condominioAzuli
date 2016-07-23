using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    [Serializable]
    public class ReciboAgua
    {
        public string idCondominio  {get;set;}
        public string nomeCondominio  {get;set;}
        public string enderecoCondominio  {get;set;}
        public string bloco {get;set;}
        public string apartamento  {get;set;}
        public string registro {get;set;}
        public string fechamentoAtual {get;set;}
        public string dataLeituraAnterior {get;set;}
        public string leituraAnteriorM3 {get;set;}
        public string dataLeituraAtual {get;set;}
        public string leituraAtualM3 {get;set;}
        public string consumoMesM3 {get;set;}
        public string dataProximaLeitura {get;set;}
        public string status {get;set;}
        public string media {get;set;}
        public string historicoDescricaoMes1 {get;set;}
        public string historicoDescricaoMes2 {get;set;}
        public string historicoDescricaoMes3 {get;set;}
        public string historicoDescricaoMes4 {get;set;}
        public string historicoDescricaoMes5 {get;set;}
        public string historicoDescricaoMes6 {get;set;}
        public string historicoMes1  {get;set;}
        public string historicoMes2  {get;set;}
        public string historicoMes3  {get;set;}
        public string historicoMes4  {get;set;}
        public string historicoMes5 {get;set;}
        public string historicoMes6 {get;set;}
        public string imagem {get;set;}
        public int consumoM3pagoCondominio  {get;set;}
        public decimal ConsumoValorPagoCondominio {get;set;}
        public int minimoM3PagoCondominio {get;set;}
        public decimal minimoValorPagoCondominio { get; set; }
        public int excedenteM3PagoCondominio { get; set; }
        public decimal excedenteValorPagoCondominio { get; set; }
        public int excedenteM3Rateio { get; set; }
        public decimal excedenteValorRateio { get; set; }
        public int tarifaMinimaM3ValorDevido { get; set; }
        public decimal tarifaMinimaValorValorDevido { get; set; }
        public decimal excedenteValorDevido { get; set; }
        public decimal valorPagarValorDevido { get; set; }
        public string avisoGeralAviso { get; set; }
        public string AnormalAviso { get; set; }
        public string individualAviso { get; set; }
        public string anormalidadeAviso { get; set; }
        public int ano { get; set; }
        public int mes { get; set; }
        public float excedenteM3diaria {get;set;}
        public int somaConsumoByBloco { get; set; }
        public int qtdAnormalidade { get; set; }
        public string persisteBanco { get; set; }
    }

     [Serializable]
    public class listaSegundaViaAgua : List<ReciboAgua> { }
}
