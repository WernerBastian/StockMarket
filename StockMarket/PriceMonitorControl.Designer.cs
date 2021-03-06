using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockMarket
{
    partial class PriceMonitorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListPrice = new StockMarket.CustomDataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OppeningPrice_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosedPrice_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimunPrice_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximunPrice_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AveragePrice_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume_Formated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListPrice
            // 
            this.dgvListPrice.AllowUserToAddRows = false;
            this.dgvListPrice.AllowUserToDeleteRows = false;
            this.dgvListPrice.AllowUserToResizeColumns = false;
            this.dgvListPrice.AllowUserToResizeRows = false;
            this.dgvListPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListPrice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            this.dgvListPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Date,
            this.Price_Formated,
            this.OppeningPrice_Formated,
            this.ClosedPrice_Formated,
            this.MinimunPrice_Formated,
            this.MaximunPrice_Formated,
            this.AveragePrice_Formated,
            this.Volume_Formated});
            this.dgvListPrice.EnableHeadersVisualStyles = false;
            this.dgvListPrice.Location = new System.Drawing.Point(3, 3);
            this.dgvListPrice.MultiSelect = false;
            this.dgvListPrice.Name = "dgvListPrice";
            this.dgvListPrice.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListPrice.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListPrice.RowHeadersVisible = false;
            this.dgvListPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListPrice.Size = new System.Drawing.Size(806, 665);
            this.dgvListPrice.TabIndex = 9;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.DataPropertyName = "RequestedDate";
            this.Description.HeaderText = "Data da Requisição";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 130;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Data";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 59;
            // 
            // Price_Formated
            // 
            this.Price_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price_Formated.DataPropertyName = "Price_Formated";
            this.Price_Formated.HeaderText = "Preço (R$)";
            this.Price_Formated.Name = "Price_Formated";
            this.Price_Formated.ReadOnly = true;
            this.Price_Formated.Width = 87;
            // 
            // OppeningPrice_Formated
            // 
            this.OppeningPrice_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OppeningPrice_Formated.DataPropertyName = "OppeningPrice_Formated";
            this.OppeningPrice_Formated.HeaderText = "Abertura (R$)";
            this.OppeningPrice_Formated.Name = "OppeningPrice_Formated";
            this.OppeningPrice_Formated.ReadOnly = true;
            this.OppeningPrice_Formated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OppeningPrice_Formated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OppeningPrice_Formated.Width = 80;
            // 
            // ClosedPrice_Formated
            // 
            this.ClosedPrice_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ClosedPrice_Formated.DataPropertyName = "ClosedPrice_Formated";
            this.ClosedPrice_Formated.HeaderText = "Fechamento (R$)";
            this.ClosedPrice_Formated.Name = "ClosedPrice_Formated";
            this.ClosedPrice_Formated.ReadOnly = true;
            this.ClosedPrice_Formated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClosedPrice_Formated.Width = 99;
            // 
            // MinimunPrice_Formated
            // 
            this.MinimunPrice_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MinimunPrice_Formated.DataPropertyName = "MinimunPrice_Formated";
            this.MinimunPrice_Formated.HeaderText = "Mínimo (R$)";
            this.MinimunPrice_Formated.Name = "MinimunPrice_Formated";
            this.MinimunPrice_Formated.ReadOnly = true;
            this.MinimunPrice_Formated.Width = 94;
            // 
            // MaximunPrice_Formated
            // 
            this.MaximunPrice_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaximunPrice_Formated.DataPropertyName = "MaximunPrice_Formated";
            this.MaximunPrice_Formated.HeaderText = "Máximo (R$)";
            this.MaximunPrice_Formated.Name = "MaximunPrice_Formated";
            this.MaximunPrice_Formated.ReadOnly = true;
            this.MaximunPrice_Formated.Width = 95;
            // 
            // AveragePrice_Formated
            // 
            this.AveragePrice_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AveragePrice_Formated.DataPropertyName = "AveragePrice_Formated";
            this.AveragePrice_Formated.HeaderText = "Médio (R$)";
            this.AveragePrice_Formated.Name = "AveragePrice_Formated";
            this.AveragePrice_Formated.ReadOnly = true;
            this.AveragePrice_Formated.Width = 88;
            // 
            // Volume_Formated
            // 
            this.Volume_Formated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Volume_Formated.DataPropertyName = "Volume_Formated";
            this.Volume_Formated.HeaderText = "Volume";
            this.Volume_Formated.Name = "Volume_Formated";
            this.Volume_Formated.ReadOnly = true;
            this.Volume_Formated.Width = 71;
            // 
            // PriceMonitorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvListPrice);
            this.Name = "PriceMonitorControl";
            this.Size = new System.Drawing.Size(812, 671);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView dgvListPrice;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Price_Formated;
        private DataGridViewTextBoxColumn OppeningPrice_Formated;
        private DataGridViewTextBoxColumn ClosedPrice_Formated;
        private DataGridViewTextBoxColumn MinimunPrice_Formated;
        private DataGridViewTextBoxColumn MaximunPrice_Formated;
        private DataGridViewTextBoxColumn AveragePrice_Formated;
        private DataGridViewTextBoxColumn Volume_Formated;
    }
}
