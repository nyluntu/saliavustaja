using System;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;

namespace Saliavustaja
{
    /// <summary>
    /// TilauksenVastaanotto.cs
    /// 
    /// Luokan tarkoitus on hoitaa tilauksen käsittely ja tarkistaa käyttäjän
    /// antaman syötteet. Luokka ei toteuta muita toimintoja kuin tilauksen
    /// vastaanottoon liittyvät toimenpiteet. Tilauksen vastaanotossa tapahtuvat
    /// vaiheet on kuvattu metodin kuvauksessa.
    /// 
    /// Luokalla on kolme ominaisuutta:
    /// 
    /// 1. TilausDb tilausDb
    /// 2. PoytaDb poytaDb
    /// 3. BonusAsiakasDb asiakasDb
    /// </summary>
    public class TilauksenVastaanotto
    {
        TilausDb tilausDb;
        PoytaDb poytaDb;
        BonusAsiakasDb asiakasDb;

        /// <summary>
        /// TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb)
        /// 
        /// Luokalla on parametrillinen konstruktori, joka ottaa vastaan kaksi
        /// tietokantaa käsittelevää oliota. Tietokantaa käsittelevät oliot
        /// ovat:
        /// 
        /// 1. TilausDb
        /// 2. PoytaDb
        /// </summary>
        /// <param name="tilausDb"></param>
        /// <param name="poytaDb"></param>
        public TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb)
        {
            this.tilausDb = tilausDb;
            this.poytaDb = poytaDb;
            this.asiakasDb = null;
        }

        /// <summary>
        /// TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb, BonusAsiakasDb asiakasDb)
        /// 
        /// Luokalla on parametrillinen konstruktori, joka ottaa vastaan kolme
        /// tietokantaa käsittelevää oliota. Tietokantaa käsittelevät oliot
        /// ovat:
        /// 
        /// 1. TilausDb
        /// 2. PoytaDb 
        /// 3. BonusAsiakasDb
        /// </summary>
        /// <param name="tilausDb"></param>
        /// <param name="poytaDb"></param>
        /// <param name="asiakasDb"></param>
        public TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb, BonusAsiakasDb asiakasDb)
            :this(tilausDb, poytaDb)
        {
            this.asiakasDb = asiakasDb;
        }

        /// <summary>
        /// VastaanotaTilaus(Tilaus tilaus)
        /// 
        /// Metodi suorittaa toimenpiteitä, joita tehdään ennen ja jälkeen
        /// tilauksen vahvistamisen. VastaanotaTilaus -metodi koostaa ohjelman
        /// muiden olioiden toimintoja yhteen. Suoritettavat toimenpiteet ovat
        /// seuraavat:
        /// 
        /// 1.  Metodi saa tilauksen tiedot sille annetusta parametrista.
        /// 
        /// 2.  Tarkistetaan tiedot virhesyötteiden varalta. Virhetilanteen
        ///     sattuessa tilausta ei vahvisteta ja siitä luodaan virheilmoitus.
        ///     Virheen sattuessa se siepataan virheenkäsittelyllä ja annetaan
        ///     metodia kutsuttavan luokan hoitaa sen käsittely.
        ///     
        ///     2.1 VIRHE: Tilausrivien määrä on 0 tai alle.
        ///     2.2 VIRHE: Tilaukseen ei ole määritetty asiakasta.
        ///     2.3 VIRHE: Tilaukseen ei ole määritetty pöytää.
        ///     2.4 VIRHE: Valitty pöytä on jo varattu.
        ///     2.5 VIRHE: Tilaus epäonnistuu muusta kuin yllämainituista syistä.
        /// 
        /// 3. Vahvistetaan tilaus.
        /// 4. Luodaan uusi tilaus tietokantaan.
        /// 5. Merkitään pöytä varatuksi.
        /// 6. Tarkistetaan onko asiakas bonusasiakas
        ///     6.1 Jos on bonusasiakas, kerrytetään etupisteitä ja
        ///         tallennetaan bonusasiakkaan tiedot tietokantaan.
        /// </summary>
        /// <param name="tilaus"></param>
        public void VastaanotaTilaus(Tilaus tilaus)
        {
            try
            {
                if (tilaus.Tilausrivit.Count <= 0)
                    throw new Exception("Tilaus ei sisällä tilausrivejä.");

                if (tilaus.Asiakas == null)
                    throw new Exception("Tilaus ei sisällä asiakasta.");

                if (tilaus.Poyta == null)
                    throw new Exception("Pöytää ei ole valittu. Tilausta ei voitu vahvistaa.");

                Poyta poyta = poytaDb.Hae(tilaus.Poyta.Id);
                if (poyta.OnkoVarattu())
                    throw new Exception("Pöytä on jo varattu. Tilausta ei voitu vahvistaa.");

                tilaus.VahvistaTilaus();
                tilausDb.Uusi(tilaus);

                poytaDb.VaraaPoyta(poyta.Id);

               if(tilaus.Asiakas.GetType() == typeof(BonusAsiakas))
                {
                    BonusAsiakas asiakas = (BonusAsiakas)tilaus.Asiakas;
                    asiakas.KerrytaEtupisteita(tilaus.LaskeVerollinenKokonaishinta());
                    asiakasDb.Uusi(asiakas);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}