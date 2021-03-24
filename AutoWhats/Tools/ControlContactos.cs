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

        public static async Task<Contacto> obtenerContactoAsync() {
            
            Contacto tmp = new Contacto();
            Contact contact = null;
            try
            {

                var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.ContactsRead>();
                }
                else {
                     contact = await Contacts.PickContactAsync();

                    string id = contact.Id;
                    string namePrefix = contact.NamePrefix;
                    string givenName = contact.GivenName;
                    string middleName = contact.MiddleName;
                    string familyName = contact.FamilyName;
                    string nameSuffix = contact.NameSuffix;
                    string displayName = contact.DisplayName;
                    List<ContactPhone> phones = contact.Phones; // List of phone numbers
                    List <ContactEmail> emails = contact.Emails; // List of email addresses

                    tmp = new Contacto() { 
                      id=id,
                      namePrefix=namePrefix,
                      givenName=givenName,
                      middleName=middleName,
                      familyName=familyName,
                      nameSuffix=nameSuffix,
                      displayName=displayName,
                      phones=phones,
                      emails=emails
                    };
                    
                    return tmp;
                }

 
            }
            catch (Exception ex)
            {
                return tmp;
            }

            return tmp;

        }
    }
}
