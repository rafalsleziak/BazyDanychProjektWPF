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
    /// Interaction logic for OknoDodawania.xaml
    /// </summary>
    public partial class OknoDodawania : Window
    {

        string symbol, material, kolor, okleina;
        float kosztMb;
        bool ornament;
        Connection baza = MainWindow.Baza;
        DataSet dataset;

        public OknoDodawania()
        {
            InitializeComponent();

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            kolor = textBoxListwaKolor.Text;
            symbol = textBoxListwaSymbol.Text;
            material = textBoxListwaMaterial.Text;
            okleina = textBoxListwaOkleina.Text;
            kosztMb = float.Parse(textBoxListwaKosztMB.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            ornament = (checkBoxOrnament.IsChecked == true);
            baza.InsertListwa(symbol, material, kolor, ornament, okleina, kosztMb);
            dataset = baza.LoadData("SELECT * FROM listwa");
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).dataGridListwa.ItemsSource = dataset.Tables[0].DefaultView;
                }
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
