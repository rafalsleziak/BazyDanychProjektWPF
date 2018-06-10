using System;
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
        public int iloscMb;

        public Produkt() { }
       public  Produkt(int idListwa,string symbol, int iloscMb)
        {
            this.idListwa = idListwa;
            this.symbol = symbol;
            this.iloscMb = iloscMb;
        }

        public string FormatujDoStringaListy()
        {
            string wynik = symbol + "   " + iloscMb;

            return  wynik;
        }



    }
}
