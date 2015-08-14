using System.Collections.Generic;
using System.Linq;

namespace Saliavustaja
{
    public abstract class Db
    {
        int viimeisinTilausnumero = 0;

        public int ViimeisinTilausnumero
        {
            get { return viimeisinTilausnumero; }
            private set { viimeisinTilausnumero = value; }
        }

        public abstract void Tallenna(Tilaus tilaus);
        public abstract Tilaus HaeTilaus(int tilausnumero);
        public abstract List<Tilaus> HaeKaikkiTilaukset();
    }
}
