CREATE PROCEDURE [DBO].[SP_BAIXA_ENCOMENDAS]
@Bloco         as int,
@Apartamento   as int,
@EncDtaRec     as DateTime,
@EncQuemPegou  as nvarchar(30),
@EncQuanPegou  as DateTime,
@EncUserBxa    as nvarchar(50)
AS
BEGIN
	IF (@EncQuanPegou='17530101')
		SET @EncQuanPegou = GETDATE()
	
	UPDATE [dbo].[Encomendas] 
	SET [EncEntr]='S', 
		[EncQuemPegou]=@EncQuemPegou ,
		[EncQuanPegou]=@EncQuanPegou ,
		[EncUserBxa]=@EncUserBxa
	WHERE [Bloco]=@Bloco AND [Apartamento]=@Apartamento AND [EncDtaRec]=@EncDtaRec
	
END
