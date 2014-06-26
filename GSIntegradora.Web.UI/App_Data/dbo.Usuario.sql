CREATE TABLE [dbo].[Usuario]
(
	[Codigo] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL,
	[Senha] VARCHAR(50) NOT NULL,
	[Ativo] BIT NULL
)
