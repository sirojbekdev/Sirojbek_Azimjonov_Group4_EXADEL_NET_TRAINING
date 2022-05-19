CREATE FUNCTION [dbo].[GetFullName]
(
	@ID INT
)
RETURNS NCHAR(50)
AS
BEGIN
	DECLARE @name NCHAR(50);
	SELECT @name =  CONCAT(FirstName, ' ', LastName) FROM [dbo].[Student] WHERE [Id] = @ID
	RETURN @name 
END;
