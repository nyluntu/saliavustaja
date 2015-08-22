﻿using NUnit.Framework;
using Saliavustaja;
using System.Collections;
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
            Assert.AreEqual(0, tilaus.Tilausrivit.Count);
            Assert.That(tilaus.Tilausrivit, Is.InstanceOf<ArrayList>());
        }

        [Test]
        public void AsetaTilauksellePoyta()
        {
            tilaus.Poyta = new Poyta(1, 1, Varaustilanne.Varattu);
            Assert.That(tilaus.Poyta, Is.InstanceOf<Poyta>());
            Assert.That(tilaus.Poyta, Is.Not.Null);
        }

        [Test]
        public void AsetaTilaukselleAsiakas()
        {
            tilaus.Asiakas = new Asiakas();
            Assert.That(tilaus.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.That(tilaus.Asiakas, Is.Not.InstanceOf<BonusAsiakas>());
        }

        [Test]
        public void AsetaTilaukselleBonusAsiakas()
        {
            tilaus.Asiakas = new BonusAsiakas();
            Assert.That(tilaus.Asiakas, Is.InstanceOf<Asiakas>());
            Assert.That(tilaus.Asiakas, Is.InstanceOf<BonusAsiakas>());
        }

        [Test]
        public void LisaaTilaukselleAteria()
        {
            var lihapullat = new Ateria(1, "Lihapullat ja muussi", 11.50);
            tilaus.LisaaAteria(lihapullat, 1);
            ArrayList tilausrivit = tilaus.Tilausrivit;
            Tilausrivi rivi = (Tilausrivi)tilausrivit[0];

            Assert.AreEqual(1, rivi.Ateria.Id);
            Assert.AreEqual("Lihapullat ja muussi", rivi.Ateria.Nimi);
            Assert.AreEqual(11.50, rivi.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(1, rivi.Maara);

            var nakit = new Ateria(2, "Lihapullat ja nakit", 11.60);
            tilaus.LisaaAteria(nakit, 3);

            ArrayList ateriat2 = tilaus.Tilausrivit;
            Tilausrivi rivi2 = (Tilausrivi)ateriat2[1];
            Assert.AreEqual(2, ateriat2.Count);
            Assert.AreEqual("Lihapullat ja nakit", rivi2.Ateria.Nimi);
            Assert.AreEqual(11.60, rivi2.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(3, rivi2.Maara);
        }

        [Test]
        public void UudenTilauksenTilaOnVahvistamaton()
        {
            Assert.AreEqual(false, tilaus.OnkoVahvistettu());
        }

        [Test]
        public void VahvistaTilauksenTila()
        {
            tilaus.MerkitseVahvistetuksi();
            Assert.AreEqual(true, tilaus.OnkoVahvistettu());
        }

        [Test]
        public void LaskeTilauksenKokonaishintaKunTilausTyhja()
        {
            var kokonaishinta = tilaus.LaskeKokonaishinta();
            Assert.AreEqual(0.0, kokonaishinta, 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunYksiAteria()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50);
            tilaus.LisaaAteria(ateria, 1);
            Assert.AreEqual(13.11, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunUseampiAteria()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50);
            tilaus.LisaaAteria(ateria, 1);

            ateria = new Ateria(2, "Cheese Burger", 9.70);
            tilaus.LisaaAteria(ateria, 1);

            Assert.AreEqual(24.17, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunYksiAteriaJaUseampiKpl()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50);
            tilaus.LisaaAteria(ateria, 3);
            Assert.AreEqual(39.33, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaBonusAsiakkaalle()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50);
            tilaus.LisaaAteria(ateria, 3);
            tilaus.Asiakas = new BonusAsiakas();
            Assert.AreEqual(33.43, tilaus.LaskeKokonaishinta(), 0.01);
        }
    }
}
