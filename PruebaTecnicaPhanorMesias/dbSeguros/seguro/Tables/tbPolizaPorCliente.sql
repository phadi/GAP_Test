CREATE TABLE [seguro].[tbPolizaPorCliente] (
    [PolizaPorClienteId] INT      IDENTITY (1, 1) NOT NULL,
    [clientreId]         INT      NULL,
    [polizaId]           INT      NULL,
    [fechaInicio]        DATETIME NULL,
    [fechaIFinal]        DATETIME NULL,
    CONSTRAINT [PK_seguroTbPolizaPorCliente] PRIMARY KEY CLUSTERED ([PolizaPorClienteId] ASC),
    CONSTRAINT [FK_tbPolizaPorCliente_tbCliente] FOREIGN KEY ([clientreId]) REFERENCES [seguro].[tbCliente] ([clienteId]),
    CONSTRAINT [FK_tbPolizaPorCliente_tbPoliza] FOREIGN KEY ([polizaId]) REFERENCES [seguro].[tbPoliza] ([polizaId])
);

