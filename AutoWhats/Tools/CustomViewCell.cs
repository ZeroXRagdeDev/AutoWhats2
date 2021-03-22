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
            var image = new Image();
            var nameLabel = new Label();
            var typeLabel = new Label();
            var verticaLayout = new StackLayout();
            var horizontalLayout = new StackLayout() { BackgroundColor = Color.Aqua };

            //set bindings
            nameLabel.SetBinding(Label.TextProperty, new Binding("nombre"));
            typeLabel.SetBinding(Label.TextProperty, new Binding("numero"));
          //  image.SetBinding(Image.SourceProperty, new Binding("Image"));

            //Set properties for desired design
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
            image.HorizontalOptions = LayoutOptions.End;
            nameLabel.FontSize = 24;

            //add views to the view hierarchy
            verticaLayout.Children.Add(nameLabel);
            verticaLayout.Children.Add(typeLabel);
            horizontalLayout.Children.Add(verticaLayout);
         //   horizontalLayout.Children.Add(image);

            // add to parent view
            View = horizontalLayout;
        }


    }
}
