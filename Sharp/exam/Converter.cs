using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    class Converter
    {
        double usd;
        double eur;
        double rub;

        public Converter(double usd, double eur, double rub)
        {
            this.usd = usd;
            this.eur = eur;
            this.rub = rub;
        }
        public double UsdUah()
        {
            return usd * 26.9;
        }
        public double EurUah()
        {
            return usd * 29.1;
        }

        public double RubUah()
        {
            return usd * 3.64;
        }
    }
}
