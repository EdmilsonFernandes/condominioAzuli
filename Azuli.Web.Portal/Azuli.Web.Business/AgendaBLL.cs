using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using Azuli.Web.DAO;

namespace Azuli.Web.Business
{
    public class AgendaBLL : Interfaces.IAgenda
    {
        #region Variables Global
        Agenda oAgendaDao = new Agenda();
        #endregion


        #region IAgenda Members


        public listAgenda listaEventos()
        {

            listAgenda oListaAgenda = new listAgenda();
            Agenda oAgendaDao = new Agenda();
            try
            {
                oListaAgenda = oAgendaDao.listaEventos();

                return oListaAgenda;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public listAgenda pendentePagamento(AgendaModel oAgenda)
        {
            listAgenda oListaAgenda = new listAgenda();
            Agenda oAgendaDao = new Agenda();
            try
            {
                oListaAgenda = oAgendaDao.pendentePagamento(oAgenda);

                return oListaAgenda;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public listAgenda listaEventos_ByCalendar(DateTime date)
        {
            listAgenda oListaAgenda = new listAgenda();

            try
            {
                oListaAgenda = oAgendaDao.listaEventos_ByCalendar(date);

                return oListaAgenda;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public listAgenda listaEventosByData(DateTime date)
        {

            listAgenda oListaAgenda = new listAgenda();

            try
            {
                oListaAgenda = oAgendaDao.listaEventos_ByData(date);

                return oListaAgenda;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void cadastrarAgenda(DateTime data, ApartamentoModel oAp, AgendaModel oAgenda)
        {
            try
            {
                oAgendaDao.cadastrarAgenda(data, oAp, oAgenda);

            }
            catch (Exception error)
            {

                throw error;
            }
        }



        public listAgenda agendamentoFuturoFesta(AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.agendamentoFuturoFesta(oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }
        }
        public listAgenda agendamentoFuturoChurras(AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.agendamentoFuturoChurras(oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public listAgenda listaReservaDetalhadaChurrasco(int ano, int mes)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.listaReservaDetalhadaChurrasco(ano, mes);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }

        }


        public listAgenda listaReservaByMorador(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.listaReservaByMorador(oAp, oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }
        }

      

        public listAgenda listaReservaDetalhadaFesta(int ano, int mes)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.listaReservaDetalhadaFesta( ano, mes);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }

        }


        public listAgenda listaReservaByMoradorFesta(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.listaReservaByMoradorFesta(oAp, oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }



        }

        public Dictionary<int, DateTime> quantidadeDiasReservaFesta(ApartamentoModel oAp)
        {
            Dictionary<int, DateTime> dataReservaFesta = new Dictionary<int, DateTime>();

            try
            {
                dataReservaFesta = oAgendaDao.quantidadeDiasReservaFesta(oAp);

                return dataReservaFesta;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Dictionary<int, DateTime> quantidadeDiasReservaChurras(ApartamentoModel oAp)
        {
            Dictionary<int, DateTime> dataReservaChurras = new Dictionary<int, DateTime>();

            try
            {
                dataReservaChurras = oAgendaDao.quantidadeDiasReservaChurras(oAp);

                return dataReservaChurras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cancelaAgendamentoMoradorObservation(DateTime dataAgendamento, ApartamentoModel ap, bool festa, bool churras, string observation)
        {
            try
            {
                oAgendaDao.cancelaAgendamentoMoradorObservation(dataAgendamento, ap, festa, churras, observation);

            }
            catch (Exception error)
            {

                throw error;
            }
        }
      

        public void cancelaAgendamentoMorador(DateTime dataAgendamento, ApartamentoModel ap, bool festa, bool churras)
        {
            try
            {
                oAgendaDao.cancelaAgendamentoMorador(dataAgendamento, ap, festa, churras);

            }
            catch (Exception error)
            {

                throw error;
            }
        }

  


        public listAgenda validaAgendamento(DateTime data, ApartamentoModel oAp, AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.validaAgendamento(data, oAp, oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }

        }



        public listAgenda listaReservaByMoradorAdmin(AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.listaReservaByMoradorAdmin(oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }
        }


        public listAgenda geraReciboPago(AgendaModel oAgenda)
        {
            listAgenda oListAgenda = new listAgenda();

            try
            {
                oListAgenda = oAgendaDao.geraReciboPago(oAgenda);

                return oListAgenda;

            }
            catch (Exception error)
            {

                throw error;
            }
        }

        #endregion

         #region IAgenda Members

        listAgenda Interfaces.IAgenda.listaEventos()
        {
            throw new NotImplementedException();
        }

        listAgenda Interfaces.IAgenda.listaEventosByData(DateTime date)
        {
            throw new NotImplementedException();
        }

        void Interfaces.IAgenda.cadastrarAgenda(DateTime data, ApartamentoModel oAp, AgendaModel oAgenda)
        {
            throw new NotImplementedException();
        }

        listAgenda Interfaces.IAgenda.listaReservaByMorador(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            throw new NotImplementedException();
        }

        listAgenda Interfaces.IAgenda.listaReservaByMoradorFesta(ApartamentoModel oAp, AgendaModel oAgenda)
        {
            throw new NotImplementedException();
        }

      
        #endregion


















     

    }
}
