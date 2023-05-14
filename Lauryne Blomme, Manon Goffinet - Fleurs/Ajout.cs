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

        }


    }
}
