using PriceMonitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StockMarket
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            this.InitializeComponent();

            if (!string.IsNullOrWhiteSpace(Configs.Acoes))
                this._acoes = Configs.Acoes.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region Private Fields

        private bool _bypassFormClosing = false;

        private string[] _acoes;

        private WebMonitor _webMonitor = null;

        private BindingList<AbstractRow> _table = new BindingList<AbstractRow>();

        #endregion

        #region Private Methods

        private List<TabPage> CreateTabsControls()
        {
            var tabPageControlList = new List<TabPage>();

            this._acoes = this._acoes.Where(x => x.ToUpper() == "IBOV").Concat(this._acoes.Where(x => x.ToUpper() != "IBOV").OrderBy(x => x)).ToArray();

            foreach (var acao in this._acoes)
            {
                var tabPage = new TabPage()
                {
                    Location = new Point(-1, 22),
                    Padding = new Padding(3),
                    Size = new Size(814, 608),
                    Text = acao
                };

                this.tbcPriceMonitor.Controls.Add(tabPage);

                tabPageControlList.Add(tabPage);
            }

            return tabPageControlList;
        }

        private void RunMonitoringControls(List<TabPage> tabPagesControlList)
        {
            this._webMonitor.Run((List<AcoesCollection> acoesCollections) =>
            {
                if (acoesCollections == null || !acoesCollections.Any())
                    return;

                this.Invoke(new Action(() =>
                {
                    this.UpdateAbstract(acoesCollections);

                    foreach (var tabPageControl in tabPagesControlList)
                    {
                        if (!tabPageControl.Visible)
                            continue;

                        ((PriceMonitorControl)tabPageControl.Controls[0]).UpdateControl(acoesCollections);
                    }
                }));
            });
        }

        private void LoadAbstract(List<AcoesCollection> acoesCollections)
        {
            if (acoesCollections == null)
                return;

            acoesCollections = acoesCollections.Where(x => x.Name.ToLower() == "ibov").Concat(acoesCollections.Where(x => x.Name.ToLower() != "ibov")).ToList();

            foreach (var acao in acoesCollections)
                this._table.Add(new AbstractRow(DateTime.Now, acao));

            this.Day.HeaderText = "Dia " + DateTime.Now.ToString("dd/MM/yyyy");
            this.dgvAbstract.DataSource = this._table;
        }

        private void UpdateAbstract(List<AcoesCollection> acoesCollections)
        {
            if (acoesCollections == null || !acoesCollections.Any())
                return;

            foreach (var acoesCollection in acoesCollections)
            {
                var acao = acoesCollection.Acoes.LastOrDefault(x => x.RequestedDate.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"));

                if (acao == null)
                    continue;

                var row = this._table.FirstOrDefault(x => x.Name == acoesCollection.Name);

                if (row == null)
                    this._table.Add(new AbstractRow(DateTime.Now, acoesCollection));
                else
                    row.UpdateValue(acao);
            }

            this.Day.HeaderText = "Dia " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._bypassFormClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void ntiTrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Visible = true;
            else if (e.Button == MouseButtons.Right)
            {
                this.tcmMenu.Show(Control.MousePosition);
            }
        }

        private void tcmMenuClose_Click(object sender, EventArgs e)
        {
            this._bypassFormClosing = true;
            this.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._webMonitor = new WebMonitor(this._acoes);

            var acoesMonitorList = this._webMonitor.AcoesCollections;
            this.LoadAbstract(acoesMonitorList);

            var tabsControls = this.CreateTabsControls();
            this.RunMonitoringControls(tabsControls);
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            this._bypassFormClosing = true;
            this.Dispose();
        }

        private void btnRestartApplication_Click(object sender, EventArgs e)
        {
            this._bypassFormClosing = true;
            Application.Restart();
        }

        private void tbcPriceMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage control in this.tbcPriceMonitor.Controls)
                if (control.Name != "tbpAbstract" && control.Controls.Count > 0)
                    control.Controls.Clear();

            var tabPage = this.tbcPriceMonitor.SelectedTab;
            var name = tabPage.Text;

            if (name == "Resumo")
                return;

            var priceMonitorControl = new PriceMonitorControl(name)
            {
                Dock = DockStyle.Fill,
                Location = new Point(3, 3),
                Size = new Size(808, 602),
                TabIndex = 1
            };

            tabPage.Controls.Add(priceMonitorControl);

            var acoesMonitorList = this._webMonitor.AcoesCollections;

            priceMonitorControl.UpdateControl(acoesMonitorList);
        }

        private void tsmConfig_Click(object sender, EventArgs e)
        {
            var form = new ConfigForm();
            form.ShowDialog();
        }
    }
}
