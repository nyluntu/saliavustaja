using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauksenVastaanottoTest
    {
        RamTilausLiittyma tilausTietokantaLiittyma;
        RamPoytaLiittyma poytaTietokantaLiittyma;
        RamAteriaLiittyma ateriaTietokantaLiittyma;
        TilauksenVastaanotto tilauksenVastaanotto;
        List<Ateria> ateriat;

        [SetUp]
        public void TestienAlustus()
        {
            tilausTietokantaLiittyma = new RamTilausLiittyma();
            poytaTietokantaLiittyma = new RamPoytaLiittyma();
            ateriaTietokantaLiittyma = new RamAteriaLiittyma();
            tilauksenVastaanotto = new TilauksenVastaanotto(tilausTietokantaLiittyma, poytaTietokantaLiittyma);
            ateriat = ateriaTietokantaLiittyma.HaeKaikki();
        }

        [Test]
        public void VastaanotaJaTallennaUusiTilaus()
        {

            Poyta poyta = poytaTietokantaLiittyma.Hae(8);
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Poyta = poyta;
            tilaus.Asiakas = asiakas;
            tilaus.Pvm = DateTime.Now;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);

            int tilausnumero = tilausTietokantaLiittyma.SeuraavaId - 1;
            Tilaus tilausTietokannasta = tilausTietokantaLiittyma.Hae(tilausnumero);
            Assert.IsNotNull(tilausTietokannasta);
            Assert.AreEqual(tilausnumero, tilausTietokannasta.Tilausnumero);
            Assert.That(tilausTietokannasta.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.AreEqual(true, tilausTietokannasta.OnkoVahvistettu());
            Assert.AreEqual(60.42, tilausTietokannasta.LaskeKokonaishinta(), 0.01);

            ArrayList tilausrivit = tilausTietokannasta.Tilausrivit;
            Tilausrivi rivi = (Tilausrivi)tilausrivit[1];
            Assert.IsNotNull(rivi);
            Assert.AreEqual(9, rivi.Ateria.Id);
            Assert.AreEqual("Tyrnipossetti ja luomusuklaata", rivi.Ateria.Nimi);
            Assert.AreEqual(12, rivi.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(3, rivi.Maara);

            Poyta varattuPoyta = poytaTietokantaLiittyma.Hae(tilaus.Poyta.Tunnus);
            Assert.That(varattuPoyta, Is.Not.Null);
            Assert.AreEqual(8, varattuPoyta.Tunnus);
            Assert.AreEqual(4, varattuPoyta.PaikkojenMaara);
            Assert.AreEqual(true, varattuPoyta.OnkoVarattu());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Pöytää ei ole valittu. Tilausta ei voitu vahvistaa.")]
        public void VirheellinenTilausPoytaPuuttuu()
        {
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = asiakas;
            tilaus.Pvm = DateTime.Now;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Pöytä on jo varattu. Tilausta ei voitu vahvistaa.")]
        public void VirheellinenTilausPoytaVarattuna()
        {
            poytaTietokantaLiittyma.VaraaPoyta(6);

            Poyta poyta = poytaTietokantaLiittyma.Hae(6);
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Poyta = poyta;
            tilaus.Asiakas = asiakas;
            tilaus.Pvm = DateTime.Now;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

    }
}
