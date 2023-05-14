
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
            layoutInterfaceAdmin = new TableLayoutPanel();
            SuspendLayout();
            // 
            // layoutConnection
            // 
            layoutConnection.ColumnCount = 1;
            layoutConnection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutConnection.Dock = DockStyle.Fill;
            layoutConnection.Location = new Point(0, 0);
            layoutConnection.Name = "layoutConnection";
            layoutConnection.RowCount = 1;
            layoutConnection.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutConnection.Size = new Size(882, 523);
            layoutConnection.TabIndex = 0;
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
            layoutChoixBoutiques.Size = new Size(882, 523);
            layoutChoixBoutiques.TabIndex = 1;
            layoutChoixBoutiques.Visible = false;
            // 
            // layoutInterfaceAdmin
            // 
            layoutInterfaceAdmin.ColumnCount = 1;
            layoutInterfaceAdmin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutInterfaceAdmin.Dock = DockStyle.Fill;
            layoutInterfaceAdmin.Location = new Point(0, 0);
            layoutInterfaceAdmin.Name = "layoutInterfaceAdmin";
            layoutInterfaceAdmin.RowCount = 1;
            layoutInterfaceAdmin.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutInterfaceAdmin.Size = new Size(882, 523);
            layoutInterfaceAdmin.TabIndex = 2;
            layoutInterfaceAdmin.Visible = false;
            // 
            // Form1
            // 
            ClientSize = new Size(900, 550);
            Controls.Add(layoutChoixBoutiques);
            Controls.Add(layoutConnection);
            Controls.Add(layoutInterfaceAdmin);
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width-this.Width)/2,(Screen.PrimaryScreen.Bounds.Height-this.Height)/2);
            MinimumSize = new Size(900, 550);
            Name = "Form1";
            ResumeLayout(false);
        }

        private void Connexion()
        {
            //
            // connection
            //
            connection = new fenetreConnection(this);
            Controls.Add(connection);
            connection.Name = "Connection";
            connection.Dock = DockStyle.Fill;
            layoutConnection.Controls.Add(connection, 0, 0);
        }

        private void ChoixBoutique()
        {
            //
            // Choix boutique
            //
            choixBoutique = new ChoixBoutiques(this);
            Controls.Add(choixBoutique);
            choixBoutique.Name = "choixBoutique";
            choixBoutique.Dock = DockStyle.Fill;
            layoutChoixBoutiques.Controls.Add(choixBoutique, 0, 0);
            layoutChoixBoutiques.Hide();
        }

        private void InterfaceAdmin()
        {
            //
            // Interface Adlin
            //
            interfaceAdmin = new InterfaceAdmin(this);
            Controls.Add(interfaceAdmin);
            interfaceAdmin.Name = "interfaceAdmin";
            interfaceAdmin.Dock = DockStyle.Fill;
            layoutInterfaceAdmin.Controls.Add(interfaceAdmin, 0, 0);
            layoutInterfaceAdmin.Hide();
        }

        #endregion
        private TableLayoutPanel layoutConnection;
        private fenetreConnection connection;
        private TableLayoutPanel layoutChoixBoutiques;
        private ChoixBoutiques choixBoutique;
        private TableLayoutPanel layoutInterfaceAdmin;
        private InterfaceAdmin interfaceAdmin;
    }
}