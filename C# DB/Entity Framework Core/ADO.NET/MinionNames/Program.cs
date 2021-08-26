namespace MinionNames
{
    using System;
    using Microsoft.Data.SqlClient;

    class Program
    {
        const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True";

        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string villainQuery = @$"SELECT [Name]
	                                       FROM Villains
	                                       WHERE Id = {villainId}";

                using (var command = new SqlCommand(villainQuery, connection))
                {
                    if (command.ExecuteScalar() is null)
                    {
                        Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {command.ExecuteScalar()}");
                }

                string minionsQuery = $@"SELECT CAST(ROW_NUMBER() 
                                        		OVER (ORDER BY m.Name) AS VARCHAR) + '.' , 
                                        		m.[Name],
                                        		m.Age
                                        	FROM MinionsVillains mv
                                        	LEFT JOIN Minions m ON m.Id = mv.MinionId
                                        	WHERE mv.VillainsId = {villainId}";

                using (var command = new SqlCommand(minionsQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows is false)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                        }
                    }
                }
            }
        }
    }
}
