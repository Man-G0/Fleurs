using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> utilisateurMotdePasse = new Dictionary<String, String> { };
        int boutique = -1;
        MySqlConnection connectionSQL;
        public Form1(MySqlConnection connectionSQL)
        {
            this.connectionSQL = connectionSQL;

            Bitmap bmp = new Bitmap(Properties.Resources.icon);
            Icon icon = Icon.FromHandle(bmp.GetHicon());
            Icon = icon;
            utilisateurMotdePasse.Add("root", "root");
            utilisateurMotdePasse.Add("bozo", "bozo");
            InitializeComponent();
            Connexion();
            ChoixBoutique();
            InterfaceAdmin();
        }

        public int Boutique
        {
            get { return boutique; }
            set { boutique = value; }
        }
        public MySqlConnection ConnectionSQL
        {
            get { return connectionSQL; }
            set { connectionSQL = value; }
        }

        public void changelayout1toClientChoixBoutique()
        {
            layoutConnection.Hide();
            layoutChoixBoutiques.Visible = true;
        }
        public void changelayout1toInterfaceAdministrateur()
        {
            layoutConnection.Hide();
            layoutInterfaceAdmin.Visible = true;
        }
        public void ExecuteMysqlCommand(string strcommand, MySqlConnection connection)
        {
            if (connection.State.ToString()!="Open")
            {
                connection.Open();
            }
           
            MySqlCommand command = new MySqlCommand(strcommand, connection);
            try
            {
                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur : " + e.ToString());
            }
            connection.Close();
                        
        }

    }
}