-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.CreateToken
@Pec varchar(50),
@TokenNumber varchar(50)
AS
	SET NOCOUNT ON

	INSERT	INTO dbo.Token
			(Pec, TokenNumber)
	VALUES	(@Pec, @TokenNumber)

	RETURN SCOPE_IDENTITY()