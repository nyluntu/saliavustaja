using System;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        RamTilausLiittyma tilausTietokantaLiittyma;
        RamPoytaLiittyma poytaTietokantaLiittyma;

        public TilauksenVastaanotto(RamTilausLiittyma tilausTietokantaLiittyma, RamPoytaLiittyma poytaTietokantaLiittyma)
        {
            this.tilausTietokantaLiittyma = tilausTietokantaLiittyma;
            this.poytaTietokantaLiittyma = poytaTietokantaLiittyma;
        }

        public void VastaanotaTilaus(Tilaus tilaus)
        {
            try
            {
                if (tilaus.Poyta == null)
                    throw new Exception("Pöytää ei ole valittu. Tilausta ei voitu vahvistaa.");

                Poyta poyta = poytaTietokantaLiittyma.Hae(tilaus.Poyta.Tunnus);
                if (poyta.OnkoVarattu())
                    throw new Exception("Pöytä on jo varattu. Tilausta ei voitu vahvistaa.");

                poytaTietokantaLiittyma.VaraaPoyta(poyta.Tunnus);
                tilaus.MerkitseVahvistetuksi();
                tilausTietokantaLiittyma.Tallenna(tilaus);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}