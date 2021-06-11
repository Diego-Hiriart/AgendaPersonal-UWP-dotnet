using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class Evento
    {             
        public int EventoID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public bool EsSerie { get; set; }
        public string Dias { get; set; }

        public string Contactos { get; set; }
        public string Notificaciones { get; set; }
        public string Memo { get; set; }
    }
}
