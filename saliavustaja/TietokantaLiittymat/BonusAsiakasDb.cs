using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja.TietokantaLiittymat
{
    public abstract class BonusAsiakasDb
    {
        public abstract BonusAsiakas Hae(int asiakasnumero);
        public abstract List<BonusAsiakas> HaeKaikki();
        public abstract void Tallenna(BonusAsiakas asiakas);
    }
}
