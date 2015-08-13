using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja
{
    public class Tilauskasittelija
    {
        Tilaus tilaus = null;
        List<Ateria> ateriat = null;
        int poyta = 0;

        public void LuoUusi()
        {
            tilaus = new Tilaus();
            ateriat = new List<Ateria>();
        }

        public Tilaus GetTilaus()
        {
            return tilaus;
        }

        public void SetPoyta(int poydanNumero)
        {
            poyta = poydanNumero;
        }

        public int GetPoyta()
        {
            return poyta;
        }

        public void LisaaAteria(string nimi, int maara)
        {
            var uusiAteria = new Ateria();
            uusiAteria.Nimi = nimi;
            uusiAteria.Maara = maara;
            ateriat.Add(uusiAteria);
        }

        public List<Ateria> HaeKaikkiAteriat()
        {
            return ateriat;
        }

        public void Vahvista()
        {
            tilaus.Tilanne = Tilauksentila.Vahvistettu;
        }

        public void TallennaTilaus()
        {
            throw new NotImplementedException();
        }
    }
}
