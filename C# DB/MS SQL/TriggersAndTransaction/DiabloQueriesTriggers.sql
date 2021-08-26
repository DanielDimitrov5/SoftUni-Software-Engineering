CREATE TRIGGER tr_UsersCannotBuyItemsWithHigherLevel
ON UserGameItems FOR INSERT
AS
BEGIN
	DECLARE @UserLevel INT
	DECLARE @ItemLevel INT

	SET @UserLevel = (SELECT ug.[Level] FROM inserted i LEFT JOIN UsersGames ug ON i.UserGameId = ug.Id)
	SET @ItemLevel = (SELECT it.MinLevel FROM inserted i LEFT JOIN Items it ON i.ItemId = it.Id)

	IF (@UserLevel < @ItemLevel)
	BEGIN
		RAISERROR('User Level is too low for this item!', 15, 1)
	END
END

UPDATE UsersGames
	SET Cash += 50000
	WHERE UserId IN (61, 52, 37, 22, 12) AND GameId = 212
	 
DECLARE @Counter INT 
SET @Counter = 251

WHILE (@Counter <= 299)
BEGIN
	INSERT INTO UserGameItems
	VALUES (@Counter, 61)

	INSERT INTO UserGameItems
	VALUES (@Counter, 52)

	INSERT INTO UserGameItems
	VALUES (@Counter, 37)	
	
	INSERT INTO UserGameItems
	VALUES (@Counter, 22)

	INSERT INTO UserGameItems
	VALUES (@Counter, 12)

	SET @Counter =+ 1
END


SET @Counter = 501

WHILE (@Counter <= 539)
BEGIN
	INSERT INTO UserGameItems
	VALUES (@Counter, 61)

	INSERT INTO UserGameItems
	VALUES (@Counter, 52)

	INSERT INTO UserGameItems
	VALUES (@Counter, 37)	
	
	INSERT INTO UserGameItems
	VALUES (@Counter, 22)

	INSERT INTO UserGameItems
	VALUES (@Counter, 12)

	SET @Counter =+ 1
END

SELECT u.Username, g.Name, ug.Cash, i.Name
	FROM Users u
	LEFT JOIN UsersGames ug ON u.Id = ug.UserId
	LEFT JOIN Games g ON ug.GameId = g.Id
	LEFT JOIN UserGameItems ugt ON ug.Id = ugt.UserGameId
	LEFT JOIN Items i ON ugt.ItemId = i.Id
   WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') AND ug.GameId = 212
  ORDER BY u.Username, i.Name