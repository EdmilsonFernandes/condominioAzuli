using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Azuli.Web.Model;
using System.Data;

namespace Azuli.Web.DAO
{
    public class GrupoClassificadosDAO : AcessoDAO, Interfaces.IGrupoClassificados
    {


        #region IGrupoClassificados Members
        string acao = "";
        public const string clausulaSQL = "SP_CLASSIFICADO_GRUPO";
        public void cadastrarGrupoClassificados(Model.GrupoClassificados OgrupoClassifica)
        {


            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);

                acao = "I";

                comandoSql.Parameters.AddWithValue("@Acao", acao);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", OgrupoClassifica.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Descricao", OgrupoClassifica.descricacaoGrupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Status", OgrupoClassifica.statusClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo_Img", OgrupoClassifica.imgGrupoClassificado);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void alteraGrupoClassificados(Model.GrupoClassificados oGrupoClassifica)
        {
            throw new NotImplementedException();
        }

        public listaGrupoClassificado listaGrupoClassificado(Model.GrupoClassificados oGrupoClassifica)
        {

            try
            {

                SqlCommand comandoSql = new SqlCommand(clausulaSQL);

                acao = "C";


                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oGrupoClassifica.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Descricao", oGrupoClassifica.descricacaoGrupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Status", oGrupoClassifica.statusClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo_Img", oGrupoClassifica.imgGrupoClassificado);
                comandoSql.Parameters.AddWithValue("@Acao", acao);

                DataTable tbGrupoClassificado = new DataTable();

                tbGrupoClassificado = ExecutaQuery(comandoSql);

                return populaGrupoClassificado(tbGrupoClassificado);

            }
            catch (Exception)
            {

                throw;
            }


        }

        private listaGrupoClassificado populaGrupoClassificado(DataTable dt)
        {
            listaGrupoClassificado oLitGrp = new listaGrupoClassificado();

            foreach (DataRow dr in dt.Rows)
            {
                GrupoClassificados oGrupoClassifica = new GrupoClassificados();

                oGrupoClassifica.grupoClassificado = Convert.ToInt32(dr["Classificado_Grupo"]);
                oGrupoClassifica.descricacaoGrupoClassificado = dr["Classificado_Descricao"].ToString();
                oGrupoClassifica.statusClassificado = dr["Classificado_Status"].ToString();
                oGrupoClassifica.imgGrupoClassificado = dr["Classificado_Grupo_Img"].ToString();

                oLitGrp.Add(oGrupoClassifica);

            }

            return oLitGrp;


        }

        #endregion



    }
}
