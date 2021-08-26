SELECT MountainRange, PeakName, Elevation 
	FROM Peaks
	JOIN Mountains ON (MountainId = Mountains.Id)
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC