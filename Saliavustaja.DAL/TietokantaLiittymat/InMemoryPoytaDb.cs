using System.Collections;
using System.Collections.Generic;
using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;

namespace Saliavustaja.TietokantaLiittymat
{
    /// <summary>
    /// InMemoryPoytaDb.cs
    /// 
    /// Luokka käsittelee tietokantayhteyksiä Poyta-luokan
    /// olioiden osalta.
    /// 
    /// HUOMAA ETTÄ KYSEESSÄ ON MUISTINVARAINEN TIETOKANTATOTEUTUS!
    /// TOTEUTUSTAPAAN VOIT KYSYÄ NEUVOA.
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. Hashtable poydat
    /// </summary>
    public class InMemoryPoytaDb : PoytaDb
    {
        Hashtable poydat = new Hashtable();

        /// <summary>
        /// InMemoryPoytaDb()
        /// 
        /// Parametriton rakenta. Tietokant (Hashtable)a alustetaan 
        /// pöytien tiedoilla, joilla voidaan kokeilla ohjelman toimintoja.
        /// </summary>
        public InMemoryPoytaDb()
        {
            poydat.Add(1, new Poyta(1, 4, Varaustilanne.Vapaa));
            poydat.Add(2, new Poyta(2, 2, Varaustilanne.Vapaa));
            poydat.Add(3, new Poyta(3, 2, Varaustilanne.Vapaa));
            poydat.Add(4, new Poyta(4, 6, Varaustilanne.Vapaa));
            poydat.Add(5, new Poyta(5, 10, Varaustilanne.Vapaa));
            poydat.Add(6, new Poyta(6, 10, Varaustilanne.Vapaa));
            poydat.Add(7, new Poyta(7, 4, Varaustilanne.Vapaa));
            poydat.Add(8, new Poyta(8, 4, Varaustilanne.Vapaa));
            poydat.Add(9, new Poyta(9, 4, Varaustilanne.Vapaa));
            poydat.Add(10, new Poyta(10, 4, Varaustilanne.Vapaa));
        }

        /// <summary>
        /// Poyta Hae(int tunnus)
        /// 
        /// Metodi palauttaa tietokannasta (hashtable) pöydän
        /// parametrina annetun pöydän tunnuksen mukaan.
        /// </summary>
        /// <param name="tunnus"></param>
        /// <returns></returns>
        public override Poyta Hae(int tunnus)
        {
            return (Poyta)poydat[tunnus];
        }

        /// <summary>
        /// List<Poyta> HaeKaikki()
        /// 
        /// Metodi palauttaa tietokannasta (hashtable) kaikki 
        /// pöydät listana, joka sisältää Poyta-olioita.
        /// </summary>
        /// <returns></returns>
        public override List<Poyta> HaeKaikki()
        {
            List<Poyta> kaikkiPoydat = new List<Poyta>();
            for (int i = 1; i <= poydat.Count; i++)
            {
                Poyta poyta = (Poyta)poydat[i];
                kaikkiPoydat.Add(poyta);
            }
            return kaikkiPoydat;
        }

        /// <summary>
        /// void VaraaPoyta(int tunnus)
        /// 
        /// Metodi hakee tietokannasta (hashtable) pöydän parametrina
        /// annetulla pöydän tunnuksella ja muuttaa pöydän tilan 
        /// varatuksi.
        /// </summary>
        /// <param name="tunnus"></param>
        public override void VaraaPoyta(int tunnus)
        {
            Poyta poyta = (Poyta)poydat[tunnus];
            poyta.VaraaPoyta();
        }
    }
}