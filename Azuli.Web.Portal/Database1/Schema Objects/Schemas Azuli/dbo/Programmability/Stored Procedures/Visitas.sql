USE [PORTALAZULI]
GO

/****** Object:  Table [dbo].[Visitas]    Script Date: 06/07/2013 23:00:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Visitas](
	[VisitaData] [datetime] NOT NULL,
	[VisitanteId] [int] NOT NULL,
	[Bloco] [smallint] NOT NULL,
	[Apartamento] [smallint] NOT NULL,
	[VisitaPlacaCarro] [char](10) NOT NULL,
	[VistaModeloCarro] [char](30) NOT NULL,
	[VisitaCorCarro] [char](12) NOT NULL,
	[VisitaAutorizada] [char](1) NOT NULL,
	[VisitaAutorizadaPor] [char](30) NOT NULL,
	[VistaObs] [char](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitaData] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Visitas]  WITH CHECK ADD  CONSTRAINT [IVISITAS1] FOREIGN KEY([VisitanteId])
REFERENCES [dbo].[Visitante] ([VisitanteId])
GO

ALTER TABLE [dbo].[Visitas] CHECK CONSTRAINT [IVISITAS1]
GO


