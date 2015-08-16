using System;
using System.Collections;
using System.Collections.Generic;

namespace Saliavustaja
{
    public class RamPoytaLiittyma
    {
        Hashtable poydat = new Hashtable();

        public RamPoytaLiittyma()
        {
            poydat.Add(1, new Poyta(1, 4, Varaustilanne.Vapaa));
            poydat.Add(2, new Poyta(2, 2, Varaustilanne.Vapaa));
            poydat.Add(3, new Poyta(3, 2, Varaustilanne.Vapaa));
            poydat.Add(4, new Poyta(4, 6, Varaustilanne.Vapaa));
            poydat.Add(5, new Poyta(5, 10, Varaustilanne.Vapaa));
            poydat.Add(6, new Poyta(6, 10, Varaustilanne.Vapaa));
            poydat.Add(7, new Poyta(7, 4, Varaustilanne.Vapaa));
            poydat.Add(8, new Poyta(8, 4, Varaustilanne.Vapaa));
            poydat.Add(9, new Poyta(9, 4, Varaustilanne.Vapaa));
            poydat.Add(10, new Poyta(10, 4, Varaustilanne.Vapaa));
        }

        public Poyta Hae(int tunnus)
        {
            return (Poyta)poydat[tunnus];
        }

        public List<Poyta> HaeKaikki()
        {
            List<Poyta> kaikkiPoydat = new List<Poyta>();
            for (int i = 1; i <= poydat.Count; i++)
            {
                Poyta poyta = (Poyta)poydat[i];
                kaikkiPoydat.Add(poyta);
            }
            return kaikkiPoydat;
        }

        public void VaraaPoyta(int tunnus)
        {
            Poyta poyta = (Poyta)poydat[tunnus];
            poyta.Varaustilanne = Varaustilanne.Varattu;
        }
    }
}