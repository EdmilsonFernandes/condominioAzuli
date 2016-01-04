using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Azuli.Web.Model;
using System.Data;

namespace Azuli.Web.DAO
{
    public class ClassificadoDAO : AcessoDAO, Interfaces.IClassificado
    {




        public void cadastraClassificado(Model.Classificados oClassificado)
        {
            string clausulaSQL = "SP_CLASSIFICADO";

            try
            {


                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oClassificado.grpClassificado.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Data", oClassificado.dataClassificado);
                // comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oClassificado.grpClassificado.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Bloco", oClassificado.apartamentoClassificado.bloco);
                comandoSql.Parameters.AddWithValue("@Classificado_AP", oClassificado.apartamentoClassificado.apartamento);
                comandoSql.Parameters.AddWithValue("@Classificado_Descricao", oClassificado.descricaoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Status", oClassificado.statusClassificado);
                // comandoSql.Parameters.AddWithValue("@Classificado_Validade", oClassificado.validadeClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Img1", oClassificado.classificadoimg1);
                comandoSql.Parameters.AddWithValue("@Classificado_Img2", oClassificado.classificadoimg2);
                comandoSql.Parameters.AddWithValue("@Classificado_Img3", oClassificado.classificadoimg3);
                comandoSql.Parameters.AddWithValue("@Classificado_Img4", oClassificado.classificadoimg4);
                comandoSql.Parameters.AddWithValue("@Classificado_email_contato", oClassificado.emailClassificadoContato);
                comandoSql.Parameters.AddWithValue("@Classificado_Tel1", oClassificado.classificadoTelefone1);
                comandoSql.Parameters.AddWithValue("@Classificado_Tel2", oClassificado.classificadoTelefone2);
                comandoSql.Parameters.AddWithValue("@Classificado_Data_Venda", oClassificado.classificadoDataVenda);
                comandoSql.Parameters.AddWithValue("@Classificado_Valor", oClassificado.valorVendaClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Contato", oClassificado.contato);
                comandoSql.Parameters.AddWithValue("@Classificado_assunto", oClassificado.assuntoClassificado);


                ExecutaComando(comandoSql);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public void atualizaClassificado(Classificados oClassificado)
        {
            string clausulaSQL = "SP_ATUALIZA_CLASSIFICADO";

            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                comandoSql.Parameters.AddWithValue("@Classificado_id", oClassificado.idClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oClassificado.grpClassificado.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Descricao", oClassificado.descricaoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Status", oClassificado.statusClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Img1", oClassificado.classificadoimg1);
                comandoSql.Parameters.AddWithValue("@Classificado_Img2", oClassificado.classificadoimg2);
                comandoSql.Parameters.AddWithValue("@Classificado_Img3", oClassificado.classificadoimg3);
                comandoSql.Parameters.AddWithValue("@Classificado_Img4", oClassificado.classificadoimg4);
                comandoSql.Parameters.AddWithValue("@Classificado_email_contato", oClassificado.emailClassificadoContato);
                comandoSql.Parameters.AddWithValue("@Classificado_Tel1", oClassificado.classificadoTelefone1);
                comandoSql.Parameters.AddWithValue("@Classificado_Tel2", oClassificado.classificadoTelefone2);
                comandoSql.Parameters.AddWithValue("@Classificado_Data_Venda", oClassificado.classificadoDataVenda);
                comandoSql.Parameters.AddWithValue("@Classificado_Valor", oClassificado.valorVendaClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_assunto", oClassificado.assuntoClassificado);

                //comandoSql.Parameters.AddWithValue("@Classificado_Data", oClassificado.dataClassificado);
                //comandoSql.Parameters.AddWithValue("@Classificado_Bloco", oClassificado.apartamentoClassificado.bloco);
                //comandoSql.Parameters.AddWithValue("@Classificado_AP", oClassificado.apartamentoClassificado.apartamento);
                //// comandoSql.Parameters.AddWithValue("@Classificado_Validade", oClassificado.validadeClassificado);
                //comandoSql.Parameters.AddWithValue("@Classificado_Contato", oClassificado.contato);
                //comandoSql.Parameters.AddWithValue("@Classificado_assunto", oClassificado.assuntoClassificado);

                ExecutaComando(comandoSql);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public listClassificados contaGrupoClassificado(Classificados oClassificado)
        {
            string clausulaSql = "SP_CLASSIFICADO_CONTA_GRUPO";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSql);

                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oClassificado.grpClassificado.grupoClassificado);


                DataTable tbClassificado = new DataTable();

                tbClassificado = ExecutaQuery(comandoSql);

                return populaClassificados(tbClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Model.listClassificados consultaClassificado(Model.Classificados oClassificado)
        {

            string clausulaSql = "SP_LISTA_CLASSIFICADO";
            try
            {
                SqlCommand comandoSql = new SqlCommand(clausulaSql);
                comandoSql.Parameters.AddWithValue("@Classificado_id", oClassificado.idClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Grupo", oClassificado.grpClassificado.grupoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Data", oClassificado.dataClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Bloco", oClassificado.apartamentoClassificado.bloco);
                comandoSql.Parameters.AddWithValue("@Classificado_AP", oClassificado.apartamentoClassificado.apartamento);
                comandoSql.Parameters.AddWithValue("@Classificado_Descricao", oClassificado.descricaoClassificado);
                comandoSql.Parameters.AddWithValue("@Classificado_Status", oClassificado.statusClassificado);
                //comandoSql.Parameters.AddWithValue("@Classificado_Img1", oClassificado.classificadoimg1);
                //comandoSql.Parameters.AddWithValue("@Classificado_Img2", oClassificado.classificadoimg2);
                //comandoSql.Parameters.AddWithValue("@Classificado_Img3", oClassificado.classificadoimg3);
                //comandoSql.Parameters.AddWithValue("@Classificado_Img4", oClassificado.classificadoimg4);
                //comandoSql.Parameters.AddWithValue("@Classificado_email_contato", oClassificado.emailClassificadoContato);
                //comandoSql.Parameters.AddWithValue("@Classificado_Tel1", oClassificado.classificadoTelefone1);
                //comandoSql.Parameters.AddWithValue("@Classificado_Tel2", oClassificado.classificadoTelefone2);
                //comandoSql.Parameters.AddWithValue("@Classificado_Data_Venda", oClassificado.classificadoDataVenda);
                //comandoSql.Parameters.AddWithValue("@Classificado_Valor", oClassificado.valorVendaClassificado);

                DataTable tbClassificado = new DataTable();

                tbClassificado = ExecutaQuery(comandoSql);

                return populaClassificados(tbClassificado);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private Model.listClassificados populaClassificados(DataTable dt)
        {
            Model.listClassificados olistClassificado = new listClassificados();


            foreach (DataRow itemOcorrencia in dt.Rows)
            {
                Classificados oClassificado = new Classificados();
                GrupoClassificados oGrpClassificados = new GrupoClassificados();
                ApartamentoModel oApClassifica = new ApartamentoModel();
                OcorrenciaModel oOcorrencia = new OcorrenciaModel();


                if (itemOcorrencia.Table.Columns.Contains("Classificado_id"))
                    oClassificado.idClassificado = Convert.ToInt32(itemOcorrencia["Classificado_id"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Grupo"))
                    oGrpClassificados.grupoClassificado = Convert.ToInt32(itemOcorrencia["Classificado_Grupo"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_AP"))
                    oApClassifica.apartamento = Convert.ToInt32(itemOcorrencia["Classificado_AP"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Bloco"))
                    oApClassifica.bloco = Convert.ToInt32(itemOcorrencia["Classificado_Bloco"]);

                oClassificado.grpClassificado = oGrpClassificados;
                oClassificado.apartamentoClassificado = oApClassifica;

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Descricao"))
                    oClassificado.descricaoClassificado = itemOcorrencia["Classificado_Descricao"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Status"))
                    oClassificado.statusClassificado = itemOcorrencia["Classificado_Status"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Validade"))
                    oClassificado.validadeClassificado = Convert.ToDateTime(itemOcorrencia["Classificado_Validade"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Img1"))
                    oClassificado.classificadoimg1 = itemOcorrencia["Classificado_Img1"].ToString();


                if (itemOcorrencia.Table.Columns.Contains("Classificado_Img2"))
                    oClassificado.classificadoimg2 = itemOcorrencia["Classificado_Img2"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Img3"))
                    oClassificado.classificadoimg3 = itemOcorrencia["Classificado_Img3"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Img4"))
                    oClassificado.classificadoimg4 = itemOcorrencia["Classificado_Img4"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_email_contato"))
                    oClassificado.emailClassificadoContato = itemOcorrencia["Classificado_email_contato"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Tel1"))
                    oClassificado.classificadoTelefone1 = itemOcorrencia["Classificado_Tel1"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Tel2"))
                    oClassificado.classificadoTelefone2 = itemOcorrencia["Classificado_Tel2"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Validade"))
                    oClassificado.classificadoDataVenda = Convert.ToDateTime(itemOcorrencia["Classificado_Validade"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Valor"))
                    oClassificado.valorVendaClassificado = Convert.ToDouble(itemOcorrencia["Classificado_Valor"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Data"))
                    oClassificado.dataClassificado = Convert.ToDateTime(itemOcorrencia["Classificado_Data"]);

                if (itemOcorrencia.Table.Columns.Contains("CONTA_GRUPO"))
                    oClassificado.contaGrupo = Convert.ToInt32(itemOcorrencia["CONTA_GRUPO"]);

                if (itemOcorrencia.Table.Columns.Contains("Classificado_Contato"))
                    oClassificado.contato = itemOcorrencia["Classificado_Contato"].ToString();

                if (itemOcorrencia.Table.Columns.Contains("Classificado_assunto"))
                    oClassificado.assuntoClassificado = itemOcorrencia["Classificado_assunto"].ToString();

                olistClassificado.Add(oClassificado);


            }

            return olistClassificado;
        }



        void Interfaces.IClassificado.cadastraClassificado(Classificados oClassificado)
        {
            throw new NotImplementedException();
        }

        listClassificados Interfaces.IClassificado.consultaClassificado(Classificados oClassificado)
        {
            throw new NotImplementedException();
        }






      
       
    }
}
