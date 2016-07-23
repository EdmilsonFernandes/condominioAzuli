using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;
using Azuli.Web.Dao;
namespace Azuli.Web.Business
{
    public class LeituraSabespBLL
    {

        LeituraSabespDao oLeituraSabespDao = new LeituraSabespDao();

        public void cadastraLeituraSabels(LeituraSabesp oLeituraSabesp)
        {


            try
            {
                oLeituraSabespDao.cadastrarLeituraSabesp(oLeituraSabesp);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public void atualizaLeituraSabesp(LeituraSabesp oLeituraSabesp)
        {


            try
            {
                oLeituraSabespDao.atualizaLeituraSabesp(oLeituraSabesp);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaSabesp buscaLeitura(string mes, string ano)
        {
            ListaSabesp oListaSabesp = new ListaSabesp();
            try
            {
                return oListaSabesp = oLeituraSabespDao.listaLeituraSabesp(mes, ano);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ListaSabesp buscaLeituraGeral()
        {
            ListaSabesp oListaSabesp = new ListaSabesp();
            try
            {
                return oListaSabesp = oLeituraSabespDao.listaLeituraSabespGeral();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
