
CREATE PROCEDURE SelectAllEmployees
AS
Begin
SELECT * FROM dbo.EMPLOYEES
END;

CREATE PROCEDURE SelectUser @username nvarchar(50), @password nvarchar(50)
AS
Begin
SELECT * FROM dbo.tbl_data WHERE username=@username AND password=@password
END;

CREATE PROCEDURE SelectEmployee @id int
AS
Begin
SELECT * FROM dbo.EMPLOYEES Where Id=@id
END;

CREATE PROCEDURE DeleteEmployee @id int
AS
Begin
DELETE FROM dbo.EMPLOYEES Where Id=@id
END;

CREATE PROCEDURE AddEmployee @Name nvarchar(30), @email nvarchar(100), @Contact nvarchar(50), @Salary nvarchar(50)
AS
Begin
insert into dbo.employees(Name,email,Contact,Salary) values (@Name,@email,@Contact,@Salary);
END;

CREATE PROCEDURE EditEmployee @Name nvarchar(30), @email nvarchar(100), @Contact nvarchar(50), @Salary nvarchar(50), @id int
AS
Begin
update  dbo.employees set Name=@Name, email=@email, Contact = @Contact, Salary=@Salary where Id=@id;
END;

CREATE PROCEDURE EditEmployee @Name nvarchar(30), @email nvarchar(100), @Contact nvarchar(50), @Salary nvarchar(50), @id int
AS
Begin
update  dbo.employees set Name=@Name, email=@email, Contact = @Contact, Salary=@Salary where Id=@id;
END;