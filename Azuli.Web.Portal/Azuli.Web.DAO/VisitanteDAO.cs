using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data;
using System.Data.SqlClient;

namespace Azuli.Web.DAO
{
    public class VisitanteDAO : AcessoDAO, Interfaces.IVisitante
    {

        public void cadastraVisitante(Model.Visitante oVisitante)
        {
            string clausulaSQL = "SP_VISITANTE";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@VisitanteNome", oVisitante.visitanteNome);
                comandoSql.Parameters.AddWithValue("@VisitanteRG", oVisitante.visitanteRG);
                comandoSql.Parameters.AddWithValue("@VisitanteTipo", oVisitante.visitanteTipo);
                comandoSql.Parameters.AddWithValue("@ID_FOTO", oVisitante.idFoto.idFoto);

                ExecutaComando(comandoSql);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Atualiza apenas as variáveis que foram alteradas filtrada pelo ID do cliente
        /// --Autor: Leando Vilela
        /// </summary>
        /// <param name="oVisitante"></param>
        public void atualizaVisitante(Model.Visitante oVisitante)
        {
            string clausulaSQL = "SP_ATUALIZA_VISITANTE";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@VisitanteId", oVisitante.visitanteId);
                comandoSql.Parameters.AddWithValue("@VisitanteNome", oVisitante.visitanteNome);
                comandoSql.Parameters.AddWithValue("@VisitanteRG", oVisitante.visitanteRG);
                comandoSql.Parameters.AddWithValue("@VisitanteTipo", oVisitante.visitanteTipo);

                ExecutaComando(comandoSql);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Procura o visitante pelo RG e retorna todas as informações do cadastro
        /// --Autor: Leandro Vilela
        /// </summary>
        /// <param name="oVisitante"></param>
        public listVisitante procuraVisitanteRG(Model.Visitante oVisitante)
        {
            string clausulaSQL = "SP_PROCURA_VISITANTE_RG";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@VisitanteId", oVisitante.visitanteId);
                comandoSql.Parameters.AddWithValue("@VisitanteNome", oVisitante.visitanteNome);
                comandoSql.Parameters.AddWithValue("@VisitanteRG", oVisitante.visitanteRG);
                comandoSql.Parameters.AddWithValue("@VisitanteTipo", oVisitante.visitanteTipo);

                DataTable dtVisitanteRG = new DataTable();

                dtVisitanteRG = ExecutaQuery(comandoSql);

                return populaVisitante(dtVisitanteRG);


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Procura visitante pelo nome, pode retornar mais que um nome, pois a Stored Procedure usa Like no nome
        /// --Auto: Leandro Vilela
        /// </summary>
        /// <param name="oVisitante"></param>
        public listVisitante procuraVisitanteNome(Model.Visitante oVisitante)
        {
            string clausulaSQL = "SP_PROCURA_VISITANTE_NOME";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@VisitanteId", oVisitante.visitanteId);
                comandoSql.Parameters.AddWithValue("@VisitanteNome", oVisitante.visitanteNome);
                comandoSql.Parameters.AddWithValue("@VisitanteRG", oVisitante.visitanteRG);
                comandoSql.Parameters.AddWithValue("@VisitanteTipo", oVisitante.visitanteTipo);

                DataTable dtVisitanteNome = new DataTable();

                dtVisitanteNome = ExecutaQuery(comandoSql);

                return populaVisitante(dtVisitanteNome);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private listVisitante populaVisitante(DataTable dt)
        {
            listVisitante oListVisitante = new listVisitante();

            foreach (DataRow item in dt.Rows)
            {

                Visitante oVisitanteModel = new Visitante();
                Foto oFotoModel = new Foto();

                oVisitanteModel.visitanteId = Convert.ToInt32(item["VisitanteId"]);
                oVisitanteModel.visitanteNome = item["VisitanteNome"].ToString();
                oVisitanteModel.visitanteRG = item["VisitanteRG"].ToString();
                oVisitanteModel.visitanteTipo = item["VisitanteTipo"].ToString();
                oFotoModel.idFoto = Convert.ToInt32(item["ID_FOTO"]);
                oVisitanteModel.idFoto = oFotoModel;

                oListVisitante.Add(oVisitanteModel);

            }

            return oListVisitante;
        }
    }
}
