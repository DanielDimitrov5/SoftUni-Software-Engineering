CREATE DATABASE UniversityDatabase

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(90) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAccount VARCHAR(90) NOT NULL,
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY NOT NULL,
	SubjectName VARCHAR(90) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID)
	PRIMARY KEY (StudentID, SubjectID)
)	