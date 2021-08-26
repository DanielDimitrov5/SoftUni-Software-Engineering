namespace VillainNames
{
    using System;
    using Microsoft.Data.SqlClient;

    class Program
    {
        const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT v.Name, COUNT(mv.MinionId) AS [count]
	                                FROM Villains v
                                	LEFT JOIN MinionsVillains mv ON v.Id = mv.MinionId
                                	  GROUP BY v.Name
                                      HAVING COUNT(mv.MinionId) >= 3
                                  ORDER BY [count] DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
