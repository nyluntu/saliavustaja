using NUnit.Framework;
using Saliavustaja;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    [TestFixture]
    public class RamAteriaLiittymaTest
    {
        RamAteriaLiittyma ateriaTietokantaLiittyma;

        [SetUp]
        public void TestienAlustus()
        {
            ateriaTietokantaLiittyma = new RamAteriaLiittyma();
        }

        [Test]
        public void HaeYksittainenAteria()
        {
            Ateria ateria = ateriaTietokantaLiittyma.Hae(3);
            Assert.That(ateria, Is.Not.Null);
            Assert.AreEqual(3, ateria.Id);
            Assert.AreEqual("Siikaa ja jokirapua", ateria.Nimi);
            Assert.AreEqual(17, ateria.VerotonHinta, 0.01);

            Ateria ateria2 = ateriaTietokantaLiittyma.Hae(7);
            Assert.That(ateria2, Is.Not.Null);
            Assert.AreEqual(7, ateria2.Id);
            Assert.AreEqual("Munakoisoa, paprikaa ja pinjansiementä", ateria2.Nimi);
            Assert.AreEqual(27, ateria2.VerotonHinta, 0.01);
        }

        [Test]
        public void HaeKaikkiAteriat()
        {
            List<Ateria> ateriat = ateriaTietokantaLiittyma.HaeKaikki();
            Assert.That(ateriat, Is.InstanceOf<List<Ateria>>());
            Assert.AreEqual(10, ateriat.Count);
        }
    }
}
