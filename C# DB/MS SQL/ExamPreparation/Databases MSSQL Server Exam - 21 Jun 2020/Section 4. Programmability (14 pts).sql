--11. Available Room 

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @roomId INT = (SELECT TOP 1 r.Id 
							FROM Rooms r
							JOIN Trips t ON t.Id = t.Id
							JOIN Hotels h ON r.HotelId = h.Id
							WHERE HotelId = @HotelId
									AND (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
									OR CancelDate IS NOT NULL) 
									AND Beds >= @People
								GROUP BY r.Id, Type, BaseRate, Price
								ORDER BY (BaseRate + r.Price) + @People DESC)

	DECLARE @roomAvailable INT = (SELECT r.Id
									FROM Rooms r LEFT JOIN Trips t ON r.Id = t.RoomId 
										WHERE RoomId = @roomId AND @Date BETWEEN ArrivalDate AND ReturnDate)

	IF @roomAvailable IS NOT NULL OR @roomId IS NULL
	BEGIN
		RETURN 'No rooms available'
	END

		DECLARE @RoomType VARCHAR(50) = (SELECT Type FROM Rooms WHERE Id = @roomId)
		DECLARE @Beds VARCHAR(50) = (SELECT Beds FROM Rooms WHERE Id = @roomId)

		DECLARE @Price DECIMAL(18, 2) = (SELECT Price FROM Rooms WHERE Id = @roomId)
		DECLARE @Rating DECIMAL(18, 2) = (SELECT h.BaseRate FROM Rooms r JOIN Hotels h ON r.HotelId = h.Id  WHERE r.Id = @roomId)

		DECLARE @TotalPrice DECIMAL(18, 2) = (@Rating + @Price) * @People;

		RETURN ('Room ' + CONVERT(VARCHAR,@roomId) + ': ' + CONVERT(VARCHAR,@RoomType) + ' (' + CONVERT(VARCHAR,@Beds) + ' beds) - $' + CONVERT(VARCHAR,@TotalPrice))
END

--12. Switch Room

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @TripHotelId INT = (SELECT HotelId FROM Trips t JOIN Rooms r ON t.RoomId = r.Id WHERE t.Id = @TripId)
	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)

	IF @TripHotelId != @TargetRoomHotelId
	BEGIN
		RAISERROR('Target room is in another hotel!', 16, 1)
		RETURN
	END

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM Trips t
									JOIN AccountsTrips ta ON t.Id = ta.TripId
									JOIN Accounts a ON ta.AccountId = a.id
									WHERE t.Id = @TripId)

	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)

	IF (@TripAccounts > @TargetRoomBeds)
	BEGIN
		RAISERROR('Not enough beds in target room!', 16, 1)
		RETURN
	END

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
END
