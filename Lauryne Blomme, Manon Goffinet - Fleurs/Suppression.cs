using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class Suppression : Form
    {
        DataGridViewRow ligne;
        string tableConcernee;
        Form1 form1;
        public Suppression(DataGridViewRow ligne, string tableConcernee, Form1 form1)
        {
            InitializeComponent();
            this.ligne = ligne;
            this.tableConcernee = tableConcernee;
            this.form1 = form1;
        }

        private void Non_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Oui_Click(object sender, EventArgs e)
        {
            string command = "";
            if (tableConcernee == "stock")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idProduit= (SELECT idProduit FROM produit WHERE libelle_prod = '{(string)ligne.Cells[1].Value}')"
                            + $" AND idMagasin = '{(string)ligne.Cells[0].Value}';";
            }
            else if(tableConcernee == "magasin")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idMagasin= '{(string)ligne.Cells[0].Value}';";
            }
            else if (tableConcernee == "produit")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idProduit= '{(string)ligne.Cells[0].Value}';";
            }
            else if (tableConcernee == "client")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idClient= '{(string)ligne.Cells[0].Value}';";
            }
            else if (tableConcernee == "bouquet_standard")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idBouquetStandard= '{(string)ligne.Cells[0].Value}';";
            }
            else if (tableConcernee == "commande")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idCommande= {ligne.Cells[0].Value};";
            }
            else if (tableConcernee == "bouquet_personnalise")
            {
                command = $"DELETE FROM {tableConcernee}\r\n" +
                             $"\r\nWHERE idBouquetPerso= '{(string)ligne.Cells[0].Value}';";
            }
           

            form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

            SupressionTexBox.Text = "La ligne a été supprimée";
            Ok.Show();
            Non.Hide();
            Oui.Hide();

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
