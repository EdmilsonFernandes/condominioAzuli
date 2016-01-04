CREATE PROCEDURE [dbo].[RESERVA_MORADOR_CHURRAS]
@AP INT,
@BLOCO INT,
@ANO VARCHAR(12),
@MES VARCHAR(12)
AS
 BEGIN
	select * from agenda
	where Proprietario_ap = @AP
	and proprietario_bloco =@BLOCO
	and salao_churrasco = 'S'
	and YEAR(data_agendamento) = @ANO
	and MONTH(data_agendamento) = @MES
	order by DATA_AGENDAMENTO asc
 END


