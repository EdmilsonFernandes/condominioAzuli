using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;

namespace Azuli.Web.Business
{
    public class ClassificadoVisto:Interfaces.IClassificadoVisto
    {
        ClassificadoVistoDAO oClassDaoVisto = new ClassificadoVistoDAO();

        #region IClassificadoVisto Members



        public void contabilizaVistoClassificado(Model.ClassificadoVisto oClassVisto)
        {
          
            try
            {
                oClassDaoVisto.contabilizaVistoClassificado(oClassVisto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaClassificadoVisto listaClassificadoVisto(Model.ClassificadoVisto oClassVisto)
        {
            listaClassificadoVisto oListClassificado = new listaClassificadoVisto();

            try
            {
                return oClassDaoVisto.listaClassificadoVisto(oClassVisto);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public listaClassificadoVisto validaClassificadoVisto(Model.ClassificadoVisto oClassificadoVisto)
        {
            listaClassificadoVisto oListClassificado = new listaClassificadoVisto();

            try
            {
                return oClassDaoVisto.validaClassificadoVisto(oClassificadoVisto);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        #endregion
    }
}
