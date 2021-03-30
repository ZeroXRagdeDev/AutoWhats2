
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Notification;
using Android.Support.V4.App;
using Android.Util;
using AutoWhats.Modelos;
using Java.Lang;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Object = Java.Lang.Object;

namespace AutoWhats.Droid
{
    [Service(Label = "NLService", Permission = "android.permission.BIND_NOTIFICATION_LISTENER_SERVICE")]
    [IntentFilter(new[] { "android.service.notification.NotificationListenerService" })]
    public class NLService : NotificationListenerService
    {
        public override void OnCreate()
        {   
            base.OnCreate();
            Log.Info("start running", "Servico Criado");
        }
        public override void OnDestroy()
        {
        
            base.OnDestroy();
        }
        public override IBinder OnBind(Intent intent)
        {
         
            return base.OnBind(intent);
        }
       
        public override bool OnUnbind(Intent intent)
        {
            StopService(new Intent(this, typeof(NLService)));
            StopSelf();
            return base.OnUnbind(intent);
        }


        public override void OnNotificationPosted(StatusBarNotification sbn)
        {

            string packageName = sbn.PackageName;
            try
            {
                Notification noty = sbn.Notification;
                if (noty.Category.ToString() == "msg") {
                    Bundle contenedr = noty.Extras;

                    string demo = contenedr.GetCharSequence(NotificationCompat.ExtraTextLines);


                    string[] multiMensajes = contenedr.GetCharSequenceArray("android.textLines");

                    string content = noty.TickerText.ToString();
                    //    TextToSpeech.SpeakAsync("Mensaje" );
                    //  TextToSpeech.SpeakAsync("de" );
                    bool estao_lectura = ControlGlobalAndroid.estado_voice;

                    if (estao_lectura) {

                        if (ControlGlobalAndroid.android_contactos_lectura_estado)
                        {
                            foreach (string contacto_ in ControlGlobalAndroid.android_contactos) {
                                if (contacto_ == content)
                                {
                                    if (ControlGlobalAndroid.android_dispositivos_lectura_estado)
                                    {
                                        // List<Dispositivo> dispo = ControlGlobalAndroid.obtenerDispositivos();
                                        string NOMBRE_ACTUAL_B = ControlGlobalAndroid.obtenerNombreDeviceConectado();
                                        List<string> device_selec = ControlGlobalAndroid.android_dispositivos;
                                        foreach (string dispositivo_actual in device_selec)
                                        {
                                            if (dispositivo_actual == NOMBRE_ACTUAL_B)
                                            {//Si el dispositivo actual esta conectado
                                             //Y esta en la lista de seleccionado se usa

                                                TextToSpeech.SpeakAsync(content);

                                                if (multiMensajes == null)
                                                {
                                                    string mensaje = contenedr.GetString(NotificationCompat.ExtraText);
                                                    if (ControlGlobalAndroid.estado_voice)
                                                    {
                                                        TextToSpeech.SpeakAsync(mensaje);
                                                    }

                                                }
                                                else
                                                {

                                                    foreach (string mensaje in multiMensajes)
                                                    {
                                                        if (ControlGlobalAndroid.estado_voice)
                                                        {
                                                            TextToSpeech.SpeakAsync(mensaje);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                    else
                                    { //TODOS CONTACTOS SELECCIONADOS

                                            TextToSpeech.SpeakAsync(content);

                                            if (multiMensajes == null)
                                            {
                                                string mensaje = contenedr.GetString(NotificationCompat.ExtraText);
                                                if (ControlGlobalAndroid.estado_voice)
                                                {
                                                    TextToSpeech.SpeakAsync(mensaje);
                                                }

                                            }
                                            else
                                            {

                                                foreach (string mensaje in multiMensajes)
                                                {
                                                    if (ControlGlobalAndroid.estado_voice)
                                                    {
                                                        TextToSpeech.SpeakAsync(mensaje);
                                                    }
                                                }
                                            }
                                    }
                                }
                            }




                        }
                        else { //TODOS
                            TextToSpeech.SpeakAsync(content);

                            if (multiMensajes == null)
                            {
                                string mensaje = contenedr.GetString(NotificationCompat.ExtraText);
                                if (ControlGlobalAndroid.estado_voice)
                                {
                                    TextToSpeech.SpeakAsync(mensaje);
                                }

                            }
                            else
                            {

                                foreach (string mensaje in multiMensajes)
                                {
                                    if (ControlGlobalAndroid.estado_voice)
                                    {
                                        TextToSpeech.SpeakAsync(mensaje);
                                    }
                                }
                            }
                        }
                    
                    }


                    if (ControlGlobalAndroid.estado_voice)
                    {
                       
                    }
                    





                  //  Console.WriteLine("YO SOY BATMAN");


                    
                }


                base.OnNotificationPosted(sbn);
            }
            catch(System.Exception ex) {
                Console.WriteLine("BATMAN DICE:"+ex);
            }
         

        }

        public void leer(string titulo, string mensaje) {
            
            TextToSpeech.SpeakAsync(titulo);


            TextToSpeech.SpeakAsync(mensaje);

        }
        public override void OnNotificationRemoved(StatusBarNotification sbn)
        {
            base.OnNotificationRemoved(sbn);
        }
    }
}