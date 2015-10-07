using System;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// Asiakas.cs
    /// 
    /// Luokka käsittelee aterioiden tietoja. Luokan
    /// toiminnot on kuvattu tarkemmin sen metodien
    /// kuvauksissa. Aterialla on seuraavia ominaisuuksia:
    /// 
    /// 1. int Id
    /// 2. string Nimi
    /// 3. double VerotonHinta
    /// 4. readonly double ALV (Miksi tämä ei ole const -tyyppinen vakio?)
    /// </summary>
    [Serializable]
    public class Ateria
    {
        public int Id { get; private set; }
        public string Nimi { get; private set; }
        public double VerotonHinta { get; private set; }
        public readonly double Alv;

        /// <summary>
        /// Ateria(int id, string nimi, double verotonHinta, double alv)
        /// 
        /// Parametrillinen konstruktori, joka rakentaa olemassa olevista
        /// tiedoista Ateria-olion. Parametrit ovat samat kuin luokan
        /// esitellyt ominaisuudet.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nimi"></param>
        /// <param name="verotonHinta"></param>
        /// <param name="alv"></param>
        public Ateria(int id, string nimi, double verotonHinta, double alv)
        {
            Id = id;
            Nimi = nimi;
            VerotonHinta = verotonHinta;
            Alv = alv;
        }

        /// <summary>
        /// LaskeVerollinenHinta()
        /// 
        /// Metodi palauttaa aterian verollisen hinnan.
        /// Verollinen hinta lasketaan seuraavalla kaavalla:
        /// 
        /// VerotonHinta * (1 + Alv)
        /// </summary>
        /// <returns></returns>
        public double LaskeVerollinenHinta()
        {
            return VerotonHinta * (1 + Alv);
        }
        
    }
}