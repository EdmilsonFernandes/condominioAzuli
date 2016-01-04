using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Azuli.Web.Model;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class ContaAguaDAO:AcessoDAO, Interfaces.IContaAguaDAO
    {

        #region IContaAguaDAO Members

        public List<int> validaContaMesAnoMorador(ContaAgua oContaModel)
        {

            string clausulaSQL = "SP_VALIDA_CONTA_AGUA_MORADOR";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@ANO", oContaModel.ano);
                comandoSql.Parameters.AddWithValue("@BLOCO", oContaModel.modelAp.bloco);
                comandoSql.Parameters.AddWithValue("@APTO", oContaModel.modelAp.apartamento);

                DataTable dtAgua = new DataTable();

                dtAgua = ExecutaQuery(comandoSql);

                return checkValueContaAgua(dtAgua);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private List<int> checkValueContaAgua(DataTable dt)
        {
            List<int> contadorAgua = new List<int>() ;

            foreach (DataRow item in dt.Rows)
            {

                contadorAgua.Add(Convert.ToInt32(item["mes"]));
            }

            return contadorAgua;
        }

        #endregion
    }
}
