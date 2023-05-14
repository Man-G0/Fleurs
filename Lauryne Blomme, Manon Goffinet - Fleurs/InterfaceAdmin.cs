using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

                modifierStock.Visible = false;


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
        private void DataStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
                if (col == 3 && (int)modif.Cells[col].Value >= 0)
                {
                    modif.Cells[col].Style.BackColor = Color.FromArgb(152, 186, 92);
                    modifierStock.Visible = false;
                    string command = "UPDATE stock\r\n" +
                                     $"SET quantite =  {modif.Cells[col].Value}" +
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
                    DataStock.CancelEdit();
                    modifierStock.Visible = true;

                }
            }
            else // si la valeur mise est nulle
            {
                DataStock.CancelEdit();
                modifierStock.Text = date.ToString(formatfin);
                modifierStock.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            }




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
            DataStock.CancelEdit();
            modifierStock.Visible = true;
        }


        //Detection de l'évenement modification pour éviter la modification des primary keys : magasins id et produit id 
        private void DataStock_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int[] colNonModifiables = { 0, 1, 2 };
            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }
        private void AjouterStock_Click(object sender, EventArgs e)
        {
            Ajout ajout = new Ajout(form1, "stock");
            ajout.FormClosed += AjoutForm_FormClosed;
            ajout.ShowDialog();
        }

        private void AjoutForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            UpdateDataStock();
            BoutiqueDataConnection();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = DataStock.SelectedCells[0];
            DataGridViewRow ligne = cell.OwningRow;

            Suppression suppression = new Suppression(ligne, "stock", form1);
            suppression.FormClosed += SuppressionForm_FormClosed;
            suppression.ShowDialog();


        }

        private void SuppressionForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            UpdateDataStock();
            BoutiqueDataConnection();
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            Ajout ajout = new Ajout(form1, "magasin");
            ajout.FormClosed += AjoutForm_FormClosed;
            ajout.ShowDialog();
        }
    }

}
