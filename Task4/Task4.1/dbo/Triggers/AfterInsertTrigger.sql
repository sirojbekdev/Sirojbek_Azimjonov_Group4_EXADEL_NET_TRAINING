CREATE TRIGGER [AddStudentAfterInsertTrigger]
ON [Student]
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @FName NVARCHAR(50);
	DECLARE @LastName NVARCHAR(50);
	DECLARE @PhoneNum NVARCHAR(50);
	DECLARE @Address NVARCHAR(50);
	DECLARE @ClassID INT;
	SELECT @FName = UPPER(i.FirstName), @LastName = i.LastName, @PhoneNum = i.PhoneNumber, @Address = i.Address, @ClassID = i.class_id FROM INSERTED i;
	EXECUTE [dbo].[AddStudent] @FName, @LastName, @PhoneNum, @Address, @ClassID;
END
