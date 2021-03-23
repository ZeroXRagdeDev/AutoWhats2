using AutoWhats.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
namespace AutoWhats.Tools
{
    public class ControlContactos
    {

        public static async Task<Contacto> obtenerContacto() {
            
            Contacto tmp = new Contacto();

            try
            {
                var contact = await Contacts.PickContactAsync();

                if (contact == null) { return tmp; }
                  

                var id = contact.Id;
                var namePrefix = contact.NamePrefix;
                var givenName = contact.GivenName;
                var middleName = contact.MiddleName;
                var familyName = contact.FamilyName;
                var nameSuffix = contact.NameSuffix;
                var displayName = contact.DisplayName;
                var phones = contact.Phones; // List of phone numbers
                var emails = contact.Emails; // List of email addresses
            }
            catch (Exception ex)
            {
                return tmp;
            }

            return tmp;

        }
    }
}
