using StockMarket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PriceMonitor
{
    public class WebMonitor
    {
        #region Consts

        public const int UPDATE_INTERVAL = 60; // seconds

        public static DateTime MARKET_OPENING
        {
            get { return DateTime.Today + Configs.Opening; }
        }

        public static DateTime MARKET_CLOSING
        {
            get { return DateTime.Today + Configs.Closing; }
        }

        #endregion

        #region Constructors

        public WebMonitor(string[] acoes)
        {
            this._acoes = acoes;
        }

        #endregion

        #region Private Fields

        private string[] _acoes;
        private Dictionary<string, decimal> _minValues = new Dictionary<string, decimal>();

        #endregion

        #region Attributes and Properties

        private List<AcoesCollection> _acoesCollection = null;
        public List<AcoesCollection> AcoesCollections
        {
            get
            {
                if (this._acoesCollection == null)
                {
                    this._acoesCollection = this.LoadFromFile();

                    if (!this._acoesCollection.Any())
                    {
                        foreach (var acao in this._acoes)
                        {
                            var collection = new AcoesCollection();
                            collection.Name = acao;

                            this._acoesCollection.Add(collection);
                        }
                    }

                    foreach (var acoes in this._acoesCollection)
                        this._minValues.Add(acoes.Name, acoes.Acoes.LastOrDefault()?.MinimunPrice ?? 0M);
                }

                return this._acoesCollection;
            }
        }

        #endregion

        #region Private Methods

        private List<AcoesCollection> LoadFromFile()
        {
            if (!Directory.Exists("DataFiles"))
                Directory.CreateDirectory("DataFiles");

            var acoesMonitorList = new List<AcoesCollection>();

            foreach (var file in Directory.EnumerateFiles("DataFiles"))
            {
                if (!this._acoes.Any(x => x == Path.GetFileNameWithoutExtension(file)))
                    continue;

                var acoes = new AcoesCollection();

                using (var sr = new StreamReader(file))
                {
                    while (true)
                    {
                        var line = (sr.ReadLine() ?? "").Trim();

                        if (string.IsNullOrEmpty(line))
                            break;

                        if (!line.Contains(";"))
                            continue;

                        var coulumns = line.Count(x => x == ';');
                        if (coulumns != 9)
                            while (coulumns < 9)
                            {
                                coulumns++;
                                line = line + ";";
                            }

                        var splitedLine = line.Split(';');

                        if (!acoes.Acoes.Any())
                            acoes.Name = splitedLine[0];

                        acoes.Acoes.Add(new Acao()
                        {
                            RequestedDate = Convert.ToDateTime(splitedLine[1]),
                            Date = Convert.ToDateTime(splitedLine[2]),
                            OppeningPrice = Convert.ToDecimal(splitedLine[3]),
                            Price = Convert.ToDecimal(splitedLine[4]),
                            MinimunPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[5]) ? "0" : splitedLine[5]),
                            MaximunPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[6]) ? "0" : splitedLine[6]),
                            AveragePrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[7]) ? "0" : splitedLine[7]),
                            Volume = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[8]) ? "0" : splitedLine[8]),
                            ClosedPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[9]) ? "0" : splitedLine[9])
                        });
                    }
                }

                if (acoes.Acoes.Any())
                    acoesMonitorList.Add(acoes);
            }

            return acoesMonitorList;
        }

        private void SaveToFile(string name, Acao acao)
        {
            if (!Directory.Exists("DataFiles"))
                Directory.CreateDirectory("DataFiles");

            var spliter = ";";
            using (var sw = new StreamWriter(Path.Combine("DataFiles", name + ".txt"), true))
                sw.WriteLine(
                    name + spliter +
                    acao.RequestedDate + spliter +
                    acao.Date + spliter +
                    acao.OppeningPrice + spliter +
                    acao.Price + spliter +
                    acao.MinimunPrice + spliter +
                    acao.MaximunPrice + spliter +
                    acao.AveragePrice + spliter +
                    acao.Volume + spliter +
                    acao.ClosedPrice);
        }

        #endregion

        #region Public Methods

        public static List<AcoesCollection> LoadFromFile(string fileName)
        {
            var acoesMonitorList = new List<AcoesCollection>();

            foreach (var file in Directory.EnumerateFiles("DataFiles"))
            {
                if (Path.GetFileNameWithoutExtension(file) != fileName)
                    continue;

                var acoes = new AcoesCollection();

                using (var sr = new StreamReader(file))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();

                        if (string.IsNullOrEmpty(line))
                            break;

                        var coulumns = line.Count(x => x == ';');
                        if (coulumns != 9)
                            while (coulumns < 9)
                            {
                                coulumns++;
                                line = line + ";";
                            }

                        var splitedLine = line.Split(';');

                        if (!acoes.Acoes.Any())
                            acoes.Name = splitedLine[0];

                        acoes.Acoes.Add(new Acao()
                        {
                            RequestedDate = Convert.ToDateTime(splitedLine[1]),
                            Date = Convert.ToDateTime(splitedLine[2]),
                            OppeningPrice = Convert.ToDecimal(splitedLine[3]),
                            Price = Convert.ToDecimal(splitedLine[4]),
                            MinimunPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[5]) ? "0" : splitedLine[5]),
                            MaximunPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[6]) ? "0" : splitedLine[6]),
                            AveragePrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[7]) ? "0" : splitedLine[7]),
                            Volume = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[8]) ? "0" : splitedLine[8]),
                            ClosedPrice = Convert.ToDecimal(string.IsNullOrEmpty(splitedLine[9]) ? "0" : splitedLine[9])
                        });
                    }
                }

                if (acoes.Acoes.Any())
                    acoesMonitorList.Add(acoes);
            }

            return acoesMonitorList;
        }

        #endregion
    }
}
