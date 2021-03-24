using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AutoWhats.Modelos
{
    public class Contacto
    {
        public static int cantidad_telefono=0;
        public string nombre { get; set; }
        public string numero { get; set; }
        public string foto { get; set; }

        public string id = "";
        public string namePrefix = "";
        public string givenName = "";
        public string middleName = "";
        public string familyName = "";
        public string nameSuffix = "";
        public string displayName = "";
        public List<ContactPhone> phones = new List<ContactPhone>();
        public List<ContactEmail> emails = new List<ContactEmail>();

        public Contacto() {
            cantidad_telefono++;
            foreach (ContactPhone telefono in phones) {
                if (telefono.PhoneNumber != "") {
                    numero = telefono.PhoneNumber;
                    break;
                }
                nombre = displayName;
            }
        }
    }

}
