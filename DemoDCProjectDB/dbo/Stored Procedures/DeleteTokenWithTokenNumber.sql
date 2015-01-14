-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTokenWithTokenNumber]
@TokenNumber varchar(50)
AS
	SET NOCOUNT ON

	DELETE 
	FROM	[dbo].[Token]
	WHERE	TokenNumber = @TokenNumber