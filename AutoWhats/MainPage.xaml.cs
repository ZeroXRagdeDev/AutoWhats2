using AutoWhats.Interfaces;
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
        }

        private void ChVoz_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            chVoz.IsChecked = !chVoz.IsChecked;
            DependencyService.Get<XamarinAndroidGlobal>().ADVoiceReaderWhats();
           
        }

        private void BtnActServ_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<XamarinAndroidGlobal>().ConfigurarNotificacion();
        }
    }
}
