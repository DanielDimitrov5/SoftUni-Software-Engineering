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