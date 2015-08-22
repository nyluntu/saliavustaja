using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saliavustaja.UI
{
    public partial class AloitusIkkuna : Form
    {
        public AloitusIkkuna()
        {
            InitializeComponent();
        }

        private void uusiTilausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UusiTilaus tilausikkuna = new UusiTilaus();
            tilausikkuna.Show();
        }

        private void lopetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
