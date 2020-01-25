using Saliavustaja.Entiteetit;
using System.Collections.Generic;

namespace Saliavustaja.Rajapinnat
{
    public abstract class BonusAsiakasDb
    {
        public abstract BonusAsiakas Hae(int asiakasnumero);
        public abstract List<BonusAsiakas> HaeKaikki();
        public abstract void Uusi(BonusAsiakas asiakas);
        public abstract void TallennaMuutokset(BonusAsiakas asiakas);
    }
}
