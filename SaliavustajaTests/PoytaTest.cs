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
        public void VaraaPoyta()
        {
            Poyta poyta = new Poyta(2, 4,Varaustilanne.Vapaa);
            poyta.Varaa();
            Assert.AreEqual(true, poyta.OnkoVarattu());
        }

        [Test]
        public void VaraaJaVapautaPoyta()
        {
            Poyta poyta = new Poyta(3, 4, Varaustilanne.Vapaa);
            poyta.Varaa();
            poyta.Vapauta();
            Assert.AreEqual(false, poyta.OnkoVarattu());
        }

        [Test]
        public void VaraaJaVapautaPoytaRakentajalla()
        {
            Poyta poyta = new Poyta(3, 4, Varaustilanne.Varattu);
            Assert.AreEqual(true, poyta.OnkoVarattu());
            Poyta poyta2 = new Poyta(3, 4, Varaustilanne.Vapaa);
            Assert.AreEqual(false, poyta2.OnkoVarattu());
        }

    }
}
