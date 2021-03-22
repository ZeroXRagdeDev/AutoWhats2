﻿using AutoWhats.Modelos;
using AutoWhats.Tools;
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

        public ObservableCollection<Contacto> veggies { get; set; }

        public ConfigurarVoz()
        {
            InitializeComponent();
            BindingContext = this;
            chReadAll.CheckedChanged += ChReadAll_CheckedChanged;
        }

        private void ChReadAll_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!chReadAll.IsChecked)
            {

                veggies= new ObservableCollection<Contacto>();

                ListView listaContactos = new ListView();
                listaContactos.RowHeight = 60;

                listaContactos.ItemTemplate = new DataTemplate(typeof(CustomViewCell));
                
                veggies.Add(new Contacto { nombre = "ED", numero = "52545" });
                veggies.Add(new Contacto { nombre = "Edgar", numero = "745454" });
                veggies.Add(new Contacto { nombre = "ruby", numero = "561321321321322545" });


                 listaContactos.ItemsSource = veggies;


                ContenedorContactos.Content = listaContactos;


            }
            else {
                ContenedorContactos.Content = null;
            }
        }
    }
}