/*
╔════════════════════════════════════════════════════════════════════╗
║ Code Overview                                                    ║
╠════════════════════════════════════════════════════════════════════╣
║ Purpose       → Expand seed data for advanced EF Core lessons    ║
║ Layout        → Add instructors → add students → add profiles →  ║
║                 add courses → add enrollments                    ║
║ Use Cases     → Performance, pagination, GroupBy, aggregates,    ║
║                 Include, ThenInclude, N+1, projections           ║
║ Key Properties→ Larger dataset, mixed statuses, varied dates,    ║
║                 dense many-to-many relationships                 ║
╚════════════════════════════════════════════════════════════════════╝
*/

USE TrainingCenterDB;
GO

------------------------------------------------------------
-- 1) Add more instructors
--    We check by email so the script is safer to rerun
------------------------------------------------------------
INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
SELECT 'Zein', 'Mousa', 'zein.mousa@trainingcenter.com', '2023-06-01', 3150.00, 1, 1
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Instructors WHERE Email = 'zein.mousa@trainingcenter.com'
);

INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
SELECT 'Farah', 'Nimr', 'farah.nimr@trainingcenter.com', '2023-08-14', 3050.00, 2, 1
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Instructors WHERE Email = 'farah.nimr@trainingcenter.com'
);

INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
SELECT 'Adnan', 'Saeed', 'adnan.saeed@trainingcenter.com', '2024-01-09', 2950.00, 3, 1
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Instructors WHERE Email = 'adnan.saeed@trainingcenter.com'
);

INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
SELECT 'Ruba', 'Hilal', 'ruba.hilal@trainingcenter.com', '2024-02-20', 2850.00, 1, 1
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Instructors WHERE Email = 'ruba.hilal@trainingcenter.com'
);

INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
SELECT 'Sameer', 'Awad', 'sameer.awad@trainingcenter.com', '2024-03-11', 2750.00, 2, 0
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Instructors WHERE Email = 'sameer.awad@trainingcenter.com'
);
GO

------------------------------------------------------------
-- 2) Add more students
--    This adds a larger student base for pagination,
--    sorting, filtering, grouping, and performance demos
------------------------------------------------------------
INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Ola', 'Kanaan', 'ola.kanaan@student.com', '2001-03-04', '2024-03-22 09:00:00', 'Active', '0799000021'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'ola.kanaan@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Hasan', 'Darwish', 'hasan.darwish@student.com', '1998-12-19', '2024-03-23 10:00:00', 'Graduated', '0799000022'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'hasan.darwish@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Ruba', 'Jamal', 'ruba.jamal@student.com', '2002-06-08', '2024-03-24 11:00:00', 'Active', '0799000023'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'ruba.jamal@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Anas', 'Bashir', 'anas.bashir@student.com', '1999-01-15', '2024-03-24 12:00:00', 'Suspended', '0799000024'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'anas.bashir@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Lama', 'Shami', 'lama.shami@student.com', '2000-08-27', '2024-03-25 09:30:00', 'Active', '0799000025'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'lama.shami@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Ibrahim', 'Khoury', 'ibrahim.khoury@student.com', '1997-04-30', '2024-03-25 13:10:00', 'Graduated', '0799000026'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'ibrahim.khoury@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Tasneem', 'Najar', 'tasneem.najar@student.com', '2003-02-11', '2024-03-26 08:40:00', 'Active', '0799000027'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'tasneem.najar@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Mahmoud', 'Zein', 'mahmoud.zein@student.com', '2001-10-07', '2024-03-26 10:20:00', 'Active', '0799000028'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'mahmoud.zein@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Raghad', 'Sabbah', 'raghad.sabbah@student.com', '1999-09-09', '2024-03-27 14:15:00', 'Suspended', '0799000029'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'raghad.sabbah@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Wael', 'Hamdi', 'wael.hamdi@student.com', '1998-05-02', '2024-03-28 09:45:00', 'Active', '0799000030'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'wael.hamdi@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Hiba', 'Salem', 'hiba.salem@student.com', '2002-12-01', '2024-03-28 11:30:00', 'Active', '0799000031'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'hiba.salem@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Nour', 'Khatib', 'nour.khatib@student.com', '2000-07-13', '2024-03-29 15:20:00', 'Graduated', '0799000032'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'nour.khatib@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Baraa', 'Mansouri', 'baraa.mansouri@student.com', '2001-11-06', '2024-03-30 09:10:00', 'Active', '0799000033'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'baraa.mansouri@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Sahar', 'Azzam', 'sahar.azzam@student.com', '1999-03-17', '2024-03-31 10:35:00', 'Active', '0799000034'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'sahar.azzam@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Yazan', 'Qadri', 'yazan.qadri@student.com', '2003-06-21', '2024-04-01 13:50:00', 'Active', '0799000035'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'yazan.qadri@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Mira', 'Badran', 'mira.badran@student.com', '2000-01-29', '2024-04-02 08:25:00', 'Suspended', '0799000036'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'mira.badran@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Ayman', 'Rizeq', 'ayman.rizeq@student.com', '1997-09-14', '2024-04-02 09:55:00', 'Graduated', '0799000037'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'ayman.rizeq@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Jood', 'Barakat', 'jood.barakat@student.com', '2002-04-18', '2024-04-03 12:40:00', 'Active', '0799000038'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'jood.barakat@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Khalil', 'Tibi', 'khalil.tibi@student.com', '2001-08-03', '2024-04-04 14:05:00', 'Active', '0799000039'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'khalil.tibi@student.com');

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
SELECT 'Dana', 'Rantisi', 'dana.rantisi@student.com', '1998-02-26', '2024-04-05 11:15:00', 'Active', '0799000040'
WHERE NOT EXISTS (SELECT 1 FROM dbo.Students WHERE Email = 'dana.rantisi@student.com');
GO

------------------------------------------------------------
-- 3) Add profiles for some of the new students only
--    This keeps optional one-to-one scenarios useful
------------------------------------------------------------
INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Khalda', 'Amman', 'Jordan', 'Interested in backend APIs and SQL optimization.', 'https://linkedin.com/in/olakanaan'
FROM dbo.Students s
WHERE s.Email = 'ola.kanaan@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Downtown', 'Amman', 'Jordan', 'Enjoys practical EF Core examples.', 'https://linkedin.com/in/rubajamal'
FROM dbo.Students s
WHERE s.Email = 'ruba.jamal@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Wasfi Al Tal', 'Amman', 'Jordan', 'Building strong fundamentals in programming.', 'https://linkedin.com/in/lamashami'
FROM dbo.Students s
WHERE s.Email = 'lama.shami@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Al Jamiaa', 'Irbid', 'Jordan', 'Interested in data modeling and LINQ.', 'https://linkedin.com/in/tasneemnajar'
FROM dbo.Students s
WHERE s.Email = 'tasneem.najar@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Tabarbour', 'Amman', 'Jordan', 'Wants to become a .NET backend developer.', 'https://linkedin.com/in/waelhamdi'
FROM dbo.Students s
WHERE s.Email = 'wael.hamdi@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Sweileh', 'Amman', 'Jordan', 'Strong interest in architecture and patterns.', 'https://linkedin.com/in/saharazzam'
FROM dbo.Students s
WHERE s.Email = 'sahar.azzam@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
SELECT s.StudentId, 'Al Bayader', 'Amman', 'Jordan', 'Learning performance tuning in applications.', 'https://linkedin.com/in/danarantisi'
FROM dbo.Students s
WHERE s.Email = 'dana.rantisi@student.com'
  AND NOT EXISTS (SELECT 1 FROM dbo.StudentProfiles sp WHERE sp.StudentId = s.StudentId);
GO

------------------------------------------------------------
-- 4) Add more courses
--    More instructors, more course levels, more statuses
------------------------------------------------------------
DECLARE @Instructor_Zein INT;
DECLARE @Instructor_Farah INT;
DECLARE @Instructor_Adnan INT;
DECLARE @Instructor_Ruba INT;
DECLARE @Instructor_Sameer INT;

SELECT @Instructor_Zein   = InstructorId FROM dbo.Instructors WHERE Email = 'zein.mousa@trainingcenter.com';
SELECT @Instructor_Farah  = InstructorId FROM dbo.Instructors WHERE Email = 'farah.nimr@trainingcenter.com';
SELECT @Instructor_Adnan  = InstructorId FROM dbo.Instructors WHERE Email = 'adnan.saeed@trainingcenter.com';
SELECT @Instructor_Ruba   = InstructorId FROM dbo.Instructors WHERE Email = 'ruba.hilal@trainingcenter.com';
SELECT @Instructor_Sameer = InstructorId FROM dbo.Instructors WHERE Email = 'sameer.awad@trainingcenter.com';

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Advanced SQL Performance', 'SQL-301', 'Indexing, execution plans, and tuning queries.', 230.00, 'Advanced', 34, '2024-02-02 10:00:00', '2024-03-01 10:00:00', 'Published', @Instructor_Zein
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'SQL-301');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'LINQ for Reporting', 'LINQ-301', 'Advanced grouping, projections, and reporting queries.', 175.00, 'Advanced', 26, '2024-02-04 11:00:00', '2024-03-03 11:00:00', 'Published', @Instructor_Farah
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'LINQ-301');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'HTML & CSS Foundations', 'WEB-101', 'Front-end foundations for beginners.', 80.00, 'Beginner', 20, '2024-02-06 09:00:00', '2024-03-05 09:00:00', 'Published', @Instructor_Adnan
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'WEB-101');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Design Patterns in C#', 'PAT-301', 'Learn classic design patterns in practical C# scenarios.', 240.00, 'Advanced', 38, '2024-02-08 12:00:00', '2024-03-08 12:00:00', 'Published', @Instructor_Ruba
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'PAT-301');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Docker Basics for Developers', 'DOCKER-201', 'Introduction to containers and Docker workflow.', 160.00, 'Intermediate', 24, '2024-02-10 13:30:00', '2024-03-10 13:30:00', 'Published', @Instructor_Zein
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'DOCKER-201');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Introduction to Algorithms', 'ALG-201', 'Core algorithms and problem-solving foundations.', 170.00, 'Intermediate', 30, '2024-02-12 14:15:00', '2024-03-12 14:15:00', 'Published', @Instructor_Farah
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'ALG-201');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Software Engineering Principles', 'SE-201', 'Requirements, design, maintainability, and quality.', 155.00, 'Intermediate', 28, '2024-02-14 15:00:00', '2024-03-14 15:00:00', 'Published', @Instructor_Adnan
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'SE-201');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'React Essentials', 'REACT-201', 'Build interactive UI with modern React.', 165.00, 'Intermediate', 27, '2024-02-16 16:00:00', '2024-03-16 16:00:00', 'Published', @Instructor_Sameer
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'REACT-201');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'System Design Basics', 'SYS-301', 'Scalability, architecture, and backend design basics.', 250.00, 'Advanced', 35, '2024-02-18 10:30:00', NULL, 'Draft', @Instructor_Ruba
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'SYS-301');

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
SELECT 'Windows Services in .NET', 'WS-201', 'Build and manage background services.', 145.00, 'Intermediate', 23, '2024-02-20 11:45:00', '2024-03-20 11:45:00', 'Archived', @Instructor_Zein
WHERE NOT EXISTS (SELECT 1 FROM dbo.Courses WHERE Code = 'WS-201');
GO

------------------------------------------------------------
-- 5) Dense enrollment generation for advanced scenarios
--    This intentionally creates:
--    - multiple students per course
--    - multiple courses per student
--    - mixed statuses
--    - varied progress
--    - varied grades
------------------------------------------------------------

;WITH StudentTargets AS
(
    SELECT StudentId
    FROM dbo.Students
    WHERE Email IN
    (
        'ola.kanaan@student.com',
        'hasan.darwish@student.com',
        'ruba.jamal@student.com',
        'anas.bashir@student.com',
        'lama.shami@student.com',
        'ibrahim.khoury@student.com',
        'tasneem.najar@student.com',
        'mahmoud.zein@student.com',
        'raghad.sabbah@student.com',
        'wael.hamdi@student.com',
        'hiba.salem@student.com',
        'nour.khatib@student.com',
        'baraa.mansouri@student.com',
        'sahar.azzam@student.com',
        'yazan.qadri@student.com',
        'mira.badran@student.com',
        'ayman.rizeq@student.com',
        'jood.barakat@student.com',
        'khalil.tibi@student.com',
        'dana.rantisi@student.com'
    )
),
CourseTargets AS
(
    SELECT CourseId, Code
    FROM dbo.Courses
    WHERE Code IN
    (
        'EF-101',
        'SQL-101',
        'SQL-301',
        'LINQ-201',
        'LINQ-301',
        'API-201',
        'ARCH-301',
        'PAT-301',
        'DOCKER-201',
        'ALG-201',
        'SE-201',
        'WEB-101',
        'REACT-201',
        'GIT-101',
        'DB-101'
    )
)
INSERT INTO dbo.Enrollments
(
    StudentId,
    CourseId,
    EnrollmentDate,
    CompletionDate,
    ProgressPercent,
    FinalGrade,
    Status
)
SELECT
    s.StudentId,
    c.CourseId,

    DATEADD(DAY, ((s.StudentId + c.CourseId) % 25), CAST('2024-04-01' AS DATETIME)) AS EnrollmentDate,

    CASE
        WHEN ((s.StudentId * c.CourseId) % 7) IN (0, 1)
            THEN DATEADD(DAY, 40 + ((s.StudentId + c.CourseId) % 15), CAST('2024-04-01' AS DATETIME))
        ELSE NULL
    END AS CompletionDate,

    CASE
        WHEN ((s.StudentId * c.CourseId) % 7) IN (0, 1) THEN 100.00
        WHEN ((s.StudentId + c.CourseId) % 5) = 0 THEN 15.00
        WHEN ((s.StudentId + c.CourseId) % 5) = 1 THEN 35.00
        WHEN ((s.StudentId + c.CourseId) % 5) = 2 THEN 55.00
        WHEN ((s.StudentId + c.CourseId) % 5) = 3 THEN 75.00
        ELSE 90.00
    END AS ProgressPercent,

    CASE
        WHEN ((s.StudentId * c.CourseId) % 7) IN (0, 1)
            THEN CAST(70 + ((s.StudentId + c.CourseId) % 27) AS DECIMAL(5,2))
        ELSE NULL
    END AS FinalGrade,

    CASE
        WHEN ((s.StudentId * c.CourseId) % 7) IN (0, 1) THEN 'Completed'
        WHEN ((s.StudentId + c.CourseId) % 9) = 0 THEN 'Dropped'
        ELSE 'Active'
    END AS Status
FROM StudentTargets s
CROSS JOIN CourseTargets c
WHERE ((s.StudentId + c.CourseId) % 3) <> 0
  AND NOT EXISTS
  (
      SELECT 1
      FROM dbo.Enrollments e
      WHERE e.StudentId = s.StudentId
        AND e.CourseId = c.CourseId
  );
GO

------------------------------------------------------------
-- 6) Add a few hand-picked enrollments for edge cases
--    Useful for very specific query demonstrations
------------------------------------------------------------

DECLARE @Student_Ola INT;
DECLARE @Student_Dana INT;
DECLARE @Student_Yazan INT;
DECLARE @Course_SYS301 INT;
DECLARE @Course_EF301 INT;
DECLARE @Course_SQL301 INT;

SELECT @Student_Ola   = StudentId FROM dbo.Students WHERE Email = 'ola.kanaan@student.com';
SELECT @Student_Dana  = StudentId FROM dbo.Students WHERE Email = 'dana.rantisi@student.com';
SELECT @Student_Yazan = StudentId FROM dbo.Students WHERE Email = 'yazan.qadri@student.com';

SELECT @Course_SYS301 = CourseId FROM dbo.Courses WHERE Code = 'SYS-301';
SELECT @Course_EF301  = CourseId FROM dbo.Courses WHERE Code = 'EF-301';
SELECT @Course_SQL301 = CourseId FROM dbo.Courses WHERE Code = 'SQL-301';

INSERT INTO dbo.Enrollments (StudentId, CourseId, EnrollmentDate, CompletionDate, ProgressPercent, FinalGrade, Status)
SELECT @Student_Ola, @Course_SYS301, '2024-04-06 09:00:00', NULL, 5.00, NULL, 'Active'
WHERE @Student_Ola IS NOT NULL AND @Course_SYS301 IS NOT NULL
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.Enrollments
      WHERE StudentId = @Student_Ola AND CourseId = @Course_SYS301
  );

INSERT INTO dbo.Enrollments (StudentId, CourseId, EnrollmentDate, CompletionDate, ProgressPercent, FinalGrade, Status)
SELECT @Student_Dana, @Course_SQL301, '2024-04-07 10:00:00', '2024-05-20 16:00:00', 100.00, 97.00, 'Completed'
WHERE @Student_Dana IS NOT NULL AND @Course_SQL301 IS NOT NULL
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.Enrollments
      WHERE StudentId = @Student_Dana AND CourseId = @Course_SQL301
  );

INSERT INTO dbo.Enrollments (StudentId, CourseId, EnrollmentDate, CompletionDate, ProgressPercent, FinalGrade, Status)
SELECT @Student_Yazan, @Course_EF301, '2024-04-08 11:00:00', NULL, 0.00, NULL, 'Dropped'
WHERE @Student_Yazan IS NOT NULL AND @Course_EF301 IS NOT NULL
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.Enrollments
      WHERE StudentId = @Student_Yazan AND CourseId = @Course_EF301
  );
GO

------------------------------------------------------------
-- 7) Verification queries
------------------------------------------------------------

-- Row counts after expansion
SELECT 'Instructors' AS TableName, COUNT(*) AS TotalRows FROM dbo.Instructors
UNION ALL
SELECT 'Students', COUNT(*) FROM dbo.Students
UNION ALL
SELECT 'StudentProfiles', COUNT(*) FROM dbo.StudentProfiles
UNION ALL
SELECT 'Courses', COUNT(*) FROM dbo.Courses
UNION ALL
SELECT 'Enrollments', COUNT(*) FROM dbo.Enrollments;
GO

-- Courses with higher enrollment counts
SELECT
    c.Code,
    c.Title,
    COUNT(e.EnrollmentId) AS TotalEnrollments
FROM dbo.Courses c
LEFT JOIN dbo.Enrollments e
    ON c.CourseId = e.CourseId
GROUP BY c.Code, c.Title
ORDER BY TotalEnrollments DESC, c.Code;
GO

-- Students with many enrollments
SELECT
    s.StudentId,
    s.FirstName,
    s.LastName,
    COUNT(e.EnrollmentId) AS TotalEnrollments
FROM dbo.Students s
LEFT JOIN dbo.Enrollments e
    ON s.StudentId = e.StudentId
GROUP BY s.StudentId, s.FirstName, s.LastName
ORDER BY TotalEnrollments DESC, s.StudentId;
GO

-- Average grade by course
SELECT
    c.Code,
    c.Title,
    AVG(e.FinalGrade) AS AverageFinalGrade
FROM dbo.Courses c
INNER JOIN dbo.Enrollments e
    ON c.CourseId = e.CourseId
WHERE e.FinalGrade IS NOT NULL
GROUP BY c.Code, c.Title
ORDER BY AverageFinalGrade DESC, c.Code;
GO

-- Status breakdown
SELECT
    Status,
    COUNT(*) AS TotalRows
FROM dbo.Enrollments
GROUP BY Status
ORDER BY TotalRows DESC;
GO