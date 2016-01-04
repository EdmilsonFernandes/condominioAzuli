using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Business.Interfaces
{
    public interface IFoto
    {
        void cadastraFoto(Foto ofotoModel);
        ListaFotos buscaFotoVisitante(Foto oFotoModel);
        Dictionary<int, byte[]> lastIdFotoSaved();
    }
}
