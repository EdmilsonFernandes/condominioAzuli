using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data;

namespace Azuli.Web.DAO.Interfaces
{
    public interface ILancamentoOcorrencia
    {
        listaLancamentoOcorrencia buscaOcorrenciaByMeses(LancamentoOcorrenciaModel olancamento, int mes, int ano);
        listaLancamentoOcorrencia populaOcorrencia(DataTable dt);
        listaLancamentoOcorrencia buscaOcorrenciaById(LancamentoOcorrenciaModel olancamento);
        listaLancamentoOcorrencia listaReclamacoesAbertas(LancamentoOcorrenciaModel oLancamento);
    }

}
