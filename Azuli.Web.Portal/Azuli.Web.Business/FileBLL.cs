using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;

namespace Azuli.Web.Business
{
    public class FileBLL:Interfaces.IFile
    {
        #region IFile Members

        public void publicarArquivo(Model.File oFile)
        {
            FileDAO oFileDAO = new FileDAO();
            try
            {
                
                oFileDAO.publicarArquivo(oFile);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Model.ListFile consultaArquivo(Model.File oFile)
        {
            throw new NotImplementedException();
        }

       

        public int validaCircular(Model.File oFile)
        {
            int quantidade = 0;
            FileDAO oFileDAO = new FileDAO();
            
            try
            {

                quantidade = oFileDAO.validaCircular(oFile);

            }

            catch (Exception)
            {
                
                throw;
            }

            return quantidade;
        }



        public Dictionary<int, int> contaArquivoByMeses(Model.File oFile)
        {
            Dictionary<int, int> mesQtd;
            FileDAO oFileDAO = new FileDAO();

            try
            {

                mesQtd = oFileDAO.contaArquivoByMeses(oFile);

            }

            catch (Exception)
            {

                throw;
            }

            return mesQtd;
        }

       

        public Model.ListFile listaArquivoCircular(Model.File oFile)
        {
            ListFile oListFile = new ListFile();
            FileDAO oFileDAO = new FileDAO();
            try
            {
                return oListFile = oFileDAO.listaArquivoCircular(oFile);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
