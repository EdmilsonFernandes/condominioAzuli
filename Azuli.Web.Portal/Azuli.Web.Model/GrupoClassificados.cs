using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class GrupoClassificados
    {


        public int grupoClassificado { get; set; }
        public string descricacaoGrupoClassificado { get; set; }
        public string statusClassificado { get; set; }
        public string imgGrupoClassificado { get; set; }
    }
    public class listaGrupoClassificado : List<GrupoClassificados>
    {
    }
}
