using System;

namespace Saliavustaja
{
    public class Ateria
    {
        int id;
        string nimi;
        double verotonHinta;

        public Ateria(int id, string nimi, double verotonHinta)
        {
            this.id = id;
            this.nimi = nimi;
            this.verotonHinta = verotonHinta;
        }

        public int Id
        {
            get { return id; }
        }

        public string Nimi
        {
            get { return nimi; }
        }

        public double VerotonHinta
        {
            get { return verotonHinta; }
        }

        public double LaskeVerollinenHinta(double alv)
        {
            return verotonHinta * (1 + alv);
        }
    }
}