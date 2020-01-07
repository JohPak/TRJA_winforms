using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace WinFormsHarkka
{

    class WriteDB
    {


        //metodit
        public static void DeleteItem(int poistettava)
        {            
            try
            {
                // tietokannan luku Meijan esimerkin perusteella
                var connString = ReadDB.yhteys();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); // Here we open connection
                                 // Here we define our SQL query
                    using (var cmd = new NpgsqlCommand("DELETE FROM komponentti where id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("id", poistettava);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void AddItem(string nimiInput, int kplInput, double hintaInput)
        {
            try
            {
                var connString = ReadDB.yhteys();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); 
                    using (var cmd = new NpgsqlCommand("INSERT INTO komponentti (nimi, kpl, hinta) VALUES (@nimi, @kpl, @hinta)", conn))
                    {
                        cmd.Parameters.AddWithValue("nimi", nimiInput);
                        cmd.Parameters.AddWithValue("kpl", kplInput);
                        cmd.Parameters.AddWithValue("hinta", hintaInput);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public static void UpdateItem(string nimiInput, int kplInput, double hintaInput, int idInput)
        {
            string hinta = hintaInput.ToString();
            if (hintaInput.ToString().Contains(","))
            {
                hinta = hintaInput.ToString().Replace(",", ".");
            }


            try
            {
                var connString = ReadDB.yhteys();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand($"UPDATE komponentti SET nimi = '{nimiInput}', kpl = '{kplInput}', hinta = '{hinta}' WHERE id = '{idInput}'", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }

        }
















    }
}
