using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Saliavustaja;

namespace SaliavustajaTests
{
    [TestFixture]
    class PoytaTest
    {
        [Test]
        public void PoytaObjektinLuominen()
        {
            Poyta poyta = new Poyta(1, 5, Varaustilanne.Vapaa);
            Assert.AreEqual(1, poyta.Tunnus);
            Assert.AreEqual(5, poyta.PaikkojenMaara);
        }

        [Test]
        public void PoydanKuuluisiOllaVarattu()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Varattu);
            Assert.AreEqual(true, poyta.OnkoVarattu());
        }

        [Test]
        public void PoydanKuuluisiOllaVapaa()
        {
            Poyta poyta = new Poyta(1, 4, Varaustilanne.Vapaa);
            Assert.AreEqual(false, poyta.OnkoVarattu());
        }

        [Test]
        public void PoydanToStringMetodinTulostus()
        {
            Poyta poyta = new Poyta(6, 5, Varaustilanne.Vapaa);
            Assert.AreEqual("Pöytä 6, paikkoja 5, VAPAA", poyta.ToString());
            poyta.Varaustilanne = Varaustilanne.Varattu;
            Assert.AreEqual("Pöytä 6, paikkoja 5, VARATTU", poyta.ToString());
        }
    }
}
