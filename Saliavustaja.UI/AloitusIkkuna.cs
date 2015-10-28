using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Saliavustaja.UI
{
    public partial class AloitusIkkuna : Form
    {

        TilausDb tilausDb = new FileSystemTilausDb("C:\\Temp\\tietokanta.dat");

        public AloitusIkkuna()
        {
            InitializeComponent();
        }

        void AloitusIkkuna_Load(object sender, EventArgs e)
        {
            PaivitaTilauksetListaKomponenttiin();
        }

        void uusiTilausToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UusiTilaus tilausikkuna = new UusiTilaus(this);
            tilausikkuna.ShowDialog();
        }

        void lopetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void PaivitaTilauksetListaKomponenttiin()
        {
            TilauksetListView.Items.Clear();
            List<Tilaus> tilaukset = tilausDb.HaeKaikki();
            foreach (var tilaus in tilaukset)
            {
                ListViewItem rivi = new ListViewItem(tilaus.Tilausnumero.ToString());
                rivi.Tag = tilaus;
                rivi.SubItems.Add(tilaus.LaskeVerotonKokonaishinta().ToString("C2"));
                rivi.SubItems.Add(tilaus.TapahtumanTila.ToString());
                TilauksetListView.Items.Add(rivi);
            }
        }

    }
}
