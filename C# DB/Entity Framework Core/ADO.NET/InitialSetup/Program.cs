namespace InitialSetup
{
    using Microsoft.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Data Source=.;database=master;Integrated Security=True;"))
            {
                connection.Open();

                string query = @"CREATE DATABASE MinionsDB";

                ExecuteQuery(query, connection);
                connection.Dispose();
            }

            const string connectionString = "Data Source=.;database=MinionsDB;Integrated Security=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string[] createTableStatements =
                {
                    "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL)",
                    "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL, CountryCode INT REFERENCES Countries(Id))",
                    "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL, Age INT NOT NULL, TownId INT REFERENCES Towns(Id))",
                    "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) CHECK([Name] IN ('super good', 'good', 'bad', 'evil', 'super evil')) NOT NULL)",
                    "CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,[Name] VARCHAR(50) NOT NULL, EvilnessFactorsId INT REFERENCES EvilnessFactors(Id))",
                    "CREATE TABLE MinionsVillains (MinionId INT REFERENCES Minions(Id), VillainsId INT REFERENCES Villains(Id), " +
                    "CONSTRAINT pk_MinionsIdVillainsId PRIMARY KEY(MinionId, VillainsId))"
                };

                foreach (var statement in createTableStatements)
                {
                    ExecuteQuery(statement, connection);
                }

                string[] insertIntoStatement =
                {
                    "INSERT INTO Countries VALUES ('Bulgaria'), ('Greece'), ('Russia'), ('Panama'), ('Canada')",
                    "INSERT INTO Towns VALUES ('Ruse', 1), ('Athens', 2), ('Kazan', 3), ('San Jose', 4), ('Ottawa', 5)",
                    "INSERT INTO Minions VALUES ('Ivo', 18, 1), ('Stefan', 16, 2), ('Gosho', 19, 3), ('Misho', 22, 4), ('Stamat', 12, 5)",
                    "INSERT INTO EvilnessFactors VALUES ('super good'), ('good'), ('bad'), ('evil'), ('super evil')",
                    "INSERT INTO Villains VALUES ('Stamo', 1), ('Viktor Dakov', 1), ('Niki Kostov', 1), ('Atanas', 1), ('Kenov', 1)",
                    "INSERT INTO MinionsVillains VALUES (1, 2), (3, 4), (1, 3), (2, 3), (1, 5)"
                };

                foreach (var statement in insertIntoStatement)
                {
                    ExecuteQuery(statement, connection);
                }
            }
        }

        private static void ExecuteQuery(string statement, SqlConnection connection)
        {
            using (var command = new SqlCommand(statement, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
