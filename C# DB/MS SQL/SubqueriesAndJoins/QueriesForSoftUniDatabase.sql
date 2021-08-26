SELECT TOP(5) 
  EmployeeID, JobTitle, e.AddressID, AddressText 
	FROM Employees e 
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID 
  ORDER BY AddressID

SELECT TOP(50) 
  FirstName, LastName, t.Name, AddressText 
	FROM Employees e 
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
  ORDER BY FirstName, LastName

SELECT TOP(50) 
  EmployeeID, FirstName, LastName, d.Name AS DepartmentName
	FROM Employees e 
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
  ORDER BY EmployeeID

SELECT TOP(5) 
  EmployeeID, FirstName, Salary, d.Name AS DepartmentName
	FROM Employees e 
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE Salary > 15000
  ORDER BY e.DepartmentID

SELECT TOP(3) 
	e.EmployeeID, FirstName 
	  FROM Employees e 
	    LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
    WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

SELECT FirstName, LastName, HireDate, d.Name AS DeptName 
	  FROM Employees e
	  LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
 ORDER BY HireDate

SELECT TOP(5)
	e.EmployeeID, e.FirstName, p.[Name] AS ProjectName  
		FROM Employees e 
		  LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		  LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
		WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

SELECT TOP(5)
	e.EmployeeID, e.FirstName, 
		CASE 
			WHEN YEAR(p.StartDate) >= 2005 THEN NULL
			ELSE p.Name 	
		END AS ProjectName  
		FROM Employees e 
		  LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
		  LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
		WHERE e.EmployeeID = 24
	ORDER BY e.EmployeeID


SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName 
	FROM Employees e
	LEFT JOIN Employees ee ON e.ManagerID = ee.EmployeeID
	WHERE e.ManagerID IN (3, 7)
  ORDER BY e.EmployeeID

SELECT TOP(50)
	e.EmployeeID, 
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(ee.FirstName, ' ',  ee.LastName) AS MangerName, 
	d.[Name] AS DepartmentName
	  FROM Employees e
		 LEFT JOIN Employees ee ON e.ManagerID = ee.EmployeeID
		 LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
  ORDER BY e.EmployeeID

SELECT Min(AvgSalary) AS MinAvarageSalary
	FROM 
	(SELECT AVG(Salary) AS AvgSalary 
		FROM Employees GROUP BY DepartmentID) AS s