using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IFotoDao
    {


       void cadastraFoto(Foto oFotoModel);
       ListaFotos buscaFotoVisitante(Foto oFotoModel);
       Dictionary<int, byte[]> lastIdFotoSaved();
    }
}
