DROP TABLE IF EXISTS "Person";

CREATE TABLE "Person" (
    "Id" serial NOT NULL,
    "FirstName" character varying(50 char) NOT NULL,
    "LastName" character varying(50 char) NULL,
    "DateCreated" datetime,
    "Active" bool
);

ALTER SEQUENCE "Person_Id_seq" INCREMENT BY 1;