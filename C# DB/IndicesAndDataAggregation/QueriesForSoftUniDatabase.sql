SELECT e.DepartmentID, SUM(e.Salary) AS TotalSalary
	FROM Employees e
	GROUP BY e.DepartmentID
   ORDER BY e.DepartmentID

SELECT e.DepartmentID, MIN(e.Salary) AS MinimumSalary
	FROM Employees e
	WHERE e.DepartmentID IN (2, 5, 7)
	AND e.HireDate > '2000-01-01'
	GROUP BY e.DepartmentID


SELECT *
  INTO EmployeesAverageSalaries
  FROM Employees
 WHERE Salary > 30000

DELETE 
	FROM EmployeesAverageSalaries
	WHERE ManagerID = 42

UPDATE EmployeesAverageSalaries
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
	FROM EmployeesAverageSalaries e
	GROUP BY e.DepartmentID

SELECT e.DepartmentID, MAX(e.Salary) AS MaxSalary
	FROM Employees e
	GROUP BY e.DepartmentID
	HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(*) AS [Count]
	FROM Employees
	WHERE Employees.ManagerID IS NULL

SELECT DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary) AS [Rank], e.Salary, e.DepartmentID
	FROM Employees e

SELECT ee.DepartmentID, rk.Salary AS ThirdHighestSalary
	FROM Employees ee
	LEFT JOIN (
		SELECT DENSE_RANK() OVER(PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [Rank],
		 e.Salary, e.DepartmentID
	FROM Employees e) rk ON rk.DepartmentID = ee.DepartmentID 
	WHERE rk.[Rank] = 3
	GROUP BY ee.DepartmentID, rk.Salary

SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
	FROM Employees e
	GROUP BY e.DepartmentID

SELECT TOP(10)
	   e.FirstName, e.LastName, e.DepartmentID
	  FROM Employees e
	  LEFT JOIN 
		(SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
			FROM Employees e
			GROUP BY e.DepartmentID) AS [Avg]
	  ON e.DepartmentID = [Avg].DepartmentID
   WHERE e.Salary > [Avg].AverageSalary
   ORDER BY DepartmentID