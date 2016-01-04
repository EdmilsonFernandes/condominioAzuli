CREATE PROCEDURE [DBO].[SP_PROCURA_VISITANTE_NOME]  
@VisitanteId   as int,  
@VisitanteNome as char(80),  
@VisitanteRG   as char(10),  
@VisitanteTipo as char(1)  
AS  
BEGIN  
   
 SELECT @VisitanteId = [VisitanteId], @VisitanteRG = [VisitanteRG], @VisitanteTipo=[VisitanteTipo]  
 FROM [Visitante]  
 WHERE [VisitanteNome] LIKE '%'+@VisitanteNome+'%'
   
END  