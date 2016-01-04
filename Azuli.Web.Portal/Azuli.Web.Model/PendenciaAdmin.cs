using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class PendenciaAdmin
    {

        public int qtdOcorrenciaPendente { get; set; }
        public int qtdMensagemPendente { get; set; }
        public int qtdMoradorPendente { get; set;}
        public int qtdAgendaNoPrazo { get; set; }
        public int qtdAgendaForaPrazo { get; set; }
    }

    public class ListaPendenciaAdmin : List<PendenciaAdmin> { }
}
