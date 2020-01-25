using System;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// Tilausrivi.cs
    /// 
    /// Luokka käsittelee tilausrivin tietoja. Luokan
    /// toiminnot on kuvattu tarkemmin sen metodien
    /// kuvauksissa. Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. Ateria Ateria
    /// 2. int Maara
    /// </summary>
    [Serializable]
    public class Tilausrivi
    {
        public Ateria Ateria { get; private set; }
        public int Maara { get; private set; }

        /// <summary>
        /// Tilausrivi(Ateria ateria, int maara)
        /// 
        /// Parametrillinen konstruktori, joka luo Tilausrivi-
        /// olion olemassa olevista tiedoista. Parametreina käytetään
        /// luokassa esiteltyjä ominaisuuksia.
        /// </summary>
        /// <param name="ateria"></param>
        /// <param name="maara"></param>
        public Tilausrivi(Ateria ateria, int maara)
        {
            Ateria = ateria;
            Maara = maara;
        }

        /// <summary>
        /// void VaihdaMaara(int maara)
        /// 
        /// Metodi vaihtaa olion tilaa ja asettaa määräksi
        /// sen mikä metodille annetaan parametrina.
        /// </summary>
        /// <param name="maara"></param>
        public void VaihdaMaara(int maara)
        {
            Maara = maara;
        }
    }
}
