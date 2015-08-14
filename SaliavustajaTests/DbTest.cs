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
    public class DbTest : TilausBaseTest
    {

        [TestFixtureSetUp]
        public void TestiAlustus()
        {
            tietokanta = new Db();
            LisaaTilauksiaTietokantaan();
        }

        [Test] 
        public void TarkistaTilaustenMaara()
        {
            Assert.AreEqual(3, tietokanta.HaeKaikkiTilaukset().Count);
        }

        [Test]
        public void TarkistaViimeisinTilausnumero()
        {
            Assert.AreEqual(3, tietokanta.ViimeisinTilausnumero);
        }

        [Test]
        public void HaeKaikkiTilauksetPalauttaaListan()
        {
            Assert.That(tietokanta.HaeKaikkiTilaukset(), Is.InstanceOf<List<Tilaus>>());
        }

        [Test]
        public void HaeYksiTilausTilausnumerolla()
        {
            var entinenTilaus = tietokanta.HaeTilaus(3);
            Assert.AreEqual(3, entinenTilaus.Tilausnumero);
            Assert.AreEqual("Chocolate Fondant", entinenTilaus.Ateriat.LastOrDefault().Nimi);
            Assert.AreEqual(3, entinenTilaus.Ateriat.LastOrDefault().Maara);
        }

        [Test]
        public void UudenTietokantaObjektinLuontiEiTuhoaTietoja()
        {
            Db tietokanta2 = new Db();
            Assert.AreNotEqual(0, tietokanta2.HaeKaikkiTilaukset().Count());
            Assert.AreEqual(3, tietokanta2.HaeKaikkiTilaukset().Count());
        }


        
       
    }
}
