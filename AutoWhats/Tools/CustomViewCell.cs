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


        public CustomViewCell()
        {

            //instantiate each of our views

             card = new Tarjeta();

            Height = 100;


            View = card;

        }



    }
}
