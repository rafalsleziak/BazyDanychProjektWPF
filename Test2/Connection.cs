using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Test2
{
    class Connection
    {
        public static string MyConnectionString = "Server=localhost;Database=baza;port=3306;Uid=root;Pwd=password;SslMode=none";

        public DataSet LoadData(string query)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public void InsertListwa(string symbol, string material, string kolor, bool ornament, string okleina, float kosztMb)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO listwa(symbol,material,kolor,ornament,okleina,kosztMb)VALUES(@symbol,@material,@kolor,@ornament,@okleina,@kosztMb)";
                cmd.Parameters.AddWithValue("@symbol", symbol);
                cmd.Parameters.AddWithValue("@material", material);
                cmd.Parameters.AddWithValue("@kolor", kolor);
                cmd.Parameters.AddWithValue("@ornament", ornament);
                cmd.Parameters.AddWithValue("@okleina", okleina);
                cmd.Parameters.AddWithValue("@kosztMb", kosztMb);
                //cmd.Parameters.AddWithValue("@ornament");
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close(); // bylo Clone(); ale to raczej blad
                }

            }
        }

        public void RemoveListwa(string idNumber)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE from listwa WHERE idListwa=@id";
                cmd.Parameters.AddWithValue("@id", idNumber);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close(); // bylo Clone(); ale to raczej blad
                }

            }
        }



        public void UpdateListwa(string symbol, string material, string kolor, bool ornament, string okleina, float kosztMb, string idListwa)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE listwa SET symbol=@symbol,material=@material,kolor=@kolor,ornament=@ornament,okleina=@okleina,kosztMb=@kosztMb WHERE idListwa=@idListwa ";
                cmd.Parameters.AddWithValue("@symbol", symbol);
                cmd.Parameters.AddWithValue("@material", material);
                cmd.Parameters.AddWithValue("@kolor", kolor);
                cmd.Parameters.AddWithValue("@ornament", ornament);
                cmd.Parameters.AddWithValue("@okleina", okleina);
                cmd.Parameters.AddWithValue("@kosztMb", kosztMb);
                cmd.Parameters.AddWithValue("@idListwa", idListwa);
                //cmd.Parameters.AddWithValue("@ornament");
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close(); // bylo Clone(); ale to raczej blad
                }

            }
        }















        //try
        //   {

        //       if (listOfParts.Any())
        //       {
        //           listOfParts.RemoveAt(listBox.SelectedIndex);
        //           listBox.Items.RemoveAt(listBox.SelectedIndex);
        //       }
        //       else
        //       {
        //           MessageBox.Show("Brak Tasków!");
        //       }
        //   }
        //   catch
        //   {
        //       MessageBox.Show("Nie wybrano tasku do usunięcia");
        //   }





    }
}

