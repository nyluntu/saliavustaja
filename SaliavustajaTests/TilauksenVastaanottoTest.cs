using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
