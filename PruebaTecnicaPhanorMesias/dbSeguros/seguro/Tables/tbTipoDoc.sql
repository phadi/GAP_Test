CREATE TABLE [seguro].[tbTipoDoc] (
    [tipoDocId]     INT          IDENTITY (1, 1) NOT NULL,
    [tipoDocumento] VARCHAR (50) NULL,
    CONSTRAINT [PK_seguroTbTipoDoc] PRIMARY KEY CLUSTERED ([tipoDocId] ASC)
);

