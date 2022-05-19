CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNum NVARCHAR(50),
	@Address NVARCHAR(50),
	@ClassID INT
AS
	INSERT INTO [dbo].[Student] VALUES(@FirstName, @LastName, @PhoneNum, @Address, @ClassID);
GO;
