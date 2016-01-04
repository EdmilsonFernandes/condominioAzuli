using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class FotoBLL:Interfaces.IFoto
    {
        FotoDAO oFotoDAO = new FotoDAO();
        public void cadastraFoto(Model.Foto ofotoModel)
        {
         

            try
            {
                oFotoDAO.cadastraFoto(ofotoModel);

            }
            catch (Exception)
            {
                throw;
            }
        }




        public Model.ListaFotos buscaFotoVisitante(Model.Foto oFotoModel)
        {
            Model.ListaFotos oListaFoto = new Model.ListaFotos();
            try
            {
                return oListaFoto = oFotoDAO.buscaFotoVisitante(oFotoModel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public Dictionary<int, byte[]> lastIdFotoSaved()
        {
            Dictionary<int, byte[]> lastIdFoto = new Dictionary<int, byte[]>();

            try
            {

                return lastIdFoto = oFotoDAO.lastIdFotoSaved();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
