CREATE TABLE [seguro].[tbPoliza] (
    [polizaId]         INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (500) NULL,
    [descriocion]      VARCHAR (MAX) NULL,
    [tipoCubrimiento]  INT           NULL,
    [cubrimiento]      DECIMAL (18)  NULL,
    [inicioVigencia]   DATETIME      NULL,
    [periodoCobertura] INT           NULL,
    [precio]           MONEY         NULL,
    [tipoRiesgo]       INT           NULL,
    CONSTRAINT [PK_seguroTbPoliza] PRIMARY KEY CLUSTERED ([polizaId] ASC),
    CONSTRAINT [FK_tbPoliza_tbTipoCubrimiento] FOREIGN KEY ([tipoCubrimiento]) REFERENCES [seguro].[tbTipoCubrimiento] ([tipoCubrimientoId]),
    CONSTRAINT [FK_tbPoliza_tbTipoRiesgo] FOREIGN KEY ([tipoRiesgo]) REFERENCES [seguro].[tbTipoRiesgo] ([tipoRiesgoId])
);

