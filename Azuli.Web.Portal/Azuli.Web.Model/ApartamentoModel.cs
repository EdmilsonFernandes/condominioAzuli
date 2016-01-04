using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class ApartamentoModel
    {
        public int bloco { get; set; }
        public int apartamento { get; set;}
        public ProprietarioModel oProprietario { get; set; }
    }

    public class listApartamento : List<ApartamentoModel> { };
}
