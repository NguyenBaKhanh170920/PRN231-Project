--CREATE DATABASE PRN231_Project;

USE PRN231_Project;

CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX)
);

INSERT INTO Category (CategoryName, Description)
VALUES 
('Fruits', 'All types of fresh fruits'),
('Meat', 'Various types of meat and poultry'),
('Beverages', 'Soft drinks, juices, and other beverages'),
('Snacks', 'Chips, cookies, and other snack items');

select*from Category
