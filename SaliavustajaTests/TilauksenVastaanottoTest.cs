using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauksenVastaanottoTest : TilausBaseTest
    {
        TilauksenVastaanotto tilauksenVastaanotto = null;

        [TestFixtureSetUp]
        public void TestiLuokanAlustus()
        {
            tietokanta = new Db();
        }

        [SetUp]
        public void TestienAlustus()
        {
            tilauksenVastaanotto = new TilauksenVastaanotto();
        }

        [Test]
        public void VahvistaTilaus()
        {
            Tilaus tilaus = LuoUusiTilaus();
            int tilausnumero = tilauksenVastaanotto.VahvistaJaTallenna(tilaus);
            Assert.AreEqual(1, tilausnumero);

            Tilaus tilaus2 = LuoUusiTilaus();
            int tilausnumero2 = tilauksenVastaanotto.VahvistaJaTallenna(tilaus);
            Assert.AreEqual(2, tilausnumero2);

            Tilaus tilaus3 = LuoUusiTilaus();
            int tilausnumero3 = tilauksenVastaanotto.VahvistaJaTallenna(tilaus);
            Assert.AreEqual(3, tilausnumero3);
            Assert.That(tilaus3.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.That(tilaus3.Poyta, Is.InstanceOf<Poyta>());
        }

    }
}
