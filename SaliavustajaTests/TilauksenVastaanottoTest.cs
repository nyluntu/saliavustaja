using NUnit.Framework;
using Saliavustaja;
using System.Diagnostics;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauksenVastaanottoTest
    {
        Db tietokanta = null;
        TilauksenVastaanotto tilauksenVastaanotto = null;

        [TestFixtureSetUp]
        public void TestiluokanAlustus()
        {
            tietokanta = new TiedostoDb();
        }

        [SetUp]
        public void TestienAlustus()
        {
            tilauksenVastaanotto = new TilauksenVastaanotto();
        }

        [Test]
        [Ignore]
        public void TallennaTilaus()
        {
            Tilaus tilaus = LuoUusiTilaus();
            int tilausnumero = tilauksenVastaanotto.TallennaJaVahvista(tilaus);
            Debug.WriteLine(tietokanta.HaeKaikkiTilaukset().Count);
            Assert.AreEqual(1, tilausnumero);
            Tilaus entinenTilaus1 = tietokanta.HaeTilaus(tilausnumero);
            Assert.IsNotNull(entinenTilaus1);
            Assert.AreEqual(true, entinenTilaus1.OnkoVahvistettu());

        }

        Tilaus LuoUusiTilaus()
        {
            var tilaus = new Tilaus();
            tilaus.Poyta = new Poyta(6, 2, Varaustilanne.Varattu);
            tilaus.Asiakas = new Asiakas();
            tilaus.LisaaAteria(new Ateria(1, "Lihapullat ja muussi", 11.50), 1);
            tilaus.LisaaAteria(new Ateria(2, "Nakit ja muussi", 9.50), 1);
            tilaus.LisaaAteria(new Ateria(3, "Jäätelöä kinuskikastikkeella", 6.50), 2);
            return tilaus;
        }

    }
}
