USE StoreManagement

--create table for users
CREATE TABLE Users
(
	--NOT NULL constraint enforces a column to NOT accept NULL values
	--ID adds by 1 and starts from 1
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(120) NOT NULL,
	LastName VARCHAR(120) NOT NULL,
	Email VARCHAR(120) NOT NULL,
	--set password to varchar since it contains letters, numbers, and special characters
	UserPassword VARCHAR(20) NOT NULL
);