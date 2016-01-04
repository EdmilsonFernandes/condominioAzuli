using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Azuli.Web.Model;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class ConfiguracaoReservaDAO:AcessoDAO,Interfaces.IConfiguracaoReserva
    {

        #region IConfiguracaoReserva Members

        public Model.ListaConfiguracaoReserva oListaValorReserva()
        {
            string clausulaSQL = "SP_LISTA_VALOR_RESERVA";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                DataTable tbConfigura = new DataTable();

                tbConfigura = ExecutaQuery(comandoSql);

                return carregaValores(tbConfigura);

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public void cadastraValorArea(Model.ConfiguraReserva oConfiguraReserva)
        {
            string clausulaSQL = "SP_CADASTRA_RESERVA_VALOR";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@TIPO_AREA", oConfiguraReserva.area);
                comandoSql.Parameters.AddWithValue("@VALOR", oConfiguraReserva.valor);

                ExecutaComando(comandoSql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }


        public void deletaReserva(ConfiguraReserva oConfiguraReserva)
        {
            string clausulaSQL = "SP_DELETA_CONFIGURACAO_RESERVA";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@ID", oConfiguraReserva.id_valor);
               

                ExecutaComando(comandoSql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void alteraConfiguracaArea(Model.ConfiguraReserva oConfiguraReserva)
        {
            string clausulaSQL = "SP_ALTERA_RESERVA_VALOR";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@ID", oConfiguraReserva.id_valor);
                comandoSql.Parameters.AddWithValue("@TIPO_AREA", oConfiguraReserva.area);
                comandoSql.Parameters.AddWithValue("@VALOR", oConfiguraReserva.valor);

                ExecutaComando(comandoSql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       
        private ListaConfiguracaoReserva carregaValores(DataTable dt)
        {
            ListaConfiguracaoReserva oLisConfig = new ListaConfiguracaoReserva();

            foreach (DataRow dr in dt.Rows)
            {

                ConfiguraReserva oConfig = new ConfiguraReserva();

                if (dr.Table.Columns.Contains("ID_PRECO_RESERVA"))
                    oConfig.id_valor = Convert.ToInt32(dr["ID_PRECO_RESERVA"]);

                if (dr.Table.Columns.Contains("TIPO_AREA"))
                    oConfig.area =  dr["TIPO_AREA"].ToString();

                if (dr.Table.Columns.Contains("valor"))
                     oConfig.valor = Convert.ToDouble(dr["valor"]);

                oLisConfig.Add(oConfig);

            }

            return oLisConfig;

        }

  

       

        #endregion
    }
}
