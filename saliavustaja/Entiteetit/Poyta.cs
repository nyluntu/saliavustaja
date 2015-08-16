using System;

namespace Saliavustaja
{
    public class Poyta
    {
        int tunnus;
        int paikkojenMaara;
        Varaustilanne varaustilanne;

        public Poyta(int tunnus, int paikkojenMaara, Varaustilanne varattu)
        {
            this.tunnus = tunnus;
            this.paikkojenMaara = paikkojenMaara;
            this.Varaustilanne = varattu;
        }

        public int Tunnus
        {
            get { return tunnus; }
            private set { tunnus = value; }
        }

        public int PaikkojenMaara
        {
            get { return paikkojenMaara; }
            private set { paikkojenMaara = value; }
        }

        public Varaustilanne Varaustilanne
        {
            get { return varaustilanne; }
            set { varaustilanne = value; }
        }

        public bool OnkoVarattu()
        {
            if (Varaustilanne == Varaustilanne.Varattu)
                return true;
            return false;
        }


    }
}
