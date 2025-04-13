using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300108
{
    public class CovidConfig
    {
        const string filePath = "..//..//..//covid_config.json";
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig(){
            LoadConfig();
        }
        private class CovidData
        {
            public string satuan_suhu { get; set; }
            public int batas_hari_deman { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }
        }

        public void LoadConfig()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<CovidData>(json);
                if (data != null)
                {
                    satuan_suhu = data.satuan_suhu;
                    batas_hari_deman = data.batas_hari_deman;
                    pesan_ditolak = data.pesan_ditolak;
                    pesan_diterima = data.pesan_diterima;
                }
            }
            else
            {
                SaveConfig();
            }
        }



        public void SaveConfig()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else 
            {
                satuan_suhu = "celcius";
            }
                SaveConfig();
        }
    }
}
