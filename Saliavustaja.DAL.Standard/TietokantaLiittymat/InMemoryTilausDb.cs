using System.Collections;
using System.Collections.Generic;
using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;

namespace Saliavustaja.TietokantaLiittymat
{
    /// <summary>
    /// InMemoryTilausDb.cs
    /// 
    /// Luokka käsittelee tietokantayhteyksiä Tilaus-luokan
    /// olioiden osalta.
    /// 
    /// HUOMAA ETTÄ KYSEESSÄ ON MUISTINVARAINEN TIETOKANTATOTEUTUS!
    /// TOTEUTUSTAPAAN VOIT KYSYÄ NEUVOA.
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. Hashtable tilaukset
    /// 2. static int seuraavaId = 1
    /// </summary>
    public class InMemoryTilausDb : TilausDb
    {
        protected static int seuraavaId = 1;
        protected Hashtable tilaukset = new Hashtable();

        public int SeuraavaId
        {
            get { return seuraavaId; }
        }

        /// <summary>
        /// void Uusi(Tilaus tilaus)
        /// 
        /// Metodi tallentaa tilauksen tietokantaan (Hashtable).
        /// Parametrina annetaan koko tilaus -olio, joka sisältää tiedot
        /// tilauksesta. 
        /// </summary>
        /// <param name="tilaus"></param>
        public override void Uusi(Tilaus tilaus)
        {
            tilaukset[seuraavaId] = tilaus;
            seuraavaId++;
        }

        /// <summary>
        /// Tilaus Hae(int tilausnumero)
        /// 
        /// TÄTÄ METODIA EI OLE KÄYTETTY MISSÄÄN
        /// </summary>
        /// <param name="tilausnumero"></param>
        /// <returns></returns>
        public override Tilaus Hae(int tilausnumero)
        {
            Tilaus tilaus = (Tilaus)tilaukset[tilausnumero];

            if (tilaus == null)
                return null; 

            return new Tilaus(tilausnumero, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm);
        }

        /// <summary>
        /// List<Tilaus> HaeKaikki()
        /// 
        /// Metodi palauttaa kaikki tietokannan (hashtable) sisällön
        /// listana, joka sisältää Tilaus-olioita.
        /// </summary>
        /// <returns></returns>
        public override List<Tilaus> HaeKaikki()
        {
            List<Tilaus> kaikkiTilaukset = new List<Tilaus>();
            for (int i = 1; i <= tilaukset.Count; i++)
            {
                Tilaus tilaus = (Tilaus)tilaukset[i];
                kaikkiTilaukset.Add(new Tilaus(i, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm));
            }
            return kaikkiTilaukset;
        }
    }
}
