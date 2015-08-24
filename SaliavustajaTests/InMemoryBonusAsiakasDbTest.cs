using NUnit.Framework;
using Saliavustaja;
using Saliavustaja.TietokantaLiittymat;
using System.Collections.Generic;

namespace SaliavustajaTests
{
    [TestFixture]
    public class InMemoryBonusAsiakasDbTest
    {

        InMemoryBonusAsiakasDb asiakasDb;

        [TestFixtureSetUp]
        public void TestienAlustus()
        {
            asiakasDb = new InMemoryBonusAsiakasDb();
            BonusAsiakas asiakas = new BonusAsiakas();
            asiakasDb.Uusi(asiakas);
            BonusAsiakas asiakas2 = new BonusAsiakas();
            asiakasDb.Uusi(asiakas2);
            BonusAsiakas asiakas3 = new BonusAsiakas();
            asiakasDb.Uusi(asiakas3);
            BonusAsiakas asiakas4 = new BonusAsiakas();
            asiakasDb.Uusi(asiakas4);
        }

        [Test]
        public void HaeAsiakasAsiakasnumerolla()
        {
            BonusAsiakas asiakasTietokannasta = asiakasDb.Hae(3);
            Assert.That(asiakasTietokannasta, Is.Not.Null);
            Assert.AreEqual(3, asiakasTietokannasta.Id);
            Assert.AreEqual(0.0, asiakasTietokannasta.Etupisteet);
        }

        [Test]
        public void HaeKaikkiAsiakkaatTietokannasta()
        {
            List<BonusAsiakas> asiakkaat = asiakasDb.HaeKaikki();
            Assert.AreEqual(4, asiakkaat.Count);
        }

        [Test]
        public void TallennaAsiakkaanMuutoksetTietokantaan()
        {
            BonusAsiakas asiakasTietokannasta = asiakasDb.Hae(1);
            asiakasTietokannasta.KerrytaPisteita(200);
            asiakasTietokannasta.KerrytaPisteita(142);
            asiakasTietokannasta.KerrytaPisteita(360);
            Assert.AreEqual(14.04, asiakasTietokannasta.Etupisteet, 0.01);

            asiakasDb.TallennaMuutokset(asiakasTietokannasta);
            BonusAsiakas asiakasTietokannasta2 = asiakasDb.Hae(1);
            Assert.AreEqual(1, asiakasTietokannasta2.Id);
            Assert.AreEqual(14.04, asiakasTietokannasta2.Etupisteet, 0.01);

            double maksettavaSumma = asiakasTietokannasta2.OstaEtupisteilla(90);
            asiakasDb.TallennaMuutokset(asiakasTietokannasta2);
            BonusAsiakas asiakasTietokannasta3 = asiakasDb.Hae(1);
            Assert.AreEqual(1, asiakasTietokannasta3.Id);
            Assert.AreEqual(0, asiakasTietokannasta3.Etupisteet, 0.01);
            Assert.AreEqual(75.96, maksettavaSumma, 0.01);
        }
    }
}
