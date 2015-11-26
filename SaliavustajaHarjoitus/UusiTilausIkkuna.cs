﻿using Saliavustaja.Entiteetit;
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
            LisaaAteriatListalle();
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

        private void LisaaAteriatListalle()
        {
            AteriaDb ateriaDb = new InMemoryAteriaDb();

            List<Ateria> ateriat = ateriaDb.HaeKaikki();

            foreach (Ateria ateria in ateriat)
            {
                ListViewItem rivi = new ListViewItem(ateria.Nimi);
                rivi.Tag = ateria;
                rivi.SubItems.Add(ateria.LaskeVerollinenHinta().ToString("C2"));

                listViewAteriat.Items.Add(rivi);
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
            }
        }

        private void buttonPoistaAteria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewAteriat.SelectedRows.Count; i++)
            {
                DataGridViewRow poistettavaRivi = dataGridViewAteriat.SelectedRows[i];
                dataGridViewAteriat.Rows.Remove(poistettavaRivi);
            }
        }
    }
}
