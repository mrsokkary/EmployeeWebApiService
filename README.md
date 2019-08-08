#WebApi Example

this is Example Asp.net WebApi 2 Service with entity framwork 

used application: Visual Studio 2017

reference  : https://www.youtube.com/watch?v=6Rrnt3AKs2g&list=PL6n9fhu94yhW7yoUOGNOfHurUE6bpOO2b&index=21

SQL Query for the project

1. Creates EmployeeDB database
2. Creates the Employees table and populate it with sample data

Create Database EmployeeDB
Go

Use EmployeeDB
Go

Create table Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
)
Go

Insert into Employees values ('Mark', 'Hastings', 'Male', 60000)
Insert into Employees values ('Steve', 'Pound', 'Male', 45000)
Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into Employees values ('Philip', 'Hastings', 'Male', 45000)
Insert into Employees values ('Mary', 'Lambeth', 'Female', 30000)
Insert into Employees values ('Valarie', 'Vikings', 'Female', 35000)
Insert into Employees values ('John', 'Stanmore', 'Male', 80000)
Go
