/*
╔════════════════════════════════════════════════════════════════════╗
║ Code Overview                                                    ║
╠════════════════════════════════════════════════════════════════════╣
║ Purpose       → Insert rich seed data into TrainingCenterDB      ║
║ Layout        → Instructors → Students → Profiles → Courses →    ║
║                 Enrollments                                       ║
║ Use Cases     → EF Core Fundamentals, LINQ queries, Include,     ║
║                 GroupBy, Aggregates, CRUD, Tracking, Performance ║
║ Key Properties→ Varied statuses, optional manager relation,      ║
║                 one-to-one profiles, many-to-many enrollments,   ║
║                 active/completed/dropped cases                   ║
╚════════════════════════════════════════════════════════════════════╝
*/

USE TrainingCenterDB;
GO

/* =========================================================
   Optional cleanup
   Uncomment these lines only if you want to reset all data
   ========================================================= */
/*
DELETE FROM dbo.Enrollments;
DELETE FROM dbo.StudentProfiles;
DELETE FROM dbo.Courses;
DELETE FROM dbo.Students;
DELETE FROM dbo.Instructors;

DBCC CHECKIDENT ('dbo.Enrollments', RESEED, 0);
DBCC CHECKIDENT ('dbo.Courses', RESEED, 0);
DBCC CHECKIDENT ('dbo.Students', RESEED, 0);
DBCC CHECKIDENT ('dbo.Instructors', RESEED, 0);
GO
*/

------------------------------------------------------------
-- 1) Insert Instructors
------------------------------------------------------------

-- Top-level managers first (ManagerId = NULL)
INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
VALUES
('Ahmed',   'Khalil',   'ahmed.khalil@trainingcenter.com',   '2018-03-10', 5500.00, NULL, 1),
('Sara',    'Nasser',   'sara.nasser@trainingcenter.com',    '2019-06-15', 5200.00, NULL, 1),
('Omar',    'Haddad',   'omar.haddad@trainingcenter.com',    '2020-01-20', 5000.00, NULL, 1);
GO

-- Other instructors referencing managers
INSERT INTO dbo.Instructors (FirstName, LastName, Email, HireDate, Salary, ManagerId, IsActive)
VALUES
('Lina',    'Samir',    'lina.samir@trainingcenter.com',     '2021-02-12', 3200.00, 1, 1),
('Yousef',  'Majed',    'yousef.majed@trainingcenter.com',   '2022-04-01', 3000.00, 1, 1),
('Noor',    'Saleh',    'noor.saleh@trainingcenter.com',     '2021-09-05', 3400.00, 2, 1),
('Huda',    'Rami',     'huda.rami@trainingcenter.com',      '2023-01-11', 2800.00, 2, 1),
('Khaled',  'Issa',     'khaled.issa@trainingcenter.com',    '2022-07-18', 3100.00, 3, 1),
('Maya',    'Fares',    'maya.fares@trainingcenter.com',     '2023-05-25', 2900.00, 3, 0);
GO

------------------------------------------------------------
-- 2) Insert Students
------------------------------------------------------------

INSERT INTO dbo.Students (FirstName, LastName, Email, DateOfBirth, RegisteredAt, Status, PhoneNumber)
VALUES
('Ali',      'Mansour',   'ali.mansour@student.com',      '2000-05-14', '2024-01-10 09:15:00', 'Active',     '0799000001'),
('Rana',     'Yasin',     'rana.yasin@student.com',       '1999-11-03', '2024-01-12 10:20:00', 'Active',     '0799000002'),
('Tariq',    'Adel',      'tariq.adel@student.com',       '2001-07-22', '2024-01-15 11:00:00', 'Suspended',  '0799000003'),
('Dina',     'Fouad',     'dina.fouad@student.com',       '1998-02-18', '2024-01-18 14:10:00', 'Graduated',  '0799000004'),
('Zaid',     'Karim',     'zaid.karim@student.com',       '2002-09-30', '2024-02-01 08:45:00', 'Active',     '0799000005'),
('Haneen',   'Samer',     'haneen.samer@student.com',     '2000-12-11', '2024-02-03 12:30:00', 'Active',     '0799000006'),
('Fadi',     'Nabil',     'fadi.nabil@student.com',       '1997-04-08', '2024-02-06 09:40:00', 'Graduated',  '0799000007'),
('Reem',     'Jaber',     'reem.jaber@student.com',       '2001-01-25', '2024-02-08 13:15:00', 'Active',     '0799000008'),
('Yara',     'Tamer',     'yara.tamer@student.com',       '1999-06-19', '2024-02-12 15:00:00', 'Suspended',  '0799000009'),
('Sami',     'Rashid',    'sami.rashid@student.com',      '2003-03-09', '2024-02-14 10:10:00', 'Active',     '0799000010'),
('Nadia',    'Walid',     'nadia.walid@student.com',      '2000-08-17', '2024-02-18 16:20:00', 'Active',     '0799000011'),
('Kareem',   'Latif',     'kareem.latif@student.com',     '1998-10-01', '2024-02-20 09:05:00', 'Graduated',  '0799000012'),
('Salma',    'Hadi',      'salma.hadi@student.com',       '2002-11-29', '2024-02-25 11:50:00', 'Active',     '0799000013'),
('Basil',    'Naser',     'basil.naser@student.com',      '1999-09-16', '2024-03-01 08:00:00', 'Active',     '0799000014'),
('Rami',     'Odeh',      'rami.odeh@student.com',        '2001-05-06', '2024-03-04 12:10:00', 'Suspended',  '0799000015'),
('Aseel',    'Maher',     'aseel.maher@student.com',      '2000-07-27', '2024-03-08 14:30:00', 'Active',     '0799000016'),
('Laith',    'Qasem',     'laith.qasem@student.com',      '1997-12-02', '2024-03-10 09:45:00', 'Graduated',  '0799000017'),
('Mariam',   'Ibrahim',   'mariam.ibrahim@student.com',   '2003-01-13', '2024-03-13 10:55:00', 'Active',     '0799000018'),
('Jana',     'Raed',      'jana.raed@student.com',        '2002-04-21', '2024-03-16 15:15:00', 'Active',     '0799000019'),
('Qusai',    'Hamdan',    'qusai.hamdan@student.com',     '1998-06-28', '2024-03-20 13:35:00', 'Active',     '0799000020');
GO

------------------------------------------------------------
-- 3) Insert Student Profiles
-- Not every student gets a profile on purpose
-- This helps explain optional related data in queries
------------------------------------------------------------

INSERT INTO dbo.StudentProfiles (StudentId, Address, City, Country, Bio, LinkedInUrl)
VALUES
(1,  '7th Circle',           'Amman',      'Jordan', 'Interested in backend development and APIs.',                 'https://linkedin.com/in/alimansour'),
(2,  'Dabouq',               'Amman',      'Jordan', 'Focuses on data analysis and reporting.',                    'https://linkedin.com/in/ranayasin'),
(4,  'Al Rabieh',            'Amman',      'Jordan', 'Graduated student exploring cloud technologies.',            'https://linkedin.com/in/dinafouad'),
(5,  'Sports City',          'Amman',      'Jordan', 'Enjoys C# and SQL Server.',                                  'https://linkedin.com/in/zaidkarim'),
(6,  'University Street',    'Irbid',      'Jordan', 'Strong interest in frontend and UX.',                        'https://linkedin.com/in/haneensamer'),
(7,  'Shmeisani',            'Amman',      'Jordan', 'Completed several technical courses successfully.',          'https://linkedin.com/in/fadinabil'),
(8,  'Abdoun',               'Amman',      'Jordan', 'Wants to become a full-stack developer.',                    'https://linkedin.com/in/reemjaber'),
(10, 'Jabal Amman',          'Amman',      'Jordan', 'Likes solving algorithmic challenges.',                      'https://linkedin.com/in/samirashid'),
(11, 'Hay Al Andalus',       'Zarqa',      'Jordan', 'Interested in software architecture.',                        'https://linkedin.com/in/nadiawalid'),
(13, 'Al Husn',              'Irbid',      'Jordan', 'Building strong fundamentals in programming.',               'https://linkedin.com/in/salmahadi'),
(16, 'Airport Road',         'Amman',      'Jordan', 'Learning EF Core and clean architecture.',                   'https://linkedin.com/in/aseelmaher'),
(17, 'Al Yarmouk',           'Irbid',      'Jordan', 'Graduated student preparing for interviews.',                'https://linkedin.com/in/laithqasem'),
(18, 'Marj Al Hamam',        'Amman',      'Jordan', 'Enjoys database design and LINQ.',                           'https://linkedin.com/in/mariamibrahim'),
(20, 'Madaba Road',          'Madaba',     'Jordan', 'Interested in analytics and dashboards.',                    'https://linkedin.com/in/qusaihamdan');
GO

------------------------------------------------------------
-- 4) Insert Courses
-- Mix of Draft / Published / Archived
-- Mix of Beginner / Intermediate / Advanced
------------------------------------------------------------

INSERT INTO dbo.Courses (Title, Code, Description, Price, Level, DurationHours, CreatedAt, PublishedAt, Status, InstructorId)
VALUES
('C# Fundamentals',                    'CSHARP-101', 'Introduction to C# programming fundamentals.',                    120.00, 'Beginner',     30, '2024-01-05 09:00:00', '2024-01-10 09:00:00', 'Published', 4),
('SQL Server Basics',                  'SQL-101',    'Learn SQL basics, queries, and joins.',                           110.00, 'Beginner',     25, '2024-01-06 10:00:00', '2024-01-12 10:00:00', 'Published', 5),
('Entity Framework Core Fundamentals', 'EF-101',     'Database First EF Core course for beginners.',                     150.00, 'Intermediate', 35, '2024-01-08 11:00:00', '2024-01-18 11:00:00', 'Published', 4),
('ASP.NET Core Web API',               'API-201',    'Build RESTful APIs using ASP.NET Core.',                           180.00, 'Intermediate', 40, '2024-01-10 12:00:00', '2024-01-22 12:00:00', 'Published', 6),
('Git & GitHub for Beginners',         'GIT-101',    'Version control fundamentals with Git and GitHub.',               90.00,  'Beginner',     20, '2024-01-12 13:00:00', '2024-01-25 13:00:00', 'Published', 7),
('LINQ Deep Dive',                     'LINQ-201',   'Master LINQ queries and projections.',                             140.00, 'Intermediate', 28, '2024-01-15 14:00:00', '2024-02-01 14:00:00', 'Published', 5),
('Database Design Essentials',         'DB-101',     'Learn normalization, keys, and relationships.',                   130.00, 'Beginner',     26, '2024-01-18 09:30:00', '2024-02-05 09:30:00', 'Published', 8),
('Advanced EF Core Performance',       'EF-301',     'Performance tuning in EF Core applications.',                     220.00, 'Advanced',     32, '2024-01-20 15:00:00', NULL,                   'Draft',     6),
('Clean Architecture in .NET',         'ARCH-301',   'Build maintainable .NET systems with clean architecture.',        210.00, 'Advanced',     36, '2024-01-22 10:15:00', '2024-02-10 10:15:00', 'Published', 1),
('Unit Testing with xUnit',            'TEST-201',   'Practical unit testing using xUnit.',                              125.00, 'Intermediate', 22, '2024-01-25 16:00:00', '2024-02-15 16:00:00', 'Published', 9),
('Legacy ADO.NET Systems',             'ADO-201',    'Working with older data access systems.',                         95.00,  'Intermediate', 18, '2024-01-28 11:45:00', '2024-02-18 11:45:00', 'Archived',  8),
('JavaScript Essentials',              'JS-101',     'JavaScript basics for web development.',                          100.00, 'Beginner',     24, '2024-02-01 08:30:00', '2024-02-20 08:30:00', 'Published', 7);
GO

------------------------------------------------------------
-- 5) Insert Enrollments
-- Mix of Active / Completed / Dropped
-- Mix of progress values and grades
-- This section is the most important for future queries
------------------------------------------------------------

INSERT INTO dbo.Enrollments (StudentId, CourseId, EnrollmentDate, CompletionDate, ProgressPercent, FinalGrade, Status)
VALUES
-- Student 1
(1, 1,  '2024-02-01 09:00:00', '2024-03-10 17:00:00', 100.00, 91.50, 'Completed'),
(1, 3,  '2024-03-15 10:00:00', NULL,                  65.00,  NULL,  'Active'),
(1, 5,  '2024-02-20 11:30:00', '2024-03-05 15:00:00', 100.00, 88.00, 'Completed'),

-- Student 2
(2, 2,  '2024-02-02 09:30:00', '2024-03-08 13:00:00', 100.00, 93.00, 'Completed'),
(2, 3,  '2024-03-12 14:00:00', NULL,                  82.00,  NULL,  'Active'),
(2, 6,  '2024-03-20 15:00:00', NULL,                  40.00,  NULL,  'Active'),

-- Student 3
(3, 1,  '2024-02-05 10:15:00', NULL,                  20.00,  NULL,  'Dropped'),
(3, 2,  '2024-02-06 10:30:00', NULL,                  15.00,  NULL,  'Dropped'),

-- Student 4
(4, 1,  '2024-01-25 08:00:00', '2024-02-28 16:00:00', 100.00, 95.00, 'Completed'),
(4, 2,  '2024-01-28 09:00:00', '2024-03-03 14:30:00', 100.00, 90.00, 'Completed'),
(4, 7,  '2024-02-15 12:00:00', '2024-03-18 18:00:00', 100.00, 92.00, 'Completed'),

-- Student 5
(5, 5,  '2024-03-01 09:00:00', NULL,                  70.00,  NULL,  'Active'),
(5, 12, '2024-03-05 13:00:00', NULL,                  55.00,  NULL,  'Active'),

-- Student 6
(6, 12, '2024-02-10 14:00:00', '2024-03-20 17:00:00', 100.00, 86.50, 'Completed'),
(6, 5,  '2024-03-25 10:00:00', NULL,                  25.00,  NULL,  'Active'),

-- Student 7
(7, 2,  '2024-01-18 09:00:00', '2024-02-22 12:00:00', 100.00, 89.00, 'Completed'),
(7, 3,  '2024-02-25 10:00:00', '2024-04-01 16:00:00', 100.00, 94.00, 'Completed'),
(7, 9,  '2024-03-05 11:00:00', NULL,                  35.00,  NULL,  'Active'),

-- Student 8
(8, 1,  '2024-02-14 09:45:00', NULL,                  78.00,  NULL,  'Active'),
(8, 4,  '2024-03-10 13:00:00', NULL,                  48.00,  NULL,  'Active'),
(8, 5,  '2024-02-18 15:00:00', '2024-03-02 11:00:00', 100.00, 84.00, 'Completed'),

-- Student 9
(9, 6,  '2024-03-01 08:30:00', NULL,                  10.00,  NULL,  'Dropped'),

-- Student 10
(10, 1, '2024-03-03 10:00:00', NULL,                  88.00,  NULL,  'Active'),
(10, 3, '2024-03-07 12:15:00', NULL,                  60.00,  NULL,  'Active'),
(10, 10,'2024-03-15 14:00:00', NULL,                  30.00,  NULL,  'Active'),

-- Student 11
(11, 7, '2024-02-20 09:20:00', '2024-03-30 16:40:00', 100.00, 90.50, 'Completed'),
(11, 9, '2024-03-22 11:10:00', NULL,                  22.00,  NULL,  'Active'),

-- Student 12
(12, 2, '2024-01-22 10:00:00', '2024-02-25 13:00:00', 100.00, 87.00, 'Completed'),
(12, 6, '2024-03-01 14:20:00', '2024-04-05 17:30:00', 100.00, 92.50, 'Completed'),
(12, 11,'2024-02-18 09:00:00', '2024-03-01 12:00:00', 100.00, 80.00, 'Completed'),

-- Student 13
(13, 1, '2024-03-10 08:15:00', NULL,                  42.00,  NULL,  'Active'),
(13, 5, '2024-03-11 10:25:00', NULL,                  90.00,  NULL,  'Active'),

-- Student 14
(14, 3, '2024-03-05 09:45:00', NULL,                  72.50,  NULL,  'Active'),
(14, 6, '2024-03-08 15:10:00', NULL,                  68.00,  NULL,  'Active'),
(14, 10,'2024-03-12 16:00:00', NULL,                  12.00,  NULL,  'Dropped'),

-- Student 15
(15, 4, '2024-03-03 12:00:00', NULL,                  18.00,  NULL,  'Dropped'),
(15, 12,'2024-03-06 13:30:00', NULL,                  35.00,  NULL,  'Active'),

-- Student 16
(16, 3, '2024-03-18 09:00:00', NULL,                  95.00,  NULL,  'Active'),
(16, 7, '2024-03-02 11:00:00', '2024-04-10 15:00:00', 100.00, 96.00, 'Completed'),

-- Student 17
(17, 2, '2024-01-16 10:10:00', '2024-02-20 14:00:00', 100.00, 85.50, 'Completed'),
(17, 3, '2024-02-21 09:20:00', '2024-03-28 16:20:00', 100.00, 89.50, 'Completed'),
(17, 9, '2024-04-01 10:45:00', NULL,                  45.00,  NULL,  'Active'),

-- Student 18
(18, 1, '2024-03-02 08:40:00', NULL,                  58.00,  NULL,  'Active'),
(18, 7, '2024-03-04 10:30:00', NULL,                  80.00,  NULL,  'Active'),
(18, 3, '2024-03-09 12:30:00', NULL,                  50.00,  NULL,  'Active'),

-- Student 19
(19, 5, '2024-03-07 11:15:00', NULL,                  65.00,  NULL,  'Active'),
(19, 12,'2024-03-10 14:10:00', NULL,                  72.00,  NULL,  'Active'),

-- Student 20
(20, 2, '2024-03-01 09:10:00', NULL,                  85.00,  NULL,  'Active'),
(20, 6, '2024-03-14 15:20:00', NULL,                  33.00,  NULL,  'Active'),
(20, 9, '2024-03-21 10:50:00', NULL,                  27.00,  NULL,  'Active');
GO

------------------------------------------------------------
-- 6) Optional verification queries
------------------------------------------------------------

-- Count rows in each table
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

-- Quick preview of students with profile (one-to-one)
SELECT
    s.StudentId,
    s.FirstName,
    s.LastName,
    sp.City,
    sp.Country
FROM dbo.Students s
LEFT JOIN dbo.StudentProfiles sp
    ON s.StudentId = sp.StudentId
ORDER BY s.StudentId;
GO

-- Quick preview of course enrollments (many-to-many)
SELECT
    c.Title,
    COUNT(e.EnrollmentId) AS TotalEnrollments
FROM dbo.Courses c
LEFT JOIN dbo.Enrollments e
    ON c.CourseId = e.CourseId
GROUP BY c.Title
ORDER BY TotalEnrollments DESC, c.Title;
GO