using NUnit.Framework;
using Saliavustaja;
using Saliavustaja.TietokantaLiittymat;

namespace SaliavustajaTests
{
    [TestFixture]
    public class InMemoryBonusAsiakasDbTest
    {

        InMemoryBonusAsiakasDb asiakasDb;

        [SetUp]
        public void TestienAlustus()
        {
            asiakasDb = new InMemoryBonusAsiakasDb();
        }

        [Test]
        public void LisaaTietokantaanBonusAsiakkaita()
        {
            BonusAsiakas asiakas = new BonusAsiakas();
            asiakasDb.Tallenna(asiakas);
            BonusAsiakas asiakasTietokannasta = asiakasDb.Hae(1);

            Assert.That(asiakasTietokannasta, Is.Not.Null);
            Assert.AreEqual(1, asiakasTietokannasta.Id);
            Assert.AreEqual(0.0, asiakasTietokannasta.Etupisteet);
        }

        // Bonusasikas tallennettava tietokantaan, haettava tietokannasta ja haettava kaikki.
        // Ohjelmassa bonusasiakkaat voidaan lataa valmiiksi ja käytettävä siten ohjelmassa.
    }
}
