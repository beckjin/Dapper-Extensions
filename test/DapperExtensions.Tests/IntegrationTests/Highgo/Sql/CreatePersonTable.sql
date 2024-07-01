DROP TABLE IF EXISTS Person;

CREATE TABLE Person (
    id serial PRIMARY KEY,
    firstname VARCHAR(50),
    lastname VARCHAR(50),
    datecreated TIMESTAMP,
    active BOOLEAN
)