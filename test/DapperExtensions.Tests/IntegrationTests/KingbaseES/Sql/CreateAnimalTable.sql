DROP TABLE IF EXISTS "Animal";

CREATE TABLE "Animal"
(
    "Id" character(36 char) NOT NULL, 
    "Name" character varying(50 char) NULL,
    CONSTRAINT "con_public_animal_constraint_1" PRIMARY KEY (Id)
)