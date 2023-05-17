using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using static System.Windows.Forms.DataFormats;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> utilisateurMotdePasse = new Dictionary<String, String> { };
        Dictionary<String, String> adminMotdePasse = new Dictionary<String, String> { };
        string password;
        string user;
        int boutique = -1;
        MySqlConnection connectionSQL;
        public Form1(MySqlConnection connectionSQL)
        {
            this.connectionSQL = connectionSQL;

            Bitmap bmp = new Bitmap(Properties.Resources.icon);
            Icon icon = Icon.FromHandle(bmp.GetHicon());
            Icon = icon;
            adminMotdePasse.Add("root", "root");
            adminMotdePasse.Add("bozo", "bozo");
            InitializeComponent();
            AjoutUser();
            Connexion();
            ChoixBoutique();
            InterfaceAdmin();
        }
        private void AjoutUser()
        {
            if (connectionSQL.State.ToString() != "Open")
            {
                connectionSQL.Open();
            }
            string strcommand = "SELECT email, motDePasse FROM client;"; ;
            MySqlCommand command = new MySqlCommand(strcommand, connectionSQL);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                utilisateurMotdePasse.Add(reader.GetString(0), reader.GetString(1));

            }
            connectionSQL.Close();
        }
        public int Boutique
        {
            get { return boutique; }
            set { boutique = value; }
        }
        public string User
        {
            get { return user; }
            set { user = value; }
            
        }
        public string Password
        {
            get { return password; }
            set { password = value; }

        }
        public Dictionary<String, String> UtilisateurMotdePasse
        {
            get { return utilisateurMotdePasse; }
        }
        public Dictionary<String, String> AdminMotdePasse
        {
            get { return adminMotdePasse; }
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
            connection.Close();
            if (connection.State.ToString() != "Open")
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