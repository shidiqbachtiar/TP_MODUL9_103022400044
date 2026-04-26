using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_MODUL9_103022400044
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            satuan_suhu = "celcius";
            batas_hari_demam = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public static CovidConfig LoadConfig()
        {
            if (!File.Exists(filePath))
            {
                CovidConfig defaultConfig = new CovidConfig();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<CovidConfig>(json);
        }

        public void SaveConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

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
