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
    public partial class Ajout : Form
    {
        Form1 form1;
        string tableConcernee;
        public Ajout(Form1 form1, string tableConcernee)
        {
            InitializeComponent();
            this.form1 = form1;
            this.tableConcernee = tableConcernee;
            if (tableConcernee == "stock")
            {
                Stock();
            }
            else if (tableConcernee == "magasin")
            {
                Magasin();
            }
            else if (tableConcernee == "produit")
            {
                Produit();
            }
            else if (tableConcernee == "client")
            {
                Client();
            }
            else if (tableConcernee == "commande")
            {
                Commande();
            }
            else if (tableConcernee == "bouquet_standard")
            {
                BouquetStandard();
            }
            else if (tableConcernee == "bouquet_personnalise")
            {
                BouquetPerso();
            }



        }
        private void Stock()
        {
            ClientSize = new Size(433, 389);
            ajoutStock = new AjoutStock(form1, this);
            Controls.Add(ajoutStock);
            ajoutStock.Name = "ajout Stock";
            ajoutStock.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutStock, 0, 0);
        }
        private void Magasin()
        {
            ClientSize = new Size(435, 259);
            ajoutMagasin = new AjoutMagasin(form1, this);
            Controls.Add(ajoutMagasin);
            ajoutMagasin.Name = "ajout Magasin";
            ajoutMagasin.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutMagasin, 0, 0);
        }
        private void Produit()
        {
            ClientSize = new Size(539, 523);
            ajoutProduit = new AjoutProduit(form1, this);
            Controls.Add(ajoutProduit);
            ajoutProduit.Name = "ajout Produit";
            ajoutProduit.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutProduit, 0, 0);
        }

        private void Client()
        {
            ClientSize = new Size(525, 500);
            ajoutClient = new AjoutClient(form1, this);
            Controls.Add(ajoutMagasin);
            ajoutClient.Name = "ajout Client";
            ajoutClient.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutClient, 0, 0);
        }

        private void Commande()
        {
            ClientSize = new Size(672, 595);
            ajoutCommande = new AjoutCommande(form1, this);
            Controls.Add(ajoutCommande);
            ajoutCommande.Name = "ajout Commande";
            ajoutCommande.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutCommande, 0, 0);
        }
        private void BouquetStandard()
        {

        }
        private void BouquetPerso()
        {
            ClientSize = new Size(813, 460); 
            ajoutBouquetPersonnalise = new AjoutBouquetPersonnalise(form1, this);
            Controls.Add(ajoutBouquetPersonnalise);
            ajoutBouquetPersonnalise.Name = "ajout bouquet Perso";
            ajoutBouquetPersonnalise.Dock = DockStyle.Fill;
            layoutAjoutStock.Controls.Add(ajoutBouquetPersonnalise, 0, 0);
        }
    }
}
