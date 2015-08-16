using System;
using System.Collections;
using System.Collections.Generic;

namespace Saliavustaja
{
    public class RamTilausLiittyma
    {
        static int seuraavaId = 1;
        Hashtable tilaukset = new Hashtable();

        public int SeuraavaId
        {
            get { return seuraavaId; }
        }

        public void Tallenna(Tilaus tilaus)
        {
            tilaukset[seuraavaId] = tilaus;
            seuraavaId++;
        }

        public Tilaus Hae(int tilausnumero)
        {
            Tilaus tilaus = (Tilaus)tilaukset[tilausnumero];
            if(tilaus != null)
                tilaus.Tilausnumero = tilausnumero;
            return tilaus;
        }

        public List<Tilaus> HaeKaikki()
        {
            List<Tilaus> kaikkiTilaukset = new List<Tilaus>();
            for (int i = 1; i <= tilaukset.Count; i++)
            {
                Tilaus tilaus = (Tilaus)tilaukset[i];
                tilaus.Tilausnumero = i;
                kaikkiTilaukset.Add(tilaus);
            }
            return kaikkiTilaukset;
        }
    }
}
