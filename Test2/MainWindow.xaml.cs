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

namespace Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TabelaListwa.IsReadOnly = true;
            //TabelaListwa.DataSource = dataset.Tables[0].DefaultView;
            //TabelaListwa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //TabelaListwa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void TabelaListwa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonDodajListwe_Click(object sender, RoutedEventArgs e)
        {
            OknoDodawania okno = new OknoDodawania();
            okno.Show();
        }

        private void buttonZlozZamowienie_Click(object sender, RoutedEventArgs e)
        {
            OknoZamowienia oknoZamowienia = new OknoZamowienia();
            oknoZamowienia.Show();
        }
    }
}
