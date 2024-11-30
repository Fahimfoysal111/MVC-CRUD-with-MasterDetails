Create Database Employee11
go
use Employee11
go
create table Employee(EmployeeId int primary key identity(1,1),
EmployeeName varchar(30),
Age int,
DateOfJoining date,
Picture nvarchar(max),
EmployeeActive bit
)
go
create table Project (ProjectId int primary key,
ProjectName varchar (30))
go
create table ProjectAssignment
(AssignmentId int primary key identity(1,1),
EmployeeId int references Employee(EmployeeId),
ProjectId int references Project (ProjectId))
go
insert into Project
values(1,'HTML'),
(2,'CSS'),
(3,'JS')
go
select * from Project
select * from Employee
select * from ProjectAssignment