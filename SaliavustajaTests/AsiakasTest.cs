using NUnit.Framework;
using Saliavustaja;

namespace SaliavustajaTests
{
    [TestFixture]
    public class AsiakasTest
    {
        [Test]
        public void LaskeAsiakkaalleEtuhinta()
        {
            Asiakas asiakas = new Asiakas();
            Assert.AreEqual(33.30, asiakas.LaskeAsiakkaanEtuhinta(33.30), 0.01);
        }

        [Test]
        public void LaskeBonusAsiakkaalleEtuhinta()
        {
            Asiakas asiakas = new BonusAsiakas();
            Assert.AreEqual(28.30, asiakas.LaskeAsiakkaanEtuhinta(33.30), 0.01);
        }
    }
}
