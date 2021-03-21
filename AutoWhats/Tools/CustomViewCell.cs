using AutoWhats.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoWhats.Tools
{
    public class CustomViewCell : ViewCell
    {

        Label _myLabel;
        MenuItem _deleteAction;

        public CustomViewCell()
        {
            _myLabel = new Label();
            View = _myLabel;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _myLabel.Text = "OPKPOKOPK";

            var item = BindingContext as myViewModel;
            if (item != null)
            {
                _myLabel.Text = item.Text;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Subscribe ViewCell Event Handlers
            _deleteAction.Clicked += HandleDeleteClicked;
            ContextActions.Add(_deleteAction);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //Unsubscribe ViewCell Event Handlers
            _deleteAction.Clicked -= HandleDeleteClicked;
            ContextActions.Remove(_deleteAction);
        }

        void HandleDeleteClicked(object sender, EventArgs e)
        {
            //Code to handle when the delete action is tapped
        }

        public static implicit operator View(CustomViewCell v)
        {
            throw new NotImplementedException();
        }
    }
}
