CREATE TABLE [dbo].[Teams] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50)  DEFAULT (N'') NOT NULL,
    [Url]  NVARCHAR (MAX) NULL,
    [File] IMAGE NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED ([Id] ASC)
);

