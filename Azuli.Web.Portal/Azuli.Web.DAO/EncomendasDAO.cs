using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class EncomendasDAO: AcessoDAO
    {

        public void cadastraEncomendas(Model.Encomendas oEncomendas)
        {
            string clausulaSQL = "SP_ENCOMENDAS";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@Bloco", oEncomendas.Bloco);
                comandoSql.Parameters.AddWithValue("@Apartamento", oEncomendas.Apartamento);
                comandoSql.Parameters.AddWithValue("@EncDtaRec", oEncomendas.EncDtaRec);
                comandoSql.Parameters.AddWithValue("@EncDesc", oEncomendas.EncDesc);
                comandoSql.Parameters.AddWithValue("@EncEntr", oEncomendas.EncEntr);
                comandoSql.Parameters.AddWithValue("@EncQuemPegou", oEncomendas.EncQuemPegou);
                comandoSql.Parameters.AddWithValue("@EncQuanPegou", oEncomendas.EncQuanPegou);
                comandoSql.Parameters.AddWithValue("@EncUserBxa", oEncomendas.EncUserBxa);
                
                ExecutaComando(comandoSql);
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
