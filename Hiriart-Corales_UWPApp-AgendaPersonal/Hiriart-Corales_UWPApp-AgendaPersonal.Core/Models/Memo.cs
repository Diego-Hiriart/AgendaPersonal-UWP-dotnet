using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class Memo
    {
        public int MemoID { get; set; }
        public string Contenido { get; set; }

        public int? Evento { get; set; }
    }
}
