using Saliavustaja.Entiteetit;
using System.Collections.Generic;

namespace Saliavustaja.Rajapinnat
{
    public abstract class TilausDb
    {
        public abstract void Uusi(Tilaus tilaus);
        public abstract Tilaus Hae(int tilausnumero);
        public abstract List<Tilaus> HaeKaikki();
    }
}