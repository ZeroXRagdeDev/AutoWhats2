
using Android;

using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Support.V4.App;
using AutoWhats.Droid;
using AutoWhats.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Manifest;



[assembly: Dependency(typeof(ControlGlobalAndroid))]
namespace AutoWhats.Droid
{

    public class ControlGlobalAndroid : XamarinAndroidGlobal
    {
        public static Context contextApp;
        public static bool estado_voice = false;



            

        public void ADVoiceReaderWhats()
        {
            estado_voice = !estado_voice;
        }

        public void ConfigurarNotificacion() {


            Android.Content.PM.Permission permiso_noty = contextApp.CheckSelfPermission(Manifest.Permission.BindNotificationListenerService);
            //permiso_noty == Permission.Denied ||

            NotificationManagerCompat manager = NotificationManagerCompat.From(contextApp);
            var IsAllowed = manager.AreNotificationsEnabled();



            if (IsAllowed)
            {

                Intent intent = new Intent("android.settings.ACTION_NOTIFICATION_LISTENER_SETTINGS");
                contextApp.StartActivity(intent);
            }

        }




    }
}