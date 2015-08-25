using NUnit.Framework;
using Saliavustaja.Entiteetit;

namespace SaliavustajaTests
{
    [TestFixture]
    public class AteriaTest
    {

        [Test]
        public void LaskeAterianVerollinenHinta()
        {
            Ateria ateria = new Ateria(1, "Lihapullia ja mummon muussia", 23.25, 0.14);
            Assert.AreEqual(26.50, ateria.LaskeVerollinenHinta(), 0.01);
        }
    }
}
