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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string idListwyDoUsuniecia;
        private static Connection baza = new Connection();
        DataSet dataset;

        internal static Connection Baza { get => baza; set => baza = value; }

        public MainWindow()
        {
            //Closing += OknoDodawania.OnWindowClosing;


            InitializeComponent();
            //dataGridListwa.IsReadOnly = true;
            //TabelaListwa.DataSource = dataset.Tables[0].DefaultView;
            //TabelaListwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //TabelaListwa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataset = baza.LoadData("SELECT * FROM listwa");
            dataGridListwa.IsReadOnly = true;
            dataGridListwa.ItemsSource = dataset.Tables[0].DefaultView;
            //dataGridListwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridListwa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void TabelaListwa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonDodajListwe_Click(object sender, RoutedEventArgs e)
        {
            OknoDodawania okno = new OknoDodawania();
            okno.Show();



        }

        //private int GetColumnIndexByName(DataGrid grid, string name)
        //{
        //    for(int i = 0; i < grid.Columns.Count; i++)
        //    {
        //        if (grid.Columns[i].HeaderText.ToLower().Trim() == name.ToLower().Trim())
        //        {
        //            return grid.Columns.IndexOf(col);
        //        }
        //    }

        //    return -1;
        //}


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

                dataset = baza.LoadData("SELECT * FROM listwa");
                dataGridListwa.ItemsSource = dataset.Tables[0].DefaultView;

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


        private void buttonZlozZamowienie_Click(object sender, RoutedEventArgs e)
        {
            OknoZamowienia oknoZamowienia = new OknoZamowienia();
            oknoZamowienia.Show();
        }

        private void ButtonEdytujListwe_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}




