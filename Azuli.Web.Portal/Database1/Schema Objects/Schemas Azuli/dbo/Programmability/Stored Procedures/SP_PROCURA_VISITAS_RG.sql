CREATE PROCEDURE [dbo].[SP_PROCURA_VISITAS_RG]
@VisitaData			 as DateTime,
@VisitanteId		 as Int,
@Bloco				 as SmallInt,
@Apartamento		 as SmallInt,
@VisitaPlacaCarro    as Char(10),
@VisitaModeloCarro   as Char(30),
@VisitaCorCarro      as Char(12),
@VisitaAutorizada    as Char(1),
@VisitaAutorizadaPor as Char(30),
@VisitaObs           as Char(100),
@VisitanteNome		 as char(80),
@VisitanteRG		 as char(10),
@VisitanteTipo		 as char(1),
@Foto				 as varbinary
AS
BEGIN
	Select @VisitaData			= [VisitaData],
		   @VisitanteId			= [VisitanteId],
		   @Bloco				= [Bloco], 
		   @Apartamento         = [Apartamento], 
		   @VisitaPlacaCarro    = [VisitaPlacaCarro], 
		   @VisitaModeloCarro   = [VistaModeloCarro], 
		   @VisitaCorCarro      = [VisitaCorCarro], 
		   @VisitaAutorizada    = [VisitaAutorizada], 
		   @VisitaAutorizadaPor = [VisitaAutorizadaPor], 
		   @VisitaObs           = [VistaObs],
		   @VisitanteNome		= [VisitanteNome],
		   --@VisitanteRG			= [VisitanteRG] ,
		   @VisitanteTipo		= [VisitanteTipo] ,
		   @Foto				= [Foto]
	From   [vVISITAS]
	Where  [VisitanteRG] = @VisitanteRG
end
