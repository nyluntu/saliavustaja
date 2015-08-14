using System.Collections.Generic;
using System.Linq;

namespace Saliavustaja
{
    public class Db
    {
        int viimeisinTilausnumero = 0;
        List<Tilaus> tilaukset = SingletonList.Instance;

        public int ViimeisinTilausnumero
        {
            get
            {
                return viimeisinTilausnumero;
            }

            private set
            {
                viimeisinTilausnumero = value;
            }
        }

        public void Tallenna(Tilaus tilaus)
        {
            ViimeisinTilausnumero++;
            tilaus.Tilausnumero = viimeisinTilausnumero;
            tilaukset.Add(tilaus);
        }

        public Tilaus HaeTilaus(int tilausnumero)
        {
            return tilaukset.FirstOrDefault(t => t.Tilausnumero == tilausnumero);
        }

        public List<Tilaus> HaeKaikkiTilaukset()
        {
            return tilaukset;
        }
    }
}
