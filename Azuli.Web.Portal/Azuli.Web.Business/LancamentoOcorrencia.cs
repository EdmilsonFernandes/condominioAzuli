using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class LancamentoOcorrencia : Interfaces.ILancamentoOcorrencia
    {
        #region ILancamentoOcorrencia Members

        public Model.listaLancamentoOcorrencia buscaOcorrenciaByMeses(Model.LancamentoOcorrenciaModel olancamento, int mes, int ano)
        {
            try
            {
                Azuli.Web.DAO.LancamentoOcorrencia oLancamentoDAO = new Azuli.Web.DAO.LancamentoOcorrencia();

                return oLancamentoDAO.buscaOcorrenciaByMeses(olancamento, mes, ano);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Model.listaLancamentoOcorrencia listaReclamacoesAbertas(Model.LancamentoOcorrenciaModel oLancamento)
        {
            try
            {
                Azuli.Web.DAO.LancamentoOcorrencia oLancamentoDAO = new Azuli.Web.DAO.LancamentoOcorrencia();

                return oLancamentoDAO.listaReclamacoesAbertas(oLancamento);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Model.listaLancamentoOcorrencia buscaOcorrenciaById(Model.LancamentoOcorrenciaModel olancamento)
        {
            Azuli.Web.DAO.LancamentoOcorrencia oLancamentoDAO = new Azuli.Web.DAO.LancamentoOcorrencia();

            return oLancamentoDAO.buscaOcorrenciaById(olancamento);
        }

        #endregion

        Model.listaLancamentoOcorrencia Interfaces.ILancamentoOcorrencia.buscaOcorrenciaByMeses(Model.LancamentoOcorrenciaModel olancamento, int mes, int ano)
        {
            throw new NotImplementedException();
        }

        Model.listaLancamentoOcorrencia Interfaces.ILancamentoOcorrencia.buscaOcorrenciaById(Model.LancamentoOcorrenciaModel olancamento)
        {
            throw new NotImplementedException();
        }

    }
}
