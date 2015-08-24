using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaliavustajaTests
{
    [TestFixture]
    public class InMemoryTilausDbTest : TilausDbBaseTest
    {
        new InMemoryTilausDb tilausDb;

        [TestFixtureSetUp]
        public void TestienAlustus()
        {
            tilausDb = new InMemoryTilausDb();
            var tilaukset = LuoTilauksia();

            foreach (Tilaus tilaus in tilaukset)
                tilausDb.Uusi(tilaus);
        }

        [TestFixtureTearDown]
        public void TestienLopetus()
        {
            tilausDb = null;
        }

        [Test]
        public void HaeTilausTilausnumerolla()
        {
            Tilaus tilaus = tilausDb.Hae(1);
            Assert.IsNotNull(tilaus);
            Assert.IsNotNull(tilaus.Asiakas);
            Assert.IsNotNull(tilaus.Poyta);
            Assert.AreEqual(1, tilaus.Tilausnumero);
            Assert.AreEqual(2, tilaus.Tilausrivit.Count);
        }

        [Test]
        public void HaeTilausTilaustaEiLoydy()
        {
            Tilaus tilaus = tilausDb.Hae(99);
            Assert.IsNull(tilaus);
        }

        [Test]
        public override void HaeKaikkiTilaukset()
        {
            List<Tilaus> tilaukset = tilausDb.HaeKaikki();
            Assert.IsNotNull(tilaukset);
            Assert.AreEqual(2, tilaukset.Count);

            Tilaus viimeinenTilaus = tilaukset.LastOrDefault();
            Assert.AreEqual(tilausDb.SeuraavaId - 1, viimeinenTilaus.Tilausnumero);

            Tilausrivi tilausrivi = (Tilausrivi)viimeinenTilaus.Tilausrivit[0];
            Assert.AreEqual("Kanasalaatti", tilausrivi.Ateria.Nimi);
        }



        public override void TallennaTilausTietokantaan()
        {
            throw new NotImplementedException();
        }
    }
}
