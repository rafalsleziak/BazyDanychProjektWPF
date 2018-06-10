using System;
using System.Collections.Generic;
using System.Data;
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
        //string listwaSymbol;
        float iloscMB;
        List<Listwa> listaListw;

        public OknoZamowienia()
        {
            InitializeComponent();
            FillComboBoxListwy();
           
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

            try
            {
                iloscMB = float.Parse(textBoxIloscMB.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                listwa.symbol = comboBoxListwy.Text;
            }
            catch
            {
                MessageBox.Show("Wystapil Blad, Wypelnij wszytskie rubryki!");
            }
            string b = baza.FindListwaQuerryBy("symbol", listwa.symbol, "idListwa"); //Funckja do zapytania SQL: (SELECT * from listwa Where columnName=Value) zwraca stringa=returnWhat 
            //string a= baza.FindListwaBySymbol(listwa.symbol);
            MessageBox.Show(b);
            //DataSet dataListwa;
            //dataListwa=baza.FindListwaBySymbol(listwa.symbol);
            //dataListwa.Tables[0].Rows[0]



        }
    }
}
