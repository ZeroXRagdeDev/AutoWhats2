using AutoWhats.Controles;
using AutoWhats.Modelos;
using AutoWhats.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoWhats.Tools
{
    public class CustomViewCell : ViewCell
    {

        public CustomViewCell()
        {
            //instantiate each of our views
            Tarjeta card = new Tarjeta();
            Height = 100;
            View = card;
      
        }
        public CustomViewCell(int i)
        {
            //instantiate each of our views
            Tarjeta card = new Tarjeta();
            Height = 100;
            View = card;
      
        }


    }
}
