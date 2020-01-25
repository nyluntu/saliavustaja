using Saliavustaja.Entiteetit;
using System.Collections.Generic;

namespace Saliavustaja.Rajapinnat
{
    public abstract class AteriaDb
    {
        public abstract Ateria Hae(int tunnus);
        public abstract List<Ateria> HaeKaikki();
    }
}