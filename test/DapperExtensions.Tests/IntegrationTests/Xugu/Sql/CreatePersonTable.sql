DROP TABLE IF EXISTS Person;

CREATE TABLE Person (
    Id INT IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateCreated DATETIME,
    Active BOOLEAN,
    PRIMARY KEY(Id)
)