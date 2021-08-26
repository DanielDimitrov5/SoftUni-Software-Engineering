CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(48) NOT NULL,
	DailyRate INT CHECK (DailyRate >= 0 AND DailyRate <= 10),
	WeeklyRate INT CHECK (WeeklyRate >= 0 AND WeeklyRate <= 10),
	MonthlyRate INT CHECK (MonthlyRate >= 0 AND MonthlyRate <= 10),
	WeekendRate INT CHECK (WeekendRate >= 0 AND WeekendRate <= 10)
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(12) NOT NULL,
	Manifacturer NVARCHAR(28) NOT NULL,
	Model NVARCHAR(28) NOT NULL,
	CarYear INT CHECK (CarYear>=1944 AND CarYear<=Year(GetDate())) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT,
	Picture VARCHAR(MAX),
	Condition VARCHAR(10) CHECK (Condition = 'Good' OR Condition = 'Bad' OR Condition = 'Perfect') NOT NULL,
	Available BIT DEFAULT ('true')
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(28) NOT NULL,
	LastName VARCHAR(28) NOT NULL,
	Title VARCHAR(36) DEFAULT ('regular'),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(120),
	City VARCHAR(36) NOT NULL,
	ZIPCode VARCHAR(12),
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CistomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT,
	KilometrageStart INT CHECK (KilometrageStart>=0) NOT NULL,
	KilometrageEnd INT CHECK (KilometrageEnd>0) NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate SMALLDATETIME NOT NULL,
	EndDate SMALLDATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied BIT DEFAULT ('false'),
	OrderStatus VARCHAR(13) CHECK (OrderStatus = 'Complited' OR OrderStatus = 'Not complited'),
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES	('Off-Road', 8, 8, 8, 8),
		('Track', 10, 10, 10, 10),
		('City', 7, 3, 6, 8)

INSERT INTO Cars (PlateNumber, Manifacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES		('P 1336 BK', 'Mercedes', 'C220', 2002, 3, 5, NULL, 'Perfect', 1),
			('P 0660 KM', 'Mercedes', 'S500', 2014, 3, 5, NULL, 'Perfect', 0),
			('B 77777', 'Mercedes', 'C400', 2017, 3, 5, NULL, 'Good', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES		('Ivan', 'Ivanov', DEFAULT, NULL),
			('Ivo', 'Georgiev', DEFAULT, NULL),
			('Stamt', 'Shefski', 'Shefa', NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES		('123123', 'Kiro Breika', NULL, 'VELIKO Turnovo', 7000, NULL),
			('1234567', 'Simbata', NULL, 'VELIKO Turnovo', 7007, NULL),
			('987655', 'Stefan Stefanov',NULL, 'Ruse', 700, NULL)

INSERT INTO RentalOrders (EmployeeId, CistomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, OrderStatus)
VALUES		(3, 1, 2, 100, 1000, 1800, 2800, '10/10/2020', '10/15/2020', 5, 'Complited'),
			(2, 2, 1, 95, 1000, 1800, 2800, '10/10/2020', '10/15/2020', 5, 'Complited'),
			(1, 1, 2, 60, 1000, 1800, 2800, '10/10/2020', '10/15/2020', 5, 'Not complited')