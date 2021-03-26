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

     
        public ImageButton btnDel { get; set; }

        public Tarjeta()
        {
            InitializeComponent();
            



            btnDel = new ImageButton {
              BackgroundColor=Color.DarkRed,
              Source="btn_delete"
            };
            btnDel.Clicked += BtnDelete_Clicked;

            gridPrincipal.Children.Add(btnDel, 1,0);

            switch (tipoObjeto.Text) {
                case "DISPOSITIVO":
                    btnDel.IsVisible = false;
                    break;
                case "CONTACTO":

                    break;
            }
        }
        public string getTipo() { return tipoObjeto.Text; }


        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            ControlContactos.removeContacto(idContacto.Text);
        }
    }
}