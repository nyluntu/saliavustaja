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
    public class RamTilausLiittymaTest
    {
        RamTilausLiittyma liittyma;

        [TestFixtureSetUp]
        public void TestienAlustus()
        {
            liittyma = new RamTilausLiittyma();
            LisaaTilausTietokantaan();
        }

        [TestFixtureTearDown]
        public void TestienLopetus()
        {
            liittyma = null;
        }

        [Test]
        public void HaeTilausTilausnumerolla()
        {
            Tilaus tilaus = liittyma.HaeTilaus(1);
            Assert.IsNotNull(tilaus);
            Assert.IsNotNull(tilaus.Asiakas);
            Assert.IsNotNull(tilaus.Poyta);
            Assert.AreEqual(1, tilaus.Tilausnumero);
            Assert.AreEqual(2, tilaus.Tilausrivit.Count);
        }

        [Test]
        public void HaeTilausTilaustaEiLoydy()
        {
            Tilaus tilaus = liittyma.HaeTilaus(99);
            Assert.IsNull(tilaus);
        }

        [Test]
        public void HaeKaikkiTilaukset()
        {
            List<Tilaus> tilaukset = liittyma.HaeKaikkiTilaukset();
            Assert.IsNotNull(tilaukset);
            Assert.AreEqual(2, tilaukset.Count);

            Tilaus viimeinenTilaus = tilaukset.LastOrDefault();
            Assert.AreEqual(liittyma.SeuraavaId - 1, viimeinenTilaus.Tilausnumero);

            Tilausrivi tilausrivi = (Tilausrivi)viimeinenTilaus.Tilausrivit[0];
            Assert.AreEqual("Kanasalaatti", tilausrivi.Ateria.Nimi);

        }

        void LisaaTilausTietokantaan()
        {
            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            tilaus.Pvm = DateTime.Now;
            var pihvi = new Ateria(1, "Garlic Steak", 11.60);
            var lehtipihvi = new Ateria(2, "Lehtipihvi lohkoperunoilla", 13.60);
            tilaus.LisaaAteria(pihvi, 1);
            tilaus.LisaaAteria(lehtipihvi, 3);
            liittyma.LuoUusi(tilaus);

            tilaus = new Tilaus();
            tilaus.Asiakas = new Asiakas();
            tilaus.Poyta = new Poyta(1, 5, Varaustilanne.Varattu);
            tilaus.Pvm = DateTime.Now;
            var salaatti = new Ateria(1, "Kanasalaatti", 5.60);
            var lehtipihvi2 = new Ateria(2, "250g pihvi ranskalaisilla", 13.00);
            tilaus.LisaaAteria(salaatti, 1);
            tilaus.LisaaAteria(lehtipihvi2, 1);
            liittyma.LuoUusi(tilaus);
        }

    }
}
