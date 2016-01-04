using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class PendenciaAdminBLL:Interfaces.IPendenciaAdmin
    {

        #region IPendenciaAdmin Members

        public Model.ListaPendenciaAdmin listaPendenciaAdmin()
        {
            ListaPendenciaAdmin oListaPendencia = new ListaPendenciaAdmin();

            try
            {
                PendenciaAdminDAO oPendenciaDAO = new PendenciaAdminDAO();

                return oListaPendencia = oPendenciaDAO.listaPendenciaAdmin();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
