using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections;
using System.Diagnostics;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauksenVastaanottoTest
    {
        [Test]
        public void VastaanotaJaTallennaUusiTilaus()
        {
            RamTilausLiittyma tietokantaLiittyma = new RamTilausLiittyma();
            TilauksenVastaanotto tilauksenVastaanotto = new TilauksenVastaanotto(tietokantaLiittyma);

            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            tilaus.Pvm = DateTime.Now;
            var pihvi = new Ateria(1, "Garlic Steak test", 11.60);
            var lehtipihvi = new Ateria(2, "Lehtipihvi lohkoperunoilla", 13.60);
            tilaus.LisaaAteria(pihvi, 1);
            tilaus.LisaaAteria(lehtipihvi, 3);

            tilauksenVastaanotto.VastaanotaTilaus(tilaus);

            int tilausnumero = tietokantaLiittyma.SeuraavaId - 1;
            Tilaus tilausTietokannasta = tietokantaLiittyma.HaeTilaus(tilausnumero);
            Assert.IsNotNull(tilausTietokannasta);
            Assert.AreEqual(tilausnumero, tilausTietokannasta.Tilausnumero);
            Assert.AreEqual(1, tilausTietokannasta.Poyta.Tunnus);
            Assert.AreEqual(5, tilausTietokannasta.Poyta.PaikkojenMaara);
            Assert.That(tilausTietokannasta.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.AreEqual(false, tilausTietokannasta.OnkoVahvistettu());
            Assert.AreEqual(59.73, tilausTietokannasta.LaskeKokonaishinta(), 0.01);

            ArrayList tilausrivit = tilausTietokannasta.Tilausrivit;
            Tilausrivi rivi = (Tilausrivi)tilausrivit[1];
            Assert.IsNotNull(rivi);
            Assert.AreEqual(2, rivi.Ateria.Id);
            Assert.AreEqual("Lehtipihvi lohkoperunoilla", rivi.Ateria.Nimi);
            Assert.AreEqual(13.60, rivi.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(3, rivi.Maara);

        }

    }
}
