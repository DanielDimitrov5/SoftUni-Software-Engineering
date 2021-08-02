CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(8)
)

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT REFERENCES Passports(PassportID) UNIQUE NOT NULL
)

INSERT INTO Passports
VALUES (101, 'N34FG21B'),
	   (102, 'K65LO4R7'),
	   (103, 'ZE657QP2')

INSERT INTO Persons
VALUES	 ('Roberto', 43300.00, 102),
		 ('Tom', 56100.00, 103),
		 ('Yana', 60200.00, 101)
		 

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(90) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers
VALUES	(1, 'BMW', '07/03/1916'),
		(2, 'Tesla', '01/01/2003'),
		(3, 'Lada', '01/05/1966')

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(90) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models
VALUES	(101, 'X1', 1),
		(102, 'i6', 1),
		(103, 'Model S', 2),
		(104, 'Model X', 2),
		(105, 'Model 3', 2),
		(106, 'Nova', 3)



CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	[Name] VARCHAR(90) NOT NULL
)

INSERT INTO Students
VALUES	(1, 'Mila'),
		(2, 'Toni'),
		(3, 'Ron')

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY,
	[NAME] VARCHAR(90) NOT NULL
)

INSERT INTO Exams
VALUES	(101, 'SpringMVC'),
        (102, 'Neo4j'),
		(103, 'Oracle 11g')

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID)

	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams
VALUES	(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103)


CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY,
	[Name] VARCHAR(90) NOT NULL,
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES      (101, 'John', NULL),
            (102, 'Maya', 106),
            (103, 'Silvia', 106),
            (104, 'Ted', 105),
            (105, 'Mark', 101),
            (106, 'Greta', 101)