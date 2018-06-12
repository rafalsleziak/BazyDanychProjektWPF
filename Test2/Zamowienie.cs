using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Zamowienie
    {
        public int idZamowienie;
        public DateTime data_zlozenia;
        public int idKlient;
        string stan;
        bool zaplacono;

        public Zamowienie(int idZamowienie, DateTime data_zlozenia, int idKlient, string stan, bool zaplacono)
        {
            this.idZamowienie = idZamowienie;
            this.data_zlozenia = data_zlozenia;
            this.idKlient = idKlient;
            this.stan = stan;
            this.zaplacono = zaplacono;
        }
        public Zamowienie()
        { }

    }
}
