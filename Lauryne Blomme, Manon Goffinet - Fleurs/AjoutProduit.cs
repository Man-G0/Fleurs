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

    public partial class AjoutProduit : UserControl
    {
        Form1 form1;
        Ajout ajout;
        public AjoutProduit(Form1 form1, Ajout ajout)
        {
            this.form1 = form1;
            this.ajout = ajout;
            InitializeComponent();
            StockProduit();

        }
        public void StockProduit()
        {
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }


            /*Pour la combo box du type : remplissage des données avec les types de produits*/

            string strcommand = "SELECT distinct type from produit;";
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
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(temp);
            reader.Close();
            comboBox2.SelectedIndex = 0;

            form1.ConnectionSQL.Close();

            //Pour la date :
            dateTimePicker1.Value = DateTime.Today;
        }

        private void Non_Click(object sender, EventArgs e)
        {
            ajout.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            ajout.Close();
        }

        private void Oui_Click(object sender, EventArgs e)
        {
            string nom = textBox2.Text;
            string type = comboBox5.Text;
            double tarifVente = (double)numericUpDown14.Value;
            string date = dateTimePicker5.Value.ToString("yyyy-MM-dd");
            int moisDebutDispo = (int)numericUpDown12.Value;
            int moisFinDispo = (int)numericUpDown13.Value;

            bool debutAvFin = (moisDebutDispo <= moisFinDispo);
            bool tarifPas0 = (tarifVente != 0);
            bool nomPasnull = (nom != null && nom != "");
            string command = "";

            if (nomPasnull && tarifPas0 && debutAvFin)
            {
                command = $"SELECT count(idProduit) FROM produit;";

                int pk = -1;

                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                pk = Convert.ToInt32(commandSQL.ExecuteScalar());
                form1.ConnectionSQL.Close();



                int n = pk + 1;
                string newPk = 'p' + Convert.ToString(n);
                bool newPkExiste = true;
                int count = -1;
                while (newPkExiste == true)
                {
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    command = $"SELECT count(idProduit) FROM produit WHERE idProduit = '{newPk}';";
                    commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    count = Convert.ToInt32(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();

                    if (count == 0)
                    {
                        newPkExiste = false;
                    }
                    else
                    {
                        n++;
                        newPk = 'p' + Convert.ToString(n);
                    }
                }
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }

                command = $"INSERT INTO produit(idProduit,libelle_prod,type,tarif_vente_unitaire,date_majoration_tarif,mois_debut_dispo,mois_fin_dispo) " +
                    $"VALUES ('{newPk}', '{nom}','{type}',{tarifVente},'{date}',{moisDebutDispo},{moisFinDispo});";
                form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

                label4.Text = "Le produit a été ajouté";
                label4.ForeColor = Color.FromArgb(152, 186, 92);
                label4.Visible = true;

                Ok.Show();
                Non.Hide();
                Oui.Hide();
            }
            else
            {
                label4.Text = "Veuillez remplir tous les champs avec des données valides";
                label4.ForeColor = Color.FromArgb(192, 0, 0);
                label4.Show();
            }

        }

       
    }

}
