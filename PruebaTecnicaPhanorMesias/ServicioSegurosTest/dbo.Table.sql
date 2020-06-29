CREATE TABLE [dbo].[tbPoliza]
(
	[polizaId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nombre] [varchar](500) NULL,
	[descriocion] [varchar](max) NULL,
	[tipoCubrimiento] [int] NULL,
	[cubrimiento] [decimal](18, 0) NULL,
	[inicioVigencia] [datetime] NULL,
	[periodoCobertura] [int] NULL,
	[precio] [money] NULL,
	[tipoRiesgo] [int] NULL
)
