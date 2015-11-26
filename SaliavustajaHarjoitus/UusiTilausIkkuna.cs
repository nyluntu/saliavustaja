using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaliavustajaHarjoitus
{
    public partial class UusiTilausIkkuna : Form
    {
        public UusiTilausIkkuna()
        {
            InitializeComponent();
        }

        private void UusiTilausIkkuna_Load(object sender, EventArgs e)
        {
            LisaaPoydatPudotusvalikkoon();
        }

        private void LisaaPoydatPudotusvalikkoon()
        {
            PoytaDb poytaDb = new InMemoryPoytaDb();

            List<Poyta> poydat = poytaDb.HaeKaikki();

            foreach (Poyta poyta in poydat)
            {
                comboBoxPoydat.Items.Add(poyta);
            }
        }
    }
}
