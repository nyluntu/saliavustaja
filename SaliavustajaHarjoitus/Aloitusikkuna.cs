using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using Saliavustaja.TietokantaLiittymat;
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

        private void Aloitusikkuna_Load(object sender, EventArgs e)
        {
            TilausDb tilausTietokanta = new FileSystemTilausDb("C:\\Temp\\tietokanta.dat");
            List<Tilaus> tilaukset = tilausTietokanta.HaeKaikki();

            foreach (var tilaus in tilaukset)
            {
                ListViewItem rivi = new ListViewItem(tilaus.Tilausnumero.ToString());
                rivi.Tag = tilaus;
                rivi.SubItems.Add(tilaus.LaskeVerotonKokonaishinta().ToString("C2"));
                rivi.SubItems.Add(tilaus.TapahtumanTila.ToString());
                listViewTilaukset.Items.Add(rivi);
            }
        }
    }
}
