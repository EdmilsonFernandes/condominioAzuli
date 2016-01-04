using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class ContaAgua
    {
        public int mes { get; set;}
        public int ano { get; set;}
        public ApartamentoModel modelAp { get; set;}

    }

    public class ListaAgua : List<ContaAgua> { }
}
