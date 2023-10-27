DROP TABLE IF EXISTS "Multikey";

CREATE TABLE "Multikey" (
    "Key1" serial NOT NULL,
    "Key2" character varying(50 char) NOT NULL,
    "Value" character varying(50 char) NULL,
    CONSTRAINT "con_public_Multikey_constraint_1" PRIMARY KEY (Key1, Key2)
);

ALTER SEQUENCE "Multikey_Key1_seq" INCREMENT BY 1;