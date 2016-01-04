using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IMensagemMorador
    {
         listaMensagemMorador listaMensagemMorador(MensagemMoradorModel oAp);
         void enviaMensagemMorador(Model.MensagemMoradorModel oMensagem);
         listaMensagemMorador listaMensagemMoradorByID(Model.MensagemMoradorModel oAp);
         void atualizaMSG(Model.MensagemMoradorModel oAp);
         void cadastraContato(string assunto, string descricao, int bloco, int ap);
    }
}
