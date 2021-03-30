using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWhats.Modelos
{
    public class Dispositivo
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public bool marcado { get; set; }
        public UUID uuid { get; set; }
        public string direccion { get; set; }

    }
}
