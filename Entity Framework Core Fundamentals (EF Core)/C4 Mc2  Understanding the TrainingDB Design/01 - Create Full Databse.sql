/*
===========================================================
TrainingCenterDB
Full SQL Server Script
Purpose:
- Creates the database
- Creates all tables
- Creates keys and constraints
- Creates useful indexes
Designed for:
- Entity Framework Core Fundamentals
- Database First approach
===========================================================
*/

-----------------------------------------------------------
-- 1) Create Database
-----------------------------------------------------------
IF DB_ID('TrainingCenterDB') IS NULL
BEGIN
    CREATE DATABASE TrainingCenterDB;
END
GO


USE TrainingCenterDB;
GO

-----------------------------------------------------------
-- 2) Drop existing objects if they already exist
--    (Useful while rebuilding during course development)
-----------------------------------------------------------

-- Drop foreign keys first if needed by dropping tables in dependency order
IF OBJECT_ID('dbo.Enrollments', 'U') IS NOT NULL
    DROP TABLE dbo.Enrollments;
GO

IF OBJECT_ID('dbo.StudentProfiles', 'U') IS NOT NULL
    DROP TABLE dbo.StudentProfiles;
GO

IF OBJECT_ID('dbo.Courses', 'U') IS NOT NULL
    DROP TABLE dbo.Courses;
GO

IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL
    DROP TABLE dbo.Students;
GO

IF OBJECT_ID('dbo.Instructors', 'U') IS NOT NULL
    DROP TABLE dbo.Instructors;
GO

-----------------------------------------------------------
-- 3) Create Instructors
--    Includes optional self-reference through ManagerId
-----------------------------------------------------------
CREATE TABLE dbo.Instructors
(
    InstructorId INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    ManagerId INT NULL,
    IsActive BIT NOT NULL CONSTRAINT DF_Instructors_IsActive DEFAULT (1),

    CONSTRAINT PK_Instructors PRIMARY KEY (InstructorId),
    CONSTRAINT UQ_Instructors_Email UNIQUE (Email),

    -- Basic validation
    CONSTRAINT CK_Instructors_Salary CHECK (Salary >= 0)
);
GO

-----------------------------------------------------------
-- Add self-referencing FK after table creation
-----------------------------------------------------------
ALTER TABLE dbo.Instructors
ADD CONSTRAINT FK_Instructors_Manager
FOREIGN KEY (ManagerId)
REFERENCES dbo.Instructors(InstructorId)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

-----------------------------------------------------------
-- 4) Create Students
-----------------------------------------------------------
CREATE TABLE dbo.Students
(
    StudentId INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    DateOfBirth DATE NOT NULL,
    RegisteredAt DATETIME NOT NULL CONSTRAINT DF_Students_RegisteredAt DEFAULT (GETDATE()),
    Status NVARCHAR(20) NOT NULL,
    PhoneNumber NVARCHAR(30) NULL,

    CONSTRAINT PK_Students PRIMARY KEY (StudentId),
    CONSTRAINT UQ_Students_Email UNIQUE (Email),

    -- Allow only known values for student status
    CONSTRAINT CK_Students_Status CHECK (Status IN ('Active', 'Suspended', 'Graduated'))
);
GO

-----------------------------------------------------------
-- 5) Create Courses
-----------------------------------------------------------
CREATE TABLE dbo.Courses
(
    CourseId INT IDENTITY(1,1) NOT NULL,
    Title NVARCHAR(150) NOT NULL,
    Code NVARCHAR(30) NOT NULL,
    Description NVARCHAR(500) NULL,
    Price DECIMAL(10,2) NOT NULL,
    Level NVARCHAR(30) NOT NULL,
    DurationHours INT NOT NULL,
    CreatedAt DATETIME NOT NULL CONSTRAINT DF_Courses_CreatedAt DEFAULT (GETDATE()),
    PublishedAt DATETIME NULL,
    Status NVARCHAR(20) NOT NULL,
    InstructorId INT NOT NULL,

    CONSTRAINT PK_Courses PRIMARY KEY (CourseId),
    CONSTRAINT UQ_Courses_Code UNIQUE (Code),

    -- Basic validation
    CONSTRAINT CK_Courses_Price CHECK (Price >= 0),
    CONSTRAINT CK_Courses_DurationHours CHECK (DurationHours > 0),

    -- Controlled values for level
    CONSTRAINT CK_Courses_Level CHECK (Level IN ('Beginner', 'Intermediate', 'Advanced')),

    -- Controlled values for course status
    CONSTRAINT CK_Courses_Status CHECK (Status IN ('Draft', 'Published', 'Archived'))
);
GO

-----------------------------------------------------------
-- Add FK from Courses to Instructors
-----------------------------------------------------------
ALTER TABLE dbo.Courses
ADD CONSTRAINT FK_Courses_Instructors
FOREIGN KEY (InstructorId)
REFERENCES dbo.Instructors(InstructorId)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
GO

-----------------------------------------------------------
-- 6) Create StudentProfiles
--    One-to-One with Students
--    StudentId is both PK and FK
-----------------------------------------------------------
CREATE TABLE dbo.StudentProfiles
(
    StudentId INT NOT NULL,
    Address NVARCHAR(200) NULL,
    City NVARCHAR(100) NULL,
    Country NVARCHAR(100) NULL,
    Bio NVARCHAR(500) NULL,
    LinkedInUrl NVARCHAR(200) NULL,

    CONSTRAINT PK_StudentProfiles PRIMARY KEY (StudentId)
);
GO

ALTER TABLE dbo.StudentProfiles
ADD CONSTRAINT FK_StudentProfiles_Students
FOREIGN KEY (StudentId)
REFERENCES dbo.Students(StudentId)
ON DELETE CASCADE
ON UPDATE NO ACTION;
GO

-----------------------------------------------------------
-- 7) Create Enrollments
--    Many-to-Many between Students and Courses
--    Includes extra payload columns
-----------------------------------------------------------
CREATE TABLE dbo.Enrollments
(
    EnrollmentId INT IDENTITY(1,1) NOT NULL,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrollmentDate DATETIME NOT NULL CONSTRAINT DF_Enrollments_EnrollmentDate DEFAULT (GETDATE()),
    CompletionDate DATETIME NULL,
    ProgressPercent DECIMAL(5,2) NOT NULL CONSTRAINT DF_Enrollments_ProgressPercent DEFAULT (0),
    FinalGrade DECIMAL(5,2) NULL,
    Status NVARCHAR(20) NOT NULL,

    CONSTRAINT PK_Enrollments PRIMARY KEY (EnrollmentId),

    -- Prevent duplicate enrollment of same student in same course
    CONSTRAINT UQ_Enrollments_StudentId_CourseId UNIQUE (StudentId, CourseId),

    -- Validation rules
    CONSTRAINT CK_Enrollments_ProgressPercent CHECK (ProgressPercent >= 0 AND ProgressPercent <= 100),
    CONSTRAINT CK_Enrollments_FinalGrade CHECK (FinalGrade IS NULL OR (FinalGrade >= 0 AND FinalGrade <= 100)),
    CONSTRAINT CK_Enrollments_Status CHECK (Status IN ('Active', 'Completed', 'Dropped'))
);
GO

ALTER TABLE dbo.Enrollments
ADD CONSTRAINT FK_Enrollments_Students
FOREIGN KEY (StudentId)
REFERENCES dbo.Students(StudentId)
ON DELETE CASCADE
ON UPDATE NO ACTION;
GO

ALTER TABLE dbo.Enrollments
ADD CONSTRAINT FK_Enrollments_Courses
FOREIGN KEY (CourseId)
REFERENCES dbo.Courses(CourseId)
ON DELETE CASCADE
ON UPDATE NO ACTION;
GO

-----------------------------------------------------------
-- 8) Create Indexes
--    Useful for joins, filtering, and performance lessons
-----------------------------------------------------------
CREATE INDEX IX_Instructors_ManagerId
ON dbo.Instructors(ManagerId);
GO

CREATE INDEX IX_Courses_InstructorId
ON dbo.Courses(InstructorId);
GO

CREATE INDEX IX_Students_Status
ON dbo.Students(Status);
GO

CREATE INDEX IX_Courses_Status
ON dbo.Courses(Status);
GO

CREATE INDEX IX_Enrollments_StudentId
ON dbo.Enrollments(StudentId);
GO

CREATE INDEX IX_Enrollments_CourseId
ON dbo.Enrollments(CourseId);
GO

CREATE INDEX IX_Enrollments_Status
ON dbo.Enrollments(Status);
GO

-----------------------------------------------------------
-- 9) Optional Sample Verification Queries
-----------------------------------------------------------

-- View all user tables
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO

-- View foreign keys
SELECT
    fk.name AS ForeignKeyName,
    OBJECT_NAME(fk.parent_object_id) AS ChildTable,
    c1.name AS ChildColumn,
    OBJECT_NAME(fk.referenced_object_id) AS ParentTable,
    c2.name AS ParentColumn
FROM sys.foreign_keys fk
INNER JOIN sys.foreign_key_columns fkc
    ON fk.object_id = fkc.constraint_object_id
INNER JOIN sys.columns c1
    ON fkc.parent_object_id = c1.object_id
   AND fkc.parent_column_id = c1.column_id
INNER JOIN sys.columns c2
    ON fkc.referenced_object_id = c2.object_id
   AND fkc.referenced_column_id = c2.column_id
ORDER BY ChildTable, ParentTable;
GO