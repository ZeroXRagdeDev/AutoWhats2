﻿using AutoWhats.Interfaces;

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
            chVoz.CheckedChanged += ChVoz_CheckedChanged;
            btnConfigLector.Clicked += BtnConfigLecto_Clicked;
           
           
            if (Preferences.ContainsKey("EstadoVoz"))
            {
                chVoz.IsChecked = Preferences.Get("EstadoVoz", false);
                if (chVoz.IsChecked) {
                    DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats();
                }
            }
            else {
                Preferences.Set("EstadoVoz", chVoz.IsChecked);
            }
        }

        private void BtnConfigLecto_Clicked(object sender, EventArgs e)
        {

             App.Current.MainPage = new NavigationPage(new ConfigurarVoz());
        }

        private void ChVoz_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Set("EstadoVoz", chVoz.IsChecked);
            DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats();
           
        }

        private void BtnActServ_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<XamarinAndroidGlobal>().ConfigurarNotificacion();
        }
    }
}
