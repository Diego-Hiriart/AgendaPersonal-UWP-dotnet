using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class Diario
    {
        public int DiarioID { get; set; }       
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }

        public List<Nullable<int>> ListaEventoID { get; set; }
    }
}
