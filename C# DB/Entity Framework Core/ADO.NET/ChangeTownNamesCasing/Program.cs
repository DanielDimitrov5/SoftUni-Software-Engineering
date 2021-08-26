namespace ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

            string country = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int countryCode;

                using (var command = new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{country}'", connection))
                {
                    if (command.ExecuteScalar() is null)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    countryCode = (int)command.ExecuteScalar();
                }

                int rowsAffected;

                using (var command = new SqlCommand($"UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = {countryCode}", connection))
                {
                    rowsAffected = command.ExecuteNonQuery();
                }

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");

                List<string> towns = new List<string>();

                using (var command = new SqlCommand($"SELECT Name FROM Towns WHERE CountryCode = {countryCode}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add(reader[0] as string);
                        }
                    }
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }
    }
}
