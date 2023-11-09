DROP TABLE IF EXISTS "Person";

CREATE TABLE "Person" (
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(50) NOT NULL,
    "LastName" VARCHAR(50) NULL,
    "DateCreated" TIMESTAMP,
    "Active" BOOLEAN
);