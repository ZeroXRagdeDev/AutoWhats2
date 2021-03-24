using AutoWhats.Interfaces;

using AutoWhats.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoWhats
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            btnActServ.Clicked += BtnActServ_Clicked;
            chVoz.CheckedChanged += ChVoz_CheckedChanged;
            btnConfigLector.Clicked += BtnConfigLecto_Clicked;
          
        }

        private void BtnConfigLecto_Clicked(object sender, EventArgs e)
        {
            foreach (var folder in Enum.GetValues(typeof(Environment.SpecialFolder))) { 
                Console.WriteLine("{0}={1}", folder, Environment.GetFolderPath((Environment.SpecialFolder)folder)); 
            
            }
            // App.Current.MainPage = new NavigationPage(new ConfigurarVoz());
        }

        private void ChVoz_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
          
            DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats();
           
        }

        private void BtnActServ_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<XamarinAndroidGlobal>().ConfigurarNotificacion();
        }
    }
}
