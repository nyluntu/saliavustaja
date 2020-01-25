using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaliavustajaHarjoitus
{
    public partial class Aloitusikkuna : Form
    {
        TilausDb tilausTietokanta = new FileSystemTilausDb("C:\\Temp\\tietokanta.dat");

        public Aloitusikkuna()
        {
            InitializeComponent();
        }

        private void uusiTilausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UusiTilausIkkuna uusiTilausIkkuna = new UusiTilausIkkuna(this);
            uusiTilausIkkuna.ShowDialog();
        }

        private void lopetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Aloitusikkuna_Load(object sender, EventArgs e)
        {
            PaivitaTilausLista();
        }

        public void PaivitaTilausLista()
        {
            listViewTilaukset.Items.Clear();
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
