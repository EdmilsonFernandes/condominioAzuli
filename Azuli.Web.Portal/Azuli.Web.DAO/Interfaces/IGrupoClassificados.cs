using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IGrupoClassificados
    {

        void cadastrarGrupoClassificados(GrupoClassificados OgrupoClassifica);
        void alteraGrupoClassificados(GrupoClassificados oGrupoClassifica);
        listaGrupoClassificado listaGrupoClassificado(GrupoClassificados oGrupoClassifica);



    }
}
