CREATE PROCEDURE [dbo].[DeleteStudent]
	@ID INT
AS
	DELETE FROM [dbo].[Student] WHERE Id = @ID;
GO;