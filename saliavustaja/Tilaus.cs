using System;
using System.Collections.Generic;

namespace Saliavustaja
{
    public class Tilaus
    {
        int tilausnumero = 0;
        Poyta poyta = null;
        Asiakas asiakas = null;
        List<Ateria> ateriat = new List<Ateria>();
        TapahtumanTila tapahtumanTila = TapahtumanTila.Vahvistamaton;

        public List<Ateria> Ateriat
        {
            get { return ateriat;}
        }

        public Poyta Poyta
        {
            get { return poyta; }
            set { poyta = value; }
        }

        public Asiakas Asiakas
        {
            get { return asiakas; }
            set { asiakas = value; }
        }

        public int Tilausnumero
        {
            get { return tilausnumero; }
            set { tilausnumero = value; }
        }


        public void LisaaAteria(Ateria ateria)
        {
            ateriat.Add(ateria);
        }

        public void Vahvista()
        {
            tapahtumanTila = TapahtumanTila.Vahvistettu;
        }

        public bool OnkoVahvistettu()
        {
            if (tapahtumanTila == TapahtumanTila.Vahvistettu)
                return true;

            return false;
        }
    }
}
