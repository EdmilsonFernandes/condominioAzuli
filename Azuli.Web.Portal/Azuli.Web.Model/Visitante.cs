using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Visitante
    {
        public int visitanteId { get; set; }
        public string visitanteNome { get; set; }
        public string visitanteRG { get; set; }
        public string visitanteTipo { get; set; }
        public Foto idFoto { get; set; }


        public Visitante()
        {
            visitanteId = 0;
            visitanteNome = "";
            visitanteRG = "";
            visitanteTipo = "V";
        }
    }
    public class listVisitante : List<Visitante>
    {
    }
}
