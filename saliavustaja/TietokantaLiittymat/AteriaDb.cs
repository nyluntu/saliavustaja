using System.Collections.Generic;

namespace Saliavustaja
{
    public abstract class AteriaDb
    {
        public abstract Ateria Hae(int tunnus);
        public abstract List<Ateria> HaeKaikki();
    }
}