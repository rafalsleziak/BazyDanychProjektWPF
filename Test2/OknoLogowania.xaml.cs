using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for OknoLogowania.xaml
    /// </summary>
    public partial class OknoLogowania : Window
    {
        //Wlasciwosci  
        public static string MyConnectionString = "Server=localhost;Database=baza;port=3306;Uid=root;Pwd=password;SslMode=none";
        MySqlConnection polaczenie = new MySqlConnection(MyConnectionString);
        MySqlCommand komenda;
        public string zapytanieSQL;

        public OknoLogowania()
        {
            InitializeComponent();
            PodmienHasloUzytkownika("admin", "admin", "admin");// Przy pomocy tej funkcji mozemy podmienic haslo recznie
           // Connection baza = new Connection();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if( string.IsNullOrWhiteSpace(textBoxHaslo.Password) || string.IsNullOrWhiteSpace(textBoxLogin.Text) )
            {
                
                MessageBox.Show("Musisz podac Login i Haslo");
            }

            else
            {
                if( SprawdzDaneLogowania(textBoxLogin.Text, textBoxHaslo.Password) ==true )
                {
                    OknoStartowe oknoStartowe = new OknoStartowe();
                    oknoStartowe.Show();
                    Close();
                }
               

                //PodmienHasloUzytkownika("admin", "admin!", "admin"); Przy pomocy tej funkcji mozemy podmienic haslo recznie
            }

        }


        public bool SprawdzDaneLogowania(string login, string haslo)
        {
            try
            {
                if (polaczenie.State == ConnectionState.Closed)
                    polaczenie.Open();
                zapytanieSQL = "SELECT count(idPracownik) FROM  pracownik WHERE nazwisko = \"" + login + "\""; //Szuakmy pracownika o danym loginie
                komenda = new MySqlCommand(zapytanieSQL, polaczenie);
                int wartosc = Convert.ToInt32(komenda.ExecuteScalar());


                if (wartosc == 1) //Jesli znalezlismy rekord z takim loginem(tutaj nazwiskiem)
                {
                    //MessageBox.Show("Jest takie naziwsko w DB");
                    zapytanieSQL = "SELECT haslo FROM pracownik WHERE nazwisko = \"" + login + "\""; //Szuakmy pracownika o danym loginie
                    komenda.CommandText = zapytanieSQL;
                    string hasloZBazy = komenda.ExecuteScalar().ToString();

                    MD5 hashMD5 = MD5.Create();

                    haslo = GetMd5Hash(hashMD5, haslo);

                   // MessageBox.Show("haslo z bazy: " + hasloZBazy);
                    //MessageBox.Show("haslo wproadzone: " + haslo);

                    if (hasloZBazy==haslo)
                    {
                        MessageBox.Show("Logowanie Udane!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Bledne wprowadzone haslo!");
                        return false;
                    }                 

                }
                else
                {
                    MessageBox.Show("Nie ma takiego uzytkownika W DB! Bledne nazwisko/Login");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Wystapil blad przy poalczeniu z DB!");
            }
            return false;
        }

        public void PodmienHasloUzytkownika(string login, string haslo, string nazwisko)
        {
            try
            {
                if (polaczenie.State == ConnectionState.Closed)
                    polaczenie.Open();

                using (MD5 hash = MD5.Create()) //Haszujemy Haslo
                {
                    haslo = GetMd5Hash(hash, haslo);
                }
                 
                zapytanieSQL = "UPDATE pracownik SET haslo = \"" + haslo + "\" WHERE nazwisko=\"" + nazwisko + "\""; //Wpisujemy haslo do rekordu(juz isntiejacego!)
                //"UPDATE pracownik SET haslo = ziemniak WHERE nazwisko = admin
                komenda = new MySqlCommand(zapytanieSQL, polaczenie);
                komenda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Blad, cos poszło nie tak!");
            }

        }

        ////////////////////////MD5


        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Konwertujemy nasze hasło to tablicy bajtow
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Tworzymmy StringBuildera
            StringBuilder sBuilder = new StringBuilder();
           
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string(zwracamy Stringa w systemie 16).
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)//input=haslo, hash=pobiermay z bazy, porownuje nam nasz input i zhasowane haslo
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
