using System;

namespace Saliavustaja
{
    public class BonusAsiakas : Asiakas
    {
        public int Id { get; private set; }
        public double Etupisteet { get; private set; }

        public BonusAsiakas()
        {
            Id = 0;
            Etupisteet = 0.0;
            etukuponki = true;
        }

        public BonusAsiakas(int id, double etupisteet)
        {
            Id = id;
            Etupisteet = etupisteet;
            etukuponki = true;
        }

        public void KerrytaPisteita(double hinta)
        {
            Etupisteet += Math.Round(hinta / 50, 2);
        }

        public double OstaEtupisteilla(double hinta)
        {
            // Jos erotus yli 0, pisteitä jää erotuksen verran.
            // Jos erotus alle 0, maksettavaksi jää erotuksen verran
            // ja etupisteet nollataan.
            // Etupisteillä voi maksaa vastaavan summan euroja.
            double erotus = Etupisteet - hinta;
            Etupisteet = erotus;

            if (erotus >= 0)
                return 0;

            Etupisteet = 0;
            return Math.Abs(erotus);
        }
    }
}
