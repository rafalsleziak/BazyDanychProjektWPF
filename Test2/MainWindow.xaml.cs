using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
/// <summary>
/// ///////////////////////////////TO TEEEEEEEEEENNNNNNNNNNNNN NAJNOWSZY !!!!!!!!!!!//////////////////////
/// </summary>

namespace Test2
{

    public partial class MainWindow : Window
    {
        private static Connection baza = new Connection();

        //Listwa
        string idListwyDoUsuniecia;
        DataSet dataSetListwa;

        //Paczka
        DataSet dataSetPaczka;

        //Zamowienia
        DataSet dataSetZamowienie;

        //Zapytanie raportowe
        DataSet dataSetRaport;
        string data, data2;


        internal static Connection Baza
        { //{ get => baza; set => baza = value; }
            get { return baza; }
            set { baza = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
           
            //Wczytaj dane do Tabeli Listwy
            dataSetListwa = baza.LoadData("SELECT * FROM listwa");
            dataGridListwa.IsReadOnly = true;
            dataGridListwa.ItemsSource = dataSetListwa.Tables[0].DefaultView;

            //Wczytaj dane do tabeli Paczek
            dataSetPaczka = baza.LoadData("SELECT * FROM paczka");
            dataGridPaczka.IsReadOnly = true;
            dataGridPaczka.ItemsSource = dataSetPaczka.Tables[0].DefaultView;

            //Wczytaj dane do tabeli Zamówien
            dataSetZamowienie = baza.LoadData("SELECT * FROM zamowienie");
            dataGridZamowienie.IsReadOnly = true;
            dataGridZamowienie.ItemsSource = dataSetZamowienie.Tables[0].DefaultView;

            comboBox1.Items.Add("Klienci - liczba zamowien");
            comboBox1.Items.Add("Listwy - liczba zamowien");
            comboBox1.Items.Add("Klienci - ilosc zakupionych metrow");
            comboBox1.Items.Add("Listwy - ilosc zakupionych metrow");
        }

        private void TabelaListwa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    
        ///LISTWA

        private void ButtonDodajListwe_Click(object sender, RoutedEventArgs e)
        {
            OknoDodawania okno = new OknoDodawania();
            okno.Show();



        }

        private void ButtonUsunListwe_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridListwa.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGridListwa.SelectedItems.Count; i++)
                {
                    //object item = dataGridListwa.SelectedItems[i];
                    DataRowView drv = (DataRowView)dataGridListwa.SelectedItems[i];
                    idListwyDoUsuniecia = Convert.ToString(drv["idListwa"]);

                    if (idListwyDoUsuniecia != null)
                    {
                        // MessageBox.Show(idListwyDoUsuniecia);
                        baza.RemoveListwa(idListwyDoUsuniecia);
                    }
                }

                dataSetListwa = baza.LoadData("SELECT * FROM listwa");
                dataGridListwa.ItemsSource = dataSetListwa.Tables[0].DefaultView;

            }
            else
            {
                MessageBox.Show("Nie wybrano rzędu/rzędów do usunięcia !");
            }


        }

        private void ButtonEdytujListwe_Click(object sender, RoutedEventArgs e)
        {
            OknoEdycjiListwy oknoEdycjiListwy = new OknoEdycjiListwy();
            oknoEdycjiListwy.Show();
        }

        ///Paczka
        
       

       //Zamowienie

        private void buttonZlozZamowienie_Click(object sender, RoutedEventArgs e)
        {
            OknoZamowienia oknoZamowienia = new OknoZamowienia();
            oknoZamowienia.Show();
        }

        private void buttonSzczegolyZamowienia_Click(object sender, RoutedEventArgs e)
        {
            OknoSzczegolyZamowienia oknoSzczegolyZamowienia = new OknoSzczegolyZamowienia();
            oknoSzczegolyZamowienia.Show();
        }

        //////// Raport


        private void buttonWykonaj_Click(object sender, RoutedEventArgs e)
        {
            //Wczytaj dane do Tabeli Listwy
            //dataSetRaport = baza.LoadData("SELECT idKlient, COUNT(*) FROM zamowienie WHERE data_zlozenia BETWEEN '2013-01-01%' AND '2019-01-03%' GROUP BY data_zlozenia");
            // dataSetRaport = baza.LoadData("SELECT zamawianyprodukt.idListwa, COUNT(*) FROM zamawianyprodukt, zamowienie,  WHERE zamowienie.idZamowienie=zamawianyprodukt.idZamowienie AND zamowienie.data_zlozenia BETWEEN '2013-01-01%' AND '2019-01-03%' GROUP BY zamowienie.data_zlozenia");
            //
            //zapytanie agregujace z zapytaniem zlozonym z trzech tabel

            try
            {
                data = datePicker.Text;
                data2 = datePicker2.Text;

                if (string.IsNullOrEmpty(data) == true || string.IsNullOrEmpty(data2) == true)
                    MessageBox.Show("Nie wybrano zakresu czasowego! ");
                else
                {
                    if (comboBox1.Text == "Listwy - liczba zamowien")
                    {

                        dataSetRaport = baza.LoadData("SELECT listwa.symbol, zamawianyprodukt.idListwa, COUNT(*) " +
                        "FROM zamawianyprodukt, listwa, zamowienie " +
                        "WHERE listwa.idListwa = zamawianyprodukt.idListwa AND zamowienie.idZamowienie = zamawianyprodukt.idZamowienie AND zamowienie.data_zlozenia " +
                        "BETWEEN '" + data + "%' AND '" + data2 + "%' " +
                        "GROUP BY idListwa");

                        dataGridRaport.IsReadOnly = true;
                        dataGridRaport.ItemsSource = dataSetRaport.Tables[0].DefaultView;

                        //comboBox2.Items.Add("Suma");
                        //comboBox2.Items.Add("Srednia");
                        //comboBox2.Items.Add("Zlicz");
                        //comboBox2.Items.Add("MIN");
                        //comboBox2.Items.Add("MAX");
                    }
                    else if (comboBox1.Text == "Klienci - liczba zamowien")
                    {
                        //dataSetRaport = baza.LoadData("SELECT listwa.symbol, zamawianyprodukt.idListwa, COUNT(*) " +
                        //    "FROM zamawianyprodukt, zamowienie, listwa " +
                        //    "WHERE zamowienie.idZamowienie=zamawianyprodukt.idZamowienie AND listwa.idListwa = zamawianyprodukt.idListwa AND zamowienie.data_zlozenia " +
                        //    "BETWEEN '2013-01-01%' AND '2019-01-03%' GROUP BY zamowienie.data_zlozenia");

                        dataSetRaport = baza.LoadData("SELECT klient.imie, klient.nazwisko, zamowienie.idKlient, COUNT(*) " +
                            "FROM zamowienie, klient " +
                            "WHERE zamowienie.IdKlient = klient.IdKlient AND zamowienie.data_zlozenia BETWEEN '" + data + "%' AND '" + data2 + "%' " +
                            "GROUP BY zamowienie.IdKlient");// GROUP BY zamowienie.data_zlozenia");
                                                            // dataSetRaport = baza.LoadData("SELECT idKlient, COUNT(*) FROM `zamowienie` WHERE data_zlozenia BETWEEN '2013-01-01%' AND '2019-01-03%' GROUP BY idKlient");

                        dataGridRaport.IsReadOnly = true;
                        dataGridRaport.ItemsSource = dataSetRaport.Tables[0].DefaultView;

                    }
                    else if (comboBox1.Text == "Klienci - ilosc zakupionych metrow")
                    {
                        dataSetRaport = baza.LoadData("SELECT zamowienie.idKlient, klient.imie, klient.nazwisko, SUM(zamawianyprodukt.iloscListwy) " +
                           "FROM zamawianyprodukt, zamowienie, klient " +
                           "WHERE zamawianyprodukt.idZamowienie = zamowienie.idZamowienie AND zamowienie.idKlient = klient.idKlient AND zamowienie.data_zlozenia BETWEEN '" + data + "%' AND '" + data2 + "%' " +
                           "GROUP BY zamowienie.IdKlient");// GROUP BY zamowienie.data_zlozenia");
                                                           // dataSetRaport = baza.LoadData("SELECT idKlient, COUNT(*) FROM `zamowienie` WHERE data_zlozenia BETWEEN '2013-01-01%' AND '2019-01-03%' GROUP BY idKlient");

                        dataGridRaport.IsReadOnly = true;
                        dataGridRaport.ItemsSource = dataSetRaport.Tables[0].DefaultView;



                    }
                    else if (comboBox1.Text == "Listwy - ilosc zakupionych metrow")
                    {
                        dataSetRaport = baza.LoadData("SELECT listwa.idListwa, listwa.symbol, SUM(zamawianyprodukt.iloscListwy) " +
                          "FROM zamawianyprodukt, listwa, zamowienie " +
                          "WHERE zamawianyprodukt.idZamowienie = zamowienie.idZamowienie AND zamawianyprodukt.idListwa = listwa.idListwa AND zamowienie.data_zlozenia BETWEEN '" + data + "%' AND '" + data2 + "%' " +
                          "GROUP BY listwa.idListwa");
                        dataGridRaport.IsReadOnly = true;
                        dataGridRaport.ItemsSource = dataSetRaport.Tables[0].DefaultView;


                    }
                    else
                    {
                        MessageBox.Show("Nie uzupelniono wszystkich wymaganych pól !");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wprowadzano nieprawidlowe dane!");
            }


        }
    }
}




