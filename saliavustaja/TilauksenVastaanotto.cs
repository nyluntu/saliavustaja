using System;

namespace Saliavustaja
{
    public class TilauksenVastaanotto
    {
        Db tietokanta = new TiedostoDb();

        public int Tallenna(Tilaus tilaus)
        {
            tietokanta.Tallenna(tilaus);
            return tietokanta.ViimeisinTilausnumero;
        }

        public int TallennaJaVahvista(Tilaus tilaus)
        {
            tilaus.Vahvista();
            return this.Tallenna(tilaus);
        }
    }
}