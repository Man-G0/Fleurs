namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class AjoutBouquetPersonnalise
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
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            Non = new Button();
            Ok = new Button();
            Oui = new Button();
            button6 = new Button();
            label12 = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            textBox1 = new TextBox();
            textBox9 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataAjoutBouquetPerso = new DataGridView();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataAjoutBouquetPerso).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.FromArgb(163, 212, 255);
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel8, 0, 4);
            tableLayoutPanel5.Controls.Add(button6, 0, 0);
            tableLayoutPanel5.Controls.Add(label12, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel9, 0, 2);
            tableLayoutPanel5.Controls.Add(dataAjoutBouquetPerso, 0, 3);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 5;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 16.5481071F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 5.21369362F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 17.2199554F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 51.65987F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 9.358371F));
            tableLayoutPanel5.Size = new Size(819, 515);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.7134056F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.4981546F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.6654358F));
            tableLayoutPanel8.Controls.Add(Non, 2, 0);
            tableLayoutPanel8.Controls.Add(Ok, 1, 0);
            tableLayoutPanel8.Controls.Add(Oui, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 468);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(813, 44);
            tableLayoutPanel8.TabIndex = 6;
            // 
            // Non
            // 
            Non.Anchor = AnchorStyles.Left;
            Non.BackColor = Color.FromArgb(255, 168, 173);
            Non.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            Non.Location = new Point(460, 3);
            Non.Name = "Non";
            Non.Size = new Size(96, 38);
            Non.TabIndex = 2;
            Non.Text = "Non";
            Non.UseVisualStyleBackColor = false;
            // 
            // Ok
            // 
            Ok.Anchor = AnchorStyles.None;
            Ok.BackColor = Color.FromArgb(255, 168, 173);
            Ok.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            Ok.Location = new Point(350, 3);
            Ok.Name = "Ok";
            Ok.Size = new Size(88, 38);
            Ok.TabIndex = 1;
            Ok.Text = "Ok";
            Ok.UseVisualStyleBackColor = false;
            Ok.Visible = false;
            Ok.Click += Ok_Click;
            // 
            // Oui
            // 
            Oui.Anchor = AnchorStyles.Right;
            Oui.BackColor = Color.FromArgb(255, 168, 173);
            Oui.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            Oui.Location = new Point(232, 3);
            Oui.Name = "Oui";
            Oui.Size = new Size(96, 38);
            Oui.TabIndex = 0;
            Oui.Text = "Oui";
            Oui.UseVisualStyleBackColor = false;
            Oui.Click += Oui_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button6.BackColor = Color.FromArgb(255, 242, 222);
            button6.Enabled = false;
            button6.Font = new Font("Berlin Sans FB", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(3, 3);
            button6.Name = "button6";
            button6.Size = new Size(813, 79);
            button6.TabIndex = 3;
            button6.Text = "Ajout d'un bouquet personnalisé";
            button6.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom;
            label12.AutoSize = true;
            label12.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.FromArgb(192, 0, 0);
            label12.Location = new Point(191, 91);
            label12.Name = "label12";
            label12.Size = new Size(436, 20);
            label12.TabIndex = 4;
            label12.Text = "Veuillez remplir tous les champs avec des données valides";
            label12.Visible = false;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 4;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.9471092F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5461254F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.4071341F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.0996323F));
            tableLayoutPanel9.Controls.Add(textBox1, 1, 0);
            tableLayoutPanel9.Controls.Add(textBox9, 3, 0);
            tableLayoutPanel9.Controls.Add(label1, 0, 0);
            tableLayoutPanel9.Controls.Add(label2, 2, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 114);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(813, 82);
            tableLayoutPanel9.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(92, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(96, 29);
            textBox1.TabIndex = 19;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.None;
            textBox9.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox9.Location = new Point(303, 26);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(507, 29);
            textBox9.TabIndex = 18;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(10, 18);
            label1.Name = "label1";
            label1.Size = new Size(76, 46);
            label1.TabIndex = 22;
            label1.Text = "Budget Max :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(196, 18);
            label2.Name = "label2";
            label2.Size = new Size(101, 46);
            label2.TabIndex = 23;
            label2.Text = "Description Bouquet :";
            // 
            // dataAjoutBouquetPerso
            // 
            dataAjoutBouquetPerso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataAjoutBouquetPerso.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataAjoutBouquetPerso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAjoutBouquetPerso.Dock = DockStyle.Fill;
            dataAjoutBouquetPerso.Location = new Point(3, 202);
            dataAjoutBouquetPerso.Name = "dataAjoutBouquetPerso";
            dataAjoutBouquetPerso.RowHeadersWidth = 51;
            dataAjoutBouquetPerso.RowTemplate.Height = 29;
            dataAjoutBouquetPerso.Size = new Size(813, 260);
            dataAjoutBouquetPerso.TabIndex = 7;
            dataAjoutBouquetPerso.CellBeginEdit += dataAjoutBouquetPerso_CellBeginEdit;
            dataAjoutBouquetPerso.CellValueChanged += dataAjoutBouquetPerso_CellValueChanged;
            dataAjoutBouquetPerso.DataError += dataAjoutBouquetPerso_DataError;
            // 
            // AjoutBouquetPersonnalise
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel5);
            Name = "AjoutBouquetPersonnalise";
            Size = new Size(819, 515);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataAjoutBouquetPerso).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel5;
        private TextBox textBox1;
        private TextBox textBox9;
        private Button button6;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel8;
        private Button Non;
        private Button Ok;
        private Button Oui;
        private Label label1;
        private Label label2;
        private DataGridView dataAjoutBouquetPerso;
    }
}
