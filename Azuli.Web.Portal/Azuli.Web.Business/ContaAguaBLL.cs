using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;

namespace Azuli.Web.Business
{
    public class ContaAguaBLL:Interfaces.IContaAgua
    {

        #region IContaAgua Members

        public List<int> validaContaMesAnoMorador(ContaAgua oContaModel)
        {
            List<int> contador = new List<int>();
            ContaAguaDAO oContaDAO = new ContaAguaDAO();
            try
            {

                contador = oContaDAO.validaContaMesAnoMorador(oContaModel);

                return contador;

            }

            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
