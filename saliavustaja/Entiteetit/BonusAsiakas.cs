namespace Saliavustaja
{
    public class BonusAsiakas : Asiakas
    {
        public override double LaskeAsiakkaanEtuhinta(double kokonaishinta)
        {
            return kokonaishinta * 0.85;
        }
    }
}
