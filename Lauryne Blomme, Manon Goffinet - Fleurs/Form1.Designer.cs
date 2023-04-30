
using System.Windows.Forms;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutConnection = new TableLayoutPanel();
            layoutChoixBoutiques = new TableLayoutPanel();
            connection = new fenetreConnection(this);
            choixBoutique = new ChoixBoutiques(this);
            SuspendLayout();
            //
            // connection
            //
            connection.AutoSize = true;
            connection.Dock = DockStyle.Fill;
            connection.Location = new Point(0, 0);
            connection.Name = "connection";
            // 
            // layoutConnection
            // 
            layoutConnection.ColumnCount = 1;
            layoutConnection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutConnection.Dock = DockStyle.Fill;
            layoutConnection.Location = new Point(0, 0);
            layoutConnection.Name = "layoutConnection";
            layoutConnection.Controls.Add(connection);
            layoutConnection.RowCount = 1;
            layoutConnection.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutConnection.Size = new Size(1017, 538);
            layoutConnection.TabIndex = 0;

            //
            // choix boutique
            //
            choixBoutique.AutoSize = true;
            choixBoutique.Dock = DockStyle.Fill;
            choixBoutique.Location = new Point(0, 0);
            choixBoutique.Name = "choixBoutique";
            // 
            // layoutChoixBoutiques
            // 
            layoutChoixBoutiques.BackColor = Color.Transparent;
            layoutChoixBoutiques.ColumnCount = 1;
            layoutChoixBoutiques.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutChoixBoutiques.Dock = DockStyle.Fill;
            layoutChoixBoutiques.Location = new Point(0, 0);
            layoutChoixBoutiques.Name = "layoutChoixBoutiques";
            layoutChoixBoutiques.RowCount = 1;
            layoutChoixBoutiques.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutChoixBoutiques.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutChoixBoutiques.Size = new Size(850, 500);
            layoutChoixBoutiques.Controls.Add(choixBoutique);
            layoutChoixBoutiques.TabIndex = 1;
            layoutChoixBoutiques.Visible = false;


            // 
            // Form1
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(layoutChoixBoutiques);
            Controls.Add(layoutConnection);
            MinimumSize = new Size(800, 500);
            Name = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel layoutConnection;
        private fenetreConnection connection;
        private TableLayoutPanel layoutChoixBoutiques;
        private ChoixBoutiques choixBoutique;
    }
}