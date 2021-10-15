--5. EEE-Mails

SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy'), c.[Name], Email
	FROM Accounts a
	LEFT JOIN Cities c ON a.CityId = c.Id
	WHERE Email LIKE N'e%'
  ORDER BY c.[Name]

--6. City Statistics

SELECT c.Name AS City, COUNT(h.Id) AS Hotels 
	FROM Cities c
	LEFT JOIN Hotels h ON c.Id = h.CityId
	GROUP BY c.[Name]
	HAVING COUNT(h.Id) > 0
  ORDER BY Hotels DESC, c.[Name]

--7. Longest and Shortest Trips

SELECT a.Id AS AccountId,
	   CONCAT(a.FirstName, ' ', a.LastName),
	   MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
	FROM Accounts a
	JOIN AccountsTrips at ON a.Id = at.AccountId
	JOIN Trips t ON at.TripId = t.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
   GROUP BY a.Id, a.FirstName, a.LastName
  ORDER BY LongestTrip DESC, ShortestTrip

--8. Metropolis
 
SELECT TOP 10
		c.Id, 
		c.[Name] AS City,
		c.CountryCode AS Country,
		COUNT(a.Id) AS Accounts
	FROM Cities c
	JOIN Accounts a ON c.Id = a.CityId
	GROUP BY c.Id, c.[Name], c.CountryCode
  ORDER BY Accounts DESC

--9. Romantic Getaways

SELECT a.Id, Email, c.[Name] AS City, COUNT(a.Id) Trips  FROM
	Accounts a
	JOIN AccountsTrips at ON a.Id = at.AccountId
	JOIN Trips t ON at.TripId = t.Id
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities c ON h.CityId = c.Id
	WHERE a.CityId = h.CityId
   GROUP BY a.Id, Email, c.[Name]
  ORDER BY Trips DESC, a.Id

--10. GDPR Violation

SELECT t.Id,
	   CONCAT_WS(' ',a.FirstName, a.MiddleName, a.LastName) AS [Full Name],
	   (SELECT [Name] FROM Cities WHERE Id = a.CityId) AS [From],
	   (SELECT [Name] FROM Cities WHERE Id = h.CityId) AS [To],
	   (CASE WHEN t.CancelDate IS NULL 
			THEN CONVERT(VARCHAR , DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
			ELSE 'Canceled' END) AS Duration
	FROM Trips t
	JOIN  AccountsTrips at ON t.Id = at.TripId
	JOIN Accounts a ON at.AccountId = a.Id
	JOIN Rooms r ON r.Id = t.RoomId
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities c ON h.CityId = c.Id
  ORDER BY [Full Name], t.Id