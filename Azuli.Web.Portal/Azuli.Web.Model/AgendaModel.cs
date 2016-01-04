using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class AgendaModel
    {
        public DateTime dataAgendamento { get; set;}
        public ApartamentoModel ap { get; set;}
        public bool salaoFesta { get; set; }
        public bool salaoChurrasco { get; set;}
        public int contadorChurrasco { get; set; }
        public int contadorFesta { get; set; }
        public int contadorChurrasFuturo{ get; set; }
        public int contadorFestaFuturo { get; set; }
        public int qtdDiasPagamentoChurras { get; set; }
        public int qtdDiasPagamentoFesta { get; set; }
        public string statusPagamento { get; set; }
        public DateTime dataConfirmacaoPagamento { get; set;}
        public DateTime dataInclusao { get; set; }
        public string observacao { get; set; }
        public double valorReserva { get; set; }
        public double ValorDesconto { get; set; }
      
    }

    public class listAgenda : List<AgendaModel> { };
}
