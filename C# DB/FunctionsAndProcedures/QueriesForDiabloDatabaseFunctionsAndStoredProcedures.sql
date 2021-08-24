CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT SUM(Cash) AS SumCash
			FROM (SELECT ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [Rank], Cash
				FROM UsersGames ug
				LEFT JOIN Games g ON ug.GameId = g.Id
				WHERE g.[Name] = @gameName) AS [data]
			WHERE [Rank] % 2 = 1)

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')
