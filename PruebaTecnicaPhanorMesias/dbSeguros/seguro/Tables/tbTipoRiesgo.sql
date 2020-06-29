CREATE TABLE [seguro].[tbTipoRiesgo] (
    [tipoRiesgoId] INT          IDENTITY (1, 1) NOT NULL,
    [tipoRiesgo]   VARCHAR (50) NULL,
    CONSTRAINT [PK_seguroTbTipoRiesgo] PRIMARY KEY CLUSTERED ([tipoRiesgoId] ASC)
);

