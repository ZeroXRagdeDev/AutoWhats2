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
        
      

        public ConfigurarVoz()
        {
            InitializeComponent();


            BindingContext = this;
            chReadAll.Toggled += ChReadAll_Toggled;
            //chReadAll.CheckedChanged += ChReadAll_CheckedChanged;
            btnAddContacto.Clicked += BtnAddContacto_Clicked;
            btnBack.Clicked += BtnBack_Clicked;
            chDisp.Toggled += ChDisp_Toggled;


            var status =  Permissions.CheckStatusAsync<Permissions.ContactsRead>();
            if (status.Result != PermissionStatus.Granted)
            {
                btnAddContacto.Text = "Obtener Permiso Contactos";
            }




            if (Preferences.ContainsKey("LeerTodos"))
            {
               // chReadAll.IsChecked = Preferences.Get("LeerTodos", true);
                chReadAll.IsToggled = Preferences.Get("LeerTodos", true);
            }
            else {
                Preferences.Set("LeerTodos", true);
            }
           
        }

        private void ChDisp_Toggled(object sender, ToggledEventArgs e)
        {
           


            Preferences.Set("CondicionDispositivo", chDisp.IsToggled);

            if (!chDisp.IsToggled)
            {
                ContenedorDispositivos.IsVisible = true;
                btnAddContacto.IsVisible = true;
                ContenedorContactos.IsVisible = true;
                gridDisContect.IsVisible = true;

                ListView listaContactos = new ListView();
                listaContactos.RowHeight = 60;
                listaContactos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));

                //RECARGAMOS LOS CONTACTOS


                ContenedorContactos.Content = listaContactos;


            }
            else
            {
                ContenedorDispositivos.IsVisible = false;
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
                ControlContactos.contactos.Add(nuevo_contacto);
                ControlContactos.saveContactos();

            }
            catch (Exception ex)
            {
                Console.WriteLine("FLASH:" + ex);
            }

        }

        private void ChReadAll_Toggled(object sender, ToggledEventArgs e)
        {
            Preferences.Set("LeerTodos", chReadAll.IsToggled);
            if (!chReadAll.IsToggled)
            {
                btnAddContacto.IsVisible = true;
                ContenedorContactos.IsVisible = true;
                gridDisContect.IsVisible = true;

                ListView listaContactos = new ListView();
                listaContactos.RowHeight = 60;

                listaContactos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));

                ControlContactos.loadContactos();



                listaContactos.ItemsSource = ControlContactos.contactos;


                ContenedorContactos.Content = listaContactos;


            }
            else
            {
                ContenedorContactos.IsVisible = false;
                btnAddContacto.IsVisible = false;
                ContenedorContactos.Content = null;
            }
        }








    }
}