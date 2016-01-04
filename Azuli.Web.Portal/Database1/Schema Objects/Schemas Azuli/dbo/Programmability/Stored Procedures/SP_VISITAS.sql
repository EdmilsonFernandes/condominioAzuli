CREATE PROCEDURE [dbo].[SP_VISITAS]
@VisitaData			 as DateTime,
@VisitanteId		 as Int,
@Bloco				 as SmallInt,
@Apartamento		 as SmallInt,
@VisitaPlacaCarro    as Char(10),
@VisitaModeloCarro   as Char(30),
@VisitaCorCarro      as Char(12),
@VisitaAutorizada    as Char(1),
@VisitaAutorizadaPor as Char(30),
@VisitaObs           as Char(100)
AS
BEGIN
	Insert [VISITAS] ([VisitaData],[VisitanteId],[Bloco], [Apartamento], [VisitaPlacaCarro], [VistaModeloCarro], 
					  [VisitaCorCarro], [VisitaAutorizada], [VisitaAutorizadaPor], [VistaObs])

	Values (@VisitaData, @VisitanteId,@Bloco,@Apartamento,@VisitaPlacaCarro,@VisitaModeloCarro,@VisitaCorCarro,
			@VisitaAutorizada,@VisitaAutorizadaPor,@VisitaObs)
END
