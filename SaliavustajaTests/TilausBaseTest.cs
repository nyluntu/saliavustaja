using Saliavustaja;

namespace SaliavustajaTests
{
    public class TilausBaseTest
    {

        protected Db tietokanta = null;

        protected void LisaaTilauksiaTietokantaan()
        {
            var tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            tilaus.LisaaAteria(new Ateria(1, "Texas Pork&Ox", 16.20), 2);
            tilaus.LisaaAteria(new Ateria(2, "Garlic Steak", 18.00), 2);
            tietokanta.Tallenna(tilaus);

            var tilaus2 = new Tilaus();
            tilaus2.Asiakas = new Asiakas();
            tilaus2.Poyta = new Poyta(2, 6, Varaustilanne.Varattu);
            tilaus2.LisaaAteria(new Ateria(3, "Cheese Master’s Steak", 14.60), 2);
            tilaus2.LisaaAteria(new Ateria(4, "Whitefish with Bacon", 12.70), 2);
            tietokanta.Tallenna(tilaus2);

            var tilaus3 = new Tilaus();
            tilaus3.Asiakas = new Asiakas();
            tilaus3.Poyta = new Poyta(3, 2, Varaustilanne.Varattu);
            tilaus3.LisaaAteria(new Ateria(5, "Pulled Pork Burger", 13.30), 1);
            tilaus3.LisaaAteria(new Ateria(6, "Chickeng Wings", 8.90), 2);
            tilaus3.LisaaAteria(new Ateria(7, "Chocolate Fondant", 6.00), 3);
            tietokanta.Tallenna(tilaus3);
        }

    }
}