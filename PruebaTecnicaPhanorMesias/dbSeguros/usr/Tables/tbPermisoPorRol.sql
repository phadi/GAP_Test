CREATE TABLE [usr].[tbPermisoPorRol] (
    [permisoPorRolId] INT          IDENTITY (1, 1) NOT NULL,
    [rolId]           INT          NULL,
    [titulo]          VARCHAR (50) NULL,
    [accion]          VARCHAR (50) NULL,
    [controlador]     VARCHAR (50) NULL,
    [nivel]           INT          NULL,
    CONSTRAINT [PK_usrTbPermisoPorRol] PRIMARY KEY CLUSTERED ([permisoPorRolId] ASC),
    CONSTRAINT [FK_tbPermisoPorRol_tbRol] FOREIGN KEY ([rolId]) REFERENCES [usr].[tbRol] ([rolId])
);

