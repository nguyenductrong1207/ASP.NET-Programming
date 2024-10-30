CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(200),
    Description NVARCHAR(MAX),
    Password NVARCHAR(MAX),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(MAX),
    Status INT,
    CreatedDate DATETIME,
    UserCode NVARCHAR(MAX),
    IsLocked BIT,
    IsDeleted BIT,
    IsActive BIT,
    ActiveCode NVARCHAR(MAX),
    Avatar NVARCHAR(MAX)
);

CREATE TABLE Loans (
    LoanId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    BookId INT,
    LoanDate DATETIME,
    DueDate DATETIME,
    ReturnDate DATETIME,
    Status INT
);

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    BookCode NVARCHAR(MAX),
    Publisher NVARCHAR(MAX),
    PublishedYear DATETIME,
    CategoryId INT,
    AuthorId INT,
    TotalCopies INT,
    AvailableCopies INT,
    CreatedDate DATETIME,
    Avatar NVARCHAR(MAX),
    Pdf NVARCHAR(MAX)
);

CREATE TABLE Authors (
    AuthorId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATETIME,
    Biography NVARCHAR(MAX),
    Nationality NVARCHAR(100),
    Email NVARCHAR(100),
    Website NVARCHAR(100),
    CreatedDate DATETIME,
    IsActive BIT,
    Avatar NVARCHAR(MAX)
);

CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    CreatedDate DATETIME,
    UpdatedDate DATETIME,
    IsActive BIT,
    Avatar NVARCHAR(MAX)
);
