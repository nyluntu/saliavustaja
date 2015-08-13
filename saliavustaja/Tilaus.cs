using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja
{
    public class Tilaus
    {
        int poydanNumero = 0;
        Tilauksentila tilanne = Tilauksentila.Alustava;

        public int PoydanNumero
        {
            get { return poydanNumero; }
            set { poydanNumero = value; }
        }

        public Tilauksentila Tilanne
        {
            get { return tilanne; }
            set { tilanne = value; }
        }

    }
}
