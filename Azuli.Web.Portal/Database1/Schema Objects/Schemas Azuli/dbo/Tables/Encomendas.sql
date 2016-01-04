USE [PORTALAZULI]
GO

/****** Object:  Table [dbo].[Encomendas]    Script Date: 06/11/2013 00:07:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Encomendas](
	[Bloco] [int] NOT NULL,
	[Apartamento] [int] NOT NULL,
	[EncDtaRec] [datetime] NOT NULL,
	[EncDesc] [nvarchar](50) NULL,
	[EncEntr] [char](1) NULL,
	[EncQuemPegou] [nvarchar](30) NULL,
	[EncQuanPegou] [datetime] NULL,
	[EncUserBxa] [nvarchar](50) NULL,
 CONSTRAINT [PK_Encomendas] PRIMARY KEY CLUSTERED 
(
	[Bloco] ASC,
	[Apartamento] ASC,
	[EncDtaRec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descrição' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Encomendas', @level2type=N'COLUMN',@level2name=N'EncDesc'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Encomenda entregue? (S/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Encomendas', @level2type=N'COLUMN',@level2name=N'EncEntr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quem pegou' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Encomendas', @level2type=N'COLUMN',@level2name=N'EncQuemPegou'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quando Pegou data e hora' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Encomendas', @level2type=N'COLUMN',@level2name=N'EncQuanPegou'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuário que baixou no sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Encomendas', @level2type=N'COLUMN',@level2name=N'EncUserBxa'
GO


