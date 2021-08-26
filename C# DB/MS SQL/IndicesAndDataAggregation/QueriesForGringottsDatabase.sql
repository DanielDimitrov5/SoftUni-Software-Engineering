SELECT COUNT(*) FROM WizzardDeposits

SELECT MAX(w.MagicWandSize) AS [LongestMagicWand] 
	FROM WizzardDeposits w

SELECT w.DepositGroup,
	   MAX(w.MagicWandSize) AS [LongestMagicWand]
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup

SELECT TOP(2)
	w.DepositGroup
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup
	ORDER BY AVG(w.MagicWandSize)

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
	FROM WizzardDeposits w
	WHERE w.MagicWandCreator = 'Ollivander family'
	GROUP BY w.DepositGroup

SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
	FROM WizzardDeposits w
	WHERE w.MagicWandCreator = 'Ollivander family'
	GROUP BY w.DepositGroup
  HAVING SUM(w.DepositAmount) < 150000
  ORDER BY TotalSum DESC

SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge)
	FROM WizzardDeposits w
	GROUP BY w.DepositGroup, w.MagicWandCreator
	ORDER BY w.MagicWandCreator

SELECT [data].Groups, COUNT(*) AS WizardCount
	FROM(SELECT 
	CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  ELSE '[61+]'
	END AS Groups
	FROM WizzardDeposits w) AS [data]
	GROUP BY [data].Groups
	
SELECT LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName, 1) 
	ORDER BY FirstLetter

SELECT w.DepositGroup, w.IsDepositExpired, AVG(w.DepositInterest) AS AverageInterest
	FROM WizzardDeposits w
	WHERE w.DepositStartDate > '1985-01-01'
	GROUP BY w.DepositGroup, w.IsDepositExpired
   ORDER BY w.DepositGroup DESC, w.IsDepositExpired

 SELECT(SELECT w.DepositAmount
	FROM WizzardDeposits w
	WHERE w.Id = wd.id + 1) AS Diff
	FROM WizzardDeposits wd

SELECT SUM([data].Diff) AS SumDifference
	FROM (SELECT wd.DepositAmount - (SELECT w.DepositAmount
		FROM WizzardDeposits w
		WHERE w.Id = wd.id + 1) AS Diff
	FROM WizzardDeposits wd) AS [data]
	