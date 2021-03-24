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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoWhats.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurarVoz : ContentPage
    {
        
        public ObservableCollection<Contacto> contactos { get; set; }

        public ConfigurarVoz()
        {
            InitializeComponent();
            BindingContext = this;
            chReadAll.CheckedChanged += ChReadAll_CheckedChanged;
            btnAddContacto.Clicked += BtnAddContacto_Clicked;
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
                contactos.Add(nuevo_contacto);

                string json = JsonConvert.SerializeObject(contactos, Formatting.Indented);
                ControlConfiguraciones.SaveData(json, "ContactosPermitidos");
              

            }
            catch (Exception ex)
            {
                Console.WriteLine("FLASH:" + ex);
            }

        }


        private void ChReadAll_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!chReadAll.IsChecked)
            {
                btnAddContacto.IsVisible = true;
                ContenedorContactos.IsVisible = true;
                contactos = new ObservableCollection<Contacto>();

                ListView listaContactos = new ListView();
                listaContactos.RowHeight = 60;

                listaContactos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));

                loadContactos();



                 listaContactos.ItemsSource = contactos;


                ContenedorContactos.Content = listaContactos;


            }
            else {
                ContenedorContactos.IsVisible = false;
                btnAddContacto.IsVisible = false;
                ContenedorContactos.Content = null;
            }
        }



        private void loadContactos() {

            string json_contactos = ControlConfiguraciones.ReadData("ContactosPermitidos");
            contactos = JsonConvert.DeserializeObject<ObservableCollection<Contacto>>(json_contactos);
            /*
            contactos.Add(new Contacto { nombre = "ED", numero = "52545" });
            contactos.Add(new Contacto { nombre = "Edgar", numero = "745454" });
            contactos.Add(new Contacto { nombre = "ruby", numero = "561321321321322545" });*/
        }





    }
}