using System.Collections;
using System.Collections.Generic;
using Saliavustaja.Entiteetit;

namespace Saliavustaja.TietokantaLiittymat
{
    public class InMemoryTilausDb : TilausDb
    {
        static int seuraavaId = 1;
        protected Hashtable tilaukset = new Hashtable();

        public int SeuraavaId
        {
            get { return seuraavaId; }
        }

        public override void Uusi(Tilaus tilaus)
        {
            tilaukset[seuraavaId] = tilaus;
            seuraavaId++;
        }

        public override Tilaus Hae(int tilausnumero)
        {
            Tilaus tilaus = (Tilaus)tilaukset[tilausnumero];

            if (tilaus == null)
                return null; 

            return new Tilaus(tilausnumero, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm);
        }

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
