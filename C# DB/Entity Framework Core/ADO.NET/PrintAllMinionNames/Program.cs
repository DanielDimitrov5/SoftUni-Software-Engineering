namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> minions = new List<string>();

            using (var connection = new SqlConnection("Data Source=.;database=MinionsDB;Integrated Security=True;"))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT Name FROM Minions", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minions.Add(reader[0] as string);
                        }
                    }
                }
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
            }

            if (minions.Count % 2 == 1)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }
    }
}
