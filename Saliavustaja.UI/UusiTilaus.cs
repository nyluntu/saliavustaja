using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Saliavustaja.UI
{
    public partial class UusiTilaus : Form
    {

        Tilaus tilaus = new Tilaus();
        TilausDb tilausLiittyma = new InMemoryTilausDb();
        PoytaDb poytaLiittyma = new InMemoryPoytaDb();
        AteriaDb ateriaLiittyma = new InMemoryAteriaDb();

        public UusiTilaus()
        {
            InitializeComponent();
            LisaaPoydatPudotusvalikkoon();
            LisaaAteriatListaValikkoon();
            LisaaTilaukseenAsiakas();
        }

        void LisaaPoydatPudotusvalikkoon()
        {
            List<Poyta> poydat = poytaLiittyma.HaeKaikki();
            foreach (Poyta poyta in poydat)
            {
                PoydatCombobox.Items.Add(poyta);
            }
        }

        void LisaaAteriatListaValikkoon()
        {
            List<Ateria> ateriat = ateriaLiittyma.HaeKaikki();
            foreach (var ateria in ateriat)
            {
                ListViewItem rivi = new ListViewItem(ateria.Nimi);
                rivi.Tag = ateria;
                rivi.SubItems.Add(ateria.LaskeVerollinenHinta(0.14).ToString("C2"));
                AteriatListView.Items.Add(rivi);
            }
        }

        void LisaaAteriaButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AteriatListView.SelectedItems.Count; i++)
            {
                Ateria ateria = (Ateria)AteriatListView.SelectedItems[i].Tag;
                DataGridViewRow rivi = new DataGridViewRow();
                rivi.CreateCells(AteriatDataGridView);
                rivi.Tag = ateria;
                rivi.SetValues(ateria.Nimi, ateria.LaskeVerollinenHinta(0.14).ToString("C2"), 0);
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

        void PeruTilausButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void VahvistaTilausButton_Click(object sender, EventArgs e)
        {
            try
            {
                TilauksenVastaanotto tilauksenVastaanotto = new TilauksenVastaanotto(tilausLiittyma, poytaLiittyma);
                tilauksenVastaanotto.VastaanotaTilaus(tilaus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void AteriatDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Ateria ateria = (Ateria)AteriatDataGridView.Rows[e.RowIndex].Tag;
                int maara = int.Parse(AteriatDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                tilaus.VaihdaAterianMaara(ateria, maara);

                KokonaishintaValue.Text = tilaus.LaskeVerollinenKokonaishinta().ToString("C2");
                VerotonKokonaishintaValue.Text = tilaus.LaskeVerotonKokonaishinta().ToString("C2");
                VeronosuusValue.Text = (tilaus.LaskeVerollinenKokonaishinta() - tilaus.LaskeVerotonKokonaishinta()).ToString("C2");
            }
        }

        void PoydatCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Poyta valittuPoyta = (Poyta)PoydatCombobox.SelectedItem;
            tilaus.Poyta = valittuPoyta;
        }

        void BonusAsiakasCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LisaaTilaukseenAsiakas();
            KokonaishintaValue.Text = tilaus.LaskeVerollinenKokonaishinta().ToString("C2");
            VerotonKokonaishintaValue.Text = tilaus.LaskeVerotonKokonaishinta().ToString("C2");
            VeronosuusValue.Text = (tilaus.LaskeVerollinenKokonaishinta() - tilaus.LaskeVerotonKokonaishinta()).ToString("C2");
        }

        void LisaaTilaukseenAsiakas()
        {
            if (BonusAsiakasCheckbox.Checked)
                tilaus.Asiakas = new BonusAsiakas();
            else
                tilaus.Asiakas = new Asiakas();
        }
    }
}
