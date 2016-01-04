using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IClassificadoVisto
    {
       void contabilizaVistoClassificado(ClassificadoVisto oClassificadoVisto);
       listaClassificadoVisto listaClassificadoVisto(ClassificadoVisto oClassificadoVisto);
       listaClassificadoVisto validaClassificadoVisto(ClassificadoVisto oClassificadoVisto);
    }
}
