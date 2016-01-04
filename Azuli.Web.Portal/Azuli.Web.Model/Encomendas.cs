using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class Encomendas
    {
        public int Bloco {get; set;}
        public int Apartamento {get; set;}
        public Nullable<DateTime> EncDtaRec { get; set; }
        public string EncDesc {get; set;}
        public string EncEntr {get; set;}
        public string EncQuemPegou {get; set;}
        public Nullable<DateTime> EncQuanPegou { get; set; }
        public string EncUserBxa {get; set;}

        public Encomendas()
        {
            Bloco=0;
            Apartamento=0;
            EncDtaRec=DateTime.Parse("01-01-1753");
            EncDesc="";
            EncEntr="N";
            EncQuemPegou="";
            EncQuanPegou=DateTime.Parse("01-01-1753");
            EncUserBxa  = "";
        }
 
    }
    public class ListaEncomendas : List<Encomendas>
    {
    }
}
