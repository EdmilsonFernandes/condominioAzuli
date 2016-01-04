CREATE PROCEDURE [DBO].[SP_VISITANTE]
@VisitanteNome as char(80),
@VisitanteRG   as char(10),
@VisitanteTipo as char(1)
AS
BEGIN
	Insert [Visitante] ([VisitanteNome] ,[VisitanteRG] ,[VisitanteTipo])
	Values (@VisitanteNome, @VisitanteRG, @VisitanteTipo )
END
