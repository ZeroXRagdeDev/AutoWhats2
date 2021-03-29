using AutoWhats.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoWhats.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tarjeta : ContentView
    {

     
        public ImageButton btnDel { get; set; }
        private CheckBox chSelDispositivo { get; set; }

        public Tarjeta()
        {
            InitializeComponent();

            chSelDispositivo = new CheckBox { 
              IsVisible=false
            };
            chSelDispositivo.CheckedChanged += ChSelDispositivo_CheckedChanged;

            btnDel = new ImageButton {
              BackgroundColor=Color.DarkRed,
              Source="btn_delete"
            };
            btnDel.Clicked += BtnDelete_Clicked;

            gridPrincipal.Children.Add(btnDel, 1,0);
            gridPrincipal.Children.Add(chSelDispositivo, 1, 0);

        }

        private void ChSelDispositivo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chSelDispositivo.IsChecked)
            {
                ControlDispositivos.dispositivos_seleccionados.Add(blueName.Text);
               
            }
            else {
                ControlDispositivos.dispositivos_seleccionados.RemoveAll(vehicle => vehicle == blueName.Text);
            }
           
            ControlDispositivos.saveDispositivo();//string blueName.Text
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            string da = tipoObjeto.Text;
            switch (tipoObjeto.Text)
            {
                case "DISPOSITIVO":
                    btnDel.IsVisible = false;
                    chSelDispositivo.IsVisible = true;
                    chSelDispositivo.SetBinding(CheckBox.IsCheckedProperty, "marcado");
                    break;
                case "CONTACTO":

                    break;
            }
            Console.WriteLine(da);
        }





        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            ControlContactos.removeContacto(idContacto.Text);
        }
    }
}