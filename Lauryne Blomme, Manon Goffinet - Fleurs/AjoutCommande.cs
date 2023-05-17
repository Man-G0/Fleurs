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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class AjoutCommande : UserControl
    {
        Form1 form1;
        Ajout ajout;
        public AjoutCommande(Form1 form1, Ajout ajout)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ajout = ajout;
            dateTimePicker1.MinDate = DateTime.Today;
            CommandeData();
        }

        public void CommandeData()
        {
            string strcommand = "SELECT idMagasin from magasin;";
            form1.ConnectionSQL.Close();
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
            comboBox2.Items.AddRange(temp);
            comboBox2.SelectedIndex = 0;
            reader.Close();

            /*Pour la combo box du choix bouquet : remplissage des données avec les différents bouquet*/
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            strcommand = "SELECT idBouquetStandard from bouquet_standard;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }
            reader.Close();


            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            strcommand = "SELECT idBouquetPerso from bouquet_personnalise;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            reader = command.ExecuteReader();

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); 

            }
            reader.Close();


            temp = new object[valeur.Count];
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i] = valeur[i];
            }
            comboBox1.Items.AddRange(temp);
            
            comboBox1.SelectedIndex = 0;

            //Pour la date :
            dateTimePicker1.Value = DateTime.Today;
            form1.ConnectionSQL.Close();

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
            string adresseLivraison = textBox7.Text;
            string dateLivraison = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string message = textBox9.Text;
            string dateCommande = DateTime.Now.ToString("yyyy-MM-dd");
            float prixTtc = 0;// a faire appliquer les réduc en fonction du mail.
            string descBouquet = ""; // c'est le type de bouquet
            string email = textBox1.Text; // a partir de l'email, retrouver l'id client 
            string codeEtat = ""; // A VOIR EN FONCTION DE LA DATE ET DU TYPE DE BOUQUET
            string magasin = comboBox2.Text;
            string idBouquet = comboBox1.Text;

            //idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB,idClient,codeEtat,idMagasin,idBouquetStandard,idBouquetPerso;
            bool notnull = !string.IsNullOrEmpty(adresseLivraison) &&
                                  !string.IsNullOrEmpty(message) &&
                                  !string.IsNullOrEmpty(email) &&
                                  !string.IsNullOrEmpty(magasin) &&
                                  !string.IsNullOrEmpty(idBouquet);

            TimeSpan a = dateTimePicker1.Value - DateTime.Now; // verifie si la livraison n'est pas demandé dans les trois jours 

            if (notnull)
            {
                if (form1.UtilisateurMotdePasse.ContainsKey(email)) // verifie si la livraison n'est pas demandé dans le passé
                {

                    string command = $"SELECT idCommande FROM commande ORDER BY idCommande DESC LIMIT 1;";

                    int pk = -1;
                    form1.ConnectionSQL.Close();
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    pk = Convert.ToInt32(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();



                    int newPk = pk + 1;

                    bool newPkExiste = true;
                    int count = -1;
                    while (newPkExiste == true)
                    {
                        if (form1.ConnectionSQL.State.ToString() != "Open")
                        {
                            form1.ConnectionSQL.Open();
                        }
                        command = $"SELECT count(*) FROM commande WHERE idCommande = {newPk};";
                        commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                        count = Convert.ToInt32(commandSQL.ExecuteScalar());
                        form1.ConnectionSQL.Close();

                        if (count == 0)
                        {
                            newPkExiste = false;
                        }
                        else
                        {
                            newPk++;
                        }
                    }

                    form1.ConnectionSQL.Close();
                    command = $"SELECT idClient FROM client WHERE email ='{email}';";
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    string idClient = Convert.ToString(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();


                    form1.ConnectionSQL.Close();
                    command = $"SELECT reduction FROM statut WHERE codeStatut = (SELECT codeStatut FROM client WHERE idCLient ='{idClient}' );";
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    int reduction = Convert.ToInt32(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();



                    if (idBouquet[1] == 's')
                    {
                        command = $"SELECT prixBS FROM bouquet_standard WHERE idBouquetStandard = '{idBouquet}';";
                        descBouquet = "bouquet standard";
                    }
                    else if (idBouquet[1] == 'p')
                    {
                        command = $"SELECT budgetMax FROM bouquet_personnalise WHERE idBouquetPerso = '{idBouquet}';";
                        descBouquet = "bouquet perso";
                    }

                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                    float prixB = Convert.ToInt32(commandSQL.ExecuteScalar());
                    form1.ConnectionSQL.Close();

                    prixTtc = prixB - prixB * reduction / 100;

                    label12.Text = "La commande a été ajouté";

                    if (a.TotalDays > 3 && descBouquet == "bouquet standard")
                    {
                        codeEtat = "CC";
                        label12.Text = "La commande a été ajouté";
                    }
                    else if (a.TotalDays < 3 && descBouquet == "bouquet standard")
                    {
                        codeEtat = "VINV";
                        label12.Text = "Au vu du délai de livraison très court, nous ne garantissons pas la livraison a la date demandée.";
                    }
                    else if (descBouquet == "bouquet perso")
                    {
                        codeEtat = "CPAV";
                        label12.Text = "Votre commande est passée ! Prise en charge de la commande dans la limite des stocks disponibles !";
                    }

                    form1.ConnectionSQL.Close();
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }

                    if(descBouquet == "bouquet standard")
                    {
                        command = $"INSERT INTO commande(idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB,idClient,codeEtat,idMagasin,idBouquetStandard,idBouquetPerso) " +
                        $"VALUES ({newPk}, '{adresseLivraison}','{dateLivraison}','{message}','{dateCommande}',{prixTtc},'{descBouquet}','{idClient}', '{codeEtat}','{magasin}','{idBouquet}',NULLIF('',''));";
                    }
                    else
                    {
                        command = $"INSERT INTO commande(idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB,idClient,codeEtat,idMagasin,idBouquetStandard,idBouquetPerso) " +
                         //$"VALUES (100, '10 rue','2023-04-04',' loha','2023-04-04',110,'bouquet perso','c1', 'or','m1',NULLIF('',''),'bp2');";
                        $"VALUES ({newPk}, '{adresseLivraison}','{dateLivraison}','{message}','{dateCommande}',{prixTtc},'{descBouquet}','{idClient}', '{codeEtat}','{magasin}',NULLIF('',''),'{idBouquet}');";
                    }
                    
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

                    
                    label12.ForeColor = Color.FromArgb(152, 186, 92);
                    label12.Visible = true;

                    Ok.Show();
                    Non.Hide();
                    Oui.Hide();
                }
                else
                {
                    label12.Text = "L'email n'est pas dans la base de données";
                    
                    label12.ForeColor = Color.FromArgb(192, 0, 0);
                    label12.Show();
                }

            }
            else
            {
                label12.Text = "Veuillez entrer des données valides dans toutes les cases";
                label12.ForeColor = Color.FromArgb(192, 0, 0);
                label12.Show();
            }

        }
    }
}
