namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class Ajout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutAjoutStock = new TableLayoutPanel();
            SuspendLayout();
            // 
            // layoutAjoutStock
            // 
            layoutAjoutStock.ColumnCount = 1;
            layoutAjoutStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutAjoutStock.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutAjoutStock.Dock = DockStyle.Fill;
            layoutAjoutStock.Location = new Point(0, 0);
            layoutAjoutStock.Name = "layoutAjoutStock";
            layoutAjoutStock.RowCount = 1;
            layoutAjoutStock.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutAjoutStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutAjoutStock.Size = new Size(433, 389);
            layoutAjoutStock.TabIndex = 0;
            // 
            // Ajout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(163, 212, 255);
            ClientSize = new Size(433, 389);
            Controls.Add(layoutAjoutStock);
            Name = "Ajout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ajout";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutAjoutStock;
        private AjoutStock ajoutStock;
        private AjoutMagasin ajoutMagasin;

        private void Stock()
        {
            ClientSize = new Size(433, 389);
            ajoutStock = new AjoutStock(form1, this);
            Controls.Add(ajoutStock);
            ajoutStock.Name = "ajout Stock";
            ajoutStock.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutStock, 0, 0);
        }
        private void Magasin()
        {
            ClientSize = new Size(433, 389);
            ajoutMagasin = new AjoutMagasin(form1, this);
            Controls.Add(ajoutMagasin);
            ajoutMagasin.Name = "ajout Magasin";
            ajoutMagasin.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutMagasin, 0, 0);
        }
    }
}