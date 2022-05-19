CREATE TABLE [dbo].[Class_Subject]
(
	subject_id INT NOT NULL,
	class_id INT NOT NULL,
	CONSTRAINT [FK_Class_Subject_ToTable] FOREIGN KEY ([subject_id]) REFERENCES [Subject]([Id]),
	CONSTRAINT [FK_Subject_Class_ToTable] FOREIGN KEY ([class_id]) REFERENCES [Class]([Id]),
	UNIQUE ([subject_id], class_id)
);
