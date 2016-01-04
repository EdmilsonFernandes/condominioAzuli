CREATE PROCEDURE [DBO].[SP_PROCURA_VISITANTE_RG]  
@VisitanteId   as int,  
@VisitanteNome as char(80),  
@VisitanteRG   as char(10),  
@VisitanteTipo as char(1)  
AS  
BEGIN  
   
 SELECT @VisitanteId = [VisitanteId], @VisitanteNome = [VisitanteNome], @VisitanteTipo=[VisitanteTipo]  
 FROM [Visitante]  
 WHERE [VisitanteRG] = @VisitanteRG  
   
END  
