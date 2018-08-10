using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
    public class ProprietarioModel
    {

        public string proprietario1 { get; set; }
        public string proprietario2 { get; set; }
        public ApartamentoModel ap { get; set; }
        public string senha { get; set; }
        public string email { get; set;}
        public string telefone { get; set; }
        public string proprietarioImovel { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string celular { get; set; }
        public string estadoCivil { get; set; }
        public string cepEndereco { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string alugaGaragem { get; set; }
        public int qtdBicicleta { get; set; }
        public string descricaoBike { get; set; }
        public List<Depedentes> dependentes;
        public List<Transporte> transporte;
        public Animais animais;
        public List<Empregados> empregados;
        public Imobiliaria imobiliaria;
        public Emergencia emergencia;

     }

    public class listProprietario : List<ProprietarioModel> { };

}
