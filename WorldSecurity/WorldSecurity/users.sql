 -- Create the Users table
 CREATE TABLE users
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(100) NOT NULL,
    [Salt] NVARCHAR(50) NOT NULL
) ;
