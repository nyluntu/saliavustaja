using NUnit.Framework;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaliavustajaTests
{
    [TestFixture]
    public class FileSystemTilausDbTest : TilausDbBaseTest
    {
       FileSystemTilausDb tilausDb;
        string tietokannanPolku = "C:\\Temp\\tilaukset.dat";

        [TestFixtureSetUp]
        public void TestienAlustus()
        {
            tilausDb = new FileSystemTilausDb(tietokannanPolku);
            var tilaukset = LuoTilauksia();

            foreach (Tilaus tilaus in tilaukset)
                tilausDb.Uusi(tilaus);
        }

        [TestFixtureTearDown]
        public void TestienLopetus()
        {
            File.Delete(tietokannanPolku);
        }

        [Test]
        public override void HaeTilausTunnisteella()
        {
            Tilaus tilaus = tilausDb.Hae(1);
            Assert.IsNotNull(tilaus);
            Assert.IsNotNull(tilaus.Asiakas);
            Assert.IsNotNull(tilaus.Poyta);
            Assert.AreEqual(1, tilaus.Tilausnumero);
            Assert.AreEqual(2, tilaus.Tilausrivit.Count);
        }

        [Test]
        public override void HaeTilausTunnisteellaMuttaTilaustaEiLoydy()
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

        [Test]
        public override void LuoUusiTilaus()
        {
            var tilaus = LuoTilaus("Pihvi, aterian tallennus testi");
            tilausDb.Uusi(tilaus);

            var tilaukset = tilausDb.HaeKaikki();
            Tilaus viimeinenTilaus = tilaukset.LastOrDefault();
            Tilausrivi tilausrivi = (Tilausrivi)viimeinenTilaus.Tilausrivit[0];
            Ateria ateria = (Ateria)tilausrivi.Ateria;
            Assert.AreEqual("Pihvi, aterian tallennus testi", ateria.Nimi);
        }
    }
}
