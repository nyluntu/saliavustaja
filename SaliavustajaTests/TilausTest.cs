using NUnit.Framework;
using Saliavustaja;
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
            Assert.AreEqual(0, tilaus.Ateriat.Count);
            Assert.That(tilaus.Ateriat, Is.InstanceOf<List<Ateria>>());
        }

        [Test]
        public void AsetaTilauksellePoyta()
        {
            tilaus.Poyta = new Poyta(1, 1);
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
            var ateria = new Ateria();
            ateria.Nimi = "Lihapullat ja muussi";
            ateria.Maara = 1;
            tilaus.LisaaAteria(ateria);
        
            List<Ateria> ateriat = tilaus.Ateriat;
            Assert.AreEqual("Lihapullat ja muussi", ateriat.FirstOrDefault().Nimi);
            Assert.AreEqual(1, ateriat.FirstOrDefault().Maara);

            var ateria2 = new Ateria();
            ateria2.Nimi = "Lihapullat ja nakit";
            ateria2.Maara = 3;
            tilaus.LisaaAteria(ateria2);
            List<Ateria> ateriat2 = tilaus.Ateriat;
            Assert.AreEqual(2, ateriat2.Count());
            Assert.AreEqual("Lihapullat ja nakit", ateriat2.LastOrDefault().Nimi);
            Assert.AreEqual(3, ateriat2.LastOrDefault().Maara);
        }

        [Test]
        public void UudenTilauksenTilaOnVahvistamaton()
        {
            Assert.AreEqual(false, tilaus.OnkoVahvistettu());
        }

        [Test]
        public void VahvistaTilauksenTila()
        {
            tilaus.Vahvista();
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
            var ateria = new Ateria();
            ateria.Nimi = "Chicken Wings";
            ateria.Maara = 1;
            ateria.Tunniste = 1;
            ateria.VerotonHintaKpl = 11.50;
            tilaus.LisaaAteria(ateria);
            Assert.AreEqual(13.10, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunUseampiAteria()
        {
            var ateria = new Ateria();
            ateria.Nimi = "Chicken Wings";
            ateria.Maara = 1;
            ateria.Tunniste = 1;
            ateria.VerotonHintaKpl = 11.50;
            tilaus.LisaaAteria(ateria);

            ateria = new Ateria();
            ateria.Nimi = "Cheese Burger";
            ateria.Maara = 1;
            ateria.Tunniste = 2;
            ateria.VerotonHintaKpl = 9.70;
            tilaus.LisaaAteria(ateria);

            Assert.AreEqual(24.17, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaKunYksiAteriaJaUseampiKpl()
        {
            var ateria = new Ateria();
            ateria.Nimi = "Chicken Wings";
            ateria.Maara = 3;
            ateria.Tunniste = 1;
            ateria.VerotonHintaKpl = 11.50;
            tilaus.LisaaAteria(ateria);
            Assert.AreEqual(39.33, tilaus.LaskeKokonaishinta(), 0.01);
        }

        [Test]
        public void LaskeKokonaishintaBonusAsiakkaalle()
        {
            var ateria = new Ateria();
            ateria.Nimi = "Chicken Wings";
            ateria.Maara = 3;
            ateria.Tunniste = 1;
            ateria.VerotonHintaKpl = 11.50;
            tilaus.LisaaAteria(ateria);
            tilaus.Asiakas = new BonusAsiakas();
            Assert.AreEqual(33.43, tilaus.LaskeKokonaishinta(), 0.01);
        }
    }
}
