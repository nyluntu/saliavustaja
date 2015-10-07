using System;
using System.Collections.Generic;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// Tilaus.cs
    /// 
    /// Luokka käsittelee Tilaus-olion tapahtumia ja on yksi
    /// ohjelman toimintoja koostavista luokista. Se tarvitsee
    /// toimiakseen ohjelman muita luokkia. Luokan toiminnot
    /// on tarkemmin kuvattu sen metodien kuvauksissa.
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. int Tilausnumero
    /// 2. List<Tilausrivi> Tilausrivit
    /// 3. Tapahtumantila TapahtumanTila
    /// 4. DateTime Pvm
    /// 5. Poyta Poyta
    /// 6. Asiakas Asiakas
    /// </summary>
    [Serializable]
    public class Tilaus
    {
        public int Tilausnumero { get; private set; }
        public List<Tilausrivi> Tilausrivit { get; private set; }
        public Tapahtumantila TapahtumanTila { get; private set; }
        public DateTime Pvm { get; private set; }
        public Poyta Poyta { get; set; }
        public Asiakas Asiakas { get; set; }

        /// <summary>
        /// Tilaus()
        /// 
        /// Parametriton rakentaja. Rakentaja alustaa Tilaus-tyyppisen
        /// olion alkuarvoilla, jotka ovat esitelty seuraavaksi.
        /// 
        /// Tilausnumero = 0;
        /// Tilausrivit = new List<Tilausrivi>();
        /// Poyta = null;
        /// Asiakas = null;
        /// TapahtumanTila = Tapahtumantila.Vahvistamaton;
        /// Pvm = DateTime.Now;
        /// </summary>
        public Tilaus()
        {
            Tilausnumero = 0;
            Tilausrivit = new List<Tilausrivi>();
            Poyta = null;
            Asiakas = null;
            TapahtumanTila = Tapahtumantila.Vahvistamaton;
            Pvm = DateTime.Now;
        }

        /// <summary>
        /// Tilaus(int tilausnumero, List<Tilausrivi> tilausrivit, 
        ///     Poyta poyta, Asiakas asiakas, 
        ///     Tapahtumantila tapahtumanTila, DateTime pvm)
        /// 
        /// Parametrillinen konstruktori luo Tilaus-tyyppisen olion
        /// sille annetuista alkuarvoista. Parametrit ovat samoja kuin
        /// luokan ominaisuudet.
        /// </summary>
        /// <param name="tilausnumero"></param>
        /// <param name="tilausrivit"></param>
        /// <param name="poyta"></param>
        /// <param name="asiakas"></param>
        /// <param name="tapahtumanTila"></param>
        /// <param name="pvm"></param>
        public Tilaus(int tilausnumero, List<Tilausrivi> tilausrivit, Poyta poyta, Asiakas asiakas, Tapahtumantila tapahtumanTila, DateTime pvm)
        {
            Tilausnumero = tilausnumero;
            Tilausrivit = tilausrivit;
            Poyta = poyta;
            Asiakas = asiakas;
            TapahtumanTila = tapahtumanTila;
            Pvm = pvm;
        }

        /// <summary>
        /// void LisaaAteria(Ateria ateria, int maara)
        /// 
        /// Metodi lisää tilaukseen tilausrivin, joka sisältää
        /// parametrina annetun aterian ja määrän.
        /// </summary>
        /// <param name="ateria"></param>
        /// <param name="maara"></param>
        public void LisaaAteria(Ateria ateria, int maara)
        {
            Tilausrivi rivi = new Tilausrivi(ateria, maara);
            Tilausrivit.Add(rivi);
        }

        /// <summary>
        /// void PoistaAteria(Ateria ateria)
        /// 
        /// Metodi poistaa tilauksen tilausrivistä parametrina
        /// annetun aterian. Aterialla on tunnus, jota verrataan
        /// tilausriveissä oleviin aterioihin.
        /// </summary>
        /// <param name="ateria"></param>
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

        /// <summary>
        /// void VaihdaAteriaMaara(Ateria ateria, int maara)
        /// 
        /// Metodi muuttaa aterian määrää tilauksessa. Tilausrivistä
        /// etsitään aterian tunnuksella oikea rivi ja sen määrää
        /// muutetaan.
        /// </summary>
        /// <param name="ateria"></param>
        /// <param name="maara"></param>
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

        /// <summary>
        /// void VahvistaTilaus()
        /// 
        /// Metodi muuttaa Tilaus-olion tilaa siten, että merkitsee
        /// tilauksen vahvistetuksi ja asettaa päivämääräksi sen
        /// hetkisen ajanhetken.
        /// </summary>
        public void VahvistaTilaus()
        {
            TapahtumanTila = Tapahtumantila.Vahvistettu;
            Pvm = DateTime.Now;
        }

        /// <summary>
        /// bool OnkoVahvistettu()
        /// 
        /// Metodi tarkistaa, onko tapahtuman tila vahvistettu.
        /// Jos on niin palauttaa true, muussa tapauksessa
        /// palautetaan arvo false.
        /// </summary>
        /// <returns></returns>
        public bool OnkoVahvistettu()
        {
            if (TapahtumanTila == Tapahtumantila.Vahvistettu)
                return true;
            return false;
        }

        /// <summary>
        /// double LaskeVerollinenKokonaishinta()
        /// 
        /// Metodi laskee ja palauttaa tilauksen verollisen kokonaishinnan.
        /// Kokonaishinta lasketaan siten, että tilausrivit käydään läpi
        /// ja niiden summat aterioiden määrän mukaan lasketaan kaikki yhteen.
        /// 
        /// Jos Asiakas-tyyppinen olio on määritetty tilaukseen niin lasketaan
        /// asiakkaalle hinta. Hinta voi vaihdella, jos kyseessä on bonusasiakas.
        /// 
        /// Lopuksi metodi palauttaa verollisen kokonaishinnan.
        /// </summary>
        /// <returns></returns>
        public double LaskeVerollinenKokonaishinta()
        {
            double kokonaishinta = 0;
            foreach (Tilausrivi rivi in Tilausrivit)
                kokonaishinta += rivi.Ateria.LaskeVerollinenHinta() * rivi.Maara;

            if (Asiakas != null)
                kokonaishinta = Asiakas.LaskeHinta(kokonaishinta);

            return kokonaishinta;
        }

        /// <summary>
        /// double LaskeVerotonKokonaishinta()
        /// 
        /// Metodi laskee ja palauttaa tilauksen verottoman kokonaishinnan.
        /// Kokonaishinta lasketaan siten, että tilausrivit käydään läpi
        /// ja niiden summat aterioiden määrän mukaan lasketaan kaikki yhteen.
        /// 
        /// Jos Asiakas-tyyppinen olio on määritetty tilaukseen niin lasketaan
        /// asiakkaalle hinta. Hinta voi vaihdella, jos kyseessä on bonusasiakas.
        /// 
        /// Lopuksi metodi palauttaa verottoman kokonaishinnan.
        /// </summary>
        /// <returns></returns>
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
