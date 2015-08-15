using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja
{
    public class Tilausrivi
    {
        Ateria ateria;
        int maara;

        public Tilausrivi(Ateria ateria, int maara)
        {
            this.ateria = ateria;
            this.maara = maara;
        }

        public Ateria Ateria
        {
            get { return ateria; }
        }

        public int Maara
        {
            get { return maara; }
        }
    }
}
