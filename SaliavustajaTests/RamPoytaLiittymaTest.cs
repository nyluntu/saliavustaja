using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    [TestFixture]
    public class RamPoytaLiittymaTest
    {
        RamPoytaLiittyma tietokantaLiittyma = new RamPoytaLiittyma();

        [SetUp]
        public void TestienAlustus()
        {
            tietokantaLiittyma = new RamPoytaLiittyma();
        }

        [Test]
        public void HaeYksittainenPoyta()
        {
            Poyta poyta = tietokantaLiittyma.Hae(4);
            Assert.That(poyta, Is.Not.Null);
            Assert.AreEqual(4, poyta.Tunnus);
            Assert.AreEqual(6, poyta.PaikkojenMaara);
        }

        [Test]
        public void HaeKaikkiPoydat()
        {
            List<Poyta> kaikkiPoydat = tietokantaLiittyma.HaeKaikki();
            Assert.That(kaikkiPoydat, Is.InstanceOf<List<Poyta>>());
            Assert.AreEqual(10, kaikkiPoydat.Count);
        }

        [Test]
        public void VaraaPoyta()
        {
            List<Poyta> kaikkiPoydat = tietokantaLiittyma.HaeKaikki();
            Poyta poyta = kaikkiPoydat[4];
            Assert.AreEqual(false, poyta.OnkoVarattu());

            tietokantaLiittyma.VaraaPoyta(poyta.Tunnus);
            kaikkiPoydat = tietokantaLiittyma.HaeKaikki();
            Poyta varattuPoyta = kaikkiPoydat[4];
            Assert.AreEqual(true, varattuPoyta.OnkoVarattu()); 
        }
        
    }
}
