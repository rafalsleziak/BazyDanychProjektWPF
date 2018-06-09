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
using System.Windows.Shapes;

namespace Test2
{
    /// <summary>
    /// Interaction logic for OknoStartowe.xaml
    /// </summary>
    public partial class OknoStartowe : Window
    {
        public OknoStartowe()
        {
            InitializeComponent();
        }

        private void buttonZlozZamowienie_Click(object sender, RoutedEventArgs e)
        {
            OknoZamowienia oknoZamowienia = new OknoZamowienia();
            oknoZamowienia.Show();
        }

        private void buttonPrzegladajBaze_Click(object sender, RoutedEventArgs e)
        {
            MainWindow oknoMain = new MainWindow();
            oknoMain.Show();
        }
    }
}
