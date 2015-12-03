using System;
using System.Collections.Generic;
using NUnit.Framework;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using SaliavustajaTv;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauksenVastaanottoTest
    {
        InMemoryTilausDb tilausDb;
        InMemoryPoytaDb poytaDb;
        InMemoryAteriaDb ateriaDb;
        TilauksenVastaanotto tilauksenVastaanotto;
        List<Ateria> ateriat;

        [SetUp]
        public void TestienAlustus()
        {
            tilausDb = new InMemoryTilausDb();
            poytaDb = new InMemoryPoytaDb();
            ateriaDb = new InMemoryAteriaDb();
            tilauksenVastaanotto = new TilauksenVastaanotto(tilausDb, poytaDb);
            ateriat = ateriaDb.HaeKaikki();
        }

        [Test]
        public void KuuluisiVastaanottaaJaTallentaaUusiTilaus()
        {

            Poyta poyta = poytaDb.Hae(8);
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Poyta = poyta;
            tilaus.Asiakas = asiakas;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);

            int tilausnumero = tilausDb.SeuraavaId - 1;
            Tilaus tilausTietokannasta = tilausDb.Hae(tilausnumero);
            Assert.IsNotNull(tilausTietokannasta);
            Assert.AreEqual(tilausnumero, tilausTietokannasta.Tilausnumero);
            Assert.That(tilausTietokannasta.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.AreEqual(true, tilausTietokannasta.OnkoVahvistettu());
            Assert.AreEqual(60.42, tilausTietokannasta.LaskeVerollinenKokonaishinta(), 0.01);

            List<Tilausrivi> tilausrivit = tilausTietokannasta.Tilausrivit;
            Tilausrivi rivi = tilausrivit[1];
            Assert.IsNotNull(rivi);
            Assert.AreEqual(9, rivi.Ateria.Id);
            Assert.AreEqual("Tyrnipossetti ja luomusuklaata", rivi.Ateria.Nimi);
            Assert.AreEqual(12, rivi.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(3, rivi.Maara);

            Poyta varattuPoyta = poytaDb.Hae(tilaus.Poyta.Id);
            Assert.That(varattuPoyta, Is.Not.Null);
            Assert.AreEqual(8, varattuPoyta.Id);
            Assert.AreEqual(4, varattuPoyta.PaikkojenMaara);
            Assert.AreEqual(true, varattuPoyta.OnkoVarattu());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Pöytää ei ole valittu. Tilausta ei voitu vahvistaa.")]
        public void KuuluisiIlmoittaaVirheestaKoskaTilauksestaPuuttuuPoyta()
        {
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = asiakas;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Pöytä on jo varattu. Tilausta ei voitu vahvistaa.")]
        public void KuuluisiIlmoittaaVirheestaKoskaTilauksenPoytaOnVarattu()
        {
            poytaDb.VaraaPoyta(6);
            Poyta poyta = poytaDb.Hae(6);
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Poyta = poyta;
            tilaus.Asiakas = asiakas;
            var ateria1 = ateriat[1];
            var ateria2 = ateriat[8];
            tilaus.LisaaAteria(ateria1, 1);
            tilaus.LisaaAteria(ateria2, 3);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Tilaus ei sisällä tilausrivejä.")]
        public void KuuluisiIlmoittaaVirheestaKoskaTilausEiSisallaTilausriveja()
        {
            poytaDb.VaraaPoyta(1);
            Poyta poyta = poytaDb.Hae(6);
            Asiakas asiakas = new Asiakas();
            Tilaus tilaus = new Tilaus();
            tilaus.Poyta = poyta;
            tilaus.Asiakas = asiakas;
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Tilaus ei sisällä asiakasta.")]
        public void KuuluisiIlmoittaaVirheestaKoskaTilausEiSisallaAsiakasta()
        {
            poytaDb.VaraaPoyta(1);
            Poyta poyta = poytaDb.Hae(6);
            var ateria1 = ateriat[1];
            Tilaus tilaus = new Tilaus();
            tilaus.LisaaAteria(ateria1,2);
            tilaus.Poyta = poyta;
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);
        }

    }
}
