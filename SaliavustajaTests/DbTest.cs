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
    public class DbTest
    {
        Db tietokanta = null;

        [SetUp]
        public void TestiAlustus()
        {
            tietokanta = new Db();
        }

        [Test]
        public void TallennaTilaus()
        {
            var tilaus = new Tilaus();
            tietokanta.Tallenna(tilaus);
        }

        [Test]
        public void TallennaTilausJaTarkistaViimeisinTilausnumero()
        {
            tietokanta.Tallenna(new Tilaus());
            Assert.AreEqual(1, tietokanta.ViimeisinTilausnumero);
            tietokanta.Tallenna(new Tilaus());
            Assert.AreEqual(2, tietokanta.ViimeisinTilausnumero);
            tietokanta.Tallenna(new Tilaus());
            Assert.AreEqual(3, tietokanta.ViimeisinTilausnumero);
        }
        

        [Test]
        public void HaeTallennetutTilaukset()
        {
            tietokanta.Tallenna(new Tilaus());
            tietokanta.Tallenna(new Tilaus());
            tietokanta.Tallenna(new Tilaus());
            Assert.AreEqual(3, tietokanta.HaeKaikkiTilaukset().Count);
            Assert.That(tietokanta.HaeKaikkiTilaukset(), Is.InstanceOf<List<Tilaus>>());
        }

        [Test]
        public void HaeTilausTilausnumerolla()
        {
            tietokanta.Tallenna(UusiTilaus());
            tietokanta.Tallenna(UusiTilaus());

            var tilaus = UusiTilaus();
            tilaus.LisaaAteria(new Ateria() { Nimi = "Jäätelöylläri kahdelle", Maara = 1 });
            tietokanta.Tallenna(tilaus);

            var entinenTilaus = tietokanta.HaeTilaus(3);
            Assert.AreEqual(3, entinenTilaus.Tilausnumero);
            Assert.AreEqual("Jäätelöylläri kahdelle", entinenTilaus.Ateriat.LastOrDefault().Nimi);
            Assert.AreEqual(1, entinenTilaus.Ateriat.LastOrDefault().Maara);
        }

        Tilaus UusiTilaus()
        {
            var tilaus = new Tilaus();
            tilaus.LisaaAteria(new Ateria() { Nimi = "Lihapullat ja muussi", Maara = 2 });
            tilaus.LisaaAteria(new Ateria() { Nimi = "Alkukeitto", Maara = 2 });
            return tilaus;
        }
    }
}
