using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class ConfiguracaoReservaBLL:Interfaces.IConfiguraReserva
    {
        ConfiguracaoReservaDAO oConfigDao = new ConfiguracaoReservaDAO();
        #region IConfiguraReserva Members

        public Model.ListaConfiguracaoReserva oListaValorReserva()
        {
            ListaConfiguracaoReserva oList = new ListaConfiguracaoReserva();

            try
            {
               oList =  oConfigDao.oListaValorReserva();

               return oList;

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public void cadastraValorArea(Model.ConfiguraReserva oConfiguraReserva)
        {
            try
            {

                oConfigDao.cadastraValorArea(oConfiguraReserva);

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public void alteraConfiguracaArea(Model.ConfiguraReserva oConfiguraReserva)
        {
            try
            {
                oConfigDao.alteraConfiguracaArea(oConfiguraReserva);

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }


        public void deletaReserva(ConfiguraReserva oConfiguraReserva)
        {
            try
            {
                oConfigDao.deletaReserva(oConfiguraReserva);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion
    }
}
