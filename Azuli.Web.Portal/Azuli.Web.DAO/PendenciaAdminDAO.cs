using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class PendenciaAdminDAO:AcessoDAO,Interfaces.IPendenciaAdmin
    {
        #region IPendenciaAdmin Members
       
       
        public ListaPendenciaAdmin listaPendenciaAdmin()
        {
            PendenciaAdmin pendencia = new PendenciaAdmin();
            ListaPendenciaAdmin oListPendAdmin = new ListaPendenciaAdmin();
            string clausulaSQL = "SP_PENDENCIAS_ADM";

            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["azulli"].ToString());

                SqlCommand comandoSQL = new SqlCommand();
                SqlDataReader myReader;

                comandoSQL.CommandText = clausulaSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Connection = conn;

                conn.Open();

                myReader = comandoSQL.ExecuteReader();

            do
             {
                    
              
                while (myReader.Read())
                {

                    //if(myReader.GetSchemaTable().Columns.Contains("CONTADOR_MENSAGEM_PENDENTE"))
                    try
                    {
                        pendencia.qtdMensagemPendente = Convert.ToInt32(myReader["CONTADOR_MENSAGEM_PENDENTE"]);
                    }
                    catch (IndexOutOfRangeException e)
                    {

                        e.ToString();
                    }

                    try
                    {
                        pendencia.qtdOcorrenciaPendente = Convert.ToInt32(myReader["CONTADOR_OCORRENCIA"]);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        e.ToString();
                      
                    }

                    try
                    {
                        pendencia.qtdMoradorPendente = Convert.ToInt32(myReader["CONTADOR_MORADOR"]);
                    }
                    catch (IndexOutOfRangeException e)
                    {

                        e.ToString();
                    }

                    try
                    {
                        pendencia.qtdAgendaNoPrazo = Convert.ToInt32(myReader["CONTADOR_DENTRO_PRAZO"]);

                    }
                    catch (IndexOutOfRangeException e)
                    {

                        e.ToString();

                    }

                    try
                    {
                        pendencia.qtdAgendaForaPrazo = Convert.ToInt32(myReader["CONTADOR_FORA_PRAZO"]);
                    }
                    catch (IndexOutOfRangeException e)
                    {

                        e.ToString();

                    }
                  

                  

                    oListPendAdmin.Add(pendencia);
                }
                    
              } while (myReader.NextResult());

                
                
                //DataSet tbPendencia = new DataSet();
                //tbPendencia = ExecutaProcQuery(comandoSQL);

                //DataTable pendenciaDT = tbPendencia.Tables[0];
                //DataTable pendenciaDT01 = tbPendencia.Tables[1];

                return oListPendAdmin;


            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //private ListaPendenciaAdmin BuscaPendenciaAdmin(DataTable dt)
        //{
        //    ListaPendenciaAdmin oListPendAdmin = new ListaPendenciaAdmin();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        PendenciaAdmin pendencia = new PendenciaAdmin();

           
        //        if (dr.Table.Columns.Contains("CONTADOR_MENSAGEM_PENDENTE"))
        //            pendencia.qtdMensagemPendente = Convert.ToInt32(dr["CONTADOR_MENSAGEM_PENDENTE"]);

        //        if (dr.Table.Columns.Contains("CONTADOR_OCORRENCIA"))
        //            pendencia.qtdOcorrenciaPendente = Convert.ToInt32(dr["CONTADOR_OCORRENCIA"]);


        //        if (dr.Table.Columns.Contains("CONTADOR_MORADOR"))
        //            pendencia.qtdMoradorPendente = Convert.ToInt32(dr["CONTADOR_MORADOR"]);

        //        if (dr.Table.Columns.Contains("CONTADOR_DENTRO_PRAZO"))
                
        //        if (dr.Table.Columns.Contains("CONTADOR_FORA_PRAZO"))
        //            pendencia.qtdAgendaForaPrazo = Convert.ToInt32(dr["CONTADOR_FORA_PRAZO"]);





        //        oListPendAdmin.Add(pendencia);

        //    }

        //    return oListPendAdmin;
        //}

        #endregion
    }
}
