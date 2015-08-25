using System;

namespace Saliavustaja
{
    public class Tilausrivi
    {
        public Ateria Ateria { get; private set; }
        public int Maara { get; private set; }

        public Tilausrivi(Ateria ateria, int maara)
        {
            Ateria = ateria;
            Maara = maara;
        }

        public void VaihdaMaara(int maara)
        {
            Maara = maara;
        }
    }
}
