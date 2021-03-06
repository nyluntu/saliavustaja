﻿using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    public abstract class TilausDbBaseTest
    {

        public abstract void KuuluisiLuodaUusiTilaus();
        public abstract void KuuluisiHakeaTilausTunnisteella();
        public abstract void KuuluisiHakeaKaikkiTilaukset();
        public abstract void KuuluisiHakeaTilausTunnisteellaMuttaPalauttaaTyhjaTilaus();

        protected List<Tilaus> LuoTilauksia()
        {
            List<Tilaus> tilaukset = new List<Tilaus>();
            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            var pihvi = new Ateria(1, "Garlic Steak", 11.60, 0.14);
            var lehtipihvi = new Ateria(2, "Lehtipihvi lohkoperunoilla", 13.60, 0.14);
            tilaus.LisaaAteria(pihvi, 1);
            tilaus.LisaaAteria(lehtipihvi, 3);
            tilaukset.Add(tilaus);

            tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(2, 4, Varaustilanne.Varattu);
            var salaatti = new Ateria(1, "Kanasalaatti", 5.60, 0.14);
            var lehtipihvi2 = new Ateria(2, "250g pihvi ranskalaisilla", 13.00, 0.14);
            tilaus.LisaaAteria(salaatti, 1);
            tilaus.LisaaAteria(lehtipihvi2, 1);
            tilaukset.Add(tilaus);

            return tilaukset;
        }

        protected Tilaus LuoTilaus(string aterianNimi = "Garlic Steak")
        {
            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            var pihvi = new Ateria(1, aterianNimi, 11.60, 0.14);
            tilaus.LisaaAteria(pihvi, 1);
            return tilaus;
        }
    }
}