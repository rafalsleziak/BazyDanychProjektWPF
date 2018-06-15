using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test2
{
    /// <summary>
    /// Interaction logic for OknoZamowienia.xaml
    /// </summary>
    public partial class OknoZamowienia : Window
    {
        Connection baza = new Connection();
        public DataSet dataSetListwaSymbol;
        public DataSet dataSetKlientImie;
        //string listwaSymbol;
        int iloscMB;
        BindingList<Produkt> zamawianyProduktLista;


        public OknoZamowienia()
        {
            zamawianyProduktLista = new BindingList<Produkt>();
            InitializeComponent();
            FillComboBoxListwy();
            listBoxProdukty.Items.Add("Symbol" + "      " + "Zamawiana Ilość [Mb]");

            FillComboBoxKlienci();
        }

        void FillComboBoxListwy()
        {

            dataSetListwaSymbol=baza.LoadData("SELECT idListwa, symbol FROM listwa");

            foreach(DataRow r in dataSetListwaSymbol.Tables[0].Rows)
            {
                comboBoxListwy.Items.Add(r["symbol"].ToString() );
               // Listwa listwa = new Listwa(r["idLista"], r["symbol"].ToString() );
                //listaListw.Add(new Listwa(r["symbol"].ToString() ));
            }

        }


        private void comboBoxListwy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // listwaSymbol = comboBoxListwy.GetValue();
        }

        public void buttonDodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            Listwa listwa = new Listwa();
            bool loadingFromDBComplete = false;

            try
            {
                iloscMB = int.Parse(textBoxIloscMB.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                listwa.symbol = comboBoxListwy.Text;
                loadingFromDBComplete = true;
            }
            catch
            {
                MessageBox.Show("Wystapil Blad, Wypelnij wszytskie rubryki!");
            }

            if (loadingFromDBComplete)
            {
                string b = baza.FindListwaQuerryBy("symbol", listwa.symbol, "idListwa"); //Funckja do zapytania SQL: (SELECT * from listwa Where columnName=Value) zwraca stringa=returnWhat, w tym przypadku znajdujemy idListwy
               // MessageBox.Show(b);
                listwa.id = int.Parse(b);

                Produkt produkt = new Produkt(listwa.id, listwa.symbol, iloscMB);

                zamawianyProduktLista.Add(produkt);
                listBoxProdukty.Items.Add(produkt.FormatujDoStringaListy());
            }
        }


        void FillComboBoxKlienci()
        {

            dataSetKlientImie = baza.LoadData("SELECT idKlient, imie, nazwisko FROM klient");

            foreach (DataRow r in dataSetKlientImie.Tables[0].Rows)
            {
                comboBoxKlienci.Items.Add(r["imie"].ToString() + " " + r["nazwisko"].ToString());
                // Listwa listwa = new Listwa(r["idLista"], r["symbol"].ToString() );
                //listaListw.Add(new Listwa(r["symbol"].ToString() ));
            }

            // string b = baza.FindListwaQuerryBy("symbol", listwa.symbol, "idListwa");
           

        }







        private void buttonPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            Klient klient = new Klient();
            Zamowienie zamowienie = new Zamowienie();
            bool loadingFromDBComplete = false;
            try
            {
                string bufor = comboBoxKlienci.Text;
                klient.imie = bufor.Remove(bufor.IndexOf(' '));
                bufor = comboBoxKlienci.Text;
                klient.nazwisko = bufor.Remove(0,bufor.IndexOf(' ') + 1);
                //MessageBox.Show(klient.imie + klient.nazwisko);
                loadingFromDBComplete = true;
            }
            catch
            {
                MessageBox.Show("Wystapil Blad, Wypelnij wszytskie rubryki!");
            }
            if (loadingFromDBComplete)
            {
                string idKlienta = baza.FindKlientQuerryBy("imie", klient.imie, "nazwisko", klient.nazwisko, "idKlient"); //Funckja do zapytania SQL: (SELECT * from listwa Where columnName=Value) zwraca stringa=returnWhat, w tym przypadku znajdujemy idListwy
             //   MessageBox.Show(idKlienta);
                klient.id = int.Parse(idKlienta);
                //DateTime dateTime = DateTime.Now;
                //DateTime dateTime = DateTime.ParseExact(DateTime.Now.ToString(), "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                DateTime dateTime = DateTime.Now;
               // var dateTimeString = dateTime.ToString(@"yyyy/MM/dd hh:mm:ss tt", new CultureInfo("en-US"));
                //MessageBox.Show(dateTimeString);

                baza.InsertZamowienie(dateTime, klient.id, "W produkcji", true);
                string idZamowienie = baza.FindZamowienieByDate(dateTime, klient.id, "idZamowienie");

                zamowienie.idZamowienie = int.Parse(idZamowienie);

                foreach (Produkt produkt in zamawianyProduktLista)
                {
                    baza.InsertProdukt(zamowienie.idZamowienie,produkt.idListwa, produkt.iloscListwy,0);
                }

                //asdsa
            }
        }
    }
}
