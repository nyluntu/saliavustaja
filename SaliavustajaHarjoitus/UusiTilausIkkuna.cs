using Saliavustaja;
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
        Aloitusikkuna kantaikkuna = null;
        Tilaus tilaus = new Tilaus();
        TilausDb tilausTietokanta = new FileSystemTilausDb("C:\\Temp\\tietokanta.dat");
        PoytaDb poytaTietokanta = new InMemoryPoytaDb();
        BonusAsiakasDb asiakasTietokanta = new InMemoryBonusAsiakasDb();
        PoytaDb poytaDb = new InMemoryPoytaDb();
        AteriaDb ateriaDb = new InMemoryAteriaDb();

        public UusiTilausIkkuna()
        {
            InitializeComponent();
        }

        public UusiTilausIkkuna(Aloitusikkuna kantaikkuna)
            : this()
        {
            this.kantaikkuna = kantaikkuna;
        }

        private void UusiTilausIkkuna_Load(object sender, EventArgs e)
        {
            tilaus.Asiakas = new Asiakas();
            LisaaPoydatPudotusvalikkoon();
            LisaaAteriatListalle();
            PiilotaEtupisteet();
        }

        private void UusiTilausIkkuna_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(kantaikkuna != null)
            {
                kantaikkuna.PaivitaTilausLista();
            }
        }

        private void buttonLisaaAteria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAteriat.SelectedItems.Count; i++)
            {
                Ateria ateria = (Ateria)listViewAteriat.SelectedItems[i].Tag;

                DataGridViewRow rivi = new DataGridViewRow();
                rivi.CreateCells(dataGridViewAteriat);
                rivi.Tag = ateria;
                rivi.SetValues(ateria.Nimi, ateria.LaskeVerollinenHinta().ToString("C2"), 0);
                dataGridViewAteriat.Rows.Add(rivi);

                tilaus.LisaaAteria(ateria, 0);
            }
        }

        private void buttonPoistaAteria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewAteriat.SelectedRows.Count; i++)
            {
                DataGridViewRow poistettavaRivi = dataGridViewAteriat.SelectedRows[i];
                dataGridViewAteriat.Rows.Remove(poistettavaRivi);
                Ateria ateria = (Ateria)poistettavaRivi.Tag;
                tilaus.PoistaAteria(ateria);
            }
            MuutaTilauksenTiedotTekstikenttiin();
        }

        private void dataGridViewAteriat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Ateria ateria = (Ateria)dataGridViewAteriat.Rows[e.RowIndex].Tag;
                int maara = Int32.Parse(dataGridViewAteriat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                tilaus.VaihdaAteriaMaara(ateria, maara);
                MuutaTilauksenTiedotTekstikenttiin();
            }
        }

        private void checkBoxBonusasiakas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBonusasiakas.Checked)
            {
                BonusAsiakas bonusAsiakas = new BonusAsiakas();
                labelKertyvatPisteetValue.Text = bonusAsiakas.LaskeEtupisteet(tilaus.LaskeVerollinenKokonaishinta()).ToString();
                tilaus.Asiakas = bonusAsiakas;
                NaytaEtupisteet();
            }
            else
            {
                tilaus.Asiakas = new Asiakas();
                PiilotaEtupisteet();
            }

            MuutaTilauksenTiedotTekstikenttiin();
        }

        private void comboBoxPoydat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Poyta valittuPoyta = (Poyta)comboBoxPoydat.SelectedItem;
            tilaus.Poyta = valittuPoyta;
        }

        private void buttonPeruTilaus_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonVahvistaTilaus_Click(object sender, EventArgs e)
        {
            try
            {
                TilauksenVastaanotto tilauksenVastaanotto = new TilauksenVastaanotto(
                    tilausTietokanta,
                    poytaTietokanta,
                    asiakasTietokanta);

                tilauksenVastaanotto.VastaanotaTilaus(tilaus);
                MessageBox.Show("Tilaus vastaanotettu onnistuneesti.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LisaaPoydatPudotusvalikkoon()
        {
            List<Poyta> poydat = poytaDb.HaeKaikki();

            foreach (Poyta poyta in poydat)
            {
                comboBoxPoydat.Items.Add(poyta);
            }
        }

        private void LisaaAteriatListalle()
        {
            List<Ateria> ateriat = ateriaDb.HaeKaikki();

            foreach (Ateria ateria in ateriat)
            {
                ListViewItem rivi = new ListViewItem(ateria.Nimi);
                rivi.Tag = ateria;
                rivi.SubItems.Add(ateria.LaskeVerollinenHinta().ToString("C2"));
                listViewAteriat.Items.Add(rivi);
            }
        }

        private void PiilotaEtupisteet()
        {
            labelKertyvatPisteetTitle.Hide();
            labelKertyvatPisteetValue.Hide();
        }

        private void NaytaEtupisteet()
        {
            labelKertyvatPisteetTitle.Show();
            labelKertyvatPisteetValue.Show();
        }

        private void MuutaTilauksenTiedotTekstikenttiin()
        {
            labelVerotonHintaValue.Text = tilaus.LaskeVerotonKokonaishinta().ToString("C2");
            labelTilauksenKokonaishintaValue.Text = tilaus.LaskeVerollinenKokonaishinta().ToString("C2");
            labelVeronOsuusValue.Text = (tilaus.LaskeVerollinenKokonaishinta() - tilaus.LaskeVerotonKokonaishinta()).ToString("C2");
        }

        
    }
}
