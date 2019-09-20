CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL , 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedOn] DATETIME2(1) NULL DEFAULT GETDATE(), 
    [ModifiedBy] INT NULL, 
    [ModifiedOn] DATETIME2(1) NULL, 
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
)
