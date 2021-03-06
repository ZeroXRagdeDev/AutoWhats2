using AutoWhats.Interfaces;
using AutoWhats.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutoWhats.Tools
{
    public class ControlContactos
    {

        public static ObservableCollection<Contacto> contactos { get; set; }
        public static bool estado = false;

        public static bool removeContacto(string id) {

            Contacto mycontacto = getContacto(id);
            if (mycontacto != null)
            {
                try {
                    contactos.Remove(mycontacto);
                    saveContactos();
                    return true;
                } catch
                {
                    return false;
                }


            }
            else {
                Console.WriteLine("No se encontro el contacto");
                return false;
            }


        }
        public static Contacto getContacto(string id)
        {
            foreach (Contacto contacto in contactos) {
                if (id == contacto.id) {
                    return contacto;
                }
            }

            return null;

        }

        public static void saveContactos() {
            string json = JsonConvert.SerializeObject(contactos, Formatting.Indented);
            Preferences.Set("Contactos", json);
            loadContactos();
        }
        public static void loadContactos()
        {
            if (contactos is null) {
                contactos = new ObservableCollection<Contacto>();
            }
            string json_contactos = Preferences.Get("Contactos", "");
           

            if (json_contactos == "")
            {
                return;
            }
            contactos = JsonConvert.DeserializeObject<ObservableCollection<Contacto>>(json_contactos);
            List<string> my_data = new List<string>();
            foreach (Contacto c in contactos) {
                 my_data.Add(c.nombre);
            }
            DependencyService.Get<XamarinAndroidGlobal>().setDatos(my_data, "CONTACTOS");

        }
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
                    string numero = "";
                    foreach (ContactPhone telefono in phones)
                    {
                        if (telefono.PhoneNumber != "")
                        {
                            numero = telefono.PhoneNumber;
                            break;
                        }
                        
                    }
                    tmp = new Contacto() { 
                      id=id,
                      namePrefix=namePrefix,
                      givenName=givenName,
                      middleName=middleName,
                      familyName=familyName,
                      nameSuffix=nameSuffix,
                      displayName=displayName,
                      nombre=displayName,
                      numero= numero,
                      phones =phones,
                      emails=emails,
                      tipo= "CONTACTO"
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
