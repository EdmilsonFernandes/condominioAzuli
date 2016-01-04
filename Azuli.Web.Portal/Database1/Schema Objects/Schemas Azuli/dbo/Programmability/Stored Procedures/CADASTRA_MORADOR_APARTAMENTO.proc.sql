CREATE PROCEDURE [dbo].[CADASTRA_MORADOR_APARTAMENTO]
@BLOCO INT,
@AP INT ,
@morador1 varchar(20),
@morador2 varchar(20),
@senha varchar(50),
@retorno int output
AS
Declare @count int 

select @count = count(bloco) from APARTAMENTO where BLOCO =@BLOCO and APARTAMENTO = @AP

	
	
	 if(@count = 0)
		Begin
			insert into APARTAMENTO values (@BLOCO,@AP)
			insert into PROPRIETARIO values (@morador1,@morador2,@BLOCO,@AP,@senha)
			
			select @retorno = @count
		End
	  
	  Else
       
       Begin
       
       select @retorno = @count
       
       End


