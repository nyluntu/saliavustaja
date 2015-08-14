using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Saliavustaja
{
    public class TiedostoDb : Db
    {
        public override List<Tilaus> HaeKaikkiTilaukset()
        {
            throw new NotImplementedException();
        }

        public override Tilaus HaeTilaus(int tilausnumero)
        {
            throw new NotImplementedException();
        }

        public override void Tallenna(Tilaus tilaus)
        {
            throw new NotImplementedException();
        }
    }
}
