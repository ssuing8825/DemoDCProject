-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.CreateToken
@BillingAccountId INT,
@Pec varchar(50),
@TokenNumber varchar(50)
AS
	SET NOCOUNT ON

	INSERT	INTO dbo.Token
			(BillingAccountId, Pec, TokenNumber)
	VALUES	(@BillingAccountId, @Pec, @TokenNumber)

	RETURN SCOPE_IDENTITY()