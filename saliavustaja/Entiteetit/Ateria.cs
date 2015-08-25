namespace Saliavustaja.Entiteetit
{
    public class Ateria
    {
        public int Id { get; private set; }
        public string Nimi { get; private set; }
        public double VerotonHinta { get; private set; }
        public readonly double Alv;

        public Ateria(int id, string nimi, double verotonHinta, double alv)
        {
            Id = id;
            Nimi = nimi;
            VerotonHinta = verotonHinta;
            Alv = alv;
        }

        public double LaskeVerollinenHinta()
        {
            return VerotonHinta * (1 + Alv);
        }
        
    }
}