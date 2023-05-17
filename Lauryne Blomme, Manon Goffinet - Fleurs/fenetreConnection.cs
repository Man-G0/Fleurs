using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class fenetreConnection : UserControl
    {
        Dictionary<String, String> utilisateurMotdePasse = new Dictionary<String, String> { };
        Dictionary<String, String> adminMotdePasse = new Dictionary<String, String> { };
        Form1 form1;
        public fenetreConnection(Form1 form1, Dictionary<String, String> utilisateurMotdePasse, Dictionary<String, String> adminMotdePasse)
        {
            
            this.form1 = form1;
            InitializeComponent();

            this.utilisateurMotdePasse=utilisateurMotdePasse;
            this.adminMotdePasse=adminMotdePasse;

        }

        
        private void boutonConnection_Click(object sender, EventArgs e)
        {
            if (mdp.Text != null && utilisateur.Text != null)
            {
                if (utilisateurMotdePasse.ContainsKey(utilisateur.Text) && utilisateurMotdePasse[utilisateur.Text] == mdp.Text)
                {
                    form1.User = utilisateur.Text;
                    form1.Password = mdp.Text;
                    labelErreurConnection.Visible = false;
                    form1.changelayout1toClientChoixBoutique();

                }
                else if (adminMotdePasse.ContainsKey(utilisateur.Text) && adminMotdePasse[utilisateur.Text] == mdp.Text)
                {

                    labelErreurConnection.Visible = false;
                    form1.User = utilisateur.Text;
                    form1.Password = mdp.Text;
                    form1.changelayout1toInterfaceAdministrateur();

                }
                else if (!utilisateurMotdePasse.ContainsKey(utilisateur.Text) && !adminMotdePasse.ContainsKey(utilisateur.Text))
                {
                    labelErreurConnection.Text = "Nom d'utilisateur invalide";
                    labelErreurConnection.Visible = true;
                }
                else if (adminMotdePasse.ContainsKey(utilisateur.Text) && adminMotdePasse[utilisateur.Text] != mdp.Text)
                {
                    labelErreurConnection.Text = "Mot de passe incorrect";
                    labelErreurConnection.Visible = true;
                }
                else if (utilisateurMotdePasse.ContainsKey(utilisateur.Text) && utilisateurMotdePasse[utilisateur.Text] != mdp.Text)
                {
                    labelErreurConnection.Text = "Mot de passe incorrect";
                    labelErreurConnection.Visible = true;
                }
            }
            else
            {
                labelErreurConnection.Text = "Veuillez entrer vos identifiants";
                labelErreurConnection.Visible = true;
            }
        }

    }
}
