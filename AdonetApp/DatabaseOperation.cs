using System;
using System.Data.SqlClient;

namespace AdonetApp
{
    internal class DatabaseOperation
    {
        public static void GetStudentGroups()
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=Education;Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * from Groups", connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Eğitim GroupAdları");
                while (reader.Read())//Tek tek kayıtlar okunur ve kayıt olduğu müdddetçe while döngüsüne girer 
                {
                    Console.WriteLine($"{reader["Name"]}");
                }
            }
        }

        public static void GetStudents()
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
        public static void GetStudentsOld()
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

        public static void InsertStudentGroup()
        {
            using (SqlConnection connection = new SqlConnection("Server=.;Database=Education;Integrated Security=true"))
            {
                connection.Open();

                string sqlCommandQuery = "Insert Into Groups(Name,StartDate,EndDate,IsActive) values(@Name,@StartDate,@EndDate,@IsActive)";
                SqlCommand command = new SqlCommand(sqlCommandQuery, connection);
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = "Ozz Akademi Elit";
                command.Parameters.Add("@StartDate", System.Data.SqlDbType.DateTime, 50).Value = DateTime.Now.AddYears(-2);
                command.Parameters.Add("@EndDate", System.Data.SqlDbType.DateTime, 50).Value = DateTime.Now.AddMonths(10);
                command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = 1;

                command.ExecuteNonQuery();

            }
        }
    }
}
