DROP TABLE IF EXISTS "Multikey";

CREATE TABLE "Multikey" (
    "Key1" SERIAL,
    "Key2" VARCHAR(50) NOT NULL,
    "Value" VARCHAR(50) NULL,
    CONSTRAINT "con_public_Multikey_constraint_1" PRIMARY KEY (Key1, Key2)
);