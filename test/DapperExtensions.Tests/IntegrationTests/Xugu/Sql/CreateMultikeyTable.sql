﻿DROP TABLE IF EXISTS Multikey;

CREATE TABLE Multikey (
    Key1 INT IDENTITY(1,1),
    Key2 VARCHAR(50) NOT NULL,
    Value VARCHAR(50),
    PRIMARY KEY(Key1, Key2)
)