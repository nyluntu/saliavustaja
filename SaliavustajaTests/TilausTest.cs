using NUnit.Framework;
using Saliavustaja.Entiteetit;
using System.Collections.Generic;

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
            Assert.That(tilaus.Tilausrivit, Is.InstanceOf<List<Tilausrivi>>());
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
            var lihapullat = new Ateria(1, "Lihapullat ja muussi", 11.50, 0.14);
            tilaus.LisaaAteria(lihapullat, 1);
            List<Tilausrivi> tilausrivit = tilaus.Tilausrivit;
            Tilausrivi rivi = tilausrivit[0];

            Assert.AreEqual(1, rivi.Ateria.Id);
            Assert.AreEqual("Lihapullat ja muussi", rivi.Ateria.Nimi);
            Assert.AreEqual(11.50, rivi.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(1, rivi.Maara);

            var nakit = new Ateria(2, "Lihapullat ja nakit", 11.60, 0.14);
            tilaus.LisaaAteria(nakit, 3);

            List<Tilausrivi> ateriat2 = tilaus.Tilausrivit;
            Tilausrivi rivi2 = ateriat2[1];
            Assert.AreEqual(2, ateriat2.Count);
            Assert.AreEqual("Lihapullat ja nakit", rivi2.Ateria.Nimi);
            Assert.AreEqual(11.60, rivi2.Ateria.VerotonHinta, 0.01);
            Assert.AreEqual(3, rivi2.Maara);
        }

        [Test]
        public void PoistaTilauksestaAteria()
        {
            var lihapullat = new Ateria(1, "Lihapullat ja muussi", 11.50, 0.14);
            tilaus.LisaaAteria(lihapullat, 1);
            var nakit = new Ateria(3, "Lihapullat ja nakit", 11.60, 0.14);
            tilaus.LisaaAteria(nakit, 2);
            Assert.AreEqual(2, tilaus.Tilausrivit.Count);

            tilaus.PoistaAteria(lihapullat);
            Assert.AreEqual(1, tilaus.Tilausrivit.Count);

            Tilausrivi tilausrivi = (Tilausrivi)tilaus.Tilausrivit[0];
            Assert.AreEqual(2, tilausrivi.Maara);
            Assert.AreEqual(3, tilausrivi.Ateria.Id);
            Assert.AreEqual("Lihapullat ja nakit", tilausrivi.Ateria.Nimi);
        }

        [Test]
        public void VaihdaTilauksenAterianMaara()
        {
            var lihapullat = new Ateria(1, "Lihapullat ja muussi", 11.50, 0.14);
            tilaus.LisaaAteria(lihapullat, 1);
            var nakit = new Ateria(3, "Lihapullat ja nakit", 11.60, 0.14);
            tilaus.LisaaAteria(nakit, 2);
            var soppa = new Ateria(5, "Nakkisoppa", 8.50, 0.14);
            tilaus.LisaaAteria(soppa, 2);

            tilaus.VaihdaAteriaMaara(nakit, 1);
            Tilausrivi tilausrivi = (Tilausrivi)tilaus.Tilausrivit[1];

            Assert.AreEqual(1, tilausrivi.Maara);
            Assert.AreEqual(3, tilausrivi.Ateria.Id);
        }

        [Test]
        public void UudenTilauksenTilaOnVahvistamaton()
        {
            Assert.AreEqual(false, tilaus.OnkoVahvistettu());
        }

        [Test]
        public void VahvistaTilauksenTila()
        {
            tilaus.VahvistaTilaus();
            Assert.AreEqual(true, tilaus.OnkoVahvistettu());
        }

        [Test]
        public void LaskeTilauksenKokonaishintaKunTilausTyhja()
        {
            var kokonaishinta = tilaus.LaskeVerollinenKokonaishinta();
            Assert.AreEqual(0.0, kokonaishinta, 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunYksiAteria()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50, 0.14);
            tilaus.LisaaAteria(ateria, 1);
            Assert.AreEqual(13.11, tilaus.LaskeVerollinenKokonaishinta(), 0.01);
            Assert.AreEqual(11.50, tilaus.LaskeVerotonKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunUseampiAteria()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50, 0.14);
            tilaus.LisaaAteria(ateria, 1);

            ateria = new Ateria(2, "Cheese Burger", 9.70, 0.14);
            tilaus.LisaaAteria(ateria, 1);

            Assert.AreEqual(24.17, tilaus.LaskeVerollinenKokonaishinta(), 0.01);
            Assert.AreEqual(21.20, tilaus.LaskeVerotonKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunYksiAteriaJaUseampiKpl()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50, 0.14);
            tilaus.LisaaAteria(ateria, 3);
            Assert.AreEqual(39.33, tilaus.LaskeVerollinenKokonaishinta(), 0.01);
            Assert.AreEqual(34.50, tilaus.LaskeVerotonKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaBonusAsiakkaalle()
        {
            var ateria = new Ateria(1, "Chicken Wings", 11.50, 0.14);
            tilaus.LisaaAteria(ateria, 3);
            tilaus.Asiakas = new BonusAsiakas();
            Assert.AreEqual(33.43, tilaus.LaskeVerollinenKokonaishinta(), 0.01);
            Assert.AreEqual(29.32, tilaus.LaskeVerotonKokonaishinta(), 0.01);
        }
    }
}
