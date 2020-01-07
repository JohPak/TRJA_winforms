using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WinFormsHarkka
{
    public class ReadDB
    {
       
        

        //constructor
        public ReadDB()
        {
           
        }

        public static string yhteys()
        {
            return "Host=maja.dy.fi;Username=jossu;Password=JohannaPakkala;Database=jossu";
            //return "Host=localhost;Username=jossu;Password=salsa;Database=jossu";
        }

        // haku tietokannasta, parametreina taulun nimi ja sarake     
        public static List<string> Reader(string sarake, string taulu)
        {
            List<string> tulokset = new List<string>();

            try
            {
                // tietokannan luku Meijan esimerkin perusteella
                var connString = yhteys();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); //open connection
                    using (var cmd = new NpgsqlCommand($"SELECT {sarake} FROM {taulu} order by id", conn))
                    {
                        cmd.ExecuteNonQuery();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // tarkistetaan mitä tyyppiä tietokannasta tulee, ja muutetaan ne stringeiksi (jotta saadaan listaan ja palautettua se pääohjelmaan)
                                if (reader.GetDataTypeName(0) == "float8")
                                {
                                    tulokset.Add(reader.GetDouble(0).ToString());
                                }
                                //Console.WriteLine(reader.GetDataTypeName(0));
                                else if (reader.GetDataTypeName(0) == "int4")
                                {
                                    tulokset.Add(reader.GetInt32(0).ToString());
                                }
                                else
                                {
                                    tulokset.Add(reader.GetString(0));
                                }
                            }
                            return tulokset;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tulokset.Add(ex.Message);
                return tulokset;
            }
        }

        // haku tietokannasta, parametreina taulun nimi, sarake ja where-ehto
        public static List<string> Reader(string sarake, string taulu, string where)
        {
            List<string> tulokset = new List<string>();

            try
            {
                // tietokannan luku Meijan esimerkin perusteella
                var connString = yhteys();

                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); //open connection
                    using (var cmd = new NpgsqlCommand($"SELECT {sarake} FROM {taulu} WHERE {where} order by id", conn))
                    {
                        cmd.ExecuteNonQuery();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // tarkistetaan mitä tyyppiä tietokannasta tulee, ja muutetaan ne stringeiksi (jotta saadaan listaan ja palautettua se pääohjelmaan)
                                if (reader.GetDataTypeName(0) == "float8")
                                {
                                    tulokset.Add(reader.GetDouble(0).ToString());
                                }
                                //Console.WriteLine(reader.GetDataTypeName(0));
                                else if (reader.GetDataTypeName(0) == "int4")
                                {
                                    tulokset.Add(reader.GetInt32(0).ToString());
                                }
                                else
                                {
                                    tulokset.Add(reader.GetString(0));
                                }
                            }
                            return tulokset;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tulokset.Add(ex.Message);
                return tulokset;
            }
        }
    }
}
