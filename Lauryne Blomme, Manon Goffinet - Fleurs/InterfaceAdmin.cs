using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class InterfaceAdmin : UserControl
    {
        Form1 form1;
        public InterfaceAdmin(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            BoutiqueDataConnection();
            ProduitDataConnection();
            StockDataConnection();
            BouquetStandardDataConnection();
            BouquetPersonnaliseDataConnection();
            ClientDataConnection();
            CommandeDataConnection();
            EtatConnection();
        }


        private void Statistique()
        {

        }
        private void EtatConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "SELECT * FROM etat;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataEtat.DataSource = dataTable;
            dataEtat.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            form1.ConnectionSQL.Close();
        }
        private void CommandeDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }

            string strcommand = "SELECT idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB AS 'desc Bouquet',idClient,codeEtat,idMagasin FROM commande;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataTable.Columns.Add("idBouquet", typeof(string));
            MySqlDataReader reader;
            List<string> valeur;
            List<string> fleurs;
            form1.ConnectionSQL.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                string compo = "";
                form1.ConnectionSQL.Open();

                strcommand = $"SELECT idBouquetStandard, idBouquetPerso FROM commande" +
                    $" WHERE idCommande = {row[0]};"; ;
                command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                reader = command.ExecuteReader();
                valeur = new List<string> { };
                while (reader.Read())   // parcours ligne par ligne
                {

                    if (!reader.IsDBNull(1))
                    {
                        valeur.Add(reader.GetString(1));
                    }
                    else if (!reader.IsDBNull(0))
                    {
                        valeur.Add(reader.GetString(0));
                    }


                }


                row["idBouquet"] = valeur[0];
                form1.ConnectionSQL.Close();
            }
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            dataCommandes.DataSource = dataTable;
            dataCommandes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            /*Pour la combo box du choix magasins : remplissage des données avec les magasins*/

            strcommand = "SELECT idMagasin from magasin;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);


            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count + 1];
            temp[0] = "général";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox12.Items.Clear();
            toolStripComboBox12.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox12.SelectedIndex = 0;


            /*Pour la combo box du choix produit : remplissage des données avec les différents produits*/
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            strcommand = "SELECT codeEtat from etat;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }
            temp = new object[valeur.Count + 1];
            temp[0] = "Tout état";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox13.Items.Clear();

            toolStripComboBox13.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox13.SelectedIndex = 0;

            form1.ConnectionSQL.Close();
        }
        private void ClientDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "SELECT idClient, nomC, prenomC, telephone, email, motDePasse, adresse, carteDeCredit, client.codeStatut as 'niveau fidelité', reduction AS '% réduction' FROM client " +
                "INNER JOIN statut ON statut.codeStatut = client.codeStatut;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataClients.DataSource = dataTable;
            dataClients.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            /*Pour la combo box du type : remplissage des données */

            strcommand = "SELECT codeStatut FROM statut;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            form1.ConnectionSQL.Close();
            form1.ConnectionSQL.Open();

            MySqlDataReader reader = command.ExecuteReader();
            List<string> valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count + 1];
            temp[0] = "Tout statut";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox3.Items.Clear();
            toolStripComboBox3.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox3.SelectedIndex = 0;

            form1.ConnectionSQL.Close();
        }
        private void BouquetStandardDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "SELECT idBouquetStandard, nomStandard, prixBS, margeBS, bouquet_standard.idOccasion, description AS 'Description Occasion' FROM bouquet_standard " +
                    "INNER JOIN occasion ON bouquet_standard.idOccasion= occasion.idOccasion;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            dataTable.Columns.Add("Composition Bouquet", typeof(string));
            MySqlDataReader reader;
            List<string> valeur;
            List<string> fleurs;
            form1.ConnectionSQL.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                string compo = "";
                form1.ConnectionSQL.Open();

                strcommand = $"SELECT quantiteS, libelle_prod FROM compose_b_s" +
                    $" INNER JOIN produit ON compose_b_s.idProduit=produit.idProduit" +
                    $" WHERE idBouquetStandard = '{row[0]}';"; ;
                command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                reader = command.ExecuteReader();
                valeur = new List<string> { };
                fleurs = new List<string>();
                while (reader.Read())   // parcours ligne par ligne
                {

                    valeur.Add(reader.GetString(0));
                    fleurs.Add(reader.GetString(1));

                }

                for (int i = 0; i < valeur.Count; i++)
                {
                    compo += valeur[i] + " " + fleurs[i] + "; ";
                }

                row["Composition Bouquet"] = compo;
                form1.ConnectionSQL.Close();
            }

            dataBouquetStandard.DataSource = dataTable;
            dataBouquetStandard.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            /*Pour la combo box du type : remplissage des données */

            strcommand = "SELECT distinct idOccasion FROM occasion;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            form1.ConnectionSQL.Close();
            form1.ConnectionSQL.Open();

            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count + 1];
            temp[0] = "Tout";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox14.Items.Clear();
            toolStripComboBox14.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox14.SelectedIndex = 0;

            form1.ConnectionSQL.Close();
        }

        private void BouquetPersonnaliseDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "SELECT idBouquetPerso, budgetMax, descriptionBP, margeBP FROM bouquet_personnalise;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            dataTable.Columns.Add("Composition Bouquet", typeof(string));
            MySqlDataReader reader;
            List<string> valeur;
            List<string> fleurs;
            form1.ConnectionSQL.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                string compo = "";
                form1.ConnectionSQL.Open();

                strcommand = $"SELECT quantiteP, libelle_prod FROM compose_b_p" +
                    $" INNER JOIN produit ON compose_b_p.idProduit=produit.idProduit" +
                    $" WHERE idBouquetPerso = '{row[0]}';"; ;
                command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                reader = command.ExecuteReader();
                valeur = new List<string> { };
                fleurs = new List<string>();
                while (reader.Read())   // parcours ligne par ligne
                {

                    valeur.Add(reader.GetString(0));
                    fleurs.Add(reader.GetString(1));

                }

                for (int i = 0; i < valeur.Count; i++)
                {
                    compo += valeur[i] + " " + fleurs[i] + "; ";
                }

                row["Composition Bouquet"] = compo;
                form1.ConnectionSQL.Close();
            }

            dataBouquetPerso.DataSource = dataTable;
            dataBouquetPerso.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            form1.ConnectionSQL.Close();

        }
        private void BoutiqueDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "Select * from magasin;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DataBoutique.DataSource = dataTable;
            form1.ConnectionSQL.Close();
        }
        private void ProduitDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "Select * from produit;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataProduit.DataSource = dataTable;

            /*Pour la combo box du type : remplissage des données avec les types de produits*/

            strcommand = "SELECT distinct type from produit;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count + 1];
            temp[0] = "Tous types";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox17.Items.Clear();
            toolStripComboBox17.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox17.SelectedItem = "Tous types";

            form1.ConnectionSQL.Close();
        }
        private void StockDataConnection()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "SELECT stock.idMagasin as Magasin, produit.libelle_prod as libelle,produit.type, stock.quantite, stock.date as 'Date Stock' FROM stock " +
                                "INNER JOIN magasin ON magasin.idMagasin = stock.idMagasin " +
                                "INNER JOIN produit ON produit.idProduit = stock.idProduit;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataStock.DataSource = dataTable;

            /*Pour la combo box du choix magasins : remplissage des données avec les magasins*/

            strcommand = "SELECT idMagasin from magasin;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }

            object[] temp = new object[valeur.Count + 1];
            temp[0] = "Stock général";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox1.Items.Clear();
            toolStripComboBox1.Items.AddRange(temp);
            toolStripComboBox1.SelectedItem = "Stock général";
            reader.Close();
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }

            /*Pour la combo box du choix produit : remplissage des données avec les différents produits*/

            strcommand = "SELECT libelle_prod from produit;";
            command = new MySqlCommand(strcommand, form1.ConnectionSQL);

            reader = command.ExecuteReader();
            valeur = new List<string> { };

            while (reader.Read())   // parcours ligne par ligne
            {

                valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

            }
            temp = new object[valeur.Count + 1];
            temp[0] = "Tous les produits";
            for (int i = 0; i < valeur.Count; i++)
            {
                temp[i + 1] = valeur[i];
            }
            toolStripComboBox2.Items.Clear();

            toolStripComboBox2.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox2.SelectedItem = "Tous les produits";

            form1.ConnectionSQL.Close();
        }


        private void UpdateCommande()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "";
            if (toolStripComboBox12.Text == "général" && toolStripComboBox13.Text == "Tout état")
            {
                strcommand = "SELECT idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB AS 'desc Bouquet',idClient,codeEtat,idMagasin FROM commande;";
            }
            else if (toolStripComboBox12.Text == "général" && toolStripComboBox13.Text != "Tout état")
            {
                strcommand = "SELECT idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB AS 'desc Bouquet',idClient,codeEtat,idMagasin FROM commande" +
                    $" WHERE codeEtat = '{toolStripComboBox13.Text}';";
            }
            else if (toolStripComboBox12.Text != "général" && toolStripComboBox13.Text == "Tout état")
            {
                strcommand = "SELECT idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB AS 'desc Bouquet',idClient,codeEtat,idMagasin FROM commande" +
                    $" WHERE idMagasin = '{toolStripComboBox12.Text}';";
            }
            else
            {
                strcommand = "SELECT idCommande,adresseLivraison,dateLivraison,message,dateCommande,prixTTC,descriptionB AS 'desc Bouquet',idClient,codeEtat,idMagasin FROM commande" +
                    $" WHERE codeEtat = '{toolStripComboBox13.Text}'" +
                    $" AND idMagasin = '{toolStripComboBox12.Text}';";
            }

            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataTable.Columns.Add("idBouquet", typeof(string));
            MySqlDataReader reader;
            List<string> valeur;
            List<string> fleurs;
            form1.ConnectionSQL.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                string compo = "";
                form1.ConnectionSQL.Open();

                strcommand = $"SELECT idBouquetStandard, idBouquetPerso FROM commande" +
                    $" WHERE idCommande = {row[0]};"; ;
                command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                reader = command.ExecuteReader();
                valeur = new List<string> { };
                while (reader.Read())   // parcours ligne par ligne
                {

                    if (!reader.IsDBNull(1))
                    {
                        valeur.Add(reader.GetString(1));
                    }
                    else if (!reader.IsDBNull(0))
                    {
                        valeur.Add(reader.GetString(0));
                    }


                }


                row["idBouquet"] = valeur[0];
                form1.ConnectionSQL.Close();
            }

            dataCommandes.DataSource = dataTable;
            form1.ConnectionSQL.Close();
        }
        private void UpdateClient()
        {

            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }

            string strcommand = "";
            if (toolStripComboBox3.Text == "Tout statut")
            {
                strcommand = "SELECT idClient, nomC, prenomC, telephone, email, motDePasse, adresse, carteDeCredit, client.codeStatut as 'niveau fidelité', reduction AS '% réduction' FROM client " +
                "INNER JOIN statut ON statut.codeStatut = client.codeStatut;";
            }
            else
            {
                strcommand = "SELECT idClient, nomC, prenomC, telephone, email, motDePasse, adresse, carteDeCredit, client.codeStatut as 'niveau fidelité', reduction AS '% réduction' FROM client " +
                $"INNER JOIN statut ON statut.codeStatut = client.codeStatut" +
                $" WHERE client.codeStatut='{toolStripComboBox3.Text}';";
            }


            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataClients.DataSource = dataTable;
            form1.ConnectionSQL.Close();

        }
        private void UpdateDataBouquetStandard()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }

            string strcommand = "";
            if (toolStripComboBox14.Text == "Tout")
            {
                strcommand = "SELECT idBouquetStandard, nomStandard, prixBS, margeBS, bouquet_standard.idOccasion, description AS 'Description Occasion' FROM bouquet_standard " +
                    "INNER JOIN occasion ON bouquet_standard.idOccasion= occasion.idOccasion;";
            }
            else
            {
                strcommand = $"SELECT idBouquetStandard, nomStandard, prixBS, margeBS, bouquet_standard.idOccasion, description AS 'Description Occasion' FROM bouquet_standard " +
                    "INNER JOIN occasion ON bouquet_standard.idOccasion= occasion.idOccasion" +
                    $" WHERE bouquet_standard.idOccasion ='{toolStripComboBox14.Text}';";
            }


            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            dataTable.Columns.Add("Description Bouquet", typeof(string));
            MySqlDataReader reader;
            List<string> valeur;
            List<string> fleurs;


            foreach (DataRow row in dataTable.Rows)
            {
                string compo = "";
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }

                strcommand = $"SELECT quantiteS, libelle_prod FROM compose_b_s" +
                    $" INNER JOIN produit ON compose_b_s.idProduit=produit.idProduit" +
                    $" WHERE idBouquetStandard = '{row[0]}';"; ;
                command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                reader = command.ExecuteReader();
                valeur = new List<string> { };
                fleurs = new List<string>();
                while (reader.Read())   // parcours ligne par ligne
                {

                    valeur.Add(reader.GetString(0));
                    fleurs.Add(reader.GetString(1));

                }
                for (int i = 0; i < valeur.Count; i++)
                {
                    compo += valeur[i] + " " + fleurs[i] + "; ";
                }

                row["Description Bouquet"] = compo;
                form1.ConnectionSQL.Close();
            }

            dataBouquetStandard.DataSource = dataTable;

        }
        private void UpdateDataStock()
        {
            if (toolStripComboBox1.Text != "" && toolStripComboBox2.Text != "")
            {
                form1.ConnectionSQL.Close();
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                string magasinChoisi = toolStripComboBox1.Text;
                string produitChoisi = toolStripComboBox2.Text;


                string strcommand = "";
                if (magasinChoisi == "Stock général" && produitChoisi == "Tous les produits")
                {
                    strcommand = "SELECT stock.idMagasin as Magasin, produit.libelle_prod as libelle,produit.type, stock.quantite, stock.date as 'Date Stock' FROM stock " +
                                    "INNER JOIN magasin ON magasin.idMagasin = stock.idMagasin " +
                                    "INNER JOIN produit ON produit.idProduit = stock.idProduit;";
                }
                else if (magasinChoisi != "Stock général" && produitChoisi == "Tous les produits")
                {
                    strcommand = "SELECT stock.idMagasin as Magasin, produit.libelle_prod as libelle,produit.type, stock.quantite, stock.date as 'Date Stock' FROM stock " +
                                    "INNER JOIN magasin ON magasin.idMagasin = stock.idMagasin " +
                                    "INNER JOIN produit ON produit.idProduit = stock.idProduit " +
                                    $"WHERE magasin.idMagasin = '{magasinChoisi}';";

                }
                else if (magasinChoisi == "Stock général" && produitChoisi != "Tous les produits")
                {
                    strcommand = "SELECT stock.idMagasin as Magasin, produit.libelle_prod as libelle,produit.type, stock.quantite, stock.date as 'Date Stock' FROM stock " +
                                    "INNER JOIN magasin ON magasin.idMagasin = stock.idMagasin " +
                                    "INNER JOIN produit ON produit.idProduit = stock.idProduit " +
                                    $"WHERE produit.libelle_prod = '{produitChoisi}';";

                }
                else if (magasinChoisi != "Stock général" && produitChoisi != "Tous les produits")
                {
                    strcommand = $"SELECT stock.idMagasin as Magasin, produit.libelle_prod as libelle,produit.type, stock.quantite, stock.date as 'Date Stock' FROM stock " +
                                    "INNER JOIN magasin ON magasin.idMagasin = stock.idMagasin " +
                                    "INNER JOIN produit ON produit.idProduit = stock.idProduit " +
                                    $"WHERE produit.libelle_prod = '{produitChoisi}' " +
                                    $"AND magasin.idMagasin = '{magasinChoisi}' ;";

                }

                MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                DataStock.DataSource = dataTable;
                form1.ConnectionSQL.Close();
            }
        }
        private void UpdateDataProduit()
        {
            if (toolStripComboBox17.Text != "")
            {
                form1.ConnectionSQL.Close();
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                string type = toolStripComboBox17.Text;

                modifierStock.Visible = false;


                string strcommand = "";
                if (type == "Tous types")
                {
                    strcommand = "Select * from produit;";
                }
                else
                {
                    strcommand = $"Select * from produit WHERE type = '{type}';";

                }


                MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataProduit.DataSource = dataTable;
                form1.ConnectionSQL.Close();
            }
        }

        private void toolStripComboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataBouquetStandard();
        }
        private void ToolStripComboBox1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            UpdateDataStock();

        }
        private void ToolStripComboBox2_SelectedIndexChanged(Object sender, EventArgs e)
        {
            UpdateDataStock();
        }

        private void toolStripComboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataProduit();
        }
        private void DataStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            // il faut vérifier pour quantité que elle est supérieure a 0 et empêcher la modification de l'id 
            //throw new NotImplementedException();
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = DataStock.Rows[ligne];
            string formatdebut = "dd/MM/yyyy HH:mm:ss";
            string formatfin = "yyyy-MM-dd";
            DateTime date = new DateTime();


            if (modif.Cells[col] != null)
            {
                if (col == 3 && int.TryParse(modif.Cells[col].Value.ToString(), out int res) && res >= 0)
                {
                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierStock.Visible = false;
                    string command = "UPDATE stock\r\n" +
                                     $"SET quantite =  {res}" +
                                        $"\r\nWHERE idProduit= (SELECT idProduit FROM produit WHERE libelle_prod = '{(string)modif.Cells[1].Value}')"
                                        + $" AND idMagasin = '{modif.Cells[0].Value}';";
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

                }
                // Le dateTime.... permet de vérifier que la modification correspond bien au format de la base données
                else if (col == 4 && DateTime.TryParseExact(modif.Cells[col].Value.ToString(), formatdebut, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {

                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierStock.Visible = false;
                    string dateSQL = date.ToString(formatfin);

                    string command = "UPDATE stock\r\n" +
                                     $"SET date =  '{dateSQL}'" +
                                        $"\r\nWHERE idProduit= (SELECT idProduit FROM produit WHERE libelle_prod = '{(string)modif.Cells[1].Value}')"
                                        + $" AND idMagasin = '{(string)modif.Cells[0].Value}';";
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);


                }
                else
                {
                    DataStock.CancelEdit();
                    modifierStock.Text = "Mauvais format";
                    modifierStock.BackColor = Color.FromArgb(255, 168, 173);
                    modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                    modifierStock.Visible = true;
                    UpdateDataStock();

                }
            }
            else // si la valeur mise est nulle
            {
                DataStock.CancelEdit();
                modifierStock.Text = "Mauvais format";
                modifierStock.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                modifierStock.Visible = true;
                UpdateDataStock();
            }

            form1.ConnectionSQL.Close();


        }

        // Si le format rentré est faux : afficher un petit message d'erreur et mettre inverser la modif
        private void DataStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = DataStock.Rows[ligne];

            DataStock.CancelEdit();
            modifierStock.Text = "Mauvais format";
            modifierStock.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modifierStock.Visible = true;
            UpdateDataStock();
        }


        //Detection de l'évenement modification pour éviter la modification des primary keys : magasins id et produit id 
        private void DataStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables;
            if (form1.User == "root")
            {
                colNonModifiables = new int[] { 0, 1, 2 };
            }
            else
            {
                colNonModifiables = new int[] { 0, 1, 2, 3 };
            }

            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }
        private void AjouterStock_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "stock");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }

        }

        private void AjoutForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            StockDataConnection();
            BoutiqueDataConnection();
            ProduitDataConnection();
            ClientDataConnection();
            BouquetStandardDataConnection();
            BouquetPersonnaliseDataConnection();
            CommandeDataConnection();
            UpdateDataStock();
            UpdateDataProduit();
            UpdateDataBouquetStandard();
            UpdateCommande();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = DataStock.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "stock", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }
        }

        private void SuppressionForm_FormClosed(object? sender, FormClosedEventArgs e)
        {

            StockDataConnection();
            BoutiqueDataConnection();
            ProduitDataConnection();
            ClientDataConnection();
            BouquetStandardDataConnection();
            BouquetPersonnaliseDataConnection();
            CommandeDataConnection();
            UpdateDataStock();
            UpdateDataProduit();
            UpdateDataBouquetStandard();
            UpdateCommande();

        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "magasin");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }

        }

        private void DataBoutique_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = DataBoutique.Rows[ligne];

            DataBoutique.CancelEdit();
            modifierBoutique.Text = "Mauvais format";
            modifierBoutique.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modifierBoutique.Visible = true;
        }

        private void DataBoutique_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = DataBoutique.Rows[ligne];
            if (modif.Cells[col] != null && modif.Cells[col].Value.ToString() != "")
            {
                modifierBoutique.Text = modif.Cells[0].Value.ToString();
                modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                modifierBoutique.Visible = true;
                string command = $"UPDATE magasin SET nom = '{modif.Cells[col].Value}' WHERE idMagasin = '{modif.Cells[0].Value}';";
                form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

            }
            else // si la valeur mise est nulle
            {
                DataBoutique.CancelEdit();
                modifierBoutique.Text = "Mauvais format";
                modifierBoutique.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                modifierBoutique.Visible = true;
            }
        }

        private void DataBoutique_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables;
            if (form1.User == "root")
            {
                colNonModifiables = new int[] { 0 };
            }
            else
            {
                colNonModifiables = new int[] { 0, 1 };
            }
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = DataBoutique.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "magasin", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }

        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "produit");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }

        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = dataProduit.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "produit", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }

        }

        private void DataProduit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataProduit.Rows[ligne];
            dataProduit.CancelEdit();


            modifierProduit.Text = "Mauvais format";
            modifierProduit.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modifierProduit.Visible = true;
        }

        private void DataProduit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataProduit.Rows[ligne];
            string formatdebut = "dd/MM/yyyy HH:mm:ss";
            string formatfin = "yyyy-MM-dd";
            DateTime date = new DateTime();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }

            if (modif.Cells[col] != null && modif.Cells[col].Value.ToString() != "")
            {
                if (col == 3 && double.TryParse(modif.Cells[col].Value.ToString(), out double res))
                {
                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierProduit.Visible = false;
                    string command = "UPDATE produit\r\n" +
                                     $"SET tarif_vente_unitaire =  {res}" +
                                        $"\r\nWHERE idProduit = '{modif.Cells[0].Value}';";
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                }
                else if (col == 4 && DateTime.TryParseExact(modif.Cells[col].Value.ToString(), formatdebut, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {

                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierProduit.Visible = false;
                    string dateSQL = date.ToString(formatfin);

                    string command = "UPDATE produit\r\n" +
                                     $"SET date_majoration_tarif =  '{dateSQL}'" +
                                        $"\r\nWHERE idProduit = '{modif.Cells[0].Value}';";
                    form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);


                }
                else if (col == 5 && int.TryParse(modif.Cells[col].Value.ToString(), out int res1) && res1 >= 1 && res1 <= 12)
                {
                    if (res1 <= (int)modif.Cells[6].Value)
                    {
                        modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                        modifierProduit.Visible = false;
                        string command = "UPDATE produit\r\n" +
                                         $"SET mois_debut_dispo =  '{res1}'" +
                                            $"\r\nWHERE idProduit = '{modif.Cells[0].Value}';";
                        form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                    }
                    else
                    {
                        modifierProduit.Text = "Fin avant début";
                        modifierProduit.BackColor = Color.FromArgb(255, 168, 173);
                        modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                        modifierProduit.Visible = true;
                        dataProduit.CancelEdit();
                        UpdateDataProduit();
                    }


                }
                else if (col == 6 && int.TryParse(modif.Cells[col].Value.ToString(), out int res2) && res2 >= 1 && res2 <= 12)
                {
                    if (res2 >= (int)modif.Cells[5].Value)
                    {
                        modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                        modifierProduit.Visible = false;
                        string command = "UPDATE produit\r\n" +
                                         $"SET mois_fin_dispo =  '{res2}'" +
                                            $"\r\nWHERE idProduit = '{modif.Cells[0].Value}';";
                        form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                    }
                    else
                    {
                        dataProduit.CancelEdit();
                        modifierProduit.Text = "Fin avant début";
                        modifierProduit.BackColor = Color.FromArgb(255, 168, 173);
                        modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                        modifierProduit.Visible = true;
                        UpdateDataProduit();
                    }

                }
                else
                {
                    dataProduit.CancelEdit();
                    modifierProduit.Text = "Mauvais format";
                    modifierProduit.BackColor = Color.FromArgb(255, 168, 173);
                    modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                    modifierProduit.Visible = true;
                    UpdateDataProduit();
                }
            }
            else // si la valeur mise est nulle
            {
                dataProduit.CancelEdit();
                modifierProduit.Text = "Mauvais format";
                modifierProduit.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                modifierProduit.Visible = true;
                UpdateDataProduit();
            }
            form1.ConnectionSQL.Close();
        }

        private void DataProduit_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables;
            if (form1.User == "root")
            {
                colNonModifiables = new int[] { 0, 1, 2 };
            }
            else
            {
                colNonModifiables = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            }
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = dataBouquetStandard.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "bouquet_standard", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }

        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "bouquet_standard");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }

        }

        private void DataBouquetStandard_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataBouquetStandard.Rows[ligne];

            dataBouquetStandard.CancelEdit();
            modifierBouquetStandard.Text = "Mauvais format";
            modifierBouquetStandard.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modifierBouquetStandard.Visible = true;
        }

        private void DataBouquetStandard_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataBouquetStandard_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables = { 0, 1, 3, 2, 4, 5 };
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }
        private void DataCommande_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataClients.Rows[ligne];

            dataCommandes.CancelEdit();
            toolStripCommande.Text = "Mauvais format";
            toolStripCommande.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            toolStripCommande.Visible = true;
        }

        private void DataCommande_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataCommandes.Rows[ligne];



            if (modif.Cells[col] != null && modif.Cells[col].Value.ToString() != "")
            {
                form1.ConnectionSQL.Close();
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }

                string strcommand = "SELECT codeEtat from etat;";
                MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);

                MySqlDataReader reader = command.ExecuteReader();
                List<string> valeur = new List<string> { };

                while (reader.Read())   // parcours ligne par ligne
                {

                    valeur.Add(reader.GetString(0)); // récupération 1ère colonne (selon la requête !)

                }
                form1.ConnectionSQL.Close();
                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                if (valeur.Contains(modif.Cells[col].Value.ToString()))
                {
                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierCommande.Visible = true;
                    modifierCommande.Text = modif.Cells[col].Value.ToString();
                    strcommand = "UPDATE commande\r\n" +
                                     $"SET codeEtat = '{modif.Cells[col].Value.ToString()}'" +
                                        $" WHERE idCommande = {modif.Cells[0].Value.ToString()};";
                    form1.ExecuteMysqlCommand(strcommand, form1.ConnectionSQL);
                    UpdateCommande();


                }
                else
                {
                    dataCommandes.CancelEdit();
                    modifierCommande.Text = "Mauvais format";
                    modifierCommande.BackColor = Color.FromArgb(255, 168, 173);
                    modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                    modifierCommande.Visible = true;
                    UpdateCommande();
                }
                form1.ConnectionSQL.Close();
            }
            else // si la valeur mise est nulle
            {
                dataCommandes.CancelEdit();
                modifierCommande.Text = "Mauvais format";
                modifierCommande.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                modifierCommande.Visible = true;
                UpdateCommande();
            }
        }

        private void DataCommande_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables;
            if (form1.User == "root")
            {
                colNonModifiables = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9, 10, 11 };
            }
            else
            {
                colNonModifiables = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            }
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }

        private void DataClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataClients.Rows[ligne];

            dataClients.CancelEdit();
            modifierClient.Text = "Mauvais format";
            modifierClient.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modifierClient.Visible = true;
        }

        private void DataClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataClients_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables;
            if (form1.User == "root")
            {
                colNonModifiables = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            }
            else
            {
                colNonModifiables = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            }
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClient();
        }

        private void toolStripComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommande();
        }

        private void toolStripComboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCommande();
        }

        private void dataEtat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataBouquetPerso_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = dataBouquetPerso.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "bouquet_personnalise", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "commande");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "client");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                Ajout ajout = new Ajout(form1, "bouquet_personnalise");
                ajout.FormClosed += AjoutForm_FormClosed;
                ajout.ShowDialog();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = dataClients.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "client", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (form1.User == "root")
            {
                DataGridViewCell cell = dataCommandes.SelectedCells[0];
                DataGridViewRow ligne = cell.OwningRow;

                Suppression suppression = new Suppression(ligne, "commande", form1);
                suppression.FormClosed += SuppressionForm_FormClosed;
                suppression.ShowDialog();
            }
        }
    }

}
