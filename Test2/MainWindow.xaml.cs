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
    }
}




