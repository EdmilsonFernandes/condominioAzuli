using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class File
    {
        public int codigo { get; set; }
        public int ano { get; set; }
        public int mes { get; set; }
        public string nameFile { get; set; }
        public int areaPublicacao { get; set; }
        public string assunto { get; set; }
        public DateTime dataPublicacao { get; set; }
        public string nomeAreaPublicacao { get; set; }
    }

    public class ListFile : List<File>
    {
    }
}
