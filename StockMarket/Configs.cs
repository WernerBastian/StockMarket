using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockMarket
{
    public static class Configs
    {
        #region Attributes and Properties

        public static string Acoes { get; set; }
        public static TimeSpan Opening { get; set; }
        public static TimeSpan Closing { get; set; }

        #endregion

        #region Private Methods

        private static string ReadConfig(Dictionary<string, string> configs, string key)
        {
            if (configs.ContainsKey(key))
                return configs[key];

            return string.Empty;
        }

        private static Dictionary<string, string> ReadFile()
        {
            var configs = new Dictionary<string, string>();

            if (!File.Exists("config.ini"))
                return configs;

            using (var sr = new StreamReader("config.ini", Encoding.UTF8))
            {
                while (true)
                {
                    var line = sr.ReadLine();

                    if (line == null)
                        break;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    configs.Add(line.Split('=')[0], line.Split('=')[1]);
                }
            }

            return configs;
        }

        #endregion

        #region Public Methods

        public static void Load()
        {
            var raw = ReadFile();
            if (string.IsNullOrWhiteSpace(ReadConfig(raw, "ABERTURA")))
                Acoes = "IBOV";
            else
                Acoes = ReadConfig(raw, "ACOES");

            if (string.IsNullOrWhiteSpace(ReadConfig(raw, "ABERTURA")))
                Opening = new TimeSpan(10, 0, 0);
            else
                Opening = TimeSpan.Parse(ReadConfig(raw, "ABERTURA"));

            if(string.IsNullOrWhiteSpace(ReadConfig(raw, "FECHAMENTO")))
                Closing = new TimeSpan(18, 30, 0);
            else
                Closing = TimeSpan.Parse(ReadConfig(raw, "FECHAMENTO"));
        }

        public static void Save()
        {
            var sb = new StringBuilder();
            sb.AppendLine("ACOES=" + Acoes);
            sb.AppendLine("ABERTURA=" + Opening.ToString("hh\\:mm\\:ss"));
            sb.AppendLine("FECHAMENTO=" + Closing.ToString("hh\\:mm\\:ss"));

            using (var sw = new StreamWriter("config.ini"))
                sw.Write(sb.ToString().Trim());
        }

        #endregion
    }
}
