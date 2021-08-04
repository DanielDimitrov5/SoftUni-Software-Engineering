SELECT TOP(50) [Name],
		FORMAT([Start], 'yyyy-MM-dd') AS [Start] 
	FROM Games
	WHERE YEAR([Start]) IN ('2011', '2012')
ORDER BY [Start]

SELECT Username,
		SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS 'Email Provider'
	FROM Users
ORDER BY [Email Provider], Username


SELECT Username, IpAddress FROM Users
	WHERE IpAddress LIKE '[0-9][0-9][0-9].1%.%[0-9][0-9][0-9]'
ORDER BY Username

SELECT [Name] AS Game,
		CASE 
			WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon' 
			WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening' 
			END AS [Part of the Day],
		CASE
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			WHEN Duration IS NULL THEN 'Extra Long'
			END AS Duration
FROM Games
ORDER BY [Name], Duration, [Part of the Day]
