﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hiriart_Corales_UWPApp_AgendaPersonal.Core.Models
{
    public class ListaContacto
    {
        public int ListaContactoID { get; set; }
        public Nullable<int> IDEvento { get; set; }
        public string NombreApellido { get; set; }
    }
}
