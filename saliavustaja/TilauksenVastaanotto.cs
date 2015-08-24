using System;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        TilausDb tilausDb;
        PoytaDb poytaDb;

        public TilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb)
        {
            this.tilausDb = tilausDb;
            this.poytaDb = poytaDb;
        }

        public void VastaanotaTilaus(Tilaus tilaus)
        {
            try
            {
                if (tilaus.Poyta == null)
                    throw new Exception("Pöytää ei ole valittu. Tilausta ei voitu vahvistaa.");

                Poyta poyta = poytaDb.Hae(tilaus.Poyta.Tunnus);
                if (poyta.OnkoVarattu())
                    throw new Exception("Pöytä on jo varattu. Tilausta ei voitu vahvistaa.");

                poytaDb.VaraaPoyta(poyta.Tunnus);
                tilaus.MerkitseVahvistetuksi();
                tilausDb.Uusi(tilaus);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}