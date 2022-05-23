CREATE VIEW [dbo].[ResultView]
	AS SELECT [s].[FirstName], [s].[LastName], [s].[PhoneNumber], [s].[Address],  [c].[Number] AS "Class Number", [c].[Letter] AS "Class Letter" FROM Student s
	Join Class c ON [c].[Id] = [s].[class_id];
