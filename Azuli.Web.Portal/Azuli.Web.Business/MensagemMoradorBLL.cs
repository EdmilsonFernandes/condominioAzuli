using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;
namespace Azuli.Web.Business
{
    public class MensagemMoradorBLL:Interfaces.IMensagemMorador
    {

        MensagemMoradorDAO oMensagemDAO = new MensagemMoradorDAO(); 

        #region IMensagemMorador Members

        public Model.listaMensagemMorador listaMensagemMorador(MensagemMoradorModel oAp)
        {
            try
            {
               return oMensagemDAO.listaMensagemMorador(oAp);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Model.listaMensagemMorador pesquisaMensagemMorador(MensagemMoradorModel oAP)
        {
            try
            {
                return oMensagemDAO.pesquisaMensagemMorador(oAP);
            }
            catch (Exception e)
            {                
                throw e;
            }
        }

        public void cadastraContato(string assunto, string descricao, int bloco, int ap)
        {
            try
            {
                oMensagemDAO.cadastraContato(assunto, descricao, bloco, ap);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public void enviaMensagemMorador(MensagemMoradorModel oMensagem)
        {
            try
            {
                oMensagemDAO.enviaMensagemMorador(oMensagem);
            }
            catch (Exception e)
            {

                throw e;
            }
        
        }

        public listaMensagemMorador listaMensagemMoradorByID(MensagemMoradorModel oAp)
        {
            try
            {
                return oMensagemDAO.listaMensagemMoradorByID(oAp);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       

        public void atualizaMSG(MensagemMoradorModel oAp)
        {
            try
            {
                oMensagemDAO.atualizaMSG(oAp);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

     

      

        #endregion
    }
}
