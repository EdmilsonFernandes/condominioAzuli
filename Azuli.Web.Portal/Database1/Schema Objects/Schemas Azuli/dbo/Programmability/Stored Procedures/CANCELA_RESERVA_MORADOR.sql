USE [Azulli]
GO
/****** Object:  StoredProcedure [dbo].[CANCELA_RESERVA_MORADOR]    Script Date: 02/20/2013 17:00:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CANCELA_RESERVA_MORADOR]
@DATA_AGENDA DATETIME,
@BLOCO INT,
@AP INT ,
@FESTA CHAR(10),
@CHURRAS CHAR(10)

AS
begin
	
 Begin
	if (@FESTA = 'N' AND @CHURRAS = 'S')
		begin
		  
			update AGENDA set SALAO_CHURRASCO = 'N'
			WHERE DATA_AGENDAMENTO = @DATA_AGENDA
			
			update AGENDA_MAE set SALAO_CHURRASCO = 'N'
			WHERE DATA_AGENDAMENTO = @DATA_AGENDA
		
			insert into historico_cancelamento values (@BLOCO,@AP,@DATA_AGENDA,'CANCELAMENTO DE CHURRASQUEIRA', GETDATE())
			
		 end
 End		 
 Begin
	Begin
		if (@FESTA = 'S' AND @CHURRAS = 'N')
		 begin
			update AGENDA set SALAO_FESTA = 'N'
			WHERE DATA_AGENDAMENTO = @DATA_AGENDA
			
			
			
			update AGENDA_MAE set SALAO_FESTA = 'N'
			WHERE DATA_AGENDAMENTO = @DATA_AGENDA
			
			insert into historico_cancelamento values (@BLOCO,@AP,@DATA_AGENDA,'CANCELAMENTO SALÃO DE FESTA', GETDATE())
		 end
	End
 End	
 End
	
	
	
  
  