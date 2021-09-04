using PriceMonitor;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StockMarket
{
    public partial class PriceMonitorControl : UserControl
    {
        public PriceMonitorControl()
        {
            this.InitializeComponent();
        }

        public PriceMonitorControl(string acao)
        {
            this.Acao = acao;

            this.InitializeComponent();
        }

        public string Acao { get; }

        public void UpdateControl(List<AcoesCollection> acoesCollections)
        {
            var teste = this.Acao;
            var acaoList = acoesCollections.FirstOrDefault(x => x.Name == teste);

            IEnumerable<Acao> acoes = new List<Acao>();

            if (acaoList != null)
                acoes = acaoList.Acoes;

            this.dgvListPrice.DataSource = acoes.Reverse().Take(60).ToList();
        }
    }
}
