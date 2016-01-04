using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class MensagensModel
    {
        public int idMsg { get; set; }
        public string textoMsg { get; set; }
        public string statusMsg { get; set; }
        public string tipoMsg { get; set; }
    }

    public class listaMensagens: List<MensagensModel>
    {

    }
}
