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
        public DataSet listwaSymbol;

        public OknoZamowienia()
        {
            InitializeComponent();
            FillComboBoxListwy();
        }

        void FillComboBoxListwy()
        { 
             
            listwaSymbol=baza.LoadData("SELECT symbol FROM listwa");

            foreach(DataRow r in listwaSymbol.Tables[0].Rows)
            {
                comboBoxListwy.Items.Add(r["symbol"].ToString());
            }

        }


        private void comboBoxListwy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
