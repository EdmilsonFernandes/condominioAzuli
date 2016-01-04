using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.Data;

namespace Azuli.Web.DAO.Interfaces
{
    public interface IProprietario
    {
        int autenticaMorador(ApartamentoModel ap, ProprietarioModel apPro);
        listApartamento listaAp(DataTable dt);
        listProprietario populaProprietario(ApartamentoModel ap, ProprietarioModel apPro);
        listProprietario BuscaMoradorAdmin(ApartamentoModel ap);
        int CadastrarApartamentoMorador(Model.ProprietarioModel ap);
        void alteraSenha(ProprietarioModel oProprietario);
        void cadastraOcorrencia(LancamentoOcorrenciaModel olacamento);
        listProprietario recuperaSenhaMorador(ProprietarioModel ap);
        void liberaAcesso(ApartamentoModel ap);
        listProprietario enviaCrendencialAcesso(ApartamentoModel oPropri);
        listProprietario listaProprietarioSendEmail();
    }
}
