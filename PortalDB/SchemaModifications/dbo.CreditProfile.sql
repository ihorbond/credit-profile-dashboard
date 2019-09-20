CREATE TABLE [dbo].[CreditProfile]
(
	[Id] INT NOT NULL , 
    [LineOfCredit] MONEY NOT NULL, 
    [Balance] MONEY NOT NULL DEFAULT 0, 
    [CustomerId] INT NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedOn] DATETIME2(1) NULL DEFAULT GETDATE(), 
    [ModifiedBy] INT NULL, 
    [ModifiedOn] DATETIME2(1) NULL, 
    CONSTRAINT [PK_CreditProfile] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_CreditProfile_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
