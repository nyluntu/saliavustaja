using Saliavustaja.Rajapinnat;
using Saliavustaja;
using Saliavustaja.Entiteetit;
using Saliavustaja.TietokantaLiittymat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaliavustajaHarjoitus
{
    public class OmaTilauksenVastaanotto
    {
        TilausDb tilausTietokanta;
        PoytaDb poytaTietokanta;
        BonusAsiakasDb asiakasTietokanta;

        public OmaTilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb)
        {
            this.tilausTietokanta = tilausDb;
            this.poytaTietokanta = poytaDb;
            this.asiakasTietokanta = null;
        }

        public OmaTilauksenVastaanotto(TilausDb tilausDb, PoytaDb poytaDb, BonusAsiakasDb asiakasDb)
            : this(tilausDb, poytaDb)
        {
            this.asiakasTietokanta = asiakasDb;
        }

        public void VastaanotaTilaus(Tilaus tilaus)
        {
            tilaus.VahvistaTilaus();

            tilausTietokanta.Uusi(tilaus);

            poytaTietokanta.VaraaPoyta(tilaus.Poyta.Id);
        }
    }
}
