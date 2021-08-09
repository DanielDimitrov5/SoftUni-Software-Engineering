SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM MountainsCountries mc
	LEFT JOIN Mountains m ON mc.MountainId = m.Id
	LEFT JOIN Peaks p ON m.Id = p.MountainId
   WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
 ORDER BY p.Elevation DESC


SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM MountainsCountries mc
	LEFT JOIN Mountains m ON mc.MountainId = m.Id
	WHERE mc.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY mc.CountryCode

SELECT TOP(5)
	c.CountryName, r.RiverName 
	FROM Rivers r
	RIGHT JOIN CountriesRivers cr ON r.Id = cr.RiverId
	RIGHT JOIN Countries c ON cr.CountryCode = c.CountryCode
	WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName


SELECT TOP(5) 
	c.CountryName, r.RiverName 
	FROM Countries c 
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON cr.RiverId = r.Id
	LEFT JOIN Continents co ON c.ContinentCode = co.ContinentCode
	WHERE co.ContinentName = 'Africa'
 ORDER BY c.CountryName


 SELECT k.ContinentCode,
         k.CurrencyCode,
         k.CurrencyUsage
    FROM (  SELECT ct.ContinentCode,
                   ct.CurrencyCode,
          		     COUNT(ct.CurrencyCode) 
                AS [CurrencyUsage],
          	       DENSE_RANK() OVER (PARTITION BY ct.ContinentCode ORDER BY COUNT(ct.CurrencyCode) DESC)
                AS [Rank]
              FROM Countries AS ct
              JOIN Continents AS [cont]
                ON ct.ContinentCode = [cont].ContinentCode
          GROUP BY ct.ContinentCode,
                   ct.CurrencyCode) AS k
   WHERE k.[Rank] = 1
     AND k.CurrencyUsage != 1
ORDER BY k.ContinentCode

SELECT COUNT(c.CountryCode) 
	FROM Countries c 
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	WHERE MountainId IS NULL

SELECT TOP(5)
		c.CountryName, 
		MAX(p.Elevation) AS HighestPeakElevation,
		MAX(r.Length) AS LongestRiverLength
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains m ON mc.MountainId = m.Id
		LEFT JOIN Peaks p ON m.Id = p.MountainId
		LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r ON cr.RiverId = r.Id
  GROUP BY CountryName
  ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC


SELECT c.CountryName, MAX(p.Elevation) AS [Highest Peak Elevation], m.MountainRange AS [Mountain],
	 DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains m ON mc.MountainId = m.Id
		LEFT JOIN Peaks p ON m.Id = p.MountainId
	GROUP BY c.CountryName, m.MountainRange, p.PeakName


SELECT TOP(5)
	    k.CountryName AS Country,
	    ISNULL(k.PeakName, '(no highest peak)') AS [Highest Peak Name],
	    ISNULL(k.[Highest Peak Elevation], 0) AS [Highest Peak Elevation],
	    ISNULL(k.Mountain, '(no mountain)') AS [Mountain]
	FROM (SELECT c.CountryName, MAX(p.Elevation) AS [Highest Peak Elevation], m.MountainRange AS [Mountain],
	 DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank], p.PeakName
	FROM Countries c
		LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains m ON mc.MountainId = m.Id
		LEFT JOIN Peaks p ON m.Id = p.MountainId
	GROUP BY c.CountryName, m.MountainRange, p.PeakName) AS k
	WHERE k.Rank = 1
 ORDER BY Country, [Highest Peak Name]
