CREATE PROCEDURE [DBO].[SP_ENCOMENDAS]
@Bloco         as int,
@Apartamento   as int,
@EncDtaRec     as DateTime,
@EncDesc       as nvarchar(50),
@EncEntr       as char(1),
@EncQuemPegou  as nvarchar(30),
@EncQuanPegou  as DateTime,
@EncUserBxa    as nvarchar(50)
AS
BEGIN
	Insert [dbo].[Encomendas] ([Bloco] ,[Apartamento] ,[EncDtaRec],[EncDesc],[EncEntr],[EncQuemPegou],[EncQuanPegou],[EncUserBxa])
	Values (@Bloco ,@Apartamento ,@EncDtaRec,@EncDesc,@EncEntr,@EncQuemPegou,@EncQuanPegou,@EncUserBxa )
END


