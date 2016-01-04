using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;

namespace Azuli.Web.Business.Interfaces
{
    public interface IFile
    {

        void publicarArquivo(File oFile);
        ListFile consultaArquivo(File oFile);
        int validaCircular(File oFile);
        Dictionary<int, int> contaArquivoByMeses(File oFile);
        ListFile listaArquivoCircular(File oFile);
    }
}
