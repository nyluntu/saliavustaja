using NUnit.Framework;
using Saliavustaja.Entiteetit;

namespace SaliavustajaTests
{
    [TestFixture]
    class PoytaTest
    {
        [Test]
        public void KuuluisiLuodaPoytaOlio()
        {
            Poyta poyta = new Poyta(1, 5, Varaustilanne.Vapaa);
            Assert.AreEqual(1, poyta.Id);
            Assert.AreEqual(5, poyta.PaikkojenMaara);
        }

        [Test]
        public void KuuluisiTarkistaaOnkoLuotuPoytaVarattu()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Varattu);
            Assert.AreEqual(true, poyta.OnkoVarattu());
        }

        [Test]
        public void KuuluisiTarkistaaOnkoLuotuPoytaVapaa()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Vapaa);
            Assert.AreEqual(false, poyta.OnkoVarattu());
        }

        [Test]
        public void KuuluisiVarataPoyta()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Vapaa);
            poyta.VaraaPoyta();
            Assert.AreEqual(true, poyta.OnkoVarattu());
        }

        [Test]
        public void KuuluisiVapauttaaPoyta()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Varattu);
            poyta.VapautaPoyta();
            Assert.AreEqual(false, poyta.OnkoVarattu());
        }

        [Test]
        public void KuuluisiTulostaaPoydastaMerkkijono()
        {
            Poyta poyta = new Poyta(6, 5, Varaustilanne.Vapaa);
            Assert.AreEqual("Pöytä 6, paikkoja 5, VAPAA", poyta.ToString());
            poyta.VaraaPoyta();
            Assert.AreEqual("Pöytä 6, paikkoja 5, VARATTU", poyta.ToString());
        }
    }
}
