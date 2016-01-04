using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data;
using System.Data.SqlClient;


namespace Azuli.Web.DAO
{
    public class EnqueteDAO:AcessoDAO,Interfaces.IEnquete
    {
        #region IEnquete Members

        public ListaEnquete resultadoEnquete()
        {
            string clausulaSQL = "RESULTADO_ENQUETE";
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                DataTable tbResultadoEnquete = ExecutaQuery(comandoSQL);

                return resultadoEnquete(tbResultadoEnquete);

            }
            catch (Exception)
            {
                
                throw;
            }
        }



        public void cadastraVotacao(Enquete oEnquete)
        {
            string clausulaSQL = "SP_VOTACAO_ENQUETE";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@ID_ENQUETE", oEnquete.idEnquete);
                comandoSQL.Parameters.AddWithValue("@DESCRICAO_ENQUETE", oEnquete.enqueteDescricao);
                comandoSQL.Parameters.AddWithValue("@VOTACAO", oEnquete.resultadoEnquete);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oEnquete.oAP.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oEnquete.oAP.apartamento);

                ExecutaComando(comandoSQL);

            }
            catch (Exception)
            {
                
                throw;
            }
        }



        private ListaEnquete resultadoEnquete(DataTable dt)
        {
            ListaEnquete oListEnquete = new ListaEnquete();
           
            ApartamentoModel oApEnquete = new ApartamentoModel();
            

            foreach (DataRow itemOcorrencia in dt.Rows)
            {
                Enquete oEnquete = new Enquete();

                if (itemOcorrencia.Table.Columns.Contains("idEnquete"))
                    oEnquete.idEnquete = Convert.ToInt32(itemOcorrencia["idEnquete"]);

                if (itemOcorrencia.Table.Columns.Contains("descEnquete"))
                    oEnquete.enqueteDescricao = itemOcorrencia["descEnquete"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("soma"))
                    oEnquete.resultadoEnquete = Convert.ToInt32(itemOcorrencia["soma"]);

                if (itemOcorrencia.Table.Columns.Contains("ap"))
                    oApEnquete.apartamento = Convert.ToInt32(itemOcorrencia["ap"]);


                if (itemOcorrencia.Table.Columns.Contains("bloco"))
                    oApEnquete.bloco = Convert.ToInt32(itemOcorrencia["bloco"]);
                oEnquete.oAP = oApEnquete;


                if (itemOcorrencia.Table.Columns.Contains("votacao"))
                    oEnquete.resultadoEnquete = Convert.ToInt32(itemOcorrencia["votacao"]);

                if (itemOcorrencia.Table.Columns.Contains("dataResposta"))
                    oEnquete.dataResposta = Convert.ToDateTime(itemOcorrencia["dataResposta"]);


                oListEnquete.Add(oEnquete);
            }

            return oListEnquete;
        }

        


        #endregion
    }
}
