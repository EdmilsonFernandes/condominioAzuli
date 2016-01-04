using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IVisitante
    {
        void cadastraVisitante(Model.Visitante oVisitante);
        void atualizaVisitante(Model.Visitante oVisitante);
        listVisitante procuraVisitanteRG(Model.Visitante oVisitante);
        listVisitante procuraVisitanteNome(Model.Visitante oVisitante);
    }
}
