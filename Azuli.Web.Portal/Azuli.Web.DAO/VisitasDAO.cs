using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data.SqlClient;
using System.Data;

namespace Azuli.Web.DAO
{
    public class VisitasDAO: AcessoDAO
    {
        public void cadastraVisitas(Model.Visitas oVisitas)
        {
            string clausulaSQL = "SP_VISITAS";

            try
            {
             SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                
            //    comandoSql.Parameters.AddWithValue("@VisitaData",oVisitas.VisitaData);
            //    comandoSql.Parameters.AddWithValue("@VisitanteId",oVisitas.VisitanteId);
            //    comandoSql.Parameters.AddWithValue("@Bloco",oVisitas.Bloco);
            //    comandoSql.Parameters.AddWithValue("@Apartamento",oVisitas.Apartamento);
            //    comandoSql.Parameters.AddWithValue("@VisitaPlacaCarro",oVisitas.VisitaPlacaCarro);
            //    comandoSql.Parameters.AddWithValue("@VisitaModeloCarro",oVisitas.VistaModeloCarro);
            //    comandoSql.Parameters.AddWithValue("@VisitaCorCarro",oVisitas.VisitaCorCarro);
            //    comandoSql.Parameters.AddWithValue("@VisitaAutorizada",oVisitas.VisitaAutorizada);
            //    comandoSql.Parameters.AddWithValue("@VisitaAutorizadaPo",oVisitas.VisitaAutorizadaPor);
            //    comandoSql.Parameters.AddWithValue("@VisitaObs", oVisitas.VistaObs);

                ExecutaComando(comandoSql);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ListaVisitas consultaVisita(Visitas oVisitas)
        {


            string clausulaSQL = "SP_PROCURA_VISITAS_RG";


            try
            {
                //SqlCommand comandoSql = new SqlCommand(clausulaSQL);
                //comandoSql.Parameters.AddWithValue("@VisitaData", oVisitas.VisitaData);
                //comandoSql.Parameters.AddWithValue("@VisitanteId", oVisitas.VisitanteId);
                //comandoSql.Parameters.AddWithValue("@Bloco", oVisitas.Bloco);
                //comandoSql.Parameters.AddWithValue("@Apartamento", oVisitas.Apartamento);
                //comandoSql.Parameters.AddWithValue("@VisitaPlacaCarro", oVisitas.VisitaPlacaCarro);
                //comandoSql.Parameters.AddWithValue("@VisitaModeloCarro", oVisitas.VistaModeloCarro);
                //comandoSql.Parameters.AddWithValue("@VisitaCorCarro", oVisitas.VisitaCorCarro);
                //comandoSql.Parameters.AddWithValue("@VisitaAutorizada", oVisitas.VisitaAutorizada);
                //comandoSql.Parameters.AddWithValue("@VisitaAutorizadaPo", oVisitas.VisitaAutorizadaPor);
                //comandoSql.Parameters.AddWithValue("@VisitaObs", oVisitas.VistaObs);

                //comandoSql.Parameters.AddWithValue("@VisitanteNome", oVisitas.VisitanteNome);
                //comandoSql.Parameters.AddWithValue("@VisitanteRG", oVisitas.VisitanteRG);
                //comandoSql.Parameters.AddWithValue("@VisitanteTipo", oVisitas.VisitanteTipo);
                //comandoSql.Parameters.AddWithValue("@Foto", oVisitas.Foto);

                DataTable tbVisitas = new DataTable();
                //tbVisitas = ExecutaQuery(comandoSql);
                return populaVisitas(tbVisitas);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Cria uma lista de visitas 
        /// --Auto: Leandro Vilela
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        private ListaVisitas populaVisitas(DataTable dt)
        {
            ListaVisitas olistaVisitas = new ListaVisitas();

            foreach (DataRow itemVisitas in dt.Rows)
            {
                Visitas oVisitas = new Visitas();

                if (itemVisitas.Table.Columns.Contains("VisitaData"))
                    oVisitas.dataVisita = Convert.ToDateTime(itemVisitas["VisitaData"]);

                //if (itemVisitas.Table.Columns.Contains("VisitanteId"))
                //    oVisitas.idVisitante = Convert.ToInt32(itemVisitas["VisitanteId"]);

                //if (itemVisitas.Table.Columns.Contains("Bloco"))
                //    oVisitas.Bloc = Convert.ToInt32(itemVisitas["Bloco"]);

                //if (itemVisitas.Table.Columns.Contains("Apartamento"))
                //    oVisitas.Apartamento = Convert.ToInt32(itemVisitas["Apartamento"]);

                if (itemVisitas.Table.Columns.Contains("VisitaPlacaCarro"))
                    oVisitas.visitaPlacaCarro = Convert.ToString(itemVisitas["VisitaPlacaCarro"]);

                if (itemVisitas.Table.Columns.Contains("VistaModeloCarro"))
                    oVisitas.visitaModeloCarro = Convert.ToString(itemVisitas["VistaModeloCarro"]);

                //if (itemVisitas.Table.Columns.Contains("VisitaCorCarro"))
                //    oVisitas.co = Convert.ToString(itemVisitas["VisitaCorCarro"]);

                //if (itemVisitas.Table.Columns.Contains("VisitaAutorizada"))
                //    oVisitas.VisitaAutorizada = Convert.ToString(itemVisitas["VisitaAutorizada"]);

                //if (itemVisitas.Table.Columns.Contains("VisitaAutorizadaPor"))
                //    oVisitas.VisitaAutorizadaPor = Convert.ToString(itemVisitas["VisitaAutorizadaPor"]);

                //if (itemVisitas.Table.Columns.Contains("VistaObs"))
                //    oVisitas.VistaObs = Convert.ToString(itemVisitas["VistaObs"]);

                //if (itemVisitas.Table.Columns.Contains("VisitanteNome"))
                //    oVisitas.VisitanteNome = Convert.ToString(itemVisitas["VisitanteNome"]);

                //if (itemVisitas.Table.Columns.Contains("VisitanteRG"))
                //    oVisitas.VisitanteRG = Convert.ToString(itemVisitas["VisitanteRG"]);

                //if (itemVisitas.Table.Columns.Contains("VisitanteTipo"))
                //    oVisitas.VisitanteTipo = Convert.ToString(itemVisitas["VisitanteTipo"]);

                //if (itemVisitas.Table.Columns.Contains("FOTO"))
                //    oVisitas.Foto = Convert.ToByte(itemVisitas["FOTO"]);

                olistaVisitas.Add(oVisitas);

            }

            return olistaVisitas;
        }
    }
}
