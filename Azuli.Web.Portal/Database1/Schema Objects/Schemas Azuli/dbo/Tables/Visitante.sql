USE [PORTALAZULI]
GO

/****** Object:  Table [dbo].[Visitante]    Script Date: 06/07/2013 22:46:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Visitante](
	[VisitanteId] [int] IDENTITY(1,1) NOT NULL,
	[VisitanteNome] [char](80) NOT NULL,
	[VisitanteRG] [char](10) NOT NULL,
	[VisitanteTipo] [char](1) NOT NULL,
	[VisitanteFoto] [varbinary](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitanteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


