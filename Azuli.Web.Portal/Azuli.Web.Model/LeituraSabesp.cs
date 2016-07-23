using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azuli.Web.Model
{
    public class LeituraSabesp
    {
        public int idLeitura { get; set; }
        public string mesReferencia { get; set; }
        public DateTime dataAtual { get; set; }
        public DateTime dataAnterior { get; set; }
        public int dias { get; set;}


    }
    public class ListaSabesp : List<LeituraSabesp> { }
}