--5.	Cigars by Price

SELECT CigarName, PriceForSingleCigar, ImageURL 
	FROM Cigars
  ORDER BY PriceForSingleCigar, CigarName DESC

--6.	Cigars by Taste

SELECT c.Id, CigarName, PriceForSingleCigar, TasteType, TasteStrength 
	FROM Cigars c
	LEFT JOIN Tastes t ON c.TastId = t.Id
	WHERE t.TasteType IN ('Earthy', 'Woody') 
  ORDER BY PriceForSingleCigar DESC

--7.	Clients without Cigars

SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email
	FROM Clients c
	 LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
	 WHERE cc.CigarId IS NULL
  ORDER BY ClientName

--8.	First 5 Cigars

SELECT TOP 5 CigarName, PriceForSingleCigar, ImageURL
	FROM Cigars c
    JOIN Sizes s ON c.SizeId = s.Id
	WHERE s.Length >= 12 AND (c.CigarName LIKE N'%ci%' 
		  OR c.PriceForSingleCigar > 50 AND s.RingRange > 2.55)
  ORDER BY CigarName, PriceForSingleCigar DESC


--9.	Clients with ZIP Codes

SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
		Country,
		ZIP,
		CONCAT('$', MAX(cg.PriceForSingleCigar)) AS CigarPrice
	FROM Clients c
	JOIN Addresses a ON c.AddressId = a.Id
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cg ON cc.CigarId = cg.Id
	WHERE a.ZIP NOT LIKE '%[^0123456789]%'
	GROUP BY FirstName, LastName, a.Country, a.ZIP
  ORDER BY FullName

--10.	Cigars by Size

SELECT c.LastName, AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients c
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cg ON cc.CigarId = cg.id
	JOIN Sizes s ON cg.SizeId = s.Id
	GROUP BY c.LastName
  ORDER BY CiagrLength DESC

--11.	Client with Cigars

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @TotalCigars INT = 
	(SELECT COUNT(*) 
		FROM Clients c
		LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
		WHERE c.FirstName = @name)

		RETURN @TotalCigars
END

--12.	Search for Cigar with Specific Taste

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT c.CigarName, 
			CONCAT('$', c.PriceForSingleCigar), 
			t.TasteType, 
			b.BrandName,
			CONCAT(s.Length, ' cm') AS CigarLength,
			CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars c
		JOIN Sizes s ON c.SizeId = s.Id
		JOIN Tastes t ON c.TastId = t.Id
		JOIN Brands b ON c.BrandId = b.Id
		WHERE t.TasteType = @taste
	  ORDER BY CigarLength, CigarRingRange DESC
END

