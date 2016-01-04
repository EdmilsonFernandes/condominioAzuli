CREATE PROCEDURE [dbo].[CADASTRA_RESERVA_MORADOR]
@DATA_AGENDA DATETIME,
@BLOCO INT,
@AP INT ,
@FESTA CHAR(10),
@CHURRAS CHAR(10)

	AS
	Declare @AUX DATETIME
	
	
	select @AUX =  data_agendamento  from agenda where data_agendamento = @DATA_AGENDA
	
	
	insert into AGENDA values (@DATA_AGENDA,@BLOCO,@AP,@FESTA,@CHURRAS)
	
	if ISNULL(@AUX,0) = 0
		 
		begin
		
		
			insert into AGENDA_MAE values (@DATA_AGENDA,@FESTA,@CHURRAS, GETDATE())
        
		End
    Else 		
		Begin 
	
		  IF @FESTA = 'S' 
		    Begin 
			update AGENDA_MAE SET SALAO_FESTA = @FESTA
			where Data_AGENDAMENTO = @DATA_AGENDA
			End
		  IF @CHURRAS = 'S' 
		    Begin 
				update AGENDA_MAE SET SALAO_CHURRASCO = @CHURRAS
				where Data_AGENDAMENTO = @DATA_AGENDA
			 End
		 
		 End


