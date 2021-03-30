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
                chReadAll.IsToggled = Preferences.Get("LeerTodos", true);
            }
            else {
                Preferences.Set("LeerTodos", true);
            }

            if (!chReadAll.IsToggled)
            {
                reloadLista();

            }
            DependencyService.Get<XamarinAndroidGlobal>().setDatos(chReadAll.IsToggled, "CONTACTOS");



            if (Preferences.ContainsKey("CondicionDispositivo"))
            {
                chDisp.IsToggled = Preferences.Get("CondicionDispositivo", true);
            }
            else {
                Preferences.Set("CondicionDispositivo", false);
            }


            if (chDisp.IsToggled) {
                ContenedorDispositivos.IsVisible = true;
                gridDisContect.IsVisible = true;

            }

            DependencyService.Get<XamarinAndroidGlobal>().setDatos(chDisp.IsToggled, "DISPOSITIVO");

        }

        private void ChDisp_Toggled(object sender, ToggledEventArgs e)
        {
           
            Preferences.Set("CondicionDispositivo", chDisp.IsToggled);
            DependencyService.Get<XamarinAndroidGlobal>().setDatos(chDisp.IsToggled, "DISPOSITIVO");

            if (chDisp.IsToggled)
            {
                ContenedorDispositivos.IsVisible = true;
                gridDisContect.IsVisible = true;
               
                ListView listaDispositivos = new ListView();
                listaDispositivos.RowHeight = 60;
                listaDispositivos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));


                //RECARGAMOS LOS DISPOSITIVO
                ControlDispositivos.loadDispositivos();
                listaDispositivos.ItemsSource = ControlDispositivos.dispositivos;
               ContenedorDispositivos.Content = listaDispositivos;
                ControlDispositivos.estado = true;

            }
            else
            {

                ContenedorDispositivos.IsVisible = false;
                ControlDispositivos.estado = false;
            }




        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnAddContacto_Clicked(object sender, EventArgs e)
        {
            _ = BtnAddContacto_ClickedAsync();
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

                if (!ControlContactos.contactos.Contains(nuevo_contacto)) {
                    ControlContactos.contactos.Add(nuevo_contacto);
                    ControlContactos.saveContactos();
                    ControlContactos.loadContactos();
                    reloadLista();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("FLASH:" + ex);
            }

        }
        private void reloadLista() {

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
        private void ChReadAll_Toggled(object sender, ToggledEventArgs e)
        {

            Preferences.Set("LeerTodos", chReadAll.IsToggled);

            DependencyService.Get<XamarinAndroidGlobal>().setDatos(chReadAll.IsToggled, "CONTACTOS");

            if (!chReadAll.IsToggled)
            {
               
                reloadLista();
                ControlContactos.estado = false;
            }
            else
            {
                ContenedorContactos.IsVisible = false;
                btnAddContacto.IsVisible = false;
                ContenedorContactos.Content = null;
                ControlContactos.estado = true;
            }
        }








    }
}