
CREATE PROCEDURE EditEmployee @Name nvarchar(30), @email nvarchar(100), @Contact nvarchar(50), @Salary nvarchar(50), @id int
AS
Begin
update  dbo.employees set Name=@Name, email=@email, Contact = @Contact, Salary=@Salary where Id=@id;
END;