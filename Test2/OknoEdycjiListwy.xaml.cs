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
    /// Interaction logic for OknoEdycjiListwy.xaml
    /// </summary>
    public partial class OknoEdycjiListwy : Window
    {
        

        public OknoEdycjiListwy()
        {
            InitializeComponent();


        }

        DataGrid dataGridListwa;
        string symbol, material, kolor, okleina, idListwa;
        float kosztMb;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        bool ornament;
        Connection baza = MainWindow.Baza;
        DataSet dataset;


        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    dataGridListwa = (window as MainWindow).dataGridListwa;
                }
            }


            ///////////////////////////////////////////////////////////////



            if (dataGridListwa.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGridListwa.SelectedItems.Count; i++)
                {
                    //object item = dataGridListwa.SelectedItems[i];
                    DataRowView drv = (DataRowView)dataGridListwa.SelectedItems[i];
                    idListwa = Convert.ToString(drv["idListwa"]);

                    if (idListwa != null)
                    {
                        // MessageBox.Show(idListwyDoUsuniecia);
                       // baza.RemoveListwa(idListwyDoUsuniecia);
                        ////////////////////////////////////////////////////

                        if (textBoxListwaKolor.Text != "")
                            kolor = textBoxListwaKolor.Text;
                        else
                        {
                            for (int j = 0; j < dataGridListwa.Columns.Count; j++)
                            {
                                //object item = dataGridListwa.SelectedItems[i];
                                DataRowView drv2 = (DataRowView)dataGridListwa.SelectedItems[i];
                                kolor = Convert.ToString(drv["kolor"]);
                            }
                        }

                        if (textBoxListwaSymbol.Text != "")
                            symbol = textBoxListwaSymbol.Text;
                        else
                        {
                            for (int j = 0; j < dataGridListwa.Columns.Count; j++)
                            {
                                //object item = dataGridListwa.SelectedItems[i];
                                DataRowView drv2 = (DataRowView)dataGridListwa.SelectedItems[i];
                                symbol = Convert.ToString(drv["symbol"]);
                            }
                        }

                        if (textBoxListwaMaterial.Text != "")
                            material = textBoxListwaMaterial.Text;
                        else
                        {
                            for (int j = 0; j < dataGridListwa.Columns.Count; j++)
                            {
                                //object item = dataGridListwa.SelectedItems[i];
                                DataRowView drv2 = (DataRowView)dataGridListwa.SelectedItems[i];
                                material = Convert.ToString(drv["material"]);
                            }
                        }

                        if (textBoxListwaOkleina.Text != "")
                            okleina = textBoxListwaOkleina.Text;
                        else
                        {
                            for (int j = 0; j < dataGridListwa.Columns.Count; j++)
                            {
                                //object item = dataGridListwa.SelectedItems[i];
                                DataRowView drv2 = (DataRowView)dataGridListwa.SelectedItems[i];
                                okleina = Convert.ToString(drv["okleina"]);
                            }
                        }

                        if (textBoxListwaKosztMB.Text != "")
                           kosztMb = float.Parse(textBoxListwaKosztMB.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        else
                        {

                            for (int j = 0; j < dataGridListwa.Columns.Count; j++)
                            {
                                //object item = dataGridListwa.SelectedItems[i];
                                DataRowView drv2 = (DataRowView)dataGridListwa.SelectedItems[i];
                                string bufor = Convert.ToString(drv["kosztMb"]);
                                kosztMb = float.Parse(bufor, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                            }
                        }
                        //symbol = textBoxListwaSymbol.Text;
                        //material = textBoxListwaMaterial.Text;
                        //okleina = textBoxListwaOkleina.Text;
                        //kosztMb = float.Parse(textBoxListwaKosztMB.Text, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        ornament = (checkBoxOrnament.IsChecked == true);
                        baza.UpdateListwa(symbol, material, kolor, ornament, okleina, kosztMb, idListwa);





                        ///////////////////////////////////////////////////////
                    }
                }

                dataset = baza.LoadData("SELECT * FROM listwa");
                dataGridListwa.ItemsSource = dataset.Tables[0].DefaultView;

            }
            else
            {
                MessageBox.Show("Nie wybrano rzędu/rzędów do usunięcia !");
            }





            ////////////////////////////////////////////////////////////////








           
            dataset = baza.LoadData("SELECT * FROM listwa");
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).dataGridListwa.ItemsSource = dataset.Tables[0].DefaultView;
                }
            }

        }


    }
}
