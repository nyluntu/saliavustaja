using NUnit.Framework;
using Saliavustaja.Entiteetit;

namespace SaliavustajaTests
{
    [TestFixture]
    public class AsiakasTest
    {
        [Test]
        public void LaskeEtuhintaAsiakkaalle()
        {
            Asiakas asiakas = new Asiakas();
            Assert.AreEqual(33.30, asiakas.LaskeHinta(33.30), 0.01);
        }

        [Test]
        public void LaskeEtuhintaBonusAsiakkaalle()
        {
            Asiakas asiakas = new BonusAsiakas();
            Assert.AreEqual(28.30, asiakas.LaskeHinta(33.30), 0.01);
        }

        [Test]
        public void LaskeEtupisteetBonusAsiakkaalle()
        {
            BonusAsiakas asiakas = new BonusAsiakas();
            double etupisteet = asiakas.LaskeEtupisteet(75);
            Assert.AreEqual(1.5, etupisteet);
            etupisteet = asiakas.LaskeEtupisteet(150);
            Assert.AreEqual(3.0, etupisteet);
            etupisteet = asiakas.LaskeEtupisteet(351);
            Assert.AreEqual(7.0, etupisteet);
        }
        [Test]
        public void KerrytaEtupisteetBonusAsiakkaalle()
        {
            BonusAsiakas asiakas = new BonusAsiakas();
            Assert.AreEqual(0, asiakas.Etupisteet);

            asiakas.KerrytaEtupisteita(75);
            Assert.AreEqual(1.5, asiakas.Etupisteet);
            asiakas.KerrytaEtupisteita(75);
            Assert.AreEqual(3.0, asiakas.Etupisteet);
            asiakas.KerrytaEtupisteita(25);
            Assert.AreEqual(3.5, asiakas.Etupisteet);
        }

        [Test]
        public void OstaEtupisteillaJaPaivitaEtupisteTilanne()
        {
            BonusAsiakas asiakas = new BonusAsiakas(1, 245);
            Assert.AreEqual(0, asiakas.OstaEtupisteilla(120));
            Assert.AreEqual(125, asiakas.Etupisteet);
            Assert.AreEqual(48, asiakas.OstaEtupisteilla(173));
            Assert.AreEqual(0, asiakas.Etupisteet);

            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(75);
            asiakas.KerrytaEtupisteita(50);
            Assert.AreEqual(10, asiakas.Etupisteet);
            Assert.AreEqual(33, asiakas.OstaEtupisteilla(43));
            Assert.AreEqual(0, asiakas.Etupisteet);
        }

    }
}
