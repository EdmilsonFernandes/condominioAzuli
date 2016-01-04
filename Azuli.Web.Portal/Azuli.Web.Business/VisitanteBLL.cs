using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;

namespace Azuli.Web.Business
{
    public class VisitanteBLL : Interfaces.IVisitante
    {
        VisitanteDAO oVisitanteDAO = new VisitanteDAO();

        public void cadastraVisitante(Model.Visitante oVisitante)
        {
            try
            {
                oVisitanteDAO.cadastraVisitante(oVisitante);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public listVisitante procuraVisitanteRG(Model.Visitante oVisitante)
        {
            listVisitante oListVst = new listVisitante();
            try
            {
                return oListVst = oVisitanteDAO.procuraVisitanteRG(oVisitante);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public listVisitante procuraVisitanteNome(Model.Visitante oVisitante)
        {
            listVisitante oListVst = new listVisitante();
            try
            {
                return oListVst = oVisitanteDAO.procuraVisitanteNome(oVisitante);
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void atualizaVisitante(Visitante oVisitante)
        {

            try
            {
                oVisitanteDAO.atualizaVisitante(oVisitante);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
