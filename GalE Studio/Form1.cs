namespace GalE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void �½���ĿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new();
            form2.ShowDialog();
        }
    }
}