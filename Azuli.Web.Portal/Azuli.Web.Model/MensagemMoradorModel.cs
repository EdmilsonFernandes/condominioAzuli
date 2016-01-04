using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class MensagemMoradorModel
    {
        public int codigoMsg {get;set;}
        public string deMsg { get; set; }
        public string assunto { get; set; }
        public ApartamentoModel oAp;
        public string mensagem { get; set; }
        public string status { get; set;}
        public string ativo { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public int qtdMsg { get; set; }
        public string todosMoradores { get; set; }

    }

    public class listaMensagemMorador : List<MensagemMoradorModel>
    {

    }
}
