using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja
{
    public class Poyta
    {
        Poydantila varaustilanne;

        public Poyta()
        {
            varaustilanne = Poydantila.Vapaa;
        }

        public Poydantila GetVaraustilanne()
        {
            return varaustilanne;
        }

        public void Varaa()
        {
            varaustilanne = Poydantila.Varattu;
        }

        public void Vapauta()
        {
            varaustilanne = Poydantila.Vapaa;
        }
    }
}
