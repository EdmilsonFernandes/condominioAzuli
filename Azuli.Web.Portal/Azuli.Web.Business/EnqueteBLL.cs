using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class EnqueteBLL:Interfaces.IEnquete
    {
        ListaEnquete oListaEnquete = new ListaEnquete();
        EnqueteDAO oEnqueteDAO = new EnqueteDAO();
         
        #region IEnquete Members

        public Model.ListaEnquete resultadoEnquete()
        {
           
            try
            {
                return oListaEnquete = oEnqueteDAO.resultadoEnquete();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void cadastraVotacao(Model.Enquete oEnquete)
        {
            try
            {
                oEnqueteDAO.cadastraVotacao(oEnquete);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
