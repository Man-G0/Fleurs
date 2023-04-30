using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> utilisateurMotdePasse = new Dictionary<String, String> { };
        int boutique;
        public Form1(int boutique)
        {
            this.boutique = boutique;

            utilisateurMotdePasse.Add("root", "root");
            utilisateurMotdePasse.Add("bozo", "bozo");
            InitializeComponent();
        }

        public int Boutique
        {
            get { return boutique; }
            set { boutique = value; }
        }


        public void changelayout1to2()
        {
            layoutConnection.Hide();
            layoutChoixBoutiques.Visible = true;
        }

    }
}