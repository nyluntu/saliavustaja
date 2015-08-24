using System;

namespace Saliavustaja
{
    public class Asiakas
    {
        protected bool etukuponki = false;
        const double ETUKERROIN = 0.85;

        public virtual double LaskeHinta(double tilauksenhinta)
        {
            if (etukuponki)
                return tilauksenhinta * ETUKERROIN;

            return tilauksenhinta;
        }
    }
}