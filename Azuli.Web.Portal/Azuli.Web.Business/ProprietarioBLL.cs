using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;

namespace Azuli.Web.Business
{
    public class ProprietarioBLL:Interfaces.IProprietario
    {

        #region IProprietario Members
        ProprietarioDAO oPropriDAO = new ProprietarioDAO();
        public int autenticaMorador(Model.ApartamentoModel ap, Model.ProprietarioModel apPro)
        {
            try
            {
               

                return oPropriDAO.autenticaMorador(ap, apPro);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Model.listProprietario populaProprietario(Model.ApartamentoModel ap, Model.ProprietarioModel apPro)
        {
            try
            {
         
                
                return oPropriDAO.populaProprietario(ap, apPro);

            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

       
        public Model.listProprietario BuscaMoradorAdmin(Model.ApartamentoModel ap)
        {
            try
            {

                return oPropriDAO.BuscaMoradorAdmin(ap);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

       


        public Model.listApartamento listaAP(System.Data.DataTable dt)
        {
            throw new NotImplementedException();
        }

        public void alteraSenha(ProprietarioModel oProprietario)
        {
            try
            {
                oPropriDAO.alteraSenha(oProprietario);
            }
            catch (Exception)
            {
                
                throw;
            }
          
            
        }

        public void liberaAcesso(ApartamentoModel ap)
        {
            try
            {


                oPropriDAO.liberaAcesso(ap);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        
        public int CadastrarApartamentoMorador(ProprietarioModel ap)
        {
            try
            {
              

                return oPropriDAO.CadastrarApartamentoMorador(ap);

            }
            catch (Exception e)
            {

                throw e;
            }

        }







        public void cadastraOcorrencia(LancamentoOcorrenciaModel olacamento)
        {
            try
            {
               

                oPropriDAO.cadastraOcorrencia(olacamento);

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public listProprietario enviaCrendencialAcesso(ApartamentoModel oPropri)
        {
            try
            {

                return oPropriDAO.enviaCrendencialAcesso(oPropri);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ap"></param>
        /// <returns></returns>
        public listProprietario recuperaSenhaMorador(ProprietarioModel ap)
        {
            try
            {

                return oPropriDAO.recuperaSenhaMorador(ap);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public listProprietario listaProprietarioSendEmail()
        {
            try
            {

                return oPropriDAO.listaProprietarioSendEmail();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
      

        

      

        #endregion

       
      
    }
}
