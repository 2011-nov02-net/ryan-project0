-- Create schema for project0
CREATE SCHEMA Project0;
GO

-- Create User Table - 1 PK, 0 FK
-- Usertype 1 -> Customer
-- Usertype 2 -> Manager/Employee
CREATE TABLE Project0.Users (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	UserType INT NOT NULL DEFAULT 1
);

-- Create Product Table - 1 PK, 0 FK
CREATE TABLE Project0.Product (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(300) NOT NULL,
	Price MONEY NOT NULL
);

-- Create StoreLocation Table - 1 PK, 1 FK
CREATE TABLE Project0.StoreLocation (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(300) NOT NULL
);

-- Create StoreInventory Table - 1 PK, 2 FK
CREATE TABLE Project0.StoreInventory (
	LocationId INT NOT NULL FOREIGN KEY REFERENCES Project0.StoreLocation (Id),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Project0.Product (Id),
	ProductQty INT NOT NULL DEFAULT 0,
	PRIMARY KEY(LocationId, ProductId)
);

-- Create Orders Table - 1 PK, 2 FK
CREATE TABLE Project0.Orders (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Project0.Users (Id),
	StoreId INT NOT NULL FOREIGN KEY REFERENCES Project0.StoreLocation (Id),
	OrderTime DATETIME2 NOT NULL,
	OrderTotal MONEY NOT NULL
);

-- Create OrderProduct Table - 0 PK, 2 FK
CREATE TABLE Project0.OrderProduct (
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Project0.Orders (Id),
	ProductId INT NOT NULL FOREIGN KEY REFERENCES Project0.Product (Id),
	ProductQty INT NOT NULL,
	ProductPricePaid MONEY NOT NULL,
	PRIMARY KEY(OrderId,ProductId)
);

------------------------------------------------------------------------------
-- Add data to tables

--Add Some Users
INSERT INTO Project0.Users (FirstName, LastName, UserType) VALUES
	('Ryan', 'Towner', 2),
	('Bob', 'Bobson', 1),
	('John', 'Johnson', 1),
	('Andy', 'Anderson', 1);

--Add Some Stores
INSERT INTO Project0.StoreLocation (Name) VALUES
	('Miami'),
	('Chicago'),
	('Dallas');

--Add Some Products
INSERT INTO Project0.Product (Name, Price) VALUES
	('Cyberpunk 9999', 59.99),
	('Borderlands 15', 45.99),
	('Fifa 48', 64.99),
	('Madden 54', 58.99),
	('Battlefield 23', 55.99);

--Add Some Inventories
INSERT INTO Project0.StoreInventory (LocationId, ProductId, ProductQty) VALUES
	-- Miami
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 1), 1, 100),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 1), 3, 50),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 1), 5, 67),
	--Chicago
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 2), 1, 56),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 2), 2, 87),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 2), 3, 54),
	--Dallas
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 3), 1, 78),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 3), 4, 23),
	((SELECT Id FROM Project0.StoreLocation WHERE Id = 3), 5, 41);

--Add Some Orders
INSERT INTO Project0.Orders (UserId, StoreId, OrderTime, OrderTotal) VALUES
	((SELECT Id FROM Project0.Users WHERE Id = 1), 
	(SELECT Id FROM Project0.StoreLocation WHERE Id = 1), GETDATE(), 124.98);

--Add OrderProduct for order
INSERT INTO Project0.OrderProduct (OrderId, ProductId, ProductQty, ProductPricePaid) VALUES
	((SELECT Id FROM Project0.Orders WHERE Id = 1), (SELECT Id FROM Project0.Product WHERE Id = 1), 1, 59.99),
	((SELECT Id FROM Project0.Orders WHERE Id = 1), (SELECT Id FROM Project0.Product WHERE Id = 3), 1, 64.99);

---------------------------------------------------------------------------
--View tables
SELECT * FROM Project0.Users;
SELECT * FROM Project0.Product;
SELECT * FROM Project0.StoreLocation;
SELECT * FROM Project0.StoreInventory;
SELECT * FROM Project0.Orders;
SELECT * FROM Project0.OrderProduct;