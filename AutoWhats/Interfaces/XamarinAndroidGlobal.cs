
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
        void ADVoiceReaderWhats();
        bool obtenerEstadoBluethooth();
        List<Dispositivo> obtenerDispositivos();


    }
}
