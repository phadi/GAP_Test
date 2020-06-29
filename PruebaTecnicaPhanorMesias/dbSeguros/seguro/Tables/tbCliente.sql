CREATE TABLE [seguro].[tbCliente] (
    [clienteId]      INT           IDENTITY (1, 1) NOT NULL,
    [nombreCompleto] VARCHAR (500) NULL,
    [documento]      VARCHAR (50)  NULL,
    [tipoDoc]        INT           NULL,
    [direccrion]     VARCHAR (MAX) NULL,
    [telefono]       VARCHAR (20)  NULL,
    CONSTRAINT [PK_seguroTbCliente] PRIMARY KEY CLUSTERED ([clienteId] ASC),
    CONSTRAINT [FK_tbCliente_tbTipoDoc] FOREIGN KEY ([tipoDoc]) REFERENCES [seguro].[tbTipoDoc] ([tipoDocId]),
    CONSTRAINT [AK_DocumentoUser] UNIQUE NONCLUSTERED ([documento] ASC)
);

