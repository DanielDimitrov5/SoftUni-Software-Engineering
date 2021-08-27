namespace IncreaseMinionAge
{
    using System;
    using System.Linq;

    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

            int[] idInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var id in idInput)
                {
                    string query = @$"UPDATE Minions
                                        SET Age += 1,
                                        	Name = UPPER(LEFT(Name, 1)) + 
                                        		   LOWER(RIGHT(Name, LEN(Name) - 1))
                                          WHERE Id = {id}";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Id = {id}", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
