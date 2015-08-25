using System;
using System.Collections;

namespace Saliavustaja.Entiteetit
{
    public class Tilaus
    {
        public int Tilausnumero { get; private set; }
        public ArrayList Tilausrivit { get; private set; }
        public Tapahtumantila TapahtumanTila { get; private set; }
        public DateTime Pvm { get; private set; }
        public Poyta Poyta { get; set; }
        public Asiakas Asiakas { get; set; }

        public Tilaus()
        {
            Tilausnumero = 0;
            Tilausrivit = new ArrayList();
            Poyta = null;
            Asiakas = null;
            TapahtumanTila = Tapahtumantila.Vahvistamaton;
            Pvm = DateTime.Now;
        }

        public Tilaus(int tilausnumero, ArrayList tilausrivit, Poyta poyta, Asiakas asiakas, Tapahtumantila tapahtumanTila, DateTime pvm)
        {
            Tilausnumero = tilausnumero;
            Tilausrivit = tilausrivit;
            Poyta = poyta;
            Asiakas = asiakas;
            TapahtumanTila = tapahtumanTila;
            Pvm = pvm;
        }

        public void LisaaAteria(Ateria ateria, int maara)
        {
            Tilausrivi rivi = new Tilausrivi(ateria, maara);
            Tilausrivit.Add(rivi);
        }

        public void PoistaAteria(Ateria ateria)
        {
            int indeksi = -1;
            foreach (Tilausrivi tilausrivi in Tilausrivit)
            {
                if (tilausrivi.Ateria.Id == ateria.Id)
                {
                    indeksi = Tilausrivit.IndexOf(tilausrivi);
                    break;
                }
            }

            if (indeksi > -1)
                Tilausrivit.RemoveAt(indeksi);
        }

        public void VaihdaAteriaMaara(Ateria ateria, int maara)
        {
            foreach (Tilausrivi tilausrivi in Tilausrivit)
            {
                if (tilausrivi.Ateria.Id == ateria.Id)
                {
                    tilausrivi.VaihdaMaara(maara);
                    break;
                }
            }
        }

        public void VahvistaTilaus()
        {
            TapahtumanTila = Tapahtumantila.Vahvistettu;
            Pvm = DateTime.Now;
        }

        public bool OnkoVahvistettu()
        {
            if (TapahtumanTila == Tapahtumantila.Vahvistettu)
                return true;
            return false;
        }

        public double LaskeVerollinenKokonaishinta()
        {
            double kokonaishinta = 0;
            foreach (Tilausrivi rivi in Tilausrivit)
                kokonaishinta += rivi.Ateria.LaskeVerollinenHinta() * rivi.Maara;

            if (Asiakas != null)
                kokonaishinta = Asiakas.LaskeHinta(kokonaishinta);

            return kokonaishinta;
        }

        public double LaskeVerotonKokonaishinta()
        {
            double kokonaishinta = 0;
            foreach (Tilausrivi rivi in Tilausrivit)
                kokonaishinta += rivi.Ateria.VerotonHinta * rivi.Maara;

            if (Asiakas != null)
                kokonaishinta = Asiakas.LaskeHinta(kokonaishinta);

            return kokonaishinta;
        }

    }


}
