using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data.SqlClient;
using System.Data;

namespace Azuli.Web.DAO
{
    public class Agenda:AcessoDAO, Interfaces.IAgenda
    {



        #region IAgenda Members

      
        public listAgenda listaReservaByMorador(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            string clausulaSQL = "RESERVA_MORADOR_CHURRAS";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@AP", oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@ANO", oAgenda.dataAgendamento.Year);
                comandoSQL.Parameters.AddWithValue("@MES", oAgenda.dataAgendamento.Month);


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }


        public listAgenda agendamentoFuturoFesta(AgendaModel oAgenda)
        {
            string clausulaSQL = "SP_AGENDAMENTO_FUTUROFESTA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@BLOCO", oAgenda.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@APARTAMENTO", oAgenda.ap.apartamento);
       

                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda agendamentoFuturoChurras(AgendaModel oAgenda)
        {
            string clausulaSQL = "SP_AGENDAMENTO_FUTUROCHURRAS";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@BLOCO", oAgenda.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@APARTAMENTO", oAgenda.ap.apartamento);
              


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

     

        public Dictionary<int, DateTime> quantidadeDiasReservaFesta(ApartamentoModel oAp)
        {
            string clausulaSQL = "SP_DIAS_AGENDAMENTO_FESTA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@APARTAMENTO", oAp.apartamento);
                DataTable tbAgenda = new DataTable();
                tbAgenda = ExecutaQuery(comandoSQL);
                return carregaAgendaDiasReserva(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public Dictionary<int,DateTime> quantidadeDiasReservaChurras(ApartamentoModel oAp)
        {
            string clausulaSQL = "SP_DIAS_CHURRASCO";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

              
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@APARTAMENTO", oAp.apartamento);



                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgendaDiasReserva(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public void cancelaAgendamentoMoradorObservation(DateTime dataAgendamento, ApartamentoModel ap, bool festa, bool churras, string observation)
        {
            string clausulaSQL = "CANCELA_RESERVA_MORADOR";


            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", dataAgendamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@FESTA", festa);
                comandoSQL.Parameters.AddWithValue("@CHURRAS", churras);
                comandoSQL.Parameters.AddWithValue("@OBSERVACAO", observation);


                ExecutaQuery(comandoSQL);

            }
            catch (Exception error)
            {

                throw error;
            }


        }
        

        
        public void cancelaAgendamentoMorador(DateTime dataAgendamento, ApartamentoModel ap, bool festa, bool churras)
        {
            string clausulaSQL = "CANCELA_RESERVA_MORADOR";

           
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", dataAgendamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@FESTA", festa);
                comandoSQL.Parameters.AddWithValue("@CHURRAS", churras);
            
               
                ExecutaQuery(comandoSQL);

            }
            catch (Exception error)
            {

                throw error;
            }


        }

        public listAgenda listaReservaByMoradorFesta(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            string clausulaSQL = "RESERVA_MORADOR_FESTA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@AP", oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@ANO", oAgenda.dataAgendamento.Year);
                comandoSQL.Parameters.AddWithValue("@MES", oAgenda.dataAgendamento.Month);


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda listaReservaDetalhadaChurrasco(int ano, int mes)
        {
            string clausulaSQL = "RESERVA_MORADOR_CHURRAS_DETALHADA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@ANO", ano);
                comandoSQL.Parameters.AddWithValue("@MES", mes);


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda listaReservaDetalhadaFesta(int ano, int mes)
        {
            string clausulaSQL = "RESERVA_MORADOR_FESTA_DETALHADA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

             
                comandoSQL.Parameters.AddWithValue("@ANO", ano);
                comandoSQL.Parameters.AddWithValue("@MES", mes);


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda listaReservaByMoradorAdmin(AgendaModel oAgenda)
        {
            string clausulaSQL = "CONSULTA_RESERVA_MORADOR";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

               
                comandoSQL.Parameters.AddWithValue("@ANO", oAgenda.dataAgendamento.Year);
                comandoSQL.Parameters.AddWithValue("@MES", oAgenda.dataAgendamento.Month);
                comandoSQL.Parameters.AddWithValue("@AREA_CHURRAS", oAgenda.salaoChurrasco);
                comandoSQL.Parameters.AddWithValue("@AREA_FESTA", oAgenda.salaoFesta);

                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }





        
        public void cadastrarAgenda(DateTime data,ApartamentoModel oAp, AgendaModel oAgenda)
        {
            string clausulaSQL = "CADASTRA_RESERVA_MORADOR";
            
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", data);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@FESTA", oAgenda.salaoFesta);
                comandoSQL.Parameters.AddWithValue("@CHURRAS", oAgenda.salaoChurrasco);
                comandoSQL.Parameters.AddWithValue("@PAGO", oAgenda.statusPagamento);
                comandoSQL.Parameters.AddWithValue("@DATA_CONFIRMACAOPG", oAgenda.dataConfirmacaoPagamento);
                comandoSQL.Parameters.AddWithValue("@OBSERVACAO", oAgenda.observacao);

                ExecutaQuery(comandoSQL);

            }
            catch (Exception error)
            {
                
                throw error;
            }
        }



        public listAgenda listaEventos()
        {

            string clausulaSQL = "LISTA_EVENTOS";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);


                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception e)
            {

                throw e;
            }

        }



        public listAgenda listaEventos_ByData(DateTime date)
        {

            string clausulaSQL = "LISTA_EVENTOS_BY_DATA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", date);

                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception e)
            {

                throw e;
            }


        }


        public listAgenda listaEventos_ByCalendar(DateTime date)
        {
            string clausulaSQL = "LISTA_EVENTOS_CALENDAR";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", date);

                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        

        private listAgenda carregaAgenda(DataTable dt)
        {

            listAgenda oListaEventos = new listAgenda();

            foreach (DataRow dr in dt.Rows)
            {

                AgendaModel oAgendaModel = new AgendaModel();
                

                if (dr.Table.Columns.Contains("DATA_AGENDAMENTO")) 
                oAgendaModel.dataAgendamento = Convert.ToDateTime(dr["DATA_AGENDAMENTO"]);


                if (dr.Table.Columns.Contains("DATA_CONFIRMACAOPG"))
                    oAgendaModel.dataConfirmacaoPagamento = Convert.ToDateTime(dr["DATA_CONFIRMACAOPG"]);

                if (dr.Table.Columns.Contains("DATA_INCLUSAO"))
                    oAgendaModel.dataInclusao = Convert.ToDateTime(dr["DATA_INCLUSAO"]);


                

                if (dr.Table.Columns.Contains("SALAO_CHURRASCO")) 
                oAgendaModel.salaoChurrasco = Convert.ToBoolean(dr["SALAO_CHURRASCO"]);

                if (dr.Table.Columns.Contains("SALAO_FESTA")) 
                    oAgendaModel.salaoFesta = Convert.ToBoolean(dr["SALAO_FESTA"]);
                
                oAgendaModel.ap = new ApartamentoModel();

                if (dr.Table.Columns.Contains("PROPRIETARIO_AP")) 
                 oAgendaModel.ap.apartamento =  Convert.ToInt32(dr["PROPRIETARIO_AP"]);

                if (dr.Table.Columns.Contains("PROPRIETARIO_BLOCO")) 
                oAgendaModel.ap.bloco = Convert.ToInt32(dr["PROPRIETARIO_BLOCO"]);

                if (dr.Table.Columns.Contains("ap"))
                    oAgendaModel.ap.apartamento = Convert.ToInt32(dr["ap"]);

                if (dr.Table.Columns.Contains("bloco"))
                    oAgendaModel.ap.bloco = Convert.ToInt32(dr["bloco"]);



                if (dr.Table.Columns.Contains("COUNT_FESTA"))
                   oAgendaModel.contadorFesta = Convert.ToInt32(dr["COUNT_FESTA"]);

                if (dr.Table.Columns.Contains("COUNT_CHURRAS"))
                    oAgendaModel.contadorChurrasco = Convert.ToInt32(dr["COUNT_CHURRAS"]);

                if (dr.Table.Columns.Contains("PAGO"))
                    oAgendaModel.statusPagamento = dr["PAGO"].ToString();

                if (dr.Table.Columns.Contains("OBSERVACAO"))
                    oAgendaModel.observacao = dr["OBSERVACAO"].ToString();

                if (dr.Table.Columns.Contains("DiasAgendaChurras"))
                    oAgendaModel.contadorChurrasco = Convert.ToInt32(dr["DiasAgendaChurras"]);
                
                if (oAgendaModel.contadorChurrasco < 0)
                {
                    oAgendaModel.contadorChurrasFuturo = Math.Abs(Convert.ToInt32(dr["DiasAgendaChurras"]));
                }


                if (dr.Table.Columns.Contains("DataChurraPara"))
                    oAgendaModel.dataAgendamento = Convert.ToDateTime(dr["DataChurraPara"]);

                if (dr.Table.Columns.Contains("DiasAgendaFesta"))
                    oAgendaModel.contadorFesta = Convert.ToInt32(dr["DiasAgendaFesta"]);

                if (oAgendaModel.contadorFesta < 0)
                {
                    oAgendaModel.contadorFestaFuturo = Math.Abs(Convert.ToInt32(dr["DiasAgendaFesta"]));
                }

                if (dr.Table.Columns.Contains("dataFuturaFesta"))
                    oAgendaModel.dataAgendamento = Convert.ToDateTime(dr["dataFuturaFesta"]);

                if (dr.Table.Columns.Contains("diasPagouChurras"))
                    oAgendaModel.qtdDiasPagamentoChurras = Convert.ToInt32(dr["diasPagouChurras"]);

                if (dr.Table.Columns.Contains("diasPagouFesta"))
                    oAgendaModel.qtdDiasPagamentoChurras = Convert.ToInt32(dr["diasPagouFesta"]);

                if (dr.Table.Columns.Contains("valor"))
                    oAgendaModel.valorReserva = Convert.ToDouble(dr["valor"]);

                if (dr.Table.Columns.Contains("ValorDesconto") && !Convert.IsDBNull(dr["ValorDesconto"]))
                    oAgendaModel.ValorDesconto = Convert.ToDouble(dr["ValorDesconto"]);

                oAgendaModel.ap.oProprietario = new ProprietarioModel();

                if (dr.Table.Columns.Contains("TELEFONE") && !Convert.IsDBNull(dr["TELEFONE"]))
                    oAgendaModel.ap.oProprietario.telefone = dr["TELEFONE"].ToString();


                if (dr.Table.Columns.Contains("NOME_PROPRIETARIO1") && !Convert.IsDBNull(dr["NOME_PROPRIETARIO1"]))
                    oAgendaModel.ap.oProprietario.proprietario1 = dr["NOME_PROPRIETARIO1"].ToString();

               
               

               



                oListaEventos.Add(oAgendaModel);
                               
            }

            return oListaEventos;

        }

        private Dictionary<int, DateTime> carregaAgendaDiasReserva(DataTable dt)
        {
            Dictionary<int, DateTime> DiasDataReserva = new Dictionary<int, DateTime>();

            foreach (DataRow dr in dt.Rows)
            {
                
                AgendaModel oAgendaModel = new AgendaModel();

                if (dr.Table.Columns.Contains("QtdDiasUltimaReservaChurras") && dr.Table.Columns.Contains("QtdDiasUltimaReservaChurras"))
                    DiasDataReserva.Add(Convert.ToInt32(dr["QtdDiasUltimaReservaChurras"]),Convert.ToDateTime(dr["ultimaDataChurras"]));

                if (dr.Table.Columns.Contains("QtdDiasUltimaReserva") && dr.Table.Columns.Contains("ultimaDataFesta"))
                    DiasDataReserva.Add(Convert.ToInt32(dr["QtdDiasUltimaReserva"]), Convert.ToDateTime(dr["ultimaDataFesta"]));
        
            }

            return DiasDataReserva;

        }


        public listAgenda pendentePagamento(AgendaModel oAgenda)
        {
            string clausulaSQL = "SP_PENDENTE_PAGAMENTO_RESERVA ";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);


                comandoSQL.Parameters.AddWithValue("@BLOCO", oAgenda.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oAgenda.ap.apartamento);
                comandoSQL.Parameters.AddWithValue("@DATA", oAgenda.dataAgendamento);
                

                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda geraReciboPago(AgendaModel oAgenda)
        {
            string clausulaSQL = "USP_GERA_RECIBO_RESERVA";

            listAgenda oListaAgendaRecibo = new listAgenda();

            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["azulli"].ToString());
            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.Connection = conn;
                SqlDataReader myReader;
                comandoSQL.Parameters.AddWithValue("@DATAAGE", oAgenda.dataAgendamento);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAgenda.ap.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oAgenda.ap.apartamento);
              

                conn.Open();

                myReader = comandoSQL.ExecuteReader();


                do
                {


                    while (myReader.Read())
                    {

                        //if(myReader.GetSchemaTable().Columns.Contains("CONTADOR_MENSAGEM_PENDENTE"))
                        try
                        {
                            oAgenda.dataAgendamento = Convert.ToDateTime(myReader["dataRec"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }

                        try
                        {
                            oAgenda.ap.apartamento = Convert.ToInt32(myReader["apRec"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            e.ToString();

                        }

                        try
                        {
                            oAgenda.ap.bloco = Convert.ToInt32(myReader["blocoRec"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            e.ToString();

                        }

                        try
                        {
                            ProprietarioModel oPropri = new ProprietarioModel();
                            oPropri.proprietario1 =  myReader["NomeRec"].ToString();
                            oAgenda.ap.oProprietario  = oPropri;

                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }

                        try
                        {
                            oAgenda.observacao = myReader["descricaoRec"].ToString();
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }

                        try
                        {
                            oAgenda.valorReserva =Convert.ToDouble(myReader["valorRec"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }

                        try
                        {
                            oAgenda.salaoFesta = Convert.ToBoolean(myReader["FESTA"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }

                        try
                        {
                            oAgenda.salaoChurrasco = Convert.ToBoolean(myReader["CHURRAS"]);
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            e.ToString();
                        }



                        oListaAgendaRecibo.Add(oAgenda);

                    }

                } while (myReader.NextResult());



                //DataSet tbPendencia = new DataSet();
                //tbPendencia = ExecutaProcQuery(comandoSQL);

                //DataTable pendenciaDT = tbPendencia.Tables[0];
                //DataTable pendenciaDT01 = tbPendencia.Tables[1];

                return oListaAgendaRecibo;


            }
            catch (Exception)
            {

                throw;
            }
        }






        public listAgenda validaAgendamento(DateTime data, ApartamentoModel oAp, AgendaModel oAgenda)
        {

            string clausulaSQL = "VALIDA_CADASTRO_AGENDA";

            try
            {
                SqlCommand comandoSQL = new SqlCommand(clausulaSQL);

                comandoSQL.Parameters.AddWithValue("@DATA_AGENDA", data);
                comandoSQL.Parameters.AddWithValue("@BLOCO", oAp.bloco);
                comandoSQL.Parameters.AddWithValue("@AP", oAp.apartamento);
                comandoSQL.Parameters.AddWithValue("@FESTA", oAgenda.salaoFesta);
                comandoSQL.Parameters.AddWithValue("@CHURRAS", oAgenda.salaoChurrasco);
                
                DataTable tbAgenda = new DataTable();

                tbAgenda = ExecutaQuery(comandoSQL);

                return carregaAgenda(tbAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
           
        }

      
       
        #endregion
    }
}
