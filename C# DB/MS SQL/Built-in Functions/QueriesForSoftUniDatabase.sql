SELECT FirstName, LastName 
	FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName 
	FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName
	FROM Employees
WHERE DepartmentID IN(3, 10) AND 
	  YEAR(HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName 
	FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] FROM Towns
	WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

SELECT TownID, [Name] FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

SELECT TownID, [Name] FROM Towns
	WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]


CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
	WHERE HireDate > CAST('2001' AS DATE)

SELECT FirstName, LastName FROM Employees
	WHERE LEN(LastName) = 5


SELECT EmployeeID,	FirstName, LastName, Salary, 
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] 
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC


SELECT * FROM
	(SELECT EmployeeID,	FirstName, LastName, Salary, 
			DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] 
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS RankedEmployees
	WHERE [RANK] = 2
ORDER BY Salary DESC