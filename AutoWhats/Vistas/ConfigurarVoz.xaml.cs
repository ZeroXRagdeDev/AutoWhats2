using AutoWhats.Interfaces;
using AutoWhats.Modelos;
using AutoWhats.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoWhats.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurarVoz : ContentPage
    {
        
        public ObservableCollection<Contacto> contactos { get; set; }

        public ConfigurarVoz()
        {
            InitializeComponent();


            BindingContext = this;
            chReadAll.CheckedChanged += ChReadAll_CheckedChanged;
            btnAddContacto.Clicked += BtnAddContacto_Clicked;
            btnBack.Clicked += BtnBack_Clicked;


            var status =  Permissions.CheckStatusAsync<Permissions.ContactsRead>();
            if (status.Result != PermissionStatus.Granted)
            {
                btnAddContacto.Text = "Obtener Permiso Contactos";
            }




            if (Preferences.ContainsKey("LeerTodos"))
            {
                chReadAll.IsChecked = Preferences.Get("LeerTodos", true);
            }
            else {
                Preferences.Set("LeerTodos", true);
            }
           
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnAddContacto_Clicked(object sender, EventArgs e)
        {
            BtnAddContacto_ClickedAsync();
        }

        private async Task BtnAddContacto_ClickedAsync()
        {
            try
            {
                Contacto nuevo_contacto = await ControlContactos.obtenerContactoAsync();
                if (nuevo_contacto.displayName == "")
                {
                    btnAddContacto.Text = "Seleccionar Contacto";
                    return;
                }
                contactos.Add(nuevo_contacto);

                string json = JsonConvert.SerializeObject(contactos, Formatting.Indented);
                Preferences.Set("Contactos",json);
              

            }
            catch (Exception ex)
            {
                Console.WriteLine("FLASH:" + ex);
            }

        }


        private void ChReadAll_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("LeerTodos", chReadAll.IsChecked);
            if (!chReadAll.IsChecked)
            {
                btnAddContacto.IsVisible = true;
                ContenedorContactos.IsVisible = true;
                contactos = new ObservableCollection<Contacto>();

                ListView listaContactos = new ListView();
                listaContactos.RowHeight = 60;

                listaContactos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));

                loadContactos();



                 listaContactos.ItemsSource = contactos;


                ContenedorContactos.Content = listaContactos;


            }
            else {
                ContenedorContactos.IsVisible = false;
                btnAddContacto.IsVisible = false;
                ContenedorContactos.Content = null;
            }
        }



        private void loadContactos() {

            string json_contactos = Preferences.Get("Contactos","");

            if(json_contactos == "")
            {
                return;
            }
            contactos = JsonConvert.DeserializeObject<ObservableCollection<Contacto>>(json_contactos);

        }





    }
}