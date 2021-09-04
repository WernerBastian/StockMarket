using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StockMarket
{
    public partial class ConfigForm : Form
    {
        #region Constructors

        public ConfigForm()
        {
            this.InitializeComponent();

            this.txtAcoes.Text = Configs.Acoes;
            this.txtOpening.Text = Configs.Opening.ToString("hh\\:mm\\:ss");
            this.txtClosing.Text = Configs.Closing.ToString("hh\\:mm\\:ss");
        }

        #endregion

        #region Private Methods

        private void ManageButton()
        {
            if (this.txtAcoes.ForeColor == Color.Black &&
                this.txtClosing.ForeColor == Color.Black &&
                this.txtOpening.ForeColor == Color.Black)
            {
                this.btnOK.Enabled = true;
            }
            else
            {
                this.btnOK.Enabled = false;
            }
        }


        private bool Save()
        {
            if (!this.ValidateAcoes(this.txtAcoes.Text) || !this.ValidateTime(this.txtOpening.Text) || !this.ValidateTime(this.txtClosing.Text))
            {
                MessageBox.Show("Nem todos os campos são válidos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Configs.Acoes = this.txtAcoes.Text;
            Configs.Opening = TimeSpan.Parse(this.txtOpening.Text);
            Configs.Closing = TimeSpan.Parse(this.txtClosing.Text);
            Configs.Save();

            MessageBox.Show("Configurações salvas com sucesso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }


        private bool ValidateAcoes(string acoes)
        {
            var regex = new Regex(@"(([A-Z]{4}[0-9]{0,2})[;]{0,1})", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);

            var result = string.Empty;
            foreach (Match match in regex.Matches(acoes))
                result += match.Value;

            if (acoes == result)
                return true;
            else
                return false;
        }

        private bool ValidateTime(string time)
        {
            try
            {
                //Testa se consegue dar parse
                var result = TimeSpan.Parse(time);
                if (result.Days != 0)
                    return false;

                var regex = new Regex(@"^[0-9]{2}:[0-9]{2}:[0-9]{2}$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (regex.IsMatch(time))
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Signed Event Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Save())
                this.Dispose();
        }


        private void txtAcoes_TextChanged(object sender, EventArgs e)
        {
            if (this.ValidateAcoes(this.txtAcoes.Text))
                this.txtAcoes.ForeColor = Color.Black;
            else
                this.txtAcoes.ForeColor = Color.Red;

            this.ManageButton();
        }

        private void txtClosing_TextChanged(object sender, EventArgs e)
        {
            if (this.ValidateTime(this.txtClosing.Text))
                this.txtClosing.ForeColor = Color.Black;
            else
                this.txtClosing.ForeColor = Color.Red;

            this.ManageButton();
        }

        private void txtOpening_TextChanged(object sender, EventArgs e)
        {
            if (this.ValidateTime(this.txtOpening.Text))
                this.txtOpening.ForeColor = Color.Black;
            else
                this.txtOpening.ForeColor = Color.Red;

            this.ManageButton();
        }

        #endregion
    }
}
