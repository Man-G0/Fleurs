namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class fenetreConnection
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
            layoutForm1 = new TableLayoutPanel();
            layoutConnexion = new TableLayoutPanel();
            mdp = new TextBox();
            utilisateur = new TextBox();
            labelMdp = new Label();
            labelUtilisateur = new Label();
            boutonConnection = new Button();
            layoutBoutonConnexion = new TableLayoutPanel();
            labelErreurConnection = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            layoutForm1.SuspendLayout();
            layoutConnexion.SuspendLayout();
            layoutBoutonConnexion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // layoutForm1
            // 
            layoutForm1.BackColor = Color.FromArgb(163, 212, 255);
            layoutForm1.ColumnCount = 3;
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714245F));
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.8571434F));
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.57143F));
            layoutForm1.Controls.Add(layoutConnexion, 1, 1);
            layoutForm1.Controls.Add(layoutBoutonConnexion, 1, 2);
            layoutForm1.Controls.Add(pictureBox1, 2, 1);
            layoutForm1.Controls.Add(pictureBox2, 0, 1);
            layoutForm1.Controls.Add(pictureBox3, 1, 0);
            layoutForm1.Dock = DockStyle.Fill;
            layoutForm1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            layoutForm1.Location = new Point(0, 0);
            layoutForm1.Margin = new Padding(3, 4, 3, 4);
            layoutForm1.Name = "layoutForm1";
            layoutForm1.RowCount = 3;
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.8962059F));
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4968834F));
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 31.6069145F));
            layoutForm1.Size = new Size(879, 559);
            layoutForm1.TabIndex = 4;
            // 
            // layoutConnexion
            // 
            layoutConnexion.BackColor = Color.Transparent;
            layoutConnexion.ColumnCount = 1;
            layoutConnexion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutConnexion.Controls.Add(mdp, 0, 3);
            layoutConnexion.Controls.Add(utilisateur, 0, 1);
            layoutConnexion.Controls.Add(labelMdp, 0, 2);
            layoutConnexion.Controls.Add(labelUtilisateur, 0, 0);
            layoutConnexion.Controls.Add(boutonConnection, 0, 4);
            layoutConnexion.Dock = DockStyle.Fill;
            layoutConnexion.Location = new Point(254, 137);
            layoutConnexion.Margin = new Padding(3, 4, 3, 4);
            layoutConnexion.Name = "layoutConnexion";
            layoutConnexion.RowCount = 5;
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0476189F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0476189F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0476189F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 19.0476189F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 23.8095245F));
            layoutConnexion.Size = new Size(370, 240);
            layoutConnexion.TabIndex = 5;
            // 
            // mdp
            // 
            mdp.Dock = DockStyle.Fill;
            mdp.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mdp.Location = new Point(3, 139);
            mdp.Margin = new Padding(3, 4, 3, 4);
            mdp.Name = "mdp";
            mdp.Size = new Size(364, 29);
            mdp.TabIndex = 5;
            // 
            // utilisateur
            // 
            utilisateur.Dock = DockStyle.Fill;
            utilisateur.Font = new Font("Berlin Sans FB", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            utilisateur.Location = new Point(3, 49);
            utilisateur.Margin = new Padding(3, 4, 3, 4);
            utilisateur.Name = "utilisateur";
            utilisateur.Size = new Size(364, 28);
            utilisateur.TabIndex = 4;
            // 
            // labelMdp
            // 
            labelMdp.AutoSize = true;
            labelMdp.Dock = DockStyle.Fill;
            labelMdp.Font = new Font("Berlin Sans FB Demi", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMdp.Location = new Point(3, 90);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(364, 45);
            labelMdp.TabIndex = 3;
            labelMdp.Text = "Mot de passe";
            labelMdp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelUtilisateur
            // 
            labelUtilisateur.AutoSize = true;
            labelUtilisateur.Dock = DockStyle.Fill;
            labelUtilisateur.Font = new Font("Berlin Sans FB Demi", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelUtilisateur.Location = new Point(3, 0);
            labelUtilisateur.Name = "labelUtilisateur";
            labelUtilisateur.Size = new Size(364, 45);
            labelUtilisateur.TabIndex = 1;
            labelUtilisateur.Text = "Nom d'utilisateur";
            labelUtilisateur.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // boutonConnection
            // 
            boutonConnection.BackColor = Color.FromArgb(255, 168, 173);
            boutonConnection.Dock = DockStyle.Fill;
            boutonConnection.Font = new Font("Berlin Sans FB Demi", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            boutonConnection.Location = new Point(3, 183);
            boutonConnection.Name = "boutonConnection";
            boutonConnection.Size = new Size(364, 54);
            boutonConnection.TabIndex = 10;
            boutonConnection.Text = "Connection";
            boutonConnection.UseVisualStyleBackColor = false;
            boutonConnection.Click += boutonConnection_Click;
            // 
            // layoutBoutonConnexion
            // 
            layoutBoutonConnexion.ColumnCount = 1;
            layoutBoutonConnexion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBoutonConnexion.Controls.Add(labelErreurConnection, 0, 0);
            layoutBoutonConnexion.Dock = DockStyle.Fill;
            layoutBoutonConnexion.Location = new Point(254, 384);
            layoutBoutonConnexion.Name = "layoutBoutonConnexion";
            layoutBoutonConnexion.RowCount = 2;
            layoutBoutonConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutBoutonConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layoutBoutonConnexion.Size = new Size(370, 172);
            layoutBoutonConnexion.TabIndex = 9;
            // 
            // labelErreurConnection
            // 
            labelErreurConnection.Anchor = AnchorStyles.None;
            labelErreurConnection.AutoSize = true;
            labelErreurConnection.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelErreurConnection.ForeColor = Color.FromArgb(192, 0, 0);
            labelErreurConnection.Location = new Point(163, 14);
            labelErreurConnection.Name = "labelErreurConnection";
            labelErreurConnection.Size = new Size(44, 23);
            labelErreurConnection.TabIndex = 9;
            labelErreurConnection.Text = "root";
            labelErreurConnection.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.BackgroundImage = Properties.Resources.flowersPot;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Location = new Point(630, 207);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.FlowerPot;
            pictureBox2.Location = new Point(148, 207);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom;
            pictureBox3.Image = Properties.Resources.wateringCan;
            pictureBox3.Location = new Point(389, 30);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 100);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // fenetreConnection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(192, 192, 255);
            Controls.Add(layoutForm1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(800, 500);
            Name = "fenetreConnection";
            Size = new Size(879, 559);
            layoutForm1.ResumeLayout(false);
            layoutForm1.PerformLayout();
            layoutConnexion.ResumeLayout(false);
            layoutConnexion.PerformLayout();
            layoutBoutonConnexion.ResumeLayout(false);
            layoutBoutonConnexion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel layoutForm1;
        private Label labelUtilisateur;
        private TableLayoutPanel layoutConnexion;
        private TextBox mdp;
        private TextBox utilisateur;
        private Label labelMdp;
        private TableLayoutPanel layoutBoutonConnexion;
        private Button boutonConnection;
        private Label labelErreurConnection;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
