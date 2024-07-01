DROP TABLE IF EXISTS FooTable;

CREATE TABLE FooTable (
    fooid serial PRIMARY KEY,
    first VARCHAR(50),
    last VARCHAR(50),
    birthdate TIMESTAMP
)