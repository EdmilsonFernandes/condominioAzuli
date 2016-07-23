using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Azuli.Web.Model;
using Azuli.Web.DAO;
using System.Data;


namespace Azuli.Web.Dao
{
    public class LeituraSabespDao :AcessoDAO
    {

        public void cadastrarLeituraSabesp(LeituraSabesp oLeitura)
        {
            string clausulaSQL = "SP_CADASTRA_LEITURA";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);

                comandoSql.Parameters.AddWithValue("@MES_REFERENCIA", oLeitura.mesReferencia);
                comandoSql.Parameters.AddWithValue("@DATA_ATUAL", oLeitura.dataAtual);
                comandoSql.Parameters.AddWithValue("@DATA_ANTERIOR", oLeitura.dataAnterior);
                comandoSql.Parameters.AddWithValue("@DIAS", oLeitura.dias);
                ExecutaComando(comandoSql);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public ListaSabesp listaLeituraSabesp(string mesReferencia, string dataAtual)
        {

            string clausulaSQL = "SP_LISTA_LEITURA_SABESP";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@MES_REFERENCIA", mesReferencia);
                comandoSQL.Parameters.AddWithValue("@ANO_REFERENCIA", dataAtual);

                DataTable tbFoto = new DataTable();

                tbFoto = ExecutaQuery(comandoSQL);

                return populaLeituraSabesp(tbFoto);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void atualizaLeituraSabesp(LeituraSabesp oLeitura)
        {

            string clausulaSQL = "SP_ATUALIZA_LEITURA_SABESP";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@MES_REFERENCIA", oLeitura.mesReferencia);
                comandoSQL.Parameters.AddWithValue("@DATA_ANTERIOR", oLeitura.dataAnterior);
                comandoSQL.Parameters.AddWithValue("@DATA_ATUAL", oLeitura.dataAtual);
                comandoSQL.Parameters.AddWithValue("@PERIODO", oLeitura.dias);

                ExecutaComando(comandoSQL);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ListaSabesp listaLeituraSabespGeral()
        {

            string clausulaSQL = "SP_LISTA_LEITURA_SABESP_GERAL";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                DataTable tbFoto = new DataTable();
                tbFoto = ExecutaQuery(comandoSQL);
                return populaLeituraSabesp(tbFoto);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private ListaSabesp populaLeituraSabesp(DataTable dt)
        {
            ListaSabesp oListaSabesp = new ListaSabesp();

            foreach (DataRow dr in dt.Rows)
            {
                LeituraSabesp oLeituraSabesp = new LeituraSabesp();

                oLeituraSabesp.idLeitura = Convert.ToInt32(dr["ID_LEITURA_SABESP"]);
                oLeituraSabesp.mesReferencia = dr["MES_REFERENCIA"].ToString();
                oLeituraSabesp.dataAtual = Convert.ToDateTime(dr["DATA_ATUAL"]);    
                oLeituraSabesp.dataAnterior = Convert.ToDateTime(dr["DATA_ANTERIOR"]);
                oLeituraSabesp.dias = Convert.ToInt32(dr["DIAS"]);

                oListaSabesp.Add(oLeituraSabesp);

            }

            return oListaSabesp;

        }
    }
}