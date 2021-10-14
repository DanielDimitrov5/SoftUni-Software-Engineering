--11.	Customers with Countries

CREATE VIEW v_UserWithCountries 
AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   cr.Name
			FROM Customers c
	LEFT JOIN Countries cr ON c.CountryId = cr.Id

--12.	Delete Products

 CREATE TRIGGER tr_DeleteRelations
 ON Products
 INSTEAD OF DELETE
 AS
 BEGIN
	DECLARE @productId INT;
	SET @productId = (SELECT p.Id FROM Products p
						JOIN deleted d ON p.Id = d.Id)
	DELETE FROM Feedbacks
		WHERE ProductId = @productId

	DELETE FROM ProductsIngredients
		WHERE ProductId = @productId

	DELETE FROM Products
		WHERE Id = @productId
 END