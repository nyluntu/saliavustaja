using Saliavustaja.Entiteetit;
using System.Collections.Generic;

namespace Saliavustaja.TietokantaLiittymat
{
    public abstract class AteriaDb
    {
        public abstract Ateria Hae(int tunnus);
        public abstract List<Ateria> HaeKaikki();
    }
}