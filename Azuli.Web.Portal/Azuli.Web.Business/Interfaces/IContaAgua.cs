using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Business.Interfaces
{
    public interface IContaAgua
    {
        List<int> validaContaMesAnoMorador(ContaAgua oContaModel);
    }
}
