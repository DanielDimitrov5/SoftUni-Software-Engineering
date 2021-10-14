--5.	Products by Price

SELECT [Name], Price, [Description] 
	FROM Products
  ORDER BY Price DESC, [Name]

--6.	Negative Feedback

SELECT ProductId, Rate, Description, CustomerId, c.Age, c.Gender 
	FROM Feedbacks f
	JOIN Customers c ON f.CustomerId = c.Id
	WHERE Rate < 5
  ORDER BY ProductId DESC, Rate

--7.	Customers without Feedback

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   c.PhoneNumber,
	   c.Gender
		FROM Customers c
	LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
	WHERE f.Id IS NULL
  ORDER BY c.Id

--8.	Customers by Criteria

SELECT FirstName, Age, PhoneNumber 
	FROM Customers c
	LEFT JOIN Countries cr ON c.CountryId = cr.Id
	WHERE (Age >= 21 AND FirstName LIKE N'%an%') OR 
		  (PhoneNumber LIKE '%38' AND cr.[Name] != 'Greece')
  ORDER BY FirstName, Age DESC

--9.	Middle Range Distributors

SELECT CountryName, DisributorName
  FROM(
	SELECT *,
		   DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY IngredientCount DESC) AS [Rank]
	  FROM (
	    SELECT c.[Name] AS CountryName, 
		   	   d.[Name] AS DisributorName,
	    	   COUNT(i.[Name]) AS IngredientCount
			      FROM Countries AS c
			      LEFT JOIN Distributors AS d ON c.Id = d.CountryId
			      LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
			      GROUP BY c.[Name], d.[Name]) AS g
		) AS t
	WHERE [Rank] = 1
  ORDER BY CountryName, DisributorName