using NUnit.Framework;
using Saliavustaja;
using System.Collections.Generic;
using System.Linq;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilausTest
    {
        Tilaus tilaus = null;

        [SetUp]
        public void TestiAlustus()
        {
            tilaus = new Tilaus();
        }

        [Test]
        public void LuoUusiTilaus()
        {
            Assert.That(tilaus, Is.InstanceOf(typeof(Tilaus)));
            Assert.That(tilaus.Poyta, Is.Null);
            Assert.That(tilaus.Asiakas, Is.Null);
            Assert.AreEqual(0, tilaus.Ateriat.Count);
            Assert.That(tilaus.Ateriat, Is.InstanceOf<List<Ateria>>());
        }

        [Test]
        public void AsetaTilauksellePoyta()
        {
            tilaus.Poyta = new Poyta();
            Assert.That(tilaus.Poyta, Is.InstanceOf<Poyta>());
            Assert.That(tilaus.Poyta, Is.Not.Null);
        }

        [Test]
        public void AsetaTilaukselleAsiakas()
        {
            tilaus.Asiakas = new Asiakas();
            Assert.That(tilaus.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.That(tilaus.Asiakas, Is.Not.InstanceOf<BonusAsiakas>());

            tilaus.Asiakas = new BonusAsiakas();
            Assert.That(tilaus.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.That(tilaus.Asiakas, Is.InstanceOf<BonusAsiakas>());
        }

        [Test]
        public void LisääTilaukselleAteria()
        {
            var ateria = new Ateria();
            ateria.Nimi = "Lihapullat ja muussi";
            ateria.Maara = 1;
            tilaus.LisaaAteria(ateria);
        
            List<Ateria> ateriat = tilaus.Ateriat;
            Assert.AreEqual("Lihapullat ja muussi", ateriat.FirstOrDefault().Nimi);
            Assert.AreEqual(1, ateriat.FirstOrDefault().Maara);

            var ateria2 = new Ateria();
            ateria2.Nimi = "Lihapullat ja nakit";
            ateria2.Maara = 3;
            tilaus.LisaaAteria(ateria2);
            List<Ateria> ateriat2 = tilaus.Ateriat;
            Assert.AreEqual(2, ateriat2.Count());
            Assert.AreEqual("Lihapullat ja nakit", ateriat2.LastOrDefault().Nimi);
            Assert.AreEqual(3, ateriat2.LastOrDefault().Maara);
        }
    }
}
