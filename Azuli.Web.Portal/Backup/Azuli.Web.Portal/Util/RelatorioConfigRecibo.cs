using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azuli.Web.Portal.Util
{
    public class RelatorioConfigRecibo
    {
        public double consumoSabesp{get;set;}
        public double valorCobradoContaSabesp { get; set; }
        public double consumoMinimoSabesp { get; set; }
        public double valorMinimoContaSabesp { get; set; }
        public int valorExcedenteSabesp { get; set; }
        public int consumoExcedenteSabesp { get; set; }
        public double consumoAzuliDiaLeitura { get; set; }
        public double exccedenteAzuliDiaLeitura { get; set;}

        public double consumoEstimativaSabespDia { get; set;}
        public double comsumoExcedenteEstimativaSabespDia { get; set;}
        public double excedenteAreaComum { get; set; }
        public double somaExcedenteAcMoradores { get; set;}
        public double valorM3Diario { get;set; }
    }
}