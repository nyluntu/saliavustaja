using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saliavustaja.TietokantaLiittymat
{

    /// <summary>
    /// FileSystemTilausDb.cs
    /// 
    /// Luokka käsittelee tietokantayhteyksiä Tilaus-luokan
    /// olioiden osalta.
    /// 
    /// HUOMAA ETTÄ KYSEESSÄ ON TIEDOSTOPOHJAINEN TIETOKANTATOTEUTUS!
    /// TOTEUTUSTAPAAN VOIT KYSYÄ NEUVOA, KOSKA TALLENNETTAVIEN
    /// LUOKKIEN TÄYTYY OLLA SERIALISOITAVIA.
    /// 
    /// Luokalla on seuraavia ominaisuuksia:
    /// 
    /// 1. Hashtable tilaukset
    /// 2. static int seuraavaId = 1
    /// 3. string tiedostonPolku = "";
    /// 4. BinaryFormatter binaryFormatter = null;
    /// </summary>
    public class FileSystemTilausDb : TilausDb
    {
        protected static int seuraavaId = 1;
        protected Hashtable tilaukset = new Hashtable();
        string tiedostonPolku = "";
        BinaryFormatter binaryFormatter = null;

        /// <summary>
        /// FileSystemTilausDb(string tiedostonPolku)
        /// 
        /// Parametrillinen rakentaja, jolle parametrina annetaan
        /// tiedostopolku. Tiedostopolkua käytetään tallennus sijaintina
        /// tietokannalle. Esimerkiksi tiedostopolku voi olla muotoa:
        /// 
        /// C:\Temp\tietokanta.dat
        /// 
        /// Rakentajassa on alustettava myös binaryFormatter -ominaisuus.
        /// Tietojenkäsittelyyn tietokanta käyttää Hastablea -muistinvaraisen
        /// tietokannan tapaan.
        /// </summary>
        /// <param name="tiedostonPolku"></param>
        public FileSystemTilausDb(string tiedostonPolku)
        {
            this.tiedostonPolku = tiedostonPolku;
            binaryFormatter = new BinaryFormatter();
            LueTilauksetTietokannasta();
        }

        public int SeuraavaId
        {
            get { return seuraavaId; }
            private set { seuraavaId = value; }
        }

        /// <summary>
        /// void Uusi(Tilaus tilaus)
        /// 
        /// Metodi tallentaa tilauksen tietokantaan (Hashtable) ja
        /// tietokannan sisältö tallennetaan tietojärjestelmää.
        /// Tallennus sijaintina käytetään olion luonnin yhteydessä
        /// annettua tiedostopolkua.
        /// 
        /// Parametrina annetaan koko tilaus -olio, joka sisältää tiedot
        /// tilauksesta. 
        /// </summary>
        /// <param name="tilaus"></param>
        public override void Uusi(Tilaus tilaus)
        {
            tilaukset[seuraavaId] = tilaus;
            seuraavaId++;

            using (FileStream fileStreamOut = File.Create(tiedostonPolku))
            {
                for (int i = 1; i <= tilaukset.Count; i++)
                    binaryFormatter.Serialize(fileStreamOut, tilaukset[i]);

                fileStreamOut.Flush();
            }
        }

        /// <summary>
        /// Tilaus Hae(int tilausnumero)
        /// 
        /// TÄTÄ METODIA EI OLE KÄYTETTY MISSÄÄN
        /// </summary>
        /// <param name="tilausnumero"></param>
        /// <returns></returns>
        public override Tilaus Hae(int tilausnumero)
        {
            Tilaus tilaus = (Tilaus)tilaukset[tilausnumero];

            if (tilaus == null)
                return null;

            return new Tilaus(tilausnumero, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm);
        }

        /// <summary>
        /// List<Tilaus> HaeKaikki()
        /// 
        /// Metodi palauttaa kaikki tietokannan (hashtable) sisällön
        /// listana, joka sisältää Tilaus-olioita.
        /// 
        /// Ennen tietojen palauttamista, on tiedot luettava tiedostojärjestelmästä
        /// ja luotava Tilaus-olioiksi. Tämän jälkeen oliot voidaan palauttaa
        /// listana.
        /// </summary>
        /// <returns></returns>
        public override List<Tilaus> HaeKaikki()
        {
            LueTilauksetTietokannasta();
            List<Tilaus> kaikkiTilaukset = new List<Tilaus>();
            for (int i = 1; i <= tilaukset.Count; i++)
            {
                Tilaus tilaus = (Tilaus)tilaukset[i];
                kaikkiTilaukset.Add(new Tilaus(i, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm));
            }
            return kaikkiTilaukset;
        }

        /// <summary>
        /// Apumetodi
        /// </summary>
        void LueTilauksetTietokannasta()
        {
            if (File.Exists(tiedostonPolku))
            {
                using (FileStream stream = File.OpenRead(tiedostonPolku))
                {
                    int i = 1;
                    while (stream.Position != stream.Length)
                    {
                        Tilaus tilaus = (Tilaus)binaryFormatter.Deserialize(stream);
                        tilaukset[i] = tilaus;
                        i++;
                    }
                }
                SeuraavaId = tilaukset.Count + 1;
            }
        }
    }
}