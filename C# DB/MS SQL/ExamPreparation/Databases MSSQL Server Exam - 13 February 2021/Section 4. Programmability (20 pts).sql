--11.	All User Commits

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @userId INT;
	SET @userId = (SELECT Id FROM Users WHERE Username = @username)

	RETURN (SELECT COUNT(*) FROM Commits WHERE ContributorId = @userId)
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--12.	 Search for Files

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
	SELECT Id, [Name], CONCAT(Size, 'KB') AS Size
		FROM Files WHERE [Name] LIKE N'%.' + @fileExtension
	  ORDER BY Id
END

EXEC usp_SearchForFiles 'txt'