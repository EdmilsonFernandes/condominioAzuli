using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class ClassificadoBLL : Interfaces.IClassificado
    {
        ClassificadoDAO oClassDao = new ClassificadoDAO();

        public void cadastraClassificado(Model.Classificados oClassificado)
        {
            try
            {
                oClassDao.cadastraClassificado(oClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public listClassificados consultaClassificado(Model.Classificados oClassificado)
        {

            listClassificados oListClassificado = new listClassificados();

            try
            {
                return oClassDao.consultaClassificado(oClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public listClassificados contaGrupoClassificado(Classificados oClassificado)
        {

            listClassificados oListClassificado = new listClassificados();

            try
            {
                return oClassDao.contaGrupoClassificado(oClassificado);
            }
            catch (Exception)
            {

                throw;
            }

        }

      


        public void atualizaClassificado(Classificados oClassificado)
        {
            try
            {
                oClassDao.atualizaClassificado(oClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
