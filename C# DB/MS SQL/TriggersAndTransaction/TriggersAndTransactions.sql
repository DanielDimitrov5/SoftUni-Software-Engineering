CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

CREATE TRIGGER tr_AddLog
ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @accountId INT
	DECLARE @oldSum MONEY
	DECLARE @newSum MONEY

	SET @accountId = (SELECT i.Id FROM inserted i)
	SET @oldSum = (SELECT d.Balance FROM deleted d)
	SET @newSum = (SELECT i.Balance FROM inserted i)

	INSERT INTO Logs
	VALUES (@accountId, @oldSum, @newSum)
END

GO

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES Accounts(Id) NOT NULL,
	[Subject] VARCHAR(90) NOT NULL,
	Body VARCHAR(250) NOT NULL
)

GO

CREATE TRIGGER tr_createTableEmails
ON Logs FOR INSERT
AS
BEGIN
	DECLARE @recipient INT
	DECLARE @subject VARCHAR(90)
	DECLARE @oldBalance MONEY
	DECLARE @newBalance MONEY
	DECLARE @body VARCHAR(200)

	SET @recipient = (SELECT i.AccountId FROM inserted AS i)
	SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(12))
	SET @oldBalance = (SELECT i.OldSum FROM inserted AS i)
	SET @newBalance = (SELECT i.NewSum FROM inserted AS i)
	SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(12)) 
	            + ' your balance was changed from ' + CAST(@oldBalance AS VARCHAR(20))
			    + ' to ' + CAST(@newBalance AS VARCHAR(20))

	INSERT INTO NotificationEmails
	VALUES (@recipient, @subject, @body)
END

GO

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 15, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts a
		WHERE a.Id = @AccountId) OR @AccountId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account ID', 15, 1)
		RETURN
	END

	UPDATE Accounts 
		SET Balance += @MoneyAmount
	  WHERE @AccountId = Id
COMMIT

GO

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 15, 1)
		RETURN
	END

	IF (NOT EXISTS(
		SELECT a.Id FROM Accounts a
		WHERE a.Id = @AccountId) OR @AccountId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account ID', 15, 1)
		RETURN
	END

	UPDATE Accounts 
		SET Balance -= @MoneyAmount
	  WHERE @AccountId = Id
COMMIT

GO

CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	EXEC usp_DepositMoney @ReceiverId, @Amount
	EXEC usp_WithdrawMoney @SenderId, @Amount
COMMIT

EXEC usp_TransferMoney 2, 1, 1000

GO