using System;
using System.Collections;

namespace Saliavustaja
{
    public class Tilaus
    {
        int tilausnumero;
        ArrayList tilausrivit;
        Poyta poyta;
        Asiakas asiakas;
        TapahtumanTila tapahtumanTila;
        DateTime pvm;

        public Tilaus()
        {
            tilausnumero = 0;
            tilausrivit = new ArrayList();
            poyta = null;
            asiakas = null;
            tapahtumanTila = TapahtumanTila.Vahvistamaton;
            pvm = DateTime.Now;
        }

        public Tilaus(int tilausnumero, ArrayList tilausrivit, Poyta poyta, Asiakas asiakas, TapahtumanTila tapahtumanTila, DateTime pvm)
        {
            this.tilausnumero = tilausnumero;
            this.tilausrivit = tilausrivit;
            this.poyta = poyta;
            this.asiakas = asiakas;
            this.tapahtumanTila = tapahtumanTila;
            this.pvm = pvm;
        }

        public int Tilausnumero
        {
            get { return tilausnumero; }
            set { tilausnumero = value; }
        }

        public ArrayList Tilausrivit
        {
            get { return tilausrivit; }
        }

        public Poyta Poyta
        {
            get { return poyta; }
            set { poyta = value; }
        }

        public Asiakas Asiakas
        {
            get { return asiakas; }
            set { asiakas = value; }
        }

        public DateTime Pvm
        {
            get { return pvm; }
            set { pvm = value; }
        }

        public void LisaaAteria(Ateria ateria, int maara)
        {
            Tilausrivi rivi = new Tilausrivi(ateria, maara);
            tilausrivit.Add(rivi);
        }

        public void Vahvista()
        {
            tapahtumanTila = TapahtumanTila.Vahvistettu;
        }

        public bool OnkoVahvistettu()
        {
            if (tapahtumanTila == TapahtumanTila.Vahvistettu)
                return true;
            return false;
        }

        public double LaskeKokonaishinta()
        {
            double kokonaishinta = 0;
            foreach (Tilausrivi rivi in tilausrivit)
                kokonaishinta += rivi.Ateria.VerotonHinta * rivi.Maara * 1.14;

            if (asiakas != null)
                kokonaishinta = asiakas.LaskeAsiakkaanEtuhinta(kokonaishinta);

            return kokonaishinta;
        }
    }

   
}
