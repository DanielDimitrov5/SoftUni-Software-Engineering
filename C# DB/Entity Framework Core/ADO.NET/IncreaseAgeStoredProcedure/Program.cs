namespace IncreaseAgeStoredProcedure
{
    using System;
    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

            int id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand($"EXEC usp_GetOlder {id}", connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Id = {id}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                    }
                }
            }
        }
    }
}
