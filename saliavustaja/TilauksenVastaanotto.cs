using System;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        RamTilausLiittyma tietokantaLiittyma;
        
        public TilauksenVastaanotto(RamTilausLiittyma tietokantaLiittyma)
        {
            this.tietokantaLiittyma = tietokantaLiittyma;
        }

        public void VastaanotaTilaus(Tilaus tilaus)
        {
            tietokantaLiittyma.LuoUusi(tilaus);
        }
    }
}