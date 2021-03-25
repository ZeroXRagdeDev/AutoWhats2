using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoWhats.Controles
{
    class CustomButton:ImageButton
    {


        public CustomButton() {
            /*

                                        Margin="1,1,360,1"
                                        Padding="2"
                                        VerticalOptions="Fill"
             */
            Margin = new Thickness(1,1,360,1);
            Padding = 2;
            Scale = 1;
            HeightRequest = 1;
            WidthRequest = 500;
            VerticalOptions = LayoutOptions.Fill;

        }


    }
}
