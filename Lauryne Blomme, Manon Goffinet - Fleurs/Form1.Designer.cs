
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            layoutForm1 = new TableLayoutPanel();
            layoutConnexion = new TableLayoutPanel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            layoutForm1.SuspendLayout();
            layoutConnexion.SuspendLayout();
            SuspendLayout();
            // 
            // layoutForm1
            // 
            layoutForm1.BackColor = Color.FromArgb(192, 192, 255);
            layoutForm1.ColumnCount = 3;
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            layoutForm1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            layoutForm1.Controls.Add(layoutConnexion, 1, 1);
            layoutForm1.Controls.Add(label1, 0, 1);
            layoutForm1.Controls.Add(label5, 1, 0);
            layoutForm1.Controls.Add(label6, 2, 1);
            layoutForm1.Controls.Add(label7, 1, 2);
            layoutForm1.Dock = DockStyle.Fill;
            layoutForm1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            layoutForm1.Location = new Point(0, 0);
            layoutForm1.Name = "layoutForm1";
            layoutForm1.RowCount = 3;
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            layoutForm1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutForm1.Size = new Size(800, 450);
            layoutForm1.TabIndex = 4;
            // 
            // layoutConnexion
            // 
            layoutConnexion.BackColor = Color.Transparent;
            layoutConnexion.ColumnCount = 1;
            layoutConnexion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 261F));
            layoutConnexion.Controls.Add(textBox3, 0, 3);
            layoutConnexion.Controls.Add(textBox2, 0, 1);
            layoutConnexion.Controls.Add(label4, 0, 2);
            layoutConnexion.Controls.Add(label3, 0, 0);
            layoutConnexion.Dock = DockStyle.Fill;
            layoutConnexion.Location = new Point(269, 138);
            layoutConnexion.Name = "layoutConnexion";
            layoutConnexion.RowCount = 4;
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layoutConnexion.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            layoutConnexion.Size = new Size(260, 174);
            layoutConnexion.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(3, 132);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(255, 25);
            textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Berlin Sans FB", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(3, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(255, 24);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Berlin Sans FB Demi", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 86);
            label4.Name = "label4";
            label4.Size = new Size(255, 43);
            label4.TabIndex = 3;
            label4.Text = "Mot de passe";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Berlin Sans FB Demi", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(255, 43);
            label3.TabIndex = 1;
            label3.Text = "Nom d'utilisateur";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(163, 176);
            label1.Name = "label1";
            label1.Size = new Size(100, 98);
            label1.TabIndex = 4;
            label1.TextAlign = ContentAlignment.BottomRight;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.BackColor = Color.Transparent;
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.Location = new Point(349, 25);
            label5.Name = "label5";
            label5.Size = new Size(100, 110);
            label5.TabIndex = 6;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.BackColor = Color.Transparent;
            label6.Image = (Image)resources.GetObject("label6.Image");
            label6.Location = new Point(535, 170);
            label6.Name = "label6";
            label6.Size = new Size(100, 109);
            label6.TabIndex = 7;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.BackColor = Color.Transparent;
            label7.Image = (Image)resources.GetObject("label7.Image");
            label7.Location = new Point(347, 315);
            label7.Name = "label7";
            label7.Size = new Size(103, 105);
            label7.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(69, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(60, 25);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Berlin Sans FB Demi", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(69, 0);
            label2.Name = "label2";
            label2.Size = new Size(260, 45);
            label2.TabIndex = 2;
            label2.Text = "Mot de passe";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(layoutForm1);
            Name = "Form1";
            Text = "Fleurie";
            layoutForm1.ResumeLayout(false);
            layoutConnexion.ResumeLayout(false);
            layoutConnexion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel layoutForm1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel;
        private Label label3;
        private TableLayoutPanel layoutConnexion;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}