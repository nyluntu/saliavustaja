using Saliavustaja.Entiteetit;
using System.Collections.Generic;

namespace Saliavustaja.TietokantaLiittymat
{
    public abstract class PoytaDb
    {
        public abstract Poyta Hae(int tunnus);
        public abstract List<Poyta> HaeKaikki();
        public abstract void VaraaPoyta(int tunnus);
    }
}