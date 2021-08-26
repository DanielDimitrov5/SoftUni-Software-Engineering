namespace AddMinion
{
    using System;
    using System.Linq;

    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine().Split().Skip(1).ToArray();

            string minionName = minionInput[0];
            int minionAge = int.Parse(minionInput[1]);
            string minionTown = minionInput[2];

            string[] villainInput = Console.ReadLine().Split().Skip(1).ToArray();

            string villainName = villainInput[0];

            const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand($"SELECT Name FROM Towns WHERE Name = '{minionTown}'", connection))
                {
                    if (command.ExecuteScalar() is null)
                    {
                        string insertTown = $@"INSERT INTO Towns (Name) VALUES ('{minionTown}')";

                        using (var insertTownCommand = new SqlCommand(insertTown, connection))
                        {
                            insertTownCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }


                using (var command = new SqlCommand($"SELECT Name FROM Villains WHERE Name = '{villainName}'", connection))
                {
                    if (command.ExecuteScalar() is null)
                    {
                        string insertVillain = $@"INSERT INTO Villains VALUES ('{villainName}', 4)";

                        using (var insertTownCommand = new SqlCommand(insertVillain, connection))
                        {
                            insertTownCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }

                int townId;

                using (var getTownId = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", connection))
                {
                    townId = (int)getTownId.ExecuteScalar();
                }

                using (var addMinionCommand = new SqlCommand(@$"INSERT INTO Minions VALUES ('{minionName}', '{minionAge}', {townId})", connection))
                {
                    addMinionCommand.ExecuteNonQuery();
                }

                int villainId;
                int minionId;

                using (var getVillainId = new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", connection))
                {
                    villainId = (int)getVillainId.ExecuteScalar();
                }

                using (var getMinionId = new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", connection))
                {
                    minionId = (int)getMinionId.ExecuteScalar();
                }

                using (var makeMinionServant = new SqlCommand($"INSERT INTO MinionsVillains VALUES ({minionId}, {villainId})", connection))
                {
                    makeMinionServant.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
            }
        }
    }
}
