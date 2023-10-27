DROP TABLE IF EXISTS "Car";

CREATE TABLE "Car" (
    "Id" character varying(15 char) NOT NULL,
    "Name" character varying(50 char) NULL,
    CONSTRAINT "con_public_Car_constraint_1" PRIMARY KEY (Id)
);