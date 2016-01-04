CREATE PROCEDURE [DBO].[SP_ATUALIZA_VISITANTE]
@VisitanteId   as int,
@VisitanteNome as char(80),
@VisitanteRG   as char(10),
@VisitanteTipo as char(1)
AS
BEGIN
	
	DECLARE @Nome as char(80)
	DECLARE @RG   as char(10)
	DECLARE @Tipo as char(1)	
	
	SELECT @Nome = [VisitanteNome], @RG=[VisitanteRG], @Tipo=[VisitanteTipo]
	FROM [Visitante]
	WHERE [VisitanteId] = @VisitanteId
	
	IF (@Nome <> @VisitanteNome)
		UPDATE [Visitante] SET [VisitanteNome] = @VisitanteNome WHERE [VisitanteId] = @VisitanteId
	
	IF (@RG <> @VisitanteRG)
		UPDATE [Visitante] SET [VisitanteRG] = @VisitanteRG WHERE [VisitanteId] = @VisitanteId
		
	IF (@Tipo <> @VisitanteTipo)
		UPDATE [Visitante] SET [VisitanteTipo] = @VisitanteTipo WHERE [VisitanteId] = @VisitanteId
		
END
