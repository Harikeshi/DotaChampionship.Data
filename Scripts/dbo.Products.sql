CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX)  NOT NULL,
    [Description]   NVARCHAR (MAX)  NOT NULL,
    [Price]         DECIMAL (18, 2) NOT NULL,
    [Category]      NVARCHAR (MAX)  NOT NULL,
    );

