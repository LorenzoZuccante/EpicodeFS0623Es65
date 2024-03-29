USE [PoliziaMunicipale]
GO
/****** Object:  Table [dbo].[VERBALE]    Script Date: 02/03/2024 05:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VERBALE](
	[IDVerbale] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [datetime] NOT NULL,
	[IndirizzoViolazione] [varchar](150) NOT NULL,
	[IDAgente] [int] NOT NULL,
	[DataTrascrizioneVerbale] [datetime] NOT NULL,
	[Importo] [money] NOT NULL,
	[DecurtamentoPunti] [tinyint] NOT NULL,
 CONSTRAINT [PK_VERBALE] PRIMARY KEY CLUSTERED 
(
	[IDVerbale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
