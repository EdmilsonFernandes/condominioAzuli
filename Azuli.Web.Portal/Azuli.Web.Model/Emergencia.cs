using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Emergencia
    {
        public string nomeContatoEmergencia { get; set; }
        public string nomeParentescoEmergencia { get; set; }
        public string contato { get; set; }
    }

    public class GetListaEmergencia : List<Emergencia>
    {
    }

}
