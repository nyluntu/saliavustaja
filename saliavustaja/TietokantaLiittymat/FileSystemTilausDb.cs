using Saliavustaja.Entiteetit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saliavustaja.TietokantaLiittymat
{
    public class FileSystemTilausDb : TilausDb
    {
        protected static int seuraavaId = 1;
        protected Hashtable tilaukset = new Hashtable();
        string tiedostonPolku = "";
        BinaryFormatter binaryFormatter = null;

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

        public override void Uusi(Tilaus tilaus)
        {
            tilaukset[seuraavaId] = tilaus;
            seuraavaId++;

            using (FileStream fileStreamOut = File.Create(tiedostonPolku))
            {
                // TODO: jotain ongelmia kun tietoja tallennetaan useammin.
                for (int i = 1; i <= tilaukset.Count; i++)
                    binaryFormatter.Serialize(fileStreamOut, tilaukset[i]);

                fileStreamOut.Flush();
            }
        }

        public override Tilaus Hae(int tilausnumero)
        {
            Tilaus tilaus = (Tilaus)tilaukset[tilausnumero];

            if (tilaus == null)
                return null;

            return new Tilaus(tilausnumero, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm);
        }

        public override List<Tilaus> HaeKaikki()
        {
            List<Tilaus> kaikkiTilaukset = new List<Tilaus>();
            for (int i = 1; i <= tilaukset.Count; i++)
            {
                Tilaus tilaus = (Tilaus)tilaukset[i];
                kaikkiTilaukset.Add(new Tilaus(i, tilaus.Tilausrivit, tilaus.Poyta, tilaus.Asiakas, tilaus.TapahtumanTila, tilaus.Pvm));
            }
            return kaikkiTilaukset;
        }

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