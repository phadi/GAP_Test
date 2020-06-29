CREATE TABLE [usr].[tbUsuario] (
    [usuarioId]  INT           IDENTITY (1, 1) NOT NULL,
    [login]      VARCHAR (50)  NULL,
    [nombres]    VARCHAR (150) NULL,
    [contrasena] VARCHAR (200) NULL,
    [rolId]      INT           NULL,
    CONSTRAINT [PK_usrTbUsuario] PRIMARY KEY CLUSTERED ([usuarioId] ASC),
    CONSTRAINT [FK_tbUsuario_tbRol] FOREIGN KEY ([rolId]) REFERENCES [usr].[tbRol] ([rolId]),
    CONSTRAINT [AK_usrLogin] UNIQUE NONCLUSTERED ([login] ASC)
);

