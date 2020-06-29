CREATE TABLE [seguro].[tbTipoCubrimiento] (
    [tipoCubrimientoId] INT          IDENTITY (1, 1) NOT NULL,
    [tipoCubrimiento]   VARCHAR (50) NULL,
    CONSTRAINT [PK_seguroTbTipoCubrimiento] PRIMARY KEY CLUSTERED ([tipoCubrimientoId] ASC)
);

