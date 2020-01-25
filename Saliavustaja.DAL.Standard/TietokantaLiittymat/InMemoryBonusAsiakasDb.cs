using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using System.Collections;
using System.Collections.Generic;

namespace Saliavustaja.TietokantaLiittymat
{
    /// <summary>
    /// InMemoryBonusAsiakasDb.cs
    /// 
    /// Luokka käsittelee tietokantayhteyksiä Bonusasiakas-luokan
    /// olioiden osalta.
    /// 
    /// HUOMAA ETTÄ KYSEESSÄ ON MUISTINVARAINEN TIETOKANTATOTEUTUS!
    /// TOTEUTUSTAPAAN VOIT KYSYÄ NEUVOA.
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. Hashtable asiakkaat
    /// 2. static int seuraavaId = 1
    /// </summary>
    public class InMemoryBonusAsiakasDb : BonusAsiakasDb
    {

        static int seuraavaId = 1;
        protected Hashtable asiakkaat = new Hashtable();

        /// <summary>
        /// BonusAsiakas Hae(int asiakasnumero)
        /// 
        /// Metodi palauttaa tietokannasta (Hashtable) bonusasiakkaan
        /// käyttäen metodille parametrina annettua asiakkaan tunnusta.
        /// 
        /// TÄTÄ METODIA EI OLE KÄYTETTY MISSÄÄN
        /// </summary>
        /// <param name="asiakasnumero"></param>
        /// <returns></returns>
        public override BonusAsiakas Hae(int asiakasnumero)
        {
            BonusAsiakas asiakas = (BonusAsiakas)asiakkaat[asiakasnumero];
            if (asiakas != null)
                asiakas = new BonusAsiakas(asiakasnumero, asiakas.Etupisteet);
            return asiakas;
        }

        /// <summary>
        /// List<BonusAsiakas> HaeKaikki()
        /// 
        /// Metodi palauttaa kaikki bonusasiakkaat tietokannasta (Hashtable)
        /// listana, joka sisältää Bonusasiakas-luokan olioita.
        /// 
        /// TÄTÄ METODIA EI OLE KÄYTETTY MISSÄÄN
        /// </summary>
        /// <returns></returns>
        public override List<BonusAsiakas> HaeKaikki()
        {
            List<BonusAsiakas> kaikkiAsiakkaat = new List<BonusAsiakas>();
            for (int i = 1; i <= asiakkaat.Count; i++)
            {
                BonusAsiakas asiakas = (BonusAsiakas)asiakkaat[i];
                kaikkiAsiakkaat.Add(new BonusAsiakas(asiakas.Id, asiakas.Etupisteet));
            }
            return kaikkiAsiakkaat;
        }

        /// <summary>
        /// void TallennaMuutokset(BonusAsiakas asiakas)
        /// 
        /// Metodi tallentaa Bonusasiakkaan tietojen muutokset 
        /// tietokantaan. (hashtable)
        /// 
        /// TÄTÄ METODIA EI OLE KÄYTETTY MISSÄÄN
        /// </summary>
        /// <param name="asiakas"></param>
        public override void TallennaMuutokset(BonusAsiakas asiakas)
        {
            asiakkaat[asiakas.Id] = asiakas;
        }

        /// <summary>
        /// void Uusi(BonusAsiakas asiakas)
        /// 
        /// Metodi lisää uuden Bonusasiakkaan tiedot tietokantaan. (hashtable)
        /// </summary>
        /// <param name="asiakas"></param>
        public override void Uusi(BonusAsiakas asiakas)
        {
            asiakkaat[seuraavaId] = asiakas;
            seuraavaId++;
        }
    }
}
