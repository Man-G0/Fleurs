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
            StockDataConnection();
        }

        private void BoutiqueDataConnection()
        {
            string strcommand = "Select * from magasin;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DataBoutique.DataSource = dataTable;
        }
        private void StockDataConnection()
        {
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
            toolStripComboBox1.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox1.SelectedItem = "Stock général";


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
            toolStripComboBox2.Items.AddRange(temp);
            reader.Close();
            toolStripComboBox2.SelectedItem = "Tous les produits";


        }
        private void UpdateDataStock()
        {
            if (toolStripComboBox1.Text != "" && toolStripComboBox2.Text != "")
            {
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
            }
        }
        private void ToolStripComboBox1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            UpdateDataStock();
        }
        private void ToolStripComboBox2_SelectedIndexChanged(Object sender, EventArgs e)
        {
            UpdateDataStock();
        }
    }

}
