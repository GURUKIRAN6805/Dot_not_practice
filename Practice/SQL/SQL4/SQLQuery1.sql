use InfiniteDB

create table tblDepartment
(  DeptNo int primary key,        --column level constraint
   DeptName varchar(15) not null,
   Budget float 
)
 
-- to retrieve the data from the table department
select * from tblDepartment
 
--create another table called employees
create table tblemployees(
Empid int primary key,
Empname varchar(40) not null,
Gender char(7),
Salary float,
DeptNo int references tbldepartment(DeptNo),  --foreign key 
)

--alter the table to add a column without data
alter table tblemployees
add Phoneno varchar(10) unique   -- constraint while adding a column after table creation

-- now let us add some data to the 2 tables
insert into tblDepartment values(1,'IT',2000000)
 
--to insert multiple rows/tuples with single insert into then we give as below
insert into tblDepartment values(2,'HR',null),
(5,'Testing',1000000),(3,'Admin',3000000),(4,'Operations',null)
 
--inserting data into table with only selected columns
insert into tblDepartment(DeptNo,DeptName) values(6,'Accounts')
 
select * from tblDepartment
 
--add a column to a table with data
alter table tbldepartment
add Loc nvarchar(20)
 
--we need to update the column Loc that was added after the table had data in it
update tblDepartment set loc = 'Pune' where deptno=6
 
--adding a constraint to a column of a table
alter table tbldepartment
add constraint con_uniq_loc unique (loc)
 
--let us add a check constraint on salary column of tblemployee table
alter table tblemployees
add constraint chksal check(Salary >=6000)
 
-- now let us add some data to the employee table
insert into tblemployees values(103, 'Anitha Gayathri', 'Female',6100,2, 2222211),
(102,'Adikeshava','Male',6200,1,3333221),(105,'Bindu','Female',6200,2,432125),
(101,'Abishek Lomte', 'Male',6000,3,'2345677')
 
select * from tblemployees
 
--adding a city column to the employees table with a default constraint
alter table tblemployees
add City varchar(30)
 
alter table tblemployees
add constraint city_def default 'Bangalore' for City
 
--inserting the default value for city
insert into tblemployees(Empid,Empname,Salary,DeptNo,phoneno) 
values(106,'Aman Ullah', 6300,4,73522380)
 
--inserting other than default value for the city column
 
insert into tblemployees(Empid,Empname,Salary,DeptNo,phoneno,city) 
values(107,'Ayesha', 6300,4,768522380,'Hyderabad')
 
 
--Foreign key constraints with alter
alter table tblemployees
add Foreign Key(DeptNo) references tbldepartment(Deptno)

create table Products
(ProductId int primary key,
Productname varchar(30) not null,
Price int,
QuantityAvailable int)
 
--let us populate data into products
insert into Products values(101,'Laptops',55000,100),
(102,'Desktops',35000,50),(103,'Tablets',60000,45),(104,'SmartPhones',45000,25)

CREATE FUNCTION dbo.GetTotalMaleEmployees()
RETURNS INT
AS
BEGIN
    DECLARE @TotalMaleEmployees INT;

    SELECT @TotalMaleEmployees = COUNT(*)
    FROM tblemployees
    WHERE gender = 'male';

    RETURN @TotalMaleEmployees;
END;

SELECT dbo.GetTotalMaleEmployees() AS total_male_employees;

CREATE FUNCTION dbo.AddTwoNumbers (
    @a1 INT,
    @b2 INT
)
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

    SET @result = @a1 + @b2;

    RETURN @result;
END;

DECLARE @x INT = 8;
DECLARE @y INT = 16;
DECLARE @sum INT;

SET @sum = dbo.AddTwoNumbers(@x, @y);

SELECT @sum AS result;

CREATE FUNCTION dbo.CalculateRectangleArea (
    @width DECIMAL(32, 5),
    @height DECIMAL(32, 5)
)
RETURNS DECIMAL(32, 5)
AS
BEGIN
    DECLARE @area DECIMAL(32, 5);

    SET @area = @width * @height;

    RETURN @area;
END;

DECLARE @width DECIMAL(32, 5) = 8.4;
DECLARE @height DECIMAL(32, 5) = 7.56;
DECLARE @area DECIMAL(32, 5);

SET @area = dbo.CalculateRectangleArea(@width, @height);

SELECT @area AS rectangle_area;

--multistatement tabled valued
create or alter function fn_GetEmployeesbyGender(@gender varchar(8))
returns
@EmpBygender table(
Empid int, EmployeeName varchar(40),
Gender varchar(7))
as
begin
--bulk insertion
insert into @EmpBygender
select Empid,Empname,gender from tblemployees 
where Gender= @gender
--handling exception situation
if @@ROWCOUNT = 0
begin
  insert into @EmpBygender
  values(0,'No Emp found with the given gender',null)
  end
return
end
 
--to execute the above function
select * from fn_GetEmployeesbyGender('male')

select * from tblemployees
 
alter table tblemployees add Remarks varchar(30)
 
--Transactions
-- 1.
begin transaction
select * from tblemployees where Empname='Bindu'
update tblemployees set remarks='Active'
where Empname='Bindu'
select * from tblemployees where Empname='Bindu'
 commit
 
--2.
begin tran
insert into tblemployees values(150,'Saajana','Female',6500,2,12345786,'Chennai',null) --this
save tran t1
select * from tblemployees
delete from tblemployees where Empid=150
select * from tblemployees where Empid=150
save tran t2
update tblDepartment set budget=50000 where DeptNo=2
select * from tblDepartment
rollback tran t1
commit  -- or rollback
 
select * from tblDepartment

select * from tblemployees

--Triggers
--1.
create trigger trgEmpIns
on tblemployees
for insert
as
 begin
  select * from inserted
  select * from tblemployees
end

insert into tblemployees values(300,'Tanmayee','Female',6700,1,998800,'Bangaluru',null)

--2.
create or alter trigger trgUpdEmp
on tblemployees
for update
as
begin
select * from deleted
select remarks from inserted
declare @status varchar(20)
select @status=remarks from inserted
if(@status='active')
 begin
 print 'Employee is active'
 end
end

update tblemployees set remarks ='active' where empid=150

--3.
create trigger trg_Nochanges
on tbldepartment
for insert,update,delete
as
begin
 print ' cannot manipulate table'
 rollback
 end

 select * from tblDepartment

 insert into tblDepartment values(100,'aa',567,'l1')

 update tblDepartment set loc='Cochin' where deptno=5

 drop trigger trg_nochanges

create table Employee_Audit(Msg varchar(max))
 
create or alter trigger trgAuditInsert
on tblemployees
for insert
as
begin
declare @id int
select @id=empid from inserted
 
insert into Employee_Audit
values('New Employee with Empid '+ ' '+ cast(@id as varchar(5)) + ' is added at '
+ cast(getdate() as nvarchar(20)))
end
 
insert into tblemployees values(200,'Banurekha','Female',6500,4,007,'Chennai',null)
 
select * from employee_audit

create table Employee_delete(Msg varchar(max))

create or alter trigger trgAuditdelete
on products
for delete
as
begin
declare @id int
select @id=ProductId from deleted
insert into Employee_delete
values('Employee with Empid '+ ' '+ cast(@id as varchar(5)) + ' is deleted at '
+ cast(getdate() as nvarchar(20)))
end 

delete from products where ProductId=102

select * from employee_delete

SELECT DeptNo, SUM(salary) AS total_salary
FROM tblemployees
GROUP BY ROLLUP(DeptNo);

SELECT d.deptname, SUM(e.salary) AS total_salary
FROM tblemployees e
JOIN tbldepartment d ON e.deptno = d.deptno
GROUP BY ROLLUP(d.deptname);

SELECT 
    COALESCE(d.deptname, 'General') AS Department,
    COALESCE(e.gender, 'All genders') AS Gender,
    SUM(e.salary) AS TotalSalary
FROM tblemployees e
LEFT JOIN tblDepartment d ON e.deptno = d.deptno
GROUP BY ROLLUP(d.deptname, e.gender);