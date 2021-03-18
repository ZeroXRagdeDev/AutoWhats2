using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Service.Notification;
using Android;
using Android.Support.V4.App;
using System.Collections.Generic;

namespace AutoWhats.Droid
{
    [Activity(Label = "AutoWhats", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
#pragma warning disable CS0657 // No hay ninguna ubicación de atributo válida para esta declaración
    [assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
#pragma warning restore CS0657 // No hay ninguna ubicación de atributo válida para esta declaración

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {

            ControlGlobalAndroid.contextApp = this;


            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);


            Xamarin.Essentials.Preferences.Set("SetSubcription", true);
           

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


        }
    


        public override void OnBackPressed()
        {
           
            StopService(new Intent(this, typeof(NLService)));
            base.OnBackPressed();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       
    }
}