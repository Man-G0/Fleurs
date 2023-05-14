namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    partial class Suppression
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Non = new Button();
            Oui = new Button();
            Ok = new Button();
            SupressionTexBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(SupressionTexBox, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.61905F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.38095F));
            tableLayoutPanel1.Size = new Size(315, 167);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.0952377F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.8095245F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.0952377F));
            tableLayoutPanel2.Controls.Add(Non, 2, 0);
            tableLayoutPanel2.Controls.Add(Oui, 0, 0);
            tableLayoutPanel2.Controls.Add(Ok, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 82);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(309, 82);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // Non
            // 
            Non.Anchor = AnchorStyles.Left;
            Non.BackColor = Color.FromArgb(255, 168, 173);
            Non.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            Non.Location = new Point(193, 16);
            Non.Name = "Non";
            Non.Size = new Size(96, 46);
            Non.TabIndex = 1;
            Non.Text = "Non";
            Non.UseVisualStyleBackColor = false;
            Non.Click += Non_Click;
            // 
            // Oui
            // 
            Oui.Anchor = AnchorStyles.Right;
            Oui.BackColor = Color.FromArgb(255, 168, 173);
            Oui.Font = new Font("Berlin Sans FB", 11.8F, FontStyle.Regular, GraphicsUnit.Point);
            Oui.Location = new Point(12, 16);
            Oui.Name = "Oui";
            Oui.Size = new Size(102, 46);
            Oui.TabIndex = 0;
            Oui.Text = "Oui";
            Oui.UseVisualStyleBackColor = false;
            Oui.Click += Oui_Click;
            // 
            // Ok
            // 
            Ok.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Ok.BackColor = Color.FromArgb(255, 168, 173);
            Ok.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            Ok.Location = new Point(120, 18);
            Ok.Name = "Ok";
            Ok.Size = new Size(67, 42);
            Ok.TabIndex = 2;
            Ok.Text = "Ok";
            Ok.UseVisualStyleBackColor = false;
            Ok.Visible = false;
            Ok.Click += Ok_Click;
            // 
            // SupressionTexBox
            // 
            SupressionTexBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SupressionTexBox.BackColor = Color.FromArgb(163, 212, 255);
            SupressionTexBox.BorderStyle = BorderStyle.None;
            SupressionTexBox.Font = new Font("Berlin Sans FB", 13.5F, FontStyle.Regular, GraphicsUnit.Point);
            SupressionTexBox.Location = new Point(3, 30);
            SupressionTexBox.Multiline = true;
            SupressionTexBox.Name = "SupressionTexBox";
            SupressionTexBox.Size = new Size(309, 46);
            SupressionTexBox.TabIndex = 2;
            SupressionTexBox.Text = "Supprimer de manière définitive la ligne ?";
            SupressionTexBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Suppression
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(163, 212, 255);
            ClientSize = new Size(315, 167);
            Controls.Add(tableLayoutPanel1);
            Name = "Suppression";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suppression";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox SupressionTexBox;
        private Button Non;
        private Button Oui;
        private Button Ok;
    }
}