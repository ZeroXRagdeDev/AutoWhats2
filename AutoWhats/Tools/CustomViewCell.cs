using AutoWhats.Controles;
using AutoWhats.Modelos;
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
            Image image = new Image();
            Label nameLabel = new Label();
            Label typeLabel = new Label();

            StackLayout verticaLayout = new StackLayout();
            StackLayout horizontalLayout = new StackLayout() { BackgroundColor = Color.Aqua };
           
            
            CustomButton btnBorrar = new CustomButton();
            btnBorrar.Source = "btn_delete";


            //set bindings
            nameLabel.SetBinding(Label.TextProperty, new Binding("nombre"));
            typeLabel.SetBinding(Label.TextProperty, new Binding("numero"));
         

            //Set properties for desired design
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;

            nameLabel.FontSize = 24;

            //add views to the view hierarchy
            verticaLayout.Children.Add(nameLabel);
            verticaLayout.Children.Add(typeLabel);
            verticaLayout.Children.Add(btnBorrar);

            horizontalLayout.Children.Add(verticaLayout);
           

            // add to parent view
            View = horizontalLayout;
        }


    }
}
