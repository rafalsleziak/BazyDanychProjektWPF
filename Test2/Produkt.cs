﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Produkt
    {
        public int idListwa;
        public string symbol;
        public int iloscListwy;

        public Produkt() { }
       public  Produkt(int idListwa,string symbol, int iloscListwy)
        {
            this.idListwa = idListwa;
            this.symbol = symbol;
            this.iloscListwy = iloscListwy;
        }

        public string FormatujDoStringaListy()
        {
            string wynik = symbol + "   " + iloscListwy;

            return  wynik;
        }



    }
}
