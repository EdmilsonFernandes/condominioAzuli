using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Azuli.Web.Model;
using System.Data;

namespace Azuli.Web.DAO
{
    public class LancamentoOcorrencia : AcessoDAO, Interfaces.ILancamentoOcorrencia
    {


        #region ILancamentoOcorrencia Members

        public listaLancamentoOcorrencia buscaOcorrenciaByMeses(LancamentoOcorrenciaModel olancamento, int mes, int ano)
        {
            string clausulaSQL = "LISTA_OCORRENCIA_MORADOR";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@BLOCO", olancamento.oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", olancamento.oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@MES", mes);
                comandoSQL.Parameters.AddWithValue("@ANO", ano);

                DataTable tbLancamento = new DataTable();

                tbLancamento = ExecutaQuery(comandoSQL);

                return populaOcorrencia(tbLancamento);

            }
            catch (Exception)
            {

                throw;
            }

        }



        public listaLancamentoOcorrencia listaReclamacoesAbertas(LancamentoOcorrenciaModel oLancamento)
        {
            string clausulaSQL = "LISTA_OCORRENCIA_ABERTAS";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@MES", oLancamento.dataOcorrencia);
                comandoSQL.Parameters.AddWithValue("@ANO", oLancamento.dataOcorrencia);

                DataTable tbLancamento = new DataTable();

                tbLancamento = ExecutaQuery(comandoSQL);

                return populaOcorrencia(tbLancamento);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaLancamentoOcorrencia populaOcorrencia(System.Data.DataTable dt)
        {
            listaLancamentoOcorrencia olist = new listaLancamentoOcorrencia();


            foreach (DataRow itemOcorrencia in dt.Rows)
            {
                LancamentoOcorrenciaModel oLancamento = new LancamentoOcorrenciaModel();
                OcorrenciaModel oOcorrencia = new OcorrenciaModel();
                ApartamentoModel Oap = new ApartamentoModel();

                if (itemOcorrencia.Table.Columns.Contains("OCORRENCIA"))
                    oLancamento.codigoOcorrencia = Convert.ToInt32(itemOcorrencia["OCORRENCIA"]);

                if (itemOcorrencia.Table.Columns.Contains("DATA_OCORRENCIA"))
                    oLancamento.dataOcorrencia = Convert.ToDateTime(itemOcorrencia["DATA_OCORRENCIA"]);

                if (itemOcorrencia.Table.Columns.Contains("STATUS"))
                    oLancamento.statusOcorrencia = itemOcorrencia["STATUS"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("DESCRICAO"))
                    oLancamento.ocorrenciaLancamento = itemOcorrencia["DESCRICAO"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("DATA_FINALIZACAO"))
                    oLancamento.dataFinalizacao = Convert.ToDateTime(itemOcorrencia["DATA_FINALIZACAO"]);

                if (itemOcorrencia.Table.Columns.Contains("DATA_CANCELAMENTO"))
                    oLancamento.dataCancelamento = Convert.ToDateTime(itemOcorrencia["DATA_CANCELAMENTO"]);

                if (itemOcorrencia.Table.Columns.Contains("DescricaoOcorrencia"))
                    oLancamento.descricaoOcorrencia = itemOcorrencia["DescricaoOcorrencia"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("imagem"))
                    oLancamento.imagemEvidencia = itemOcorrencia["imagem"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("BLOCO"))
                    Oap.apartamento = Convert.ToInt32(itemOcorrencia["BLOCO"]);

                if (itemOcorrencia.Table.Columns.Contains("AP"))
                    Oap.bloco = Convert.ToInt32(itemOcorrencia["AP"]);

                oLancamento.oAp = Oap;

                olist.Add(oLancamento);


            }

            return olist;
        }




        public listaLancamentoOcorrencia buscaOcorrenciaById(LancamentoOcorrenciaModel olancamento)
        {
            string clausulaSQL = "LISTA_OCORRENCIA_MORADOR_byID";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@CODIGO", olancamento.codigoOcorrencia);
                DataTable tbLancamento = new DataTable();

                tbLancamento = ExecutaQuery(comandoSQL);

                return populaOcorrencia(tbLancamento);

            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion



    }
}
