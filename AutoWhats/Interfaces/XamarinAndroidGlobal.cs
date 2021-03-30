
using AutoWhats.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoWhats.Interfaces
{
    public interface XamarinAndroidGlobal
    {
        void ConfigurarNotificacion();
        void ADVoiceReaderWhats(bool estado = false);
        bool obtenerEstadoBluethooth();
        List<Dispositivo> obtenerDispositivos();
        void setDatos(List<string> datos,string tipo);
        void setDatos(bool estado, string tipo);



    }
}
