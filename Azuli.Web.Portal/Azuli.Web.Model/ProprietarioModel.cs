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
        public List<Depedentes> dependentes;
        public List<Transporte> transporte;
        public Animais animais;
        public List<Empregados> empregados;
        public Imobiliaria imobiliaria;
        public Emergencia emergencia;

     }

    public class listProprietario : List<ProprietarioModel> { };

}
