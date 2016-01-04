using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class CancelamentoReservaMorador
    {
        public ApartamentoModel ap;
        public DateTime dataCancelamento { get; set;}
        public AgendaModel areaCondominio;

    }

    public class listaCancelamentosMorador:List<CancelamentoReservaMorador>
    {
    }
}
