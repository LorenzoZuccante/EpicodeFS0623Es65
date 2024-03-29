USE [PoliziaMunicipale]
GO
/****** Object:  Table [dbo].[ANAGRAFE]    Script Date: 02/03/2024 05:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ANAGRAFE](
	[IdAnagrafica] [int] IDENTITY(1,1) NOT NULL,
	[Cognome] [varchar](30) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[Indirizzo] [varchar](150) NOT NULL,
	[Citta] [varchar](30) NOT NULL,
	[Cod_Fisc] [varchar](16) NOT NULL,
 CONSTRAINT [PK_ANAGRAFE] PRIMARY KEY CLUSTERED 
(
	[IdAnagrafica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
