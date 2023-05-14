using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.LinkLabel;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class AjoutStock : UserControl
    {
        Form1 form1;
        Ajout ajout;
        public AjoutStock(Form1 form1, Ajout ajout)
        {
            InitializeComponent();
            this.form1 = form1;
            StockData();
            this.ajout = ajout;
        }
        public void StockData()
        {
            string strcommand = "SELECT idMagasin from magasin;";
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count];

            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i] = valeur[i];
            }
            comboBox1.Items.AddRange(temp);
            comboBox1.SelectedItem = temp[0];
            reader.Close();

            /*Pour la combo box du choix produit : remplissage des données avec les différents produits*/

            strcommand = "SELECT libelle_prod from produit;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }
            temp = new object[valeur.Count];
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i] = valeur[i];
            }
            comboBox2.Items.AddRange(temp);
            reader.Close();
            comboBox2.SelectedIndex = 0;

            //Pour la date :
            dateTimePicker1.Value = DateTime.Today;

        }



        private void Oui_Click(object sender, EventArgs e)
        {
            label4.Hide();
            string command = "";
            string magasin = comboBox1.SelectedItem.ToString();
            string produit = comboBox2.SelectedItem.ToString();
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int quantite = Convert.ToInt32(numericUpDown1.Value.ToString());
            command = $"SELECT count(*) FROM stock WHERE idMagasin = '{magasin}' AND idProduit = (SELECT idProduit FROM produit WHERE libelle_prod = '{produit}');";

            int verifDansDB = -1;

            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
            verifDansDB = Convert.ToInt32(commandSQL.ExecuteScalar());
            form1.ConnectionSQL.Close();

            if (verifDansDB == 0)
            {
                label4.Show();
                command = $"INSERT INTO stock(idMagasin,idProduit,quantite,date) VALUES ('{magasin}', (SELECT idProduit FROM produit WHERE libelle_prod = '{produit}'),{quantite},'{date}');";
                form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                label4.Text = "La ligne a été ajouté";
                label4.ForeColor = Color.FromArgb(152, 186, 92);
                Ok.Show();
                Non.Hide();
                Oui.Hide();
            }
            else
            {
                label4.Text = "Attention, ce stock existe déjà dans la base de données !";
                label4.ForeColor = Color.FromArgb(192, 0, 0);
                label4.Show();
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
