using System;

namespace Saliavustaja.Entiteetit
{
    [Serializable]
    public class Asiakas
    {
        protected bool etukuponki = false;
        const double ETUKERROIN = 0.85;

        public double LaskeHinta(double tilauksenhinta)
        {
            if (etukuponki)
                return tilauksenhinta * ETUKERROIN;

            return tilauksenhinta;
        }
    }
}