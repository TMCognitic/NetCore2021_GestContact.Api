CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY,
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Birthdate] DATE NULL, 
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
)
