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
            tilaus.Poyta = new Poyta(1, 5);
            tilaus.LisaaAteria(new Ateria() { Nimi = "Texas Pork&Ox", Maara = 2 });
            tilaus.LisaaAteria(new Ateria() { Nimi = "Garlic Steak", Maara = 2 });
            tietokanta.Tallenna(tilaus);

            var tilaus2 = new Tilaus();
            tilaus2.Asiakas = new Asiakas();
            tilaus2.Poyta = new Poyta(2, 6);
            tilaus2.LisaaAteria(new Ateria() { Nimi = "Cheese Master’s Steak", Maara = 2 });
            tilaus2.LisaaAteria(new Ateria() { Nimi = "Whitefish with Bacon", Maara = 2 });
            tietokanta.Tallenna(tilaus2);

            var tilaus3 = new Tilaus();
            tilaus3.Asiakas = new Asiakas();
            tilaus3.Poyta = new Poyta(3, 2);
            tilaus3.LisaaAteria(new Ateria() { Nimi = "Pulled Pork Burger", Maara = 1 });
            tilaus3.LisaaAteria(new Ateria() { Nimi = "Chicken Wings", Maara = 2 });
            tilaus3.LisaaAteria(new Ateria() { Nimi = "Chocolate Fondant", Maara = 3 });
            tietokanta.Tallenna(tilaus3);
        }

        protected Tilaus LuoUusiTilaus()
        {
            var tilaus = new Tilaus();
            tilaus.Poyta = new Poyta(6, 2);
            tilaus.Asiakas = new Asiakas();
            tilaus.LisaaAteria(new Ateria()
            {
                Nimi = "Lihapullat ja muussi",
                Maara = 3
            });
            tilaus.LisaaAteria(new Ateria()
            {
                Nimi = "Nakit ja muussi",
                Maara = 1
            });
            tilaus.LisaaAteria(new Ateria()
            {
                Nimi = "Jäätelöpallo kinuskikastikkeella",
                Maara = 4
            });
            return tilaus;
        }
    }
}