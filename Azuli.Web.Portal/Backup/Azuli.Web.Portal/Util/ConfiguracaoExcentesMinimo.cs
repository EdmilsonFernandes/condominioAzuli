using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azuli.Web.Model;

namespace Azuli.Web.Portal.Util
{
    public class ConfiguracaoExcentesMinimo
    {
        public ReciboAgua oReciboExcenteConfig { get; set; }
    }

    public class listaConfigExcedente : List<ConfiguracaoExcentesMinimo> { } 
}