CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
	Id BIGINT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(55) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id BIGINT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(55) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories 
(
	Id BIGINT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(55) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Title VARCHAR(55) NOT NULL,
	DirectorId BIGINT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId BIGINT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId BIGINT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating FLOAT CHECK (RATING>=0 AND RATING<=10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
VALUES		('Ivo', 'Good one'),
			('Stamat', NULL),
			('Jorko', NULL),
			('Gogi', 'Best Director'),
			('Chompi', NULL)

INSERT INTO Genres (GenreName, Notes)
VALUES		('Action', NULL),
			('Horror', 'Creepy'),
			('Romance', NUll),
			('Comedy', NULL),
			('Fantasy', NULL)


INSERT INTO Categories (CategoryName, Notes)
VALUES		('Animated', NULL),
			('Mystery', 'Creepy'),
			('Gangster', NUll),
			('Sports', NULL),
			('Science Fiction', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES			   ('Batman', 1, 1999, 211, 1, 3, 8, 'Full of action'),
                   ('Titanic', 4, 1997, 268, 3, 3, 9, NULL),
				   ('Fast and Furious 7', 2, 2016, 212, 1, 4, 10, 'It is a must see!'),
				   ('Ford vs Ferrari', 5, 1995, 198, 1, 4, 7, NULL),
				   ('Toy Story 4', 3, 2019, 168, 4, 1, 9, NULL)
