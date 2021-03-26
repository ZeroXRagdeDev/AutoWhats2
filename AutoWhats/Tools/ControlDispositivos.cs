using AutoWhats.Interfaces;
using AutoWhats.Modelos;
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

        public static void loadDispositivos() {
            dispositivos = obtenerDispositivos();
        }

        public static  List<Dispositivo> obtenerDispositivos() {



            List<Dispositivo> tmp = new List<Dispositivo>();

            if (DependencyService.Get<XamarinAndroidGlobal>().obtenerEstadoBluethooth()) {
                tmp=DependencyService.Get<XamarinAndroidGlobal>().obtenerDispositivos();
            }

            return tmp;
        }
    }
}
