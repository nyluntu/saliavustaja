namespace Saliavustaja.Entiteetit
{
    public class Poyta
    {
        public int Id { get; private set; }
        public int PaikkojenMaara { get; private set; }
        public Varaustilanne Varaustilanne { get; private set; }

        public Poyta(int tunnus, int paikkojenMaara, Varaustilanne varattu)
        {
            Id = tunnus;
            PaikkojenMaara = paikkojenMaara;
            Varaustilanne = varattu;
        }

        public void VaraaPoyta()
        {
            Varaustilanne = Varaustilanne.Varattu;
        }

        public void VapautaPoyta()
        {
            Varaustilanne = Varaustilanne.Vapaa;
        }

        public bool OnkoVarattu()
        {
            if (Varaustilanne == Varaustilanne.Varattu)
                return true;

            return false;
        }

        public override string ToString()
        {
            return string.Format("Pöytä {0}, paikkoja {1}, {2}", Id, PaikkojenMaara, Varaustilanne.ToString().ToUpper());
        }


    }
}
