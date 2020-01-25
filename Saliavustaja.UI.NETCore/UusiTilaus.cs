using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using Saliavustaja.Rajapinnat;
using SaliavustajaTv;

namespace Saliavustaja.UI
{
    public partial class UusiTilaus : Form
    {
        const double ALV = 0.14;

        AloitusIkkuna kantaikkuna = null;
        Tilaus tilaus = new Tilaus();
        TilausDb tilausDb = new FileSystemTilausDb("C:\\Temp\\tietokanta.dat");
        PoytaDb poytaDb = new InMemoryPoytaDb();
        AteriaDb ateriaDb = new InMemoryAteriaDb();
        BonusAsiakasDb asiakasDb = new InMemoryBonusAsiakasDb();

        public UusiTilaus()
        {
            InitializeComponent();
            tilaus.Asiakas = new Asiakas();
        }

        public UusiTilaus(AloitusIkkuna kantaikkuna)
            : this()
        {
            this.kantaikkuna = kantaikkuna;
        }

        void UusiTilaus_Load(object sender, EventArgs e)
        {
            LisaaPoydatPudotusvalikkoon();
            LisaaAteriatListaValikkoon();
            PiilotaEtupisteidenElementit();
        }

        void UusiTilaus_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kantaikkuna != null)
                kantaikkuna.PaivitaTilauksetListaKomponenttiin();
        }

        void VahvistaTilausButton_Click(object sender, EventArgs e)
        {
            try
            {
                TilauksenVastaanotto tilauksenVastaanotto = new TilauksenVastaanotto(tilausDb, poytaDb, asiakasDb);
                tilauksenVastaanotto.VastaanotaTilaus(tilaus);
                MessageBox.Show("Tilaus tallennettu onnistuneesti.");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void PeruTilausButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void LisaaAteriaButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AteriatListView.SelectedItems.Count; i++)
            {
                Ateria ateria = (Ateria)AteriatListView.SelectedItems[i].Tag;
                DataGridViewRow rivi = new DataGridViewRow();
                rivi.CreateCells(AteriatDataGridView);
                rivi.Tag = ateria;
                rivi.SetValues(ateria.Nimi, (ateria.VerotonHinta * (1 + ALV)).ToString("C2"), 0);
                AteriatDataGridView.Rows.Add(rivi);
                tilaus.LisaaAteria(ateria, 0);
            }
        }

        void PoistaAteriaButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AteriatDataGridView.SelectedRows.Count; i++)
            {
                DataGridViewRow rivi = AteriatDataGridView.SelectedRows[i];
                AteriatDataGridView.Rows.Remove(rivi);
                Ateria ateria = (Ateria)rivi.Tag;
                tilaus.PoistaAteria(ateria);
            }
        }

        void AteriatDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Ateria ateria = (Ateria)AteriatDataGridView.Rows[e.RowIndex].Tag;
                int maara = int.Parse(AteriatDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                tilaus.VaihdaAteriaMaara(ateria, maara);

                LaskeKokonaishintaJaEtupisteet();
            }
        }

        void LisaaPoydatPudotusvalikkoon()
        {
            List<Poyta> poydat = poytaDb.HaeKaikki();
            foreach (Poyta poyta in poydat)
            {
                PoydatCombobox.Items.Add(poyta);
            }
        }

        void LisaaAteriatListaValikkoon()
        {
            List<Ateria> ateriat = ateriaDb.HaeKaikki();
            foreach (var ateria in ateriat)
            {
                ListViewItem rivi = new ListViewItem(ateria.Nimi);
                rivi.Tag = ateria;
                rivi.SubItems.Add((ateria.VerotonHinta * (1 + ALV)).ToString("C2"));
                AteriatListView.Items.Add(rivi);
            }
        }

        void PoydatCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Poyta valittuPoyta = (Poyta)PoydatCombobox.SelectedItem;
            tilaus.Poyta = valittuPoyta;
        }

        void BonusAsiakasCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LaskeKokonaishintaJaEtupisteet();
        }

        void LaskeKokonaishintaJaEtupisteet()
        {
            if (BonusAsiakasCheckbox.Checked)
            {
                BonusAsiakas bonusAsiakas = new BonusAsiakas();
                EtupisteetValue.Text = bonusAsiakas.LaskeEtupisteet(tilaus.LaskeVerollinenKokonaishinta()).ToString();
                tilaus.Asiakas = bonusAsiakas;
                NaytaEtupisteidenElementit();
            }
            else
            {
                tilaus.Asiakas = new Asiakas();
                PiilotaEtupisteidenElementit();
            }
            LaskeKokonaishintaTilaukselle();
        }

        void LaskeKokonaishintaTilaukselle()
        {
            KokonaishintaValue.Text = tilaus.LaskeVerollinenKokonaishinta().ToString("C2");
            VerotonKokonaishintaValue.Text = tilaus.LaskeVerotonKokonaishinta().ToString("C2");
            VeronosuusValue.Text = (tilaus.LaskeVerollinenKokonaishinta() - tilaus.LaskeVerotonKokonaishinta()).ToString("C2");
        }

        void NaytaEtupisteidenElementit()
        {
            EtupisteetLabel.Show();
            EtupisteetValue.Show();
        }

        void PiilotaEtupisteidenElementit()
        {
            EtupisteetLabel.Hide();
            EtupisteetValue.Hide();
        }


    }
}
