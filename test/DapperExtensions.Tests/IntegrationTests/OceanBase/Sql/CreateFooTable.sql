﻿DROP TABLE IF EXISTS FooTable;

CREATE TABLE FooTable (
    FooId INT PRIMARY KEY AUTO_INCREMENT,
    `First` VARCHAR(50),
    `Last` VARCHAR(50),
    BirthDate DATETIME
)