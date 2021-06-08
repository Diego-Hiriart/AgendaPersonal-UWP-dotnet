using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    class ListaEvento
    {
        public int ListaEventoID { get; set; }
        public Nullable<int> IDDiario { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaEvento { get; set; }
    }
}
