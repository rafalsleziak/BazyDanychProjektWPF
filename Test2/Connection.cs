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
        public static string MyConnectionString = "Server=localhost;Database=baza;port=3306;Uid=root;Pwd=password;SslMode=none"; //"Server=localhost;Database=baza;port=3306;Uid=root;Pwd=password;SslMode=none";

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

        public string LoadDataToString()
        {
           
            return "nic";
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

        public string FindListwaBySymbol(string symbol)
        {
            DataSet listwa;

            listwa = LoadData("SELECT *  from listwa WHERE symbol=\"" + symbol + "\"");
            string a = listwa.Tables[0].Rows[0]["idListwa"].ToString();

            return a;          
        }

        public string FindListwaQuerryBy(string columnName, string value, string returnWhat)
        {
            DataSet listwa;

            listwa = LoadData("SELECT *  from listwa WHERE " + columnName + "=\"" + value + "\"");
            string a = listwa.Tables[0].Rows[0][returnWhat].ToString();

            return a;
        }



        //////// KLIENT //////////////////////////////////////////////////

        public string FindKlientQuerryBy(string columnName, string valueName, string column2Name, string value2Name, string returnWhat)
        {
            DataSet klient;

            klient = LoadData("SELECT *  from klient WHERE " + columnName + "=\"" + valueName + "\"" + "AND " + column2Name + "=\"" + value2Name + "\"");
            string a = klient.Tables[0].Rows[0][returnWhat].ToString();

            return a;
        }





        ////////Produkt

        public void InsertProdukt(int idZamowienie, int idListwa,int iloscListwy,int idPaczka)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO zamawianyprodukt(idZamowienie,idListwa,iloscListwy,idPaczka)VALUES(@idZamowienie,@idListwa,@iloscListwy,@idPaczka)";
                cmd.Parameters.AddWithValue("@idZamowienie", idZamowienie);
                cmd.Parameters.AddWithValue("@idListwa", idListwa);
                cmd.Parameters.AddWithValue("@iloscListwy", iloscListwy);
                cmd.Parameters.AddWithValue("@idPaczka", idPaczka);
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

        public string FindProduktQuerryBy(string columnName, string value, string returnWhat)
        {
            DataSet zamawianyProdukt;

            zamawianyProdukt = LoadData("SELECT *  from zamawianyprodukt WHERE " + columnName + "=\"" + value + "\"");
            string a = zamawianyProdukt.Tables[0].Rows[0][returnWhat].ToString();

            return a;
        }

        ///////////////////////// ZAMOWIENIE ////////////////////

        public void InsertZamowienie(DateTime data_zlozenia, int idKlient, string stan, bool zaplacono)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO zamowienie(data_zlozenia, idKlient, stan, zaplacono)VALUES(@data_zlozenia,@idKlient,@stan,@zaplacono)";
                cmd.Parameters.AddWithValue("@data_zlozenia", data_zlozenia);
                cmd.Parameters.AddWithValue("@idKlient", idKlient);
                cmd.Parameters.AddWithValue("@stan", stan);
                cmd.Parameters.AddWithValue("@zaplacono", zaplacono);
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


        public string FindZamowienieByDate(DateTime dateTime, int idKlient, string returnWhat)
        {
            DataSet zamowienie;

            zamowienie = LoadData("SELECT *  from zamowienie WHERE data_zlozenia"  + "=\"" + dateTime.ToString() + "\"" + "AND " + "idKlient=\"" + idKlient + "\"");
            string a = zamowienie.Tables[0].Rows[0][returnWhat].ToString();

            return a;

        }

        public string FindZamowienieQuerryBy(string columnName, string valueName, string returnWhat)
        {
            DataSet zamowienie;

            zamowienie = LoadData("SELECT *  from zamowienie WHERE " + columnName + "=\"" + valueName + "\"");
            string a = zamowienie.Tables[0].Rows[0][returnWhat].ToString();

            return a;
        }



        public string FindZamowienieQuerryBy(string columnName, string valueName, string column2Name, string value2Name, string returnWhat)
        {
            DataSet zamowienie;

            zamowienie = LoadData("SELECT *  from zamowienie WHERE " + columnName + "=\"" + valueName + "\"" + "AND " + column2Name + "=\"" + value2Name + "\"");
            string a = zamowienie.Tables[0].Rows[0][returnWhat].ToString();

            return a;
        }





    }
}

