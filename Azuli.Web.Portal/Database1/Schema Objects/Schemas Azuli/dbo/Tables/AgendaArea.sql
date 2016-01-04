USE [Azulli]
GO
/****** Object:  Table [dbo].[AgendaArea]    Script Date: 12/15/2012 20:17:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AgendaArea](
	[idArea] [int] NOT NULL,
	[idFormaAgenda] [int] NOT NULL,
	[dataFormaAgenda] [datetime] NOT NULL,
	[statusAgendaArea] [char](1) NULL,
	[msgAgendaArea] [nchar](30) NULL,
	[dataincAgendaArea] [datetime] NULL,
	[datacancAgendaArea] [datetime] NULL,
	[Bloco] [int] NULL,
	[Apartamento] [int] NULL,
 CONSTRAINT [PK_AgendaArea] PRIMARY KEY CLUSTERED 
(
	[idArea] ASC,
	[idFormaAgenda] ASC,
	[dataFormaAgenda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data da Agenda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'dataFormaAgenda'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A-Ativo, C-Cancelado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'statusAgendaArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Exemplo: Manutenção da parte eletrica do salão' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'msgAgendaArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data e hora de lançamento da agenda' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'dataincAgendaArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data e hora de cancelamento da agenda. Quando o status for alterado para C-Cancelado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'datacancAgendaArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Caso o agendamento da area foi feita para um bloco e apartamento esses campos serão preenchidos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'Bloco'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Caso o agendamento da area foi feita para um bloco e apartamento esses campos serão preenchidos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AgendaArea', @level2type=N'COLUMN',@level2name=N'Apartamento'
GO
ALTER TABLE [dbo].[AgendaArea]  WITH CHECK ADD  CONSTRAINT [FK_AgendaArea_APARTAMENTO] FOREIGN KEY([Bloco], [Apartamento])
REFERENCES [dbo].[APARTAMENTO] ([BLOCO], [APARTAMENTO])
GO
ALTER TABLE [dbo].[AgendaArea] CHECK CONSTRAINT [FK_AgendaArea_APARTAMENTO]
GO
ALTER TABLE [dbo].[AgendaArea]  WITH CHECK ADD  CONSTRAINT [FK_AgendaArea_FormaAgenda] FOREIGN KEY([idFormaAgenda], [idArea])
REFERENCES [dbo].[FormaAgenda] ([idFormaAgenda], [idArea])
GO
ALTER TABLE [dbo].[AgendaArea] CHECK CONSTRAINT [FK_AgendaArea_FormaAgenda]
