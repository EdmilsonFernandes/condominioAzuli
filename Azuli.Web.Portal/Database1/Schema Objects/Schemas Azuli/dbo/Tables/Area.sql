USE [Azulli]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/15/2012 20:12:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[idArea] [int] NOT NULL,
	[nomeArea] [nchar](20) NULL,
	[statusArea] [char](1) NULL CONSTRAINT [DF_Area_statusArea]  DEFAULT ('A'),
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Exemplo: Churrasqueira, Salão de Festa, Salão de Jogos, sala de reuniões, etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'nomeArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status: A-Ativo, C-Cancelado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'statusArea'
