CREATE PROCEDURE [dbo].[UpdateStudent]
	@ID INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNum NVARCHAR(50),
	@Address NVARCHAR(50),
	@ClassID INT
AS
	UPDATE [dbo].[Student] SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNum, Address = @Address, class_id = @ClassID
	WHERE Id = @ID;
GO;