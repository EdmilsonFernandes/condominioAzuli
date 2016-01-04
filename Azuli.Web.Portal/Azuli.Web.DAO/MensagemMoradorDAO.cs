using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Azuli.Web.Model;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class MensagemMoradorDAO:AcessoDAO, Interfaces.IMensagemMorador
    {
        #region IMensagemMorador Members

        public listaMensagemMorador listaMensagemMorador(Model.MensagemMoradorModel oAp)
        {
            string clausulaSQL = "SP_MENSAGEM_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@AP", oAp.oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@STATUS_PARAM",oAp.status);
                
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaMensagemMorador(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaMensagemMorador pesquisaMensagemMorador(Model.MensagemMoradorModel oAp)
        {
            string clausulaSQL = "SP_PESQUISA_MENSAGEM_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@AP", oAp.oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@STATUS", oAp.status);
                comandoSQL.Parameters.AddWithValue("@ASSUNTO",  oAp.assunto);
                comandoSQL.Parameters.AddWithValue("@MENSAGEM", oAp.mensagem);
                comandoSQL.Parameters.AddWithValue("@DATA_INICIO", oAp.data_inicio);
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaMensagemMorador(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaMensagemMorador  listaMensagemMoradorByID(MensagemMoradorModel oAp)
        {



            string clausulaSQL = "SP_MENSAGEM_MORADOR_BY_ID"; 
                    
            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@CODIGO_MSG", oAp.codigoMsg);
               
                
                DataTable tbProprietario = new DataTable();

                tbProprietario = ExecutaQuery(comandoSQL);

                return listaMensagemMorador(tbProprietario);


            }
            catch (Exception)
            {

                throw;
            }
        }


        public void cadastraContato(string assunto, string descricao, int bloco, int ap)
        {
            string clausulaSQL = "CADASTRA_CONTATO";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);


                comandoSQL.Parameters.AddWithValue("@ASSUNTO", assunto);
                comandoSQL.Parameters.AddWithValue("@DESCRICAO", descricao);
                comandoSQL.Parameters.AddWithValue("@BLOCO", bloco);
                comandoSQL.Parameters.AddWithValue("@AP", ap);
             
                ExecutaComando(comandoSQL);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public void enviaMensagemMorador(Model.MensagemMoradorModel oMensagem)
        {
            string clausulaSQL = "ENVIA_MENSAGEM_MORADOR";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
               
                
           
                comandoSQL.Parameters.AddWithValue("@BLOCO", oMensagem.oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oMensagem.oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@MENSAGEM", oMensagem.mensagem);
                comandoSQL.Parameters.AddWithValue("@STATUS", oMensagem.status);
                comandoSQL.Parameters.AddWithValue("@ATIVO", oMensagem.ativo);
                comandoSQL.Parameters.AddWithValue("@ASSUNTO", oMensagem.assunto);
                comandoSQL.Parameters.AddWithValue("@De", oMensagem.deMsg);
                comandoSQL.Parameters.AddWithValue("@TodosUser", oMensagem.todosMoradores);


                 ExecutaComando(comandoSQL);


            }
            catch (Exception)
            {

                throw;
            }
        }

    

        public listaMensagemMorador listaMensagemMorador(DataTable dt)
        {
            listaMensagemMorador oListMensagemMorador = new listaMensagemMorador();

            foreach (DataRow dr in dt.Rows)
            {
                MensagemMoradorModel oMensagem = new MensagemMoradorModel();
                ApartamentoModel oPropri = new ApartamentoModel();

                if (dr.Table.Columns.Contains("ID_MSG"))
                    oMensagem.codigoMsg = Convert.ToInt32(dr["ID_MSG"]);

                oMensagem.mensagem = dr["MENSAGEM"].ToString();
                oPropri.apartamento = Convert.ToInt32(dr["APARTAMENTO"]);
                oPropri.bloco = Convert.ToInt32(dr["BLOCO"]);
                oMensagem.ativo = dr["ATIVO"].ToString();
                oMensagem.status = dr["STATUS"].ToString();
                oMensagem.data_inicio = Convert.ToDateTime(dr["DATA_INICIO"]);
                oMensagem.data_fim = Convert.ToDateTime(dr["DATA_FIM"]);
                oMensagem.qtdMsg = Convert.ToInt32(dr["QTDMGS"]);
                oMensagem.assunto = dr["ASSUNTO"].ToString();
                oMensagem.deMsg = dr["De"].ToString();
                oMensagem.oAp = oPropri;

                oListMensagemMorador.Add(oMensagem);

            }

            return oListMensagemMorador;
        }

   

        public void atualizaMSG(MensagemMoradorModel oAp)
        {
            string clausulaSQL = "SP_MENSAGEM_MORADOR_ATUALIZA_MSG";

            try
            {

                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@CODIGO_MSG", oAp.codigoMsg);
                ExecutaComando(comandoSQL);

            }
            catch (Exception)
            {

                throw;
            }
        }

      
        #endregion
    }
}
