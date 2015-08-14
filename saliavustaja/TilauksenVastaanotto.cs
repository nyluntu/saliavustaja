using System;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        Db tietokanta = new Db();

        public int VahvistaJaTallenna(Tilaus tilaus)
        {
            tietokanta.Tallenna(tilaus);
            return tietokanta.ViimeisinTilausnumero;
        }
    }
}