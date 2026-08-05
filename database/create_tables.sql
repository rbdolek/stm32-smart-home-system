USE arayuz;
GO

CREATE TABLE dbo.kayit_tbl
(
    user_name VARCHAR(50) NOT NULL PRIMARY KEY,
    password VARCHAR(50),
    name VARCHAR(50),
    last_name VARCHAR(50),
    mail VARCHAR(50)
);
GO

CREATE TABLE dbo.Temperature_tbl
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Room NVARCHAR(50),
    Temperature FLOAT,
    [Timestamp] DATETIME DEFAULT GETDATE()
);
GO