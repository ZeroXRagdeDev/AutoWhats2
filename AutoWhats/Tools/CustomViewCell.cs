using AutoWhats.Controles;
using AutoWhats.Modelos;
using AutoWhats.Vistas;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AutoWhats.Tools
{
    public class CustomViewCell : ViewCell
    {
        Tarjeta card;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            string tipo = card.getTipo();
            Console.WriteLine(tipo);

        }
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            string tipo = card.getTipo();
            Console.WriteLine(tipo);
        }

        public CustomViewCell()
        {

            //instantiate each of our views

             card = new Tarjeta();

            Height = 100;


            View = card;

        }



    }
}
