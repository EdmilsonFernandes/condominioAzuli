using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class ClassificadoVisto
    {
        public int idVisto { get; set;}
        public Classificados oClassificadoID { get; set;}
        public DateTime dataVisto { get; set;}
        public ApartamentoModel oApartamento { get; set;}
        public int contadorClassificado { get; set; }
    }

    public class listaClassificadoVisto : List<ClassificadoVisto> { }
}
