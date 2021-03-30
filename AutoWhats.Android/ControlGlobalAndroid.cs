
using Android;
using Android.Bluetooth;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Support.V4.App;
using AutoWhats.Droid;
using AutoWhats.Interfaces;
using AutoWhats.Modelos;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Android.Manifest;



[assembly: Dependency(typeof(ControlGlobalAndroid))]
namespace AutoWhats.Droid
{

    public class ControlGlobalAndroid : XamarinAndroidGlobal
    {
        public static Context contextApp;
        public static bool estado_voice = false;
        public static List<string> android_contactos = new List<string>();
        public static List<string> android_dispositivos = new List<string>();

        public static bool android_contactos_lectura_estado = false;
        public static bool android_dispositivos_lectura_estado = false;

        public bool obtenerEstadoBluethooth() {


            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
            {
                return false;

            }
            if (!adapter.IsEnabled)
            {
                return false;
            }
            return true;

        }
        public static string obtenerNombreDeviceConectado() {

            List<Dispositivo> dispo =  obtenerDispositivos(true);

            foreach (Dispositivo dispositivo in dispo) {
                if (checkEstadoBluetooth(dispositivo.uuid, dispositivo.direccion)) {
                    return dispositivo.nombre;
                }
            }

            return "";


        }
 
        public static bool checkEstadoBluetooth(UUID uuid,string address) {


            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            BluetoothDevice device = adapter.GetRemoteDevice(address);

            try {

           
             
               var _socket = device.CreateRfcommSocketToServiceRecord(uuid);
                _socket.Connect();


                return true;


            } catch(Exception ex) {
                Console.WriteLine(ex);
                return false;
            }

        }
       
        
        public static List<Dispositivo> obtenerDispositivos(bool demo)
        {

            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            List<Dispositivo> tmp = new List<Dispositivo>();


            if (!adapter.IsEnabled)
            {
                return tmp;
            }

            ICollection<BluetoothDevice> devices = adapter.BondedDevices;
            foreach (BluetoothDevice device in devices)
            {


                Dispositivo destmp = new Dispositivo();
                /* if (checkEstadoBluetooth(device))
                 {
                     destmp.conectado = true;
                 }
                 else {
                     destmp.conectado = false;
                 }*/
                destmp.uuid = device.GetUuids()[0].Uuid;
                destmp.nombre = device.Name;
                destmp.direccion = device.Address;

                destmp.tipo = "DISPOSITIVO";
                tmp.Add(destmp);
            }




            return tmp;

        }
        public List<Dispositivo> obtenerDispositivos() {
           
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            List<Dispositivo> tmp = new List<Dispositivo>();


            if (!adapter.IsEnabled) {
                return tmp;
            }
    
            ICollection<BluetoothDevice> devices = adapter.BondedDevices;
            foreach (BluetoothDevice device in devices) {


                Dispositivo destmp = new Dispositivo();

                destmp.uuid = device.GetUuids()[0].Uuid;
                destmp.nombre=device.Name;
                destmp.direccion=device.Address;
              
                destmp.tipo = "DISPOSITIVO";
                tmp.Add(destmp);
            }




            return tmp;
        
        }
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


        public void setDatos(List<string> datos,string tipo)
        {
            switch (tipo) {
                case "CONTACTOS":
                    android_contactos = datos;
                    break;
                case "DISPOSITIVO":
                    android_dispositivos = datos;
                    break;
            
            }
        }

        public void setDatos(bool estado, string tipo)
        {

            switch (tipo)
            {
                case "CONTACTOS":
                    android_contactos_lectura_estado = estado;
                    break;
                case "DISPOSITIVO":
                    android_dispositivos_lectura_estado = estado;
                    break;

            }
        }
    }
}