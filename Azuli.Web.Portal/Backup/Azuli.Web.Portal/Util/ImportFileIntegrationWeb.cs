using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Azuli.Web.Model;
using System.IO;
using System.Text;


namespace Azuli.Web.Portal.Util
{
    public class ImportFileIntegrationWeb
    {

        System.Globalization.NumberFormatInfo info = new System.Globalization.NumberFormatInfo(); 
     

        #region Enumerations
        private enum Header : int
        {
            idCondominio = 0,
            nomeCondominio = 1,
            enderecoCondominio = 2,
            bloco = 3,
            apartamento = 4,
            registro = 5,
            fechamentoAtual = 6,
            dataLeituraAnterior = 7,
            leituraAnteriorM3 = 8,
            dataLeituraAtual = 9,
            leituraAtualM3 = 10,
            consumoMesM3 = 11,
            dataProximaLeitura = 12,
            status = 13,
            media = 14,
            historicoDescricaoMes1 = 15,
            historicoMes1 = 16,
            historicoDescricaoMes2 = 17,
            historicoMes2 = 18,
            historicoDescricaoMes3 = 19,
            historicoMes3 = 20,
            historicoDescricaoMes4 = 21,
            historicoMes4 = 22,
            historicoDescricaoMes5 = 23,
            historicoMes5 = 24,
            historicoDescricaoMes6 = 25,
            historicoMes6 = 26,
            imagem = 27,
            consumoM3pagoCondominio = 28,
            ConsumoValorPagoCondominio = 29,
            minimoM3PagoCondominio = 30,
            minimoValorPagoCondominio = 31,
            excedenteM3PagoCondominio = 32,
            excedenteValorPagoCondominio = 33,
            excedenteM3Rateio = 34,
            excedenteValorRateio = 35,
            tarifaMinimaM3ValorDevido = 36,
            tarifaMinimaValorValorDevido = 37,
            excedenteValorDevido = 38,
            valorPagarValorDevido = 39,
            avisoGeralAviso = 40,
            AnormalAviso = 41,
            individualAviso = 42,
            anormalidadeAviso = 43,
            mes = 44,
            ano = 45,
            excedenteM3diaria = 46

        }
        #endregion

        #region ConvertRowToObject
        /// <summary>
        /// Method which converts the row to object
        /// </summary>
        /// <param name="yearBase">Year base</param>
        /// <param name="lineNumber">line number of the file</param>
        /// <param name="line">string which contains line information read</param>
        /// <returns>object created in the iterop format</returns>
        private ReciboAgua ConvertRowToObject(int lineNumber, string line)
        {
            ReciboAgua model = new ReciboAgua();

            info.NumberDecimalSeparator = ",";
            info.NumberGroupSeparator = ".";
            
            if (string.IsNullOrEmpty(line))
                return null;

            string[] split = line.Split(new char[] { ';' });


            if (split.Length <= (int)Header.idCondominio)
                throw new Exception("Not found idCondominio in column: " + ((int)Header.idCondominio).ToString());
            model.idCondominio = split[(int)Header.idCondominio].Trim().ToString();

            if (split.Length <= (int)Header.nomeCondominio)
                throw new Exception("Not found nomeCondominio in column: " + ((int)Header.nomeCondominio).ToString());
            model.nomeCondominio = split[(int)Header.nomeCondominio].Trim().ToString();

            if (split.Length <= (int)Header.enderecoCondominio)
                throw new Exception("Not found enderecoCondominio in column: " + ((int)Header.enderecoCondominio).ToString());
            model.enderecoCondominio = split[(int)Header.enderecoCondominio].Trim().ToString();


            if (split.Length <= (int)Header.bloco)
                throw new Exception("Not found bloco in column: " + ((int)Header.bloco).ToString());
            model.bloco = split[(int)Header.bloco].Trim().ToString();

            if (split.Length <= (int)Header.apartamento)
                throw new Exception("Not found apartamento in column: " + ((int)Header.apartamento).ToString());
            model.apartamento = split[(int)Header.apartamento].Trim().ToString();

            if (split.Length <= (int)Header.registro)
                throw new Exception("Not found registro in column: " + ((int)Header.registro).ToString());
            model.registro = split[(int)Header.registro].Trim().ToString();


            if (split.Length <= (int)Header.fechamentoAtual)
                throw new Exception("Not found fechamentoAtual in column: " + ((int)Header.fechamentoAtual).ToString());
            model.fechamentoAtual = split[(int)Header.fechamentoAtual].Trim().ToString();


            if (split.Length <= (int)Header.dataLeituraAnterior)
                throw new Exception("Not found dataLeituraAnteriorr in column: " + ((int)Header.dataLeituraAnterior).ToString());
            model.dataLeituraAnterior = split[(int)Header.dataLeituraAnterior].Trim().ToString();

            if (split.Length <= (int)Header.leituraAnteriorM3)
                throw new Exception("Not found leituraAnteriorM3 in column: " + ((int)Header.leituraAnteriorM3).ToString());
            model.leituraAnteriorM3 = split[(int)Header.leituraAnteriorM3].Trim().ToString();

            if (split.Length <= (int)Header.dataLeituraAtual)
                throw new Exception("Not found dataLeituraAtual in column: " + ((int)Header.dataLeituraAtual).ToString());
            model.dataLeituraAtual = split[(int)Header.dataLeituraAtual].Trim().ToString();

            if (split.Length <= (int)Header.leituraAtualM3)
                throw new Exception("Not found leituraAtualM3 in column: " + ((int)Header.leituraAtualM3).ToString());
            model.leituraAtualM3 = split[(int)Header.leituraAtualM3].Trim().ToString();

            if (split.Length <= (int)Header.consumoMesM3)
                throw new Exception("Not found consumoMesM3 in column: " + ((int)Header.consumoMesM3).ToString());
            model.consumoMesM3 = split[(int)Header.consumoMesM3].Trim().ToString();


            if (split.Length <= (int)Header.dataProximaLeitura)
                throw new Exception("Not found dataProximaLeitura in column: " + ((int)Header.dataProximaLeitura).ToString());
            model.dataProximaLeitura = split[(int)Header.dataProximaLeitura].Trim().ToString();

            if (split.Length <= (int)Header.status)
                throw new Exception("Not found status in column: " + ((int)Header.status).ToString());
            model.status = split[(int)Header.status].Trim();

            if (split.Length <= (int)Header.media)
                throw new Exception("Not found media in column: " + ((int)Header.media).ToString());
            model.media = split[(int)Header.media].Trim().ToString();


            if (split.Length <= (int)Header.historicoDescricaoMes1)
                throw new Exception("Not found historicoDescricaoMes1 in column: " + ((int)Header.historicoDescricaoMes1).ToString());
            model.historicoDescricaoMes1 = split[(int)Header.historicoDescricaoMes1].Trim().ToString();

            if (split.Length <= (int)Header.historicoMes1)
                throw new Exception("Not found historicoMes1 in column: " + ((int)Header.historicoMes1).ToString());
            model.historicoMes1 = split[(int)Header.historicoMes1].Trim().ToString();


            if (split.Length <= (int)Header.historicoDescricaoMes2)
                throw new Exception("Not found historicoDescricaoMes2 in column: " + ((int)Header.historicoDescricaoMes2).ToString());
            model.historicoDescricaoMes2 = split[(int)Header.historicoDescricaoMes2].Trim();

            if (split.Length <= (int)Header.historicoMes2)
                throw new Exception("Not found historicoMes2 in column: " + ((int)Header.historicoMes2).ToString());
            model.historicoMes2 = split[(int)Header.historicoMes2].Trim().ToString();

            if (split.Length <= (int)Header.historicoDescricaoMes3)
                throw new Exception("Not found historicoDescricaoMes3 in column: " + ((int)Header.historicoDescricaoMes3).ToString());
            model.historicoDescricaoMes3 = split[(int)Header.historicoDescricaoMes3].Trim().ToString();

            if (split.Length <= (int)Header.historicoMes3)
                throw new Exception("Not found historicoMes3 in column: " + ((int)Header.historicoMes3).ToString());
            model.historicoMes3 = split[(int)Header.historicoMes3].Trim().ToString();



            if (split.Length <= (int)Header.historicoDescricaoMes4)
                throw new Exception("Not found historicoDescricaoMes4 in column: " + ((int)Header.historicoDescricaoMes4).ToString());
            model.historicoDescricaoMes4 = split[(int)Header.historicoDescricaoMes4].Trim().ToString();

            if (split.Length <= (int)Header.historicoMes4)
                throw new Exception("Not found historicoMes1 in column: " + ((int)Header.historicoMes4).ToString());
            model.historicoMes4 = split[(int)Header.historicoMes4].Trim().ToString();

            if (split.Length <= (int)Header.historicoDescricaoMes5)
                throw new Exception("Not found historicoDescricaoMes5 in column: " + ((int)Header.historicoDescricaoMes5).ToString());
            model.historicoDescricaoMes5 = split[(int)Header.historicoDescricaoMes5].Trim().ToString();


            if (split.Length <= (int)Header.historicoMes5)
                throw new Exception("Not found historicoMes5 in column: " + ((int)Header.historicoMes5).ToString());
            model.historicoMes5 = split[(int)Header.historicoMes5].Trim().ToString();

            if (split.Length <= (int)Header.historicoDescricaoMes6)
                throw new Exception("Not found historicoDescricaoMes6 in column: " + ((int)Header.historicoDescricaoMes6).ToString());
            model.historicoDescricaoMes6 = split[(int)Header.historicoDescricaoMes6].Trim().ToString();

            if (split.Length <= (int)Header.historicoMes6)
                throw new Exception("Not found historicoMes6 in column: " + ((int)Header.historicoMes6).ToString());
            model.historicoMes6 = split[(int)Header.historicoMes6].Trim().ToString();

            if (split.Length <= (int)Header.imagem)
                throw new Exception("Not found imagem in column: " + ((int)Header.imagem).ToString());
            model.imagem = split[(int)Header.imagem].Trim().ToString();



            if (split.Length <= (int)Header.ConsumoValorPagoCondominio)
                throw new Exception("Not found consumoM3pagoCondominio in column: " + ((int)Header.consumoM3pagoCondominio).ToString());
            model.ConsumoValorPagoCondominio = Convert.ToDecimal(split[(int)Header.ConsumoValorPagoCondominio].Trim());

            if (split.Length <= (int)Header.consumoM3pagoCondominio)
                throw new Exception("Not found consumoM3pagoCondominio in column: " + ((int)Header.consumoM3pagoCondominio).ToString());
            model.consumoM3pagoCondominio = Convert.ToInt32(split[(int)Header.consumoM3pagoCondominio].Trim());

            if (split.Length <= (int)Header.minimoM3PagoCondominio)
                throw new Exception("Not found minimoM3PagoCondominio in column: " + ((int)Header.minimoM3PagoCondominio).ToString());
            model.minimoM3PagoCondominio = Convert.ToInt32(split[(int)Header.minimoM3PagoCondominio].Trim());

            if (split.Length <= (int)Header.minimoValorPagoCondominio)
                throw new Exception("Not found minimoValorPagoCondominio in column: " + ((int)Header.minimoValorPagoCondominio).ToString());
            model.minimoValorPagoCondominio = Convert.ToDecimal(split[(int)Header.minimoValorPagoCondominio].Trim());

            if (split.Length <= (int)Header.excedenteM3PagoCondominio)
                throw new Exception("Not found excedenteM3PagoCondominio in column: " + ((int)Header.excedenteM3PagoCondominio).ToString());
            model.excedenteM3PagoCondominio = Convert.ToInt32(split[(int)Header.excedenteM3PagoCondominio].Trim());

            if (split.Length <= (int)Header.excedenteValorPagoCondominio)
                throw new Exception("Not found excedenteValorPagoCondominio in column: " + ((int)Header.excedenteValorPagoCondominio).ToString());
            model.excedenteValorPagoCondominio = Convert.ToDecimal(split[(int)Header.excedenteValorPagoCondominio].Trim());

            if (split.Length <= (int)Header.excedenteM3Rateio)
                throw new Exception("Not found excedenteM3Rateio in column: " + ((int)Header.excedenteM3Rateio).ToString());
            model.excedenteM3Rateio = Convert.ToInt32(split[(int)Header.excedenteM3Rateio].Trim());

            if (split.Length <= (int)Header.excedenteValorRateio)
                throw new Exception("Not found excedenteValorRateio in column: " + ((int)Header.excedenteValorRateio).ToString());
            model.excedenteValorRateio = Convert.ToDecimal(split[(int)Header.excedenteValorRateio].Trim());

            if (split.Length <= (int)Header.tarifaMinimaM3ValorDevido)
                throw new Exception("Not found tarifaMinimaM3ValorDevido in column: " + ((int)Header.tarifaMinimaM3ValorDevido).ToString());
            model.tarifaMinimaM3ValorDevido = Convert.ToInt32(split[(int)Header.tarifaMinimaM3ValorDevido].Trim());

            if (split.Length <= (int)Header.tarifaMinimaValorValorDevido)
                throw new Exception("Not found tarifaMinimaValorValorDevido in column: " + ((int)Header.tarifaMinimaValorValorDevido).ToString());
            model.tarifaMinimaValorValorDevido = Convert.ToDecimal(split[(int)Header.tarifaMinimaValorValorDevido].Trim());

            if (split.Length <= (int)Header.excedenteValorDevido)
                throw new Exception("Not found excedenteValorDevido in column: " + ((int)Header.excedenteValorDevido).ToString());
            model.excedenteValorDevido = Convert.ToDecimal(split[(int)Header.excedenteValorDevido].Trim());


            if (split.Length <= (int)Header.valorPagarValorDevido)
                throw new Exception("Not found valorPagarValorDevido in column: " + ((int)Header.valorPagarValorDevido).ToString());
            model.valorPagarValorDevido = Convert.ToDecimal(split[(int)Header.valorPagarValorDevido].Trim());

            if (split.Length <= (int)Header.avisoGeralAviso)
                throw new Exception("Not found avisoGeralAviso in column: " + ((int)Header.avisoGeralAviso).ToString());
            model.avisoGeralAviso = split[(int)Header.avisoGeralAviso].Trim().ToString();

            if (split.Length <= (int)Header.AnormalAviso)
                throw new Exception("Not found AnormalAviso in column: " + ((int)Header.AnormalAviso).ToString());
            model.AnormalAviso = split[(int)Header.AnormalAviso].Trim().ToString();

            if (split.Length <= (int)Header.individualAviso)
                throw new Exception("Not found individualAviso in column: " + ((int)Header.individualAviso).ToString());
            model.individualAviso = split[(int)Header.individualAviso].Trim();

            if (split.Length <= (int)Header.anormalidadeAviso)
                throw new Exception("Not found anormalidadeAviso in column: " + ((int)Header.anormalidadeAviso).ToString());
            model.anormalidadeAviso = split[(int)Header.anormalidadeAviso].Trim().ToString();

            if (split.Length <= (int)Header.individualAviso)
                throw new Exception("Not found individualAviso in column: " + ((int)Header.individualAviso).ToString());
            model.individualAviso = split[(int)Header.individualAviso].Trim().ToString();

            if (split.Length <= (int)Header.ano)
                throw new Exception("Not found ano in column: " + ((int)Header.ano).ToString());
            model.ano = Convert.ToInt32(split[(int)Header.ano].Trim());

            if (split.Length <= (int)Header.mes)
                throw new Exception("Not found mes in column: " + ((int)Header.mes).ToString());
            model.mes = Convert.ToInt32(split[(int)Header.mes].Trim());

            if (split.Length <= (int)Header.excedenteM3diaria)
                throw new Exception("Not found  excedenteM3diaria in column: " + ((int)Header.excedenteM3diaria).ToString());
             decimal excedenteM3diario = Convert.ToDecimal(split[(int)Header.excedenteM3diaria].Trim().ToString());
             model.excedenteM3diaria = (float)excedenteM3diario;
           
            return model;
        }

        #endregion




        #region IIteropProject Members
        /// <summary>
        /// Methods which read the file and convert it to the model
        /// </summary>
        /// <param name="file">File to be loaded</param>
        /// <returns>List of objects found</returns>        
        public listaSegundaViaAgua LoadFile(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("file");


            if (!System.IO.File.Exists(file))
                throw new Exception("File " + file + " not found.");


            StreamReader reader = new StreamReader(file, Encoding.Unicode, false);

            return LoadFile(reader.BaseStream);

        }


        public string ReplaceAt(string value, int index, char newchar)
        {
            if (value.Length <= index)
                return value;
            else
                return string.Concat(value.Select((c, i) => i == index ? newchar : c));
        }

        /// <summary>
        /// Methods which read the file and convert it to the model
        /// </summary>
        /// <param name="file">File to be loaded</param>
        /// <returns>List of objects found</returns>                
        public listaSegundaViaAgua LoadFile(Stream file)
        {
            listaSegundaViaAgua list = new listaSegundaViaAgua();
            int lineNumber = 0;

            StreamReader reader = new StreamReader(file, Encoding.Default, false);


            try
            {


                //Checking all lines of the file
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();

                    int count = line.Length;
                    
                    if(line[count -5] == '.')
                    {
                        line = line.Remove(count - 5, 1);
                        line = line.Insert(count - 5, ",");

                    }
                 
                    
                    //Converting the line to object
                    ReciboAgua newObject = ConvertRowToObject(lineNumber, line);

                    //If found a valid object
                   
                    if (newObject != null)
                        list.Add(newObject);

                    lineNumber++;

                }//end while




            }
            finally
            {
                reader.Close();
            }

            return list;
        }

    }
        #endregion
}