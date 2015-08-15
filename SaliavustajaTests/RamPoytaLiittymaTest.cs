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
        public void HaeKaikkiPoydat()
        {
            List<Poyta> kaikkiPoydat = tietokantaLiittyma.HaeKaikkiPoydat();
            Assert.That(kaikkiPoydat, Is.InstanceOf<List<Poyta>>());
            Assert.AreEqual(10, kaikkiPoydat.Count);
        }
        
    }
}
