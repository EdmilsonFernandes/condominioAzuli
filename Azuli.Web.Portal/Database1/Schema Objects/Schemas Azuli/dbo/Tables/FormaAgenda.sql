USE [Azulli]
GO
/****** Object:  Table [dbo].[FormaAgenda]    Script Date: 12/15/2012 20:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormaAgenda](
	[idFormaAgenda] [int] NOT NULL,
	[idArea] [int] NOT NULL,
	[descricaoFormaAgenda] [nchar](30) NULL,
	[inicioFormaAgenda] [datetime] NULL,
	[fimFormaAgenda] [datetime] NULL,
	[statusFormaAgenda] [char](1) NULL,
 CONSTRAINT [PK_FormaAgenda] PRIMARY KEY CLUSTERED 
(
	[idFormaAgenda] ASC,
	[idArea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'exemplo: manhã, tarde e noite' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormaAgenda', @level2type=N'COLUMN',@level2name=N'descricaoFormaAgenda'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hora Inicial' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormaAgenda', @level2type=N'COLUMN',@level2name=N'inicioFormaAgenda'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hora Final' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormaAgenda', @level2type=N'COLUMN',@level2name=N'fimFormaAgenda'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A-Ativo, C-Cancelado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormaAgenda', @level2type=N'COLUMN',@level2name=N'statusFormaAgenda'
GO
ALTER TABLE [dbo].[FormaAgenda]  WITH CHECK ADD  CONSTRAINT [FK_FormaAgenda_Area] FOREIGN KEY([idArea])
REFERENCES [dbo].[Area] ([idArea])
GO
ALTER TABLE [dbo].[FormaAgenda] CHECK CONSTRAINT [FK_FormaAgenda_Area]
