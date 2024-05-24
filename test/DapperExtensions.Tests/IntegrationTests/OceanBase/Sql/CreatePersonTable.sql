DROP TABLE IF EXISTS Person;

CREATE TABLE Person (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateCreated DATETIME,
    Active BIT
)