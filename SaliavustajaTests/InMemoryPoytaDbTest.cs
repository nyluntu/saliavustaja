using NUnit.Framework;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    [TestFixture]
    public class InMemoryPoytaDbTest
    {
        InMemoryPoytaDb poytaDb;

        [SetUp]
        public void TestienAlustus()
        {
            poytaDb = new InMemoryPoytaDb();
        }

        [Test]
        public void KuuluisiHakeaPoytaTunnisteella()
        {
            Poyta poyta = poytaDb.Hae(4);
            Assert.That(poyta, Is.Not.Null);
            Assert.AreEqual(4, poyta.Id);
            Assert.AreEqual(6, poyta.PaikkojenMaara);
        }

        [Test]
        public void KuuluisiHakeaKaikkiPoydat()
        {
            List<Poyta> kaikkiPoydat = poytaDb.HaeKaikki();
            Assert.That(kaikkiPoydat, Is.InstanceOf<List<Poyta>>());
            Assert.AreEqual(10, kaikkiPoydat.Count);
        }

        [Test]
        public void KuuluisiVarataPoyta()
        {
            List<Poyta> kaikkiPoydat = poytaDb.HaeKaikki();
            Poyta poyta = kaikkiPoydat[4];
            Assert.AreEqual(false, poyta.OnkoVarattu());

            poytaDb.VaraaPoyta(poyta.Id);
            kaikkiPoydat = poytaDb.HaeKaikki();
            Poyta varattuPoyta = kaikkiPoydat[4];
            Assert.AreEqual(true, varattuPoyta.OnkoVarattu()); 
        }
        
    }
}
