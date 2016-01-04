using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Business.Interfaces
{
    public interface IClassificadoVisto
    {
         void contabilizaVistoClassificado(Model.ClassificadoVisto oClassVisto);
         listaClassificadoVisto listaClassificadoVisto(Model.ClassificadoVisto oClassVisto);
         listaClassificadoVisto validaClassificadoVisto(Model.ClassificadoVisto oClassificadoVisto);

    }
}
