using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class GrupoClassificadoBLL:Interfaces.IGrupoClassificados
    {
        public void cadastrarGrupoClassificados(Model.GrupoClassificados OgrupoClassifica)
        {
            throw new NotImplementedException();
        }

        public void alteraGrupoClassificados(Model.GrupoClassificados oGrupoClassifica)
        {
            throw new NotImplementedException();
        }

        public Model.listaGrupoClassificado listaGrupoClassificado(GrupoClassificados oGrupoClassifica)
        {
            Model.listaGrupoClassificado olistGrp = new listaGrupoClassificado();
            GrupoClassificadosDAO oGrpClassificaDAO = new GrupoClassificadosDAO();
            try 
            {

                return olistGrp = oGrpClassificaDAO.listaGrupoClassificado(oGrupoClassifica); 


            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
    }
}
