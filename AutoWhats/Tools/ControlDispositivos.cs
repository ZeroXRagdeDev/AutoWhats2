using AutoWhats.Interfaces;
using AutoWhats.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutoWhats.Tools
{
    class ControlDispositivos
    {
        public static List<Dispositivo> dispositivos = new List<Dispositivo>();
        public static List<string> dispositivos_seleccionados = new List<string>();
        public static bool estado = false;


        public static void loadDispositivos() {

            dispositivos = obtenerDispositivos();
        }
        public static void saveDispositivo() {

            string json = JsonConvert.SerializeObject(dispositivos_seleccionados, Formatting.Indented);
            Preferences.Set("DispositivosSeleccionados", json);
            obtenerDispositivos();

        }
        public static  List<Dispositivo> obtenerDispositivos() {

            string json_dispositivos_sel = Preferences.Get("DispositivosSeleccionados","");

           
            dispositivos_seleccionados = JsonConvert.DeserializeObject<List<string>>(json_dispositivos_sel);
            if (dispositivos_seleccionados == null) { dispositivos_seleccionados = new List<string>(); }
            List<Dispositivo> tmp = new List<Dispositivo>();
            List<Dispositivo> tmpFinal = new List<Dispositivo>();

            List<string> cdispositivo_seleccionado = new List<string>();

        


            if (DependencyService.Get<XamarinAndroidGlobal>().obtenerEstadoBluethooth()) {
                tmp = DependencyService.Get<XamarinAndroidGlobal>().obtenerDispositivos();

                foreach (Dispositivo dispo in tmp) {
                   
                    if (dispositivos_seleccionados.Contains(dispo.nombre))
                    {
                        dispo.marcado = true;
                        cdispositivo_seleccionado.Add(dispo.nombre);
                    }
                    else {
                        dispo.marcado = false;
                    }
                    tmpFinal.Add(dispo);
                }


            }
            DependencyService.Get<XamarinAndroidGlobal>().setDatos(cdispositivo_seleccionado, "DISPOSITIVO");
            return tmpFinal;
        }
    }
}
