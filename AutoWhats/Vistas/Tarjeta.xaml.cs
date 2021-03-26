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
    public partial class Tarjeta : ContentView
    {
        public Tarjeta()
        {
            InitializeComponent();
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            ControlContactos.removeContacto(idContacto.Text);
        }
    }
}