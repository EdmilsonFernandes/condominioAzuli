using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Depedentes
    {
        public string nomeDepedente { get; set; }
        public string parentesco { get; set; }
        public string nascimentoDepedente { get; set; }
    }
    public class GetListaDepedentes : List<Depedentes>
    {
    }
}
