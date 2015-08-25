using System;
using Saliavustaja.TietokantaLiittymat;
using Saliavustaja.Entiteetit;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        TilausDb tilausDb;
        PoytaDb poytaDb;
        BonusAsiakasDb asiakasDb;

        public TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb)
        {
            this.tilausDb = tilausDb;
            this.poytaDb = poytaDb;
            this.asiakasDb = null;
        }

        public TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb, BonusAsiakasDb asiakasDb)
            :this(tilausDb, poytaDb)
        {
            this.asiakasDb = asiakasDb;
        }

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