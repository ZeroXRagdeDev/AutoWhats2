using AutoWhats.Interfaces;

using AutoWhats.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AutoWhats
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            btnActServ.Clicked += BtnActServ_Clicked;
            //  chVoz.CheckedChanged += ChVoz_CheckedChanged;
            chVoz.Toggled += ChVoz_Toggled;
            btnConfigLector.Clicked += BtnConfigLecto_Clicked;


            if (Preferences.ContainsKey("LeerTodos"))
            {
                bool estado_contactos_lectura = Preferences.Get("LeerTodos", true);
                DependencyService.Get<XamarinAndroidGlobal>().setDatos(estado_contactos_lectura, "CONTACTOS");
            }
            else
            {
                DependencyService.Get<XamarinAndroidGlobal>().setDatos(true, "CONTACTOS");
            }


            if (Preferences.ContainsKey("CondicionDispositivo"))
            {
                bool estado_dispositivos_lectura = Preferences.Get("CondicionDispositivo", true);
                DependencyService.Get<XamarinAndroidGlobal>().setDatos(estado_dispositivos_lectura, "DISPOSITVOS");
            }
            else
            {
                DependencyService.Get<XamarinAndroidGlobal>().setDatos(false, "DISPOSITVOS");
            }

            if (Preferences.ContainsKey("EstadoVoz"))
            {
              //  chVoz.IsChecked = Preferences.Get("EstadoVoz", false);
                chVoz.IsToggled = Preferences.Get("EstadoVoz", false);
                DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats(chVoz.IsToggled);
                
            }
            else {
               // Preferences.Set("EstadoVoz", chVoz.IsChecked);
                Preferences.Set("EstadoVoz", chVoz.IsToggled);
            }
        }

        /*
        private void ChVoz_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("EstadoVoz", chVoz.IsChecked);
            DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats();

        }*/
        private void ChVoz_Toggled(object sender, ToggledEventArgs e)
        {
            Preferences.Set("EstadoVoz", chVoz.IsToggled);
            DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats(chVoz.IsToggled);
        }

        private async void BtnConfigLecto_Clicked(object sender, EventArgs e)
        {
          //  App.Current.MainPage =  new NavigationPage(new ConfigurarVoz());
            await Navigation.PushModalAsync(new ConfigurarVoz());
            // App.Current.MainPage = new NavigationPage(new ConfigurarVoz());
        }

      

        private void BtnActServ_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<XamarinAndroidGlobal>().ConfigurarNotificacion();
        }
    }
}
