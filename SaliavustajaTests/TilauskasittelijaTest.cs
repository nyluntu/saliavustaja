using NUnit.Framework;
using Saliavustaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaliavustajaTests
{
    [TestFixture]
    public class TilauskasittelijaTest
    {
        Tilauskasittelija tilausKasittelija = null;

        [SetUp]
        public void TestiAlustus()
        {
            tilausKasittelija = new Tilauskasittelija();
        }

        [Test]
        public void LuoUusiTilaus()
        {
            tilausKasittelija.LuoUusi();
            Assert.That(tilausKasittelija.GetTilaus(), Is.InstanceOf(typeof(Tilaus)));
        }

        [Test]
        public void AsetaTilauksellePoyta()
        {
            tilausKasittelija.LuoUusi();
            Assert.AreEqual(0, tilausKasittelija.GetPoyta());
            tilausKasittelija.SetPoyta(5);
            Assert.AreEqual(5, tilausKasittelija.GetPoyta());
            Assert.AreNotEqual(0, tilausKasittelija.GetPoyta());
            tilausKasittelija.SetPoyta(1);
            Assert.AreEqual(1, tilausKasittelija.GetPoyta());
            Assert.AreNotEqual(0, tilausKasittelija.GetPoyta());
        }

        [Test]
        public void LisaaTilaukseenAteria()
        {
            tilausKasittelija.LuoUusi();
            tilausKasittelija.LisaaAteria("Lihapullat ja muussi", 1);
            tilausKasittelija.LisaaAteria("Lihapullat ja nakit", 3);
            tilausKasittelija.LisaaAteria("Jäätelöannos", 4);

            List<Ateria> ateriat = tilausKasittelija.HaeKaikkiAteriat();
            Assert.AreEqual("Lihapullat ja muussi", ateriat.FirstOrDefault().Nimi);
            Assert.AreEqual(1, ateriat.FirstOrDefault().Maara);
            Assert.AreEqual("Jäätelöannos", ateriat.LastOrDefault().Nimi);
            Assert.AreEqual(4, ateriat.LastOrDefault().Maara);
            Assert.AreEqual(3, ateriat.Count);
        }

        [Test]
        public void VahvistaTilaus()
        {
            tilausKasittelija.LuoUusi();
            Assert.AreEqual(Tilauksentila.Alustava, tilausKasittelija.GetTilaus().Tilanne);

            tilausKasittelija.Vahvista();
            Assert.AreEqual(Tilauksentila.Vahvistettu, tilausKasittelija.GetTilaus().Tilanne);
        }

        [Test]
        public void TallennaTilaus()
        {
            tilausKasittelija.TallennaTilaus();
            // tallennettaisiinko serialisoituna tekstitiedostoon?
            // mitenkä useampi tilaus?
        }
    }
}
