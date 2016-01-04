using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Azuli.Web.DAO
{
    public class AcessoDAO
    {
          //Atributos
        private SqlTransaction trans;
        private SqlConnection conn;


        #region Construtores
        /// <summary>
        /// Seta a conexão de banco
        /// </summary>
        /// <remarks>Edmilson</remarks>
        public AcessoDAO()
        {
            conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["azulli"].ConnectionString);
        }
        /// <summary>
        /// Retorna objeto conexao
        /// </summary>
        /// <remarks>Edmilson </remarks>
        protected SqlConnection Conexao
        {
            get { return conn; }
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Executa o Comando Passado
        /// </summary>
        /// <param name="cmd">SqlCommand com a instrução a ser executada</param>
        /// <remarks>Edmilson</remarks>
        public void ExecutaComando(SqlCommand cmd)
        {
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                trans.Commit();
                conn.Close();

            }
            catch (Exception e)
            {

                trans.Rollback();
                throw e;

            }
           
        }
        /// <summary>
        /// Executa o comando de select passado e retorna um DataTable
        /// </summary>
        /// <remarks>Edmilson</remarks>
        public DataTable ExecutaQuery(SqlCommand cmd)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.CommandTimeout = 150;
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Executa o comando de select passado e retorna um DataSet com DataTables
        /// </summary>
        /// <remarks>Edmilson</remarks>
        public DataSet ExecutaProcQuery(SqlCommand cmd)
        {
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion
    }
}
