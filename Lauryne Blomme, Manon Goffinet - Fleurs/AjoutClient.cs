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
    public partial class AjoutClient : UserControl
    {
        Form1 form1;
        Ajout ajout;
        public AjoutClient(Form1 form1, Ajout ajout)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ajout = ajout;
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
            string nom = textBox11.Text;
            string prenom = textBox12.Text;
            string email = textBox1.Text;
            string telephone = textBox10.Text;
            string mdp = textBox9.Text;
            string adresse = textBox7.Text;
            string carte = textBox8.Text;

            bool notnull = (!string.IsNullOrEmpty(nom) && !string.IsNullOrWhiteSpace(nom)) &&
                (!string.IsNullOrEmpty(prenom) && !string.IsNullOrWhiteSpace(prenom)) &&
                (!string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email)) &&
                (!string.IsNullOrEmpty(mdp) && !string.IsNullOrWhiteSpace(mdp)) &&
                (!string.IsNullOrEmpty(adresse) && !string.IsNullOrWhiteSpace(adresse)) &&
                (!string.IsNullOrEmpty(carte) && !string.IsNullOrWhiteSpace(carte)) &&
                (carte.Length == 16);

            if (notnull)
            {
                if (!form1.UtilisateurMotdePasse.ContainsKey(email))
                {
                    string command = $"SELECT count(idClient) FROM client;";

                    int pk = -1;
                    form1.ConnectionSQL.Close();
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    pk = Convert.ToInt32(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();



                    int n = pk + 1;
                    string newPk = 'c' + Convert.ToString(n);
                    bool newPkExiste = true;
                    int count = -1;
                    while (newPkExiste == true)
                    {
                        if (form1.ConnectionSQL.State.ToString() != "Open")
                        {
                            form1.ConnectionSQL.Open();
                        }
                        command = $"SELECT count(idClient) FROM client WHERE idClient = '{newPk}';";
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
                            newPk = 'c' + Convert.ToString(n);
                        }
                    }
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }

                    command = $"INSERT INTO client(idClient, nomC,prenomC,telephone,email,motDePasse,adresse,carteDeCredit,codeStatut) " +
                        $"VALUES ('{newPk}', '{nom}','{prenom}','{telephone}','{email}','{mdp}','{adresse}','{carte}', 'aucun');";
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

                    label12.Text = "Le client a été ajouté";
                    label12.ForeColor = Color.FromArgb(152, 186, 92);
                    label12.Visible = true;

                    Ok.Show();
                    Non.Hide();
                    Oui.Hide();
                }
                else
                {
                    label12.Text = "l'email donné existe déjà dans la base de donnée";
                    label12.ForeColor = Color.FromArgb(192, 0, 0);
                    label12.Show();
                }
                
            }
            else
            {
                label12.Text = "Veuillez remplir tous les champs avec des données valides";
                label12.ForeColor = Color.FromArgb(192, 0, 0);
                label12.Show();
            }

        }
    }
}
