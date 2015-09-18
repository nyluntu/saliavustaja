using NUnit.Framework;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaliavustajaTests
{
    [TestFixture]
    public class FileSystemTilausDbTest : TilausDbBaseTest
    {
       FileSystemTilausDb tilausDb;
        string tietokannanPolku = "C:\\Temp\\tilaukset.dat";

        [TestFixtureTearDown]
        public void TestienLopetus()
        {
            File.Delete(tietokannanPolku);
        }

        [Test]
        public void HyvaksymisTesti() {
            // Luodaan uusi tiedostojärjestelmää käsittelevä luokka.
            tilausDb = new FileSystemTilausDb(tietokannanPolku);

            // Haetaan tilaukset ja tilauksia ei kuulu olla yhtään.
            List<Tilaus> tilaukset = tilausDb.HaeKaikki();
            Assert.AreEqual(0, tilaukset.Count);

            // Lisätään tilauksia ja haetaan jälleen kerran kaikki tilaukset.
            // Tilauksia kuuluisi olla lisätty määrä.
            foreach (Tilaus tilaus in LuoTilauksia())
                tilausDb.Uusi(tilaus);
            tilaukset = tilausDb.HaeKaikki();
            Assert.AreEqual(2, tilaukset.Count);

            // Tarkistetaan viimeisen tilauksen tietoja äsken lisätyistä.
            Tilaus viimeinenTilaus = tilaukset.LastOrDefault();
            Assert.AreEqual(tilausDb.SeuraavaId - 1, viimeinenTilaus.Tilausnumero);
            Tilausrivi tilausrivi = viimeinenTilaus.Tilausrivit[0];
            Assert.AreEqual("Kanasalaatti", tilausrivi.Ateria.Nimi);

            // Luodaan uusi tilaus ja tarkistetaan tallentuiko oikein.
            // Tarkistetaan luodun tilauksen tietoja.
            tilausDb.Uusi(LuoTilaus("Pihvi, aterian tallennus testi"));
            tilaukset = tilausDb.HaeKaikki();
            viimeinenTilaus = tilaukset.LastOrDefault();
            tilausrivi = viimeinenTilaus.Tilausrivit[0];
            Ateria ateria = tilausrivi.Ateria;
            Assert.AreEqual("Pihvi, aterian tallennus testi", ateria.Nimi);

            // Yritetään hakea tuntematon tilaus eli tilaus, jota 
            // tietokannassa ei ole.
            Tilaus tuntematonTilaus = tilausDb.Hae(99);
            Assert.IsNull(tuntematonTilaus);

            // Haetaan yksittäinen tilaus tunnisteella ja tarkistetaan
            // löydetyn tilauksen tietoja.
            Tilaus loytynytTilaus = tilausDb.Hae(1);
            Assert.IsNotNull(loytynytTilaus);
            Assert.IsNotNull(loytynytTilaus.Asiakas);
            Assert.IsNotNull(loytynytTilaus.Poyta);
            Assert.AreEqual(1, loytynytTilaus.Tilausnumero);
            Assert.AreEqual(2, loytynytTilaus.Tilausrivit.Count);
        }

        public override void LuoUusiTilaus()
        {
            throw new NotImplementedException();
        }

        public override void HaeTilausTunnisteella()
        {
            throw new NotImplementedException();
        }

        public override void HaeKaikkiTilaukset()
        {
            throw new NotImplementedException();
        }

        public override void HaeTilausTunnisteellaMuttaTilaustaEiLoydy()
        {
            throw new NotImplementedException();
        }
    }
}
