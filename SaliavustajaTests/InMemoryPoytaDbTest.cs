using NUnit.Framework;
using Saliavustaja;
using System;
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
        public void HaeYksittainenPoyta()
        {
            Poyta poyta = poytaDb.Hae(4);
            Assert.That(poyta, Is.Not.Null);
            Assert.AreEqual(4, poyta.Tunnus);
            Assert.AreEqual(6, poyta.PaikkojenMaara);
        }

        [Test]
        public void HaeKaikkiPoydat()
        {
            List<Poyta> kaikkiPoydat = poytaDb.HaeKaikki();
            Assert.That(kaikkiPoydat, Is.InstanceOf<List<Poyta>>());
            Assert.AreEqual(10, kaikkiPoydat.Count);
        }

        [Test]
        public void VaraaPoyta()
        {
            List<Poyta> kaikkiPoydat = poytaDb.HaeKaikki();
            Poyta poyta = kaikkiPoydat[4];
            Assert.AreEqual(false, poyta.OnkoVarattu());

            poytaDb.VaraaPoyta(poyta.Tunnus);
            kaikkiPoydat = poytaDb.HaeKaikki();
            Poyta varattuPoyta = kaikkiPoydat[4];
            Assert.AreEqual(true, varattuPoyta.OnkoVarattu()); 
        }
        
    }
}
