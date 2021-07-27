CREATE TABLE People
(
	Id BIGINT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(200),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES	('Ivo Ivanov', NULL, 1.89, 100.50, 'm', '1989-05-20', 'Alo' ),
		('Stefan Stefanov', NULL, 1.89, 100.50, 'm', '1989-05-20', 'Alo' ),
		('Ivo Ivanovski', NULL, 1.89, 100.50, 'm', '1989-05-20', 'Alo' ),
		('Pesho Ivanov', NULL, 1.89, 100.50, 'm', '1989-05-20', 'Alo' ),
		('Stamat Ivanov', NULL, 1.89, 100.50, 'm', '1989-05-20', 'Alo' )