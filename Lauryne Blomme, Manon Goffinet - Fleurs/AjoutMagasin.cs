using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class AjoutMagasin : UserControl
    {
        Ajout ajout;
        Form1 form1;
        public AjoutMagasin( Form1 form1, Ajout ajout)
        {
            InitializeComponent();
            this.ajout = ajout;
            this.form1 = form1;
        }

        private void Oui_Click(object sender, EventArgs e)
        {
            label3.Hide();
            string nom = textBox1.Text;
            string command = "";
            if (nom!=null)
            {
                command = $"SELECT idMagasin FROM magasin" +
                        $"\r\nORDER BY idMagasin DESC\r\n" +
                        $"LIMIT 1;";
                string pk = "";

                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                pk = Convert.ToString(commandSQL.ExecuteScalar());
                form1.ConnectionSQL.Close();
                string temp = "";
                for (int i =1; i < pk.Length; i++)
                {
                    temp += pk[i];
                }

                int n = Convert.ToInt32(temp)+1;
                string newPk = 'm' + Convert.ToString(n);

                label3.Show();
                command = $"INSERT INTO magasin(idMagasin,nom) VALUES ('{newPk}', '{nom}');";
                form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                label3.Text = "La ligne a été ajouté";
                label3.ForeColor = Color.FromArgb(152, 186, 92);
                Ok.Show();
                Non.Hide();
                Oui.Hide();



            }
            else
            {
                label3.Text = "Le nom est vide";
                label3.ForeColor = Color.FromArgb(192, 0, 0);
                label3.Show();
            }




        }

        private void Non_Click(object sender, EventArgs e)
        {
            ajout.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            ajout.Close();
        }
    }
}
