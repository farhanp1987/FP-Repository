CREATE TABLE BookDetails (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    ISBN NVARCHAR(20) NOT NULL,
    PublishYear INT NOT NULL,
    CoverPrice DECIMAL(10, 2) NOT NULL,
    IsCheckedOut BIT NOT NULL DEFAULT 0,
    CONSTRAINT CK_BookDetails_CoverPrice CHECK (CoverPrice >= 0)
);

--inserting some sample data into the "BookDetails" table
INSERT INTO BookDetails (Title, ISBN, PublishYear, CoverPrice)
VALUES 
('Lord of the Rings', 'ISBN001', 2023, 207.32),
('Pride and Prejudice', 'ISBN002', 2018, 314.27),
('Great Expectations', 'ISBN003', 2024, 549.34),
('Beloved', 'ISBN004', 2022, 375.84),
('War and Peace', 'ISBN005', 2021, 457.49);

CREATE TABLE CheckOutDetails (
    CheckOutId INT IDENTITY(1,1) PRIMARY KEY,
    BookId INT NOT NULL,
    BorrowerName NVARCHAR(100) NOT NULL,
    MobileNumber NVARCHAR(20) NOT NULL,
    NationalID NVARCHAR(11) NOT NULL,
    CheckedOutDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    CONSTRAINT FK_CheckOutDetails_BookDetails FOREIGN KEY (BookId) REFERENCES BookDetails (BookId)
);

CREATE TABLE ErrorsLog (
    ErrorId INT IDENTITY(1,1) PRIMARY KEY,
    ErrorMessage NVARCHAR(MAX) NOT NULL,
    ErrorDate DATETIME NOT NULL
);

SELECT BookId, Title, ISBN, PublishYear, CoverPrice, IsCheckedOut FROM BookDetails
select * from CheckOutDetails

SELECT b.Title, b.ISBN, b.PublishYear, b.CoverPrice, c.BorrowerName, c.MobileNumber, c.NationalID, c.CheckedOutDate, c.ReturnDate 
FROM BookDetails b inner join CheckOutDetails c on b.BookId = c.BookId
WHERE b.BookId = 4
