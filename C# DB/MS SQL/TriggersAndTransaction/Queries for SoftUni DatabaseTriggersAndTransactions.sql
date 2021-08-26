CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @EmployeesProjects INT

	SET @EmployeesProjects = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = 2)

	IF (@EmployeesProjects >= 3)
	BEGIN
		RAISERROR ('The employee has too many projects!', 16, 1)
		ROLLBACK
	END

	INSERT INTO EmployeesProjects
	VALUES (@emloyeeId, @projectID)
COMMIT

EXEC usp_AssignProject 2,1
EXEC usp_AssignProject 2,2
EXEC usp_AssignProject 2,3
BEGIN TRY  
 EXEC usp_AssignProject 2,4
END TRY  
BEGIN CATCH  
   SELECT error_message()
END CATCH;

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY NOT NULL, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL,
	Salary MONEY NOT NULL
)

GO

CREATE TRIGGER tr_deleteEmployees
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary 
		FROM deleted AS d
END
