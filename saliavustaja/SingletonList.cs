using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saliavustaja
{
    public class SingletonList
    {
        static List<Tilaus> instance;

        SingletonList() { }

        public static List<Tilaus> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new List<Tilaus>();
                }
                return instance;
            }
        }
    }
}
