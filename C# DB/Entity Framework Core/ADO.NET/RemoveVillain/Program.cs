namespace RemoveVillain
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

                string villainName;

                using (var command = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {id}", connection))
                {
                    if (command.ExecuteScalar() is null)
                    {
                        Console.WriteLine($"No such villain was found.");
                        return;
                    }

                    villainName = command.ExecuteScalar() as string;
                }

                int minionsReleased;

                using (var command = new SqlCommand($"DELETE FROM MinionsVillains WHERE VillainsId = {id}", connection))
                {
                    minionsReleased = command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand($"DELETE FROM Villains WHERE Id = {id}", connection))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsReleased} minions were released.");
            }
        }
    }
}
