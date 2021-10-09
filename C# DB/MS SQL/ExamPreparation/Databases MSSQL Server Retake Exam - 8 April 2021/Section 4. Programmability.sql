--11.	Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
	BEGIN
		RETURN 0
	END

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

GO

--12.	Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @EmployeeDepartmentId INT;
	SET @EmployeeDepartmentId = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	DECLARE @CategoryDepartmentId INT;
	SET @CategoryDepartmentId = (SELECT c.DepartmentId FROM Reports r 
									   LEFT JOIN Categories c ON r.CategoryId = c.Id	
									WHERE r.Id = @ReportId)

	IF @EmployeeDepartmentId != @CategoryDepartmentId
	BEGIN
		RAISERROR ('Employee doesn''t belong to the appropriate department!',16, 1)
	END

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END