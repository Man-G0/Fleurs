namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class ChoixBoutiques
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            layoutForm2 = new TableLayoutPanel();
            labelFidelité = new Label();
            layoutUtile = new TableLayoutPanel();
            comboBoxBoutiques = new ComboBox();
            labelBoutiques = new Label();
            buttonOk = new Button();
            bienvenue = new Label();
            layoutForm2.SuspendLayout();
            layoutUtile.SuspendLayout();
            SuspendLayout();
            // 
            // layoutForm2
            // 
            layoutForm2.ColumnCount = 1;
            layoutForm2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutForm2.Controls.Add(labelFidelité, 0, 1);
            layoutForm2.Controls.Add(layoutUtile, 0, 2);
            layoutForm2.Controls.Add(bienvenue, 0, 0);
            layoutForm2.Dock = DockStyle.Fill;
            layoutForm2.Location = new Point(0, 0);
            layoutForm2.Margin = new Padding(3, 4, 3, 4);
            layoutForm2.Name = "layoutForm2";
            layoutForm2.RowCount = 3;
            layoutForm2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6341448F));
            layoutForm2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.14634F));
            layoutForm2.RowStyles.Add(new RowStyle(SizeType.Percent, 76.21951F));
            layoutForm2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            layoutForm2.Size = new Size(914, 600);
            layoutForm2.TabIndex = 0;
            // 
            // labelFidelité
            // 
            labelFidelité.AutoEllipsis = true;
            labelFidelité.AutoSize = true;
            labelFidelité.BackColor = Color.FromArgb(239, 250, 165);
            labelFidelité.BorderStyle = BorderStyle.Fixed3D;
            labelFidelité.Dock = DockStyle.Fill;
            labelFidelité.Font = new Font("Berlin Sans FB", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelFidelité.Location = new Point(3, 87);
            labelFidelité.Name = "labelFidelité";
            labelFidelité.Size = new Size(908, 54);
            labelFidelité.TabIndex = 4;
            labelFidelité.Text = "Fidelité : Atteignez les 15 commandes !";
            labelFidelité.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // layoutUtile
            // 
            layoutUtile.ColumnCount = 3;
            layoutUtile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layoutUtile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layoutUtile.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layoutUtile.Controls.Add(comboBoxBoutiques, 1, 1);
            layoutUtile.Controls.Add(labelBoutiques, 1, 0);
            layoutUtile.Controls.Add(buttonOk, 1, 2);
            layoutUtile.Dock = DockStyle.Fill;
            layoutUtile.Location = new Point(3, 145);
            layoutUtile.Margin = new Padding(3, 4, 3, 4);
            layoutUtile.Name = "layoutUtile";
            layoutUtile.RowCount = 4;
            layoutUtile.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4254036F));
            layoutUtile.RowStyles.Add(new RowStyle(SizeType.Percent, 27.4894428F));
            layoutUtile.RowStyles.Add(new RowStyle(SizeType.Percent, 27.2695274F));
            layoutUtile.RowStyles.Add(new RowStyle(SizeType.Percent, 21.8156223F));
            layoutUtile.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            layoutUtile.Size = new Size(908, 451);
            layoutUtile.TabIndex = 0;
            // 
            // comboBoxBoutiques
            // 
            comboBoxBoutiques.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxBoutiques.BackColor = SystemColors.ControlLightLight;
            comboBoxBoutiques.Font = new Font("Berlin Sans FB", 18F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxBoutiques.FormattingEnabled = true;
            comboBoxBoutiques.Items.AddRange(new object[] { "Magasin 1", "Magasin 2", "Magasin 3", "Magasin 4" });
            comboBoxBoutiques.Location = new Point(184, 146);
            comboBoxBoutiques.Margin = new Padding(3, 4, 3, 4);
            comboBoxBoutiques.Name = "comboBoxBoutiques";
            comboBoxBoutiques.Size = new Size(538, 41);
            comboBoxBoutiques.TabIndex = 1;
            // 
            // labelBoutiques
            // 
            labelBoutiques.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelBoutiques.AutoSize = true;
            labelBoutiques.Font = new Font("Berlin Sans FB", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelBoutiques.Location = new Point(184, 72);
            labelBoutiques.Name = "labelBoutiques";
            labelBoutiques.Size = new Size(538, 33);
            labelBoutiques.TabIndex = 0;
            labelBoutiques.Text = "Veuillez selectionner votre boutique :\r\n";
            labelBoutiques.TextAlign = ContentAlignment.BottomLeft;
            // 
            // buttonOk
            // 
            buttonOk.Anchor = AnchorStyles.None;
            buttonOk.AutoSize = true;
            buttonOk.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOk.BackColor = Color.FromArgb(255, 168, 173);
            buttonOk.Font = new Font("Berlin Sans FB", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonOk.Location = new Point(396, 255);
            buttonOk.Margin = new Padding(3, 4, 3, 4);
            buttonOk.MaximumSize = new Size(229, 133);
            buttonOk.MinimumSize = new Size(114, 67);
            buttonOk.Name = "buttonOk";
            buttonOk.RightToLeft = RightToLeft.No;
            buttonOk.Size = new Size(114, 67);
            buttonOk.TabIndex = 3;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = false;
            buttonOk.Click += buttonOk_Click;
            // 
            // bienvenue
            // 
            bienvenue.Anchor = AnchorStyles.None;
            bienvenue.AutoSize = true;
            bienvenue.BackColor = Color.Transparent;
            bienvenue.Font = new Font("Berlin Sans FB Demi", 21.75F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            bienvenue.ForeColor = SystemColors.ActiveCaptionText;
            bienvenue.Location = new Point(360, 22);
            bienvenue.Name = "bienvenue";
            bienvenue.Size = new Size(194, 43);
            bienvenue.TabIndex = 1;
            bienvenue.Text = "Bienvenue";
            bienvenue.TextAlign = ContentAlignment.TopCenter;
            // 
            // ChoixBoutiques
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(163, 212, 255);
            Controls.Add(layoutForm2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ChoixBoutiques";
            Size = new Size(914, 600);
            layoutForm2.ResumeLayout(false);
            layoutForm2.PerformLayout();
            layoutUtile.ResumeLayout(false);
            layoutUtile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutForm2;
        private TableLayoutPanel layoutUtile;
        private Label bienvenue;
        private ComboBox comboBoxBoutiques;
        private Label labelBoutiques;
        private Button buttonOk;
        private Label labelFidelité;
    }
}
