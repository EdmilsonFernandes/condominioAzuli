using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Azuli.Web.Model;

namespace Azuli.Web.DAO
{
    public class FileDAO:AcessoDAO, Interfaces.IFile
    {

        #region IFile Members
        Dictionary<int, int> qtdMes = new Dictionary<int,int>();
        int qtd = 0;
        int mes = 0;
        public void publicarArquivo(Model.File oFile)
        {
            string clausulaSQL = "PUBLICAR_ARQUIVO";



            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@MES", oFile.mes);
                comandoSQL.Parameters.AddWithValue("@ANO", oFile.ano);
                comandoSQL.Parameters.AddWithValue("@NOME_ARQUIVO", oFile.nameFile);
                comandoSQL.Parameters.AddWithValue("@AREA_PUBLICACAO", oFile.areaPublicacao);
                comandoSQL.Parameters.AddWithValue("@ASSUNTO", oFile.assunto);


              

                ExecutaComando(comandoSQL);

               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Model.ListFile consultaArquivo(Model.File oFile)
        {
            throw new NotImplementedException();
        }



        public int validaCircular(Model.File oFile)
        {
            string clausulaSQL = "VALIDA_PUBLICACAO_CIRCULAR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@MES", oFile.mes);
                comandoSQL.Parameters.AddWithValue("@ANO", oFile.ano);
       
                DataTable tbFile = new DataTable();

                tbFile = ExecutaQuery(comandoSQL);

                return listaValidacaoPublicacao(tbFile);


            }
            catch (Exception)
            {

                throw;
            }
        }


        





        public int listaValidacaoPublicacao(DataTable dt)
        {
           int quantidade = 0;

            foreach (DataRow dr in dt.Rows)
            {
              
                quantidade = Convert.ToInt32(dr["PUBLICADO"]);
               
            }

            return quantidade;
        }


        public Dictionary<int, int> contaArquivos(DataTable dt)
        {
         
            
            foreach (DataRow dr in dt.Rows)
            {

                 qtd = Convert.ToInt32(dr["qtd"]);
                 mes = Convert.ToInt32(dr["MES"]);

                 qtdMes.Add(mes,qtd);
              

            }

            return qtdMes;
        }



        public ListFile listArquivosCircularByAnoMes(DataTable dt)
        {
            ListFile olistFile = new ListFile();

            foreach (DataRow dr in dt.Rows)
            {
                File oFileModel = new File();

                oFileModel.assunto = dr["ASSUNTO"].ToString();
                oFileModel.mes = Convert.ToInt32(dr["MES"]);
                oFileModel.ano =  Convert.ToInt32(dr["ANO"]);
                oFileModel.nameFile =  dr["NOME_ARQUIVO"].ToString();
                oFileModel.dataPublicacao = Convert.ToDateTime(dr["DATA_GRAVACAO"]);
                oFileModel.nomeAreaPublicacao = dr["SITE_PUBLICACAO"].ToString();

                olistFile.Add(oFileModel);

            }

            return olistFile;
        }







        public Dictionary<int, int> contaArquivoByMeses(File oFile)
        {
            string clausulaSQL = "CONTA_ARQUIVOS_PUBLICADOS";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@ANO", oFile.ano);

                DataTable tbFile = new DataTable();

                tbFile = ExecutaQuery(comandoSQL);

                return contaArquivos(tbFile);


            }
            catch (Exception)
            {

                throw;
            }
        }

        


        public ListFile listaArquivoCircular(File oFile)
        {
            string clausulaSQL = "LISTA_ARQUIVOS_CIRCULAR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@MES", oFile.mes);
                comandoSQL.Parameters.AddWithValue("@ANO", oFile.ano);

                DataTable tbFile = new DataTable();

                tbFile = ExecutaQuery(comandoSQL);

                return listArquivosCircularByAnoMes(tbFile);


            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
