using System.Collections;
using System.Collections.Generic;
using Saliavustaja.Entiteetit;

namespace Saliavustaja.TietokantaLiittymat
{
    public class InMemoryAteriaDb : AteriaDb
    {
        Hashtable ateriat = new Hashtable();

        public InMemoryAteriaDb()
        {
            ateriat.Add(1, new Ateria(1, "Lämminsavustettua hanhenrintaa ja fenkolia", 17, 0.14));
            ateriat.Add(2, new Ateria(2, "Hirvipastramia ja viiriäisen uppomuna", 17, 0.14));
            ateriat.Add(3, new Ateria(3, "Siikaa ja jokirapua", 17, 0.14));
            ateriat.Add(4, new Ateria(4, "Härkää ja lohta", 28.50, 0.14));
            ateriat.Add(5, new Ateria(5, "Paahdettua nieriää ja lime-voikastiketta", 28.50, 0.14));
            ateriat.Add(6, new Ateria(6, "Kaldoaivin poronvasaa ja rakuunakastiketta", 34, 0.14));
            ateriat.Add(7, new Ateria(7, "Munakoisoa, paprikaa ja pinjansiementä", 27, 0.14));
            ateriat.Add(8, new Ateria(8, "Raparperia ja minttujäätelöä12 ", 12, 0.14));
            ateriat.Add(9, new Ateria(9, "Tyrnipossetti ja luomusuklaata", 12, 0.14));
            ateriat.Add(10, new Ateria(10, "Valikoima kotimaisia juustoja ja kuusenkerkkää", 13, 0.14));
        }

        public override Ateria Hae(int tunnus)
        {
            return (Ateria)ateriat[tunnus];
        }

        public override List<Ateria> HaeKaikki()
        {
            List<Ateria> kaikkiAteriat = new List<Ateria>();
            for (int i = 1; i <= ateriat.Count; i++)
            {
                Ateria ateria = (Ateria)ateriat[i];
                kaikkiAteriat.Add(ateria);
            }
            return kaikkiAteriat;
        }
    }
}