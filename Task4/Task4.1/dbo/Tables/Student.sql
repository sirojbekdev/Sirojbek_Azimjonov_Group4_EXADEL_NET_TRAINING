CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(50) NULL, 
    [class_id] INT NULL, 
    CONSTRAINT [FK_Student_ToTable] FOREIGN KEY ([class_id]) REFERENCES [Class]([Id])
)
