DROP TABLE IF EXISTS "FooTable";

CREATE TABLE "FooTable" (
    "FooId" serial NOT NULL,
    "First" character varying(50 char) NULL,
    "Last" character varying(50 char) NULL,
    "BirthDate" datetime NULL
);

ALTER SEQUENCE "FooTable_FooId_seq" INCREMENT BY 1;