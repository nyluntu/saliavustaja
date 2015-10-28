using System;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// BonusAsiakas.cs
    /// 
    /// Luokka periytyy Asiakas.cs luokasta ja omii perittävän
    /// luokan ominaisuudet ja toiminnot. BonusAsiakas -luokka
    /// laajentaa alkuperäistä Asiakas-luokkaa siten, että sitä
    /// voidaan käyttää bonusasiakkaan tietojen tallentamiseen.
    /// Bonusasiakkaasta tahdotaan tehdä aina merkintä tietokantaan.
    /// 
    /// Bonusasiakkaan toiminnot on kuvattu tarkemmin metodien
    /// kuvauksissa.
    /// 
    /// Bonusasiakkaalla on kaksi ominaisuutta:
    /// 
    /// 1. int Id
    /// 2. double Etupisteet
    /// </summary>
    [Serializable]
    public class BonusAsiakas : Asiakas
    {
        public int Id { get; private set; }
        public double Etupisteet { get; private set; }

        /// <summary>
        /// BonusAsiakas()
        /// 
        /// Parametriton rakentaja, jossa määritetään
        /// alustusarvot bonusasiakkaan ominaisuuksille
        /// seuraavasti:
        /// 
        /// Id = 0
        /// Etupisteet = 0
        /// etukuponki = true (Mistä etukuponki ominaisuus tulee?)
        /// </summary>
        public BonusAsiakas()
        {
            Id = 0;
            Etupisteet = 0.0;
            etukuponki = true;
        }

        /// <summary>
        /// BonusAsiakas(int id, double etupisteet)
        /// 
        /// Parametrillinen rakentaja, jota käytetään bonusasiakkaan
        /// tietojen käsittelyyn kun se luodaan olemassaolevien
        /// tietojen pohjalta. Etukuponki määritetään päälle
        /// aina bonusasiakkaan parametrillisessa rakentajassa.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="etupisteet"></param>
        public BonusAsiakas(int id, double etupisteet)
        {
            Id = id;
            Etupisteet = etupisteet;
            etukuponki = true;
        }

        /// <summary>
        /// LaskeEtupisteet(double hinta)
        /// 
        /// Metodi palauttaa etupisteiden määrän sille
        /// annetusta hinta-parametrin mukaan. Etupisteiden
        /// laskemiseen käytetään seuraavaa yksinkertaista
        /// kaavaa:
        /// 
        /// Math.Round(hinta / 50, 1); 
        /// (mitä math round tekee ja mitä tarkoittaa pilkun 
        /// jälkeen numero 1?)
        /// </summary>
        /// <param name="hinta"></param>
        /// <returns></returns>
        public double LaskeEtupisteet(double hinta)
        {
            return Math.Round(hinta / 50, 1);
        }

        /// <summary>
        /// KerrytaEtupisteita(double hinta)
        /// 
        /// Metodi kasvattaa bonusasiakkaan etupisteitä mutta
        /// ei palauta mitään arvoa.
        /// </summary>
        /// <param name="hinta"></param>
        public void KerrytaEtupisteita(double hinta)
        {
            Etupisteet += LaskeEtupisteet(hinta);
        }

        /// <summary>
        /// OstaEtupisteilla(double hinta)
        /// 
        /// Metodi vähentää bonusasiakkaan etupisteitä
        /// sen mukaan minkä suuruisen loppusumman etupisteillä
        /// maksetaan. Etupisteet ovat suoraanverrannollisia
        /// hintaan.
        /// 
        /// 1.  Jos etupisteitä jää yli, ne jäävät bonusasiakkaalle.
        /// 2.  Jos etupisteet menevät alle nollan, maksettavaksi jää
        ///     itseisarvon verran erotuksesta. Tämän jälkeen etupisteet nollataan.
        /// 
        /// (Positiivisen reaaliluvun ja nollan itseisarvo on luku itse, 
        /// negatiivisen reaaliluvun itseisarvo on luvun vastaluku eli 
        /// luku kerrottuna luvulla −1. Esimerkiksi luvun kolme itseisarvo 
        /// merkitään |3| ja se on 3. Miinus kahden itseisarvo puolestaan 
        /// on kaksi, |-2| = 2. Helpoiten negatiivisen lukuarvon itseisarvon 
        /// saa lasketuksi poistamalla miinusmerkin.)
        /// </summary>
        /// <param name="hinta"></param>
        /// <returns></returns>
        // OstaEtupisteillä toimintoa ei ole hyödynnetty toistaiseksi ohjelmassa.
        public double OstaEtupisteilla(double hinta)
        {
            // Jos erotus yli 0, pisteitä jää erotuksen verran.
            // Jos erotus alle 0, maksettavaksi jää erotuksen verran
            // ja etupisteet nollataan.
            // Etupisteillä voi maksaa vastaavan summan euroja.
            double erotus = Etupisteet - hinta;
            Etupisteet = erotus;

            if (erotus >= 0)
                return 0;

            Etupisteet = 0;
            return Math.Abs(erotus);
        }
    }
}
