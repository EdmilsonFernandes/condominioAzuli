using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    
    public class EncomendaBLL
    {
        EncomendasDAO oEncomendaDAO = new EncomendasDAO();

        public void cadastraEncomendas(Model.Encomendas oEncomendas)
        {
            try
            {
                oEncomendaDAO.cadastraEncomendas(oEncomendas);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
