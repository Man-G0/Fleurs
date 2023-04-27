namespace Lauryne_Blomme__Manon_Goffinet___Fleurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Bitmap bmp = new Bitmap(Properties.Resources.icon);
            Icon icon = Icon.FromHandle(bmp.GetHicon());
            this.Icon = icon;
            InitializeComponent();
        }


    }
}