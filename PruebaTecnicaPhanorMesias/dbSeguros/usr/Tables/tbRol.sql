CREATE TABLE [usr].[tbRol] (
    [rolId] INT          IDENTITY (1, 1) NOT NULL,
    [rol]   VARCHAR (50) NULL,
    CONSTRAINT [PK_usrTbRol] PRIMARY KEY CLUSTERED ([rolId] ASC)
);

