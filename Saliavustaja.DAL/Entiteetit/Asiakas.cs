using System;

namespace Saliavustaja.Entiteetit
{
    /// <summary>
    /// Asiakas.cs
    /// 
    /// Luokka käsittelee asiakkaalle tapahtuvia toimenpiteitä.
    /// Luokan tarkemmat toiminnot on kuvattu sen metodien kuvauksissa.
    /// Asiakkaalla on kaksi ominaisuutta, joista toinen on vakio:
    /// 
    /// 1. bool etukuponki
    /// 2. const double ETUKERROIN
    /// </summary>
    [Serializable]
    public class Asiakas
    {
        protected bool etukuponki = false;
        const double ETUKERROIN = 0.85;

        /// <summary>
        /// LaskeHinta(double tilauksenhinta)
        /// 
        /// Metodi laskee asiakkaalle tilauksen hinnan seuraavin
        /// ehdoin:
        /// 
        /// 1.  Jos asiakkaalla on etukuponki, metodi palauttaa
        ///     hinnan, joka on laskettu kaavalla 
        ///     "tilauksenhinta * ETUKERROIN"
        /// 2.  Jos asiakkaalla ei ole etukuponkia, palautetaan
        ///     alkuperäinen hinta sellaisenaan.
        /// </summary>
        /// <param name="tilauksenhinta"></param>
        /// <returns></returns>
        public double LaskeHinta(double tilauksenhinta)
        {
            if (etukuponki)
                return tilauksenhinta * ETUKERROIN;

            return tilauksenhinta;
        }
    }
}