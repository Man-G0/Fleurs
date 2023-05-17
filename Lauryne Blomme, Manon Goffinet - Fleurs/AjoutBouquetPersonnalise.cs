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
    public partial class AjoutBouquetPersonnalise : UserControl
    {
        Form1 form1;
        Ajout ajout;
        public AjoutBouquetPersonnalise(Form1 form1, Ajout ajout)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ajout = ajout;
            dataAjoutBouquet();

        }

        private void dataAjoutBouquet()
        {
            form1.ConnectionSQL.Close();
            if (form1.ConnectionSQL.State.ToString() != "Open")
            {
                form1.ConnectionSQL.Open();
            }
            string strcommand = "Select idProduit,libelle_prod,type,tarif_vente_unitaire AS tarif,mois_debut_dispo,mois_fin_dispo from produit;";
            MySqlCommand command = new MySqlCommand(strcommand, form1.ConnectionSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataTable.Columns.Add("Quantité", typeof(int));

            foreach (DataRow row in dataTable.Rows)
            {
                row["Quantité"] = 0;
                form1.ConnectionSQL.Close();
            }

            dataAjoutBouquetPerso.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataAjoutBouquetPerso.DataSource = dataTable;


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

            if (textBox9.Text != null && textBox9.Text != "" && int.TryParse(textBox1.Text, out int budget))
            {
                string budgetstr = textBox1.Text;
                string desc = textBox9.Text;

                int pk = -1;
                string command = $"SELECT count(idBouquetPerso) FROM bouquet_personnalise;";

                if (form1.ConnectionSQL.State.ToString() != "Open")
                {
                    form1.ConnectionSQL.Open();
                }
                MySqlCommand commandSQL = new MySqlCommand(command, form1.ConnectionSQL);
                pk = Convert.ToInt32(commandSQL.ExecuteScalar());
                form1.ConnectionSQL.Close();



                int n = pk + 1;
                string newPk = "bp" + Convert.ToString(n);
                bool newPkExiste = true;
                int count = -1;
                while (newPkExiste == true)
                {
                    form1.ConnectionSQL.Close();
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    command = $"SELECT count(idBouquetPerso) FROM bouquet_personnalise WHERE idBouquetPerso = '{newPk}';";
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
                        newPk = "bp" + Convert.ToString(n);
                    }


                }
                command = $"INSERT INTO bouquet_personnalise(idBouquetPerso, budgetMax,descriptionBP, margeBP) " +
                    $"VALUES ('{newPk}', {budget},'{desc}',{Convert.ToString(budget * 10 / 100)});";
                form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);

                string contenu = "";
                DataGridView temp = new DataGridView();

                DataGridViewColumn column1 = new DataGridViewColumn(dataAjoutBouquetPerso.Columns[0].CellTemplate);
                DataGridViewColumn column2 = new DataGridViewColumn(dataAjoutBouquetPerso.Columns[6].CellTemplate);
                temp.Columns.Add(column1);
                temp.Columns.Add(column2);

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    form1.ConnectionSQL.Close();
                    if (form1.ConnectionSQL.State.ToString() != "Open")
                    {
                        form1.ConnectionSQL.Open();
                    }
                    string idProduit = temp.Rows[i].Cells[0].ToString();
                    string quantite = temp.Rows[i].Cells[1].ToString();

                    if (quantite != "0")
                    {
                        command = $"INSERT INTO compose_b_p(idBouquetPerso,idProduit, quantiteP) " +
                    $"VALUES ('{newPk}', '{idProduit}',{quantite});";
                        form1.ExecuteMysqlCommand(command, form1.ConnectionSQL);
                        contenu += "; ";
                    }


                }
                label12.ForeColor = Color.FromArgb(152, 186, 92);
                label12.Text = "Votre bouquet a été ajouté à la base de données";
                label12.Visible = true;
                Ok.Show();
                Non.Hide();
                Oui.Hide();
            }
            else
            {
                label12.Text = "Veuillez entrer des données valides dans les cases de description et de budget max";
                label12.ForeColor = Color.FromArgb(192, 0, 0);
                label12.Show();
            }



        }

        private void dataAjoutBouquetPerso_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            int[] colNonModifiables = { 0, 1, 2, 3, 4, 5 };

            if (colNonModifiables.Contains(e.ColumnIndex))
            {
                e.Cancel = true;
            }
        }

        private void dataAjoutBouquetPerso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataAjoutBouquetPerso.Rows[ligne];

            if (!int.TryParse(modif.Cells[col].Value.ToString(), out int res) || res < 0)
            {
                dataAjoutBouquetPerso.CancelEdit();
                label12.Text = "Mauvais format";
                label12.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
                modif.Cells[col].Value = "0";
                label12.Visible = true;

            }
        }

        private void dataAjoutBouquetPerso_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            int ligne = e.RowIndex;
            int col = e.ColumnIndex;
            DataGridViewRow modif = dataAjoutBouquetPerso.Rows[ligne];

            dataAjoutBouquetPerso.CancelEdit();
            label12.Text = "Mauvais format";
            label12.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Style.BackColor = Color.FromArgb(255, 168, 173);
            modif.Cells[col].Value = "0";
            label12.Visible = true;
        }

      
    }
}
