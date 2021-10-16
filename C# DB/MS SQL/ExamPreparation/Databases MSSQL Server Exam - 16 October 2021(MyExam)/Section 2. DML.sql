--2.Insert

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) 
VALUES	('COHIBA ROBUSTO', 9, 1 , 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
		('COHIBA SIGLO I', 9, 1 , 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
		('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5 , 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
		('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4 , 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
		('TRINIDAD COLONIALES', 2, 3 , 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
	   ('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
	   ('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')


--3. Update

UPDATE Cigars
SET PriceForSingleCigar *= 1.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--4. Delete

DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE N'C%')

DELETE FROM Addresses
WHERE Country LIKE N'C%'