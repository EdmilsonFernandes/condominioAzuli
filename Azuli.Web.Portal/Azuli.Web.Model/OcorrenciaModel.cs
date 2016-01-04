using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Model
{
    public class OcorrenciaModel
    {
        public int codigoOcorencia {get;set;}
        public string descricaoOcorrencia { get; set; }
    }

    public class listaOcorrencia : List<OcorrenciaModel> { }
}
