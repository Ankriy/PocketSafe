CREATE TABLE IF NOT EXISTS public."Task"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Subject" text COLLATE pg_catalog."default",
    "Description" text COLLATE pg_catalog."default",
    "UserId" integer NOT NULL,
    CONSTRAINT "Task_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT " fk_user_tasks" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
	
CREATE TABLE IF NOT EXISTS public."User"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default",
    "Surname" text COLLATE pg_catalog."default",
    "Email" text COLLATE pg_catalog."default",
    CONSTRAINT "User_pkey" PRIMARY KEY ("Id")
);
--CREATE TABLE IF NOT exists  public."User" (
--	"Id" serial4 NOT NULL,
--	"Name" varchar(50) NULL,
--	"Surname" varchar(50) NOT NULL,
--	"Email" varchar(128) NULL,
--	"CreatedDate" timestamptz NULL
--);

--CREATE TABLE IF NOT exists public."Task" (
--	"Id" serial4 NOT NULL,
--	"Subject" varchar(255) NULL,
--	"Description" text NULL,
--	"UserId" int4 NULL
--    CONSTRAINT "Task_pkey" PRIMARY KEY ("Id"),
--    CONSTRAINT " fk_user_tasks" FOREIGN KEY ("UserId")
--        REFERENCES public."User" ("Id") MATCH SIMPLE
--        ON UPDATE NO ACTION
--        ON DELETE NO ACTION
--);
