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
    /// Interaction logic for OknoSzczegolyZamowienia.xaml
    /// </summary>
    public partial class OknoSzczegolyZamowienia : Window
    {


        DataGrid dataGridZamowienie;
        // DataGrid dataGridProduktow;
        Connection baza = MainWindow.Baza;
        DataSet dataSetZamawianyProdukt;

        public OknoSzczegolyZamowienia()
        {
            InitializeComponent();

            string idZamowienie;
            string idKlient;
            bool loadingFromDBComplete = false;

            //dataSetProdukty = baza.LoadData("SELECT * FROM listwa");
            //dataGridProdukty.IsReadOnly = true;
            //dataGridProdukty.ItemsSource = dataSetProdukty.Tables[0].DefaultView;

            foreach (Window window in Application.Current.Windows) //wyszukuje main window, w celu dostepu do dataGridZamowienie
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    dataGridZamowienie = (window as MainWindow).dataGridZamowienie;
                }
            }


            if (dataGridZamowienie.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGridZamowienie.SelectedItems.Count; i++) //wyszukuje zaznaczonych zamowien w gridzie
                {
                    
                    DataRowView drv = (DataRowView)dataGridZamowienie.SelectedItems[i];
                    idZamowienie = Convert.ToString(drv["idZamowienie"]);

                    DataRowView drv2 = (DataRowView)dataGridZamowienie.SelectedItems[i];
                    idKlient = Convert.ToString(drv2["idKlient"]);

                    if (idZamowienie != null)
                    {
                       // MessageBox.Show(idZamowienie);

                        //ZamawianyProdukt produkt = new ZamawianyProdukt();
                        //string idZamawianyProdukt = baza.FindProduktQuerryBy("idZamowienie", idZamowienie, "idZamawianyProdukt"); //znajduje id zamawianych produktow 
                        //produkt.idZamawianyProdukt = int.Parse(idZamowienie);



                        dataSetZamawianyProdukt = baza.LoadData("SELECT zamawianyprodukt.iloscListwy, zamawianyprodukt.idPaczka, listwa.symbol, listwa.kosztMb, listwa.material FROM `zamawianyprodukt`, `listwa` WHERE zamawianyprodukt.idZamowienie=\"" + idZamowienie + "\"" + "AND  zamawianyprodukt.idListwa = listwa.idListwa ");
                        dataGridZamawianyProdukt.IsReadOnly = true;
                        dataGridZamawianyProdukt.ItemsSource = dataSetZamawianyProdukt.Tables[0].DefaultView;


                        DataSet dataSetDaneZamowienia;

                        dataSetDaneZamowienia = baza.LoadData("SELECT data_zlozenia FROM zamowienie WHERE idZamowienie=\"" + idZamowienie + "\"");
                        string a = dataSetDaneZamowienia.Tables[0].Rows[0]["data_zlozenia"].ToString();
                        labelDaneZamowieniaDataZlozenia2.Content = a;

                        dataSetDaneZamowienia = baza.LoadData("SELECT idKlient FROM zamowienie WHERE idZamowienie=\"" + idZamowienie + "\"");
                        string b = dataSetDaneZamowienia.Tables[0].Rows[0]["idKlient"].ToString();
                        labelDaneZamowieniaIdKlient2.Content = b;

                        dataSetDaneZamowienia = baza.LoadData("SELECT stan FROM zamowienie WHERE idZamowienie=\"" + idZamowienie + "\"");
                        string c = dataSetDaneZamowienia.Tables[0].Rows[0]["stan"].ToString();
                        labelDaneZamowieniaStan2.Content = c;

                        dataSetDaneZamowienia = baza.LoadData("SELECT zaplacono FROM zamowienie WHERE idZamowienie=\"" + idZamowienie + "\"");
                        string d = dataSetDaneZamowienia.Tables[0].Rows[0]["zaplacono"].ToString();
                        labelDaneZamowieniaZaplacono2.Content = d;

                        DataSet dataSetDaneKlienta;

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT imie FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            a = dataSetDaneKlienta.Tables[0].Rows[0]["imie"].ToString();
                            labelDaneKlientaImie2.Content = a;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT nazwisko FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            b = dataSetDaneKlienta.Tables[0].Rows[0]["nazwisko"].ToString();
                            labelDaneKlientaNazwisko2.Content = b;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT telefon FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            c = dataSetDaneKlienta.Tables[0].Rows[0]["telefon"].ToString();
                            labelDaneKlientaTelefon2.Content = c;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT e-mail FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            d = dataSetDaneKlienta.Tables[0].Rows[0]["email"].ToString();
                            labelDaneKlientaEmail2.Content = d;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT firma FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            a = dataSetDaneKlienta.Tables[0].Rows[0]["firma"].ToString();
                            labelDaneKlientaFirma2.Content = a;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT marza FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            b = dataSetDaneKlienta.Tables[0].Rows[0]["marza"].ToString();
                            labelDaneKlientaMarza2.Content = b;
                        }
                        catch { }

                        try
                        {
                            dataSetDaneKlienta = baza.LoadData("SELECT idKlient FROM klient WHERE idKlient=\"" + idKlient + "\"");
                            c = dataSetDaneKlienta.Tables[0].Rows[0]["idKlient"].ToString();
                            labelDaneKlientaIdKlient2.Content = c;
                        }
                        catch { }

                    }


                }
            }
            else
            {
                MessageBox.Show("Nie wybrano zamówień do wyświetlenia !");
            }

            //        dataset = baza.LoadData("SELECT * FROM listwa");
            //        dataGridZamowienie.ItemsSource = dataset.Tables[0].DefaultView;

            //    }
            //        else
            //        {
            //            MessageBox.Show("Nie wybrano rzędu/rzędów do usunięcia !");
            //        }

            //dataset = baza.LoadData("SELECT * FROM listwa");
            //        foreach (Window window in Application.Current.Windows)
            //        {
            //            if (window.GetType() == typeof(MainWindow))
            //            {
            //                (window as MainWindow).dataGridZamowienie.ItemsSource = dataset.Tables[0].DefaultView;
            //            }
            //        }

        }
    }

}
