using System;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// Poyta.cs
    /// 
    /// Luokka käsittelee ohjelmassa esiintyvien pöytien tietoja.
    /// Luokan toimintojen tarkempi kuvaus löytyy sen metodien
    /// kuvauksista. 
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. int Id
    /// 2. int PaikkojenMaara
    /// 3. Varaustilanne Varaustilanne (enum? miksi hyvä käyttää?)
    /// </summary>
    [Serializable]
    public class Poyta
    {
        public int Id { get; private set; }
        public int PaikkojenMaara { get; private set; }
        public Varaustilanne Varaustilanne { get; private set; }

        /// <summary>
        /// Poyta(int tunnus, int paikkojenMaara, Varaustilanne varattu)
        /// 
        /// Parametrillinen konstruktori, joka rakentaa Poyta-tyyppisen
        /// olion olemassa olevista tiedoista. Parametreina annetaan
        /// luokassa esitellyt ominaisuudet.
        /// </summary>
        /// <param name="tunnus"></param>
        /// <param name="paikkojenMaara"></param>
        /// <param name="varattu"></param>
        public Poyta(int tunnus, int paikkojenMaara, Varaustilanne varattu)
        {
            Id = tunnus;
            PaikkojenMaara = paikkojenMaara;
            Varaustilanne = varattu;
        }

        /// <summary>
        /// void VaraaPoyta()
        /// 
        /// Metodi muuttaa olion tilaa siten, että merkitsee
        /// pöydän varaustilaneen varatuksi.
        /// </summary>
        public void VaraaPoyta()
        {
            Varaustilanne = Varaustilanne.Varattu;
        }

        /// <summary>
        /// void VapautaPoyta()
        /// 
        /// Metodi muuttaa olion tilaa siten, että merkitsee
        /// pöydän varaustilanteen vapaaksi.
        /// </summary>
        public void VapautaPoyta()
        {
            Varaustilanne = Varaustilanne.Vapaa;
        }

        /// <summary>
        /// bool OnkoVarattu()
        /// 
        /// Metodi tarkistaa onko pöytä varattu. Jos pöytä
        /// on varattu, palauttaa se arvon true. Muussa
        /// tapauksessa palautetaan arvo false.
        /// </summary>
        /// <returns></returns>
        public bool OnkoVarattu()
        {
            if (Varaustilanne == Varaustilanne.Varattu)
                return true;

            return false;
        }

        /// <summary>
        /// override string ToString()
        /// 
        /// Ei esitellä tehtävässä. Tulee vastaan kohta, jossa hyödyllinen
        /// ja pyritään katsomaan kuka hoksaa käyttää.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Pöytä {0}, paikkoja {1}, {2}", Id, PaikkojenMaara, Varaustilanne.ToString().ToUpper());
        }


    }
}
