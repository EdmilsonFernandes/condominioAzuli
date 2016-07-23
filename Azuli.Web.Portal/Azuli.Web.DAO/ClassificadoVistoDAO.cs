using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Azuli.Web.Model;
using System.Data.SqlClient;


namespace Azuli.Web.DAO
{
    public class ClassificadoVistoDAO:AcessoDAO, Interfaces.IClassificadoVisto
    {
        #region IClassificadoVisto Members

        public void contabilizaVistoClassificado(ClassificadoVisto oClassificadoVisto)
        {
            string clausulaSql = "SP_CLASSIFICADO_VISTO";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSql);
                comandoSql.Parameters.AddWithValue("@ID_CLASSIFICADO_VISTO", oClassificadoVisto.oClassificadoID.idClassificado);
                comandoSql.Parameters.AddWithValue("@DATA_VISTO", oClassificadoVisto.dataVisto);
                comandoSql.Parameters.AddWithValue("@BLOCO_VISTO", oClassificadoVisto.oApartamento.bloco);
                comandoSql.Parameters.AddWithValue("@APARTAMENTO_VISTO", oClassificadoVisto.oApartamento.apartamento);
              

                ExecutaComando(comandoSql);

            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public Model.listaClassificadoVisto validaClassificadoVisto(Model.ClassificadoVisto oClassificadoVisto)
        {
            string clausulaSql = "SP_VALIDA_CLASSIFICADO";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSql);
                comandoSql.Parameters.AddWithValue("@ID_CLASSIFICADO_VISTO", oClassificadoVisto.oClassificadoID.idClassificado);
                comandoSql.Parameters.AddWithValue("@DATA_VISTO", oClassificadoVisto.dataVisto);
                comandoSql.Parameters.AddWithValue("@BLOCO_VISTO", oClassificadoVisto.oApartamento.bloco);
                comandoSql.Parameters.AddWithValue("@APARTAMENTO_VISTO", oClassificadoVisto.oApartamento.apartamento);
            

                DataTable tbClassificado = new DataTable();

                tbClassificado = ExecutaQuery(comandoSql);

                return buscaClassificado(tbClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Model.listaClassificadoVisto listaClassificadoVisto(ClassificadoVisto oClassificadoVisto)
        {
            string clausulaSql = "SP_LISTA_CLASSIFICADO_VISTO";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSql);
                comandoSql.Parameters.AddWithValue("@ID_CLASSIFICADO_VISTO", oClassificadoVisto.oClassificadoID.idClassificado);
               
                DataTable tbClassificado = new DataTable();

                tbClassificado = ExecutaQuery(comandoSql);

                return buscaClassificado(tbClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private listaClassificadoVisto buscaClassificado(DataTable dt)
        {
            Model.listaClassificadoVisto olistClassificado = new listaClassificadoVisto();


            foreach (DataRow itemOcorrencia in dt.Rows)
            {
                ClassificadoVisto oClassificadoVisto = new ClassificadoVisto();
            
                oClassificadoVisto.contadorClassificado = Convert.ToInt32(itemOcorrencia["ANUNCIO_VISTO"]);

                olistClassificado.Add(oClassificadoVisto);

            }

            return olistClassificado;
        }


       

        #endregion
    }
}
