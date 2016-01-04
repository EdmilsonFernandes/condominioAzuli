using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azuli.Web.Model
{
   

        public class Visitas
        {
            public DateTime dataVisita { get; set; }
            public Visitante idVisitante { get; set; }
            public ApartamentoModel oAP { get; set; }
            public string visitaPlacaCarro { get; set; }
            public string visitaModeloCarro { get; set; }
            public char visitaAutorizada { get; set; }
            public string visitaObs { get; set; }
        }

        public class ListaVisitas : List<Visitas>
        {

        }


        //public Nullable<DateTime> VisitaData {get;set;}
        //public int VisitanteId {get;set;}
        //public int Bloco {get;set;}
        //public int Apartamento {get;set;}
        //public string VisitaPlacaCarro {get;set;}
        //public string VistaModeloCarro {get;set;}
        //public string VisitaCorCarro {get;set;}
        //public string VisitaAutorizada {get;set;}
        //public string VisitaAutorizadaPor {get;set;}
        //public string VistaObs { get; set; }

        //public string VisitanteNome {get;set;}
        //public string VisitanteRG {get;set;}
        //public string VisitanteTipo {get;set;}
        //public byte   Foto {get;set;}



        
        //public Visitas()
        //{
        //    VisitaData          = DateTime.Parse("01-01-1753");
        //    VisitanteId         = 0;
        //    Bloco               = 0;
        //    Apartamento         = 0;
        //    VisitaPlacaCarro    = "";
        //    VistaModeloCarro    = "";
        //    VisitaCorCarro      = "";
        //    VisitaAutorizada    = "";
        //    VisitaAutorizadaPor = "";
        //    VistaObs            = "";

        //    VisitanteNome       = "";
        //    VisitanteRG         = "";
        //    VisitanteTipo       = "V";
        //    Foto                = 0;
        //}
    

    
}
