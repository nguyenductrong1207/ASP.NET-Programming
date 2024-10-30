INSERT INTO Users (FullName, Description, Password, Email, Phone, Address, Status, CreatedDate, UserCode, IsLocked, IsDeleted, IsActive, ActiveCode, Avatar)
VALUES 
('Alice Johnson', 'Regular user', 'password123', 'alice@example.com', '1234567890', '123 Maple St', 1, GETDATE(), 'U001', 0, 0, 1, 'ACT123', '/avatars/alice.jpg'),
('Bob Smith', 'VIP user', 'password456', 'bob@example.com', '2345678901', '456 Oak St', 1, GETDATE(), 'U002', 0, 0, 1, 'ACT456', '/avatars/bob.jpg'),
('Cathy Lee', 'Library staff', 'password789', 'cathy@example.com', '3456789012', '789 Pine St', 1, GETDATE(), 'U003', 0, 0, 1, 'ACT789', '/avatars/cathy.jpg'),
('David Brown', 'Frequent visitor', 'password101', 'david@example.com', '4567890123', '101 Elm St', 1, GETDATE(), 'U004', 0, 0, 1, 'ACT101', '/avatars/david.jpg'),
('Eva Green', 'Book enthusiast', 'password102', 'eva@example.com', '5678901234', '202 Birch St', 1, GETDATE(), 'U005', 0, 0, 1, 'ACT102', '/avatars/eva.jpg');


INSERT INTO Loans (UserId, BookId, LoanDate, DueDate, ReturnDate, Status)
VALUES 
(1, 1, GETDATE(), DATEADD(day, 14, GETDATE()), NULL, 0),
(2, 2, GETDATE(), DATEADD(day, 14, GETDATE()), NULL, 0),
(3, 3, GETDATE(), DATEADD(day, 7, GETDATE()), GETDATE(), 1),
(4, 4, GETDATE(), DATEADD(day, 21, GETDATE()), NULL, 0),
(5, 5, GETDATE(), DATEADD(day, 14, GETDATE()), NULL, 2);


INSERT INTO Books (Title, Description, BookCode, Publisher, PublishedYear, CategoryId, AuthorId, TotalCopies, AvailableCopies, CreatedDate, Avatar, Pdf)
VALUES 
('C# Programming', 'Comprehensive guide to C#', 'B001', 'TechBooks', '2022-01-01', 1, 1, 5, 3, GETDATE(), '/books/csharp.jpg', '/books/csharp.pdf'),
('ASP.NET MVC', 'Learn ASP.NET MVC framework', 'B002', 'WebBooks', '2023-05-10', 2, 2, 4, 4, GETDATE(), '/books/aspnet.jpg', '/books/aspnet.pdf'),
('Entity Framework Core', 'Master EF Core', 'B003', 'DataBooks', '2021-03-15', 3, 3, 3, 2, GETDATE(), '/books/efcore.jpg', '/books/efcore.pdf'),
('LINQ in C#', 'Querying data with LINQ', 'B004', 'DataBooks', '2020-07-20', 1, 4, 2, 2, GETDATE(), '/books/linq.jpg', '/books/linq.pdf'),
('Design Patterns in C#', 'Understanding design patterns', 'B005', 'CodeBooks', '2019-11-25', 4, 5, 6, 6, GETDATE(), '/books/designpatterns.jpg', '/books/designpatterns.pdf');


INSERT INTO Authors (FirstName, LastName, DateOfBirth, Biography, Nationality, Email, Website, CreatedDate, IsActive, Avatar)
VALUES 
('John', 'Doe', '1975-06-15', 'Expert in C# programming', 'American', 'johndoe@example.com', 'https://johndoe.com', GETDATE(), 1, '/authors/johndoe.jpg'),
('Jane', 'Smith', '1982-02-28', 'Specialist in web development', 'British', 'janesmith@example.com', 'https://janesmith.com', GETDATE(), 1, '/authors/janesmith.jpg'),
('Tom', 'Brown', '1979-11-10', 'Database and EF Core expert', 'Canadian', 'tombrown@example.com', 'https://tombrown.com', GETDATE(), 1, '/authors/tombrown.jpg'),
('Emily', 'Clark', '1985-08-08', 'LINQ and data querying expert', 'Australian', 'emilyclark@example.com', 'https://emilyclark.com', GETDATE(), 1, '/authors/emilyclark.jpg'),
('Michael', 'Johnson', '1980-03-21', 'Expert in software design patterns', 'German', 'michaeljohnson@example.com', 'https://michaeljohnson.com', GETDATE(), 1, '/authors/michaeljohnson.jpg');


INSERT INTO Categories (Name, Description, CreatedDate, UpdatedDate, IsActive, Avatar)
VALUES 
('Programming', 'Books on various programming languages', GETDATE(), GETDATE(), 1, '/categories/programming.jpg'),
('Web Development', 'Resources for web development', GETDATE(), GETDATE(), 1, '/categories/webdev.jpg'),
('Database', 'Database management and development', GETDATE(), GETDATE(), 1, '/categories/database.jpg'),
('Software Design', 'Books on software design and patterns', GETDATE(), GETDATE(), 1, '/categories/softwaredesign.jpg'),
('Networking', 'Resources for network administration and security', GETDATE(), GETDATE(), 1, '/categories/networking.jpg');


