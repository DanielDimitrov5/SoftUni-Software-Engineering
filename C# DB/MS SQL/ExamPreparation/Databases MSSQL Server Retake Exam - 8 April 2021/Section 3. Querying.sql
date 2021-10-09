--5.	Unassigned Reports

SELECT [Description], Format(OpenDate, 'dd-MM-yyyy') AS OpenDate5 FROM Reports
	WHERE EmployeeId IS NULL
  ORDER BY OpenDate, [Description]

--6.	Reports & Categories

SELECT [Description], c.[Name] AS CategoryName FROM Reports r
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	WHERE c.[Name] IS NOT NULL
  ORDER BY [Description], c.[Name] DESC

--7.	Most Reported Category

SELECT TOP(5)
	c.Name AS CategoryName, 
	Count(r.CategoryId) AS ReportsNumber 
		FROM Reports r
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	GROUP BY c.Name
	ORDER BY ReportsNumber DESC, CategoryName

--8.	Birthday Report

SELECT u.Username, c.Name FROM Reports r
	LEFT JOIN Users u ON r.UserId = u.Id
	LEFT JOIN Categories c ON c.Id = r.CategoryId
	WHERE DAY(r.OpenDate) = DAY(u.Birthdate)
  ORDER BY u.Username, c.Name

--9.	Users per Employee 

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, COUNT(Name) AS UserCount 
		FROM Employees e
	 LEFT JOIN Reports r ON e.Id = r.EmployeeId
	 LEFT JOIN Users u ON r.UserId = u.id
	GROUP BY FirstName, e.LastName
  ORDER BY UserCount DESC, FullName

--10.	Full Info

SELECT CASE WHEN CONCAT(e.FirstName, ' ', e.LastName) = ' ' THEN 'None' ELSE CONCAT(e.FirstName, ' ', e.LastName) END AS Employee,
	   CASE WHEN d.Name = '' OR d.Name IS NULL THEN 'None' ELSE d.Name END AS Department,
	   c.Name AS CategoryName,
	   r.Description,
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.Label AS Status,
	   CASE WHEN u.Name = '' THEN 'None' ELSE u.Name END AS [User]
		FROM Reports r
	LEFT JOIN Employees e ON r.EmployeeId = e.Id
	LEFT JOIN Departments d ON e.DepartmentId = d.Id
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	LEFT JOIN Status s ON r.StatusId = s.Id
	LEFT JOIN Users u ON r.UserId = u.Id
  ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate, Status, User