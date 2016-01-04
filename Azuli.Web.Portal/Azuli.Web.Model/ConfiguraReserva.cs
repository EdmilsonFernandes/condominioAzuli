using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class ConfiguraReserva
    {
        public int id_valor { get; set; }
        public string area { get; set; }
        public double valor { get; set; }
    }

    public class ListaConfiguracaoReserva : List<ConfiguraReserva> { }

}
