using System;

namespace Saliavustaja
{
    public class Poyta
    {
        int tunnus;
        int paikkojenMaara;
        bool varattu;

        public int Tunnus
        {
            get{ return tunnus;}
            private set {tunnus = value;}
        }

        public int PaikkojenMaara
        {
            get{ return paikkojenMaara; }
            private set{paikkojenMaara = value; }
        }

        public Poyta(int tunnus, int paikkojenMaara)
        {
            this.Tunnus = tunnus;
            this.PaikkojenMaara = paikkojenMaara;
            this.varattu = false;
        }

        public Poyta(int tunnus, int paikkojenMaara, bool varattu)
        {
            this.Tunnus = tunnus;
            this.PaikkojenMaara = paikkojenMaara;
            this.varattu = varattu;
        }

        public void Varaa()
        {
            varattu = true;
        }

        public void Vapauta()
        {
            varattu = false;
        }

        public bool OnkoVarattu()
        {
            return varattu;
        }

        
    }
}
