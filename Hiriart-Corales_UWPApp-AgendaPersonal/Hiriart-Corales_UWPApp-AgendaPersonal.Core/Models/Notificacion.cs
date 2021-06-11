using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class Notificacion
    {      
        public int NotificacionID { get; set; }
        public string Titulo { get; set; }
        public DateTime Hora { get; set; }

        public int? Evento { get; set; }
    }
}
