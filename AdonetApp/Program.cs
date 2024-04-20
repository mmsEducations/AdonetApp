using System;
using System.Data.SqlClient;

namespace AdonetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetStudents();

        }

        private static void GetStudents()
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=Education;Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from Students", connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Database bağlanmaya çalışır");
                while (reader.Read())//Tek tek kayıtlar okunur ve kayıt olduğu müdddetçe while döngüsüne girer 
                {
                    Console.WriteLine($"Öğrenci Adı:{reader["Name"]} {reader[2]}");
                }

                Console.WriteLine("Database bağlantısı koptu");
            }
        }
        private static void GetStudentsOld()
        {
            //Data Source->sunucu,Initial Catalog->database
            const string connectionString = "Data Source=.;Initial Catalog=Education;Integrated Security=true";

            const string queryStringCommand = "SELECT * from Students";

            //Database Bağlantısı için kullanılır 
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();//Bağlantıyı aç

            //Sql sorgusu çalıştırmak için kullanılır
            SqlCommand command = new SqlCommand(queryStringCommand, connection);

            //Dataları tek tek okumak için kullanılır 
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Database bağlanmaya çalışır");
            while (reader.Read())//Tek tek kayıtlar okunur ve kayıt olduğu müdddetçe while döngüsüne girer 
            {
                Console.WriteLine($"Öğrenci Adı:{reader["Name"]} {reader[2]}");
            }
            connection.Close();//bağlantıyı kapa
            Console.WriteLine("Database bağlantısı koptu");
        }

    }
}
