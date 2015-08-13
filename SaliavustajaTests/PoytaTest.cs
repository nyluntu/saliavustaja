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
    public class PoytaTest
    {
        Poyta poyta = null;

        [SetUp]
        public void AlustaTesti()
        {
            poyta = new Poyta();
        }

        [Test]
        public void VaraaPoyta()
        {
            poyta.Varaa();
            Assert.AreEqual(Poydantila.Varattu, poyta.GetVaraustilanne());
        }

        [Test]
        public void VapautaPoyta()
        {
            poyta.Vapauta();
            Assert.AreEqual(Poydantila.Vapaa, poyta.GetVaraustilanne());
        }

    }
}
