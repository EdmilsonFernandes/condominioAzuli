using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Business.Interfaces
{
    public interface IClassificado
    {
        void cadastraClassificado(Classificados oClassificado);
        listClassificados consultaClassificado(Classificados oClassificado);
        listClassificados contaGrupoClassificado(Classificados oClassificado);
        void atualizaClassificado(Classificados oClassificado);
    }
}
