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
            this.varaustilanne = varattu;
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

        public void Varaa()
        {
            varaustilanne = Varaustilanne.Varattu;
        }

        public void Vapauta()
        {
            varaustilanne = Varaustilanne.Vapaa;
        }

        public bool OnkoVarattu()
        {
            if (varaustilanne == Varaustilanne.Varattu)
                return true;
            return false;
        }


    }
}
