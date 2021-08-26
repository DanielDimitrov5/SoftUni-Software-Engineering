CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Towns
VALUES		('Sofis'),
			('Plovdiv'),
			('Varna'),
			('Burgas')

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText	NVARCHAR(90) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Departments
VALUES		('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')


CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(60) NOT NULL,		
	MiddleName NVARCHAR(90) NOT NULL,		
	LastName NVARCHAR(90) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

	select convert(varchar, getdate(), 3)
	delete from Employees

INSERT INTO Employees
VALUES		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00, NULL),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00, NULL),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25, NULL),
			('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00, NULL),
			('Peter', 'Pan', 'Pan', 'Intern', 3, '08/29/2016', 599.88, NULL)


--Problem 19.	Basic Select All Fields

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees


--Problem 20.	Basic Select All Fields and Order Them

SELECT * FROM Towns ORDER BY([Name])

SELECT * FROM Departments ORDER BY([Name])

SELECT * FROM Employees ORDER BY (Salary) DESC


--Problem 21.	Basic Select Some Fields

SELECT [Name] FROM Towns ORDER BY([Name])

SELECT [Name] FROM Departments ORDER BY([Name])

SELECT [FirstName], 
	   [LastName], 
	   [JobTitle], 
	   [Salary]
FROM Employees 
ORDER BY (Salary) DESC


--Problem 22.	Increase Employees Salary

UPDATE Employees
SET Salary *= 1.1

SELECT [Salary] FROM Employees


--Problem 23.	Decrease Tax Rate

UPDATE Payments
SET TaxRate *= 0.97

SELECT [TaxRate] FROM Payments


--Problem 24.	Delete All Records

DELETE  FROM Occupancies

