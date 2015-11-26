using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaliavustajaHarjoitus
{
    public partial class Aloitusikkuna : Form
    {
        public Aloitusikkuna()
        {
            InitializeComponent();
        }

        private void uusiTilausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UusiTilausIkkuna uusiTilausIkkuna = new UusiTilausIkkuna();
            uusiTilausIkkuna.ShowDialog();
        }

        private void lopetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
