﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azuli.Web.Model;
using System.IO;

namespace Azuli.Web.Business.Interfaces
{
    public interface IReciboAgua
    {
        listaSegundaViaAgua buscaTodosRecibos(ReciboAgua oReciboAguaModel);
        listaSegundaViaAgua buscaTodosRecibosByYearAndMonth(int ano, int mes);
        listaSegundaViaAgua buscaTodosRecibosByBlocoAndApto(ReciboAgua oReciboModel);
        listaSegundaViaAgua buscaRecibosCalculadosByMesAno(int ano, int mes);
        void importIntegracaoWeb(ReciboAgua oReciboModel);
        void persisteCalculoFinalBanco(ReciboAgua oReciboModel);
        listaSegundaViaAgua LoadFile(string file);
        listaSegundaViaAgua LoadFile(Stream file);
        listaSegundaViaAgua validaImportacao(ReciboAgua oReciboModel);
        listaSegundaViaAgua graficosConsumoAgua(int yearBase);
        listaSegundaViaAgua graficoExcedentePorApartamento(int yearBase);
        listaSegundaViaAgua graficoConsumoPorBloco(int yearBase);
        listaSegundaViaAgua graficoQuantidadeApAnormal(int yearBase);
        listaSegundaViaAgua graficosConsumoAguaIndividual(int yearBase, int bloco, int apto);
        int validaPersistenciaAgua(int mes, int ano);
        int retornaConsumoHistorico(int mes, int ano, int bloco, int apto);

    }
}
