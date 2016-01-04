using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Foto
    {
        public int idFoto { get; set; }
        public byte[] foto { get; set; }
        public DateTime dataInclusao { get; set;}

    }
    public class ListaFotos : List<Foto>
    {

    }
}
