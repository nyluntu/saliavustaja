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
            throw new NotImplementedException();
        }

        public override void Tallenna(BonusAsiakas asiakas)
        {
            asiakkaat[seuraavaId] = asiakas;
            seuraavaId++;
        }
    }
}
