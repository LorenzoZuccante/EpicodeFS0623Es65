USE [PoliziaMunicipale]
GO
/****** Object:  Table [dbo].[COMUNICAZIONE]    Script Date: 02/03/2024 05:51:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMUNICAZIONE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDAnagrafica] [int] NOT NULL,
	[IDVerbale] [int] NOT NULL,
	[IDViolazione] [int] NOT NULL,
 CONSTRAINT [PK_COMUNICAZIONE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
