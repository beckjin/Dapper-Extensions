DROP TABLE IF EXISTS Multikey;

CREATE TABLE Multikey (
    key1 serial,
    key2 VARCHAR(50) NOT NULL,
    value VARCHAR(50),
    PRIMARY KEY(key1, key2)
)