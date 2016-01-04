using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Azuli.Web.Model
{
    public class LancamentoOcorrenciaModel
    {

        public string ocorrenciaLancamento {get;set;}
        public DateTime dataOcorrencia { get; set; }
        public string statusOcorrencia { get; set; }
        public string descricaoOcorrencia { get; set; }
        public ApartamentoModel oAp { get; set; }
        public DateTime dataFinalizacao { get; set; }
        public DateTime dataCancelamento { get; set; }
        public string imagemEvidencia { get;set; }
        public OcorrenciaModel oOcorrencia { get; set; }
        public int codigoOcorrencia { get; set; }
    }

    public class listaLancamentoOcorrencia : List<LancamentoOcorrenciaModel> { }

    
}
