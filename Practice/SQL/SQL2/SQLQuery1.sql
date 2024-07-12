use database infinteDB

-- Create emp table
CREATE TABLE emp (
    empno INT,
    ename VARCHAR(15),
    job VARCHAR(20),
    mgrid INT,
    hiredate DATE,
    sal FLOAT,
    comm INT,
    deptno INT
);
 
-- Insert data into emp table
INSERT INTO emp VALUES
(7369,'SMITH','CLERK',7902,'1980-12-17',800,NULL, 20),
(7499,'ALLEN','SALESMAN',7698,'1981-02-20',1600,300,30),
(7521,'WARD','SALESMAN',7698,'1981-02-22',1250,500,30),
(7566,'JONES','MANAGER',7839,'1981-04-02',2975,NULL,20),
(7654,'MARTIN','SALESMAN',7698,'1981-09-28',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'1981-05-01',2850,NULL,30),
(7782,'CLARK','MANAGER',7839,'1981-06-09',2450,NULL,10),
(7788,'SCOTT','ANALYST',7566,'1987-04-19',3000,NULL,20),
(7839,'KING','PRESIDENT',NULL,'1981-11-17',5000,NULL,10),
(7844,'TURNER','SALESMAN',7698,'1981-09-08',1500,0,30),
(7876,'ADAMS','CLERK',7788,'1987-05-23',1100,NULL,20),
(7900,'JAMES','CLERK',7698,'1981-12-03',950,NULL,30),
(7902,'FORD','ANALYST',7566,'1981-12-03',3000,NULL,20),
(7934,'MILLER','CLERK',7782,'1982-01-23',1300,NULL,10);
 
-- Select from emp table to verify data
SELECT * FROM emp;
 
-- Create dept table
CREATE TABLE dept (
    deptno INT,
    dname VARCHAR(15),
    loc VARCHAR(16)
);
 
-- Insert data into dept table
INSERT INTO dept VALUES
(10,'Accounting','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON');
 
-- Select from dept table to verify data
SELECT * FROM dept;
 
-- Create procedure to get manager ID and salary
CREATE PROCEDURE GetEmployeeManagerAndSalary
    @empno INT
AS
BEGIN
    -- Declare variables to store employee details
    DECLARE @mgrID INT;
    DECLARE @empSalary FLOAT;
 
    -- Retrieve employee details
    SELECT @mgrID = mgrid, @empSalary = sal
    FROM emp
    WHERE empno = @empno;
 
    -- Display the manager ID and salary
    SELECT @mgrID AS ManagerID, @empSalary AS Salary;
END;
 
-- Execute the procedure to test
EXEC GetEmployeeManagerAndSalary @empno = 7369;

DROP PROCEDURE IF EXISTS GetDeptAvgSalaryAndEmpCount;

CREATE PROCEDURE GetDeptAvgSalaryAndEmpCount
    @deptno INT,             -- Input parameter for department number
    @avgSalary FLOAT OUTPUT  -- Output parameter for average salary
AS
BEGIN
    -- Declare a variable to store the count of employees
    DECLARE @empCount INT;
 
    -- Retrieve the average salary and count of employees for the specified department
    SELECT @avgSalary = AVG(sal), @empCount = COUNT(*)
    FROM emp
    WHERE deptno = @deptno;
 
    -- Return the count of employees
    RETURN @empCount;
END;


DECLARE @averageSalary FLOAT;
DECLARE @employeeCount INT;
 
-- Execute the stored procedure
EXEC @employeeCount = GetDeptAvgSalaryAndEmpCount @deptno = 30, @avgSalary = @averageSalary OUTPUT;
 
-- Print the results
PRINT 'Average Salary: ' + CAST(@averageSalary AS VARCHAR(20));
PRINT 'Employee Count: ' + CAST(@employeeCount AS VARCHAR(20));



CREATE PROCEDURE GetDeptAvgSalaryAndEmpCount
    @deptno INT,             -- Input parameter for department number
    @avgSalary FLOAT OUTPUT  -- Output parameter for average salary
AS
BEGIN
    -- Declare a variable to store the count of employees
    DECLARE @empCount INT;
 
    -- Retrieve the average salary and count of employees for the specified department
    SELECT @avgSalary = AVG(sal), @empCount = COUNT(*)
    FROM emp
    WHERE deptno = @deptno;
 
    -- Return the count of employees
    RETURN @empCount;
END;


select * from emp


DECLARE @averageSalary FLOAT;
DECLARE @employeeCount INT;
 
-- Execute the stored procedure
EXEC @employeeCount = GetDeptAvgSalaryAndEmpCount @deptno = 30, @avgSalary = @averageSalary OUTPUT;
 
-- Select the results
SELECT @averageSalary AS AverageSalary, @employeeCount AS EmployeeCount;

