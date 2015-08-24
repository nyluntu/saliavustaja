using System;
using System.Collections;
using System.Collections.Generic;

namespace Saliavustaja.TietokantaLiittymat
{
    public class InMemoryBonusAsiakasDb : BonusAsiakasDb
    {

        static int seuraavaId = 1;
        protected Hashtable asiakkaat = new Hashtable();

        public override BonusAsiakas Hae(int asiakasnumero)
        {
            BonusAsiakas asiakas = (BonusAsiakas)asiakkaat[asiakasnumero];
            if (asiakas != null)
                asiakas = new BonusAsiakas(asiakasnumero, asiakas.Etupisteet);
            return asiakas;
        }

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

        public override void TallennaMuutokset(BonusAsiakas asiakas)
        {
            asiakkaat[asiakas.Id] = asiakas;
        }

        public override void Uusi(BonusAsiakas asiakas)
        {
            asiakkaat[seuraavaId] = asiakas;
            seuraavaId++;
        }
    }
}
