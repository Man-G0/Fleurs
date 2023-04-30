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
    public partial class ChoixBoutiques : UserControl
    {
        Form1 form1;
        public ChoixBoutiques(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBoxBoutiques.SelectedIndex != -1)
            {
                labelBoutiques.ForeColor = Color.Black;
                form1.Boutique = comboBoxBoutiques.SelectedIndex;

            }
            else
            {
                
                labelBoutiques.ForeColor = Color.FromArgb(196,0,30);
            }
            
        }
    }
}
