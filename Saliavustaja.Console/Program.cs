using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saliavustaja;
using Saliavustaja.Entiteetit;
using Saliavustaja.Rajapinnat;
using Saliavustaja.TietokantaLiittymat;

namespace Saliavustaja.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Poyta poyta1 = new Poyta(11, 6, Varaustilanne.Vapaa);

            Asiakas pekka = new BonusAsiakas();

            Ateria ateria1 = new Ateria(10, "Makkaraperunat", 12.5, 0.14);

            Tilaus tilaus = new Tilaus();
            tilaus.Asiakas = pekka;
            tilaus.Poyta = poyta1;
            tilaus.LisaaAteria(ateria1, 3);


            TilausDb tilausTietokanta = new FileSystemTilausDb("C:\\Temp\tietokanta_testi.dat");
            PoytaDb poytaTietokanta = new InMemoryPoytaDb();

            TilauksenVastaanotto tilauksenVastaanotto = new TilauksenVastaanotto(tilausTietokanta, poytaTietokanta);
            tilauksenVastaanotto.VastaanotaTilaus(tilaus);

        }
    }
}
