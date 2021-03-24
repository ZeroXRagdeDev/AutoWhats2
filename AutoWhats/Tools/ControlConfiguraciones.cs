using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace AutoWhats.Tools
{
    public class ControlConfiguraciones
    {
        public static string ReadData(string filename) {

            try
            {

                var backingFile = Path.Combine(GetFolderPath(SpecialFolder.Personal), filename+".json");

                if (backingFile == null || !File.Exists(backingFile))
                {
                    return null;
                }
                string FileData = string.Empty;
                using (var reader = new StreamReader(backingFile, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        FileData = line;
                    }
                }

                return FileData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }




        public static  void SaveData(string Data,string filename)
        {
            try
            {
               // string ruta = GetFolderPath(SpecialFolder.CommonApplicationData);
               // string ruta1 = GetFolderPath(SpecialFolder.ApplicationData);
                //string ruta2 = GetFolderPath(SpecialFolder.LocalApplicationData);
                string ruta3 = GetFolderPath(SpecialFolder.Personal);

                var backingFile = ruta3+"/"+filename+".json";
                using (var writer = File.CreateText(backingFile))
                {
                     writer.WriteLineAsync(Data);
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
