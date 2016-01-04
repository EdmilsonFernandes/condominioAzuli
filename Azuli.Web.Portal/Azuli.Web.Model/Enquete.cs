using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Enquete
    {

        public string enqueteDescricao { get; set;}
        public int idEnquete { get; set;}
        public int resultadoEnquete { get; set; }
        public ApartamentoModel oAP { get; set;}
        public DateTime dataResposta { get; set; }
    }

    public class ListaEnquete : List<Enquete> { }

}
