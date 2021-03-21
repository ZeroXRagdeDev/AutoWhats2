using AutoWhats.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            chReadAll.CheckedChanged += ChReadAll_CheckedChanged;
        }

        private void ChReadAll_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!chReadAll.IsChecked) {

                CustomViewCell celContactos = new CustomViewCell();

                ContenedorContactos.Content = celContactos.View;


            }
        }
    }
}