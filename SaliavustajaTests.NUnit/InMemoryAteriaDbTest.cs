using NUnit.Framework;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    [TestFixture]
    public class InMemoryAteriaDbTest
    {
        InMemoryAteriaDb ateriaDb;

        [SetUp]
        public void TestienAlustus()
        {
            ateriaDb = new InMemoryAteriaDb();
        }

        [Test]
        public void KuuluisiHakeaAteriaTunnisteella()
        {
            Ateria ateria = ateriaDb.Hae(3);
            Assert.That(ateria, Is.Not.Null);
            Assert.AreEqual(3, ateria.Id);
            Assert.AreEqual("Siikaa ja jokirapua", ateria.Nimi);
            Assert.AreEqual(17, ateria.VerotonHinta, 0.01);

            Ateria ateria2 = ateriaDb.Hae(7);
            Assert.That(ateria2, Is.Not.Null);
            Assert.AreEqual(7, ateria2.Id);
            Assert.AreEqual("Munakoisoa, paprikaa ja pinjansiementä", ateria2.Nimi);
            Assert.AreEqual(27, ateria2.VerotonHinta, 0.01);
        }

        [Test]
        public void KuuluisiHakeaKaikkiAteriat()
        {
            List<Ateria> ateriat = ateriaDb.HaeKaikki();
            Assert.That(ateriat, Is.InstanceOf<List<Ateria>>());
            Assert.AreEqual(10, ateriat.Count);
        }
    }
}
