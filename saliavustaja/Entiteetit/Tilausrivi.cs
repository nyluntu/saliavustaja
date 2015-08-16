namespace Saliavustaja
{
    public class Tilausrivi
    {
        Ateria ateria;
        int maara;

        public Tilausrivi(Ateria ateria, int maara)
        {
            this.ateria = ateria;
            this.maara = maara;
        }

        public Ateria Ateria
        {
            get { return ateria; }
        }

        public int Maara
        {
            get { return maara; }
        }
    }
}
