CREATE PROC usp_GetEmployeesSalaryAbove35000 AS
BEGIN
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18, 4)) 
AS
BEGIN
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO

CREATE PROC usp_GetTownsStartingWith (@String VARCHAR(50))
AS
BEGIN 
	SELECT [Name]
		FROM Towns
		WHERE Name LIKE @String + '%'
END

EXEC usp_GetTownsStartingWith 'b'

GO

CREATE PROC usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
BEGIN 
	SELECT FirstName, LastName
		FROM Employees e
		LEFT JOIN Addresses a ON e.AddressID = a.AddressID
		LEFT JOIN Towns t ON a.TownID = t.TownID
	  WHERE t.[Name] = @TownName
END

EXEC usp_GetEmployeesFromTown Sofia

GO

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @Level VARCHAR(10);
	
	IF @salary < 30000
		SET @Level = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		SET @Level = 'Average'
	ELSE
		SET @Level = 'High'

	RETURN @Level
END

SELECT [dbo].[ufn_GetSalaryLevel](13500.00)

GO

CREATE PROC usp_EmployeesBySalaryLevel(@Level VARCHAR(10))
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
		WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @Level
END

EXEC usp_EmployeesBySalaryLevel 'High'

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @Count INT = 1
	DECLARE @Letter VARCHAR(1)

	WHILE (LEN(@word) >= @Count)
	BEGIN
		SET @Letter = SUBSTRING(@word, @Count, 1)

		IF @setOfLetters NOT LIKE '%' + @Letter + '%'
			RETURN 0

		SET @Count += 1
	END
	RETURN 1 
END

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia') AS Result
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves') AS Result

GO

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID
		  FROM Employees
		 WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	   SET ManagerID = NULL
	 WHERE ManagerID IN ( 
		SELECT EmployeeID
		  FROM Employees
		 WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT

	UPDATE Departments
	   SET ManagerID = NULL
	 WHERE DepartmentID = @departmentId

	 DELETE FROM Employees
	 WHERE DepartmentID = @departmentId

	 DELETE FROM Departments
	 WHERE DepartmentID = @departmentId

	 SELECT COUNT(*)
	   FROM Employees
       WHERE DepartmentID = @departmentId
END

