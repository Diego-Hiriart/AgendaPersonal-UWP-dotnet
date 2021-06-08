using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class Evento
    {
        public Nullable<int> DiarioID { get; set; }
        public Nullable<int> NotificacionID { get; set; }
        public Nullable<int> MemoID { get; set; }
        
        public int EventoID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public bool EsSerie { get; set; }
        public string Dias { get; set; }

        public List<Nullable<int>> ListaContactoID { get; set; }
    }
}
