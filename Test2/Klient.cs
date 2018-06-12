using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Klient
    {
        public int id;
        public string imie;
        public string nazwisko;

        public Klient(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public Klient()
        { }

    }
}
