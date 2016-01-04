using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data.SqlClient;
using System.Data;

namespace Azuli.Web.DAO
{
    public class FotoDAO:AcessoDAO, Interfaces.IFotoDao
    {
        public void cadastraFoto(Foto ofotoModel)
        {
            string clausulaSQL = "SP_CADASTRA_FOTO_VISITANTE";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);

                comandoSql.Parameters.AddWithValue("@FOTO", ofotoModel.foto);

                ExecutaComando(comandoSql);

            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public ListaFotos buscaFotoVisitante(Foto oFotoModel)
        {

            string clausulaSQL = "SP_LISTA_FOTO_VISITANTE";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@ID", oFotoModel.idFoto);

                DataTable tbFoto = new DataTable();

                tbFoto = ExecutaQuery(comandoSQL);

                return populaFoto(tbFoto);

            }
            catch (Exception)
            {
                
                throw;
            }
        }



        private ListaFotos populaFoto(DataTable dt)
        {
            ListaFotos oListaFoto = new ListaFotos();

            foreach (DataRow dr in dt.Rows)
            {
                Foto oFotoModel = new Foto();

                oFotoModel.idFoto =  Convert.ToInt32(dr["ID_FOTO"]);
                oFotoModel.foto = (byte[])dr["FOTO"];
                oFotoModel.dataInclusao = Convert.ToDateTime(dr["DATA"]);

                oListaFoto.Add(oFotoModel);
                
            }

            return oListaFoto;

        }

        private Dictionary<int,byte[]> pegaUltimoIdFoto(DataTable dt)
        {
        
            Dictionary<int, byte[]> ultimoFoto = new Dictionary<int, byte[]>();
          
            foreach (DataRow dr in dt.Rows)
            {
                Foto oFotoModel = new Foto();

                 ultimoFoto.Add(Convert.ToInt32(dr["MAX_ID_FOTO"]),(byte[])dr["FOTO"]);


            }

            return ultimoFoto;

        }


        public Dictionary<int,byte[]> lastIdFotoSaved()
        {

            string clausulaSQL = "SP_MAXIMO_ID_FOTO";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                DataTable tbFoto = new DataTable();

                tbFoto = ExecutaQuery(comandoSQL);

                return pegaUltimoIdFoto(tbFoto);

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
