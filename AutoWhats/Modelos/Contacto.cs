using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWhats.Modelos
{
    public class Contacto
    {
        public long Id = 0;
        public string DisplayName = "";
        public string PhotoUri = "";
        public string Name = "",
                      Image = "";
        public string[] Emails = null,
                        PhoneNumbers=null;
    }
}
