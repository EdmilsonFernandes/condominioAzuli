using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.DAO;
using Azuli.Web.Model;
using System.IO;


namespace Azuli.Web.Business
{
    public class ReciboAguaBLL:Interfaces.IReciboAgua
    {

        #region IReciboAgua Members

        public listaSegundaViaAgua buscaTodosRecibos(ReciboAgua oReciboAguaModel)
        {
            throw new NotImplementedException();
        }



        public int retornaConsumoHistorico(int mes, int ano, int bloco, int apto)
        {
            int consumoHistory = 0;
            ReciboAguaDAO oRec = new ReciboAguaDAO();
            try
            {
                consumoHistory = oRec.retornaConsumoHistorico(mes, ano, bloco, apto);
                return consumoHistory;

            }
            catch (Exception)
            {
                return consumoHistory = 0;
                throw;
            }
            
        }

        public listaSegundaViaAgua buscaRecibosCalculadosByMesAno(int ano, int mes)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.buscaRecibosCalculadosByMesAno(ano, mes);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaSegundaViaAgua buscaTodosRecibosByYearAndMonth(int ano, int mes)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.buscaTodosRecibosByYearAndMonth(ano, mes);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaSegundaViaAgua buscaTodosRecibosByBlocoAndApto(ReciboAgua oReciboModel)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO  oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.buscaTodosRecibosByBlocoAndApto(oReciboModel);

                return oListReciboAgua;

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public listaSegundaViaAgua validaImportacao(ReciboAgua oReciboModel)
        {
              listaSegundaViaAgua oListReciboAgua;
              ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
               oListReciboAgua = oReciboDao.validaImportacao(oReciboModel);

               return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void persisteCalculoFinalBanco(ReciboAgua oReciboModel)
        {
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oReciboDao.persisteCalculoFinalBanco(oReciboModel);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public void importIntegracaoWeb(ReciboAgua oReciboModel)
        {
          
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oReciboDao.importIntegracaoWeb(oReciboModel);

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        //public listaSegundaViaAgua LoadFile(string file)
        //{
        //    if (string.IsNullOrEmpty(file))
        //        throw new ArgumentException("file");


        //    if (!System.IO.File.Exists(file))
        //        throw new Exception("File " + file + " not found.");


        //    StreamReader reader = new StreamReader(file, Encoding.Unicode, false);

        //    return LoadFile(reader.BaseStream);
        //}

        ////public listaSegundaViaAgua LoadFile(System.IO.Stream file)
        //{

        //    int lineNumber = 1;

        //    StreamReader reader = new StreamReader(file, Encoding.Default, false);


        //    try
        //    {
        //        #region First Line

        //        string line = reader.ReadLine();


        //        if (string.IsNullOrEmpty(line))
        //            throw new Exception("YearBase at the top of the file " + file + " not found");

        //        string[] lineSplit = line.Split(new char[] { ';' });

               

        //        #endregion

        //        #region Header Line

        //        lineNumber++;
        //        line = reader.ReadLine();

        //        //Getting the name of each header
        //        string[] headers = line.Split(new char[] { ';' });

        //        #endregion

        //        #region Rows

        //        //Checking all lines of the file
        //        while (reader.Peek() > 0)
        //        {
        //            lineNumber++;
        //            line = reader.ReadLine();

        //            //Converting the line to object
        //          //  Model.IteropProject newObject = ConvertRowToObject(yearBase, lineNumber, line);

        //            //If found a valid object
        //            if (newObject != null)
        //             //   list.Add(newObject);

        //        }//end while


        //        #endregion

        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }

        //    return list;
        //}

       

        #region IReciboAgua Members


        public listaSegundaViaAgua LoadFile(string file)
        {
            throw new NotImplementedException();
        }

        public listaSegundaViaAgua LoadFile(Stream file)
        {
            throw new NotImplementedException();
        }

        #endregion

        public listaSegundaViaAgua graficosConsumoAgua(int yearBase)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.graficosConsumoAgua(yearBase);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public listaSegundaViaAgua graficosConsumoAguaIndividual(int yearBase, int bloco, int apto)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.graficosConsumoAguaIndividual(yearBase, bloco, apto);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public listaSegundaViaAgua graficoQuantidadeApAnormal(int yearBase)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.graficoQuantidadeApAnormal(yearBase);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public listaSegundaViaAgua graficoConsumoPorBloco(int yearBase)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.graficoConsumoPorBloco(yearBase);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }





        public int validaPersistenciaAgua(int mes, int ano)
        {
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();
            int resultado = 0;
            try
            {
                resultado = oReciboDao.validaPersistenciaAgua(mes, ano);

                return resultado;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public listaSegundaViaAgua graficoExcedentePorApartamento(int yearBase)
        {
            listaSegundaViaAgua oListReciboAgua;
            ReciboAguaDAO oReciboDao = new ReciboAguaDAO();

            try
            {
                oListReciboAgua = oReciboDao.graficoExcedentePorApartamento(yearBase);

                return oListReciboAgua;

            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion



    }
}
