﻿DROP TABLE IF EXISTS Multikey;

CREATE TABLE Multikey (
    Key1 INT AUTO_INCREMENT,
    Key2 VARCHAR(50) NOT NULL,
    Value VARCHAR(50),
    PRIMARY KEY(Key1, Key2)
)